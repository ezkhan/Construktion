﻿namespace Construktion.Builders
{
    using System;

    public class GuidBuilder : Builder
    {
        public bool CanBuild(ConstruktionContext context)
        {
            return context.RequestType == typeof(Guid);
        }

        public object Build(ConstruktionContext context, ConstruktionPipeline pipeline)
        {
            return Guid.NewGuid();
        }
    }
}
