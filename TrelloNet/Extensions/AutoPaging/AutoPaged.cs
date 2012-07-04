using System;
using System.Collections.Generic;
using System.Linq;

namespace TrelloNet.Extensions
{
	public class AutoPaged
	{
		private readonly IActions _trelloActions;
		private readonly int _pageSize;

		internal AutoPaged(IActions trelloActions, int pageSize)
		{
			_trelloActions = trelloActions;
			_pageSize = pageSize >= Paging.MaxLimit ? Paging.MaxLimit : pageSize;
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

		private IEnumerable<Action> AutoPage(Func<IEnumerable<Action>> fetchActions)
		{
			while (true)
			{
				var actions = fetchActions().ToList();

				if (actions.Count < _pageSize)
					yield break;

				foreach (var action in actions)
					yield return action;
			}
		}
	}
}