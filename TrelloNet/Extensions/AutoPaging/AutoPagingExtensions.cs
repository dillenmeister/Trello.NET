namespace TrelloNet.Extensions
{
	public static class AutoPagingExtensions
	{
		public static AutoPagedActions AutoPaged(this IActions trelloActions, int pageSize = 50)
		{
			return new AutoPagedActions(trelloActions, pageSize);
		}

		public static AutoPagedNotifications AutoPaged(this INotifications trelloActions, int pageSize = 50)
		{
			return new AutoPagedNotifications(trelloActions, pageSize);
		}
	}
}