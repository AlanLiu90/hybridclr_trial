using System;
using System.Collections.Generic;

public class GeneratedResolver : global::MessagePack.IFormatterResolver
{
    public static readonly global::MessagePack.IFormatterResolver Instance = new GeneratedResolver();

    GeneratedResolver()
    {

    }

    public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
    {
        return FormatterCache<T>.formatter;
    }

    static class FormatterCache<T>
    {
        public static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> formatter;

        static FormatterCache()
        {
            var f = GeneratedResolverGetFormatterHelper.GetFormatter(typeof(T));
            if (f != null)
            {
                formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
            }
        }
    }
}

internal static partial class GeneratedResolverGetFormatterHelper
{
    static readonly Dictionary<Type, object> formatterMap = new Dictionary<Type, object>()
        {
            {typeof(A1), new A1Formatter()},
            {typeof(A2), new A2Formatter()},
            {typeof(A3), new A3Formatter()},
        };

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
