namespace TrelloNet
{
	public class BoardPreferences
	{
		public InvitationPermission Invitations { get; set; }
		public CommentPermission Comments { get; set; }
		public VotingPermission Voting { get; set; }
		public PermissionLevel PermissionLevel { get; set; }
	}
}