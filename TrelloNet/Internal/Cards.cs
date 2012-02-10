using System.Collections.Generic;
using TrelloNet.Internal.Requests;

namespace TrelloNet.Internal
{
	internal class Cards : ICards
	{
		private readonly TrelloRestClient _restClient;

		public Cards(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Card GetById(string cardId)
		{
			Guard.NotNullOrEmpty(cardId, "cardId");
			return _restClient.Request<Card>(new CardRequest(cardId));
		}

		public IEnumerable<Card> GetByBoard(IBoardId board, CardFilter filter = CardFilter.Default)
		{
			Guard.NotNull(board, "board");
			return _restClient.Request<List<Card>>(new BoardCardsRequest(board, filter));
		}

		public IEnumerable<Card> GetByList(IListId list, CardFilter filter = CardFilter.Default)
		{
			Guard.NotNull(list, "list");
			return _restClient.Request<List<Card>>(new ListCardsRequest(list, filter));
		}

		public IEnumerable<Card> GetByMember(IMemberId member, CardFilter filter = CardFilter.Default)
		{
			Guard.NotNull(member, "member");
			return _restClient.Request<List<Card>>(new MemberCardsRequest(member, filter));
		}

		public IEnumerable<Card> GetByChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Default)
		{
			Guard.NotNull(checklist, "checklist");
			return _restClient.Request<List<Card>>(new ChecklistCardsRequest(checklist, filter));
		}
	}
}