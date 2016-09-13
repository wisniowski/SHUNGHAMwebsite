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

namespace SitefinityWebApp.CustomWidgets.BannerWidget.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="SitefinityWebApp.CustomWidgets.BannerWidget.BannerWidget"/> widget
    /// </summary>
    public class BannerWidgetDesigner : ControlDesignerBase
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
                    return BannerWidgetDesigner.layoutTemplatePath;
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
        /// Gets the control that is bound to the SubTitle property
        /// </summary>
        protected virtual Control SubTitle
        {
            get
            {
                return this.Container.GetControl<Control>("SubTitle", true);
            }
        }

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

        /// <summary>
        /// Gets the control that is bound to the FirstBtnText property
        /// </summary>
        protected virtual Control FirstBtnText
        {
            get
            {
                return this.Container.GetControl<Control>("FirstBtnText", true);
            }
        }

        /// <summary>
        /// Gets the page selector control.
        /// </summary>
        /// <value>The page selector control.</value>
        protected internal virtual PagesSelector PageSelectorFirstBtnLandingPage
        {
            get
            {
                return this.Container.GetControl<PagesSelector>("pageSelectorFirstBtnLandingPage", true);
            }
        }

        /// <summary>
        /// Gets the selector tag.
        /// </summary>
        /// <value>The selector tag.</value>
        public HtmlGenericControl SelectorTagFirstBtnLandingPage
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("selectorTagFirstBtnLandingPage", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the SecondBtnText property
        /// </summary>
        protected virtual Control SecondBtnText
        {
            get
            {
                return this.Container.GetControl<Control>("SecondBtnText", true);
            }
        }

        /// <summary>
        /// Gets the page selector control.
        /// </summary>
        /// <value>The page selector control.</value>
        protected internal virtual PagesSelector PageSelectorSecondBtnLandingPage
        {
            get
            {
                return this.Container.GetControl<PagesSelector>("pageSelectorSecondBtnLandingPage", true);
            }
        }

        /// <summary>
        /// Gets the selector tag.
        /// </summary>
        /// <value>The selector tag.</value>
        public HtmlGenericControl SelectorTagSecondBtnLandingPage
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("selectorTagSecondBtnLandingPage", true);
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
                this.PageSelectorFirstBtnLandingPage.UICulture = uiCulture;
                this.PageSelectorSecondBtnLandingPage.UICulture = uiCulture;
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
            descriptor.AddElementProperty("subTitle", this.SubTitle.ClientID);
            descriptor.AddElementProperty("selectButtonBackgroundImageId", this.SelectButtonBackgroundImageId.ClientID);
            descriptor.AddElementProperty("deselectButtonBackgroundImageId", this.DeselectButtonBackgroundImageId.ClientID);
            descriptor.AddComponentProperty("selectorBackgroundImageId", this.SelectorBackgroundImageId.ClientID);
            descriptor.AddElementProperty("firstBtnText", this.FirstBtnText.ClientID);
            descriptor.AddComponentProperty("pageSelectorFirstBtnLandingPage", this.PageSelectorFirstBtnLandingPage.ClientID);
            descriptor.AddElementProperty("selectorTagFirstBtnLandingPage", this.SelectorTagFirstBtnLandingPage.ClientID);
            descriptor.AddElementProperty("secondBtnText", this.SecondBtnText.ClientID);
            descriptor.AddComponentProperty("pageSelectorSecondBtnLandingPage", this.PageSelectorSecondBtnLandingPage.ClientID);
            descriptor.AddElementProperty("selectorTagSecondBtnLandingPage", this.SelectorTagSecondBtnLandingPage.ClientID);
            descriptor.AddProperty("imageServiceUrl", this.imageServiceUrl);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(BannerWidgetDesigner.scriptReference));
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
        public static readonly string layoutTemplatePath = "~/CustomWidgets/BannerWidget/Designer/BannerWidgetDesigner.ascx";
        public const string scriptReference = "~/CustomWidgets/BannerWidget/Designer/BannerWidgetDesigner.js";
        private string imageServiceUrl = VirtualPathUtility.ToAbsolute("~/Sitefinity/Services/Content/ImageService.svc/");
        #endregion
    }
}
 
