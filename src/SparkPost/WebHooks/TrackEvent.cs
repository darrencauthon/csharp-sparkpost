using Newtonsoft.Json;

namespace SparkPost.WebHooks
{
    public class TrackEvent
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

        [JsonProperty("delv_method")]
        public string DelvMethod
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

        [JsonProperty("ip_address")]
        public string IpAddress
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

        [JsonProperty("target_link_name")]
        public string TargetLinkName
        {
            get;
            set;
        }

        [JsonProperty("target_link_url")]
        public string TargetLinkUrl
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

        [JsonProperty("geo_ip")]
        public GeoIp GeoIp
        {
            get;
            set;
        }
    }
}