using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Deserializers;

namespace TrelloNet.Internal
{
	internal class TrelloDeserializer : IDeserializer
	{		
		public T Deserialize<T>(RestResponse response) where T : new()
		{
			return JsonConvert.DeserializeObject<T>(response.Content, new NotificationConverter());
		}

		// We have some abstraction leakage here since we don't care about these things.
		public string RootElement { get; set; }
		public string Namespace { get; set; }
		public string DateFormat { get; set; }
	}

	public class NotificationConverter : JsonCreationConverter<Notification>
	{
		protected override Notification Create(Type objectType, JObject jObject)
		{
			if (jObject["type"].ToObject<NotificationType>() == NotificationType.AddedToCard)
				return new AddedToCardNotification();

			return new Notification();
		}
	}

	public abstract class JsonCreationConverter<T> : JsonConverter
	{
		/// <summary>
		/// Create an instance of objectType, based properties in the JSON object
		/// </summary>
		/// <param name="objectType">type of object expected</param>
		/// <param name="jObject">contents of JSON object that will be deserialized</param>
		/// <returns></returns>
		protected abstract T Create(Type objectType, JObject jObject);

		public override bool CanConvert(Type objectType)
		{
			return typeof(T).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			// Load JObject from stream
			JObject jObject = JObject.Load(reader);

			// Create target object based on JObject
			T target = Create(objectType, jObject);

			// Populate the object properties
			serializer.Populate(jObject.CreateReader(), target);

			return target;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}