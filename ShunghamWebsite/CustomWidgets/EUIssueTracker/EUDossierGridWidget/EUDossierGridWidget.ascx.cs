using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget.Designer;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Web.UI;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget
{
    [ControlDesigner(typeof(EUDossierGridWidgetDesigner))]
    public partial class EUDossierGridWidget : System.Web.UI.UserControl
    {
        #region Properties

        public bool DisplayOtherUpdates { get; set; }

        public int DaysToDisplayUpdatesWithin
        {
            get
            {
                return this.daysToDisplayUpdatesWithin;
            }
            set
            {
                this.daysToDisplayUpdatesWithin = value;
            }
        }

        public Guid DetailsPageId { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                BindDossierList();
                if (!this.DisplayOtherUpdates)
                {
                    BindDossierStatusesList();
                }
                var urlParams = this.GetUrlParameters();
                if (urlParams != null)
                {
                    FilterDossierList(urlParams);
                }

                if (this.DisplayOtherUpdates)
                {
                    this.statusesList.Visible = false;
                    this.otherUpdatesTitle.Text = string.Format(Res.Get<ShunghamResources>().OtherUpdatesTitle, 
                        otherUpdatesCount);
                }
                else
                {
                    this.statusesList.Visible = true;
                }
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
            dossiers = EUIssueTrackerHelper.GetDossiers();

            if (this.DisplayOtherUpdates)
            {
                //the other dossiers grid must display all dossiers that were modified in the last X days
                dossiers = dossiers.GetLatestUpdatedDossiersWithinDays(this.DaysToDisplayUpdatesWithin);
            }

            this.dossiersList.DataSource = dossiers.RestrictDossiersByStatus();
            this.dossiersList.ItemCreated += dossiersList_ItemCreated;
            this.dossiersList.ItemDataBound += dossiersList_ItemDataBound;
            this.dossiersList.DataBind();
        }

        protected void dossiersList_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
            if (e.Item is RadListViewDataItem)
            {
                var dataItem = ((RadListViewDataItem)e.Item).DataItem as EUDossierModel;
                var dateUpdated = dataItem.Attributes.uni_publishdate;
                if (dateUpdated > DateTime.Now.AddHours(-24) && dateUpdated <= DateTime.Now)
                {
                    HtmlGenericControl pTag = e.Item.FindControl("newWrapper") as HtmlGenericControl;
                    pTag.Attributes["style"] = "display:block";
                }

                var detailViewLinkControl = e.Item.FindControl("detailViewLink") as HyperLink;
                if (detailViewLinkControl != null)
                {
                    if (this.DetailsPageId != null && this.DetailsPageId != Guid.Empty)
                    {
                        var pmanager = PageManager.GetManager();
                        var detailsPage = pmanager.GetPageNode(this.DetailsPageId);
                        var pageUrl = detailsPage.GetUrl(Thread.CurrentThread.CurrentCulture);
                        detailViewLinkControl.NavigateUrl = 
                            string.Format("{0}/{1}/{2}", pageUrl, dataItem.Attributes.dossierId.Value, 
                            Regex.Replace(dataItem.Attributes.uni_shorttitle.ToLower(), urlRegex, hyphen));
                    }
                }
            }
        }

        private void FilterDossierList(string[] urlParams)
        {
            IList<EUDossierModel> filteredDossiers = new List<EUDossierModel>();
            IList<EUDossierModel> filteredByPolicyCatDossiers = new List<EUDossierModel>();
            if (urlParams != null && urlParams.Count() > 1)
            {
                filteredByPolicyCatDossiers = FilterDossierListByPolicyAreaAndCategory(dossiers);
                if (filteredByPolicyCatDossiers.Count > 0)
                {
                    otherUpdatesCount = filteredByPolicyCatDossiers.Count - 1;
                }
                this.dossiersList.DataSource = filteredByPolicyCatDossiers.RestrictDossiersByStatus();

                if (urlParams.Count() > 2)
                {
                    filteredDossiers = FilterDossierListByStatus(filteredByPolicyCatDossiers, urlParams);
                    if (filteredDossiers != null)
                    {
                        filteredDossiers = filteredDossiers.RestrictDossiersByStatus();
                    }
                    this.dossiersList.DataSource = filteredDossiers;
                }
            }

            dossiers = filteredByPolicyCatDossiers;

            this.dossiersList.DataBind();

            this.statusesList.DataBind();
        }

        private IList<EUDossierModel> FilterDossierListByPolicyAreaAndCategory(IList<EUDossierModel> dossiers)
        {
            var navItem = EUIssueTrackerHelper.GetNavItemByUrlParams(this.GetUrlParameters());
            if (navItem != null)
            {
                return dossiers.FilterDossiersByPolicyAreaAndCategory(navItem.policyAreaName, navItem.policyCategoryName);
            }
            return dossiers;
        }

        private IList<EUDossierModel> FilterDossierListByStatus(IList<EUDossierModel> dossiers, string[] urlParams)
        {
            selectedStatus = urlParams[2];
            switch (selectedStatus)
            {
                case "future-initiatives":
                case "dormant":
                case "shelved":
                    return null;
                default:
                    var status = statuses.Where(s => s.statusURL == selectedStatus).FirstOrDefault();
                    if (status != null)
                    {
                        return dossiers.FilterDossiersByStatus(status.statusName);
                    }
                    else
                    {
                        return null;
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
                        emptyMessageContentLtl.Text = Res.Get<ShunghamResources>().NoDossiersFound;
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

                statuses.Add(new StatusItem
                {
                    statusName = dataItem.Attributes.uni_name,
                    statusURL = statusUrlComponent,
                });

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

        protected int DisplayDossiersCount(EUDossierStatusModel statusItem)
        {
            if (statusItem != null)
            {
                return dossiers.GetDossiersCountByStatus(statusItem.Attributes.uni_name);
            }
            return 0;
        }

        #region Private fields and constants

        private int daysToDisplayUpdatesWithin = 30;
        private int otherUpdatesCount = 0;
        public static string urlRegex = @"[^\w\-\!\$\'\(\)\=\@\d_]+";
        public static string hyphen = "-";
        public static string fwdSlash = "/";
        public static string underscore = "_";
        public string selectedStatus = null;
        private IList<EUDossierModel> dossiers = new List<EUDossierModel>();
        public IList<StatusItem> statuses = new List<StatusItem>();

        #endregion
    }
}