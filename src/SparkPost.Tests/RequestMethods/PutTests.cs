using System;
using AutoMoq.Helpers;
using NUnit.Framework;
using Shouldly;
using SparkPost.RequestMethods;

namespace SparkPost.Tests.RequestMethods
{
    public class PutTests
    {
        [TestFixture]
        public class CanExecuteTests : AutoMoqTestFixture<Put>
        {
            [Test]
            public void It_should_return_true_for_put()
            {
                var request = new Request {Method = "PUT"};
                Subject.CanExecute(request).ShouldBeTrue();
            }

            [Test]
            public void It_should_return_true_for_put_lower()
            {
                var request = new Request {Method = "put"};
                Subject.CanExecute(request).ShouldBeTrue();
            }

            [Test]
            public void It_should_return_true_for_put_json()
            {
                var request = new Request {Method = "PUT JSON"};
                Subject.CanExecute(request).ShouldBeTrue();
            }

            [Test]
            public void It_should_return_false_for_others()
            {
                var request = new Request {Method = Guid.NewGuid().ToString()};
                Subject.CanExecute(request).ShouldBeFalse();
            }

            [Test]
            public void It_should_return_false_for_nil()
            {
                var request = new Request {Method = null};
                Subject.CanExecute(request).ShouldBeFalse();
            }
        }
    }
}