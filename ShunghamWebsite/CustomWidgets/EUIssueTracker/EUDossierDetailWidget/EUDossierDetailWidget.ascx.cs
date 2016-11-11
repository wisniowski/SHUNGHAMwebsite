using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Web;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierDetailWidget
{
    public partial class EUDossierDetailWidget : UserControl, IBreadcrumExtender
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            RouteHelper.SetUrlParametersResolved();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.Page.RegisterBreadcrumbExtender(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] urlParams = this.GetUrlParameters();
            if (urlParams != null && urlParams.Count() > 0)
            {
                var dossierID = urlParams[0];
                var dossiers = EUIssueTrackerHelper.GetDossiers().RestrictDossiersByStatus();
                dossierUpdate = dossiers.Where(d => d.Attributes.dossierId.Value == dossierID).FirstOrDefault();

                if (dossierUpdate != null)
                {
                    RouteHelper.SetUrlParametersResolved();
                    BindDossierDetail(dossierUpdate);
                    ResolvePageMetaTags(dossierUpdate);
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

        private void ResolvePageMetaTags(EUDossierModel dossierUpdate)
        {
            if (this.Page == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(dossierUpdate.Attributes.uni_fulltitle))
            {
                this.Page.MetaDescription = dossierUpdate.Attributes.uni_fulltitle;
            }
            if (!string.IsNullOrEmpty(dossierUpdate.Attributes.uni_shorttitle))
            {
                this.Page.Title = dossierUpdate.Attributes.uni_shorttitle;
            }
        }

        public IEnumerable<SiteMapNode> GetVirtualNodes(SiteMapProvider provider)
        {
            IList<SiteMapNode> sitemap = new List<SiteMapNode>();
            if (dossierUpdate != null)
            {
                SiteMapNode policyAreaNode = new SiteMapNode(provider, "dossierUpdateKey", "#",
                    dossierUpdate.Attributes.policyAreaName.Value);
                sitemap.Add(policyAreaNode);
                SiteMapNode policyCategoryNode = new SiteMapNode(provider, "dossierUpdateKey", "#",
                    dossierUpdate.Attributes.policyCategoryName.Value);
                sitemap.Add(policyCategoryNode);
                SiteMapNode dossierUpdateNode = new SiteMapNode(provider, "dossierUpdateKey", "#",
                    dossierUpdate.Attributes.status.Value, dossierUpdate.Attributes.uni_shorttitle);
                sitemap.Add(dossierUpdateNode);
                return sitemap;
            }
            return sitemap;
        }

        #region Private fields and constants

        public EUDossierModel dossierUpdate = null;

        #endregion
    }
}