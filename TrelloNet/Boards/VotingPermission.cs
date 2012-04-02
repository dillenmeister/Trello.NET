using Newtonsoft.Json;
using TrelloNet.Internal;

namespace TrelloNet
{
	[JsonConverter(typeof(TrelloEnumConverter))]
	public enum VotingPermission
	{
		Unknown = 0,
		Disabled,
		Members,
		Org,
		Public
	}
}