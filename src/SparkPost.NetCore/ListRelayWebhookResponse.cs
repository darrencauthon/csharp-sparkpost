using System.Collections.Generic;
using SparkPost.Utilities;

namespace SparkPost
{
    public class ListRelayWebhookResponse : Response
    {
        public IEnumerable<RelayWebhook> RelayWebhooks { get; set; }

        public static ListRelayWebhookResponse CreateFromResponse(Response response)
        {
            var result = new ListRelayWebhookResponse();

            LeftRight.SetValuesToMatch(result, response);

            result.RelayWebhooks = BuildTheRelayWebhooksFrom(response);

            return result;
        }

        private static IEnumerable<RelayWebhook> BuildTheRelayWebhooksFrom(Response response)
        {
            var results = Jsonification.DeserializeObject<dynamic>(response.Content).results;

            var relayWebhooks = new List<RelayWebhook>();
            foreach (var r in results)
                relayWebhooks.Add(ConvertToARelayWebhook(r));

            return relayWebhooks;
        }

        internal static RelayWebhook ConvertToARelayWebhook(dynamic item)
        {
            return new RelayWebhook
            {
                Id = item.id,
                Name = item.name,
                Target = item.target,
                AuthToken = item.auth_token,
                Match = new RelayWebhookMatch
                {
                    Protocol = item.match.protocol,
                    Domain = item.match.domain
                }
            };
        }
    }
}