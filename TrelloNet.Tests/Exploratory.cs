using System;
using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class Exploratory
	{
		[Test, Explicit]
		public void Demonstrate_Functionality()
		{
			ITrello trello = new Trello(ConfigurationManager.AppSettings["ApplicationKey"]);
			trello.Authenticate("xyz");


			//// Visit https://trello.com/1/appKey/generate to get your application key
			//ITrello trello = new Trello("[your application key]");

			// Have the user browse to this url to authenticate your application
			var urlForAuthentication = trello.GetAuthenticationUrl("[a name for your application]");

			// The user will receive a token, call Authenticate with it
			trello.Authenticate("[the token the user got]");

			Member me = trello.Member("me");
			Member memberTrello = trello.Member("trello");

			Board theTrelloDevBoard = trello.Board("4d5ea62fd76aa1136000000c");

			Organization trelloApps = trello.Organization("trelloapps");

			IEnumerable<Member> membersOfTrelloDevBoard = trello.Members(theTrelloDevBoard);
			IEnumerable<Member> ownersOfTrelloDevBoard = trello.Members(theTrelloDevBoard, MemberFilter.Owners);
			IEnumerable<Member> membersInTrelloAppsOrg = trello.Members(trelloApps);

			IEnumerable<Board> allMyBoards = trello.Boards(me);
			IEnumerable<Board> allBoardsOfTrelloAppsOrg = trello.Boards(trelloApps);
			IEnumerable<Board> closedBoardsOfTrelloAppsOrg = trello.Boards(trelloApps, BoardFilter.Closed);

			IEnumerable<List> allListsInTheTrelloDevBoard = trello.Lists(theTrelloDevBoard);
			IEnumerable<Card> allCardsOnTheTrelloDevBoard = trello.Cards(theTrelloDevBoard);
			IEnumerable<Card> allCardsAssignedToMe = trello.Cards(me);

			IEnumerable<Organization> allMyOrganizations = trello.Organizations(me);
		}
	}
}