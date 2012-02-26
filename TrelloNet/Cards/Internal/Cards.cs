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
			_restClient.Request(new CardsDeleteRequest(card));
		}

		public void Archive(ICardId card)
		{
			Guard.NotNull(card, "card");
			_restClient.Request(new CardsArchiveRequest(card));
		}

		public void SendToBoard(ICardId card)
		{
			Guard.NotNull(card, "card");
			_restClient.Request(new CardsSendToBoardRequest(card));
		}

		public void ChangeDescription(ICardId card, string description)
		{
			Guard.NotNull(card, "card");
			Guard.NotNull(description, "description");
			_restClient.Request(new CardsChangeDescriptionRequest(card, description));
		}

		public void ChangeName(ICardId card, string name)
		{
			Guard.NotNull(card, "card");
			Guard.NotNullOrEmpty(name, "name");
			_restClient.Request(new CardsChangeNameRequest(card, name));
		}

		public void ChangeDueDate(ICardId card, DateTime? due)
		{
			Guard.NotNull(card, "card");
			_restClient.Request(new CardsChangeDueDateRequest(card, due));
		}

		public void Move(ICardId card, IListId list)
		{
			Guard.NotNull(card, "card");
			Guard.NotNull(list, "list");
			_restClient.Request(new CardsMoveRequest(card, list));
		}

		public void AddLabel(ICardId card, Color color)
		{
			Guard.NotNull(card, "card");
			_restClient.Request(new CardsAddLabelRequest(card, color));
		}

		public void RemoveLabel(ICardId card, Color color)
		{
			Guard.NotNull(card, "card");
			_restClient.Request(new CardsRemoveLabelRequest(card, color));
		}

		public void AddMember(ICardId card, IMemberId member)
		{
			Guard.NotNull(card, "card");
			Guard.NotNull(member, "member");
			_restClient.Request(new CardsAddMemberRequest(card, member));
		}

		public void RemoveMember(ICardId card, IMemberId member)
		{
			Guard.NotNull(card, "card");
			Guard.NotNull(member, "member");
			_restClient.Request(new CardsRemoveMemberRequest(card, member));
		}

		public void AddComment(ICardId card, string comment)
		{
			Guard.NotNull(card, "card");
			Guard.NotNullOrEmpty(comment, "comment");

			_restClient.Request(new CardsAddCommentRequest(card, comment));
		}

		public void AddChecklist(ICardId card, IChecklistId checklist)
		{
			Guard.NotNull(card, "card");
			Guard.NotNull(checklist, "checklist");

			_restClient.Request(new CardsAddChecklistRequest(card, checklist));
		}

		public void RemoveChecklist(ICardId card, IChecklistId checklist)
		{
			Guard.NotNull(card, "card");
			Guard.NotNull(checklist, "checklist");

			_restClient.Request(new CardsRemoveChecklistRequest(card, checklist));
		}
	}
}