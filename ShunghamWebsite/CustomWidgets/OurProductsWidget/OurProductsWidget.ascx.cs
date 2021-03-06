﻿using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShunghamUtilities;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Web.UI;

namespace SitefinityWebApp.CustomWidgets.OurProductsWidget
{
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Designer.OurProductsWidgetDesigner))]
    public partial class OurProductsWidget : System.Web.UI.UserControl
    {
        public Guid BackgroundImageId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.productsList.PreRender += ProductsList_PreRender;

            PopulateProducts();
        }

        private void ProductsList_PreRender(object sender, EventArgs e)
        {
            Image backgroundImg = this.productsList.FindControl("BackgroundImg") as Image;

            if (backgroundImg != null && BackgroundImageId != null && BackgroundImageId != Guid.Empty)
            {
                backgroundImg.ImageUrl = LibrariesUtilities.GetMediaUrlByImageId(this.BackgroundImageId, true);
                backgroundImg.AlternateText = LibrariesUtilities.GetAltByImageId(this.BackgroundImageId);
            }
        }

        private void PopulateProducts()
        {
            var products = DynamicModulesUtilities.GetDataItemsByType(productsType);
            if (products != null)
            {
                this.productsList.ItemDataBound += ProductsList_ItemDataBound;
                this.productsList.DataSource = products;
                this.productsList.DataBind();
            }
        }

        private void ProductsList_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            if (e.Item is RadListViewDataItem)
            {
                HtmlControl heading3 = e.Item.FindControl("ProductTitle") as HtmlControl;
                DynamicContent productItem = ((RadListViewDataItem)e.Item).DataItem as DynamicContent;
                string productTitle = String.Empty;

                if (productItem != null)
                {
                    productTitle = productItem.GetString("Title");
                }

                if (heading3 != null)
                {
                    if (productTitle.StartsWith("EU"))
                    {
                        HtmlGenericControl span = new HtmlGenericControl("span");
                        span.Attributes.Add("class", productNameSpanClass);
                        string firstPart = productTitle.Substring(0, 2);
                        string secondPart = productTitle.Substring(2);
                        Literal literalEU = new Literal();
                        literalEU.Text = firstPart;
                        heading3.Controls.Add(literalEU);

                        span.InnerText = secondPart;
                        heading3.Controls.Add(span);
                    }
                    else
                    {
                        Literal productTitleLtl = new Literal();
                        productTitleLtl.Text = productTitle;
                        heading3.Controls.Add(productTitleLtl);
                    }
                }
                
                //Add NavigateUrl to Policy Coverage link
                HyperLink policyCoverageLink = e.Item.FindControl("PolicyCoverageLink") as HyperLink;
                PageNode policyCoveragePageNode = productItem.GetValue("PolicyCoverageLandingPage") as PageNode;

                if (policyCoverageLink != null && policyCoveragePageNode != null)
                {
                    policyCoverageLink.NavigateUrl = PagesUtilities.GetPageUrlByPageNode(policyCoveragePageNode);
                }

                //Add NavigateUrl to Read More link
                HyperLink readMoreLink = e.Item.FindControl("ReadMoreLink") as HyperLink;
                PageNode readMorePageNode = productItem.GetValue("ReadMoreLandingPage") as PageNode;

                if (readMoreLink != null && readMorePageNode != null)
                {
                    readMoreLink.NavigateUrl = PagesUtilities.GetPageUrlByPageNode(readMorePageNode);
                }
            }
        }

        private const string productsType = "Telerik.Sitefinity.DynamicTypes.Model.Products.Product";
        private const string productNameSpanClass = "overlay-c";
    }
}