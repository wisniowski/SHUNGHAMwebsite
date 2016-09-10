using System.Linq;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Pages.Model;

namespace ShunghamUtilities
{
    public class PagesUtilities
    {
        /// <summary>
        /// Gets the top level pages.
        /// </summary>
        /// <param name="shownInNavigation">if set to <c>true</c> gets the pages which have "Show in Navigation" check-box checked.</param>
        /// <returns></returns>
        public static IQueryable<PageNode> GetTopLevelPages(bool shownInNavigation)
        {
            PageManager pageManager = PageManager.GetManager();

            using (new ElevatedModeRegion(pageManager))
            {
                var pageDataList = pageManager.GetPageDataList();

                IQueryable<PageNode> pagesPublished = pageManager.GetPageNodes()
                    .Where(pt => pt.Parent.Title == frontendPagesParentName && pt.ShowInNavigation == shownInNavigation);

                return pagesPublished;
            }
        }

        #region Private fields and constants

        private const string frontendPagesParentName = "Pages";

        #endregion
    }
}
