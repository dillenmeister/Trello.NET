using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace TrelloNet.Internal
{
	internal class TrelloDeserializer : IDeserializer
	{		
		public T Deserialize<T>(IRestResponse response)
		{
			return JsonConvert.DeserializeObject<T>(response.Content, new NotificationConverter(), new ActionConverter());
		}

		// We have some abstraction leakage here since we don't care about these things.
		public string RootElement { get; set; }
		public string Namespace { get; set; }
		public string DateFormat { get; set; }
	}
}