using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsChangeCheckItemNameRequest : CardsRequest
	{
		public CardsChangeCheckItemNameRequest(ICardId card, IChecklistId checkList, ICheckItemId checkItem, string name)
			: base(card, "checklist/{idCheckList}/checkItem/{idCheckItem}/name", Method.PUT)
		{
			Guard.NotNull(checkList, "checkList");
			Guard.NotNull(checkItem, "checkItem");
			Guard.RequiredTrelloString(name, "name");

			AddParameter("idCheckList", checkList.GetChecklistId(), ParameterType.UrlSegment);
			AddParameter("idCheckItem", checkItem.GetCheckItemId(), ParameterType.UrlSegment);
			this.AddValue(name);
		}
	}
}