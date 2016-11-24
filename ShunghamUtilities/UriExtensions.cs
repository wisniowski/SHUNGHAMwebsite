using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShunghamUtilities
{
    public static class UriExtensions
    {
        /// <summary>
        ///     Adds query string value to an existing url, both absolute and relative URI's are supported.
        /// </summary>
        /// <example>
        /// <code>
        ///     // returns "www.domain.com/test?param1=val1&amp;param2=val2&amp;param3=val3"
        ///     new Uri("www.domain.com/test?param1=val1").ExtendQuery(new Dictionary&lt;string, string&gt; { { "param2", "val2" }, { "param3", "val3" } }); 
        /// 
        ///     // returns "/test?param1=val1&amp;param2=val2&amp;param3=val3"
        ///     new Uri("/test?param1=val1").ExtendQuery(new Dictionary&lt;string, string&gt; { { "param2", "val2" }, { "param3", "val3" } }); 
        /// </code>
        /// </example>
        /// <param name="uri"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Uri ExtendQuery(this Uri uri, IDictionary<string, string> values)
        {
            var baseUrl = uri.ToString();
            var queryString = string.Empty;
            if (baseUrl.Contains("?"))
            {
                var urlSplit = baseUrl.Split('?');
                baseUrl = urlSplit[0];
                queryString = urlSplit.Length > 1 ? urlSplit[1] : string.Empty;
            }

            NameValueCollection queryCollection = HttpUtility.ParseQueryString(queryString);
            foreach (var kvp in values ?? new Dictionary<string, string>())
            {
                queryCollection[kvp.Key] = kvp.Value;
            }
            var uriKind = uri.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative;
            return queryCollection.Count == 0
              ? new Uri(baseUrl, uriKind)
              : new Uri(string.Format("{0}?{1}", baseUrl, queryCollection), uriKind);
        }

        /// <summary>
        /// Constructs query string by name value collection.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static string ConstructQueryString(NameValueCollection parameters)
        {
            var sb = new StringBuilder();

            foreach (String name in parameters)
                sb.Append(String.Concat(name, "=", System.Web.HttpUtility.UrlEncode(parameters[name]), "&"));

            if (sb.Length > 0)
                return sb.ToString(0, sb.Length - 1);

            return String.Empty;
        } 
    }
}
