using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class Checklists : IChecklists
	{
		private readonly TrelloRestClient _restClient;

		public Checklists(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Checklist WithId(string checklistId)
		{
			Guard.NotNullOrEmpty(checklistId, "checklistId");
			return _restClient.Request<Checklist>(new ChecklistsRequest(checklistId));
		}

		public IEnumerable<Checklist> ForBoard(IBoardId board)
		{
			Guard.NotNull(board, "board");
			return _restClient.Request<List<Checklist>>(new ChecklistsForBoardRequest(board));
		}

		public IEnumerable<Checklist> ForCard(ICardId card)
		{
			Guard.NotNull(card, "card");
			return _restClient.Request<List<Checklist>>(new ChecklistsForCardRequest(card));
		}
	}
}