using System.Collections.Generic;

namespace SparkPost
{
    public class ListSuppressionResponse : Response
    {
        public IEnumerable<Suppression> Suppressions { get; set; }
    }
}