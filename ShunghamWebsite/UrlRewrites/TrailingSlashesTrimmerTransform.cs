using Intelligencia.UrlRewriter;

namespace SitefinityWebApp.UrlRewrites
{
    /// <summary>
    /// This custom transformer trims slashes (and whitespace) from the end of the captured URL
    /// </summary>
    public class TrailingSlashesTrimmerTransform : IRewriteTransform
    {
        /// <summary>
        /// Applies the transformation on the given input and returns the trimmed URL.
        /// </summary>
        /// <param name="input">The input url.</param>
        /// <returns>The trimmed url.</returns>
        public string ApplyTransform(string input)
        {
            return input.TrimEnd('/', ' ');
        }

        public string Name
        {
            get { return "trailingSlashesTrimmerTransform"; }
        }
    }
}