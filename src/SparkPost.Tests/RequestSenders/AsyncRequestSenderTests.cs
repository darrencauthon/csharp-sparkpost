using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMoq.Helpers;
using NUnit.Framework;
using Shouldly;
using SparkPost.RequestSenders;

namespace SparkPost.Tests.RequestSenders
{
    public class AsyncRequestSenderTests
    {
        public class SendTests : AutoMoqTestFixture<SendTests.AsyncTesting>
        {
            private HttpClient httpClient;
            private Request request;
            private string apiHost;
            private string apiKey;
            private HttpResponseMessage defaultHttpResponseMessage;

            [SetUp]
            public void Setup()
            {
                ResetSubject();

                httpClient = new HttpClient();

                apiHost = "http://test.com";
                apiKey = Guid.NewGuid().ToString();

                var settings = new Client.Settings();
                settings.BuildHttpClientsUsing(() => httpClient);
                Mocked<IClient>().Setup(x => x.CustomSettings).Returns(settings);
                Mocked<IClient>().Setup(x => x.ApiHost).Returns(apiHost);
                Mocked<IClient>().Setup(x => x.ApiKey).Returns(apiKey);

                request = new Request();

                defaultHttpResponseMessage = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(Guid.NewGuid().ToString())
                };
            }

            [Test]
            public async Task It_should_return_the_http_response_message_info()
            {
                var content = Guid.NewGuid().ToString();
                Subject.SetupTheResponseWith((r, h) => new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(content)
                });

                var result = await Subject.Send(request);
                result.StatusCode.ShouldBe(HttpStatusCode.Accepted);
                result.Content.ShouldBe(content);
            }

            [Test]
            public async Task It_should_return_the_http_response_message_info_take_2()
            {
                var content = Guid.NewGuid().ToString();
                Subject.SetupTheResponseWith((r, h) => new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(content)
                });

                var result = await Subject.Send(request);
                result.StatusCode.ShouldBe(HttpStatusCode.NotFound);
                result.ReasonPhrase.ShouldBe("Not Found");
                result.Content.ShouldBe(content);
            }

            [Test]
            public async Task It_should_pass_the_api_key()
            {
                Subject.SetupTheResponseWith((r, h) =>
                {
                    h.DefaultRequestHeaders.Authorization.ToString().ShouldBe(apiKey);
                    return defaultHttpResponseMessage;
                });

                await Subject.Send(request);
            }

            [Test]
            public async Task It_should_send_the_request_to_the_appropriate_host()
            {
                Subject.SetupTheResponseWith((r, h) =>
                {
                    h.BaseAddress.ToString().ShouldBe(apiHost + "/");
                    return defaultHttpResponseMessage;
                });

                await Subject.Send(request);
            }

            [Test]
            public async Task It_should_set_the_subaccount_when_the_subaccount_is_not_zero()
            {
                Mocked<IClient>().Setup(x => x.SubaccountId).Returns(345);
                Subject.SetupTheResponseWith((r, h) =>
                {
                    var match = h.DefaultRequestHeaders.First(x => x.Key == "X-MSYS-SUBACCOUNT");
                    match.Value.Count().ShouldBe(1);
                    match.Value.First().ShouldBe("345");
                    return defaultHttpResponseMessage;
                });

                await Subject.Send(request);
            }

            [Test]
            public async Task It_should_NOT_set_a_subaccount_when_the_subaccount_is_zero()
            {
                Mocked<IClient>().Setup(x => x.SubaccountId).Returns(0);
                Subject.SetupTheResponseWith((r, h) =>
                {
                    var count = h.DefaultRequestHeaders.Count(x => x.Key == "X-MSYS-SUBACCOUNT");
                    count.ShouldBe(0);
                    return defaultHttpResponseMessage;
                });

                await Subject.Send(request);
            }

            public class AsyncTesting : AsyncRequestSender
            {
                private Func<Request, HttpClient, HttpResponseMessage> responseBuilder;

                public AsyncTesting(IClient client) : base(client, null)
                {
                }

                public void SetupTheResponseWith(Func<Request, HttpClient, HttpResponseMessage> responseBuilder)
                {
                    this.responseBuilder = responseBuilder;
                }

                protected override Task<HttpResponseMessage> GetTheResponse(Request request, HttpClient httpClient)
                {
                    return Task.FromResult(responseBuilder(request, httpClient));
                }
            }
        }
    }
}