using ProductsManagment.Common.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductsManagment.Common
{
    public class CategoryConverter : JsonConverter<CategoryDto>
    {
        public override CategoryDto? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;
                

                if (root.TryGetProperty("voltage", out _))
                {
                    return JsonSerializer.Deserialize<ElectricProductDTO>(root.GetRawText(), options);
                }
                else if (root.TryGetProperty("expiryDate", out _))
                {
                    return JsonSerializer.Deserialize<FreshProductDTO>(root.GetRawText(), options);
                }
                else
                {
                    throw new JsonException("Unknown category.");
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, CategoryDto value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }
}
