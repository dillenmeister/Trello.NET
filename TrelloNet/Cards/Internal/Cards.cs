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
			return _restClient.Request<Card>(new CardRequest(cardId));
		}

		public IEnumerable<Card> ForBoard(IBoardId board, CardFilter filter = CardFilter.Default)
		{
			Guard.NotNull(board, "board");
			return _restClient.Request<List<Card>>(new BoardCardsRequest(board, filter));
		}

		public IEnumerable<Card> ForList(IListId list, CardFilter filter = CardFilter.Default)
		{
			Guard.NotNull(list, "list");
			return _restClient.Request<List<Card>>(new ListCardsRequest(list, filter));
		}

		public IEnumerable<Card> ForMember(IMemberId member, CardFilter filter = CardFilter.Default)
		{
			Guard.NotNull(member, "member");
			return _restClient.Request<List<Card>>(new MemberCardsRequest(member, filter));
		}

		public IEnumerable<Card> ForChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Default)
		{
			Guard.NotNull(checklist, "checklist");
			return _restClient.Request<List<Card>>(new ChecklistCardsRequest(checklist, filter));
		}
	}
}