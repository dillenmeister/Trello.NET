using System.Threading.Tasks;

namespace TrelloNet.Internal
{
    internal class AsyncWebhooks : IAsyncWebhooks
    {
        private readonly TrelloRestClient _restClient;

        public AsyncWebhooks(TrelloRestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<Webhook> WithId(string id)
        {
            return _restClient.RequestAsync<Webhook>(new WebhookRequest(new WebhookId(id)));
        }

        public Task<Webhook> Add(string idModel, string callbackUrl, string description = null)
        {
            return _restClient.RequestAsync<Webhook>(new WebhookAddRequest(idModel, callbackUrl, description));
        }

        public Task Delete(IWebhookId webhook)
        {
            return _restClient.RequestAsync(new WebhookDeleteRequest(webhook));
        }

        public Task Delete(string id)
        {
            return _restClient.RequestAsync(new WebhookDeleteRequest(new WebhookId(id)));
        }

    }
}