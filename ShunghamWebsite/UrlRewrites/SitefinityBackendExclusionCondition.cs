using System.Web;
using Intelligencia.UrlRewriter;

namespace SitefinityWebApp.UrlRewrites
{
    public class SitefinityBackendExclusionCondition : IRewriteCondition
    {
        /// <summary>
        /// Determines whether we are not on a back-end URL
        /// </summary>
        /// <param name="context">The current rewriter context.</param>
        /// <returns>True, if we are not on a back-end URL, False otherwise.</returns>
        public bool IsMatch(RewriteContext context)
        {
            string relativePath = HttpContext
                                    .Current
                                    .Request
                                    .AppRelativeCurrentExecutionFilePath
                                    .ToLower();
            return !relativePath.StartsWith("~/sitefinity/");
        }
    }
}