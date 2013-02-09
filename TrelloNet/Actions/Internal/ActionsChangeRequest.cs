using RestSharp;

namespace TrelloNet.Internal
{
	internal class ActionsUpdateRequest : ActionsRequest
	{
        public ActionsUpdateRequest(IActionId action, string newText)
            : base(action.GetActionId(), Method.PUT)
		{
            Guard.RequiredTrelloString(newText, "newText");
            AddParameter("text", newText);
		}
	}
}