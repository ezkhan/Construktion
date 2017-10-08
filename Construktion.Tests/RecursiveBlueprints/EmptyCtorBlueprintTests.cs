﻿using Construktion.Blueprints.Recursive;
using Shouldly;
using Xunit;

namespace Construktion.Tests.RecursiveBlueprints
{
    public class EmptyCtorBlueprintTests
    {
        [Fact]
        public void should_build_a_class_with_its_properties()
        {
            var blueprint = new EmptyCtorBlueprint();

            var result = (Person)blueprint.Construct(new ConstruktionContext(typeof(Person)), new DefaultConstruktionPipeline());

            result.ShouldNotBeNull();
            result.Name.ShouldNotBeNullOrEmpty();
            result.Age.ShouldNotBeNull();
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}