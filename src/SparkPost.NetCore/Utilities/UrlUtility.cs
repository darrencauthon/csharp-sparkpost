#if NET45
using System.Web;
#else
using System.Net;
#endif

namespace SparkPost.Utilities
{
    public static class UrlUtility
    {
        public static string UrlEncode(string value)
        {
#if NET45
            return HttpUtility.UrlEncode(value);
#else
            return WebUtility.UrlEncode(value);
#endif
        }
    }
}
