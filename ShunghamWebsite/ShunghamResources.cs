using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace SitefinityWebApp
{
    [ObjectInfo(typeof(ShunghamResources), Title = "ShunghamResourcesTitle", Description = "ShunghamResourcesDescription")]
    public class ShunghamResources : Resource
    {
        public ShunghamResources()
        {
        }

        public ShunghamResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }

        /// <summary>
        /// Gets the Shungham resources title.
        /// </summary>
        /// <value>
        /// The Shungham resources title.
        /// </value>
        [ResourceEntry("ShunghamResourcesTitle",
                       Value = "Shungham resources",
                       Description = "The title of this class.",
                       LastModified = "2016/09/02")]
        public string ShunghamResourcesTitle
        {
            get
            {
                return this["ShunghamResourcesTitle"];
            }
        }
        /// <summary>
        /// Gets the Shungham resources description.
        /// </summary>
        /// <value>
        /// The Shungham resources description.
        /// </value>
        [ResourceEntry("ShunghamResourcesDescription",
                       Value = "Contains localisable resources for Shungham application.",
                       Description = "The description of this class.",
                       LastModified = "2016/09/02")]
        public string ShunghamResourcesDescription
        {
            get
            {
                return this["ShunghamResourcesDescription"];
            }
        }

        #region Header widget                
        /// <summary>
        /// Text on Get Free Trial Button.
        /// </summary>
        [ResourceEntry("GetTrialButton",
                       Value = "Free Trial",
                       Description = "The text on Get Trial Button.",
                       LastModified = "2016/09/09")]
        public string GetTrialButton
        {
            get
            {
                return this["GetTrialButton"];
            }
        }

        /// <summary>
        /// Text of "Log In" link.
        /// </summary>
        [ResourceEntry("LogInLinkText",
                       Value = "Log In",
                       Description = "The text on Log In link.",
                       LastModified = "2016/09/09")]
        public string LogInLinkText
        {
            get
            {
                return this["LogInLinkText"];
            }
        }
        #endregion
    }
}