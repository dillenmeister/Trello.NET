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

        public ActionsRequest(string actionId, Method method, string resource = "")
            : base("actions/{actionId}/" + resource, method)
        {
            Guard.NotNull(actionId, "actionId");
            AddParameter("actionId", actionId, ParameterType.UrlSegment);
        }
    }
}