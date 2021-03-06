﻿namespace Construktion.Blueprints.Recursive
{
    using System;
    using System.Collections.Generic;

    public class InterfaceBlueprint : Blueprint
    {
        private readonly IDictionary<Type, Type> _typeMap = new Dictionary<Type, Type>();

        public InterfaceBlueprint() { }

        public InterfaceBlueprint(IDictionary<Type, Type> typeMap)
        {
            _typeMap = typeMap;
        }

        public bool Matches(ConstruktionContext context) => _typeMap.ContainsKey(context.RequestType);

        public object Construct(ConstruktionContext context, ConstruktionPipeline pipeline)
        {
            var implementation = _typeMap[context.RequestType];

            var result = pipeline.Send(new ConstruktionContext(implementation));

            return result;
        }
    }
}