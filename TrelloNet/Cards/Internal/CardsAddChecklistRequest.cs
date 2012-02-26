using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsAddChecklistRequest : CardsRequest
	{
		public CardsAddChecklistRequest(ICardId card, IChecklistId checklist)
			: base(card, "checklists", Method.POST)
		{
			this.AddValue(checklist.GetChecklistId());
		}
	}
}