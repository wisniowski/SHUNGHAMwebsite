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
                if (this.DisplayOtherUpdates)
                {
                    BindOtherUpdatesList();
                    this.statusesList.Visible = false;
                    this.otherUpdatesTitle.Text = string.Format(Res.Get<ShunghamResources>().OtherUpdatesTitle,
                        otherUpdatesCount);
                }
                else
                {
                    BindDossierList();
                    BindDossierStatusesList();

                    var urlParams = this.GetUrlParameters();
                    if (urlParams != null)
                    {
                        FilterDossierList(urlParams);
                    }

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
            MemoryCacheItem.dossiers = EUIssueTrackerHelper.GetDossiers();

            //initially the dossiers grid must display all dossiers that were modified in the last X days
            MemoryCacheItem.dossiers = MemoryCacheItem.dossiers.GetLatestUpdatedDossiersWithinDays(this.DaysToDisplayUpdatesWithin);

            this.dossiersList.DataSource = MemoryCacheItem.dossiers.RestrictDossiersByStatus();
            this.dossiersList.ItemCreated += dossiersList_ItemCreated;
            this.dossiersList.ItemDataBound += dossiersList_ItemDataBound;
            this.dossiersList.DataBind();
        }

        private void BindOtherUpdatesList()
        {
            MemoryCacheItem.dossiers = EUIssueTrackerHelper.GetDossiers();
            string[] urlParams = this.GetUrlParameters();
            var dossierUpdate = EUIssueTrackerHelper.GetDossierByUrlParams(urlParams);

            var category = dossierUpdate.Attributes.policyCategoryName.Value;

            //exclude current dossier from list
            MemoryCacheItem.dossiers.Remove(dossierUpdate);

            //filters dossiers by category and exclude current dossier from list
            MemoryCacheItem.dossiers = MemoryCacheItem.dossiers.Where(a => a.Attributes.policyCategoryName.Value == category)
                .ToList();

            //filters dossiers by status
            MemoryCacheItem.dossiers = MemoryCacheItem.dossiers.RestrictDossiersByStatus();

            //gets dossiers count
            if (MemoryCacheItem.dossiers.Count > 0)
            {
                otherUpdatesCount = MemoryCacheItem.dossiers.Count;
            }

            this.dossiersList.DataSource = MemoryCacheItem.dossiers;
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
            if (urlParams != null)
            {
                //filter dossiers by status only
                if (urlParams.Count() == 1)
                {
                    statusURL = urlParams[0];
                    filteredDossiers = FilterDossierListByStatus(MemoryCacheItem.dossiers, statusURL);
                    if (filteredDossiers != null)
                    {
                        filteredDossiers = filteredDossiers.RestrictDossiersByStatus();
                    }
                    this.dossiersList.DataSource = filteredDossiers;
                }
                else
                {
                    //filter dossiers by policy area and policy category
                    if (urlParams.Count() > 1)
                    {
                        filteredByPolicyCatDossiers = FilterDossierListByPolicyAreaAndCategory(MemoryCacheItem.dossiers);
                        this.dossiersList.DataSource = filteredByPolicyCatDossiers.RestrictDossiersByStatus();
                    }
                    //filter dossiers by policy area, policy category and status
                    if (urlParams.Count() > 2)
                    {
                        statusURL = urlParams[2];
                        filteredDossiers = FilterDossierListByStatus(filteredByPolicyCatDossiers, statusURL);
                        if (filteredDossiers != null)
                        {
                            filteredDossiers = filteredDossiers.RestrictDossiersByStatus();
                        }
                        this.dossiersList.DataSource = filteredDossiers;
                    }

                    MemoryCacheItem.dossiers = filteredByPolicyCatDossiers;
                }
            }

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

        private IList<EUDossierModel> FilterDossierListByStatus(IList<EUDossierModel> dossiers, string selectedStatusURL)
        {
            var status = statuses.Where(s => s.statusURL == selectedStatusURL).FirstOrDefault();
            if (status != null)
            {
                return dossiers.FilterDossiersByStatus(status.statusName);
            }
            return null;
        }

        protected void dossiersList_ItemCreated(object sender, RadListViewItemEventArgs e)
        {
            if (e.Item is RadListViewEmptyDataItem)
            {
                Literal emptyMessageLtl = e.Item.FindControl("emptyMessageLtl") as Literal;
                Literal emptyTitleLtl = e.Item.FindControl("emptyTitleLtl") as Literal;
                Literal emptyMessageContentLtl = e.Item.FindControl("emptyMessageContentLtl") as Literal;
                switch (statusURL)
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
                var statusUrlComponent = Regex.Replace(dataItem.Attributes.uni_displayname.ToLower(), urlRegex, hyphen);

                statuses.Add(new StatusItem
                {
                    statusName = dataItem.Attributes.uni_displayname,
                    statusURL = statusUrlComponent,
                    showOnSitefinity = dataItem.FormattedValues.uni_showonsitefinity
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

        protected void statusesList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItem = e.Item.DataItem as EUDossierStatusModel;
                HyperLink statusLink = e.Item.FindControl("dossierStatusLink") as HyperLink;
                var pageUrl = SiteMapBase.GetActualCurrentNode().GetUrl(Thread.CurrentThread.CurrentCulture);
                var urlParams = this.GetUrlParameters();
                var statusUrlComponent = Regex.Replace(dataItem.Attributes.uni_displayname.ToLower(), urlRegex, hyphen);

                statuses.Add(new StatusItem
                {
                    statusName = dataItem.Attributes.uni_displayname,
                    statusURL = statusUrlComponent,
                });

                if (urlParams == null || urlParams.Count() == 1)
                {
                    statusLink.NavigateUrl = string.Format("{0}/{1}", pageUrl, statusUrlComponent);
                }
                else if (urlParams != null)
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
                return MemoryCacheItem.dossiers.GetDossiersCountByStatus(statusItem.Attributes.uni_displayname);
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
        public string statusURL = null;
        public IList<StatusItem> statuses = new List<StatusItem>();

        #endregion
    }
}