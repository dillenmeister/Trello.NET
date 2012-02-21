using System;
using System.Collections.Generic;

namespace TrelloNet
{
	public interface ICards
	{
		Card WithId(string cardId);
		Card WithShortId(int shortId, IBoardId boardId);
		IEnumerable<Card> ForBoard(IBoardId board, CardFilter filter = CardFilter.Default);
		IEnumerable<Card> ForList(IListId list, CardFilter filter = CardFilter.Default);
		IEnumerable<Card> ForMember(IMemberId member, CardFilter filter = CardFilter.Default);
		IEnumerable<Card> ForChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Default);
		Card Add(NewCard card);
		void Delete(ICardId card);
		void Archive(ICardId card);
		void SendToBoard(ICardId card);
		void ChangeDescription(ICardId card, string description);
		void ChangeName(ICardId card, string name);		
	}
}