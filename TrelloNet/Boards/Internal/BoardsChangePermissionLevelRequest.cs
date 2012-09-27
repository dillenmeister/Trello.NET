using RestSharp;

namespace TrelloNet.Internal
{
    internal class BoardsChangePermissionLevelRequest : BoardsRequest
    {
        public BoardsChangePermissionLevelRequest(IBoardId board, PermissionLevel permissionLevel)
            : base(board, "prefs/permissionLevel", Method.PUT)
        {
            this.AddValue(permissionLevel.ToTrelloString());
        }
    }
}