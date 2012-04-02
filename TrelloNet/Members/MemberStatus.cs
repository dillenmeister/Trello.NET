using Newtonsoft.Json;
using TrelloNet.Internal;

namespace TrelloNet
{
	[JsonConverter(typeof(TrelloEnumConverter))]
	public enum MemberStatus
	{
		Unknown = 0,
		Active,
		Idle,
		Disconnected
	}
}