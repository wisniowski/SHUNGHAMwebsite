using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitefinityWebApp.CustomWidgets.EUCalendar;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker
{
    public static class MemoryCacheItem
    {
        public static IList<EUDossierModel> dossiers;
        public static IList<EventModel> events;
    }
}