using System.Net;

namespace SparkPost
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public string Content { get; set; }

        protected void SetFrom(Response source)
        {
            this.ReasonPhrase = source.ReasonPhrase;
            this.StatusCode = source.StatusCode;
            this.Content = source.Content;
        }
    }
}