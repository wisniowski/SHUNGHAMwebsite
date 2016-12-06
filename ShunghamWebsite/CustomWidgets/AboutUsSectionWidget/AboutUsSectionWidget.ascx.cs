using System;
using ShunghamUtilities;
using System.Web.UI.HtmlControls;
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
            this.BindWidget();
        }

        private void BindWidget()
        {
            if (!string.IsNullOrEmpty(this.Title))
            {
                var titleControl = this.CreateTitle(this.Title);
                this.divWrapper.Controls.AddAt(0, titleControl);
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
                    this.imageWrapper.Attributes.Add("class", leftAlignmentCSSClass);
                }
                else
                {
                    this.imageWrapper.Attributes.Add("class", rightAlignmentCSSClass);
                }
            }

            if (!string.IsNullOrEmpty(this.TextBackgroundColor))
            {
                if (this.TextBackgroundColor == "White")
                {
                    this.contentWrapper.Style.Add("background-color", whiteBGRColorName);
                    this.contentWrapper.Style.Add("padding", contentWrapperPaddingStyle);
                }
            }
        }

        private HtmlGenericControl CreateTitle(string title)
        {
            HtmlGenericControl h2 = new HtmlGenericControl("h2");
            h2.Attributes.Add("class", headerCSSClass);

            Literal titleLtl = new Literal();
            titleLtl.Text = title;

            h2.Controls.Add(titleLtl);

            return h2;
        }

        #region Private fields and constants

        private const string leftAlignmentCSSClass = "float-left";
        private const string rightAlignmentCSSClass = "float-right";
        private const string headerCSSClass = "header-a text-center";
        private const string whiteBGRColorName = "white";
        private const string contentWrapperPaddingStyle = "60px 80px 5px";

        #endregion
    }
}