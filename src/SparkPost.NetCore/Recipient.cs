using System.Collections.Generic;

namespace SparkPost
{
    public class Recipient
    {
        public Recipient()
        {
            Address = new Address();
            Tags = new List<string>();
            Metadata = new Dictionary<string, object>();
            SubstitutionData = new Dictionary<string, object>();
        }

        public Address Address { get; set; }
        public string ReturnPath { get; set; }
        public IList<string> Tags { get; set; }
        public IDictionary<string, object> Metadata { get; set; }
        public IDictionary<string, object> SubstitutionData { get; set; }

        public RecipientType Type { get; set; }
    }
}