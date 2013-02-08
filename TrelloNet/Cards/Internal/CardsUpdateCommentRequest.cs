using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsUpdateCommentRequest : ActionsRequest
	{
		public CardsUpdateCommentRequest(CommentCardAction comment, string newComment)
			: base(comment.Id, Method.PUT)
		{
            Guard.RequiredTrelloString(newComment, "newComment");
            AddParameter("text", newComment);
		}
	}
}