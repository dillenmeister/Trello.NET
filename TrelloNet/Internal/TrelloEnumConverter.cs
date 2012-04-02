using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace TrelloNet.Internal
{
	/// <summary>
	/// If the enum member we are trying to deserialize to is not found, it will return the first value in the enum instead of throwing.
	/// </summary>
	internal class TrelloEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			try
			{
				return Enum.Parse(objectType, reader.Value.ToString(), ignoreCase: true);
			}
			catch (ArgumentException)
			{				
				return objectType
				  .GetFields(BindingFlags.Static | BindingFlags.Public)				  
				  .First()
				  .GetValue(null);
			}
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType.IsEnum;
		}
	}
}