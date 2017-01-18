
using SparkPost.Utilities;

namespace SparkPost
{
    public class RetrieveWebhookResponse : Response
    {
        public Webhook Webhook { get; set; }

        public static RetrieveWebhookResponse CreateFromResponse(Response response)
        {
            var result = new RetrieveWebhookResponse();
            LeftRight.SetValuesToMatch(result, response);

            var results = Jsonification.DeserializeObject<dynamic>(response.Content).results;

            result.Webhook = ListWebhookResponse.ConvertToAWebhook(results);

            return result;
        }
    }
}