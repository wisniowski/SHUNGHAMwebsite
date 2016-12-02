using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker
{
    public class UpdateId
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class DossierId
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

    public class PolicyCategoryName
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

    public class ShowOnSitefinity
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public bool Value { get; set; }
    }

    public class Fulltitle
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class ShortTitle
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class PublishDate
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public DateTime Value { get; set; }
    }

    public class DossierAttributes
    {
        public string uni_shunghamdossierid { get; set; }
        public Status status { get; set; }
        public DossierId dossierId { get; set; }
        public Fulltitle fulltitle { get; set; }
        public ShortTitle shortTitle { get; set; }
        public UpdateId updateId { get; set; }
        public PolicyCategoryName policyCategoryName { get; set; }
        public PublishDate publishDate { get; set; }
        public PolicyAreaName policyAreaName { get; set; }
        public ShowOnSitefinity showOnSitefinity { get; set; }
    }

    public class DossierFormattedValues
    {
        public string publishDate { get; set; }
        public string showOnSitefinity { get; set; }
    }

    public class EUDossierModel
    {
        public DossierAttributes Attributes { get; set; }
        public DossierFormattedValues FormattedValues { get; set; }
        public string Id { get; set; }
        public string LogicalName { get; set; }
    }
}