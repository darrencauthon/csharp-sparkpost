using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkPost
{
    public class MetricsResourceQuery
    {
        /// <summary>
        /// Only return results containing this string
        /// </summary>
        public string Match { get; set; }
        /// <summary>
        /// Maximum number of results to return
        /// </summary>
        public int? Limit { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        /// <summary>
        /// Standard timezone identification string, defaults to UTC
        /// </summary>
        public string Timezone { get; set; }
    }
}
