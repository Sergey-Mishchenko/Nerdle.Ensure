using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_ensuring_less_than
    {
        [TestFixture]
        public class On_a_value
        {
            [Test]
            public void No_exception_is_thrown_if_the_value_is_less_than()
            {
                Action ensuring = () => Ensure.ValueOf(-1).LessThan(0);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_value_is_equal_to()
            {
                Action ensuring = () => Ensure.ValueOf(0).LessThan(0);
                ensuring.ShouldThrow<Exception>();
            }

            [Test]
            public void An_exception_is_thrown_if_the_value_is_greater_than()
            {
                Action ensuring = () => Ensure.ValueOf(1).LessThan(0);
                ensuring.ShouldThrow<Exception>();
            }

            [Test]
            public void The_default_exception_is_InvalidOperationException()
            {
                Action ensuring = () => Ensure.ValueOf(1).LessThan(1);
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("Value must be less than 1 but was 1.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.ValueOf(1).LessThan(1, "foo");
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.ValueOf(1).LessThan(1, _ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.ValueOf(-1);
                theEnsurable.LessThan(0).Should().Be(theEnsurable);
            }
        }

        [TestFixture]
        public class On_an_argument
        {
            [Test]
            public void No_exception_is_thrown_if_the_value_is_less_than()
            {
                Action ensuring = () => Ensure.Argument(-1).LessThan(0);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_value_is_equal_to()
            {
                Action ensuring = () => Ensure.Argument(1).LessThan(1);
                ensuring.ShouldThrow<Exception>();
            }

            [Test]
            public void An_exception_is_thrown_if_the_value_is_greater_than()
            {
                Action ensuring = () => Ensure.Argument(1).LessThan(0);
                ensuring.ShouldThrow<Exception>();
            }

            [Test]
            public void The_default_exception_is_ArgumentOutOfRangeException()
            {
                Action ensuring = () => Ensure.Argument(1).LessThan(1);
                ensuring.ShouldThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value must be less than 1 but was 1.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(1).LessThan(1, "foo");
                ensuring.ShouldThrowExactly<ArgumentOutOfRangeException>().WithMessage("foo");
            }

            [Test]
            public void The_exception_includes_the_name_if_set()
            {
                Action ensuring = () => Ensure.Argument(1, "myArg").LessThan(0);
                ensuring.ShouldThrowExactly<ArgumentOutOfRangeException>().And.ParamName.Should().Be("myArg");
            }

            [Test]
            public void The_exception_does_not_include_the_name_if_not_set()
            {
                Action ensuring = () => Ensure.Argument(1).LessThan(0); ;
                ensuring.ShouldThrowExactly<ArgumentOutOfRangeException>().And.ParamName.Should().BeNull();
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(1).LessThan(1, _ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Argument(-1);
                theEnsurable.LessThan(0).Should().Be(theEnsurable);
            }
        }
    }
}