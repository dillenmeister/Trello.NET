using RestSharp;

namespace TrelloNet.Internal
{
    internal class BoardsAddMemberRequest : BoardsRequest
    {
        public BoardsAddMemberRequest (IBoardId board, IMemberId member, BoardMemberType type)
            : base(board, "members/{idMember}", Method.PUT)
        {
            Guard.NotNull(member, "member");
            Guard.NotNull(type, "type");

            this.AddParameter("idMember", member.GetMemberId(), ParameterType.UrlSegment);           
            this.AddParameter("type", type.ToTrelloString());
        }
    }
}
