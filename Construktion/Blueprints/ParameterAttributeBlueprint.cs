﻿namespace Construktion.Blueprints
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class ParameterAttributeBlueprint<T> : Blueprint where T : Attribute
    {
        protected readonly Func<T, object> _value;

        public ParameterAttributeBlueprint(Func<T, object> value)
        {
            value.GuardNull();

            _value = value;
        }

        public virtual bool Matches(ConstruktionContext context)
        {
            return context.ParameterInfo?.GetCustomAttributes(typeof(T))
                       .ToList()
                       .Any() ?? false;
        }

        public virtual object Construct(ConstruktionContext context, ConstruktionPipeline pipeline)
        {
            var attribute = (T)context.ParameterInfo.GetCustomAttribute(typeof(T));

            var value = _value(attribute);

            return value;
        }
    }
}