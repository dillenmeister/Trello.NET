using System;

namespace TrelloNet
{
	public interface ITrello
	{
		IMembers Members { get; }
		IBoards Boards { get; }
		ILists Lists { get; }
		ICards Cards { get; }
		IChecklists Checklists { get; }
		IOrganizations Organizations { get; }
		INotifications Notifications { get; }
		ITokens Tokens { get; }
		IAsyncTrello Async { get; }
		void Authorize(string token);
		Uri GetAuthorizationUrl(string applicationName, Scope scope, Expiration expiration = Expiration.ThirtyDays);				
	}
}