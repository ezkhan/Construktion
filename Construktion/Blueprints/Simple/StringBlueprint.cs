﻿namespace Construktion.Blueprints.Simple
{
    public class StringBlueprint : AbstractBlueprint<string>
    {
        public override object Construct(ConstruktionContext context, ConstruktionPipeline pipeline)
        {
            var result = "String-" + _random.Next(1, 10000);

            return result;
        }
    }
}