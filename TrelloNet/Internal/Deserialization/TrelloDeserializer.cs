using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace TrelloNet.Internal.Deserialization
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
}