using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Localization;
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
                BindDossierList();
                FilterDossierListByStatus();
            }
        }

        private void BindDossierStatusesList()
        {
            var dossierStatuses = EUIssueTrackerHelper.GetDossierStatuses();

            this.statusesList.DataSource = dossierStatuses;
            this.statusesList.ItemDataBound += statusesList_ItemDataBound;
            this.statusesList.DataBind();
        }

        private void BindDossierList()
        {
            var dossiers = EUIssueTrackerHelper.GetDossiers();

            this.dossiersList.DataSource = dossiers;
            this.dossiersList.DataBind();
        }

        private void FilterDossierListByStatus()
        {
            var urlParams = this.GetUrlParameters();
            if (urlParams != null && urlParams.Count() > 2)
            {
                selectedStatus = urlParams[2];
                switch (selectedStatus)
                {
                    case "future-initiatives":
                    case "dormant":
                    case "shelved":
                        this.dossiersList.DataSource = null;
                        this.dossiersList.ItemCreated += dossiersList_ItemCreated;
                        this.dossiersList.DataBind();
                        break;
                    default:
                        break;
                }
            }
        }

        protected void dossiersList_ItemCreated(object sender, RadListViewItemEventArgs e)
        {
            if (e.Item is RadListViewEmptyDataItem)
            {
                Literal emptyMessageLtl = e.Item.FindControl("emptyMessageLtl") as Literal;
                Literal emptyTitleLtl = e.Item.FindControl("emptyTitleLtl") as Literal;
                Literal emptyMessageContentLtl = e.Item.FindControl("emptyMessageContentLtl") as Literal;
                switch (selectedStatus)
                {
                    case "future-initiatives":
                        emptyMessageLtl.Text = Res.Get<ShunghamResources>().FutureInitiativesEmptyMessage;
                        emptyTitleLtl.Text = Res.Get<ShunghamResources>().FutureInitiativesTitle;
                        emptyMessageContentLtl.Text = Res.Get<ShunghamResources>().FutureInitiativesEmptyContent;
                        break;
                    case "dormant":
                        emptyMessageLtl.Text = Res.Get<ShunghamResources>().DormantEmptyMessage;
                        emptyTitleLtl.Text = Res.Get<ShunghamResources>().DormantTitle;
                        emptyMessageContentLtl.Text = Res.Get<ShunghamResources>().DormantEmptyContent;
                        break;
                    case "shelved":
                        emptyMessageLtl.Text = Res.Get<ShunghamResources>().ShelvedEmptyMessage;
                        emptyTitleLtl.Text = Res.Get<ShunghamResources>().ShelvedTitle;
                        emptyMessageContentLtl.Text = Res.Get<ShunghamResources>().ShelvedEmptyContent;
                        break;
                    default:
                        break;
                }
            }
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
                        //removes old status from url and applies the new one
                        urlParams = urlParams.Take(urlParams.Count() - 1).ToArray();
                    }
                    statusLink.NavigateUrl = string.Format("{0}/{1}/{2}", pageUrl, 
                        string.Join("/", urlParams), statusUrlComponent);
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
        public string selectedStatus = null;

        #endregion
    }
}