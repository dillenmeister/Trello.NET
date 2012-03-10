using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsRemoveChecklistRequest : CardsRequest
	{
		public CardsRemoveChecklistRequest(ICardId card, IChecklistId checklist)
			: base(card, "checklists/{idChecklist}", Method.DELETE)
		{
			Guard.NotNull(checklist, "checklist");
			AddParameter("idChecklist", checklist.GetChecklistId(), ParameterType.UrlSegment);
		}
	}
}