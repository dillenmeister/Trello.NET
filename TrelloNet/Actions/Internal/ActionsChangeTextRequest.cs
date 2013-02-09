using RestSharp;

namespace TrelloNet.Internal
{
	internal class ActionsChangeTextRequest : ActionsRequest
	{
        public ActionsChangeTextRequest(IActionId action, string newText)
            : base(action.GetActionId(), Method.PUT)
		{
            Guard.RequiredTrelloString(newText, "newText");
            AddParameter("text", newText);
		}
	}
}