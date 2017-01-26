#if NETSTANDARD1_6
using System.Net;
#else
using System.Web;
#endif

namespace SparkPost.Utilities
{
    public static class UrlUtility
    {
        public static string UrlEncode(string value)
        {
#if NETSTANDARD1_6
            return WebUtility.UrlEncode(value);
#else
            return HttpUtility.UrlEncode(value);
#endif
        }
    }
}
