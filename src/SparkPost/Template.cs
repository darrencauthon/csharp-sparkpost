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

    public class TemplateBase : TemplateInfo
    {
        public string Id { get; set; }
    }

    public class TemplateInfo
    {
        public string Name { get; set; }
        public bool Published { get; set; }
        public string Description { get; set; }
    }

    public class TemplateUpdate : TemplateInfo
    {
        public TemplateUpdate()
        {
            Content = new TemplateContent();
            Options = new TemplateOptions();
        }

        public TemplateContent Content { get; set; }
        public TemplateOptions Options { get; set; }
    }
}
