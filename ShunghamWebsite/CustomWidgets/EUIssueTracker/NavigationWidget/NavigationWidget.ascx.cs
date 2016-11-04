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
    public partial class NavigationWidget : System.Web.UI.UserControl
    {
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
                var policyCategiryUrlComponent = Regex.Replace(category.Attributes.uni_name.ToLower(), urlRegex, hyphen);
                navLink.NavigateUrl = string.Format("{0}/{1}/{2}", pageUrl, policyAreaUrlComponent, policyCategiryUrlComponent);
            }
        }

        #region Private fields and constants

        public static string urlRegex = @"[^\w\-\!\$\'\(\)\=\@\d_]+";
        public static string hyphen = "-";

        #endregion
    }
}