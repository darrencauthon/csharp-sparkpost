using System;
using AutoMoq.Helpers;
using NUnit.Framework;
using Shouldly;
using SparkPost.RequestMethods;

namespace SparkPost.Tests.RequestMethods
{
    public class PostTests
    {
        [TestFixture]
        public class CanExecuteTests : AutoMoqTestFixture<Post>
        {
            [Test]
            public void It_should_return_true_for_post()
            {
                var request = new Request {Method = "POST"};
                Subject.CanExecute(request).ShouldBeTrue();
            }

            [Test]
            public void It_should_return_true_for_post_lower()
            {
                var request = new Request {Method = "post"};
                Subject.CanExecute(request).ShouldBeTrue();
            }

            [Test]
            public void It_should_return_true_for_post_spaces()
            {
                var request = new Request {Method = "post  "};
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