using System;

namespace SitefinityWebApp.CustomWidgets.EUCalendar
{
    public class OrganiserName
    {
        public string __type { get; set; }
        public string AttributeLogicalName { get; set; }
        public string EntityLogicalName { get; set; }
        public string Value { get; set; }
    }

    public class Attributes
    {
        public string cdi_eventid { get; set; }
        public string cdi_name { get; set; }
        public OrganiserName organiserName { get; set; }
    }

    public class FormattedValues
    {
    }

    public class EventModel
    {
        public Attributes Attributes { get; set; }
        public FormattedValues FormattedValues { get; set; }
        public string Id { get; set; }
        public string LogicalName { get; set; }
    }
}