using System;
using System.Collections.Generic;

namespace TrelloNet
{
	public interface ITrello
	{
		IMembers Members { get; }
		IBoards Boards { get; }
		void Authenticate(string token);
		Uri GetAuthenticationUrl(string applicationName);
		List List(string listId);
		List List(ICardId card);
		IEnumerable<List> Lists(IBoardId board, ListFilter filter = ListFilter.None);
		IEnumerable<Card> Cards(IBoardId board, CardFilter filter = CardFilter.Open);
		IEnumerable<Card> Cards(IListId list, CardFilter filter = CardFilter.Open);
		IEnumerable<Card> Cards(IMemberId member, CardFilter filter = CardFilter.Open);
		IEnumerable<Card> Cards(IChecklistId checklist, CardFilter filter = CardFilter.Open);
		Card Card(string cardId);
		IEnumerable<Checklist> Checklists(IBoardId board);
		IEnumerable<Checklist> Checklists(ICardId card);
		Checklist Checklist(string checkListId);
		Organization Organization(string orgIdOrName);
		Organization Organization(IBoardId board);
		IEnumerable<Organization> Organizations(IMemberId member, OrganizationFilter filter = OrganizationFilter.All);
	}
}