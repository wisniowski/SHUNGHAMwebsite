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
                       Value = "Contains localizable resources for Shungham application.",
                       Description = "The description of this class.",
                       LastModified = "2016/09/02")]
        public string ShunghamResourcesDescription
        {
            get
            {
                return this["ShunghamResourcesDescription"];
            }
        }

        /// <summary>
        /// Gets the name of the shungham organization.
        /// </summary>
        [ResourceEntry("ShunghamCompanyName",
                       Value = "Shungham",
                       Description = "Name of the Shungham Organization.",
                       LastModified = "2016/09/12")]
        public string ShunghamCompanyName
        {
            get
            {
                return this["ShunghamCompanyName"];
            }
        }

        /// <summary>
        /// Gets all rights reserved text.
        /// </summary>
        [ResourceEntry("AllRightsReservedSign",
                       Value = "All Rights Reserved",
                       Description = "Name of the Shungham Organization.",
                       LastModified = "2016/09/12")]
        public string AllRightsReservedSign
        {
            get
            {
                return this["AllRightsReservedSign"];
            }
        }

        /// <summary>
        /// Gets the year.
        /// </summary>
        [ResourceEntry("Year",
                       Value = "2016",
                       Description = "The current Year.",
                       LastModified = "2016/09/12")]
        public string Year
        {
            get
            {
                return this["Year"];
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

        /// <summary>
        /// Gets the label for "Log in" landing page selector in designer.
        /// </summary>
        [ResourceEntry("LogInButtonLandingPageLabelInDesigner",
                       Value = "'Log In' Button Landing Page",
                       Description = "The label for 'Log In' Button Landing Page selector in designer.",
                       LastModified = "2016/09/12")]
        public string LogInButtonLandingPageLabelInDesigner
        {
            get
            {
                return this["LogInButtonLandingPageLabelInDesigner"];
            }
        }

        /// <summary>
        /// Gets the label for "Trial" button landing page selector in designer.
        /// </summary>
        [ResourceEntry("TrialButtonLandingPageLabelInDesigner",
                       Value = "'Free Trial' Button Landing Page",
                       Description = "The label for 'Trial' Button Landing Page selector in designer.",
                       LastModified = "2016/09/12")]
        public string TrialButtonLandingPageLabelInDesigner
        {
            get
            {
                return this["TrialButtonLandingPageLabelInDesigner"];
            }
        }
        #endregion

        #region Footer widget

        /// <summary>
        /// Gets the products title in footer.
        /// </summary>
        [ResourceEntry("ProductsTitleInFooter",
                       Value = "Our Products",
                       Description = "The Title for 'Products' section in footer.",
                       LastModified = "2016/09/12")]
        public string ProductsTitleInFooter
        {
            get
            {
                return this["ProductsTitleInFooter"];
            }
        }

        /// <summary>
        /// Gets the 'who we are' title in footer.
        /// </summary>
        [ResourceEntry("WhoWeAreTitleInFooter",
                       Value = "Who We Are",
                       Description = "The Title for 'Who we are' section in footer.",
                       LastModified = "2016/09/12")]
        public string WhoWeAreTitleInFooter
        {
            get
            {
                return this["WhoWeAreTitleInFooter"];
            }
        }

        /// <summary>
        /// Gets the LinkedIn Hyperlink text.
        /// </summary>
        [ResourceEntry("LinkedInTextInFooter",
                       Value = "LinkedIn",
                       Description = "The text on LinkedIn Hyperlink.",
                       LastModified = "2016/09/10")]
        public string LinkedInTextInFooter
        {
            get
            {
                return this["LinkedInTextInFooter"];
            }
        }

        /// <summary>
        /// Gets the Тwitter Hyperlink text.
        /// </summary>
        [ResourceEntry("TwitterTextInFooter",
                       Value = "Twitter",
                       Description = "The text on Twitter Hyperlink.",
                       LastModified = "2016/09/10")]
        public string TwitterTextInFooter
        {
            get
            {
                return this["TwitterTextInFooter"];
            }
        }

        /// <summary>
        /// Gets the Facebook Hyperlink text.
        /// </summary>
        [ResourceEntry("FacebookTextInFooter",
                       Value = "Facebook",
                       Description = "The text on Facebook Hyperlink.",
                       LastModified = "2016/09/10")]
        public string FacebookTextInFooter
        {
            get
            {
                return this["FacebookTextInFooter"];
            }
        }

        /// <summary>
        /// Gets the 'who we are' Pages Selector label in designer.
        /// </summary>
        [ResourceEntry("WhoWeAreLinksLabelInDesigner",
                       Value = "'Who We Are' Pages",
                       Description = "The label for 'Who We Are' Pages selector in the designer.",
                       LastModified = "2016/09/12")]
        public string WhoWeAreLinksLabelInDesigner
        {
            get
            {
                return this["WhoWeAreLinksLabelInDesigner"];
            }
        }

        /// <summary>
        /// Gets the 'LinkedIn' link label in designer.
        /// </summary>
        [ResourceEntry("LinkedInLinkLabelInDesigner",
                       Value = "'LinkedIn' Button Link",
                       Description = "The label for 'LinkedIn' link textbox in the designer.",
                       LastModified = "2016/09/12")]
        public string LinkedInLinkLabelInDesigner
        {
            get
            {
                return this["LinkedInLinkLabelInDesigner"];
            }
        }

        /// <summary>
        /// Gets the 'Twitter' link label in designer.
        /// </summary>
        [ResourceEntry("TwitterLinkLabelInDesigner",
                       Value = "'Twitter' Button Link",
                       Description = "The label for 'Twitter' link textbox in the designer.",
                       LastModified = "2016/09/12")]
        public string TwitterLinkLabelInDesigner
        {
            get
            {
                return this["TwitterLinkLabelInDesigner"];
            }
        }

        /// <summary>
        /// Gets the 'Facebook' link label in designer.
        /// </summary>
        [ResourceEntry("FacebookLinkLabelInDesigner",
                       Value = "'Facebook' Button Link",
                       Description = "The label for 'Facebook' link textbox in the designer.",
                       LastModified = "2016/09/12")]
        public string FacebookLinkLabelInDesigner
        {
            get
            {
                return this["FacebookLinkLabelInDesigner"];
            }
        }

        #endregion
    }
}