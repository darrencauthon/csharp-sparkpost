using Newtonsoft.Json;

namespace SparkPost.WebHooks
{
    public class RelayEvent
    {
        [JsonProperty("type")]
        public string Type
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

        [JsonProperty("msg_size")]
        public string MsgSize
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

        [JsonProperty("customer_id")]
        public string CustomerId
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

        [JsonProperty("timestamp")]
        public string Timestamp
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

        [JsonProperty("msg_from")]
        public string MsgFrom
        {
            get;
            set;
        }

        [JsonProperty("relay_id")]
        public string RelayId
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

        [JsonProperty("error_code")]
        public string ErrorCode
        {
            get;
            set;
        }

        [JsonProperty("remote_addr")]
        public string RemoteAddr
        {
            get;
            set;
        }

        [JsonProperty("queue_time")]
        public string QueueTime
        {
            get;
            set;
        }

        [JsonProperty("num_retries")]
        public string NumRetries
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
    }
}