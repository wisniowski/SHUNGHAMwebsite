using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.CustomWidgets.ContactUsWidget.Designer
{
    public class ContactUsWidgetDesigner : ControlDesignerBase
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
                    return ContactUsWidgetDesigner.layoutTemplatePath;
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
        /// The LinkButton for selecting BackgroundImageId.
        /// </summary>
        /// <value>The page selector control.</value>
        protected internal virtual LinkButton SelectButtonBackgroundImageId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("selectButtonBackgroundImageId", false);
            }
        }

        /// <summary>
        /// The LinkButton for deselecting BackgroundImageId.
        /// </summary>
        /// <value>The page selector control.</value>
        protected internal virtual LinkButton DeselectButtonBackgroundImageId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("deselectButtonBackgroundImageId", false);
            }
        }

        /// <summary>
        /// Gets the RadEditor Manager dialog for inserting image, document or video for the BackgroundImageId property.
        /// </summary>
        /// <value>The RadEditor Manager dialog for inserting image, document or video.</value>
        protected EditorContentManagerDialog SelectorBackgroundImageId
        {
            get
            {
                return this.Container.GetControl<EditorContentManagerDialog>("selectorBackgroundImageId", false);
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

        /// <inheritdoc/>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptDescriptor> GetScriptDescriptors()
        {
            var scriptDescriptors = new List<ScriptDescriptor>(base.GetScriptDescriptors());
            var descriptor = (ScriptControlDescriptor)scriptDescriptors.Last();

            descriptor.AddElementProperty("selectButtonBackgroundImageId", this.SelectButtonBackgroundImageId.ClientID);
            descriptor.AddElementProperty("deselectButtonBackgroundImageId", this.DeselectButtonBackgroundImageId.ClientID);
            descriptor.AddComponentProperty("selectorBackgroundImageId", this.SelectorBackgroundImageId.ClientID);
            descriptor.AddProperty("imageServiceUrl", this.imageServiceUrl);

            return scriptDescriptors;
        }

        /// <inheritdoc/>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(ContactUsWidgetDesigner.scriptReference));
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

        public static readonly string layoutTemplatePath = "~/CustomWidgets/ContactUsWidget/Designer/ContactUsWidgetDesigner.ascx";
        public const string scriptReference = "~/CustomWidgets/ContactUsWidget/Designer/ContactUsWidgetDesigner.js";
        private string imageServiceUrl = VirtualPathUtility.ToAbsolute("~/Sitefinity/Services/Content/ImageService.svc/");

        #endregion
    }
}
