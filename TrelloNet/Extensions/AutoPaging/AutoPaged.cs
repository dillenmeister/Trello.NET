using System;
using System.Collections.Generic;
using System.Linq;

namespace TrelloNet.Extensions
{
	public class AutoPaged
	{
		protected readonly int _pageSize;

		public AutoPaged(int pageSize)
		{
			_pageSize = pageSize >= Paging.MaxLimit ? Paging.MaxLimit : pageSize;
		}

		protected IEnumerable<T> AutoPage<T>(Func<IEnumerable<T>> fetch)
		{
			while (true)
			{
				var items = fetch().ToList();

				foreach (var item in items)
					yield return item;

				if (items.Count < _pageSize)
					yield break;
			}
		}
	}
}