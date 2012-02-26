using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsAddCommentRequest : CardsRequest
	{
		public CardsAddCommentRequest(ICardId card, string comment)
			: base(card, "actions/comments", Method.POST)
		{
			AddParameter("text", comment);
		}
	}
}