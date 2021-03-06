﻿namespace Construktion.Tests.SimpleBlueprints
{
    using System;
    using Blueprints.Simple;
    using Internal;
    using Shouldly;
    using Xunit;

    public class GuidBlueprintTests
    {
        [Fact]
        public void should_construct()
        {
            var blueprint = new GuidBlueprint();

            var result = (Guid)blueprint.Construct(new ConstruktionContext(typeof(Guid)),
                new DefaultConstruktionPipeline());

            result.ShouldNotBe(new Guid());
        }
    }
}