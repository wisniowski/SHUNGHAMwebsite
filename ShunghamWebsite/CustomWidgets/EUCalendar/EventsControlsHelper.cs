using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
            Stopwatch sw = Stopwatch.StartNew();

            OpenServicePoint(eventsServiceUrl);

            IList<string> serviceUrls = new List<string>();
            var parsedJson = new List<EventModel>();
            for (int i = 1; i < 4; i++)
            {
                serviceUrls.Add(string.Format("{0}/{1}/{2}", eventsServiceUrl, i, 5000));
            }
            var tasks = serviceUrls.Select(GetAsync).ToArray();
            var completed = Task.Factory.ContinueWhenAll(tasks,
                                completedTasks =>
                                {
                                    foreach (var result in completedTasks.Select(t => t.Result))
                                    {
                                        parsedJson.AddRange(JsonConvert.DeserializeObject<List<EventModel>>(result));
                                    }
                                });
            completed.Wait();

            //anything that follows gets executed after all urls have finished downloading
            var events = parsedJson;

            //combines policy areas into a comma-separated list
            eventList = GroupEventsByPolicyArea(events);
            Log.Write(string.Format("Total number of events: {0}", eventList.Count), ConfigurationPolicy.Trace);

            if (eventList != null && eventList.Count > 0)
            {
                //TODO: extract this in a config
                var cacheExpirationTime = 60;
                CacheManager.Add(
                    cacheKeywordEvents,
                    eventList,
                    CacheItemPriority.Normal,
                    null,
                    new SlidingTime(TimeSpan.FromMinutes(cacheExpirationTime)));
            }
            sw.Stop();
            Log.Write(string.Format("Events parallel requests took total {0}", sw.Elapsed), ConfigurationPolicy.Trace);

            return eventList;
        }

        private static void OpenServicePoint(string url)
        {
            ServicePointManager.UseNagleAlgorithm = true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.CheckCertificateRevocationList = true;
            ServicePointManager.DefaultConnectionLimit = 100;
            Uri serviceUrl = new Uri(url);
            ServicePoint servicePoint = ServicePointManager.FindServicePoint(serviceUrl);
        }

        public static Task<string> GetAsync(string url)
        {
            var tcs = new TaskCompletionSource<string>();
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = requestMethod;
            request.ContentType = requestType;
            request.UseDefaultCredentials = true;
            request.PreAuthenticate = true;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Proxy = null;

            try
            {
                request.BeginGetResponse(iar =>
                {
                    HttpWebResponse response = null;
                    try
                    {
                        response = (HttpWebResponse)request.EndGetResponse(iar);
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            tcs.SetResult(reader.ReadToEnd());
                        }
                    }
                    catch (Exception exc) { tcs.SetException(exc); }
                    finally { if (response != null) response.Close(); }
                }, null);
            }
            catch (Exception exc)
            {
                Log.Write(exc.Message, ConfigurationPolicy.ErrorLog);
            }

            return tcs.Task;
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

                    if (policyAreasList != null && policyAreasList.Count > 0)
                    {
                        //TODO: extract this in a config
                        var cacheExpirationTime = 60;
                        CacheManager.Add(
                            cacheKeywordPolicyAreas,
                            policyAreasList,
                            CacheItemPriority.Normal,
                            null,
                            new SlidingTime(TimeSpan.FromMinutes(cacheExpirationTime)));
                    }

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
        private const string eventsServiceUrl = "http://www.shungham.com/SavedQueryService/Execute/filteredshunghamevents";
        private const string policyAreasServiceUrl = "http://www.shungham.com/SavedQueryService/Execute/policyareas";

        #endregion
    }
}