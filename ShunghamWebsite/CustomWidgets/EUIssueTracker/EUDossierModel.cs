using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker
{
    public class DossierID
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class DossierPolicyAreaName
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class Status
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class PolicyCategoryName
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class DossierAttributes
    {
        public string uni_shorttitle { get; set; }
        public DateTime createdon { get; set; }
        public string uni_shunghamdossierupdateid { get; set; }
        public DossierID DossierID { get; set; }
        public DossierPolicyAreaName PolicyAreaName { get; set; }
        public PolicyCategoryName PolicyCategoryName { get; set; }
        public Status Status { get; set; }
    }

    public class DossierFormattedValues
    {
        public string createdon { get; set; }
    }

    public class EUDossierModel
    {
        public DossierAttributes Attributes { get; set; }
        public DossierFormattedValues FormattedValues { get; set; }
        public string Id { get; set; }
        public string LogicalName { get; set; }
    }
}