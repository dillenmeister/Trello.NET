using TrelloNet.Internal;

namespace TrelloNet
{
	public class Paging
	{
		public Paging(int limit, int page)
		{
			Guard.InRange(limit, 1, 1000, "limit");
			Guard.InRange(page, 1, 100, "page");

			Limit = limit;
			Page = page;
		}

		public int Limit { get; private set; }
		public int Page { get; private set; }
	}
}