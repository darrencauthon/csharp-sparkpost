using System;
using AutoMoq.Helpers;
using NUnit.Framework;
using Shouldly;
using SparkPost.RequestMethods;

namespace SparkPost.Tests.RequestMethods
{
    public class GetTests
    {
        [TestFixture]
        public class CanExecuteTests : AutoMoqTestFixture<Get>
        {
            [Test]
            public void It_should_return_true_for_get()
            {
                var request = new Request {Method = "GET"};
                Subject.CanExecute(request).ShouldBeTrue();
            }

            [Test]
            public void It_should_return_true_for_get_lower()
            {
                var request = new Request {Method = "get"};
                Subject.CanExecute(request).ShouldBeTrue();
            }

            [Test]
            public void It_should_return_true_for_get_spacing()
            {
                var request = new Request {Method = "get "};
                Subject.CanExecute(request).ShouldBeTrue();
            }

            [Test]
            public void It_should_return_false_for_others()
            {
                var request = new Request {Method = Guid.NewGuid().ToString()};
                Subject.CanExecute(request).ShouldBeFalse();
            }

            [Test]
            public void It_should_return_false_for_null()
            {
                var request = new Request {Method = null};
                Subject.CanExecute(request).ShouldBeFalse();
            }
        }
    }
}