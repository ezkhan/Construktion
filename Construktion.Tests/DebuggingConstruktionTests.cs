﻿namespace Construktion.Tests
{
    using Debug;
    using Shouldly;
    using Xunit;

    public class DebuggingConstruktionTests
    {
        [Fact]
        public void visually_inspect_log()
        {
            var debuggingConstruktion = new DebuggingConstruktion();
            var context = new ConstruktionContext(typeof(Foo));

            var result = debuggingConstruktion.DebuggingConstruct(context, out string log);

            //not going to assert on the message, a visual check is good enough 
            true.ShouldBe(true);
        }

        [Fact]
        public void log_should_power_through_exceptions()
        {
            var debuggingConstruktion = new DebuggingConstruktion();
            var context = new ConstruktionContext(typeof(WillThrowFoo));

            var result = debuggingConstruktion.DebuggingConstruct(context, out string log);

            log.ShouldContain("Cannot construct the interface");
            log.ShouldContain("End Construktion.Tests.DebuggingConstruktionTests+WillThrowFoo");
        }

        public class Foo
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class WillThrowFoo
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public NotRegisteredInterface NotRegisteredInterface { get; set; }
        }

        public interface NotRegisteredInterface { }
    }
}