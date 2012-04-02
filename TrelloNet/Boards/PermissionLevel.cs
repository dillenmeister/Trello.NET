using Newtonsoft.Json;
using TrelloNet.Internal;

namespace TrelloNet
{
	[JsonConverter(typeof(TrelloEnumConverter))]
	public enum PermissionLevel
	{
		Unknown = 0,
		Private,
		Org,
		Public
	}
}