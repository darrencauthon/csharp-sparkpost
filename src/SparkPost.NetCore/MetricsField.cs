using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkPost
{
    public static class MetricsField
    {
        public const string Injected = "count_injected";
        public const string Targeted = "count_targeted";
        public const string Sent = "count_sent";
        public const string Accepted = "count_accepted";
        public const string Delivered = "count_delivered";
        public const string DeliveredFirst = "count_delivered_first";
        public const string DeliveredSubsequent = "count_delivered_subsequent";
        public const string DeliveryTimeFirst = "total_delivery_time_first";
        public const string DeliveryTimeSubsequent = "total_delivery_time_subsequent";
        public const string Rendered = "count_rendered";
        public const string UniqueRendered = "count_unique_rendered";
        public const string UniqueConfirmedOpened = "count_unique_confirmed_opened";
        public const string Clicked = "count_clicked";
        public const string UniqueClicked = "count_unique_clicked";
        public const string Bounce = "count_bounce";
        public const string HardBounce = "count_hard_bounce";
        public const string SoftBounce = "count_soft_bounce";
        public const string BlockBounce = "count_block_bounce";
        public const string AdminBounce = "count_admin_bounce";
        public const string UndeterminedBounce = "count_undetermined_bounce";
        public const string Rejected = "count_rejected";
        public const string PolicyRejection = "count_policy_rejection";
        public const string GenerationFailed = "count_generation_failed";
        public const string GenerationRejection = "count_generation_rejection";
        public const string InBandBounce = "count_inband_bounce";
        public const string OutOfBandBounce = "count_outofband_bounce";
        public const string Delayed = "count_delayed";
        public const string DelayedFirst = "count_delayed_first";
        public const string MessageVolume = "total_msg_volume";
        public const string SpamComplaint = "count_spam_complaint";

        public const string Domain = "domain";
        public const string SendingIp = "sending_ip";
        public const string IpPool = "ip_pool";
        public const string SendingDomain = "sending_domain";
        public const string Subaccount = "subaccount_id";
        public const string Campaign = "campaign_id";
        public const string Template = "template_id";
        public const string WatchedDomain = "watched_domain";
        public const string TimeSeries = "ts";
        public const string Reason = "reason";
        public const string BounceClassName = "bounce_class_name";
        public const string BounceClassDescription = "bounce_class_description";
        public const string BounceCategoryId = "bounce_category_id";
        public const string ClassificationId = "classification_id";
        public const string BounceCategoryName = "bounce_category_name";
        public const string RejectionCategoryId = "rejection_category_id";
        public const string RejectionType = "rejection_type";
        public const string LinkName = "link_name";
        public const string RawClicked = "count_raw_clicked";
        public const string Attempt = "attempt";

        /// <summary>
        /// A list of all metrics that are valid for GetDeliverabilityXyz() methods.
        /// </summary>
        public static IList<string> AllDeliverability
        {
            get
            {
                return new List<string>() {
                    Injected,
                    Bounce,
                    Rejected,
                    Delivered,
                    DeliveredFirst,
                    DeliveredSubsequent,
                    DeliveryTimeFirst,
                    DeliveryTimeSubsequent,
                    MessageVolume,
                    PolicyRejection,
                    GenerationRejection,
                    GenerationFailed,
                    InBandBounce,
                    OutOfBandBounce,
                    SoftBounce,
                    HardBounce,
                    BlockBounce,
                    AdminBounce,
                    UndeterminedBounce,
                    Delayed,
                    DelayedFirst,
                    Rendered,
                    UniqueRendered,
                    UniqueConfirmedOpened,
                    Clicked,
                    UniqueClicked,
                    Targeted,
                    Sent,
                    Accepted,
                    SpamComplaint,
                };
            }
        }

        /// <summary>
        /// A list of all metrics that are valid for GetBounceXyz() methods.
        /// </summary>
        public static IList<string> AllBounce
        {
            get
            {
                return new List<string>()
                {
                    Bounce,
                    InBandBounce,
                    OutOfBandBounce
                };
            }
        }

        /// <summary>
        /// A list of all metrics that are valid for GetEngagementDetails().
        /// </summary>
        public static IList<string> AllEngagement
        {
            get
            {
                return new List<string>()
                {
                    Clicked,
                    RawClicked
                };
            }
        }
    }    
}
