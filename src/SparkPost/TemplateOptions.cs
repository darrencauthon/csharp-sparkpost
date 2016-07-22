using System;

namespace SparkPost
{
    public class TemplateOptions
    {
        public bool? OpenTracking { get; set; }
        public bool? ClickTracking { get; set; }
        public bool? Transactional { get; set; }
        public bool? Sandbox { get; set; }
    }
}
