namespace TrelloNet
{
    public interface IWebhooks
    {
        /// <summary>
        /// GET /webhooks/[webhook_id]
        /// <br/>
        /// Required permissions: read
        /// </summary>
        Webhook WithId(string id);

        /// <summary>
        /// POST /webhooks
        /// <br/>
        /// Required permissions: read
        /// </summary>
        Webhook Add(string idModel, string callbackUrl, string description = null);

        /// <summary>
        /// DELETE /webhooks/[webhook_id]
        /// <br/>
        /// Required permissions: read
        /// </summary>
        void Delete(IWebhookId webhook);

        /// <summary>
        /// DELETE /webhooks/[webhook_id]
        /// <br/>
        /// Required permissions: read
        /// </summary>
        void Delete(string id);
    }
}