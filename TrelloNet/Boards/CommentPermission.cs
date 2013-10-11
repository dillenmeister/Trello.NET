using Newtonsoft.Json;
using TrelloNet.Internal;

namespace TrelloNet
{
	[JsonConverter(typeof(TrelloEnumConverter))]
	public enum CommentPermission
	{
		Unknown = 0,
		Disabled,
		Members,
		Observers,
		Org,
		Public
	}
}