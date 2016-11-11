using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Web;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierDetailWidget
{
    public partial class EUDossierDetailWidget : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] urlParams = this.GetUrlParameters();
            if (urlParams != null && urlParams.Count() > 0)
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
            this.fullTitleLtl.Text = dossierUpdate.Attributes.uni_fulltitle;
        }

        #region IBreadcrumExtender

        //public IEnumerable<SiteMapNode> GetVirtualNodes(SiteMapProvider provider)
        //{
        //    IList<SiteMapNode> sitemap = new List<SiteMapNode>();
        //    var navItem = EUIssueTrackerHelper.GetNavItemByUrlParams(this.GetUrlParameters());
        //    if (navItem != null)
        //    {
        //        SiteMapNode policyAreaNode = new SiteMapNode(provider, "policyAreaKey", navItem.policyAreaURL,
        //            navItem.policyAreaName, navItem.policyCategoryName);
        //        sitemap.Add(policyAreaNode);
        //        return sitemap;
        //    }
        //    return sitemap;
        //}

        #endregion
    }
}