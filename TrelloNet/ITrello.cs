using System;
using System.Collections.Generic;

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
		IActions Actions { get; }
		SearchResults Search(string query, IEnumerable<ModelType> modelTypes = null, int limit = 10);
		void Authorize(string token);
		void Deauthorize();
		Uri GetAuthorizationUrl(string applicationName, Scope scope, Expiration expiration = Expiration.ThirtyDays);
	}
}