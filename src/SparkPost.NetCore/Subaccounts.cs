using System.Net;
using System.Threading.Tasks;
using SparkPost.RequestSenders;
using SparkPost.Utilities;

namespace SparkPost
{
    public class Subaccounts : ISubaccounts
    {
        private readonly IClient client;
        private readonly IRequestSender requestSender;
        private readonly IDataMapper dataMapper;

        public Subaccounts(IClient client, IRequestSender requestSender, IDataMapper dataMapper)
        {
            this.client = client;
            this.requestSender = requestSender;
            this.dataMapper = dataMapper;
        }

        public async Task<ListSubaccountResponse> List()
        {
            var request = new Request
            {
                Url = $"/api/{client.Version}/subaccounts",
                Method = "GET"
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            return ListSubaccountResponse.CreateFromResponse(response);
        }

        public async Task<CreateSubaccountResponse> Create(SubaccountCreate subaccount)
        {
            var request = new Request
            {
                Url = $"api/{client.Version}/subaccounts",
                Method = "POST",
                Data = new
                {
                    name = subaccount.Name,
                    key_label = subaccount.KeyLabel,
                    key_grants = subaccount.KeyGrants
                }
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            var results = Jsonification.DeserializeObject<dynamic>(response.Content).results;

            return new CreateSubaccountResponse
            {
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode,
                Content = response.Content,
                Key = results.key,
                Label = results.label,
                ShortKey = results.short_key,
                SubaccountId = results.subaccount_id
            };
        }

        public async Task<UpdateSubaccountResponse> Update(SubaccountUpdate subaccount)
        {
            var request = new Request
            {
                Url = $"api/{client.Version}/subaccounts/{subaccount.Id}",
                Method = "PUT JSON",
                Data = new
                {
                    name = subaccount.Name,
                    status = subaccount.Status.ToString().ToLowerInvariant()
                }
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            var results = Jsonification.DeserializeObject<dynamic>(response.Content).results;

            return new UpdateSubaccountResponse
            {
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode,
                Content = response.Content
            };
        }

    }
}