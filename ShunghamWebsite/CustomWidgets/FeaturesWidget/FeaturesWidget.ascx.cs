using System;
using ShunghamUtilities;

namespace SitefinityWebApp.CustomWidgets.FeaturesWidget
{
    public partial class FeaturesWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindFeaturesWidget();
        }

        private void BindFeaturesWidget()
        {
            var productFeatures = DynamicModulesUtilities.GetDataItemsByType(productFeaturesType);
            if (productFeatures != null)
            {
                this.featuresList.DataSource = productFeatures;
                this.featuresList.DataBind();

                this.featuresPopupList.DataSource = productFeatures;
                this.featuresPopupList.DataBind();
            }
        }

        private const string productFeaturesType = "Telerik.Sitefinity.DynamicTypes.Model.ProductFeatures.Productfeature";
    }
}