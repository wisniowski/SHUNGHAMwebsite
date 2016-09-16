using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;
using Telerik.Sitefinity.Web.UI.Fields;

namespace SitefinityWebApp.CustomWidgets.InfoWidget.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="SitefinityWebApp.CustomWidgets.InfoWidget.InfoWidget"/> widget
    /// </summary>
    public class InfoWidgetDesigner : ControlDesignerBase
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
                    return InfoWidgetDesigner.layoutTemplatePath;
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
        protected virtual Control Title
        {
            get
            {
                return this.Container.GetControl<Control>("Title", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the Summary property
        /// </summary>
        protected virtual Control Summary
        {
            get
            {
                return this.Container.GetControl<Control>("Summary", true);
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

        #endregion

        #region Methods
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            // Place your initialization logic here
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
            descriptor.AddElementProperty("summary", this.Summary.ClientID);
            descriptor.AddElementProperty("content", this.Content.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(InfoWidgetDesigner.scriptReference));
            return scripts;
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/CustomWidgets/InfoWidget/Designer/InfoWidgetDesigner.ascx";
        public const string scriptReference = "~/CustomWidgets/InfoWidget/Designer/InfoWidgetDesigner.js";
        #endregion
    }
}
 
