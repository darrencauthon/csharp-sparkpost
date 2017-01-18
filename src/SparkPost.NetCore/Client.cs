using System;
using System.Net.Http;
using SparkPost.RequestSenders;

namespace SparkPost
{
    public class Client : IClient
    {
        private const string defaultApiHost = "https://api.sparkpost.com";

        public Client(string apiKey) : this(apiKey, defaultApiHost, 0)
        {

        }

        public Client(string apiKey, string apiHost) : this(apiKey, apiHost, 0)
        {

        }

        public Client(string apiKey, long subAccountId) : this(apiKey, defaultApiHost, subAccountId)
        {

        }

        public Client(string apiKey, string apiHost, long subAccountId)
        {
            ApiKey = apiKey;
            ApiHost = apiHost;
            SubaccountId = subAccountId;

            var dataMapper = new DataMapper(Version);
            var asyncRequestSender = new AsyncRequestSender(this, dataMapper);
            var syncRequestSender = new SyncRequestSender(asyncRequestSender);
            var requestSender = new RequestSender(asyncRequestSender, syncRequestSender, this);

            SendingDomains = new SendingDomains(this, requestSender, dataMapper);
            Transmissions = new Transmissions(this, requestSender, dataMapper);
            Suppressions = new Suppressions(this, requestSender, dataMapper);
            Webhooks = new Webhooks(this, requestSender, dataMapper);
            Subaccounts = new Subaccounts(this, requestSender, dataMapper);
            MessageEvents = new MessageEvents(this, requestSender);
            InboundDomains = new InboundDomains(this, requestSender, dataMapper);
            RelayWebhooks = new RelayWebhooks(this, requestSender, dataMapper);
            RecipientLists = new RecipientLists(this, requestSender, dataMapper);
            Templates = new Templates(this, requestSender, dataMapper);
            Metrics = new Metrics(this, requestSender);
            CustomSettings = new Settings();
        }

        public string ApiKey { get; set; }
        public string ApiHost { get; set; }
        public long SubaccountId { get; set; }

        public ISendingDomains SendingDomains { get; }
        public ITransmissions Transmissions { get; }
        public ISuppressions Suppressions { get; }
        public IWebhooks Webhooks { get; }
        public ISubaccounts Subaccounts { get; }
        public IMessageEvents MessageEvents { get; }
        public IInboundDomains InboundDomains { get; }
        public IRelayWebhooks RelayWebhooks { get; }
        public IRecipientLists RecipientLists { get; }
        public ITemplates Templates { get; }
        public IMetrics Metrics { get; } 
        public string Version => "v1";

        public Settings CustomSettings { get; }

        public class Settings
        {
            private Func<HttpClient> httpClientBuilder;

            public Settings()
            {
                httpClientBuilder = () =>
                {
                    var httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    return httpClient;
                };
            }

            public SendingModes SendingMode { get; set; }

            public HttpClient CreateANewHttpClient()
            {
                return httpClientBuilder();
            }

            public void BuildHttpClientsUsing(Func<HttpClient> httpClient)
            {
                httpClientBuilder = httpClient;
            }
        }

    }
}