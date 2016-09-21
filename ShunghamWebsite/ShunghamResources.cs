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

        #region Info widget

        /// <summary>
        /// Gets the Info widget title label in designer.
        /// </summary>
        [ResourceEntry("InfoWidgetTitleLabelInDesigner",
                       Value = "Title",
                       Description = "The label for 'Title' textbox in the InfoWidget designer.",
                       LastModified = "2016/09/15")]
        public string InfoWidgetTitleLabelInDesigner
        {
            get
            {
                return this["InfoWidgetTitleLabelInDesigner"];
            }
        }

        /// <summary>
        /// Gets the Info widget summary label in designer.
        /// </summary>
        [ResourceEntry("InfoWidgetSummaryLabelInDesigner",
                       Value = "Summary",
                       Description = "The label for 'Summary' textbox in the InfoWidget designer.",
                       LastModified = "2016/09/15")]
        public string InfoWidgetSummaryLabelInDesigner
        {
            get
            {
                return this["InfoWidgetSummaryLabelInDesigner"];
            }
        }

        /// <summary>
        /// Gets the Info widget content label in designer.
        /// </summary>
        [ResourceEntry("InfoWidgetContentLabelInDesigner",
                       Value = "Content",
                       Description = "The label for 'Content' textbox in the InfoWidget designer.",
                       LastModified = "2016/09/15")]
        public string InfoWidgetContentLabelInDesigner
        {
            get
            {
                return this["InfoWidgetContentLabelInDesigner"];
            }
        }

        #endregion

        #region Our Products widget

        /// <summary>
        /// Gets the policy coverage button text.
        /// </summary>
        [ResourceEntry("PolicyCoverageButtonText",
                       Value = "See Policy Coverage",
                       Description = "The text on 'Policy Coverage' button in 'Our Products' widget.",
                       LastModified = "2016/09/18")]
        public string PolicyCoverageButtonText
        {
            get
            {
                return this["PolicyCoverageButtonText"];
            }
        }

        /// <summary>
        /// Gets the read more button text.
        /// </summary>
        [ResourceEntry("ReadMoreButtonText",
                       Value = "Read More",
                       Description = "The text on 'Read More' button in 'Our Products' widget.",
                       LastModified = "2016/09/18")]
        public string ReadMoreButtonText
        {
            get
            {
                return this["ReadMoreButtonText"];
            }
        }


        #endregion

        #region Contact us widget

        /// <summary>
        /// Gets the contact us title
        /// </summary>
        [ResourceEntry("ContactTitle",
                       Value = "Contact <span>us</span>",
                       Description = "The contact title",
                       LastModified = "2016/09/19")]
        public string ContactTitle
        {
            get
            {
                return this["ContactTitle"];
            }
        }

        /// <summary>
        /// Gets the street address.
        /// </summary>
        [ResourceEntry("StreetAddress",
                       Value = "25 Rue Archimède",
                       Description = "The street address.",
                       LastModified = "2016/09/19")]
        public string StreetAddress
        {
            get
            {
                return this["StreetAddress"];
            }
        }

        /// <summary>
        /// Gets the postal code.
        /// </summary>
        [ResourceEntry("PostalCode",
                       Value = "1000",
                       Description = "The postal code.",
                       LastModified = "2016/09/19")]
        public string PostalCode
        {
            get
            {
                return this["PostalCode"];
            }
        }

        /// <summary>
        /// Gets the locality.
        /// </summary>
        [ResourceEntry("Locality",
                       Value = "Brussels",
                       Description = "The locality.",
                       LastModified = "2016/09/19")]
        public string Locality
        {
            get
            {
                return this["Locality"];
            }
        }

        /// <summary>
        /// Gets the country name.
        /// </summary>
        [ResourceEntry("CountryName",
                       Value = "Belgium",
                       Description = "The country name.",
                       LastModified = "2016/09/19")]
        public string CountryName
        {
            get
            {
                return this["CountryName"];
            }
        }

        /// <summary>
        /// Gets the contact phone number.
        /// </summary>
        [ResourceEntry("ContactPhone",
                       Value = "<a href='tel:+32489105317'>+32 489 105 317</a>",
                       Description = "The contact phone number.",
                       LastModified = "2016/09/19")]
        public string ContactPhone
        {
            get
            {
                return this["ContactPhone"];
            }
        }

        /// <summary>
        /// Gets the contact email.
        /// </summary>
        [ResourceEntry("ContactEmail",
                       Value = "<a class='email' href='mailto:info@shungham.com'>info@shungham.com</a>",
                       Description = "The contact email.",
                       LastModified = "2016/09/19")]
        public string ContactEmail
        {
            get
            {
                return this["ContactEmail"];
            }
        }

        /// <summary>
        /// The message that appears after successful submit.
        /// </summary>
        [ResourceEntry("SuccessfulSubmitMessage",
                       Value = "Thank you, we'll get in touch soon.",
                       Description = "The message that appears after successful submit.",
                       LastModified = "2016/09/19")]
        public string SuccessfulSubmitMessage
        {
            get
            {
                return this["SuccessfulSubmitMessage"];
            }
        }

        /// <summary>
        /// Send us a message.
        /// </summary>
        [ResourceEntry("SendUsMessage",
                       Value = "Send us a message",
                       Description = "Send us a message.",
                       LastModified = "2016/09/19")]
        public string SendUsMessage
        {
            get
            {
                return this["SendUsMessage"];
            }
        }

        /// <summary>
        /// Shungham Information sprl.
        /// </summary>
        [ResourceEntry("InfoLabel",
                       Value = "Shungham Information sprl",
                       Description = "Shungham Information sprl.",
                       LastModified = "2016/09/21")]
        public string InfoLabel
        {
            get
            {
                return this["InfoLabel"];
            }
        }

        #endregion

        #region Free trial widget

        /// <summary>
        /// Gets the free trial title
        /// </summary>
        [ResourceEntry("FreeTrialTitle",
                       Value = "<span>Get a </span>free trial",
                       Description = "The free trial title",
                       LastModified = "2016/09/20")]
        public string FreeTrialTitle
        {
            get
            {
                return this["FreeTrialTitle"];
            }
        }

        #endregion

        #region Job application widget

        /// <summary>
        /// Gets the free trial title
        /// </summary>
        [ResourceEntry("JobApplicationTitle",
                       Value = "<span>Apply for a</span> job",
                       Description = "Apply for a job",
                       LastModified = "2016/09/21")]
        public string JobApplicationTitle
        {
            get
            {
                return this["JobApplicationTitle"];
            }
        }

        #endregion

        #region Job Openings widget

        /// <summary>
        /// Gets the job openings widget title.
        /// </summary>
        [ResourceEntry("JobOpeningsWidgetTitle",
                       Value = "Current job <span>openings</span>",
                       Description = "JobOpeningsWidget Title",
                       LastModified = "2016/09/21")]
        public string JobOpeningsWidgetTitle
        {
            get
            {
                return this["JobOpeningsWidgetTitle"];
            }
        }

        /// <summary>
        /// Gets the job basis text.
        /// </summary>
        [ResourceEntry("JobBasisText",
                       Value = "Basis:",
                       Description = "Explanatory text displayed in front of the job basis.",
                       LastModified = "2016/09/21")]
        public string JobBasisText
        {
            get
            {
                return this["JobBasisText"];
            }
        }

        /// <summary>
        /// Gets the job added date text.
        /// </summary>
        [ResourceEntry("JobAddedText",
                       Value = "Added:",
                       Description = "Explanatory text displayed in front of the job Added date.",
                       LastModified = "2016/09/21")]
        public string JobAddedText
        {
            get
            {
                return this["JobAddedText"];
            }
        }

        /// <summary>
        /// Gets the job key skills text.
        /// </summary>
        [ResourceEntry("JobKeySkillsText",
                       Value = "Key Skills",
                       Description = "Job Key skills text.",
                       LastModified = "2016/09/21")]
        public string JobKeySkillsText
        {
            get
            {
                return this["JobKeySkillsText"];
            }
        }

        /// <summary>
        /// Gets the job responsibilities text.
        /// </summary>
        [ResourceEntry("JobResponsibilitiesText",
                       Value = "Responsibilities",
                       Description = "Job Responsibilities text.",
                       LastModified = "2016/09/21")]
        public string JobResponsibilitiesText
        {
            get
            {
                return this["JobResponsibilitiesText"];
            }
        }

        /// <summary>
        /// Gets the apply now button text.
        /// </summary>
        [ResourceEntry("ApplyNowButtonText",
                       Value = "Apply Now",
                       Description = "The text on Apply Now button.",
                       LastModified = "2016/09/21")]
        public string ApplyNowButtonText
        {
            get
            {
                return this["ApplyNowButtonText"];
            }
        }
        #endregion

        #region Features widget

        /// <summary>
        /// Gets the features widget title.
        /// </summary>
        [ResourceEntry("FeaturesWidgetTitle",
                       Value = "Features",
                       Description = "FeaturesWidget Title",
                       LastModified = "2016/09/21")]
        public string FeaturesWidgetTitle
        {
            get
            {
                return this["FeaturesWidgetTitle"];
            }
        }

        /// <summary>
        /// Gets the features read more text.
        /// </summary>
        [ResourceEntry("FeaturesReadMoreText",
                       Value = "Read More",
                       Description = "Text on 'Read More' buttons in 'Features' widget.",
                       LastModified = "2016/09/21")]
        public string FeaturesReadMoreText
        {
            get
            {
                return this["FeaturesReadMoreText"];
            }
        }
        #endregion
    }
}