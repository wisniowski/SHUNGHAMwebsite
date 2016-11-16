using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Web.UI;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker.Breadcrumb
{
    public class CustomBreadcrumb : global::Telerik.Sitefinity.Web.UI.NavigationControls.Breadcrumb.Breadcrumb
    {
        public override string LayoutTemplatePath
        {
            get
            {
                return CustomBreadcrumb.layoutTemplatePath;
            }
        }

        protected override void InitializeControls(GenericContainer container)
        {
            base.InitializeControls(container);
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            this.SiteMapBreadcrumb.EnableEmbeddedBaseStylesheet = false;
            this.SiteMapBreadcrumb.EnableEmbeddedSkins = false;

            ((SitefinityLabel)this.BreadcrumbLabel).HideIfNoTextMode = HideIfNoTextMode.Server;
        }

        public static readonly string layoutTemplatePath = "~/CustomWidgets/EUIssueTracker/Breadcrumb/BreadcrumbTemplate.ascx";
    }
}