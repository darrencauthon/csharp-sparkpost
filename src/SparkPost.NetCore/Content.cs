using System.Collections.Generic;

namespace SparkPost
{
    public class Content
    {
        public Content()
        {
            From = new Address();
            Headers = new Dictionary<string, string>();
            Attachments = new List<Attachment>();
            InlineImages = new List<InlineImage>();
        }

        public string Html { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
        public Address From { get; set; }
        public string ReplyTo { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public IList<Attachment> Attachments { get; set; }
        public IList<InlineImage> InlineImages { get; set; }
        public string TemplateId { get; set; }
        public bool? UseDraftTemplate { get; set; }
    }
}