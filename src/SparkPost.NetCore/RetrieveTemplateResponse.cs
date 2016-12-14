using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkPost
{
    public class RetrieveTemplateResponse : Response
    {
        public RetrieveTemplateResponse()
        {
            Options = new TemplateOptions();
            TemplateContent = new TemplateContent();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public DateTime? LastUse { get; set; }
        public TemplateOptions Options { get; set; }
        public TemplateContent TemplateContent { get; set; }
    }
}
