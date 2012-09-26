using Newtonsoft.Json;
using TrelloNet.Internal;

namespace TrelloNet
{
	[JsonConverter(typeof(TrelloEnumConverter))]
	public enum InvitationPermission
	{
		Unknown = 0,
		Members,
		Owners,
        Admins
	}
}