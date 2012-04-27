using System;
using System.Collections.Generic;
using System.Linq;

namespace TrelloNet.Extensions
{
	public static class AutoPagerExtensions
	{
		public static IEnumerable<Action> ForMeAutoPaged(this IActions trelloActions, int pageSize = 50, IEnumerable<ActionType> filter = null, ISince since = null)
		{
			if (pageSize >= Paging.MaxLimit) pageSize = Paging.MaxLimit;
			var currentPage = 0;

			return AutoPage(() => trelloActions.ForMe(filter, since, new Paging(pageSize, currentPage++)));
		}

		public static IEnumerable<Action> ForBoardAutoPaged(this IActions trelloActions, IBoardId board, int pageSize = 50, IEnumerable<ActionType> filter = null, ISince since = null)
		{
			if (pageSize >= Paging.MaxLimit) pageSize = Paging.MaxLimit;
			var currentPage = 0;

			return AutoPage(() => trelloActions.ForBoard(board, filter, since, new Paging(pageSize, currentPage++)));
		}

		public static IEnumerable<Action> ForCardAutoPaged(this IActions trelloActions, ICardId card, int pageSize = 50, IEnumerable<ActionType> filter = null, ISince since = null)
		{
			if (pageSize >= Paging.MaxLimit) pageSize = Paging.MaxLimit;
			var currentPage = 0;

			return AutoPage(() => trelloActions.ForCard(card, filter, since, new Paging(pageSize, currentPage++)));
		}

		public static IEnumerable<Action> ForListAutoPaged(this IActions trelloActions, IListId list, int pageSize = 50, IEnumerable<ActionType> filter = null, ISince since = null)
		{
			if (pageSize >= Paging.MaxLimit) pageSize = Paging.MaxLimit;
			var currentPage = 0;

			return AutoPage(() => trelloActions.ForList(list, filter, since, new Paging(pageSize, currentPage++)));
		}

		public static IEnumerable<Action> ForMemberAutoPaged(this IActions trelloActions, IMemberId member, int pageSize = 50, IEnumerable<ActionType> filter = null, ISince since = null)
		{
			if (pageSize >= Paging.MaxLimit) pageSize = Paging.MaxLimit;
			var currentPage = 0;

			return AutoPage(() => trelloActions.ForMember(member, filter, since, new Paging(pageSize, currentPage++)));
		}

		public static IEnumerable<Action> ForOrganizationAutoPaged(this IActions trelloActions, IOrganizationId organization, int pageSize = 50, IEnumerable<ActionType> filter = null, ISince since = null)
		{
			if (pageSize >= Paging.MaxLimit) pageSize = Paging.MaxLimit;
			var currentPage = 0;

			return AutoPage(() => trelloActions.ForOrganization(organization, filter, since, new Paging(pageSize, currentPage++)));
		}

		private static IEnumerable<Action> AutoPage(Func<IEnumerable<Action>> fetchActions)
		{
			while (true)
			{
				var actions = fetchActions().ToList();				

				if (!actions.Any())
					yield break;

				foreach (var action in actions)
					yield return action;
			}
		}
	}
}