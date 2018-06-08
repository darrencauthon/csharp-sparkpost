using Newtonsoft.Json;

namespace SparkPost.WebHooks
{
    public class GenEvent
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

        [JsonProperty("error_code")]
        public string ErrorCode
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

        [JsonProperty("ip_pool")]
        public string IpPool
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

        [JsonProperty("rcpt_subs")]
        public dynamic RcptSubs
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

        [JsonProperty("raw_reason")]
        public string RawReason
        {
            get;
            set;
        }

        [JsonProperty("reason")]
        public string Reason
        {
            get;
            set;
        }

        [JsonProperty("routing_domain")]
        public string RoutingDomain
        {
            get;
            set;
        }

        [JsonProperty("sending_ip")]
        public string SendingIp
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

        [JsonProperty("subject")]
        public string Subject
        {
            get;
            set;
        }
    }
}