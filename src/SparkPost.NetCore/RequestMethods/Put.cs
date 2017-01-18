using System.Net.Http;
using System.Threading.Tasks;

namespace SparkPost.RequestMethods
{
    public class Put : PutAndPostAreTheSame
    {
        public Put(HttpClient client) : base(client)
        {
        }

        public override Task<HttpResponseMessage> Execute(string url, StringContent stringContent)
        {
            return Client.PutAsync(url, stringContent);
        }
    }
}