using NUnit.Framework;

namespace TrelloNet.Tests
{
    [TestFixture]
    public class WebhookTests : TrelloTestBase
    {
        [Test]
        public void Scenario_CreateAndDeleteWebhook()
        {
            var webhook = _trelloReadWrite.Webhooks.Add("4f41e4803374646b5c74bd69", "http://www.google.com", "description");
            _trelloReadWrite.Webhooks.Delete(webhook);            

            Assert.That(webhook.Id, Is.Not.Null);
            Assert.That(webhook.Description, Is.EqualTo("description"));
            Assert.That(webhook.IdModel, Is.EqualTo("4f41e4803374646b5c74bd69"));
            Assert.That(webhook.CallbackUrl, Is.EqualTo("http://www.google.com"));
            Assert.That(webhook.Active, Is.True);
        }
    }
}