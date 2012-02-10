using System.Collections.Generic;

namespace TrelloNet
{
	public interface IChecklists
	{
		Checklist GetById(string checklistId);
		IEnumerable<Checklist> GetByBoard(IBoardId board);
		IEnumerable<Checklist> GetByCard(ICardId card);
	}
}