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

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget
{
    public partial class EUDossierGridWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDossierStatusesList();
            }
        }

        private void BindDossierStatusesList()
        {
            var dossierStatuses = EUIssueTrackerHelper.GetDossierStatuses();

            this.statusesList.DataSource = dossierStatuses;
            this.statusesList.ItemDataBound += statusesList_ItemDataBound;
            this.statusesList.DataBind();
        }

        protected void statusesList_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
            if (e.Item is RadListViewDataItem)
            {
                var dataItem = ((RadListViewDataItem)e.Item).DataItem as EUDossierStatusModel;
                HyperLink statusLink = e.Item.FindControl("dossierStatusLink") as HyperLink;
                var pageUrl = SiteMapBase.GetActualCurrentNode().GetUrl(Thread.CurrentThread.CurrentCulture);
                var urlParams = this.GetUrlParameters();
                var statusUrlComponent = Regex.Replace(dataItem.Attributes.uni_name.ToLower(), urlRegex, hyphen);

                if (urlParams != null)
                {
                    if (urlParams.Count() > 2)
                    {
                        urlParams = urlParams.Take(urlParams.Count() - 1).ToArray();
                    }
                    statusLink.NavigateUrl = string.Format("{0}/{1}/{2}", pageUrl, string.Join("/", urlParams), statusUrlComponent);
                }
            }
        }

        protected string GetDossiersCountByStatus(RadListViewDataItem dataItem)
        {
            return "13";
        }

        #region Private fields and constants

        public static string urlRegex = @"[^\w\-\!\$\'\(\)\=\@\d_]+";
        public static string hyphen = "-";

        #endregion
    }
}