using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Caching;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker
{
    /// <summary>
    /// Helper class to consume MS Dynamics data and perform CRUD operations via helper methods.
    /// </summary>
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
                navItemsList = GetNavItemsFromMSDynamics()
                    .OrderBy(p => p.Attributes.policyAreaName.Value)
                    .ToList();
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

                    if (policyAreasList != null && policyAreasList.Count > 0)
                    {
                        //TODO: extract this in a config
                        var cacheExpirationTime = 60;
                        CacheManager.Add(
                            cacheKeywordPAC,
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

                    if (dossierStatusesList != null && dossierStatusesList.Count > 0)
                    {
                        //TODO: extract this in a config
                        var cacheExpirationTime = 60;
                        CacheManager.Add(
                            cacheKeywordDossierStatuses,
                            dossierStatusesList,
                            CacheItemPriority.Normal,
                            null,
                            new SlidingTime(TimeSpan.FromMinutes(cacheExpirationTime)));
                    }

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
            Stopwatch sw = Stopwatch.StartNew();
            OpenServicePoint(dossierServiceUrl);

            IList<string> serviceUrls = new List<string>();
            var parsedJson = new List<EUDossierModel>();
            for (int i = 1; i < 5; i++)
            {
                serviceUrls.Add(string.Format("{0}/{1}/{2}", dossierServiceUrl, i, 5000));
            }
            var tasks = serviceUrls.Select(GetAsync).ToArray();
            var completed = Task.Factory.ContinueWhenAll(tasks,
                                completedTasks =>
                                {
                                    foreach (var result in completedTasks.Select(t => t.Result))
                                    {
                                        parsedJson.AddRange(JsonConvert.DeserializeObject<List<EUDossierModel>>(result));
                                    }
                                });
            completed.Wait();

            //anything that follows gets executed after all urls have finished downloading
            var dossiers = parsedJson;
            Log.Write(string.Format("Total number of dossier updates: {0}", dossiers.Count), ConfigurationPolicy.Trace);
            //dossiersList = dossiers.GetLatestUpdatedDossiersOnly();
            dossiersList = dossiers;

            if (dossiersList != null && dossiersList.Count > 0)
            {
                //TODO: extract this in a config
                var cacheExpirationTime = 60;
                CacheManager.Add(
                    cacheKeywordDossiers,
                    dossiersList,
                    CacheItemPriority.Normal,
                    null,
                    new SlidingTime(TimeSpan.FromMinutes(cacheExpirationTime)));
            }
            sw.Stop();
            Log.Write(string.Format("Dossiers request took {0}", sw.Elapsed), ConfigurationPolicy.Trace);

            return dossiersList;
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

        /// <summary>
        /// Gets the latest updated dossiers only per status.
        /// </summary>
        /// <param name="dossiersList">The dossiers list.</param>
        /// <returns></returns>
        public static IList<EUDossierModel> GetLatestUpdatedDossiersOnly(this IList<EUDossierModel> dossiersList)
        {
            return dossiersList.OrderByDescending(d => d.Attributes.publishDate.Value)
                                .GroupBy(s => new { DossierID = s.Attributes.dossierId.Value, Status = s.Attributes.status.Value })
                                .Select(grp => grp.FirstOrDefault())
                                .ToList();
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
        /// Gets the latest updated dossiers within days
        /// </summary>
        /// <param name="dossiersList">The dossiers list.</param>
        /// <param name="days">The days.</param>
        /// <returns></returns>
        public static IList<EUDossierModel> GetLatestUpdatedDossiersWithinDays(this IList<EUDossierModel> dossiersList, int days)
        {
            dossiersList = dossiersList.Where(d => d.Attributes.publishDate != null && 
                d.Attributes.publishDate.Value > DateTime.Now.AddDays(-days) &&
                d.Attributes.publishDate.Value <= DateTime.Now).ToList();
            return dossiersList;
        }

        /// <summary>
        /// Restricts the dossiers list so that dossiers with Show On Sitefinity value "False" require authentication.
        /// Such are for example: "Future Initiatives", 
        /// "Dormant" and "Shelved" are not displayed.
        /// </summary>
        /// <param name="dossiersList">The dossiers list.</param>
        /// <returns></returns>
        public static IList<EUDossierModel> RestrictDossiersByStatus(this IList<EUDossierModel> dossiersList)
        {
            return dossiersList.Where(d => d.Attributes.showOnSitefinity.Value).ToList();
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

        /// <summary>
        /// Constructs the policy area and category URL.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="pageUrl">The page URL.</param>
        /// <param name="policyAreaUrlComponent">The policy area URL component.</param>
        /// <param name="policyCategoryUrlComponent">The policy category URL component.</param>
        public static void ConstructPolicyAreaAndCategoryURL(string areaName, string categoryName, out string navigateUrl)
        {
            var pageUrl = SiteMapBase.GetActualCurrentNode().GetUrl(Thread.CurrentThread.CurrentCulture);
            if (pageUrl.Contains("detail"))
            {
                pageUrl = pageUrl.Substring(0, pageUrl.IndexOf("/detail"));
            }
            var fullPageUrl = VirtualPathUtility.ToAbsolute(pageUrl);
            var policyAreaUrlComponent = Regex.Replace(areaName.ToLower(), urlRegex, hyphen);
            var policyCategoryUrlComponent = Regex.Replace(categoryName.ToLower(), urlRegex, hyphen);
            navigateUrl = string.Format("{0}/{1}/{2}", fullPageUrl, policyAreaUrlComponent, policyCategoryUrlComponent);

            EUIssueTrackerHelper.navItems.Add(new NavigationItem
            {
                policyAreaName = areaName,
                policyAreaURL = policyAreaUrlComponent,
                policyCategoryName = categoryName,
                policyCategoryURL = policyCategoryUrlComponent,
            });
        }

        /// <summary>
        /// Constructs the status URL.
        /// </summary>
        /// <param name="statusName">Name of the status.</param>
        /// <param name="navigateUrl">The navigate URL.</param>
        public static void ConstructStatusUrl(string statusName, out string navigateUrl)
        {
            var pageUrl = SiteMapBase.GetActualCurrentNode().GetUrl(Thread.CurrentThread.CurrentCulture);
            if (pageUrl.Contains("detail"))
            {
                pageUrl = pageUrl.Substring(0, pageUrl.IndexOf("/detail"));
            }
            var fullPageUrl = VirtualPathUtility.ToAbsolute(pageUrl);
            var statusUrlComponent = Regex.Replace(statusName.ToLower(), urlRegex, hyphen);
            navigateUrl = string.Format("{0}/{1}", fullPageUrl, statusUrlComponent);
        }

        /// <summary>
        /// Gets the dossier by URL parameters.
        /// </summary>
        /// <param name="urlParams">The URL parameters.</param>
        /// <returns></returns>
        public static EUDossierModel GetDossierByUrlParams(string[] urlParams)
        {
            var dossierID = urlParams[0];
            var dossiers = EUIssueTrackerHelper.GetDossiers().RestrictDossiersByStatus();
            var dossierUpdate = dossiers.Where(d => d.Attributes.dossierId.Value == dossierID).FirstOrDefault();
            return dossierUpdate;
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
        private const string dossierServiceUrl = "http://www.shungham.com/SavedQueryService/Execute/shunghamdossierupdates";
        public static IList<NavigationItem> navItems = new List<NavigationItem>();
        public static string urlRegex = @"[^\w\-\!\$\'\(\)\=\@\d_]+";
        public static string hyphen = "-";
        #endregion
    }
}