using RestSharp;

namespace TrelloNet.Internal
{
	internal class ActionsDeleteRequest : ActionsRequest
	{
        public ActionsDeleteRequest(IActionId action)
            : base(action.GetActionId(), Method.DELETE)
		{
		}
	}
}