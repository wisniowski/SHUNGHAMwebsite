using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Web;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierDetailWidget
{
    public partial class EUDossierDetailWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] urlParams = this.GetUrlParameters();
            if (urlParams.Count() > 0)
            {
                var dossierID = urlParams[0];
                var dossiers = EUIssueTrackerHelper.GetDossiers().RestrictDossiersByStatus();
                var dossierUpdate = dossiers.Where(d => d.Attributes.dossierId.Value == dossierID).FirstOrDefault();

                if (dossierUpdate != null)
                {
                    RouteHelper.SetUrlParametersResolved();
                    BindDossierDetail(dossierUpdate);
                }
            }
        }

        private void BindDossierDetail(EUDossierModel dossierUpdate)
        {
            this.dateUpdatedLtl.Text = dossierUpdate.Attributes.uni_publishdate.ToString("dd MMM yyyy");
            this.statusLtl.Text = dossierUpdate.Attributes.status.Value;
            this.dossierIDLtl.Text = dossierUpdate.Attributes.dossierId.Value;
            this.fullTitleLtl.Text = "";
        }
    }
}