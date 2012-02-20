using System.Configuration;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	public class TrelloTestBase
	{
		protected Trello _readTrello;
		protected Trello _writeTrello;

		[SetUp]
		public void Setup()
		{
			_readTrello = new Trello(ConfigurationManager.AppSettings["ApplicationKey"]);
			_readTrello.Authenticate(ConfigurationManager.AppSettings["MemberReadToken"]);

			_writeTrello = new Trello(ConfigurationManager.AppSettings["ApplicationKey"]);
			_writeTrello.Authenticate(ConfigurationManager.AppSettings["MemberWriteToken"]);	
		}
	}
}