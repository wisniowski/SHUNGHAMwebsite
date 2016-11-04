using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.CustomWidgets.EUIssueTracker
{
    public class CustomNavGroup<TKey, TValue>
    {
        public TKey Key { get; set; }
        public IEnumerable<TValue> Values { get; set; }
    }
}