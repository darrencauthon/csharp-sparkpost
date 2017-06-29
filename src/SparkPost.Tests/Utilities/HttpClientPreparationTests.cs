using System;
using System.Linq;
using System.Net.Http;
using AutoMoq.Helpers;
using NUnit.Framework;
using Should;

namespace SparkPost.Tests.Utilities
{
    public class HttpClientPreparationTests
    {
        [TestFixture]
        public class PrepareTests : AutoMoqTestFixture<HttpClientPreparation>
        {
            private HttpClient httpClient;
            private string apiHost;
            private string apiKey;

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
            }

            [Test]
            public void It_should_set_the_base_address()
            {
                Subject.Prepare(httpClient);
                httpClient.BaseAddress.Host.ShouldEqual("test.com");
            }

            [Test]
            public void It_should_set_the_authorization_header()
            {
                Subject.Prepare(httpClient);
                httpClient.DefaultRequestHeaders.Authorization.ToString().ShouldEqual(apiKey);
            }

            [Test]
            public void It_should_set_the_x_msys_subaccount_if_the_subaccount_is_set()
            {
                Mocked<IClient>().Setup(x => x.SubaccountId).Returns(5);
                Subject.Prepare(httpClient);
                var match = httpClient.DefaultRequestHeaders.First(x => x.Key == "X-MSYS-SUBACCOUNT");
                match.Value.Count().ShouldEqual(1);
                match.Value.First().ShouldEqual("5");
            }

            [Test]
            public void It_should_not_set_The_xmsys_subaccount_if_the_subaccount_is_zero()
            {
                Mocked<IClient>().Setup(x => x.SubaccountId).Returns(0);
                Subject.Prepare(httpClient);
                httpClient.DefaultRequestHeaders.Count(x => x.Key == "X-MSYS-SUBACCOUNT")
                    .ShouldEqual(0);
            }

            [Test]
            public void It_should_not_set_The_xmsys_subaccount_if_the_subaccount_is_less_than_zero()
            {
                Mocked<IClient>().Setup(x => x.SubaccountId).Returns(-1);
                Subject.Prepare(httpClient);
                httpClient.DefaultRequestHeaders.Count(x => x.Key == "X-MSYS-SUBACCOUNT")
                    .ShouldEqual(0);
            }
        }
    }
}