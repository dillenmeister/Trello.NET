using RestSharp;

namespace TrelloNet.Internal
{
    internal class WebhookRequest : RestRequest
    {
        public WebhookRequest(IWebhookId webhook, string resource = "", Method method = Method.GET)
            : base("webhooks/{webhookId}/" + resource, method)
        {            
            Guard.NotNull(webhook, "webhook");
            AddParameter("webhookId", webhook.GetWebhookId(), ParameterType.UrlSegment);
        }
    }
}