using System;

namespace SparkPost
{
    public class Options
    {
        public DateTimeOffset? StartTime { get; set; }
        public bool? OpenTracking { get; set; }
        public bool? ClickTracking { get; set; }
        public bool? Transactional { get; set; }
        public bool? Sandbox { get; set; }
        public bool? SkipSuppression { get; set; }
        public bool? InlineCss { get; set; }
        public string IpPool { get; set; }
    }
}