using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.Designer;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Modules.Pages.Web.UI;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Web.UI;

namespace SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget
{
    [RequireScriptManager, ControlDesigner(typeof(EUCalendarWidgetDesigner))]
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

        /// <summary>
        /// Gets or sets the back button default destination.
        /// </summary>
        /// <value>
        /// The back button default destination.
        /// </value>
        public string BackBtnDefaultDestination
        {
            get
            {
                return this.backBtnDefaultDestination;
            }
            set
            {
                this.backBtnDefaultDestination = value;
            }
        }

        #endregion

        #region Events list control references

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

        protected virtual HtmlGenericControl Date
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("date", false);
            }
        }

        protected virtual LinkButton Prev
        {
            get
            {
                return this.Container.GetControl<LinkButton>("prev", false);
            }
        }

        protected virtual LinkButton Next
        {
            get
            {
                return this.Container.GetControl<LinkButton>("next", false);
            }
        }

        #endregion

        #region Event Details control references

        protected virtual Literal EventDetailErrMessage
        {
            get
            {
                return this.Container.GetControl<Literal>("eventDetailErrMessage", false);
            }
        }

        protected virtual HtmlAnchor BackButtonLink
        {
            get
            {
                return this.Container.GetControl<HtmlAnchor>("backButtonLink", false);
            }
        }

        protected virtual Literal TitleControl
        {
            get
            {
                return this.Container.GetControl<Literal>("titleLtl", false);
            }
        }

        protected virtual Literal DescriptionControl
        {
            get
            {
                return this.Container.GetControl<Literal>("descriptionLtl", false);
            }
        }

        protected virtual HyperLink OrganizersEventLink
        {
            get
            {
                return this.Container.GetControl<HyperLink>("organizersEventLink", false);
            }
        }

        protected virtual Literal StartDateControl
        {
            get
            {
                return this.Container.GetControl<Literal>("startDateLtl", false);
            }
        }

        protected virtual Literal PriceControl
        {
            get
            {
                return this.Container.GetControl<Literal>("priceLtl", false);
            }
        }

        protected virtual Literal PolicyAreaControl
        {
            get
            {
                return this.Container.GetControl<Literal>("policyAreaLtl", false);
            }
        }

        protected virtual Literal OrganizerControl
        {
            get
            {
                return this.Container.GetControl<Literal>("organizerLtl", false);
            }
        }

        protected virtual Literal LocationControl
        {
            get
            {
                return this.Container.GetControl<Literal>("locationLtl", false);
            }
        }

        protected virtual Literal DeadlineControl
        {
            get
            {
                return this.Container.GetControl<Literal>("deadlineLtl", false);
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
            if (!Page.IsPostBack)
            {
                HttpContext.Current.Session[dateKey] = DateTime.Now;

                if (HttpContext.Current.Session[dateKey] != null)
                {
                    var date = (DateTime)HttpContext.Current.Session[dateKey];
                    this.eventList = EventsControlsHelper.GetEventsList()
                        .OrderEventsCollection(date);
                }
            }

            this.Date.InnerText = DateTime.Now.ToString(eventsDateFormat);

            this.SearchButton.ServerClick += SearchButton_Click;
            this.Prev.Click += Prev_Click;
            this.Next.Click += Next_Click;

            if (this.IsDetailsMode)
            {
                this.InitializeDetailsView(this.eventList);
            }
            else
            {
                this.InitializeMasterView(this.eventList);
            }
        }

        protected void Prev_Click(object sender, EventArgs e)
        {
            var currentDate = ((DateTime)(HttpContext.Current.Session[dateKey])).AddMonths(-1);
            HttpContext.Current.Session[dateKey] = currentDate;
            this.Date.InnerText = currentDate.ToString(eventsDateFormat);

            this.eventList = EventsControlsHelper.GetEventsList().OrderEventsCollection(currentDate);
            this.EventsList.DataSource = this.eventList;
            this.EventsList.ItemDataBound += EventsList_ItemDataBound;
            this.EventsList.DataBind();
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            var currentDate = ((DateTime)(HttpContext.Current.Session[dateKey])).AddMonths(1);
            HttpContext.Current.Session[dateKey] = currentDate;
            this.Date.InnerText = currentDate.ToString(eventsDateFormat);

            this.eventList = EventsControlsHelper.GetEventsList().OrderEventsCollection(currentDate);
            this.EventsList.DataSource = this.eventList;
            this.EventsList.ItemDataBound += EventsList_ItemDataBound;
            this.EventsList.DataBind();
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

        protected void eventDeadlineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (eventDeadlineRadioButton.Checked)
            {
                var currentDate = DateTime.Parse(this.Date.InnerHtml);
                this.EventsList.DataSource = EventsControlsHelper.GetEventsList().OrderEventsCollection(currentDate)
                    .OrderBy(a => a.Attributes.new_eucregistrationdeadline).ToList();
                this.EventsList.ItemDataBound += EventsList_ItemDataBound;
                this.EventsList.DataBind();
            }
        }

        protected void eventDateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (eventDateRadioButton.Checked)
            {
                var currentDate = DateTime.Parse(this.Date.InnerHtml);
                this.EventsList.DataSource = EventsControlsHelper.GetEventsList().OrderEventsCollection(currentDate)
                    .OrderBy(a => a.Attributes.new_eucstartdate).ToList();
                this.EventsList.ItemDataBound += EventsList_ItemDataBound;
                this.EventsList.DataBind();
            }
        }

        #endregion

        #region IScriptControl methods

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
        /// Converts relative URL to absolute URL.
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
            if (this.IsBackend() || this.IsPreviewMode())
            {
                this.DisplayBackendMessage();
            }

            string itemUrl = string.Empty;
            itemUrl = this.GetUrlParameterString(true);

            if (!string.IsNullOrEmpty(itemUrl))
            {
                var eventItem = eventList.Where(e => itemUrl.Contains(Regex.Replace(e.Attributes.cdi_name.ToLower(),
                    urlRegex, hyphen))).FirstOrDefault();

                if (eventItem != null)
                {
                    RouteHelper.SetUrlParametersResolved();
                    this.BackButtonLink.InnerHtml = @"<i class=""icon-caret-left""></i>Back to Events List";
                    this.BackButtonLink.HRef =
                        HttpContext.Current.Request.UrlReferrer == null ? this.BackBtnDefaultDestination : HttpContext.Current.Request.UrlReferrer.AbsolutePath;
                    this.TitleControl.Text = eventItem.Attributes.cdi_name;
                    this.StartDateControl.Text = eventItem.Attributes.new_eucstartdate.ToString("dd MMMM yyyy");
                    this.DescriptionControl.Text = eventItem.Attributes.new_euceventdescription;
                    this.PriceControl.Text = eventItem.Attributes.new_euceventprice;
                    this.PolicyAreaControl.Text = eventItem.Attributes.new_eucconcatenatepolicyareastrings;
                    this.OrganizerControl.Text = eventItem.Attributes.organiserName.Value;
                    this.LocationControl.Text = eventItem.Attributes.new_euclocation.Name;
                    this.DeadlineControl.Text = eventItem.Attributes.new_eucregistrationdeadline == DateTime.MinValue ? "No deadline" :
                    eventItem.Attributes.new_eucregistrationdeadline.ToString("dd MMMM yyyy");
                    this.OrganizersEventLink.NavigateUrl = eventItem.Attributes.new_euceventlink;
                }
            }
        }

        private void EventsList_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
            if (e.Item.ItemType == RadListViewItemType.DataItem || e.Item.ItemType == RadListViewItemType.AlternatingItem)
            {
                var eventLinkControl = e.Item.FindControl("detailViewLink") as HyperLink;
                if (eventLinkControl != null)
                {
                    var eventItem = (e.Item as Telerik.Web.UI.RadListViewDataItem).DataItem as EventModel;

                    if (this.DetailsPageId != null && this.DetailsPageId != Guid.Empty)
                    {
                        var pmanager = PageManager.GetManager();
                        var detailsPage = pmanager.GetPageNode(this.DetailsPageId);
                        eventLinkControl.NavigateUrl = detailsPage.GetUrl(Thread.CurrentThread.CurrentCulture) + fwdSlash +
                            Regex.Replace(eventItem.Attributes.cdi_name.ToLower(), urlRegex, hyphen);
                    }
                }
            }
        }

        private void DisplayBackendMessage()
        {
            this.EventDetailErrMessage.Visible = true;
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(this.BackBtnDefaultDestination))
            {
                sb.AppendLine(Res.Get<ShunghamResources>().AddRelativePathToEventListPage);
                sb.Append("<br />");
            }
            sb.AppendLine(Res.Get<ShunghamResources>().EventBackendErrMessage);
            this.EventDetailErrMessage.Text = sb.ToString();
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
        public static string eventsDateFormat = "MMMM yyyy";
        public const string eventsSearchUrlKeyword = "?search=";
        public static string dateKey = "Date";
        private string backBtnDefaultDestination = string.Empty;

        #endregion
    }
}