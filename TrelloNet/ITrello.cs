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
		void Authenticate(string token);
		Uri GetAuthenticationUrl(string applicationName);		
		Organization Organization(string orgIdOrName);
		Organization Organization(IBoardId board);
		IEnumerable<Organization> Organizations(IMemberId member, OrganizationFilter filter = OrganizationFilter.All);
	}
}