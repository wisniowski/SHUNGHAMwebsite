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
            List<DynamicContent> dataSource;

            var productFeatures = DynamicModulesUtilities.GetDataItemsByType(productFeaturesType);
            
            if (productFeatures != null)
            {
                if (this.ProductId != null && this.ProductId != Guid.Empty)
                {
                    var productTitle = DynamicModulesUtilities.GetDataItemTitleById(productType, this.ProductId);
                    dataSource = this.GetDataItemsRelatedToItemWithTitle(productTitle, productFeatures);
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

        private List<DynamicContent> GetDataItemsRelatedToItemWithTitle(string titleOfTheRelatedItem, IQueryable<DynamicContent> dataItems)
        {
            List<DynamicContent> dataSource = new List<DynamicContent>();

            foreach (var feature in dataItems)
            {
                var relatedItemsTemp = feature.GetRelatedItems(relatedProductsFieldName).OfType<DynamicContent>();

                foreach (var relatedProduct in relatedItemsTemp)
                {
                    if (relatedProduct.GetString("Title") == titleOfTheRelatedItem)
                    {
                        dataSource.Add(feature);
                    }
                }
            }

            return dataSource;
        }

        private const string productFeaturesType = "Telerik.Sitefinity.DynamicTypes.Model.ProductFeatures.Productfeature";
        private const string productType = "Telerik.Sitefinity.DynamicTypes.Model.Products.Product";
        private const string relatedProductsFieldName = "RelatedProduct";
    }
}