using System;
using System.Linq;
using pavliks.PortalConnector;
using SitefinityWebApp.CustomWidgets.EUCalendar;
using SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget;
using SitefinityWebApp.CustomWidgets.EUIssueTracker.Breadcrumb;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI;

namespace SitefinityWebApp
{
    /// <summary>
    /// Public class for registering custom components in Sitefinity.
    /// </summary>
    public class Installer
    {
        /// <summary>
        /// Method that is called by ASP.NET before application start to install the custom controls on the site
        /// </summary>
        public static void PreApplicationStart()
        {
            SystemManager.ApplicationStart += SystemManager_ApplicationStart;
            Bootstrapper.Initialized += PortalInitialization.SitefinityBootstrapper_Initialized;
        }

        private static void SystemManager_ApplicationStart(object sender, EventArgs e)
        {
            Res.RegisterResource<ShunghamResources>();

            RegisterSectionInBackend(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName);
            RegisterSectionInBackend(Installer.pageControlsToolboxName, Installer.EUCalendarControlsSectionName);
            RegisterSectionInBackend(Installer.pageControlsToolboxName, Installer.EUIssueTrackerControlsSectionName);
            RegisterSectionInBackend(Installer.pageLayoutsToolboxName, Installer.ShunghamLayoutsName);

            //Register widgets
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
               "~/CustomWidgets/HeaderWidget/HeaderWidget.ascx", "Header Widget");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
               "~/CustomWidgets/FooterWidget/FooterWidget.ascx", "Footer Widget");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
               "~/CustomWidgets/BannerWidget/BannerWidget.ascx", "Banner Widget");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
               "~/CustomWidgets/TestimonialsRotatorWidget/TestimonialsRotatorWidget.ascx", "Testimonials Rotator Widget");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
               "~/CustomWidgets/CompaniesLogosRotatorWidget/CompaniesLogosRotatorWidget.ascx", "Companies Logos Rotator Widget");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
               "~/CustomWidgets/InfoWidget/InfoWidget.ascx", "Info Widget");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
               "~/CustomWidgets/OurProductsWidget/OurProductsWidget.ascx", "Our Products Widget");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
               "~/CustomWidgets/ContactUsWidget/ContactUsWidget.ascx", "Contact Us Form");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
              "~/CustomWidgets/FreeTrialWidget/FreeTrialWidget.ascx", "Free Trial Form");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
              "~/CustomWidgets/JobApplicationWidget/JobApplicationWidget.ascx", "Job Application Form");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
               "~/CustomWidgets/OurTeamWidget/OurTeamWidget.ascx", "Our Team Widget");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
               "~/CustomWidgets/ButtonWidget/ButtonWidget.ascx", "Button Widget");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
               "~/CustomWidgets/JobOpeningsWidget/JobOpeningsWidget.ascx", "Job Openings Widget");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.ShunghamControlsSectionName,
               "~/CustomWidgets/FeaturesWidget/FeaturesWidget.ascx", "Features Widget");

            //Register EUCalendar widgets
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.EUCalendarControlsSectionName, 
                typeof(EUCalendarWidget).AssemblyQualifiedName, "EUCalendar Widget");

            //Register EUIssueTracker widgets
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.EUIssueTrackerControlsSectionName,
              "~/CustomWidgets/EUIssueTracker/NavigationWidget/NavigationWidget.ascx", "Navigation Widget");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.EUIssueTrackerControlsSectionName,
               typeof(CustomBreadcrumb).AssemblyQualifiedName, "Custom Breadcrumb Widget");
            RegisterControlInToolbox(Installer.pageControlsToolboxName, Installer.EUIssueTrackerControlsSectionName,
              "~/CustomWidgets/EUIssueTracker/EUDossierGridWidget/EUDossierGridWidget.ascx", "Dossier Grid Widget");

            //Register Layout controls
            RegisterControlInToolbox(Installer.pageLayoutsToolboxName, Installer.ShunghamLayoutsName,
                Installer.layoutControlTypeName, "OneColumnGreyBGR", "~/CustomLayouts/OneColumnGreyBGR.ascx");
            RegisterControlInToolbox(Installer.pageLayoutsToolboxName, Installer.ShunghamLayoutsName,
                Installer.layoutControlTypeName, "InfoWidget_ThreeColumns", "~/CustomLayouts/InfoWidget_ThreeColumns.ascx");
            RegisterControlInToolbox(Installer.pageLayoutsToolboxName, Installer.ShunghamLayoutsName,
                Installer.layoutControlTypeName, "InfoWidget_TwoColumns", "~/CustomLayouts/InfoWidget_TwoColumns.ascx");
        }

        private static void RegisterSectionInBackend(string toolboxName, string sectionName)
        {
            var configManager = ConfigManager.GetManager();
            var config = configManager.GetSection<ToolboxesConfig>();

            var controls = config.Toolboxes[toolboxName];

            var section = controls.Sections.Where<ToolboxSection>(e => e.Name == sectionName).FirstOrDefault();

            if (section == null)
            {
                configManager.Provider.SuppressSecurityChecks = true;
                section = new ToolboxSection(controls.Sections)
                {
                    Name = sectionName,
                    Title = sectionName,
                    Description = sectionName,
                    ResourceClassId = string.Empty
                };
                controls.Sections.Add(section);
                configManager.SaveSection(config);

                configManager.Provider.SuppressSecurityChecks = false;
            }
        }

        private static void RegisterControlInToolbox(string toolboxName, string sectionName, string controlType, string controlName)
        {
            RegisterControlInToolbox(toolboxName, sectionName, controlType, controlName, string.Empty);
        }

        private static void RegisterControlInToolbox(string toolboxName, string sectionName, string controlType, string controlName, string layoutTemplate)
        {
            var configManager = ConfigManager.GetManager();
            configManager.Provider.SuppressSecurityChecks = true;
            var config = configManager.GetSection<ToolboxesConfig>();

            var controls = config.Toolboxes[toolboxName];
            var section = controls.Sections.Where<ToolboxSection>(e => e.Name == sectionName).FirstOrDefault();

            if (section != null && !section.Tools.Any<ToolboxItem>(e => e.Name == controlName))
            {
                var tool = new ToolboxItem(section.Tools)
                {
                    Name = controlName,
                    Title = controlName,
                    Description = controlName,
                    ControlType = controlType,
                };

                if (!string.IsNullOrEmpty(layoutTemplate))
                {
                    tool.LayoutTemplate = layoutTemplate;
                }
                section.Tools.Add(tool);

                configManager.SaveSection(config);
            }

            configManager.Provider.SuppressSecurityChecks = false;
        }

        #region Private fields and constants

        private const string pageControlsToolboxName = "PageControls";
        private const string pageLayoutsToolboxName = "PageLayouts";
        private const string ShunghamLayoutsName = "ShunghamLayouts";
        private const string ShunghamControlsSectionName = "ShunghamControls";
        private const string EUCalendarControlsSectionName = "EUCalendarControls";
        private const string EUIssueTrackerControlsSectionName = "EUIssueTrackerControls";

        private static readonly string layoutControlTypeName = typeof(LayoutControl).AssemblyQualifiedName;

        #endregion
    }
}