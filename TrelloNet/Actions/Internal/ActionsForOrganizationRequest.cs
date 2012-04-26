using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class ActionsForOrganizationRequest : OrganizationsRequest
	{
		public ActionsForOrganizationRequest(IOrganizationId organization, ISince since, Paging paging, IEnumerable<ActionType> filter)
			: base(organization, "actions")
		{
			this.AddTypeFilter(filter);
			this.AddSince(since);
			this.AddPaging(paging);
		}
	}
}