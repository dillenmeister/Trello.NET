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
		void Authenticate(string token);
		Uri GetAuthenticationUrl(string applicationName);		
		IEnumerable<Checklist> Checklists(IBoardId board);
		IEnumerable<Checklist> Checklists(ICardId card);
		Checklist Checklist(string checkListId);
		Organization Organization(string orgIdOrName);
		Organization Organization(IBoardId board);
		IEnumerable<Organization> Organizations(IMemberId member, OrganizationFilter filter = OrganizationFilter.All);
	}
}