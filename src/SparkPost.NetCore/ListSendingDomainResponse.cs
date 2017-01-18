using System.Collections.Generic;
using SparkPost.Utilities;

namespace SparkPost
{
    public class ListSendingDomainResponse : Response
    {
        public IEnumerable<SendingDomain> SendingDomains { get; set; }

        public static ListSendingDomainResponse CreateFromResponse(Response response)
        {
            var result = new ListSendingDomainResponse();
            LeftRight.SetValuesToMatch(result, response);

            var results = Jsonification.DeserializeObject<dynamic>(response.Content).results;
            result.SendingDomains = BuildTheSendingDomains(results);
            return result;
        }

        private static IEnumerable<SendingDomain> BuildTheSendingDomains(dynamic results)
        {
            var sendingDomains = new List<SendingDomain>();
            foreach (var r in results)
                sendingDomains.Add(SendingDomain.ConvertToSendingDomain(r));
            return sendingDomains;
        }
    }
}