using System.Collections.Generic;

namespace SparkPost
{
    public class Template
    {
        public Template()
        {
            //Content = new TemplateContent();
            Content = new TemplateContent();
            Options = new TemplateOptions();
        }

        public string Id { get; set; }
        //public TemplateContent Content { get; set; }
        public TemplateContent Content { get; set; }
        public bool Published { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TemplateOptions Options { get; set; }

    }
}
