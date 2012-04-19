namespace TrelloNet.Internal
{
	internal class ActionsForListRequest : ListsRequest
	{
		public ActionsForListRequest(IListId list, ISince since, Paging paging)
			: base(list, "actions")
		{
			this.AddSince(since);
			this.AddPaging(paging);
		}
	}
}