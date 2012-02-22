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
			Guard.NotNullOrEmpty(cardId, "cardId");
			return _restClient.Request<Card>(new CardsRequest(cardId));
		}

		public Card WithShortId(int shortId, IBoardId boardId)
		{
			Guard.NotNull(boardId, "boardId");
			return _restClient.Request<Card>(new CardsWithShortIdRequest(shortId, boardId));
		}

		public IEnumerable<Card> ForBoard(IBoardId board, CardFilter filter = CardFilter.Default)
		{
			Guard.NotNull(board, "board");
			return _restClient.Request<List<Card>>(new CardsForBoardRequest(board, filter));
		}

		public IEnumerable<Card> ForList(IListId list, CardFilter filter = CardFilter.Default)
		{
			Guard.NotNull(list, "list");
			return _restClient.Request<List<Card>>(new CardsForListRequest(list, filter));
		}

		public IEnumerable<Card> ForMember(IMemberId member, CardFilter filter = CardFilter.Default)
		{
			Guard.NotNull(member, "member");
			return _restClient.Request<List<Card>>(new CardsForMemberRequest(member, filter));
		}

		public IEnumerable<Card> ForChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Default)
		{
			Guard.NotNull(checklist, "checklist");
			return _restClient.Request<List<Card>>(new CardsForChecklistRequest(checklist, filter));
		}

		public Card Add(NewCard card)
		{
			Guard.NotNull(card, "card");
			return _restClient.Request<Card>(new CardsAddRequest(card));
		}

		public void Delete(ICardId card)
		{
			Guard.NotNull(card, "card");
			_restClient.Request<object>(new CardsDeleteRequest(card));
		}

		public void Archive(ICardId card)
		{
			Guard.NotNull(card, "card");
			_restClient.Request<object>(new CardsArchiveRequest(card));
		}

		public void SendToBoard(ICardId card)
		{
			Guard.NotNull(card, "card");
			_restClient.Request<object>(new CardsSendToBoardRequest(card));
		}

		public void ChangeDescription(ICardId card, string description)
		{
			Guard.NotNull(card, "card");
			Guard.NotNull(description, "description");
			_restClient.Request<object>(new CardsChangeDescriptionRequest(card, description));
		}

		public void ChangeName(ICardId card, string name)
		{
			Guard.NotNull(card, "card");
			Guard.NotNullOrEmpty(name, "name");
			_restClient.Request<object>(new CardsChangeNameRequest(card, name));
		}

		public void Move(ICardId card, IListId list)
		{
			Guard.NotNull(card, "card");
			Guard.NotNull(list, "list");
			_restClient.Request<object>(new CardsMoveRequest(card, list));
		}
	}
}