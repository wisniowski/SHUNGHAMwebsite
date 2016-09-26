using System;
using ShunghamUtilities;

namespace SitefinityWebApp.CustomWidgets.ButtonWidget
{
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Designer.ButtonWidgetDesigner))]
    public partial class ButtonWidget : System.Web.UI.UserControl
    {
        public string Text { get; set; }
        public string Alignment { get; set; }
        public Guid LandingPageId { get; set; }
        public string ExternalLink { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindButtonWidget();
        }

        private void BindButtonWidget()
        {
            if (!string.IsNullOrEmpty(this.Text))
            {
                this.ButtonTextLtl.Text = this.Text;
            }

            if (this.LandingPageId != null && this.LandingPageId != Guid.Empty)
            {
                var pageNodeUrl = PagesUtilities.GetPageUrlById(this.LandingPageId);
                this.ButtonLink.NavigateUrl = pageNodeUrl;
            }
            else if (!string.IsNullOrEmpty(this.ExternalLink))
            {
                this.ButtonLink.NavigateUrl = this.ExternalLink;
            }

            if (this.Alignment == "Right")
            {
                this.ButtonLink.CssClass += " align-right";
            }
            else if (this.Alignment == "Center")
            {
                this.ButtonLink.CssClass += " align-center";
            }
            else
            {
                this.ButtonLink.CssClass += " align-left";
            }
        }
    }
}