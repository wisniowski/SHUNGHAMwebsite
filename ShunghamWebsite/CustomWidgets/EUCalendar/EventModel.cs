using System;
using System.Collections.Generic;

namespace SitefinityWebApp.CustomWidgets.EUCalendar
{
    public class OrganiserName
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class NewEuclocation
    {
        public string __type { get; set; }
        public string Id { get; set; }
        public List<object> KeyAttributes { get; set; }
        public string LogicalName { get; set; }
        public string Name { get; set; }
        public object RowVersion { get; set; }
    }

    public class PolicyAreaID
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class PolicyAreaName
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class Attributes
    {
        public string new_eucstarttime { get; set; }
        public DateTime new_eucenddate { get; set; }
        public OrganiserName organiserName { get; set; }
        public string cdi_name { get; set; }
        public string new_euceventlink { get; set; }
        public string cdi_eventid { get; set; }
        public string new_eucendtime { get; set; }
        public string new_euceventdescription { get; set; }
        public DateTime new_eucstartdate { get; set; }
        public NewEuclocation new_euclocation { get; set; }
        public PolicyAreaID policyAreaID { get; set; }
        public PolicyAreaName policyAreaName { get; set; }
        public DateTime new_eucregistrationdeadline { get; set; }
        public string new_euceventprice { get; set; }
    }

    public class FormattedValues
    {
        public string new_eucenddate { get; set; }
        public string new_eucstartdate { get; set; }
        public string new_eucregistrationdeadline { get; set; }
    }

    public class EventModel
    {
        public Attributes Attributes { get; set; }
        public FormattedValues FormattedValues { get; set; }
        public string Id { get; set; }
        public string LogicalName { get; set; }
    }
}