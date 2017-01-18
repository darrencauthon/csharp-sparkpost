using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SparkPost.Utilities;

namespace SparkPost.RequestMethods
{
    public abstract class PutAndPostAreTheSame : RequestMethod
    {
        protected readonly HttpClient Client;

        protected PutAndPostAreTheSame(HttpClient client)
        {
            Client = client;
        }

        public override Task<HttpResponseMessage> Execute(Request request)
        {
            return Execute(request.Url, ContentFrom(request));
        }

        public abstract Task<HttpResponseMessage> Execute(string url, StringContent stringContent);

        private static StringContent ContentFrom(Request request)
        {
            return new StringContent(SerializeObject(request.Data), Encoding.UTF8, "application/json");
        }

        private static string SerializeObject(object data)
        {
            return Jsonification.SerializeObject(data);
        }
    }
}