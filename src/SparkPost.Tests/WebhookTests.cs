using NUnit.Framework;
using Shouldly;

namespace SparkPost.Tests
{
    public class WebhookTests
    {
        [TestFixture]
        public class DefaultTests
        {
            [Test]
            public void It_should_initialize_events()
            {
                (new Webhook()).Events.ShouldNotBeNull();
            }
        }
    }
}