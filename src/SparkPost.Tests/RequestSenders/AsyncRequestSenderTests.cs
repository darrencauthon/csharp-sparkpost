using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMoq.Helpers;
using NUnit.Framework;
using Should;
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

                Mocker.SetInstance(httpClient);

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
            public async void It_should_return_the_http_response_message_info()
            {
                var content = Guid.NewGuid().ToString();
                Subject.SetupTheResponseWith((r, h) => new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(content)
                });

                var result = await Subject.Send(request);
                result.StatusCode.ShouldEqual(HttpStatusCode.Accepted);
                result.Content.ShouldEqual(content);
            }

            [Test]
            public async void It_should_return_the_http_response_message_info_take_2()
            {
                var content = Guid.NewGuid().ToString();
                Subject.SetupTheResponseWith((r, h) => new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(content)
                });

                var result = await Subject.Send(request);
                result.StatusCode.ShouldEqual(HttpStatusCode.NotFound);
                result.ReasonPhrase.ShouldEqual("Not Found");
                result.Content.ShouldEqual(content);
            }

            public class AsyncTesting : AsyncRequestSender
            {
                private Func<Request, HttpClient, HttpResponseMessage> responseBuilder;

                public AsyncTesting(IClient client, Func<HttpClient> httpClient) : base(null, httpClient)
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