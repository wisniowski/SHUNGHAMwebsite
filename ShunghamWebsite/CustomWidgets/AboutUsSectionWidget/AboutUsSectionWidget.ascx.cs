using ShunghamUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitefinityWebApp.CustomWidgets.AboutUsSectionWidget
{
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Designer.AboutUsSectionWidgetDesigner))]
    public partial class AboutUsSectionWidget : System.Web.UI.UserControl
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid Image { get; set; }
        public string ImageAlignment { get; set; }
        public string TextBackgroundColor { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Title))
            {
                this.TitleLtl.Text = this.Title;
            }

            if (!string.IsNullOrEmpty(this.Content))
            {
                this.ContentLtl.Text = this.Content;
            }

            if (this.Image != null && this.Image != Guid.Empty)
            {
                this.ImageControl.ImageUrl = LibrariesUtilities.GetMediaUrlByImageId(this.Image, true);
                this.ImageControl.AlternateText = LibrariesUtilities.GetAltByImageId(this.Image);
            }

            if (!string.IsNullOrEmpty(this.ImageAlignment))
            {
                if (this.ImageAlignment == "Left")
                {
                    this.imageWrapper.Attributes.Add("class", "float-left");
                }
                else
                {
                    this.imageWrapper.Attributes.Add("class", "float-right");
                }
            }

            if (!string.IsNullOrEmpty(this.TextBackgroundColor))
            {
                if (this.TextBackgroundColor == "White")
                {
                    this.contentWrapper.Style.Add("background-color", "white");
                    this.contentWrapper.Style.Add("padding", "60px 80px 5px");
                }
            }
        }
    }
}