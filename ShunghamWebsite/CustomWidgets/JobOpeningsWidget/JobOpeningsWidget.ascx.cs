using System;
using ShunghamUtilities;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace SitefinityWebApp.CustomWidgets.JobOpeningsWidget
{
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Designer.JobOpeningsWidgetDesigner))]
    public partial class JobOpeningsWidget : System.Web.UI.UserControl
    {
        public Guid ApplyNowLandingPage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindJobOpeningsWidget();
        }

        private void BindJobOpeningsWidget()
        {
            var jobOpenings = DynamicModulesUtilities.GetDataItemsByType(jobOpeningsType);
            if (jobOpenings != null)
            {
                if (this.ApplyNowLandingPage != null && this.ApplyNowLandingPage != Guid.Empty)
                {
                    this.jobOpeningsList.ItemDataBound += JobOpeningsList_ItemDataBound;
                }
                this.jobOpeningsList.DataSource = jobOpenings;
                this.jobOpeningsList.DataBind();
            }
        }

        private void JobOpeningsList_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            if (e.Item is RadListViewDataItem)
            {
                HyperLink applyNowLink = e.Item.FindControl("ApplyNowLink") as HyperLink;

                if (applyNowLink != null)
                {
                    applyNowLink.NavigateUrl = PagesUtilities.GetPageUrlById(this.ApplyNowLandingPage);
                }
            }
        }

        private const string jobOpeningsType = "Telerik.Sitefinity.DynamicTypes.Model.JobOpenings.JobOpening";
    }
}