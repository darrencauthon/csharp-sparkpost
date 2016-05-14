using Newtonsoft.Json;

namespace SparkPost.WebHooks
{
    public class RelayMessage
    {
        [JsonProperty("rcpt_to")]
        public string RcptTo
        {
            get;
            set;
        }

        [JsonProperty("friendly_from")]
        public string FriendlyFrom
        {
            get;
            set;
        }

        [JsonProperty("customer_id")]
        public string CustomerId
        {
            get;
            set;
        }

        [JsonProperty("content")]
        public Content Content
        {
            get;
            set;
        }

        [JsonProperty("msg_from")]
        public string MsgFrom
        {
            get;
            set;
        }

        [JsonProperty("webhook_id")]
        public string WebhookId
        {
            get;
            set;
        }
    }
}