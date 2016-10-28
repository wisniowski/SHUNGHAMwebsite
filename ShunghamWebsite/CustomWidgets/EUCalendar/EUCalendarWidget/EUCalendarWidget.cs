using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Modules.Pages.Web.UI;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Web.UI;
using Telerik.Web.UI;

namespace SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget
{
    [RequireScriptManager]
    public class EUCalendarWidget : SimpleScriptView
    {
        #region Control Properties

        /// <summary>
        /// Gets or sets the initial items count.
        /// </summary>
        /// <value>
        /// The initial items count.
        /// </value>
        public int InitialItemsCount
        {
            get
            {
                return this.initialItemsCount;
            }
            set
            {
                if (value == 0)
                {
                    value = 7; //Default value for the control
                }
                this.initialItemsCount = value;
            }
        }

        /// <inheritdoc />
        public override string LayoutTemplatePath
        {
            get
            {
                return this.layoutTemplatePath;
            }
            set
            {
                this.layoutTemplatePath = value;
            }
        }

        /// <summary>
        /// Gets or sets the details page identifier.
        /// </summary>
        /// <value>
        /// The details page identifier.
        /// </value>
        public Guid DetailsPageId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is details mode.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is details mode; otherwise, <c>false</c>.
        /// </value>
        public bool IsDetailsMode
        {
            get
            {
                return this.isDetailsMode;
            }
            set
            {
                this.isDetailsMode = value;
            }
        }

        #endregion

        #region Control references

        protected virtual RadListView EventsList
        {
            get
            {
                return this.Container.GetControl<RadListView>("eventsList", false);
            }
        }

        protected virtual RadioButton eventDateRadioButton
        {
            get
            {
                return this.Container.GetControl<RadioButton>("startDateRadioButton", false);
            }
        }

        protected virtual RadioButton eventDeadlineRadioButton
        {
            get
            {
                return this.Container.GetControl<RadioButton>("deadlineRadioButton", false);
            }
        }

        protected virtual TextBox SearchBox
        {
            get
            {
                return this.Container.GetControl<TextBox>("searchBox", false);
            }
        }

        protected virtual HtmlButton SearchButton
        {
            get
            {
                return this.Container.GetControl<HtmlButton>("searchBtn", false);
            }
        }

        #endregion

        #region Overridden methods

        /// <inheritdoc />
        protected override void CreateChildControls()
        {
            if (this.IsDetailsMode)
            {
                this.LayoutTemplatePath = this.layoutTemplatePathDetails;
            }
            else
            {
                this.LayoutTemplatePath = this.layoutTemplatePathMaster;
            }

            base.CreateChildControls();
        }

        /// <inheritdoc />
        protected override void InitializeControls(GenericContainer container)
        {
            this.eventList = EventsControlsHelper.GetEventsList();
                //.Where(a => a.Attributes.new_eucstartdate == DateTime.Now)
                //    .ToList();
            this.SearchButton.ServerClick += SearchButton_Click;

            this.InitializeMasterView(this.eventList);
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            var redirectLocation = string.Empty;
            var searchQuery = this.SearchBox.Text;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                redirectLocation = SiteMapBase.GetActualCurrentNode().GetUrl(Thread.CurrentThread.CurrentCulture) 
                    + eventsSearchUrlKeyword + searchQuery;
            }
            if (searchQuery == string.Empty)
            {
                redirectLocation = SiteMapBase.GetActualCurrentNode().GetUrl(Thread.CurrentThread.CurrentCulture);
            }

            HttpContext.Current.Response.Redirect(redirectLocation);
        }

        /// <inheritdoc />
        public override IEnumerable<System.Web.UI.ScriptDescriptor> GetScriptDescriptors()
        {
            ScriptControlDescriptor scriptControlDescriptor = new ScriptControlDescriptor(base.GetType().FullName, this.ClientID);
            scriptControlDescriptor.AddProperty("initialItemsCount", this.InitialItemsCount);
            scriptControlDescriptor.AddProperty("isDetailsMode", this.IsDetailsMode);
            return new ScriptControlDescriptor[] { scriptControlDescriptor };
        }

        /// <inheritdoc />
        public override IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>();
            scripts.Add(new ScriptReference(this.scriptReference));
            return scripts;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Initializes the master view.
        /// </summary>
        /// <param name="eventList">The event list.</param>
        private void InitializeMasterView(IList<EventModel> eventList)
        {
            //Need to initialize the controls before further filtering
            this.InitializeDropDownControls(eventList);

            this.eventDateRadioButton.CheckedChanged += eventDateRadioButton_CheckedChanged;
            this.eventDeadlineRadioButton.CheckedChanged += eventDeadlineRadioButton_CheckedChanged;

            var queryStringParams = HttpContext.Current.Request.QueryString;

            if (queryStringParams != null && queryStringParams.Count > 0)
            {
                eventList = this.FilterCollectionBySearchTerm(eventList, queryStringParams);
            }

            int eventListCount = 0;
            eventListCount = eventList.Count;

            if (eventListCount > 0)
            {
                this.EventsList.DataSource = eventList;
                this.EventsList.ItemDataBound += EventsList_ItemDataBound;
                this.EventsList.DataBind();
            }
        }

        void eventDeadlineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (eventDeadlineRadioButton.Checked)
            {
                this.EventsList.DataSource = this.eventList.OrderBy(a => a.Attributes.new_eucregistrationdeadline).ToList();
                this.EventsList.ItemDataBound += EventsList_ItemDataBound;
                this.EventsList.DataBind();
            }
        }

        void eventDateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (eventDateRadioButton.Checked)
            {
                this.EventsList.DataSource = this.eventList.OrderBy(a => a.Attributes.new_eucstartdate).ToList();
                this.EventsList.ItemDataBound += EventsList_ItemDataBound;
                this.EventsList.DataBind();
            }
        }

        private IList<EventModel> FilterCollectionBySearchTerm(IList<EventModel> eventList, NameValueCollection queryStringParams)
        {
            List<EventModel> eventMatches = new List<EventModel>();
            var searchTerm = queryStringParams["search"];

            if (!string.IsNullOrEmpty(searchTerm))
            {
                this.SearchBox.Text = searchTerm;
                var searchTermCleaned = searchTerm.Trim();

                //add white spaces on start and end of the search query for exact phrase/word matching
                searchTermCleaned = " " + searchTermCleaned + " ";

                //search with spaces
                eventMatches = eventList.Where(e => e.Attributes.cdi_name.ToLower().Contains(searchTermCleaned.ToLower())).ToList();

                //search by exact match in the titles
                eventMatches.AddRange(eventList.Where(e => e.Attributes.cdi_name.ToLower().Contains(searchTerm.ToLower())).ToList());

                //breakup phrase and search for any match on any word
                eventMatches.AddRange(eventList.Where(e => searchTerm.Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries).Any(w => e.Attributes.cdi_name.ToLower().Contains(w.ToLower()))));
                eventMatches.AddRange(eventList.Where(e => searchTerm.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).Any(w => e.Attributes.cdi_name.ToLower().Contains(w.ToLower()))));
            }
            else
            {
                return eventList;
            }

            return eventMatches.Distinct().ToList();
        }

        /// <summary>
        /// Initializes the drop down controls.
        /// </summary>
        /// <param name="eventList">The event list.</param>
        private void InitializeDropDownControls(IList<EventModel> eventList)
        {
            //this.InitializeEventTypesDropDown(eventList);
            //this.InitializeEventLocationsDropDown(eventList);
            //this.InitializeEventLanguagesDropDown(eventList);
        }

        /// <summary>
        /// Converts the relative URL to absolute URL.
        /// </summary>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <returns></returns>
        public string ConvertRelativeUrlToAbsoluteUrl(string relativeUrl)
        {
            return string.Format("http{0}://{1}{2}",
                HttpContext.Current.Request.IsSecureConnection ? "s" : string.Empty,
                HttpContext.Current.Request.Url.Host,
                Page.ResolveUrl(relativeUrl));
        }

        /// <summary>
        /// Initializes the details view.
        /// </summary>
        /// <param name="eventList">The event list.</param>
        private void InitializeDetailsView(IList<EventModel> eventList)
        {
            //if (this.IsBackend() || this.IsPreviewMode())
            //{
            //    this.DisplayBackendMessage();
            //}

            //string itemUrl = string.Empty;
            //itemUrl = this.GetUrlParameterString(true);

            //if (!string.IsNullOrEmpty(itemUrl))
            //{
            //    var eventItem = eventList.Where(e => itemUrl.Contains(Regex.Replace(e.EventTitle.ToLower(), ETXCommon.DevNames.UrlHelpers.UrlRegex, ETXCommon.DevNames.UrlHelpers.Dash))).FirstOrDefault();

            //    if (eventItem != null)
            //    {
            //        RouteHelper.SetUrlParametersResolved();
            //        this.BackButtonLink.NavigateUrl = HttpContext.Current.Request.UrlReferrer == null ? this.BackBtnDefaultDestination : HttpContext.Current.Request.UrlReferrer.AbsolutePath;
            //        this.TypeControl.Text = eventItem.EventType;
            //        this.SubjectControl.Text = eventItem.EventTitle;
            //        this.DateControl.Text = eventItem.EventDates + " " + eventItem.EventHours;
            //        this.LocationControl.Text = eventItem.EventLocation;
            //        this.LanguageControl.Text = eventItem.EventLanguage;
            //        this.AvailabilityControl.Text = eventItem.EventAvailability;
            //        this.ContentControl.Text = eventItem.EventDetails;

            //        this.ResolvePageMetaTags(eventItem);
            //        this.SetupBookNowIframe(eventItem);
            //    }
            //}
        }

        private void EventsList_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
            if (e.Item.ItemType == RadListViewItemType.DataItem || e.Item.ItemType == RadListViewItemType.AlternatingItem)
            {
                var eventLinkControl = e.Item.FindControl("detailViewLink") as HtmlAnchor;
                if (eventLinkControl != null)
                {
                    var eventItem = (e.Item as Telerik.Web.UI.RadListViewDataItem).DataItem as EventModel;

                    if (this.DetailsPageId != null && this.DetailsPageId != Guid.Empty)
                    {
                        var pmanager = PageManager.GetManager();
                        var detailsPage = pmanager.GetPageNode(this.DetailsPageId);
                        eventLinkControl.HRef = detailsPage.GetUrl(Thread.CurrentThread.CurrentCulture) + fwdSlash +
                            Regex.Replace(eventItem.Attributes.cdi_name.ToLower(), urlRegex, hyphen);
                    }
                }
            }
        }

        #endregion

        #region Private variables

        private bool isDetailsMode = false;
        private int initialItemsCount = 7;
        private string layoutTemplatePath = string.Empty;
        private string layoutTemplatePathDetails = "~/CustomWidgets/EUCalendar/EUCalendarWidget/EUCalendarDetailTemplate.ascx";
        private string layoutTemplatePathMaster = "~/CustomWidgets/EUCalendar/EUCalendarWidget/EUCalendarMasterTemplate.ascx";
        private string scriptReference = "~/CustomWidgets/EUCalendar/EUCalendarWidget/EUCalendarWidget.js";
        private IList<EventModel> eventList = new List<EventModel>();
        public static string urlRegex = @"[^\w\-\!\$\'\(\)\=\@\d_]+";
        public static string hyphen = "-";
        public static string fwdSlash = "/";
        public static string underscore = "_";
        public static string eventsDateFormat = "dd MMM";
        public const string eventsSearchUrlKeyword = "?search=";

        #endregion
    }
}