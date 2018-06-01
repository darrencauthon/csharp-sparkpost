using System.Threading.Tasks;
using AutoMoq.Helpers;
using NUnit.Framework;
using Shouldly;
using SparkPost.RequestSenders;

namespace SparkPost.Tests.RequestSenders
{
    public class SyncRequestSenderTests
    {
        [TestFixture]
        public class SendTests : AutoMoqTestFixture<SyncRequestSender>
        {
            [Test]
            public void It_should_return_the_result_from_the_parent_request_sender()
            {
                var request = new Request();
                var response = new Response();

                Mocked<IRequestSender>().Setup(x => x.Send(request)).Returns(Task.FromResult(response));

                var result = Subject.Send(request);

                result.Result.ShouldBeSameAs(response);
            }
        }
    }
}