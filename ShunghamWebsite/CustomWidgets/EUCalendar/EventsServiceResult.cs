using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.CustomWidgets.EUCalendar
{
    public class EventsServiceResult
    {
        public List<EventModel> Data { get; set; }
        public string Status { get; set; }
    }
}