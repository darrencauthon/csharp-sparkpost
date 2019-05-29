using AutoMoq.Helpers;
using Moq;
using NUnit.Framework;
using Should;
using SparkPost.RequestSenders;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SparkPost.Tests
{
    public class TemplateTests
    {
        [TestFixture]
        public class DeleteTests : AutoMoqTestFixture<Templates>
        {
            private Response _response;
            private Template _template;

            [SetUp]
            public void Setup()
            {
                ResetSubject();

                _response = new Response { StatusCode = HttpStatusCode.NoContent };

                Mocked<IRequestSender>()
                    .Setup(x => x.Send(It.IsAny<Request>()))
                    .Returns(Task.FromResult(_response));

                _template = new Template()
                {
                    Id = Guid.NewGuid().ToString()
                };
            }

            [Test]
            public async void It_should_return_false_if_the_status_is_not_ok()
            {
                var result = await Subject.Delete(_template.Id);
                result.ShouldBeFalse();
            }

            [Test]
            public async void It_should_return_false_if_the_web_request_returns_anything_but_no_content()
            {
                _response.StatusCode = HttpStatusCode.Accepted;
                (await Subject.Delete(_template.Id)).ShouldBeFalse();

                _response.StatusCode = HttpStatusCode.Ambiguous;
                (await Subject.Delete(_template.Id)).ShouldBeFalse();

                _response.StatusCode = HttpStatusCode.UpgradeRequired;
                (await Subject.Delete(_template.Id)).ShouldBeFalse();
            }

            [Test]
            public async void It_should_build_the_web_request_parameters_correctly()
            {
                var version = Guid.NewGuid().ToString();

                Mocked<IClient>()
                    .Setup(x => x.Version)
                    .Returns(version);

                Mocked<IRequestSender>()
                    .Setup(x => x.Send(It.IsAny<Request>()))
                    .Callback((Request r) =>
                    {
                        r.Url.ShouldEqual($"api/{version}/templates/{_template.Id}");
                        r.Method.ShouldEqual("DELETE");
                    })
                    .Returns(Task.FromResult(_response));

                await Subject.Delete(_template.Id);
            }
        }

        [TestFixture]
        public class CreateOrUpdateTests : AutoMoqTestFixture<Templates>
        {
            private Response _response;
            private List<Template> _templates;

            [SetUp]
            public void Setup()
            {
                ResetSubject();

                _response = new Response
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = ""
                };

                Mocked<IRequestSender>()
                    .Setup(x => x.Send(It.IsAny<Request>()))
                    .Returns(Task.FromResult(_response));

                _templates = new List<Template>
                {
                    new Template(),
                    new Template()
                };
            }

            [Test]
            public async void It_should_return_a_response_when_the_web_request_is_ok()
            {
                var result = await Subject.Create(_templates[0]);
                result.ShouldNotBeNull();

                var boolResult = await Subject.Update(_templates[0].Id, _templates[0]);
                Assert.AreEqual(true, boolResult);
            }

            [Test]
            public async void It_should_return_the_reason_phrase()
            {
                _response.ReasonPhrase = Guid.NewGuid().ToString();
                var result = await Subject.Create(_templates[0]);
                result.ReasonPhrase.ShouldEqual(_response.ReasonPhrase);
            }

            [Test]
            public async void It_should_return_the_content()
            {
                _response.Content = Guid.NewGuid().ToString();
                var result = await Subject.Create(_templates[1]);
                result.Content.ShouldEqual(_response.Content);
            }

            [Test]
            public async void It_should_make_a_properly_formed_request_for_create()
            {
                var client = Mocked<IClient>().Object;
                Mocked<IClient>().Setup(x => x.Version).Returns(Guid.NewGuid().ToString());
                Mocked<IRequestSender>()
                    .Setup(x => x.Send(It.IsAny<Request>()))
                    .Callback((Request r) =>
                    {
                        r.Url.ShouldEqual($"api/{client.Version}/templates");
                        r.Method.ShouldEqual("POST");
                    })
                    .Returns(Task.FromResult(_response));

                await Subject.Create(_templates[1]);
            }

            [Test]
            public async void It_should_make_a_properly_formed_request_for_update()
            {
                _templates[1].Id = Guid.NewGuid().ToString();

                var client = Mocked<IClient>().Object;
                Mocked<IClient>().Setup(x => x.Version).Returns(Guid.NewGuid().ToString());
                Mocked<IRequestSender>()
                    .Setup(x => x.Send(It.IsAny<Request>()))
                    .Callback((Request r) =>
                    {
                        r.Url.ShouldEqual($"api/{client.Version}/templates/{_templates[1].Id}");
                        r.Method.ShouldEqual("PUT");
                    })
                    .Returns(Task.FromResult(_response));

                await Subject.Update(_templates[1].Id, _templates[1]);
            }

            [Test]
            public async void It_should_throw_if_the_http_status_code_is_not_ok_for_create()
            {
                _response.StatusCode = HttpStatusCode.Accepted;

                Exception exception = null;
                try
                {
                    await Subject.Create(_templates[1]);
                }
                catch (ResponseException ex)
                {
                    exception = ex;
                }

                exception.ShouldNotBeNull();
            }

            [Test]
            public async void It_should_throw_if_the_http_status_code_is_not_ok_for_update()
            {
                _response.StatusCode = HttpStatusCode.Accepted;

                Exception exception = null;
                try
                {
                    await Subject.Update(_templates[1].Id, _templates[1]);
                }
                catch (ResponseException ex)
                {
                    exception = ex;
                }

                exception.ShouldNotBeNull();
            }
        }
    }
}
