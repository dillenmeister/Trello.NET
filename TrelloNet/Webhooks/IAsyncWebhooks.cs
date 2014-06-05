using System.Threading.Tasks;

namespace TrelloNet
{
    public interface IAsyncWebhooks
    {
        /// <summary>
        /// GET /webhooks/[webhook_id]
        /// <br/>
        /// Required permissions: read
        /// </summary>
        Task<Webhook> WithId(string id);

        /// <summary>
        /// POST /webhooks
        /// <br/>
        /// Required permissions: read
        /// </summary>
        Task<Webhook> Add(string idModel, string callbackUrl, string description = null);

        /// <summary>
        /// DELETE /webhooks/[webhook_id]
        /// <br/>
        /// Required permissions: read
        /// </summary>
        Task Delete(IWebhookId webhook);

        /// <summary>
        /// DELETE /webhooks/[webhook_id]
        /// <br/>
        /// Required permissions: read
        /// </summary>
        Task Delete(string id);
    }
}