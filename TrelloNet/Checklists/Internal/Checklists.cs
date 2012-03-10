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
			return _restClient.Request<Checklist>(new ChecklistsRequest(checklistId));
		}

		public IEnumerable<Checklist> ForBoard(IBoardId board)
		{
			return _restClient.Request<List<Checklist>>(new ChecklistsForBoardRequest(board));
		}

		public IEnumerable<Checklist> ForCard(ICardId card)
		{
			return _restClient.Request<List<Checklist>>(new ChecklistsForCardRequest(card));
		}

		public Checklist Add(string name, IBoardId board)
		{
			return _restClient.Request<Checklist>(new ChecklistsAddRequest(board, name));
		}

		public void ChangeName(IChecklistId checklist, string name)
		{
			_restClient.Request(new ChecklistsChangeNameRequest(checklist, name));
		}

		public void AddCheckItem(IChecklistId checklist, string name)
		{
			_restClient.Request(new ChecklistsAddCheckItemRequest(checklist, name));
		}

		public void RemoveCheckItem(IChecklistId checklist, string checkItemId)
		{
			_restClient.Request(new ChecklistsRemoveCheckItemRequest(checklist, checkItemId));
		}
	}
}