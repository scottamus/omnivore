using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace OmnivoreClassLibrary.Helpers
{
    /// <summary>
    /// For converting from the int version of price in the Omnivore API (175),
    /// and the decimal version in .NET, with 2 decimal places (1.75).
    /// Also converts back to the int version when writing JSON.
    /// TODO: Unit Test!!!!!
    /// </summary>
    public class CurrencyConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(int));
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.FormatException"></exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Integer || reader.TokenType != JsonToken.Float)
            {
                throw new Exception(
                    String.Format("Unexpected token parsing date. Expected Integer or Float, got {0}.",
                    reader.TokenType));
            }

            JValue jsonValue = serializer.Deserialize<JValue>(reader);

            if (jsonValue.Type == JTokenType.Integer)
            {
                return (decimal)jsonValue.Value<int>()/100; // insert decimal place in right spot
            }
            else if (jsonValue.Type == JTokenType.Float)
            {
                return (decimal)Math.Round(jsonValue.Value<decimal>(), 2); // round to 2 decimal places
            }

            throw new FormatException();
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <exception cref="System.FormatException">Valid Decimal value should have no more than two decimal places.</exception>
        /// <exception cref="System.Exception">Expected decimal value.</exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            int intValue;

            if (value is decimal)
            {
                if (IsValidDecimal((decimal)value))
                {
                    intValue = (int)((decimal)value * 100);
                }
                else
                {
                    throw new FormatException("Valid Decimal value should have no more than two decimal places.");
                }
            }
            else
            {
                throw new Exception("Expected decimal value.");
            }

            writer.WriteValue(intValue);
        }

        /// <summary>
        /// Determines whether [is valid decimal] [the specified d].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns></returns>
        private bool IsValidDecimal(decimal d)
        {
            return decimal.Round(d, 2) == d;
        }
    }
}
