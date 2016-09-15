﻿using ShunghamUtilities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitefinityWebApp.CustomWidgets.BannerWidget
{
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Designer.BannerWidgetDesigner))]
    public partial class BannerWidget : System.Web.UI.UserControl
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public Guid BackgroundImageId { get; set; }
        public string FirstBtnText { get; set; }
        public Guid FirstBtnLandingPage { get; set; }
        public string FirstBtnExternalLink { get; set; }
        public string SecondBtnText { get; set; }
        public Guid SecondBtnLandingPage { get; set; }
        public string SecondBtnExternalLink { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Title))
            {
                this.titleLtl.Text = Title;
            }

            if (!string.IsNullOrEmpty(SubTitle))
            {
                this.subTitleLtl.Text = SubTitle;
            }

            if (!string.IsNullOrEmpty(FirstBtnText) || !string.IsNullOrEmpty(FirstBtnExternalLink))
            {
                this.AddButton(this.btnParagraph, FirstBtnText, FirstBtnLandingPage, FirstBtnExternalLink);
            }

            if (!string.IsNullOrEmpty(SecondBtnText) || !string.IsNullOrEmpty(SecondBtnExternalLink))
            {
                this.AddButton(this.btnParagraph, SecondBtnText, SecondBtnLandingPage, SecondBtnExternalLink);
            }

            if (BackgroundImageId != null && BackgroundImageId != Guid.Empty)
            {
                this.bgrImage.ImageUrl = LibrariesUtilities.GetMediaUrlByImageId(BackgroundImageId, true);
            }
        }

        private void AddButton(Control parent, string btnText, Guid landingPageId, string btnUrl)
        {
            HyperLink btnLink = new HyperLink();
            btnLink.Target = "_blank";
            btnLink.CssClass = "b";

            if (landingPageId != null && landingPageId != Guid.Empty)
            {
                var pageNodeUrl = PagesUtilities.GetPageUrlById(landingPageId);
                btnLink.NavigateUrl = pageNodeUrl;
            }

            if (!string.IsNullOrEmpty(btnUrl))
            {
                btnLink.NavigateUrl = btnUrl;
            }

            if (!string.IsNullOrEmpty(btnText))
            {
                Literal btnTextLtl = new Literal();
                btnTextLtl.Text = btnText;
                btnLink.Controls.Add(btnTextLtl);
            }

            parent.Controls.Add(btnLink);
        }
    }
}