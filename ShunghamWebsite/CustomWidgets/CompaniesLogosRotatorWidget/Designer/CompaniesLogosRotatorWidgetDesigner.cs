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

namespace SitefinityWebApp.CustomWidgets.CompaniesLogosRotatorWidget.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="SitefinityWebApp.CustomWidgets.CompaniesLogosSlider.CompaniesLogosRotatorWidget"/> widget
    /// </summary>
    public class CompaniesLogosRotatorWidgetDesigner : ControlDesignerBase
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
                    return CompaniesLogosRotatorWidgetDesigner.layoutTemplatePath;
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
        /// The LinkButton for selecting AlbumId
        /// </summary>
        protected internal virtual LinkButton SelectButtonAlbumId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("selectButtonAlbumId", false);
            }
        }

        /// <summary>
        /// The LinkButton for deselecting AlbumId
        /// </summary>
        protected internal virtual LinkButton DeselectButtonAlbumId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("deselectButtonAlbumId", false);
            }
        }

        /// <summary>
        /// The Flat Selector for AlbumId
        /// </summary>
        protected internal virtual FolderSelector AlbumIdItemSelector
        {
            get
            {
                return this.Container.GetControl<FolderSelector>("AlbumIdItemSelector", false);
            }
        }

        /// <summary>
        /// The LinkButton for "Done"
        /// </summary>
        protected virtual LinkButton DoneButtonAlbumId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("lnkDoneAlbumId", true);
            }
        }

        /// <summary>
        /// The LinkButton for "Cancel"
        /// </summary>
        protected virtual LinkButton CancelButtonAlbumId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("lnkCancelAlbumId", true);
            }
        }

        /// <summary>
        /// The button area control
        /// </summary>
        protected virtual Control ButtonAreaAlbumId
        {
            get
            {
                return this.Container.GetControl<Control>("buttonAreaPanelAlbumId", false);
            }
        }

        #endregion

        #region Methods
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
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

            descriptor.AddElementProperty("selectButtonAlbumId", this.SelectButtonAlbumId.ClientID);
            descriptor.AddElementProperty("deselectButtonAlbumId", this.DeselectButtonAlbumId.ClientID);
            descriptor.AddComponentProperty("AlbumIdItemSelector", this.AlbumIdItemSelector.ClientID);
            descriptor.AddElementProperty("lnkDoneAlbumId", this.DoneButtonAlbumId.ClientID);
            descriptor.AddElementProperty("lnkCancelAlbumId", this.CancelButtonAlbumId.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(CompaniesLogosRotatorWidgetDesigner.scriptReference));
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
        public static readonly string layoutTemplatePath = "~/CustomWidgets/CompaniesLogosRotatorWidget/Designer/CompaniesLogosRotatorWidgetDesigner.ascx";
        public const string scriptReference = "~/CustomWidgets/CompaniesLogosRotatorWidget/Designer/CompaniesLogosRotatorWidgetDesigner.js";
        #endregion
    }
}
 
