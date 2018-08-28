using System;
using System.Collections.Generic;

namespace SparkPost
{
    public class Template : TemplateBase
    {
        public Template()
        {
            Content = new TemplateContent();
            Options = new TemplateOptions();
        }

        public TemplateContent Content { get; set; }
        public TemplateOptions Options { get; set; }

    }

    public class TemplateListItem : TemplateBase
    {
        public DateTime LastUpdateTime { get; set; }
    }

    public class TemplateBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
    }
}
