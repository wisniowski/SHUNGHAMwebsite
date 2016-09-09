using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Pages.Model;

namespace ShunghamUtilities
{
    public class PagesUtilities
    {
        public static IQueryable<PageNode> GetTopLevelPages(bool shownInNavigation)
        {
            PageManager pageManager = PageManager.GetManager();

            using (new ElevatedModeRegion(pageManager))
            {
                var pageDataList = pageManager.GetPageDataList();

                IQueryable<PageNode> pagesPublished = pageManager.GetPageNodes()
                    .Where(pt => pt.Parent.Title == "Pages" && pt.ShowInNavigation == shownInNavigation);

                return pagesPublished;
            }
        }
    }
}
