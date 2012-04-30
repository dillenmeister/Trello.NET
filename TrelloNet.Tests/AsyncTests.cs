using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class AsyncTests : TrelloTestBase
	{
		[Test, Explicit]
		public void ExecuteAsync_Bug_In_RestSharp()
		{
			var task = _trelloReadOnly.Async.Members.Me();
			var tookLessThan5Seconds = task.Wait(5000);

			Assert.That(tookLessThan5Seconds);
		}
	}
}