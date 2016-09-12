using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.Pages;
using System.Web.UI.HtmlControls;

namespace SitefinityWebApp.CustomWidgets.FooterWidget.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="SitefinityWebApp.CustomWidgets.FooterWidget.FooterWidget"/> widget
    /// </summary>
    public class FooterWidgetDesigner : ControlDesignerBase
    {
        #region Properties
        /// <summary>
        /// Obsolete. Use LayoutTemplatePath instead.
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the layout template's relative or virtual path.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    return FooterWidgetDesigner.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        #endregion

        #region Control references
        /// <summary>
        /// Gets the page selector control.
        /// </summary>
        /// <value>The page selector control.</value>
        protected internal virtual PagesSelector PageSelectorWhoWeArePageIds
        {
            get
            {
                return this.Container.GetControl<PagesSelector>("pageSelectorWhoWeArePageIds", true);
            }
        }

        /// <summary>
        /// Gets the selector tag.
        /// </summary>
        /// <value>The selector tag.</value>
        public HtmlGenericControl SelectorTagWhoWeArePageIds
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("selectorTagWhoWeArePageIds", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the LinkedInButtonExternalLink property
        /// </summary>
        protected virtual Control LinkedInButtonExternalLink
        {
            get
            {
                return this.Container.GetControl<Control>("LinkedInButtonExternalLink", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the TwitterButtonExternalLink property
        /// </summary>
        protected virtual Control TwitterButtonExternalLink
        {
            get
            {
                return this.Container.GetControl<Control>("TwitterButtonExternalLink", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the FacebookButtonExternalLink property
        /// </summary>
        protected virtual Control FacebookButtonExternalLink
        {
            get
            {
                return this.Container.GetControl<Control>("FacebookButtonExternalLink", true);
            }
        }

        #endregion

        #region Methods
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            // Place your initialization logic here

            if (this.PropertyEditor != null)
            {
                var uiCulture = this.PropertyEditor.PropertyValuesCulture;
                this.PageSelectorWhoWeArePageIds.UICulture = uiCulture;
            }
        }
        #endregion

        #region IScriptControl implementation
        /// <summary>
        /// Gets a collection of script descriptors that represent ECMAScript (JavaScript) client components.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptDescriptor> GetScriptDescriptors()
        {
            var scriptDescriptors = new List<ScriptDescriptor>(base.GetScriptDescriptors());
            var descriptor = (ScriptControlDescriptor)scriptDescriptors.Last();

            descriptor.AddComponentProperty("pageSelectorWhoWeArePageIds", this.PageSelectorWhoWeArePageIds.ClientID);
            descriptor.AddElementProperty("selectorTagWhoWeArePageIds", this.SelectorTagWhoWeArePageIds.ClientID);
            descriptor.AddElementProperty("linkedInButtonExternalLink", this.LinkedInButtonExternalLink.ClientID);
            descriptor.AddElementProperty("twitterButtonExternalLink", this.TwitterButtonExternalLink.ClientID);
            descriptor.AddElementProperty("facebookButtonExternalLink", this.FacebookButtonExternalLink.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(FooterWidgetDesigner.scriptReference));
            return scripts;
        }

        /// <summary>
        /// Gets the required by the control, core library scripts predefined in the <see cref="ScriptRef"/> enum.
        /// </summary>
        protected override ScriptRef GetRequiredCoreScripts()
        {
            return ScriptRef.JQuery | ScriptRef.JQueryUI;
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/CustomWidgets/FooterWidget/Designer/FooterWidgetDesigner.ascx";
        public const string scriptReference = "~/CustomWidgets/FooterWidget/Designer/FooterWidgetDesigner.js";
        #endregion
    }
}
 
