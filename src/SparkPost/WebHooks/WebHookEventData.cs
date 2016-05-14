using Newtonsoft.Json;

namespace SparkPost.WebHooks
{
    public class WebHookEventData
    {
        [JsonProperty("msys")]
        public Msys Msys { get; set; }
    }

    public class Msys
    {
        [JsonProperty("message_event")]
        public MessageEvent MessageEvent { get; set; }
        [JsonProperty("track_event")]
        public TrackEvent TrackEvent { get; set; }
        [JsonProperty("gen_event")]
        public GenEvent GenEvent { get; set; }
        [JsonProperty("unsubscribe_event")]
        public UnsubscribeEvent UnsubscribeEvent { get; set; }
        [JsonProperty("relay_event")]
        public RelayEvent RelayEvent { get; set; }
        [JsonProperty("relay_message")]
        public RelayMessage RelayMessage { get; set; }
    }

    public class MessageEvent
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("bounce_class")]
        public string BounceClass { get; set; }
        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("delv_method")]
        public string DelvMethod { get; set; }
        [JsonProperty("device_token")]
        public string DeviceToken { get; set; }
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
        [JsonProperty("event_id")]
        public string EventId { get; set; }
        [JsonProperty("friendly_from")]
        public string FriendlyFrom { get; set; }
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
        [JsonProperty("ip_pool")]
        public string IpPool { get; set; }
        [JsonProperty("message_id")]
        public string MessageId { get; set; }
        [JsonProperty("msg_from")]
        public string MsgFrom { get; set; }
        [JsonProperty("msg_size")]
        public string MsgSize { get; set; }
        [JsonProperty("num_retries")]
        public string NumRetries { get; set; }
        [JsonProperty("rcpt_meta")]
        public dynamic RcptMeta { get; set; }
        [JsonProperty("rcpt_tags")]
        public string[] RcptTags { get; set; }
        [JsonProperty("rcpt_to")]
        public string RcptTo { get; set; }
        [JsonProperty("raw_rcpt_to")]
        public string RawRcptTo { get; set; }
        [JsonProperty("rcpt_type")]
        public string RcptType { get; set; }
        [JsonProperty("raw_reason")]
        public string RawReason { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("routing_domain")]
        public string RoutingDomain { get; set; }
        [JsonProperty("sending_ip")]
        public string SendingIp { get; set; }
        [JsonProperty("sms_coding")]
        public string SmsCoding { get; set; }
        [JsonProperty("sms_dst")]
        public string SmsDst { get; set; }
        [JsonProperty("sms_dst_npi")]
        public string SmsDstNpi { get; set; }
        [JsonProperty("sms_dst_ton")]
        public string SmsDstTon { get; set; }
        [JsonProperty("sms_src")]
        public string SmsSrc { get; set; }
        [JsonProperty("sms_src_npi")]
        public string SmsSrcNpi { get; set; }
        [JsonProperty("sms_src_ton")]
        public string SmsSrcTon { get; set; }
        [JsonProperty("subaccount_id")]
        public string SubaccountId { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }
        [JsonProperty("template_version")]
        public string TemplateVersion { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("transmission_id")]
        public string TransmissionId { get; set; }
        [JsonProperty("queue_time")]
        public string QueueTime { get; set; }
        [JsonProperty("sms_remoteids")]
        public string[] SmsRemoteids { get; set; }
        [JsonProperty("sms_segments")]
        public int SmsSegments { get; set; }
        [JsonProperty("sms_text")]
        public string SmsText { get; set; }
        [JsonProperty("dr_latency")]
        public string DrLatency { get; set; }
        [JsonProperty("stat_type")]
        public string StatType { get; set; }
        [JsonProperty("stat_state")]
        public string StatState { get; set; }
        [JsonProperty("fbtype")]
        public string Fbtype { get; set; }
        [JsonProperty("report_by")]
        public string ReportBy { get; set; }
        [JsonProperty("report_to")]
        public string ReportTo { get; set; }
        [JsonProperty("user_str")]
        public string UserStr { get; set; }
        [JsonProperty("remote_addr")]
        public string RemoteAddr { get; set; }
    }
    
    public class TrackEvent
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("delv_method")]
        public string DelvMethod { get; set; }
        [JsonProperty("event_id")]
        public string EventId { get; set; }
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
        [JsonProperty("message_id")]
        public string MessageId { get; set; }
        [JsonProperty("rcpt_meta")]
        public dynamic RcptMeta { get; set; }
        [JsonProperty("rcpt_tags")]
        public string[] RcptTags { get; set; }
        [JsonProperty("rcpt_to")]
        public string RcptTo { get; set; }
        [JsonProperty("raw_rcpt_to")]
        public string RawRcptTo { get; set; }
        [JsonProperty("rcpt_type")]
        public string RcptType { get; set; }
        [JsonProperty("subaccount_id")]
        public string SubaccountId { get; set; }
        [JsonProperty("target_link_name")]
        public string TargetLinkName { get; set; }
        [JsonProperty("target_link_url")]
        public string TargetLinkUrl { get; set; }
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }
        [JsonProperty("template_version")]
        public string TemplateVersion { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("transmission_id")]
        public string TransmissionId { get; set; }
        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }
        [JsonProperty("geo_ip")]
        public GeoIp GeoIp { get; set; }
    }
    
    public class GeoIp
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("latitude")]
        public float Latitude { get; set; }
        [JsonProperty("longitude")]
        public float Longitude { get; set; }
    }

    public class GenEvent
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
        [JsonProperty("event_id")]
        public string EventId { get; set; }
        [JsonProperty("friendly_from")]
        public string FriendlyFrom { get; set; }
        [JsonProperty("ip_pool")]
        public string IpPool { get; set; }
        [JsonProperty("rcpt_meta")]
        public dynamic RcptMeta { get; set; }
        [JsonProperty("rcpt_subs")]
        public dynamic RcptSubs { get; set; }
        [JsonProperty("rcpt_tags")]
        public string[] RcptTags { get; set; }
        [JsonProperty("rcpt_to")]
        public string RcptTo { get; set; }
        [JsonProperty("raw_rcpt_to")]
        public string RawRcptTo { get; set; }
        [JsonProperty("raw_reason")]
        public string RawReason { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("routing_domain")]
        public string RoutingDomain { get; set; }
        [JsonProperty("sending_ip")]
        public string SendingIp { get; set; }
        [JsonProperty("subaccount_id")]
        public string SubaccountId { get; set; }
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }
        [JsonProperty("template_version")]
        public string TemplateVersion { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("transmission_id")]
        public string TransmissionId { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
    }
    
    public class UnsubscribeEvent
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("event_id")]
        public string EventId { get; set; }
        [JsonProperty("friendly_from")]
        public string FriendlyFrom { get; set; }
        [JsonProperty("mailfrom")]
        public string Mailfrom { get; set; }
        [JsonProperty("message_id")]
        public string MessageId { get; set; }
        [JsonProperty("rcpt_meta")]
        public dynamic RcptMeta { get; set; }
        [JsonProperty("rcpt_tags")]
        public string[] RcptTags { get; set; }
        [JsonProperty("rcpt_to")]
        public string RcptTo { get; set; }
        [JsonProperty("raw_rcpt_to")]
        public string RawRcptTo { get; set; }
        [JsonProperty("rcpt_type")]
        public string RcptType { get; set; }
        [JsonProperty("subaccount_id")]
        public string SubaccountId { get; set; }
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }
        [JsonProperty("template_version")]
        public string TemplateVersion { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("transmission_id")]
        public string TransmissionId { get; set; }
        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }
    }
    
    public class RelayEvent
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("event_id")]
        public string EventId { get; set; }
        [JsonProperty("rcpt_to")]
        public string RcptTo { get; set; }
        [JsonProperty("raw_rcpt_to")]
        public string RawRcptTo { get; set; }
        [JsonProperty("msg_size")]
        public string MsgSize { get; set; }
        [JsonProperty("routing_domain")]
        public string RoutingDomain { get; set; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("sending_ip")]
        public string SendingIp { get; set; }
        [JsonProperty("subaccount_id")]
        public string SubaccountId { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("ip_pool")]
        public string IpPool { get; set; }
        [JsonProperty("msg_from")]
        public string MsgFrom { get; set; }
        [JsonProperty("relay_id")]
        public string RelayId { get; set; }
        [JsonProperty("raw_reason")]
        public string RawReason { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
        [JsonProperty("remote_addr")]
        public string RemoteAddr { get; set; }
        [JsonProperty("queue_time")]
        public string QueueTime { get; set; }
        [JsonProperty("num_retries")]
        public string NumRetries { get; set; }
        [JsonProperty("delv_method")]
        public string DelvMethod { get; set; }
    }

    public class RelayMessage
    {
        [JsonProperty("rcpt_to")]
        public string RcptTo { get; set; }
        [JsonProperty("friendly_from")]
        public string FriendlyFrom { get; set; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("content")]
        public Content Content { get; set; }
        [JsonProperty("msg_from")]
        public string MsgFrom { get; set; }
        [JsonProperty("webhook_id")]
        public string WebhookId { get; set; }
    }

    public class Content
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("html")]
        public string Html { get; set; }
        [JsonProperty("headers")]
        public dynamic Headers { get; set; }
        [JsonProperty("email_rfc822")]
        public string EmailRfc822 { get; set; }
        [JsonProperty("email_rfc822_is_base64")]
        public bool EmailRfc822IsBase64 { get; set; }
        [JsonProperty("to")]
        public string[] To { get; set; }
    }

}
