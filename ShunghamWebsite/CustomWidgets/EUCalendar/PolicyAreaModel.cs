using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.CustomWidgets.EUCalendar
{
    public class PAAttributes
    {
        public string uni_shunghampolicyareaid { get; set; }
        public string uni_name { get; set; }
        public DateTime createdon { get; set; }
        public string uni_policyareaid { get; set; }
    }

    public class PAFormattedValues
    {
        public string createdon { get; set; }
    }

    public class PolicyAreaModel
    {
        public PAAttributes Attributes { get; set; }
        public PAFormattedValues FormattedValues { get; set; }
        public string Id { get; set; }
        public string LogicalName { get; set; }
    }
}