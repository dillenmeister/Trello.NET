using Newtonsoft.Json;
using TrelloNet.Internal;

namespace TrelloNet
{
	[JsonConverter(typeof(TrelloEnumConverter))]
	public enum AvatarSource
	{
		Unknown = 0,
		None,
		Upload,
		Gravatar
	}
}