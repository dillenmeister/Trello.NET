namespace TrelloNet
{
	public interface IAsyncTrello
	{
		IAsyncMembers Members { get; }
		IAsyncBoards Boards { get; }
		IAsyncLists Lists { get; }
		IAsyncCards Cards { get; }
		IAsyncChecklists Checklists { get; }
		IAsyncOrganizations Organizations { get; }
		IAsyncNotifications Notifications { get; }
		IAsyncTokens Tokens { get; }
		IAsyncActions Actions { get; }
	}
}