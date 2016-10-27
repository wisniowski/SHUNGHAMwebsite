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
                eventList = GetEventsFromSalesforce();
            }

            return eventList;
        }

        internal static IList<EventModel> GetEventsFromSalesforce()
        {
            List<EventModel> eventList = new List<EventModel>();

            WebRequest request = (WebRequest)WebRequest.Create(serviceUrl);
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

                    eventList = parsedJson;

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

        public static IList<EventModel> OrderEventsCollection(this IList<EventModel> eventList, string dateFormat, params string[] eventID)
        {
            //eventList = eventList
            //    .OrderBy(ev => DateTime.ParseExact(ev.StartDate, dateFormat, CultureInfo.CurrentCulture))
            //    .ThenBy(ev => ev.EventTitle).ToList();
            //if (eventID != null && eventID.Count() != 0)
            //{
            //    var featuredEvent = eventList.Where(eve => eve.EventId == eventID.FirstOrDefault()).FirstOrDefault();
            //    eventList.Remove(featuredEvent);
            //}

            return eventList;
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
        private const string serviceUrl = "http://shunghamdemo.crmportalconnector.com/SavedQueryService/Execute/ShunghamEvents";

        #endregion
    }
}