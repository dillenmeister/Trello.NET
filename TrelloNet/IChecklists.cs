using System.Collections.Generic;

namespace TrelloNet
{
	public interface IChecklists
	{
		Checklist GetById(string checklistId);
		IEnumerable<Checklist> GetByBoard(string boardId);
		IEnumerable<Checklist> GetByCard(string cardId);
	}
}