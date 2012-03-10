using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncChecklists
	{
		Task<Checklist> WithId(string checklistId);
		Task<IEnumerable<Checklist>> ForBoard(IBoardId board);
		Task<IEnumerable<Checklist>> ForCard(ICardId card);
		Task<Checklist> Add(string name, IBoardId board);
		Task ChangeName(IChecklistId checklist, string name);
		Task AddCheckItem(IChecklistId checklist, string name);
		Task RemoveCheckItem(IChecklistId checklist, string checkItemId);
	}
}