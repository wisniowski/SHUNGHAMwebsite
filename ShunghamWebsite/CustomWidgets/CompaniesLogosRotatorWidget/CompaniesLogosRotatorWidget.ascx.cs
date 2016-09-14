using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ShunghamUtilities;

namespace SitefinityWebApp.CustomWidgets.CompaniesLogosSlider
{
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(CustomWidgets.CompaniesLogosRotatorWidget.Designer.CompaniesLogosRotatorWidgetDesigner))]
    public partial class CompaniesLogosRotatorWidget : System.Web.UI.UserControl
    {
        public Guid AlbumId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateLogosList();
        }

        private void PopulateLogosList()
        {
            if (AlbumId != null && AlbumId != Guid.Empty)
            {
                var logos = LibrariesUtilities.GetImagesByAlbumNativeAPI(AlbumId);

                if (logos != null)
                {
                    this.companiesLogosList.ItemDataBound += CompaniesLogosList_ItemDataBound;
                    this.companiesLogosList.DataSource = logos;
                    this.companiesLogosList.DataBind();
                }
            }
        }

        private void CompaniesLogosList_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            if (e.Item is RadListViewDataItem)
            {
                var image = ((RadListViewDataItem)e.Item).DataItem as Telerik.Sitefinity.Libraries.Model.Image;
                string imageUrl = LibrariesUtilities.GetMediaUrlByImageId(image.Id, true);

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    Image imageControl = e.Item.FindControl("logoImg") as Image;
                    imageControl.ImageUrl = imageUrl;
                }
            }
        }
    }
}