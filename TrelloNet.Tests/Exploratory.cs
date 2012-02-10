using System.Collections.Generic;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class Exploratory
	{		
		[Test, Explicit]
		public void Demonstrate_Functionality()
		{
			// Visit https://trello.com/1/appKey/generate to get your application key
			ITrello trello = new Trello("[your application key]");

			// Optional: Have the user browse to this url to authenticate your application
			var urlForAuthentication = trello.GetAuthenticationUrl("[a name for your application]");

			// The user will receive a token, call Authenticate with it
			trello.Authenticate("[the token the user got]");

			// Get a member
			Member me = trello.Members.GetMe();
			Member memberTrello = trello.Members.GetById("trello");

			// Get a board
			Board theTrelloDevBoard = trello.Boards.GetById("4d5ea62fd76aa1136000000c");

			// Get an organization
			Organization trelloApps = trello.Organizations.GetById("trelloapps");

			// Get all members of a board
			IEnumerable<Member> membersOfTrelloDevBoard = trello.Members.GetByBoard(theTrelloDevBoard);

			// Get all owners of a board
			IEnumerable<Member> ownersOfTrelloDevBoard = trello.Members.GetByBoard(theTrelloDevBoard, MemberFilter.Owners);

			// Get all members of an organization
			IEnumerable<Member> membersInTrelloAppsOrg = trello.Members.GetByOrganization(trelloApps);

			// Get all boards of a member
			IEnumerable<Board> allMyBoards = trello.Boards.GetByMember(me);

			//Get all boards of an organization
			IEnumerable<Board> allBoardsOfTrelloAppsOrg = trello.Boards.GetByOrganization(trelloApps);

			// Get all closed boards of an organization
			IEnumerable<Board> closedBoardsOfTrelloAppsOrg = trello.Boards.GetByOrganization(trelloApps, BoardFilter.Closed);

			// Get all lists on a board
			IEnumerable<List> allListsInTheTrelloDevBoard = trello.Lists.GetByBoard(theTrelloDevBoard);

			// Get all cards on a board
			IEnumerable<Card> allCardsOnTheTrelloDevBoard = trello.Cards.GetByBoard(theTrelloDevBoard);

			// Get all cards assigned to a member
			IEnumerable<Card> allCardsAssignedToMe = trello.Cards.GetByMember(me);

			// Get all organizations that a member belongs to
			IEnumerable<Organization> allMyOrganizations = trello.Organizations.GetByMember(me);			
		}
	}	
}
