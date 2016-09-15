using System;
using System.Collections.Generic;
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

            IQueryable<PageNode> pagesPublished = pageManager.GetPageNodes()
                .Where(pt => pt.Parent.Title == frontendPagesParentName && pt.ShowInNavigation == shownInNavigation);

            return pagesPublished;
        }

        /// <summary>
        /// Gets the page nodes by ids.
        /// </summary>
        /// <param name="pageNodeIds">The page node ids.</param>
        /// <returns></returns>
        public static IList<PageNode> GetPageNodesByIds(Guid[] pageNodeIds)
        {
            PageManager pageManager = PageManager.GetManager();
            IList<PageNode> pageNodes = new List<PageNode>();

            foreach (var pageNodeId in pageNodeIds)
            {
                PageNode node = pageManager.GetPageNode(pageNodeId);
                pageNodes.Add(node);
            }

            return pageNodes;
        }

        /// <summary>
        /// Gets the page URL by page ID.
        /// </summary>
        /// <param name="pageNodeId">The page node identifier.</param>
        /// <returns></returns>
        public static string GetPageUrlById(Guid pageNodeId)
        {
            PageManager pageManager = PageManager.GetManager();

            string url = pageManager.GetPageNode(pageNodeId).GetUrl();

            return url;
        }

        /// <summary>
        /// Gets the page by title or by text that is contained in the Page Title.
        /// </summary>
        /// <param name="title">The title or contained text.</param>
        /// <returns></returns>
        public static PageNode GetPageNodeByTitle(string title)
        {
            PageManager pageManager = PageManager.GetManager();

            PageNode page = pageManager.GetPageNodes()
                .Where(pt => pt.Parent.Title == frontendPagesParentName && pt.Title.ToString().ToLower().Contains(title.ToLower())).FirstOrDefault();

            return page;
        }

        #region Private fields and constants

        private const string frontendPagesParentName = "Pages";

        #endregion
    }
}
