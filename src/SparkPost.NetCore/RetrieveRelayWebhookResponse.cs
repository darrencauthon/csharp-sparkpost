using SparkPost.Utilities;

namespace SparkPost
{
    public class RetrieveRelayWebhookResponse : Response
    {
        public RelayWebhook RelayWebhook { get; set; }

        public static RetrieveRelayWebhookResponse CreateFromResponse(Response response)
        {
            var result = new RetrieveRelayWebhookResponse();
            LeftRight.SetValuesToMatch(result, response);

            var results = Jsonification.DeserializeObject<dynamic>(response.Content).results;

            result.RelayWebhook = ListRelayWebhookResponse.ConvertToARelayWebhook(results);

            return result;
        }
    }
}