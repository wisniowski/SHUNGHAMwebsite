using ShunghamUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitefinityWebApp.CustomWidgets.OurTeamWidget
{
    public partial class OurTeamWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTeamMembersWidget();
        }

        private void BindTeamMembersWidget()
        {
            var teamMembers = DynamicModulesUtilities.GetDataItemsByType(teamMembersType);
            if (teamMembers != null)
            {
                this.teamMembersList.DataSource = teamMembers;
                this.teamMembersList.DataBind();
            }
        }

        private const string teamMembersType = "Telerik.Sitefinity.DynamicTypes.Model.Teammembers.TeamMember";
    }
}