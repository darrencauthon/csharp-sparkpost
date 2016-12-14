using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SparkPost.RequestMethods
{
    public class Post : PutAndPostAreTheSame
    {
        public Post(HttpClient client) : base(client)
        {
        }

        public override Task<HttpResponseMessage> Execute(string url, StringContent stringContent)
        {
            return Client.PostAsync(url, stringContent);
        }
    }
}