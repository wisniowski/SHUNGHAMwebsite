using System;
using System.Web.UI.WebControls;

namespace SitefinityWebApp.CustomWidgets.FooterWidget
{
    public partial class FooterWidget : System.Web.UI.UserControl
    {
        public string LinkedInButtonExternalLink { get; set; }
        public string TwitterButtonExternalLink { get; set; }
        public string FacebookButtonExternalLink { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetSocialShareButtonsDestination();
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