using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker.EUINavigationWidget
{
    public partial class NavigationWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindNavigationWidget();
        }

        private void BindNavigationWidget()
        {
            IEnumerable<CustomNavGroup<string, EUIPolicyAreaModel>> result =
                EUIssueTrackerHelper.GetNavigationItems()
                .GroupBy(w => w.Attributes.policyAreaName.Value)
                .Select(g => new CustomNavGroup<string, EUIPolicyAreaModel>() { Key = g.Key, Values = g });

            this.navigationList.DataSource = result;
            this.navigationList.DataBind();
        }
    }
}