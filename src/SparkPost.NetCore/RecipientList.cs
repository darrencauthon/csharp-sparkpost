using System.Collections.Generic;

namespace SparkPost
{
    public class RecipientList
    {
        public RecipientList()
        {
            Recipients = new List<Recipient>();
            Attributes = new Attributes();
        }

        public List<Recipient> Recipients { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Attributes Attributes { get; set; }
    }
}