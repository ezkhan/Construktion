﻿using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Construktion.Tests")]
[assembly: InternalsVisibleTo("Construktion.Benchmarks")]

namespace Construktion.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class Extensions
    {
        public static ConstructorInfo GreedyCtor(this List<ConstructorInfo> ctors)
        {
            var max = ctors.Max(x => x.GetParameters().Length);
            var greedyCtor = ctors.First(x => x.GetParameters().Length == max);

            return greedyCtor;
        }

        public static ConstructorInfo ModestCtor(this List<ConstructorInfo> ctors)
        {
            var min = ctors.Min(x => x.GetParameters().Length);
            var modestCtor = ctors.First(x => x.GetParameters().Length == min);

            return modestCtor;
        }

        public static IEnumerable<PropertyInfo> PropertiesWithPublicSetter(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                       .Where(x => x.CanWrite && x.GetSetMethod( /*nonPublic*/ true).IsPublic);
        }

        public static IEnumerable<PropertyInfo> PropertiesWithAccessibleSetter(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                       .Where(x => x.CanWrite);
        }
    }
}