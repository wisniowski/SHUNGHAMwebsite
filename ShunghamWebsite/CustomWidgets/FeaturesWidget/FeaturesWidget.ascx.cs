using System;
using System.Collections.Generic;
using System.Linq;
using ShunghamUtilities;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.RelatedData;

namespace SitefinityWebApp.CustomWidgets.FeaturesWidget
{
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Designer.FeaturesWidgetDesigner))]
    public partial class FeaturesWidget : System.Web.UI.UserControl
    {
        public Guid ProductId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindFeaturesWidget();
        }

        private void BindFeaturesWidget()
        {
            var productFeatures = DynamicModulesUtilities.GetDataItemsByType(productFeaturesType);
            List<DynamicContent> dataSource = new List<DynamicContent>();
            if (productFeatures != null)
            {
                if (this.ProductId != null && this.ProductId != Guid.Empty)
                {
                    var productTitle = DynamicModulesUtilities.GetDataItemTitleById(productType, this.ProductId);
                    foreach (var feature in productFeatures)
                    {
                        var relatedItemsTemp = feature.GetRelatedItems("RelatedProduct").OfType<DynamicContent>();

                        foreach (var relatedProduct in relatedItemsTemp)
                        {
                            if (relatedProduct.GetString("Title") == productTitle)
                            {
                                dataSource.Add(feature);
                            }
                        }
                    }
                }
                else
                {
                    dataSource = productFeatures.ToList();
                }

                if (dataSource != null)
                {
                    this.featuresList.DataSource = dataSource;
                    this.featuresList.DataBind();

                    this.featuresPopupList.DataSource = dataSource;
                    this.featuresPopupList.DataBind();
                }
            }
        }

        private const string productFeaturesType = "Telerik.Sitefinity.DynamicTypes.Model.ProductFeatures.Productfeature";
        private const string productType = "Telerik.Sitefinity.DynamicTypes.Model.Products.Product";
    }
}