using System.Configuration;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	public class TrelloTestBase
	{
		protected Trello _trello;

		[SetUp]
		public void Setup()
		{
			_trello = new Trello(ConfigurationManager.AppSettings["ApplicationKey"]);
			_trello.Authenticate(ConfigurationManager.AppSettings["MemberToken"]);			
		}
	}
}