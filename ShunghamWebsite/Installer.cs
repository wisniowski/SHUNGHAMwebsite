using System;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Services;

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
        }

        private static void SystemManager_ApplicationStart(object sender, EventArgs e)
        {
            Res.RegisterResource<ShunghamResources>();
        }
    }
}