﻿namespace Construktion.Tests
{
    using Blueprints;
    using Shouldly;
    using Xunit;

    public class StringBlueprintTests
    {
        [Fact]
        public void should_build_string()
        {
            var blueprint = new StringBlueprint();

            var result = (string)blueprint.Construct(new ConstruktionContext(typeof(string)), Default.Pipeline);

            result.Substring(0, 7).ShouldBe("String-");
        }
    }
}