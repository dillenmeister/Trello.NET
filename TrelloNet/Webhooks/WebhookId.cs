using TrelloNet.Internal;

namespace TrelloNet
{
    public class WebhookId : IWebhookId
    {
        private readonly string _id;

        public WebhookId(string id)
        {            
            Guard.NotNullOrEmpty(id, "id");

            _id = id;
        }

        public string GetWebhookId()
        {
            return _id;
        }
    }
}