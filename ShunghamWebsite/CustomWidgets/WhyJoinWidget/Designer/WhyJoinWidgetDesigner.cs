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
using Telerik.Sitefinity.Web.UI.Fields;

namespace SitefinityWebApp.CustomWidgets.WhyJoinWidget.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="SitefinityWebApp.CustomWidgets.WhyJoinWidget.WhyJoinWidget"/> widget
    /// </summary>
    public class WhyJoinWidgetDesigner : ControlDesignerBase
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
                    return WhyJoinWidgetDesigner.layoutTemplatePath;
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
        /// Gets the control that is bound to the Title property
        /// </summary>
        protected virtual HtmlField Title
        {
            get
            {
                return this.Container.GetControl<HtmlField>("Title", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the Content property
        /// </summary>
        protected virtual HtmlField Content
        {
            get
            {
                return this.Container.GetControl<HtmlField>("Content", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the FirstButtonText property
        /// </summary>
        protected virtual Control FirstButtonText
        {
            get
            {
                return this.Container.GetControl<Control>("FirstButtonText", true);
            }
        }

        /// <summary>
        /// Gets the page selector control.
        /// </summary>
        /// <value>The page selector control.</value>
        protected internal virtual PagesSelector PageSelectorFirstButtonLandingPage
        {
            get
            {
                return this.Container.GetControl<PagesSelector>("pageSelectorFirstButtonLandingPage", true);
            }
        }

        /// <summary>
        /// Gets the selector tag.
        /// </summary>
        /// <value>The selector tag.</value>
        public HtmlGenericControl SelectorTagFirstButtonLandingPage
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("selectorTagFirstButtonLandingPage", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the SecondButtonText property
        /// </summary>
        protected virtual Control SecondButtonText
        {
            get
            {
                return this.Container.GetControl<Control>("SecondButtonText", true);
            }
        }

        /// <summary>
        /// Gets the page selector control.
        /// </summary>
        /// <value>The page selector control.</value>
        protected internal virtual PagesSelector PageSelectorSecondButtonLandingPage
        {
            get
            {
                return this.Container.GetControl<PagesSelector>("pageSelectorSecondButtonLandingPage", true);
            }
        }

        /// <summary>
        /// Gets the selector tag.
        /// </summary>
        /// <value>The selector tag.</value>
        public HtmlGenericControl SelectorTagSecondButtonLandingPage
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("selectorTagSecondButtonLandingPage", true);
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
                this.PageSelectorFirstButtonLandingPage.UICulture = uiCulture;
                this.PageSelectorSecondButtonLandingPage.UICulture = uiCulture;
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

            descriptor.AddElementProperty("title", this.Title.ClientID);
            descriptor.AddElementProperty("content", this.Content.ClientID);
            descriptor.AddElementProperty("firstButtonText", this.FirstButtonText.ClientID);
            descriptor.AddComponentProperty("pageSelectorFirstButtonLandingPage", this.PageSelectorFirstButtonLandingPage.ClientID);
            descriptor.AddElementProperty("selectorTagFirstButtonLandingPage", this.SelectorTagFirstButtonLandingPage.ClientID);
            descriptor.AddElementProperty("secondButtonText", this.SecondButtonText.ClientID);
            descriptor.AddComponentProperty("pageSelectorSecondButtonLandingPage", this.PageSelectorSecondButtonLandingPage.ClientID);
            descriptor.AddElementProperty("selectorTagSecondButtonLandingPage", this.SelectorTagSecondButtonLandingPage.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(WhyJoinWidgetDesigner.scriptReference));
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
        public static readonly string layoutTemplatePath = "~/CustomWidgets/WhyJoinWidget/Designer/WhyJoinWidgetDesigner.ascx";
        public const string scriptReference = "~/CustomWidgets/WhyJoinWidget/Designer/WhyJoinWidgetDesigner.js";
        #endregion
    }
}
 
