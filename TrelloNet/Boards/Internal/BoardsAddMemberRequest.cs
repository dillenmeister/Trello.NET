using RestSharp;

namespace TrelloNet.Internal
{
    internal class BoardsAddMemberRequest : BoardsRequest
    {
        public BoardsAddMemberRequest(IBoardId board, IMemberId member, BoardMemberType type)
            : base(board, "members/{idMember}", Method.PUT)
        {
            Guard.NotNull(member, "member");
            AddParameter("idMember", member.GetMemberId(), ParameterType.UrlSegment);
            
            AddParameter("type", type.ToTrelloString());            
        }

        public BoardsAddMemberRequest(IBoardId board, string email, string fullName, BoardMemberType type)
            : base(board, "members", Method.PUT)
        {
            Guard.RequiredTrelloString(email, "email");
            Guard.RequiredTrelloString(fullName, "fullName");            

            AddParameter("email", email);
            AddParameter("fullName", fullName);
            
            AddParameter("type", type.ToTrelloString());
            
        }
    }
}
