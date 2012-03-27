using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class Members : IMembers
	{
		private readonly TrelloRestClient _restClient;

		internal Members(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Member WithId(string memberIdOrUsername)
		{
			return _restClient.Request<Member>(new MembersRequest(memberIdOrUsername));
		}

		public Member Me()
		{
			return _restClient.Request<Member>(new MembersRequest(new Me()));
		}

		public IEnumerable<Member> ForBoard(IBoardId board, MemberFilter filter = MemberFilter.All)
		{
			return _restClient.Request<List<Member>>(new MembersForBoardRequest(board, filter));
		}

		public IEnumerable<Member> ForCard(ICardId card)
		{
			return _restClient.Request<List<Member>>(new MembersForCardRequest(card));
		}

		public IEnumerable<Member> ForOrganization(IOrganizationId organization, MemberFilter filter = MemberFilter.All)
		{
			return _restClient.Request<List<Member>>(new MembersForOrganizationRequest(organization, filter));
		}

		public Member ForToken(string token)
		{
			return _restClient.Request<Member>(new MembersForTokenRequest(token));
		}
	}
}