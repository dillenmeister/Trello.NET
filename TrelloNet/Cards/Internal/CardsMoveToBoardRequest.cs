using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsMoveToBoardRequest : CardsRequest
	{
		public CardsMoveToBoardRequest(ICardId card, IBoardId board, IListId list)
			: base(card, "idBoard", Method.PUT)
		{
			Guard.NotNull(board, "board");
			this.AddValue(board.GetBoardId());

			if (list != null)
				AddParameter("idList", list.GetListId());
		}
	}
}