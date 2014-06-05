namespace TrelloNet.Internal
{
    internal class Webhooks : IWebhooks
    {
        private readonly TrelloRestClient _restClient;

        public Webhooks(TrelloRestClient restClient)
        {
            _restClient = restClient;
        }

        public Webhook WithId(string id)
        {
            return _restClient.Request<Webhook>(new WebhookRequest(new WebhookId(id)));
        }

        public Webhook Add(string idModel, string callbackUrl, string description = null)
        {
            return _restClient.Request<Webhook>(new WebhookAddRequest(idModel, callbackUrl, description));
        }

        public void Delete(IWebhookId webhook)
        {
            _restClient.Request(new WebhookDeleteRequest(webhook));
        }

        public void Delete(string id)
        {
            _restClient.Request(new WebhookDeleteRequest(new WebhookId(id)));
        }
    }  
}
