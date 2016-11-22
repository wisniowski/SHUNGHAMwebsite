using System.Xml;
using Intelligencia.UrlRewriter;

namespace SitefinityWebApp.UrlRewrites
{
    /// <summary>
    /// This class parses whether rewriter.config fires a condition "<if isSitefinityBackend="false">...</if>"
    /// </summary>
    public class SitefinityBackendExclusionConditionParser : IRewriteConditionParser
    {
        /// <summary>
        /// Parses the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public IRewriteCondition Parse(System.Xml.XmlNode node)
        {
            XmlNode existsAttr = node.Attributes.GetNamedItem("isSitefinityBackend");
            if ((existsAttr != null) && existsAttr.Value == "false")
            {
                return new SitefinityBackendExclusionCondition();
            }

            return null;
        }
    }
}