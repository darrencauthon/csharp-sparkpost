using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
#if !NETSTANDARD1_6
using System.Web;
#endif
using SparkPost.Utilities;

namespace SparkPost.RequestMethods
{
    public class Get : RequestMethod
    {
        private readonly HttpClient client;
        private readonly IDataMapper dataMapper;

        public Get(HttpClient client, IDataMapper dataMapper)
        {
            this.client = client;
            this.dataMapper = dataMapper;
        }

        public override Task<HttpResponseMessage> Execute(Request request)
        {
            return client.GetAsync(string.Join("?",
                new[] { request.Url, ConvertToQueryString(request.Data) }
                    .Where(x => string.IsNullOrEmpty(x) == false)));
        }

        private string ConvertToQueryString(object data)
        {
            if (data == null) return null;
            var original = dataMapper.CatchAll(data);

            var dictionary = new Dictionary<string, string>();
            foreach (var thing in original.Where(x => string.IsNullOrEmpty(x.Value.ToString()) == false))
                dictionary[thing.Key] = thing.Value.ToString();
#if NETSTANDARD1_6
            var values = dictionary
                .Select(x => System.Net.WebUtility.UrlEncode(SnakeCase.Convert(x.Key)) + "=" + System.Net.WebUtility.UrlEncode(x.Value));
#else
            var values = dictionary
                .Select(x => HttpUtility.UrlEncode(SnakeCase.Convert(x.Key)) + "=" + HttpUtility.UrlEncode(x.Value));
#endif

            return string.Join("&", values);
        }
    }
}