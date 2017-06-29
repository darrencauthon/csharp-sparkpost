using System;
using System.Globalization;
using System.Net.Http;

namespace SparkPost
{
    public class HttpClientPreparation
    {
        private readonly IClient client;

        public HttpClientPreparation(IClient client)
        {
            this.client = client;
        }

        public void Prepare(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(client.ApiHost);
            httpClient.DefaultRequestHeaders.Add("Authorization", client.ApiKey);

            if (client.SubaccountId > 0)
                httpClient.DefaultRequestHeaders.Add("X-MSYS-SUBACCOUNT",
                    client.SubaccountId.ToString(CultureInfo.InvariantCulture));
        }
    }
}