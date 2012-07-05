using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet.Internal
{
	internal class AsyncCards : IAsyncCards
	{
		private readonly TrelloRestClient _restClient;

		public AsyncCards(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Task<Card> WithId(string cardId)
		{
			return _restClient.RequestAsync<Card>(new CardsRequest(cardId));
		}

		public Task<Card> WithShortId(int shortId, IBoardId boardId)
		{
			return _restClient.RequestAsync<Card>(new CardsWithShortIdRequest(shortId, boardId));
		}

		public Task<IEnumerable<Card>> ForBoard(IBoardId board, BoardCardFilter filter = BoardCardFilter.Visible)
		{
			return _restClient.RequestListAsync<Card>(new CardsForBoardRequest(board, filter));
		}

		public Task<IEnumerable<Card>> ForList(IListId list, CardFilter filter = CardFilter.Open)
		{
			return _restClient.RequestListAsync<Card>(new CardsForListRequest(list, filter));
		}

		public Task<IEnumerable<Card>> ForMember(IMemberId member, CardFilter filter = CardFilter.Open)
		{
			return _restClient.RequestListAsync<Card>(new CardsForMemberRequest(member, filter));
		}

		public Task<IEnumerable<Card>> ForMe(CardFilter filter = CardFilter.Open)
		{
			return ForMember(new Me(), filter);
		}

		public Task<IEnumerable<Card>> ForChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Open)
		{
			return _restClient.RequestListAsync<Card>(new CardsForChecklistRequest(checklist, filter));
		}

		public Task<Card> Add(NewCard card)
		{
			return _restClient.RequestAsync<Card>(new CardsAddRequest(card));
		}

		public Task<Card> Add(string name, IListId list)
		{
			return Add(new NewCard(name, list));
		}

		public Task Delete(ICardId card)
		{
			return _restClient.RequestAsync(new CardsDeleteRequest(card));
		}

		public Task Archive(ICardId card)
		{
			return _restClient.RequestAsync(new CardsArchiveRequest(card));
		}

		public Task SendToBoard(ICardId card)
		{
			return _restClient.RequestAsync(new CardsSendToBoardRequest(card));
		}

		public Task ChangeDescription(ICardId card, string description)
		{
			return _restClient.RequestAsync(new CardsChangeDescriptionRequest(card, description));
		}

		public Task ChangeName(ICardId card, string name)
		{
			return _restClient.RequestAsync(new CardsChangeNameRequest(card, name));
		}

		public Task ChangeDueDate(ICardId card, DateTime? due)
		{
			return _restClient.RequestAsync(new CardsChangeDueDateRequest(card, due));
		}

		public Task Move(ICardId card, IListId list)
		{
			return _restClient.RequestAsync(new CardsMoveRequest(card, list));
		}

		public Task AddLabel(ICardId card, Color color)
		{
			return _restClient.RequestAsync(new CardsAddLabelRequest(card, color));
		}

		public Task RemoveLabel(ICardId card, Color color)
		{
			return _restClient.RequestAsync(new CardsRemoveLabelRequest(card, color));
		}

		public Task AddMember(ICardId card, IMemberId member)
		{
			return _restClient.RequestAsync(new CardsAddMemberRequest(card, member));
		}

		public Task RemoveMember(ICardId card, IMemberId member)
		{
			return _restClient.RequestAsync(new CardsRemoveMemberRequest(card, member));
		}

		public Task AddComment(ICardId card, string comment)
		{
			return _restClient.RequestAsync(new CardsAddCommentRequest(card, comment));
		}

		public Task AddChecklist(ICardId card, IChecklistId checklist)
		{
			return _restClient.RequestAsync(new CardsAddChecklistRequest(card, checklist));
		}

		public Task RemoveChecklist(ICardId card, IChecklistId checklist)
		{
			return _restClient.RequestAsync(new CardsRemoveChecklistRequest(card, checklist));
		}

		public Task Update(IUpdatableCard card)
		{
			return _restClient.RequestAsync(new CardsUpdateRequest(card));
		}

		public Task<IEnumerable<Card>> Search(string query, int limit = 10, SearchFilter filter = null)
		{
			return _restClient.RequestAsync<SearchResults>(new SearchRequest(query, limit, filter, new[] { ModelType.Cards }))
				.ContinueWith<IEnumerable<Card>>(r => r.Result.Cards);				
		}
	}
}