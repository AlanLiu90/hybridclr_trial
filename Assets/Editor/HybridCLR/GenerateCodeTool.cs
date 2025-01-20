using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GenerateCodeTool : MonoBehaviour
{
    private const int Count = 1000;

    [MenuItem("Tools/Generate Code")]
    private static void Generate()
    {
        using (var sw = new StreamWriter("Assets/HotUpdate/Serializables.cs"))
        {
            for (int i = 0; i < Count; i++)
            {
                sw.WriteLine($"public class A{i + 1}");
                sw.WriteLine("{");
                sw.WriteLine("}");
                sw.WriteLine();
            }
        }

        using (var sw = new StreamWriter("Assets/HotUpdate/Formatters.cs"))
        {
            sw.WriteLine("using MessagePack;");
            sw.WriteLine("using MessagePack.Formatters;");
            sw.WriteLine();

            for (int i = 0; i < Count; i++)
            {
                sw.WriteLine($"public sealed class A{i + 1}Formatter : IMessagePackFormatter<A{i + 1}>");
                sw.WriteLine("{");
 
                sw.WriteLine($"    public int Serialize(ref byte[] bytes, int offset, A{i + 1} value, IFormatterResolver formatterResolver)");
                sw.WriteLine("     {");
                sw.WriteLine("         return 0;");
                sw.WriteLine("     }");

                sw.WriteLine($"     public A{i + 1} Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)");
                sw.WriteLine("     {");
                sw.WriteLine("         readSize = 0;");
                sw.WriteLine("         return default;");
                sw.WriteLine("     }");

                sw.WriteLine("}");
                sw.WriteLine();
            }
        }

        using (var sw = new StreamWriter("Assets/HotUpdate/GeneratedResolverGetFormatterHelper.cs"))
        {
            sw.WriteLine("using System;");
            sw.WriteLine("using System.Collections.Generic;");
            sw.WriteLine();

            sw.WriteLine("namespace MessagePack.Resolvers");
            sw.WriteLine("{");

            sw.WriteLine("internal static partial class GeneratedResolverGetFormatterHelper");
            sw.WriteLine("{");

            sw.WriteLine("    static readonly Dictionary<Type, object> formatterMap = new Dictionary<Type, object>()");
            sw.WriteLine("    {");

            for (int i = 0; i < Count; i++)
            {
                sw.WriteLine($"        {{typeof(A{i + 1}), new A{i + 1}Formatter()}},");
            }

            sw.WriteLine("    };");

            sw.WriteLine("}");

            sw.WriteLine("}");
        }

        using (var sw = new StreamWriter("Assets/HotUpdate/InstantiateByAddComponentPartial.cs"))
        {
            sw.WriteLine("using System;");
            sw.WriteLine("using System.Collections.Generic;");
            sw.WriteLine("using MessagePack;");
            sw.WriteLine();

            sw.WriteLine("partial class InstantiateByAddComponent");
            sw.WriteLine("{");

            sw.WriteLine("    static void RunGeneratedCode()");
            sw.WriteLine("    {");

            for (int i = 0; i < Count; i++)
            {
                sw.WriteLine($"        GeneratedResolver.Instance.GetFormatterWithVerify<A{i + 1}>();");
            }

            sw.WriteLine("    }");

            sw.WriteLine("}");
        }

        AssetDatabase.Refresh();
    }
}
