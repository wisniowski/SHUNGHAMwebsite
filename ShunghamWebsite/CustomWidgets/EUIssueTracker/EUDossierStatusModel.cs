using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker
{
    public class EUDossierAttributes
    {
        public int uni_statusid { get; set; }
        public string uni_displayname { get; set; }
        public string uni_shunghamdossierstatusid { get; set; }
    }

    public class EUDossierStatusesFormattedValues
    {
        public string uni_statusid { get; set; }
        public string uni_showonsitefinity { get; set; }
    }

    public class EUDossierStatusModel
    {
        public EUDossierAttributes Attributes { get; set; }
        public EUDossierStatusesFormattedValues FormattedValues { get; set; }
        public string Id { get; set; }
        public string LogicalName { get; set; }
    }
}