using System;
using System.Collections.Generic;

namespace SparkPost
{
    public class RetrieveTemplatesResponse : Response
    {
        public RetrieveTemplatesResponse()
        {
            Templates = new List<TemplateListItem>();
        }

        public List<TemplateListItem> Templates { get; set; }
    }
}