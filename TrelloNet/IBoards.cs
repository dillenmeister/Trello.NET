using System.Collections.Generic;

namespace TrelloNet
{
	public interface IBoards
	{
		Board GetById(string boardId);
		Board GetByCard(string cardId);
		Board GetByChecklist(string checklistId);
		Board GetByList(string listId);
		IEnumerable<Board> GetByMember(string memberId, BoardFilter filter = BoardFilter.Default);
		IEnumerable<Board> GetByOrganization(string organizationId, BoardFilter filter = BoardFilter.Default);
	}
}