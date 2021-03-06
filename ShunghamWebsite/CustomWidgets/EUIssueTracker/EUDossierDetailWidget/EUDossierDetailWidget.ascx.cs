﻿using System;
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
            this.dateUpdatedLtl.Text = dossierUpdate.Attributes.publishDate.Value.ToString("dd MMM yyyy");
            this.statusLtl.Text = dossierUpdate.Attributes.status.Value;
            this.dossierIDLtl.Text = dossierUpdate.Attributes.dossierId.Value;
            this.fullTitleLtl.Text = dossierUpdate.Attributes.fulltitle.Value;
        }

        private void ResolvePageMetaTags(EUDossierModel dossierUpdate)
        {
            if (this.Page == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(dossierUpdate.Attributes.fulltitle.Value))
            {
                this.Page.MetaDescription = dossierUpdate.Attributes.fulltitle.Value;
            }
            if (!string.IsNullOrEmpty(dossierUpdate.Attributes.shortTitle.Value))
            {
                this.Page.Title = dossierUpdate.Attributes.shortTitle.Value;
            }
        }

        public IEnumerable<SiteMapNode> GetVirtualNodes(SiteMapProvider provider)
        {
            IList<SiteMapNode> sitemap = new List<SiteMapNode>();
            if (dossierUpdate != null)
            {
                SiteMapNode policyAreaNode = new SiteMapNode(provider, "dossierUpdateKey", "javascript:void(0)",
                    dossierUpdate.Attributes.policyAreaName.Value);
                sitemap.Add(policyAreaNode);
                string policyAreaAndCatUrl = "javascript:void(0)";
                EUIssueTrackerHelper.ConstructPolicyAreaAndCategoryURL(dossierUpdate.Attributes.policyAreaName.Value, 
                    dossierUpdate.Attributes.policyCategoryName.Value, out policyAreaAndCatUrl);
                SiteMapNode policyCategoryNode = new SiteMapNode(provider, "dossierUpdateKey", policyAreaAndCatUrl,
                    dossierUpdate.Attributes.policyCategoryName.Value);
                sitemap.Add(policyCategoryNode);
                var statusUrl = "javascript:void(0)";
                EUIssueTrackerHelper.ConstructStatusUrl(dossierUpdate.Attributes.status.Value, out statusUrl);
                SiteMapNode dossierUpdateNode = new SiteMapNode(provider, "dossierUpdateKey", statusUrl,
                    dossierUpdate.Attributes.status.Value, dossierUpdate.Attributes.shortTitle.Value);
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