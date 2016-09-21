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

namespace SitefinityWebApp.CustomWidgets.JobOpeningsWidget.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="SitefinityWebApp.CustomWidgets.JobOpeningsWidget.JobOpeningsWidget"/> widget
    /// </summary>
    public class JobOpeningsWidgetDesigner : ControlDesignerBase
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
                    return JobOpeningsWidgetDesigner.layoutTemplatePath;
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
        protected internal virtual PagesSelector PageSelectorApplyNowLandingPage
        {
            get
            {
                return this.Container.GetControl<PagesSelector>("pageSelectorApplyNowLandingPage", true);
            }
        }

        /// <summary>
        /// Gets the selector tag.
        /// </summary>
        /// <value>The selector tag.</value>
        public HtmlGenericControl SelectorTagApplyNowLandingPage
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("selectorTagApplyNowLandingPage", true);
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
                this.PageSelectorApplyNowLandingPage.UICulture = uiCulture;
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

            descriptor.AddComponentProperty("pageSelectorApplyNowLandingPage", this.PageSelectorApplyNowLandingPage.ClientID);
            descriptor.AddElementProperty("selectorTagApplyNowLandingPage", this.SelectorTagApplyNowLandingPage.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(JobOpeningsWidgetDesigner.scriptReference));
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
        public static readonly string layoutTemplatePath = "~/CustomWidgets/JobOpeningsWidget/Designer/JobOpeningsWidgetDesigner.ascx";
        public const string scriptReference = "~/CustomWidgets/JobOpeningsWidget/Designer/JobOpeningsWidgetDesigner.js";
        #endregion
    }
}
 
