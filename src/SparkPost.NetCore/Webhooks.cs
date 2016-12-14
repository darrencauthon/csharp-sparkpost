using System.Net;
using System.Threading.Tasks;
using SparkPost.RequestSenders;

namespace SparkPost
{
    public interface IWebhooks
    {
        Task<ListWebhookResponse> List(object query = null);
        Task<Response> Create(Webhook webhook);
        Task<RetrieveWebhookResponse> Retrieve(string id);
        Task<bool> Delete(string id);
    }

    public class Webhooks : IWebhooks
    {
        private readonly IClient client;
        private readonly IDataMapper dataMapper;
        private readonly IRequestSender requestSender;

        public Webhooks(IClient client, IRequestSender requestSender, IDataMapper dataMapper)
        {
            this.client = client;
            this.requestSender = requestSender;
            this.dataMapper = dataMapper;
        }

        public async Task<ListWebhookResponse> List(object query = null)
        {
            if (query == null) query = new {};
            var request = new Request
            {
                Url = $"/api/{client.Version}/webhooks",
                Method = "GET",
                Data = query
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            return ListWebhookResponse.CreateFromResponse(response);
        }

        public async Task<RetrieveWebhookResponse> Retrieve(string id)
        {
            var request = new Request
            {
                Url = $"/api/{client.Version}/webhooks/{id}",
                Method = "GET"
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            return RetrieveWebhookResponse.CreateFromResponse(response);
        }

        public async Task<Response> Create(Webhook webhook)
        {
            var request = new Request
            {
                Url = $"api/{client.Version}/webhooks",
                Method = "POST",
                Data = dataMapper.ToDictionary(webhook)
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            var updateSuppressionResponse = new Response();
            LeftRight.SetValuesToMatch(updateSuppressionResponse, response);
            return updateSuppressionResponse;
        }

        public async Task<bool> Delete(string id)
        {
            var request = new Request
            {
                Url = $"/api/{client.Version}/webhooks/{id}",
                Method = "DELETE"
            };

            var response = await requestSender.Send(request);
            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}