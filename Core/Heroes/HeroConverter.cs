using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    /// <summary>
    /// This is a class for converting derived types using JSON
    /// </summary>
    /// <seealso cref="System.Text.Json.Serialization.JsonConverter&lt;IOT1030_Phase2_GUI.Core.Heroes.Hero&gt;" />
    public class HeroConverter : JsonConverter<Hero>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(Hero).IsAssignableFrom(typeToConvert);
        }

        public override Hero Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                //if the property isn't there, let it blow up
                switch (jsonDoc.RootElement.GetProperty("Type").GetString())
                {
                    case nameof(Archer):
                        return jsonDoc.RootElement.Deserialize<Archer>(options);
                    case nameof(King):
                        return jsonDoc.RootElement.Deserialize<King>(options);
                    case nameof(Knight):
                        return jsonDoc.RootElement.Deserialize<Knight>(options);
                    case nameof(Mage):
                        return jsonDoc.RootElement.Deserialize<Mage>(options);
                    case nameof(Player):
                        return jsonDoc.RootElement.Deserialize<Player>(options);
                    case nameof(Queen):
                        return jsonDoc.RootElement.Deserialize<Queen>(options);
                    //warning: If you're not using the JsonConverter attribute approach,
                    //make a copy of options without this converter
                    default:
                        throw new JsonException("'Type' doesn't match a known derived type");
                }

            }
        }

        public override void Write(Utf8JsonWriter writer, Hero hero, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)hero, options);
            //warning: If you're not using the JsonConverter attribute approach,
            //make a copy of options without this converter
        }
    }
}
