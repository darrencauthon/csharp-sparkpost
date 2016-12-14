using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkPost
{
    public class MetricsQuery
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public IList<string> Domains { get; set; }
        public IList<string> Campaigns { get; set; }
        public IList<string> Templates { get; set; }
        public IList<string> SendingIps { get; set; }
        public IList<string> IpPools { get; set; }
        public IList<string> SendingDomains { get; set; }
        public IList<string> Subaccounts { get; set; }
        public IList<string> Metrics { get; set; }
        public string Timezone { get; set; }
        public string Precision { get; set; }

        public MetricsQuery()
        {
            Domains = new List<string>();
            Campaigns = new List<string>();
            Templates = new List<string>();
            SendingIps = new List<string>();
            IpPools = new List<string>();
            SendingDomains = new List<string>();
            Subaccounts = new List<string>();
            Metrics = new List<string>();
        }
    }
}
