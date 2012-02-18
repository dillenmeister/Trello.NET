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

		public Checklist GetById(string checklistId)
		{
			Guard.NotNullOrEmpty(checklistId, "checklistId");
			return _restClient.Request<Checklist>(new ChecklistRequest(checklistId));
		}

		public IEnumerable<Checklist> GetByBoard(IBoardId board)
		{
			Guard.NotNull(board, "board");
			return _restClient.Request<List<Checklist>>(new BoardChecklistsRequest(board));
		}

		public IEnumerable<Checklist> GetByCard(ICardId card)
		{
			Guard.NotNull(card, "card");
			return _restClient.Request<List<Checklist>>(new CardChecklistsRequest(card));
		}
	}
}