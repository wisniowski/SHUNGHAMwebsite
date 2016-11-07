using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Web;
using Telerik.Web.UI;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker.EUINavigationWidget
{
    public partial class NavigationWidget : System.Web.UI.UserControl, IBreadcrumExtender
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            RouteHelper.SetUrlParametersResolved();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.Page.RegisterBreadcrumbExtender(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RouteHelper.SetUrlParametersResolved();
            BindNavigationWidget();
        }

        private void BindNavigationWidget()
        {
            IEnumerable<CustomNavGroup<string, EUIPolicyAreaModel>> result =
                EUIssueTrackerHelper.GetNavigationItems()
                .GroupBy(w => w.Attributes.policyAreaName.Value)
                .Select(g => new CustomNavGroup<string, EUIPolicyAreaModel>() { Key = g.Key, Values = g });

            navItems.Clear();

            this.navigationList.DataSource = result;
            this.navigationList.ItemDataBound += navigationList_ItemDataBound;
            this.navigationList.DataBind();
        }

        protected void navigationList_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
            if (e.Item is RadListViewDataItem)
            {
                Repeater repeater = e.Item.FindControl("categoriesRepeater") as Repeater;

                if (repeater != null)
                {
                    var dataItem = ((RadListViewDataItem)e.Item).DataItem as CustomNavGroup<string, EUIPolicyAreaModel>;

                    repeater.DataSource = dataItem.Values;
                    repeater.ItemDataBound += repeater_ItemDataBound;
                    repeater.DataBind();
                }
            }
        }

        protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var category = e.Item.DataItem as EUIPolicyAreaModel;
                HyperLink navLink = e.Item.FindControl("categoryLink") as HyperLink;
                var pageUrl = SiteMapBase.GetActualCurrentNode().GetUrl(Thread.CurrentThread.CurrentCulture);
                var policyAreaUrlComponent = Regex.Replace(category.Attributes.policyAreaName.Value.ToLower(), urlRegex, hyphen);
                var policyCategoryUrlComponent = Regex.Replace(category.Attributes.uni_name.ToLower(), urlRegex, hyphen);
                navLink.NavigateUrl = string.Format("{0}/{1}/{2}", pageUrl, policyAreaUrlComponent, policyCategoryUrlComponent);

                navItems.Add(new NavigationItem
                {
                    policyAreaName = category.Attributes.policyAreaName.Value,
                    policyAreaURL = policyAreaUrlComponent,
                    policyCategoryName = category.Attributes.uni_name,
                    policyCategoryURL = policyCategoryUrlComponent
                });
            }
        }

        #region IBreadcrumExtender

        public IEnumerable<SiteMapNode> GetVirtualNodes(SiteMapProvider provider)
        {
            IList<SiteMapNode> sitemap = new List<SiteMapNode>();

            var urlParams = this.GetUrlParameters();
            if (urlParams != null && urlParams.Count() > 0)
            {
                var navItem = navItems.Where(n => n.policyAreaURL == urlParams[0] && n.policyCategoryURL == urlParams[1]).FirstOrDefault();
                SiteMapNode policyAreaNode = new SiteMapNode(provider, "policyAreaKey", 
                    navItem.policyAreaURL, navItem.policyAreaName, navItem.policyCategoryName);
                sitemap.Add(policyAreaNode);
                return sitemap;
            }
            return sitemap;
        }

        #endregion

        #region Private fields and constants

        public static string urlRegex = @"[^\w\-\!\$\'\(\)\=\@\d_]+";
        public static string hyphen = "-";
        public IList<NavigationItem> navItems = new List<NavigationItem>();

        #endregion

    }
}