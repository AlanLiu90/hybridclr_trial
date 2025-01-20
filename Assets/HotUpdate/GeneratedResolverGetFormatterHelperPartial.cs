using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MessagePack.Resolvers
{
    internal static partial class GeneratedResolverGetFormatterHelper
    {
        internal static object GetFormatter(Type t)
        {
            object formatter;
            if (formatterMap.TryGetValue(t, out formatter))
            {
                return formatter;
            }

            return null;
        }
    }
}
