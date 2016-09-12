using ShunghamUtilities;
using System;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Web.UI;

namespace SitefinityWebApp.CustomWidgets.FooterWidget
{
    public partial class FooterWidget : System.Web.UI.UserControl
    {
        public string LinkedInButtonExternalLink { get; set; }
        public string TwitterButtonExternalLink { get; set; }
        public string FacebookButtonExternalLink { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            PageNode productsPage = PagesUtilities.GetPageNodeByTitle("products");
            var childNodes = productsPage.Nodes;
            if (productsPage != null && childNodes.Count > 0)
            {
                this.productsList.ItemDataBound += ProductsList_ItemDataBound; ;
                this.productsList.DataSource = childNodes;
                this.productsList.DataBind();
            }

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
    }
}