using RestSharp;

namespace TrelloNet.Internal
{
    internal class WebhookDeleteRequest : WebhookRequest
    {
        public WebhookDeleteRequest(IWebhookId webhook) : 
            base(webhook, method: Method.DELETE)            
        {            
        }
    }
}