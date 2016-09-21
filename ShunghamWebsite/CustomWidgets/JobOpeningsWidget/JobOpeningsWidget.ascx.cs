using System;
using ShunghamUtilities;

namespace SitefinityWebApp.CustomWidgets.JobOpeningsWidget
{
    public partial class JobOpeningsWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindJobOpeningsWidget();
        }

        private void BindJobOpeningsWidget()
        {
            var jobOpenings = DynamicModulesUtilities.GetDataItemsByType(jobOpeningsType);
            if (jobOpenings != null)
            {
                this.jobOpeningsList.DataSource = jobOpenings;
                this.jobOpeningsList.DataBind();
            }
        }

        private const string jobOpeningsType = "Telerik.Sitefinity.DynamicTypes.Model.JobOpenings.JobOpening";
    }
}