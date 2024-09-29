using Confluent.Kafka;
using System.Text.Json;

namespace Shared.Events
{
    public class CustomKeyDeserializer<T> : IDeserializer<T>
    {
        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            return JsonSerializer.Deserialize<T>(data)!;
        }
    }
}