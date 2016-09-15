using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Sitefinity.Modules.Pages;

namespace SitefinityWebApp.CustomWidgets.HeaderWidget.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="SitefinityWebApp.CustomWidgets.HeaderWidget.HeaderWidget"/> widget
    /// </summary>
    public class HeaderWidgetDesigner : ControlDesignerBase
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
                    return HeaderWidgetDesigner.layoutTemplatePath;
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
        protected internal virtual PagesSelector PageSelectorLogInButtonLandingPage
        {
            get
            {
                return this.Container.GetControl<PagesSelector>("pageSelectorLogInButtonLandingPage", true);
            }
        }

        /// <summary>
        /// Gets the selector tag.
        /// </summary>
        /// <value>The selector tag.</value>
        public HtmlGenericControl SelectorTagLogInButtonLandingPage
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("selectorTagLogInButtonLandingPage", true);
            }
        }

        /// <summary>
        /// Gets the page selector control.
        /// </summary>
        /// <value>The page selector control.</value>
        protected internal virtual PagesSelector PageSelectorTrialButtonLandingPage
        {
            get
            {
                return this.Container.GetControl<PagesSelector>("pageSelectorTrialButtonLandingPage", true);
            }
        }

        /// <summary>
        /// Gets the selector tag.
        /// </summary>
        /// <value>The selector tag.</value>
        public HtmlGenericControl SelectorTagTrialButtonLandingPage
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("selectorTagTrialButtonLandingPage", true);
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
                this.PageSelectorLogInButtonLandingPage.UICulture = uiCulture;
                this.PageSelectorTrialButtonLandingPage.UICulture = uiCulture;
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

            descriptor.AddComponentProperty("pageSelectorLogInButtonLandingPage", this.PageSelectorLogInButtonLandingPage.ClientID);
            descriptor.AddElementProperty("selectorTagLogInButtonLandingPage", this.SelectorTagLogInButtonLandingPage.ClientID);
            descriptor.AddComponentProperty("pageSelectorTrialButtonLandingPage", this.PageSelectorTrialButtonLandingPage.ClientID);
            descriptor.AddElementProperty("selectorTagTrialButtonLandingPage", this.SelectorTagTrialButtonLandingPage.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(HeaderWidgetDesigner.scriptReference));
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
        public static readonly string layoutTemplatePath = "~/CustomWidgets/HeaderWidget/Designer/HeaderWidgetDesigner.ascx";
        public const string scriptReference = "~/CustomWidgets/HeaderWidget/Designer/HeaderWidgetDesigner.js";
        #endregion
    }
}
 
