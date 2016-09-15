using System;

namespace SitefinityWebApp.CustomWidgets.InfoWidget
{
    public partial class InfoWidget : System.Web.UI.UserControl
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateInformation();
        }

        public void PopulateInformation()
        {
            if (!string.IsNullOrEmpty(this.Title))
            {
                this.TitleLtl.Text = this.Title;
            }

            if (!string.IsNullOrEmpty(this.Summary))
            {
                this.SummaryLtl.Text = this.Summary;
            }

            if (!string.IsNullOrEmpty(this.Content))
            {
                this.ContentLtl.Text = this.Content;
            }
        }
    }
}