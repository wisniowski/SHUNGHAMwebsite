using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker
{
    public class PolicyAreaName
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class PolicyAreaID
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class Attributes
    {
        public string uni_shunghamdossiercategoryid { get; set; }
        public string uni_name { get; set; }
        public PolicyAreaName policyAreaName { get; set; }
        public PolicyAreaID policyAreaID { get; set; }
    }

    public class FormattedValues
    {
    }

    public class EUIPolicyAreaModel
    {
        public Attributes Attributes { get; set; }
        public FormattedValues FormattedValues { get; set; }
        public string Id { get; set; }
        public string LogicalName { get; set; }
    }
}