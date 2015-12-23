using RestSharp;

namespace TrelloNet.Internal
{
	internal class ChecklistsAddRequest : CardsRequest
	{
		public ChecklistsAddRequest(ICardId card, string name)
			: base(card, "checklists", Method.POST)
		{
			Guard.RequiredTrelloString(name, "name");
			AddParameter("name", name);
		}
	}
}