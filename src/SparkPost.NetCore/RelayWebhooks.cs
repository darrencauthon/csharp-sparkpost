using System.Net;
using System.Threading.Tasks;
using SparkPost.RequestSenders;

namespace SparkPost
{
    public interface IRelayWebhooks
    {
        Task<ListRelayWebhookResponse> List(object query = null);
        Task<Response> Create(RelayWebhook webhook);
        Task<RetrieveRelayWebhookResponse> Retrieve(string id);
        Task<Response> Update(RelayWebhook relayWebhook);
        Task<bool> Delete(string id);
    }

    public class RelayWebhooks : IRelayWebhooks
    {
        private readonly IClient client;
        private readonly IDataMapper dataMapper;
        private readonly IRequestSender requestSender;

        public RelayWebhooks(IClient client, IRequestSender requestSender, IDataMapper dataMapper)
        {
            this.client = client;
            this.requestSender = requestSender;
            this.dataMapper = dataMapper;
        }

        public async Task<ListRelayWebhookResponse> List(object query = null)
        {
            if (query == null) query = new {};
            var request = new Request
            {
                Url = $"/api/{client.Version}/relay-webhooks",
                Method = "GET",
                Data = query
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            return ListRelayWebhookResponse.CreateFromResponse(response);
        }

        public async Task<RetrieveRelayWebhookResponse> Retrieve(string id)
        {
            var request = new Request
            {
                Url = $"/api/{client.Version}/relay-webhooks/{id}",
                Method = "GET"
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            return RetrieveRelayWebhookResponse.CreateFromResponse(response);
        }

        public async Task<Response> Create(RelayWebhook relayWebhook)
        {
            var request = new Request
            {
                Url = $"api/{client.Version}/relay-webhooks",
                Method = "POST",
                Data = dataMapper.ToDictionary(relayWebhook)
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            var createWebhookResponse = new Response();
            LeftRight.SetValuesToMatch(createWebhookResponse, response);
            return createWebhookResponse;
        }

        public async Task<Response> Update(RelayWebhook relayWebhook)
        {
            var request = new Request
            {
                Url = $"api/{client.Version}/relay-webhooks/{relayWebhook.Id}",
                Method = "PUT",
                Data = dataMapper.ToDictionary(relayWebhook)
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            var createWebhookResponse = new Response();
            LeftRight.SetValuesToMatch(createWebhookResponse, response);
            return createWebhookResponse;
        }

        public async Task<bool> Delete(string id)
        {
            var request = new Request
            {
                Url = $"/api/{client.Version}/relay-webhooks/{id}",
                Method = "DELETE"
            };

            var response = await requestSender.Send(request);
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}