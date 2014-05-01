using RestSharp;

namespace TrelloNet.Internal
{
    internal class Advanced : IAdvanced
    {
        private readonly TrelloRestClient _restClient;

        public Advanced(TrelloRestClient restClient)
        {
            _restClient = restClient;
        }

        public T Get<T>(string uri, dynamic arguments) where T : class, new()
        {
            return _restClient.Request<T>(new AdvancedRequest(uri, Method.GET, arguments));
        }

        public dynamic Get(string uri, dynamic arguments)
        {
            return Get<dynamic>(uri, arguments);
        }

        public T Put<T>(string uri, dynamic arguments) where T : class, new()
        {
            return _restClient.Request<T>(new AdvancedRequest(uri, Method.PUT, arguments));
        }

        public dynamic Put(string uri, dynamic arguments)
        {
            return Put<dynamic>(uri, arguments);
        }

        public T Post<T>(string uri, dynamic arguments) where T : class, new()
        {
            return _restClient.Request<T>(new AdvancedRequest(uri, Method.POST, arguments));
        }

        public dynamic Post(string uri, dynamic arguments)
        {
            return Post<dynamic>(uri, arguments);
        }

        public T Delete<T>(string uri, dynamic arguments) where T : class, new()
        {
            return _restClient.Request<T>(new AdvancedRequest(uri, Method.DELETE, arguments));
        }

        public dynamic Delete(string uri, dynamic arguments)
        {
            return Delete<dynamic>(uri, arguments);
        }
    }
}