using MessagePack.Resolvers;
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


