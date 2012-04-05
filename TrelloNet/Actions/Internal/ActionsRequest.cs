using RestSharp;

namespace TrelloNet.Internal
{
	internal class ActionsRequest : RestRequest
	{
		public ActionsRequest(string actionId, string resource = "")
			: base("actions/{actionId}/" + resource)
		{
			Guard.NotNull(actionId, "actionId");
			AddParameter("actionId", actionId, ParameterType.UrlSegment);
		}
	}
}