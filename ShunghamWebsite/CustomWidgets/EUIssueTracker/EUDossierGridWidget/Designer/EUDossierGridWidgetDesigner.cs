using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget.Designer
{
    public class EUDossierGridWidgetDesigner : ControlDesignerBase
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
                {
                    return EUDossierGridWidgetDesigner.layoutTemplatePath;
                }
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
        protected internal virtual PagesSelector PageSelectorDetailsPageId
        {
            get
            {
                return this.Container.GetControl<PagesSelector>("pageSelectorDetailsPageId", true);
            }
        }

        /// <summary>
        /// Gets the selector tag.
        /// </summary>
        /// <value>The selector tag.</value>
        public HtmlGenericControl SelectorTagDetailsPageId
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("selectorTagDetailsPageId", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the DaysToDisplayUpdatesWithin property
        /// </summary>
        protected virtual Control DaysToDisplayUpdatesWithin
        {
            get
            {
                return this.Container.GetControl<Control>("DaysToDisplayUpdatesWithin", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the DisplayOtherUpdates property
        /// </summary>
        protected virtual Control DisplayOtherUpdates
        {
            get
            {
                return this.Container.GetControl<Control>("DisplayOtherUpdates", true);
            }
        }

        #endregion

        #region Methods

        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            //initialization logic goes here
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

            descriptor.AddElementProperty("daysToDisplayUpdatesWithin", this.DaysToDisplayUpdatesWithin.ClientID);
            descriptor.AddElementProperty("displayOtherUpdates", this.DisplayOtherUpdates.ClientID);
            descriptor.AddComponentProperty("pageSelectorDetailsPageId", this.PageSelectorDetailsPageId.ClientID);
            descriptor.AddElementProperty("selectorTagDetailsPageId", this.SelectorTagDetailsPageId.ClientID);

            return scriptDescriptors;
        }

        /// <inheritdoc />
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(EUDossierGridWidgetDesigner.scriptReference));
            return scripts;
        }

        /// <inheritdoc />
        protected override ScriptRef GetRequiredCoreScripts()
        {
            return ScriptRef.JQuery | ScriptRef.JQueryUI;
        }
        #endregion

        #region Private members & constants

        public static readonly string layoutTemplatePath = "~/CustomWidgets/EUIssueTracker/EUDossierGridWidget/Designer/EUDossierGridWidgetDesigner.ascx";
        public const string scriptReference = "~/CustomWidgets/EUIssueTracker/EUDossierGridWidget/Designer/EUDossierGridWidgetDesigner.js";

        #endregion
    }
}