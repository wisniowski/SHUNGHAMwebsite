using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ShunghamUtilities;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Web.UI;

namespace SitefinityWebApp.CustomWidgets.HeaderWidget
{
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Designer.HeaderWidgetDesigner))]
    public partial class HeaderWidget : System.Web.UI.UserControl
    {
        public Guid LogInButtonLandingPage { get; set; }
        public string LogInButtonExternalLink { get; set; }
        public Guid TrialButtonLandingPage { get; set; }
        public string TrialButtonExternalLink { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PopulateNavigation();
        }

        private void PopulateNavigation()
        {
            IQueryable<PageNode> topLevelPages = PagesUtilities.GetTopLevelPages(true);
            if (topLevelPages != null)
            {
                this.menuItemsList.ItemDataBound += MenuItemsList_ItemDataBound;
                this.menuItemsList.DataSource = topLevelPages;
                this.menuItemsList.DataBind();
            }
        }

        private void SetButtonUrl(HyperLink hyperLink, Guid buttonLandingPage, string buttonExternalLink)
        {
            if (buttonLandingPage != null && buttonLandingPage != Guid.Empty)
            {
                var pageNodeUrl = PagesUtilities.GetPageUrlById(buttonLandingPage);
                hyperLink.NavigateUrl = pageNodeUrl;
            }
            else if (!string.IsNullOrEmpty(buttonExternalLink))
            {
                hyperLink.NavigateUrl = buttonExternalLink;
            }
        }

        private void MenuItemsList_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            if (e.Item is RadListViewDataItem)
            {
                var pageNode = ((RadListViewDataItem)e.Item).DataItem as PageNode;
                HtmlControl listItem = e.Item.FindControl("itemTemplateLi") as HtmlControl;
                var childNodes = pageNode.Nodes;

                if (childNodes.Count > 0 && listItem != null)
                {
                    bool isUpperCase = false;

                    if (pageNode.Title.ToLower().Contains("products"))
                    {
                        isUpperCase = true;
                    }

                    PopulateChildItems(listItem, childNodes, isUpperCase);
                }
            }

            HyperLink logInLink = this.menuItemsList.FindControl("LogInLink") as HyperLink;

            if (logInLink != null)
            {
                this.SetButtonUrl(logInLink, this.LogInButtonLandingPage, this.LogInButtonExternalLink);
            }

            HyperLink trialLink = this.menuItemsList.FindControl("GetTrialLink") as HyperLink;

            if (trialLink != null)
            {
                this.SetButtonUrl(trialLink, this.TrialButtonLandingPage, this.TrialButtonExternalLink);
            }
        }

        private void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var childPageNode = e.Item.DataItem as PageNode;
                bool isUpperCase = false;
                var li = new HtmlGenericControl("li");

                string pageNodeText = childPageNode.Title;

                if (pageNodeText.ToLower().Contains("products"))
                {
                    isUpperCase = true;
                }
                else if (pageNodeText.StartsWith("EU"))
                {
                    HtmlGenericControl spanIn = new HtmlGenericControl("span");
                    string firstPart = pageNodeText.Substring(0, 2);
                    string secondPart = pageNodeText.Substring(2);
                    Literal literalIn = new Literal();
                    literalIn.Text = secondPart;
                    spanIn.Controls.Add(literalIn);

                    HtmlGenericControl spanOut = new HtmlGenericControl("span");
                    spanOut.InnerText = firstPart;
                    spanOut.Controls.Add(spanIn);
                    li.Controls.Add(spanOut);
                }
                else
                {
                    Literal literal = new Literal();
                    literal.Text = pageNodeText;

                    HyperLink pageLink = new HyperLink();
                    pageLink.NavigateUrl = childPageNode.GetUrl();
                    pageLink.Controls.Add(literal);
                    li.Controls.Add(pageLink);
                }

                e.Item.Controls.Add(li);

                if (childPageNode.Nodes.Count > 0)
                {
                    PopulateChildItems(li, childPageNode.Nodes, isUpperCase);
                }
            }
        }

        private void PopulateChildItems(Control item, IList<PageNode> childNodes, bool isUpperCase)
        {
            var ul = new HtmlGenericControl("ul");

            if (isUpperCase)
            {
                ul.Attributes.Add("class", "text-uppercase");
            }

            Repeater repeater = new Repeater();
            repeater.ItemDataBound += Repeater_ItemDataBound;
            repeater.DataSource = childNodes;
            repeater.DataBind();

            ul.Controls.Add(repeater);
            item.Controls.Add(ul);
        }
    }
}