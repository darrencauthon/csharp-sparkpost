using System.Net;
using System.Threading.Tasks;
using SparkPost.RequestSenders;

namespace SparkPost
{
    public interface IInboundDomains
    {
        Task<ListInboundDomainResponse> List(object query = null);
        Task<Response> Create(InboundDomain inboundDomain);
        Task<InboundDomainResponse> Retrieve(string domain);
        Task<bool> Delete(string domain);
    }

    public class InboundDomains : IInboundDomains
    {
        private readonly IClient client;
        private readonly IDataMapper dataMapper;
        private readonly IRequestSender requestSender;

        public InboundDomains(IClient client, IRequestSender requestSender, IDataMapper dataMapper)
        {
            this.client = client;
            this.requestSender = requestSender;
            this.dataMapper = dataMapper;
        }

        public async Task<ListInboundDomainResponse> List(object query = null)
        {
            if (query == null) query = new {};
            var request = new Request
            {
                Url = $"/api/{client.Version}/inbound-domains",
                Method = "GET",
                Data = query
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            return ListInboundDomainResponse.CreateFromResponse(response);
        }

        public async Task<InboundDomainResponse> Retrieve(string domain)
        {
            var request = new Request
            {
                Url = $"/api/{client.Version}/inbound-domains/{domain}",
                Method = "GET"
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            return InboundDomainResponse.CreateFromResponse(response);
        }

        public async Task<Response> Create(InboundDomain inboundDomain)
        {
            var request = new Request
            {
                Url = $"api/{client.Version}/inbound-domains",
                Method = "POST",
                Data = dataMapper.ToDictionary(inboundDomain)
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            var createInboundDomainResponse = new Response();
            LeftRight.SetValuesToMatch(createInboundDomainResponse, response);
            return createInboundDomainResponse;
        }

        public async Task<bool> Delete(string domain)
        {
            var request = new Request
            {
                Url = $"/api/{client.Version}/inbound-domains/{domain}",
                Method = "DELETE"
            };

            var response = await requestSender.Send(request);
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}