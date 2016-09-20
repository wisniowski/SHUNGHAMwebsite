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
                this.wrapper.Attributes["class"] = "module-b double";
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
                this.articleWrapper.Attributes["class"] = "module-a has-background";
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
                this.articleWrapper.Attributes["class"] = "double a";
                this.backgrdFigure.Visible = false;
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                SubmitContactForm();
            }
        }

        private void SubmitContactForm()
        {
            Dictionary<string, string> inputs = new Dictionary<string, string>();

            inputs.Add("FirstName", this.faa.Text);
            inputs.Add("LastName", this.fab.Text);
            inputs.Add("Email", this.fac.Text);
            inputs.Add("PhoneNumber", this.fad.Text);
            inputs.Add("Company", this.fae.Text);
            inputs.Add("Message", this.faf.Text);

            FormsManager manager = FormsManager.GetManager();
            var form = manager.GetFormByName("sf_contactus");
            FormEntry entry = manager.CreateFormEntry(form.EntriesTypeName);

            foreach (var item in inputs)
            {
                entry.SetValue(item.Key, item.Value);
            }

            entry.IpAddress = this.Page.Request.UserHostAddress;
            var identity = ClaimsManager.GetCurrentIdentity();
            entry.UserId = identity != null ? identity.UserId : Guid.Empty;

            if (AppSettings.CurrentSettings.Multilingual)
            {
                entry.Language = System.Globalization.CultureInfo.CurrentUICulture.Name;
            }

            entry.ReferralCode = (manager.Provider.GetNextReferralCode(entry.GetType().ToString())).ToString();
            entry.SubmittedOn = System.DateTime.UtcNow;

            manager.SaveChanges();

            this.wrapper.Visible = false;
            this.success.Visible = true;
        }
    }
}