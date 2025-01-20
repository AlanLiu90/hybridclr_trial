using MessagePack;
using MessagePack.Formatters;

public sealed class A1Formatter : IMessagePackFormatter<A1>
{
    public int Serialize(ref byte[] bytes, int offset, A1 value, IFormatterResolver formatterResolver)
     {
         return 0;
     }
     public A1 Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
     {
         readSize = 0;
         return default;
     }
}

public sealed class A2Formatter : IMessagePackFormatter<A2>
{
    public int Serialize(ref byte[] bytes, int offset, A2 value, IFormatterResolver formatterResolver)
     {
         return 0;
     }
     public A2 Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
     {
         readSize = 0;
         return default;
     }
}

public sealed class A3Formatter : IMessagePackFormatter<A3>
{
    public int Serialize(ref byte[] bytes, int offset, A3 value, IFormatterResolver formatterResolver)
     {
         return 0;
     }
     public A3 Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
     {
         readSize = 0;
         return default;
     }
}
