using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkPost
{
    public class GetMetricsResourceResponse: Response
    {
        public IList<string> Results { get; set; }

        public GetMetricsResourceResponse()
        {
            Results = new List<string>();
        }        

        public GetMetricsResourceResponse(Response source)
        {
            this.SetFrom(source);
        }
    }
}
