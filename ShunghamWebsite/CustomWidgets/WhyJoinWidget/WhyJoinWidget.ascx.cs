using System;
using System.Web.UI.WebControls;
using ShunghamUtilities;

namespace SitefinityWebApp.CustomWidgets.WhyJoinWidget
{
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Designer.WhyJoinWidgetDesigner))]
    public partial class WhyJoinWidget : System.Web.UI.UserControl
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string FirstButtonText { get; set; }
        public Guid FirstButtonLandingPage { get; set; }
        public string FirstButtonExternalLink { get; set; }
        public string FirstButtonBackground { get; set; }
        public string SecondButtonText { get; set; }
        public Guid SecondButtonLandingPage { get; set; }
        public string SecondButtonExternalLink { get; set; }
        public string SecondButtonBackground { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindWhyJoinWidget();
        }

        private void BindWhyJoinWidget()
        {
            //Set Title
            if (!string.IsNullOrEmpty(this.Title))
            {
                this.TitleLtl.Text = this.Title;
            }

            //Add Content
            if (!string.IsNullOrEmpty(this.Content))
            {
                this.ContentLtl.Text = this.Content;
            }

            //Add button
            if (!string.IsNullOrEmpty(this.FirstButtonText))
            {
                HyperLink button = AddButton(this.FirstButtonText, this.FirstButtonLandingPage, this.FirstButtonExternalLink, this.FirstButtonBackground);

                if (button != null)
                {
                    this.btnWrapper.Controls.Add(button);
                }
            }

            //Add button
            if (!string.IsNullOrEmpty(this.SecondButtonText))
            {
                HyperLink button = AddButton(this.SecondButtonText, this.SecondButtonLandingPage, this.SecondButtonExternalLink, this.SecondButtonBackground);

                if (button != null)
                {
                    this.btnWrapper.Controls.Add(button);
                }
            }
        }

        /// <summary>
        /// Method for adding custom button.
        /// </summary>
        /// <param name="btnText">The button text.</param>
        /// <param name="btnLandingPage">The button landing page.</param>
        /// <param name="btnBackground">The button background color.</param>
        private HyperLink AddButton(string btnText, Guid btnLandingPage, string externalLink, string btnBackground)
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
            else if (!string.IsNullOrEmpty(externalLink))
            {
                button.NavigateUrl = externalLink;
            }

            if (!string.IsNullOrEmpty(btnBackground))
            {
                if (btnBackground == "White")
                {
                    button.CssClass = whiteBtnCssClass;
                }
                else if (btnBackground == "Blue")
                {
                    button.CssClass = blueBtnCssClass;
                }
                else
                {
                    button.CssClass = "";
                }
            }

            return button;
        }

        #region Private fields and constants

        private const string whiteBtnCssClass = "c";
        private const string blueBtnCssClass = "b";
        #endregion
    }
}