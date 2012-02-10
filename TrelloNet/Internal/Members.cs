using System.Collections.Generic;
using TrelloNet.Internal.Requests;

namespace TrelloNet.Internal
{
	internal class Members : IMembers
	{
		private readonly TrelloRestClient _restClient;

		internal Members(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Member GetById(string memberId)
		{
			Guard.NotNullOrEmpty(memberId, "memberId");
			return _restClient.Request<Member>(new MemberRequest(memberId));
		}

		public Member GetMe()
		{
			return _restClient.Request<Member>(new MemberRequest(new Me()));
		}

		public IEnumerable<Member> GetByBoard(IBoardId board, MemberFilter filter = MemberFilter.Default)
		{
			Guard.NotNull(board, "board");
			return _restClient.Request<List<Member>>(new BoardMembersRequest(board, filter));
		}

		public IEnumerable<Member> GetByCard(ICardId card)
		{
			Guard.NotNull(card, "card");
			return _restClient.Request<List<Member>>(new CardMembersRequest(card));
		}

		public IEnumerable<Member> GetByOrganization(IOrganizationId organization, MemberFilter filter = MemberFilter.Default)
		{
			Guard.NotNull(organization, "organization");
			return _restClient.Request<List<Member>>(new OrganizationMembersRequest(organization, filter));
		}
	}
}