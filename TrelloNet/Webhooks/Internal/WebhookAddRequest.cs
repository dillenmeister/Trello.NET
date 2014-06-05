using RestSharp;

namespace TrelloNet.Internal
{
    internal class WebhookAddRequest : RestRequest
    {
        public WebhookAddRequest(string idModel, string callbackUrl, string description)
            : base("webhooks", Method.POST)
        {
            Guard.NotNullOrEmpty(idModel, "idModel");
            Guard.RequiredTrelloString(callbackUrl, "callbackUrl");

            AddParameter("idModel", idModel);
            AddParameter("callbackURL", callbackUrl);

            if (description != null)
            {
                Guard.OptionalTrelloString(description, "description");
                AddParameter("description", description);
            }
        }
    }
}