using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.Designer
{
    public class EUCalendarWidgetDesigner : ControlDesignerBase
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
                    return EUCalendarWidgetDesigner.layoutTemplatePath;
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
        /// Gets the control that is bound to the BackButtonDefaultDestination property
        /// </summary>
        protected virtual Control BackButtonDefaultDestination
        {
            get
            {
                return this.Container.GetControl<Control>("BackButtonDefaultDestination", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the IsDetailsMode property
        /// </summary>
        protected virtual Control IsDetailsMode
        {
            get
            {
                return this.Container.GetControl<Control>("IsDetailsMode", true);
            }
        }

        #endregion

        #region Methods

        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            if (this.PropertyEditor != null)
            {
                var uiCulture = this.PropertyEditor.PropertyValuesCulture;
                this.PageSelectorDetailsPageId.UICulture = uiCulture;
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

            descriptor.AddComponentProperty("pageSelectorDetailsPageId", this.PageSelectorDetailsPageId.ClientID);
            descriptor.AddElementProperty("selectorTagDetailsPageId", this.SelectorTagDetailsPageId.ClientID);
            descriptor.AddElementProperty("backButtonDefaultDestination", this.BackButtonDefaultDestination.ClientID);
            descriptor.AddElementProperty("isDetailsMode", this.IsDetailsMode.ClientID);

            return scriptDescriptors;
        }

        /// <inheritdoc />
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(EUCalendarWidgetDesigner.scriptReference));
            return scripts;
        }

        /// <inheritdoc />
        protected override ScriptRef GetRequiredCoreScripts()
        {
            return ScriptRef.JQuery | ScriptRef.JQueryUI;
        }
        #endregion

        #region Private members & constants

        public static readonly string layoutTemplatePath = "~/CustomWidgets/EUCalendar/EUCalendarWidget/Designer/EUCalendarWidgetDesigner.ascx";
        public const string scriptReference = "~/CustomWidgets/EUCalendar/EUCalendarWidget/Designer/EUCalendarWidgetDesigner.js";
        
        #endregion
    }
}