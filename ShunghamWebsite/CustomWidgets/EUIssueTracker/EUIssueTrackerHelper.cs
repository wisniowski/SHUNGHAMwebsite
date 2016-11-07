using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Caching;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker
{
    public class EUIssueTrackerHelper
    {
        internal static IList<EUIPolicyAreaModel> GetNavigationItems()
        {
            IList<EUIPolicyAreaModel> navItemsList = new List<EUIPolicyAreaModel>();

            if (((IList<EUIPolicyAreaModel>)CacheManager[cacheKeywordPAC]) != null)
            {
                navItemsList = (List<EUIPolicyAreaModel>)CacheManager[cacheKeywordPAC];
            }
            else
            {
                navItemsList = GetNavItemsFromMSDynamics();
            }

            return navItemsList;
        }

        internal static IList<EUIPolicyAreaModel> GetNavItemsFromMSDynamics()
        {
            IList<EUIPolicyAreaModel> policyAreasList = new List<EUIPolicyAreaModel>();

            WebRequest request = (WebRequest)WebRequest.Create(policyAreaServiceUrl);
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

                    var parsedJson = JsonConvert.DeserializeObject<List<EUIPolicyAreaModel>>(stringValue);

                    policyAreasList = parsedJson;

                    //TODO: extract this in a config
                    var cacheExpirationTime = 20;
                    CacheManager.Add(
                        cacheKeywordPAC,
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
        private const string cacheKeywordPAC = "policyAreasAndCategoriesCached";
        private const string policyAreaServiceUrl = "http://www.shungham.com/SavedQueryService/Execute/navigation";

        #endregion
    }
}