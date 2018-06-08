using Newtonsoft.Json;

namespace SparkPost.WebHooks
{
    public class UnsubscribeEvent
    {
        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }

        [JsonProperty("campaign_id")]
        public string CampaignId
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

        [JsonProperty("event_id")]
        public string EventId
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

        [JsonProperty("mailfrom")]
        public string Mailfrom
        {
            get;
            set;
        }

        [JsonProperty("message_id")]
        public string MessageId
        {
            get;
            set;
        }

        [JsonProperty("rcpt_meta")]
        public dynamic RcptMeta
        {
            get;
            set;
        }

        [JsonProperty("rcpt_tags")]
        public string[] RcptTags
        {
            get;
            set;
        }

        [JsonProperty("rcpt_to")]
        public string RcptTo
        {
            get;
            set;
        }

        [JsonProperty("raw_rcpt_to")]
        public string RawRcptTo
        {
            get;
            set;
        }

        [JsonProperty("rcpt_type")]
        public string RcptType
        {
            get;
            set;
        }

        [JsonProperty("subaccount_id")]
        public string SubaccountId
        {
            get;
            set;
        }

        [JsonProperty("template_id")]
        public string TemplateId
        {
            get;
            set;
        }

        [JsonProperty("template_version")]
        public string TemplateVersion
        {
            get;
            set;
        }

        [JsonProperty("timestamp")]
        public string Timestamp
        {
            get;
            set;
        }

        [JsonProperty("transmission_id")]
        public string TransmissionId
        {
            get;
            set;
        }

        [JsonProperty("user_agent")]
        public string UserAgent
        {
            get;
            set;
        }
    }
}