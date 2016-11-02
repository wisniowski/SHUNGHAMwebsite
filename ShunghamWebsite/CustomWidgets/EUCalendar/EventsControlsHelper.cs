using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Caching;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp.CustomWidgets.EUCalendar
{
    public static class EventsControlsHelper
    {
        internal static IList<EventModel> GetEventsList()
        {
            IList<EventModel> eventList = new List<EventModel>();

            if (((IList<EventModel>)CacheManager[cacheKeywordEvents]) != null)
            {
                eventList = (List<EventModel>)CacheManager[cacheKeywordEvents];
            }
            else
            {
                eventList = GetEventsFromMSDynamics();
            }

            return eventList;
        }

        internal static IList<PolicyAreaModel> GetPolicyAreasList()
        {
            IList<PolicyAreaModel> policyAreasList = new List<PolicyAreaModel>();

            if (((IList<PolicyAreaModel>)CacheManager[cacheKeywordPolicyAreas]) != null)
            {
                policyAreasList = (List<PolicyAreaModel>)CacheManager[cacheKeywordPolicyAreas];
            }
            else
            {
                policyAreasList = GetPolicyAreasFromMSDynamics();
            }

            return policyAreasList;
        }

        internal static IList<EventModel> GetEventsFromMSDynamics()
        {
            IList<EventModel> eventList = new List<EventModel>();

            WebRequest request = (WebRequest)WebRequest.Create(eventsServiceUrl);
            request.Method = requestMethod;
            request.ContentType = requestType;
            request.UseDefaultCredentials = true;
            request.PreAuthenticate = true;
            request.Credentials = CredentialCache.DefaultCredentials;

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string stringValue = reader.ReadToEnd();
                    reader.Close();

                    var parsedJson = JsonConvert.DeserializeObject<List<EventModel>>(stringValue);

                    var events = parsedJson;
                    eventList = GroupEventsByPolicyArea(events);

                    //TODO: extract this in a config
                    var cacheExpirationTime = 20;
                    CacheManager.Add(
                        cacheKeywordEvents,
                        eventList,
                        CacheItemPriority.Normal,
                        null,
                        new SlidingTime(TimeSpan.FromMinutes(cacheExpirationTime)));

                    return eventList;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return eventList;
            }
        }

        internal static IList<PolicyAreaModel> GetPolicyAreasFromMSDynamics()
        {
            IList<PolicyAreaModel> policyAreasList = new List<PolicyAreaModel>();

            WebRequest request = (WebRequest)WebRequest.Create(policyAreasServiceUrl);
            request.Method = requestMethod;
            request.ContentType = requestType;
            request.UseDefaultCredentials = true;
            request.PreAuthenticate = true;
            request.Credentials = CredentialCache.DefaultCredentials;

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string stringValue = reader.ReadToEnd();
                    reader.Close();

                    var parsedJson = JsonConvert.DeserializeObject<List<PolicyAreaModel>>(stringValue);

                    policyAreasList = parsedJson;

                    //TODO: extract this in a config
                    var cacheExpirationTime = 20;
                    CacheManager.Add(
                        cacheKeywordPolicyAreas,
                        policyAreasList,
                        CacheItemPriority.Normal,
                        null,
                        new SlidingTime(TimeSpan.FromMinutes(cacheExpirationTime)));

                    return policyAreasList;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return policyAreasList;
            }
        }

        public static IList<EventModel> OrderEventsCollection(this IList<EventModel> eventList, DateTime startDate)
        {

            eventList = eventList
                .Where(ev => ev.Attributes.new_eucstartdate.ToString("MMMM yyyy") == startDate.ToString("MMMM yyyy"))
                .OrderBy(ev => ev.Attributes.new_eucstarttime)
                .ThenBy(ev => ev.Attributes.cdi_name).ToList();

            return eventList;
        }

        public static IList<EventModel> GroupEventsByPolicyArea(IList<EventModel> ungroupedEvents)
        {
            IList<EventModel> result = new List<EventModel>();
            var events = from ev in ungroupedEvents
                         group ev by ev.Id into groupedEvents
                         select new
                         {
                             ID = groupedEvents.First().Id,
                             policyAreaName = string.Join(", ", (from p in groupedEvents select p.Attributes.policyAreaName.Value).ToArray())
                         };

            foreach (var e in events)
            {
                var eventItem = ungroupedEvents.Where(ev => ev.Id == e.ID).FirstOrDefault();
                if (eventItem != null)
                {
                    eventItem.Attributes.policyAreaName.Value = e.policyAreaName;
                    result.Add(eventItem);
                }
            }

            return result;
        }

        private static ICacheManager CacheManager
        {
            get
            {
                return SystemManager.GetCacheManager(CacheManagerInstance.Global);
            }
        }

        #region Public variables and constants

        public const string requestType = "application/x-www-form-urlencoded";
        public const string requestMethod = "GET";
        private const string cacheKeywordEvents = "eventListCached";
        private const string cacheKeywordPolicyAreas = "policyAreasListCached";
        private const string eventsServiceUrl = "http://shunghamdemo.crmportalconnector.com/SavedQueryService/Execute/filteredshunghamevents";
        private const string policyAreasServiceUrl = "http://shunghamdemo.crmportalconnector.com/SavedQueryService/Execute/shunghampolicyareas";

        #endregion
    }
}