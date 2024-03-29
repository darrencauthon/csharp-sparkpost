﻿using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace SparkPost.RequestSenders
{
    public interface IRequestSender
    {
        Task<Response> Send(Request request);
    }

    public class RequestSender : IRequestSender
    {
        private readonly IClient client;
        private readonly IDataMapper dataMapper;

        public RequestSender(IClient client, IDataMapper dataMapper)
        {
            this.client = client;
            this.dataMapper = dataMapper;
        }

        public virtual async Task<Response> Send(Request request)
        {
            using (var httpClient = client.CustomSettings.CreateANewHttpClient())
            {
                httpClient.BaseAddress = new Uri(client.ApiHost);
                httpClient.DefaultRequestHeaders.Add("Authorization", client.ApiKey);

                SetTheUserAgentIfItIsProvided(httpClient);

                if (client.SubaccountId != 0)
                    httpClient.DefaultRequestHeaders.Add("X-MSYS-SUBACCOUNT", client.SubaccountId.ToString(CultureInfo.InvariantCulture));

                var result = await GetTheResponse(request, httpClient);

                return new Response
                {
                    StatusCode = result.StatusCode,
                    ReasonPhrase = result.ReasonPhrase,
                    Content = await result.Content.ReadAsStringAsync()
                };
            }
        }

        private void SetTheUserAgentIfItIsProvided(HttpClient httpClient)
        {
            if (string.IsNullOrEmpty(client.CustomSettings.UserAgent) == false)
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", client.CustomSettings.UserAgent);
        }

        protected virtual async Task<HttpResponseMessage> GetTheResponse(Request request, HttpClient httpClient)
        {
            return await new RequestMethodFinder(httpClient, dataMapper).FindFor(request).Execute(request);
        }
    }
}
