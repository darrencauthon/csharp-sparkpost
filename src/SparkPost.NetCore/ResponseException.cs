using System;

namespace SparkPost
{
    public class ResponseException : Exception
    {
        public ResponseException(Response response) :
            base(string.Format("Response: {0} {1}. Content: {2}.", ((int)response.StatusCode).ToString(), response.ReasonPhrase, response.Content))
        {
            this.Response = response;
        }

        public Response Response { get; private set; }
    }
}