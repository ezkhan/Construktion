﻿namespace Construktion.Tests.Blueprints
{
    using System.Reflection;
    using global::Construktion.Blueprints;
    using Shouldly;
    using Xunit;

    public class StringPropertyBlueprintTests
    {
        [Fact]
        public void property_name_is_prefixed()
        {
            var blueprint = new StringPropertyBlueprint();
            var pi = typeof(Foo).GetProperty(nameof(Foo.Name));
            var result = (string)blueprint.Construct(new ConstruktionContext(pi), Pipeline.Default);
            
            result.Substring(0, 5).ShouldBe("Name-");
        }

        public class Foo
        {
            public string Name { get; set; }
        }
    }
}