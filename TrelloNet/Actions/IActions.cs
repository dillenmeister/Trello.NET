using System.Collections.Generic;

namespace TrelloNet
{
	public interface IActions
	{
		Action WithId(string actionId);
		IEnumerable<Action> ForBoard(IBoardId board, ISince since = null, Paging paging = null);
	}
}