using Newtonsoft.Json;

namespace SparkPost.WebHooks
{
    public class Content
    {
        [JsonProperty("text")]
        public string Text
        {
            get;
            set;
        }

        [JsonProperty("subject")]
        public string Subject
        {
            get;
            set;
        }

        [JsonProperty("html")]
        public string Html
        {
            get;
            set;
        }

        [JsonProperty("headers")]
        public dynamic Headers
        {
            get;
            set;
        }

        [JsonProperty("email_rfc822")]
        public string EmailRfc822
        {
            get;
            set;
        }

        [JsonProperty("email_rfc822_is_base64")]
        public bool EmailRfc822IsBase64
        {
            get;
            set;
        }

        [JsonProperty("to")]
        public string[] To
        {
            get;
            set;
        }
    }
}