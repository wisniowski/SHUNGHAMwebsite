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
        public string BackgroundColor { get; set; }

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
        }
    }
}