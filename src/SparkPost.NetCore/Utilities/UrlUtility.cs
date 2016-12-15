#if FRAMEWORK
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
#if FRAMEWORK
            return HttpUtility.UrlEncode(value);
#else
            return WebUtility.UrlEncode(value);
#endif
        }
    }
}
