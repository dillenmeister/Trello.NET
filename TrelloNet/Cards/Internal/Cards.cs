using System;
using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class Cards : ICards
	{
		private readonly TrelloRestClient _restClient;

		public Cards(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Card WithId(string cardId)
		{
			return _restClient.Request<Card>(new CardsRequest(cardId));
		}

		public Card WithShortId(int shortId, IBoardId boardId)
		{
			return _restClient.Request<Card>(new CardsWithShortIdRequest(shortId, boardId));
		}

		public IEnumerable<Card> ForBoard(IBoardId board, BoardCardFilter filter = BoardCardFilter.Visible)
		{
			return _restClient.Request<List<Card>>(new CardsForBoardRequest(board, filter));
		}

		public IEnumerable<Card> ForList(IListId list, CardFilter filter = CardFilter.Open)
		{
			return _restClient.Request<List<Card>>(new CardsForListRequest(list, filter));
		}

		public IEnumerable<Card> ForMember(IMemberId member, CardFilter filter = CardFilter.Open)
		{
			return _restClient.Request<List<Card>>(new CardsForMemberRequest(member, filter));
		}

		public IEnumerable<Card> ForMe(CardFilter filter = CardFilter.Open)
		{
			return ForMember(new Me(), filter);
		}

		public IEnumerable<Card> ForChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Open)
		{
			return _restClient.Request<List<Card>>(new CardsForChecklistRequest(checklist, filter));
		}

		public Card Add(NewCard card)
		{
			return _restClient.Request<Card>(new CardsAddRequest(card));
		}

		public Card Add(string name, IListId list)
		{
			return Add(new NewCard(name, list));
		}

		public void Delete(ICardId card)
		{
			_restClient.Request(new CardsDeleteRequest(card));
		}

		public void Archive(ICardId card)
		{
			_restClient.Request(new CardsArchiveRequest(card));
		}

		public void SendToBoard(ICardId card)
		{
			_restClient.Request(new CardsSendToBoardRequest(card));
		}

		public void ChangeDescription(ICardId card, string description)
		{
			_restClient.Request(new CardsChangeDescriptionRequest(card, description));
		}

		public void ChangeName(ICardId card, string name)
		{
			_restClient.Request(new CardsChangeNameRequest(card, name));
		}

		public void ChangeDueDate(ICardId card, DateTime? due)
		{
			_restClient.Request(new CardsChangeDueDateRequest(card, due));
		}

		public void Move(ICardId card, IListId list)
		{
			_restClient.Request(new CardsMoveRequest(card, list));
		}

		public void AddLabel(ICardId card, Color color)
		{
			_restClient.Request(new CardsAddLabelRequest(card, color));
		}

		public void RemoveLabel(ICardId card, Color color)
		{
			_restClient.Request(new CardsRemoveLabelRequest(card, color));
		}

		public void AddMember(ICardId card, IMemberId member)
		{
			_restClient.Request(new CardsAddMemberRequest(card, member));
		}

		public void RemoveMember(ICardId card, IMemberId member)
		{
			_restClient.Request(new CardsRemoveMemberRequest(card, member));
		}

		public void AddComment(ICardId card, string comment)
		{
			_restClient.Request(new CardsAddCommentRequest(card, comment));
		}

		public void AddChecklist(ICardId card, IChecklistId checklist)
		{
			_restClient.Request(new CardsAddChecklistRequest(card, checklist));
		}

		public void RemoveChecklist(ICardId card, IChecklistId checklist)
		{
			_restClient.Request(new CardsRemoveChecklistRequest(card, checklist));
		}

		public void Update(IUpdatableCard card)
		{
			_restClient.Request(new CardsUpdateRequest(card));
		}

		public IEnumerable<Card> Search(string query, int limit = 10, SearchFilter filter = null)
		{
			return _restClient.Request<SearchResults>(new SearchRequest(query, limit, filter, new[] { ModelType.Cards })).Cards;					
		}
	}
}