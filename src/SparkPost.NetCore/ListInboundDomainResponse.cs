using System.Collections.Generic;
using SparkPost.Utilities;

namespace SparkPost
{
    public class ListInboundDomainResponse : Response
    {
        public IEnumerable<InboundDomain> InboundDomains { get; set; }

        public static ListInboundDomainResponse CreateFromResponse(Response response)
        {
            var thisResponse = new ListInboundDomainResponse();

            LeftRight.SetValuesToMatch(thisResponse, response);

            thisResponse.InboundDomains = BuildTheInboundDomainsFrom(response);

            return thisResponse;
        }

        private static IEnumerable<InboundDomain> BuildTheInboundDomainsFrom(Response response)
        {
            dynamic results = Jsonification.DeserializeObject<dynamic>(response.Content).results;

            var inboundDomains = new List<InboundDomain>();
            foreach (var r in results)
                inboundDomains.Add(ConvertToAInboundDomain(r));

            return inboundDomains;
        }

        internal static InboundDomain ConvertToAInboundDomain(dynamic item)
        {
            return new InboundDomain
            {
                Domain = item.domain
            };
        }
    }
}