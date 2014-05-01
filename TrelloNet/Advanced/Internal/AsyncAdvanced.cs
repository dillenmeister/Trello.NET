using System;
using System.Threading.Tasks;
using RestSharp;

namespace TrelloNet.Internal
{
    internal class AsyncAdvanced : IAsyncAdvanced
    {
        private readonly TrelloRestClient _restClient;

        public AsyncAdvanced(TrelloRestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<T> Get<T>(string uri, dynamic arguments = null) where T : class, new()
        {
            return _restClient.RequestAsync<T>(new AdvancedRequest(uri, Method.GET, arguments));
        }

        public Task<dynamic> Get(string uri, dynamic arguments = null)
        {
            return Get<dynamic>(uri, arguments);
        }

        public Task<T> Put<T>(string uri, dynamic arguments = null) where T : class, new()
        {
            return _restClient.RequestAsync<T>(new AdvancedRequest(uri, Method.PUT, arguments));
        }

        public Task<dynamic> Put(string uri, dynamic arguments = null)
        {
            return Put<dynamic>(uri, arguments);
        }

        public Task<T> Post<T>(string uri, dynamic arguments = null) where T : class, new()
        {
            return _restClient.RequestAsync<T>(new AdvancedRequest(uri, Method.POST, arguments));
        }

        public Task<dynamic> Post(string uri, dynamic arguments = null)
        {
            return Post<dynamic>(uri, arguments);
        }

        public Task<T> Delete<T>(string uri, dynamic arguments = null) where T : class, new()
        {
            return _restClient.RequestAsync<T>(new AdvancedRequest(uri, Method.DELETE, arguments));
        }

        public Task<dynamic> Delete(string uri, dynamic arguments = null)
        {
            return Delete<dynamic>(uri, arguments);
        }
    }
}