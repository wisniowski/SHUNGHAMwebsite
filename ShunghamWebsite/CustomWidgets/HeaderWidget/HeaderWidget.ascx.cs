using System;
using System.Linq;
using Telerik.Sitefinity.Pages.Model;
using ShunghamUtilities;

namespace SitefinityWebApp.CustomWidgets.HeaderWidget
{
    public partial class HeaderWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PopulateNavigation();
        }

        private void PopulateNavigation()
        {
            IQueryable<PageNode> topLevelPages = PagesUtilities.GetTopLevelPages(true);
            if (topLevelPages != null)
            {
                this.menuItemsList.DataSource = topLevelPages;
            }
        }
    }
}