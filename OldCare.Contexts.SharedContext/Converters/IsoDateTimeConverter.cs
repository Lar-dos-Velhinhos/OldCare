using System.Text.Json;
using System.Text.Json.Serialization;
using OldCare.Contexts.SharedContext.Converters.Exceptions;

namespace OldCare.Contexts.SharedContext.Converters;

public class IsoDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var date = reader.GetString();
        try
        {
            return DateTime.Parse(date ?? string.Empty);
        }
        catch
        {
            throw new IsoDateTimeConverterException($"Data `{date}` inválida! Formato ISO inválido");
        }
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
}