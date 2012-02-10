using System.Collections.Generic;
using TrelloNet.Internal.Requests;

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
			return _restClient.Request<Checklist>(new ChecklistRequest(checklistId));
		}

		public IEnumerable<Checklist> GetByBoard(IBoardId board)
		{
			return _restClient.Request<List<Checklist>>(new BoardChecklistsRequest(board));
		}

		public IEnumerable<Checklist> GetByCard(ICardId card)
		{
			return _restClient.Request<List<Checklist>>(new CardChecklistsRequest(card));
		}
	}
}