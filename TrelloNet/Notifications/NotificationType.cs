using Newtonsoft.Json;
using TrelloNet.Internal;

namespace TrelloNet
{
	[JsonConverter(typeof(TrelloEnumConverter))]
	public enum NotificationType
	{
		AddedToBoard,
		AddedToCard,
		AddAdminToBoard,
		AddAdminToOrganization,
		ChangeCard,
		CloseBoard,
		CommentCard,
		InvitedToBoard,
		InvitedToOrganization,
		RemovedFromBoard,
		RemovedFromCard,
		RemovedFromOrganization,
		MentionedOnCard
	}
}