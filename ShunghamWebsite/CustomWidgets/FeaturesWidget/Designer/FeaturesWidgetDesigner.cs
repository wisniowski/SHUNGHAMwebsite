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

namespace SitefinityWebApp.CustomWidgets.FeaturesWidget.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="SitefinityWebApp.CustomWidgets.FeaturesWidget.FeaturesWidget"/> widget
    /// </summary>
    public class FeaturesWidgetDesigner : ControlDesignerBase
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
                    return FeaturesWidgetDesigner.layoutTemplatePath;
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
        /// The LinkButton for selecting ProductId
        /// </summary>
        protected internal virtual LinkButton SelectButtonProductId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("selectButtonProductId", false);
            }
        }

        /// <summary>
        /// The LinkButton for deselecting ProductId
        /// </summary>
        protected internal virtual LinkButton DeselectButtonProductId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("deselectButtonProductId", false);
            }
        }

        /// <summary>
        /// The Flat Selector for ProductId
        /// </summary>
        protected internal virtual FlatSelector ProductIdItemSelector
        {
            get
            {
                return this.Container.GetControl<FlatSelector>("ProductIdItemSelector", false);
            }
        }

        /// <summary>
        /// The LinkButton for "Done"
        /// </summary>
        protected virtual LinkButton DoneButtonProductId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("lnkDoneProductId", true);
            }
        }

        /// <summary>
        /// The LinkButton for "Cancel"
        /// </summary>
        protected virtual LinkButton CancelButtonProductId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("lnkCancelProductId", true);
            }
        }

        /// <summary>
        /// The button area control
        /// </summary>
        protected virtual Control ButtonAreaProductId
        {
            get
            {
                return this.Container.GetControl<Control>("buttonAreaPanelProductId", false);
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
                this.ProductIdItemSelector.UICulture = uiCulture;
                this.ProductIdItemSelector.ConstantFilter = "Visible=true";
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

            descriptor.AddElementProperty("selectButtonProductId", this.SelectButtonProductId.ClientID);
            descriptor.AddElementProperty("deselectButtonProductId", this.DeselectButtonProductId.ClientID);
            descriptor.AddComponentProperty("ProductIdItemSelector", this.ProductIdItemSelector.ClientID);
            descriptor.AddElementProperty("lnkDoneProductId", this.DoneButtonProductId.ClientID);
            descriptor.AddElementProperty("lnkCancelProductId", this.CancelButtonProductId.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(FeaturesWidgetDesigner.scriptReference));
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
        public static readonly string layoutTemplatePath = "~/CustomWidgets/FeaturesWidget/Designer/FeaturesWidgetDesigner.ascx";
        public const string scriptReference = "~/CustomWidgets/FeaturesWidget/Designer/FeaturesWidgetDesigner.js";
        #endregion
    }
}
 
