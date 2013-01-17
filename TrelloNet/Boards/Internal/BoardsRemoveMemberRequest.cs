using RestSharp;

namespace TrelloNet.Internal
{
    internal class BoardsRemoveMemberRequest : BoardsRequest
    {
        public BoardsRemoveMemberRequest(IBoardId board, IMemberId member)
            : base(board, "members/{idMember}", Method.DELETE)
        {
            Guard.NotNull(member, "member");
            AddParameter("idMember", member.GetMemberId(), ParameterType.UrlSegment);
        }
    }
}
