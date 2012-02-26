using System;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class AuthorizationTests : TrelloTestBase
	{
		[Test]
		public void GetAuthorizationlUrl_ApplicationNameIsEmpty_Throw()
		{
			var trello = new Trello("key");

			Assert.That(() => trello.GetAuthorizationUrl("", AccessMode.ReadOnly),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "applicationName"));
		}

		//Assert.That(url, Is.EqualTo("https://trello.com/1/connect?key=key&name=app&response_type=token&scope=read"));			

		[Test]
		public void GetAuthorizationlUrl_Always_ContainsKeyPassedInConstructor()
		{
			var trello = new Trello("123");

			var url = trello.GetAuthorizationUrl("dummy", AccessMode.ReadOnly);

			Assert.That(url.ToString(), Is.StringContaining("key=123"));						
		}

		[Test]
		public void GetAuthorizationlUrl_Always_ContainsApplicationName()
		{
			var trello = new Trello("dummy");

			var url = trello.GetAuthorizationUrl("appname", AccessMode.ReadOnly);

			Assert.That(url.ToString(), Is.StringContaining("name=appname"));
		}

		[Test]
		public void GetAuthorizationlUrl_Always_ContainsResponseTypeToken()
		{
			var trello = new Trello("dummy");

			var url = trello.GetAuthorizationUrl("dummy", AccessMode.ReadOnly);

			Assert.That(url.ToString(), Is.StringContaining("response_type=token"));
		}

		[Test]
		public void GetAuthorizationlUrl_AccessModeReadonly_ContainsRead()
		{
			var trello = new Trello("dummy");

			var url = trello.GetAuthorizationUrl("dummy", AccessMode.ReadOnly);

			Assert.That(url.ToString(), Is.StringContaining("scope=read"));
			Assert.That(url.ToString(), Is.Not.StringContaining("write"));
		}

		[Test]
		public void GetAuthorizationlUrl_AccessModeReadonly_ContainsReadWrite()
		{
			var trello = new Trello("dummy");

			var url = trello.GetAuthorizationUrl("dummy", AccessMode.ReadWrite);

			Assert.That(url.ToString(), Is.StringContaining("scope=read,write"));			
		}

		[Test]
		public void GetAuthorizationlUrl_DefaultExpiration_Contains30days()
		{
			var trello = new Trello("dummy");

			var url = trello.GetAuthorizationUrl("dummy", AccessMode.ReadWrite);

			Assert.That(url.ToString(), Is.StringContaining("expiration=30days"));
		}

		[Test]
		public void GetAuthorizationlUrl_ExpirationNever_ContainsNever()
		{
			var trello = new Trello("dummy");

			var url = trello.GetAuthorizationUrl("dummy", AccessMode.ReadWrite, Expiration.Never);

			Assert.That(url.ToString(), Is.StringContaining("expiration=never"));
		}

		[Test]
		public void GetAuthorizationlUrl_ExpirationOneHour_Contains1hour()
		{
			var trello = new Trello("dummy");

			var url = trello.GetAuthorizationUrl("dummy", AccessMode.ReadWrite, Expiration.OneHour);

			Assert.That(url.ToString(), Is.StringContaining("expiration=1hour"));
		}

		[Test]
		public void GetAuthorizationlUrl_ExpirationOneHour_Contains1day()
		{
			var trello = new Trello("dummy");

			var url = trello.GetAuthorizationUrl("dummy", AccessMode.ReadWrite, Expiration.OneDay);

			Assert.That(url.ToString(), Is.StringContaining("expiration=1day"));
		}
	}
}