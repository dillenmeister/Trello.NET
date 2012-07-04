using System.Collections.Generic;

namespace TrelloNet.Extensions
{
	public class AutoPagedActions : AutoPaged
	{
		private readonly IActions _trelloActions;

		internal AutoPagedActions(IActions trelloActions, int pageSize)
			: base(pageSize)
		{
			_trelloActions = trelloActions;
		}

		public IEnumerable<Action> ForMe(IEnumerable<ActionType> filter = null, ISince since = null)
		{
			var currentPage = 0;
			return AutoPage(() => _trelloActions.ForMe(filter, since, new Paging(_pageSize, currentPage++)));
		}

		public IEnumerable<Action> ForBoard(IBoardId board, IEnumerable<ActionType> filter = null, ISince since = null)
		{
			var currentPage = 0;
			return AutoPage(() => _trelloActions.ForBoard(board, filter, since, new Paging(_pageSize, currentPage++)));
		}

		public IEnumerable<Action> ForCard(ICardId card, IEnumerable<ActionType> filter = null, ISince since = null)
		{
			var currentPage = 0;
			return AutoPage(() => _trelloActions.ForCard(card, filter, since, new Paging(_pageSize, currentPage++)));
		}

		public IEnumerable<Action> ForList(IListId list, IEnumerable<ActionType> filter = null, ISince since = null)
		{
			var currentPage = 0;
			return AutoPage(() => _trelloActions.ForList(list, filter, since, new Paging(_pageSize, currentPage++)));
		}

		public IEnumerable<Action> ForMember(IMemberId member, IEnumerable<ActionType> filter = null, ISince since = null)
		{
			var currentPage = 0;
			return AutoPage(() => _trelloActions.ForMember(member, filter, since, new Paging(_pageSize, currentPage++)));
		}

		public IEnumerable<Action> ForOrganization(IOrganizationId organization, IEnumerable<ActionType> filter = null, ISince since = null)
		{
			var currentPage = 0;
			return AutoPage(() => _trelloActions.ForOrganization(organization, filter, since, new Paging(_pageSize, currentPage++)));
		}
	}
}