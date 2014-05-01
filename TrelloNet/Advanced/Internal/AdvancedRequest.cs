using RestSharp;

namespace TrelloNet.Internal
{
    internal class AdvancedRequest : RestRequest
    {
        public AdvancedRequest(string uri, Method method, dynamic arguments)
            : base(uri, method)
        {
            if(arguments != null)
                AddObject(arguments);
        }
    }
}