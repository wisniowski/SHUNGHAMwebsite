using ShunghamUtilities;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Web.UI;
using System.Collections.Generic;

namespace SitefinityWebApp.CustomWidgets.FooterWidget
{
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Designer.FooterWidgetDesigner))]
    public partial class FooterWidget : System.Web.UI.UserControl
    {
        public Guid[] WhoWeArePageIds
        {
            get
            {
                if (this.whoWeArePageIds == null) this.whoWeArePageIds = new Guid[] { };
                return this.whoWeArePageIds;
            }
            set
            {
                this.whoWeArePageIds = value;
            }
        }

        public string WhoWeArePagesValue
        {
            get { return string.Join(",", this.WhoWeArePageIds); }
            set
            {
                var list = new List<Guid>();
                if (value != null)
                {
                    var guids = value.Split(',');
                    foreach (var guid in guids)
                    {
                        Guid newGuid;
                        if (Guid.TryParse(guid, out newGuid))
                            list.Add(newGuid);
                    }
                }
                this.WhoWeArePageIds = list.ToArray();
            }
        }

        public string LinkedInButtonExternalLink { get; set; }
        public string TwitterButtonExternalLink { get; set; }
        public string FacebookButtonExternalLink { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            PageNode productsPage = PagesUtilities.GetPageNodeByTitle("products");
            var childNodes = productsPage.Nodes;
            if (productsPage != null && childNodes.Count > 0)
            {
                this.productsList.ItemDataBound += ProductsList_ItemDataBound;
                this.productsList.DataSource = childNodes;
                this.productsList.DataBind();
            }

            PopulateWhoWeAreLinksRepeater();
            SetSocialShareButtonsDestination();
        }

        private void ProductsList_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            if (e.Item is RadListViewDataItem)
            {
                Repeater repeater = e.Item.FindControl("linksRepeater") as Repeater;

                if (repeater != null)
                {
                    var pageNode = ((RadListViewDataItem)e.Item).DataItem as PageNode;
                    repeater.DataSource = pageNode.Nodes;
                    repeater.DataBind();
                }
            }
        }

        private void PopulateWhoWeAreLinksRepeater()
        {
            if (this.WhoWeArePageIds != null && this.WhoWeArePageIds.Length > 0)
            {
                var pages = PagesUtilities.GetPageNodesByIds(this.WhoWeArePageIds).OrderBy(p => p.Title);
                
                this.whoWeArePagesList.DataSource = pages;
                this.whoWeArePagesList.DataBind();
            }
        }

        private void SetSocialShareButtonsDestination()
        {
            this.SetButtonUrl(this.LinkedInLink, LinkedInButtonExternalLink);
            this.SetButtonUrl(this.TwitterLink, TwitterButtonExternalLink);
            this.SetButtonUrl(this.FacebookLink, FacebookButtonExternalLink);
        }

        private void SetButtonUrl(HyperLink hyperLink, string buttonExternalLink)
        {
            if (!string.IsNullOrEmpty(buttonExternalLink))
            {
                hyperLink.NavigateUrl = buttonExternalLink;
            }
        }

        #region Private fields and constants

        private Guid[] whoWeArePageIds;

        #endregion
    }
}