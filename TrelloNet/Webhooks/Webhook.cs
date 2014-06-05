namespace TrelloNet
{
    public class Webhook : IWebhookId
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string IdModel { get; set; }
        public string CallbackUrl { get; set; }
        public bool Active { get; set; }

        public string GetWebhookId()
{
            return Id;
        }
    }
}