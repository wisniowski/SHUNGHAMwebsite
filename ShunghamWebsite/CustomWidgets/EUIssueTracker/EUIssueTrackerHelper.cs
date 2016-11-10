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
    public static class EUIssueTrackerHelper
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

        internal static IList<EUDossierStatusModel> GetDossierStatuses()
        {
            IList<EUDossierStatusModel> dossierStatusesList = new List<EUDossierStatusModel>();

            if (((IList<EUDossierStatusModel>)CacheManager[cacheKeywordDossierStatuses]) != null)
            {
                dossierStatusesList = (List<EUDossierStatusModel>)CacheManager[cacheKeywordDossierStatuses];
            }
            else
            {
                dossierStatusesList = GetDossierStatusesFromMSDynamics();
            }

            return dossierStatusesList;
        }

        internal static IList<EUDossierModel> GetDossiers()
        {
            IList<EUDossierModel> dossiersList = new List<EUDossierModel>();

            if (((IList<EUDossierModel>)CacheManager[cacheKeywordDossiers]) != null)
            {
                dossiersList = (List<EUDossierModel>)CacheManager[cacheKeywordDossiers];
            }
            else
            {
                dossiersList = GetDossiersFromMSDynamics();
            }

            return dossiersList;
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

        internal static IList<EUDossierStatusModel> GetDossierStatusesFromMSDynamics()
        {
            IList<EUDossierStatusModel> dossierStatusesList = new List<EUDossierStatusModel>();

            WebRequest request = (WebRequest)WebRequest.Create(dossierStatusServiceUrl);
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

                    var parsedJson = JsonConvert.DeserializeObject<List<EUDossierStatusModel>>(stringValue);

                    dossierStatusesList = parsedJson;

                    //TODO: extract this in a config
                    var cacheExpirationTime = 20;
                    CacheManager.Add(
                        cacheKeywordDossierStatuses,
                        dossierStatusesList,
                        CacheItemPriority.Normal,
                        null,
                        new SlidingTime(TimeSpan.FromMinutes(cacheExpirationTime)));

                    return dossierStatusesList;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return dossierStatusesList;
            }
        }

        internal static IList<EUDossierModel> GetDossiersFromMSDynamics()
        {
            IList<EUDossierModel> dossiersList = new List<EUDossierModel>();

            WebRequest request = (WebRequest)WebRequest.Create(dossierServiceUrl);
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

                    var parsedJson = JsonConvert.DeserializeObject<List<EUDossierModel>>(stringValue);

                    dossiersList = parsedJson;

                    //TODO: extract this in a config
                    var cacheExpirationTime = 20;
                    CacheManager.Add(
                        cacheKeywordDossiers,
                        dossiersList,
                        CacheItemPriority.Normal,
                        null,
                        new SlidingTime(TimeSpan.FromMinutes(cacheExpirationTime)));

                    return dossiersList;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return dossiersList;
            }
        }

        /// <summary>
        /// Gets the dossiers count by status.
        /// </summary>
        /// <param name="dossiersList">The dossiers list.</param>
        /// <param name="statusName">Name of the status.</param>
        /// <returns></returns>
        public static int GetDossiersCountByStatus(this IList<EUDossierModel> dossiersList, string statusName)
        {
            var count = dossiersList.Where(d => d.Attributes.status.Value == statusName).Count();
            return count;
        }

        /// <summary>
        /// Filters the dossiers by status.
        /// </summary>
        /// <param name="dossiersList">The dossiers list.</param>
        /// <param name="statusName">Name of the status.</param>
        /// <returns></returns>
        public static IList<EUDossierModel> FilterDossiersByStatus(this IList<EUDossierModel> dossiersList, string statusName)
        {
            dossiersList = dossiersList.Where(d => d.Attributes.status.Value == statusName).ToList();
            return dossiersList;
        }

        /// <summary>
        /// Filters the dossiers by policy area and category.
        /// </summary>
        /// <param name="dossiersList">The dossiers list.</param>
        /// <param name="areaName">Name of the area.</param>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns></returns>
        public static IList<EUDossierModel> FilterDossiersByPolicyAreaAndCategory(this IList<EUDossierModel> dossiersList, string areaName, string categoryName)
        {
            dossiersList = dossiersList.Where(d => d.Attributes.policyAreaName.Value == areaName &&
                d.Attributes.policyCategoryName.Value == categoryName).ToList();
            return dossiersList;
        }

        /// <summary>
        /// Restricts the dossiers list so that dossiers with status "Future Initiatives", 
        /// "Dormant" and "Shelved" are not displayed.
        /// </summary>
        /// <param name="dossiersList">The dossiers list.</param>
        /// <returns></returns>
        public static IList<EUDossierModel> RestrictDossiersByStatus(this IList<EUDossierModel> dossiersList)
        {
            return dossiersList.Where(d => d.Attributes.status.Value != "Future Initiatives" &&
                d.Attributes.status.Value != "Shelved" && d.Attributes.status.Value != "Dormant").ToList();
        }

        /// <summary>
        /// Gets the nav item by URL parameters.
        /// </summary>
        /// <param name="urlParams">The URL parameters.</param>
        /// <returns></returns>
        public static NavigationItem GetNavItemByUrlParams(string[] urlParams)
        {
            NavigationItem navItem = null;
            if (urlParams != null && urlParams.Count() > 0)
            {
                navItem = navItems
                    .Where(n => n.policyAreaURL == urlParams[0] && n.policyCategoryURL == urlParams[1]).FirstOrDefault();
            }

            return navItem;
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
        private const string cacheKeywordDossierStatuses = "dossierStatusesCached";
        private const string cacheKeywordDossiers = "dossiersCached";
        private const string policyAreaServiceUrl = "http://www.shungham.com/SavedQueryService/Execute/navigation";
        private const string dossierStatusServiceUrl = "http://www.shungham.com/SavedQueryService/Execute/ShunghamDossierStatuses";
        private const string dossierServiceUrl = "http://www.shungham.com/SavedQueryService/Execute/ShunghamDossiers";
        public static IList<NavigationItem> navItems = new List<NavigationItem>();

        #endregion
    }
}