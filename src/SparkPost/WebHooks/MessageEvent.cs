using Newtonsoft.Json;

namespace SparkPost.WebHooks
{
    public class MessageEvent
    {
        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }

        [JsonProperty("bounce_class")]
        public string BounceClass
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

        [JsonProperty("device_token")]
        public string DeviceToken
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

        [JsonProperty("ip_address")]
        public string IpAddress
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

        [JsonProperty("message_id")]
        public string MessageId
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

        [JsonProperty("msg_size")]
        public string MsgSize
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

        [JsonProperty("sms_coding")]
        public string SmsCoding
        {
            get;
            set;
        }

        [JsonProperty("sms_dst")]
        public string SmsDst
        {
            get;
            set;
        }

        [JsonProperty("sms_dst_npi")]
        public string SmsDstNpi
        {
            get;
            set;
        }

        [JsonProperty("sms_dst_ton")]
        public string SmsDstTon
        {
            get;
            set;
        }

        [JsonProperty("sms_src")]
        public string SmsSrc
        {
            get;
            set;
        }

        [JsonProperty("sms_src_npi")]
        public string SmsSrcNpi
        {
            get;
            set;
        }

        [JsonProperty("sms_src_ton")]
        public string SmsSrcTon
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

        [JsonProperty("subject")]
        public string Subject
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

        [JsonProperty("queue_time")]
        public string QueueTime
        {
            get;
            set;
        }

        [JsonProperty("sms_remoteids")]
        public string[] SmsRemoteids
        {
            get;
            set;
        }

        [JsonProperty("sms_segments")]
        public int SmsSegments
        {
            get;
            set;
        }

        [JsonProperty("sms_text")]
        public string SmsText
        {
            get;
            set;
        }

        [JsonProperty("dr_latency")]
        public string DrLatency
        {
            get;
            set;
        }

        [JsonProperty("stat_type")]
        public string StatType
        {
            get;
            set;
        }

        [JsonProperty("stat_state")]
        public string StatState
        {
            get;
            set;
        }

        [JsonProperty("fbtype")]
        public string Fbtype
        {
            get;
            set;
        }

        [JsonProperty("report_by")]
        public string ReportBy
        {
            get;
            set;
        }

        [JsonProperty("report_to")]
        public string ReportTo
        {
            get;
            set;
        }

        [JsonProperty("user_str")]
        public string UserStr
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
    }
}