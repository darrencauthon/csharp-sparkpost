using System.Collections.Generic;
using SparkPost.Utilities;

namespace SparkPost
{
    public class ListWebhookResponse : Response
    {
        public IEnumerable<Webhook> Webhooks { get; set; }

        public static ListWebhookResponse CreateFromResponse(Response response)
        {
            var result = new ListWebhookResponse();
            LeftRight.SetValuesToMatch(result, response);

            var results = Jsonification.DeserializeObject<dynamic>(result.Content).results;
            var webhooks = new List<Webhook>();
            foreach(var r in results)
                webhooks.Add(ConvertToAWebhook(r));

            result.Webhooks = webhooks;
            return result;
        }

        internal static Webhook ConvertToAWebhook(dynamic r)
        {
            var events = new List<string>();
            foreach (var i in r.events)
                events.Add(i.ToString());
            var webhook = new Webhook
            {
                Id = r.id,
                Name = r.name,
                Target = r.target,
                Events = events,
                AuthType = r.auth_type,
                AuthRequestDetails = r.auth_request_details,
                AuthCredentials = r.auth_credentials,
                AuthToken = r.auth_token,
                LastSuccessful = r.last_successful,
                LastFailure = r.last_failure
            };
            return webhook;
        }
    }
}