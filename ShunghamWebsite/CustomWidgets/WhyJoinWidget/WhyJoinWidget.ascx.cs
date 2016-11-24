using ShunghamUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SitefinityWebApp.CustomWidgets.WhyJoinWidget
{
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Designer.WhyJoinWidgetDesigner))]
    public partial class WhyJoinWidget : System.Web.UI.UserControl
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string FirstButtonText { get; set; }
        public Guid FirstButtonLandingPage { get; set; }
        public string FirstButtonBackground { get; set; }
        public string SecondButtonText { get; set; }
        public Guid SecondButtonLandingPage { get; set; }
        public string SecondButtonBackground { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindWhyJoinWidget();
        }

        private void BindWhyJoinWidget()
        {
            if (!string.IsNullOrEmpty(this.Title))
            {
                this.TitleLtl.Text = this.Title;
            }

            if (!string.IsNullOrEmpty(this.Content))
            {
                this.ContentLtl.Text = this.Content;
            }

            if (!string.IsNullOrEmpty(this.FirstButtonText))
            {
                HyperLink button = AddButton(this.FirstButtonText, this.FirstButtonLandingPage, this.FirstButtonBackground);

                if (button != null)
                {
                    this.btnWrapper.Controls.Add(button);
                }
            }

            if (!string.IsNullOrEmpty(this.SecondButtonText))
            {
                HyperLink button = AddButton(this.SecondButtonText, this.SecondButtonLandingPage, this.SecondButtonBackground);

                if (button != null)
                {
                    this.btnWrapper.Controls.Add(button);
                }
            }
        }

        private HyperLink AddButton(string btnText, Guid btnLandingPage, string btnBackground)
        {
            HyperLink button = new HyperLink();

            if (!string.IsNullOrEmpty(btnText))
            {
                button.Text = btnText;
            }

            if (btnLandingPage != null && btnLandingPage != Guid.Empty)
            {
                var pageNodeUrl = PagesUtilities.GetPageUrlById(btnLandingPage);
                button.NavigateUrl = pageNodeUrl;
            }

            if (!string.IsNullOrEmpty(btnBackground))
            {
                if (btnBackground == "White")
                {
                    button.CssClass = "c";
                }
                else if (btnBackground == "Blue")
                {
                    button.CssClass = "b";
                }
                else
                {
                    button.CssClass = "";
                }
            }

            return button;
        }
    }
}