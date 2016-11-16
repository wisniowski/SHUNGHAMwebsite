using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShunghamUtilities;
using SitefinityWebApp.CustomWidgets.ContactUsWidget.Designer;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Forms.Model;
using Telerik.Sitefinity.Modules.Forms;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Sitefinity.Model;

namespace SitefinityWebApp.CustomWidgets.ContactUsWidget
{
    [ControlDesigner(typeof(ContactUsWidgetDesigner))]
    public partial class ContactUs : System.Web.UI.UserControl
    {
        public Guid BackgroundImageId { get; set; }
        public bool ShowTitle { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.wrapper.Visible = true;
                this.success.Visible = false;
            }

            if (this.ShowTitle)
            {
                this.titleLbl.Attributes["style"] = "display:block";
                this.wrapper.Attributes["class"] = ContactUs.wrapperClass;
            }
            else
            {
                this.titleLbl.Attributes["style"] = "display:none";
            }
            SetBackgroundImage();
        }

        private void SetBackgroundImage()
        {
            if (BackgroundImageId != null && BackgroundImageId != Guid.Empty)
            {
                this.articleWrapper.Attributes["class"] = ContactUs.articleWrapperBackgroundClass;
                if (this.backgrdImage != null)
                {
                    var imageUrl = LibrariesUtilities.GetMediaUrlByImageId(this.BackgroundImageId, true);
                    this.backgrdImage.ImageUrl = imageUrl;
                    this.backgrdImage.AlternateText = LibrariesUtilities.GetAltByImageId(this.BackgroundImageId);
                    if (this.backgrdFigure != null)
                    {
                        this.backgrdFigure.Attributes["style"] = string.Format(@"background-image: url('{0}');", imageUrl);
                    }
                }
            }
            else
            {
                this.backgrdFigure.Visible = false;
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                string ipAddress = this.Page.Request.UserHostAddress;

                var identity = ClaimsManager.GetCurrentIdentity();
                var userId = identity != null ? identity.UserId : Guid.Empty;
                FormsUtilities.SubmitForm(this.faa.Text, this.fab.Text, this.fac.Text, this.fad.Text,
                    this.fae.Text, this.faf.Text, ipAddress, userId, ContactUs.formName);

                this.wrapper.Visible = false;
                this.success.Visible = true;
            }
        }

        #region Private fields and constants

        private const string formName = "sf_contactus";
        private const string articleWrapperBackgroundClass = "module-a has-background";
        private const string wrapperClass = "module-b double";

        #endregion
    }
}