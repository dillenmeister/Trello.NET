﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TrelloNet.Internal;

namespace TrelloNet.Tests
{
	[TestFixture, Explicit]
	public class Exploratory : TrelloTestBase
	{
		[Test]
		public void Explore()
		{
			var org = _trelloReadOnly.Organizations.WithId("trellnettestorganization");
			var items = _trelloReadOnly.Boards.Search("tes", filter: new SearchFilter { Organizations = new[] { org } }, partial: true);
		}

		[Test]
		public void Demonstrate_Functionality()
		{
			// Visit https://trello.com/1/appKey/generate to get your application key
			ITrello trello = new Trello("[your application key]");

			// Optional: Have the user browse to this url to authenticate your application
			var urlForAuthentication = trello.GetAuthorizationUrl("[a name for your application]", Scope.ReadOnly);

			// The user will receive a token, call Authenticate with it
			trello.Authorize("[the token the user got]");

			// Get a member
			Member memberTrello = trello.Members.WithId("trello");

			// Get the authenticated member
			Member me = trello.Members.Me();
			Console.WriteLine(me.FullName);

			// Get a board
			Board theTrelloDevBoard = trello.Boards.WithId("4d5ea62fd76aa1136000000c");
			Console.WriteLine(theTrelloDevBoard.Name);

			// Get an organization
			Organization trelloApps = trello.Organizations.WithId("trelloapps");
			Console.WriteLine(trelloApps.DisplayName);

			// Get all members of a board
			IEnumerable<Member> membersOfTrelloDevBoard = trello.Members.ForBoard(theTrelloDevBoard);

			// Get all owners of a board
			IEnumerable<Member> ownersOfTrelloDevBoard = trello.Members.ForBoard(theTrelloDevBoard, MemberFilter.Owners);

			// Get all members of an organization
			IEnumerable<Member> membersInTrelloAppsOrg = trello.Members.ForOrganization(trelloApps);

			// Get all boards of a member
			IEnumerable<Board> allMyBoards = trello.Boards.ForMember(me);

			//Get all boards of an organization
			IEnumerable<Board> allBoardsOfTrelloAppsOrg = trello.Boards.ForOrganization(trelloApps);

			// Get all closed boards of an organization
			IEnumerable<Board> closedBoardsOfTrelloAppsOrg = trello.Boards.ForOrganization(trelloApps, BoardFilter.Closed);

			// Get all lists on a board
			IEnumerable<List> allListsInTheTrelloDevBoard = trello.Lists.ForBoard(theTrelloDevBoard);

			// Get all cards on a board
			IEnumerable<Card> allCardsOnTheTrelloDevBoard = trello.Cards.ForBoard(theTrelloDevBoard);

			// Get all cards assigned to a member
			IEnumerable<Card> allCardsAssignedToMe = trello.Cards.ForMember(me);

			// Get all organizations that a member belongs to
			IEnumerable<Organization> allMyOrganizations = trello.Organizations.ForMember(me);

			// Get unread notifications
			IEnumerable<Notification> notifications = trello.Notifications.ForMe(readFilter: ReadFilter.Unread);

			// Get a token
			Token token = trello.Tokens.WithToken("[a token]");

			// Get all actions since last view
			foreach (Action action in trello.Actions.ForMe(since: Since.LastView))
				Console.WriteLine(action.Date);

			// Create a new board
			Board aNewBoard = trello.Boards.Add(new NewBoard("A new board"));

			// Close a board
			trello.Boards.Close(aNewBoard);

			// Create a new list
			List aNewList = trello.Lists.Add(new NewList("A new list", aNewBoard));

			// Archive a list
			trello.Lists.Archive(aNewList);

			// Create a card
			Card aNewCard = trello.Cards.Add(new NewCard("A new card", aNewList));

			// Label card
			trello.Cards.AddLabel(aNewCard, "green");

			// Assign member to card
			trello.Cards.AddMember(aNewCard, me);

			// Delete a card
			trello.Cards.Delete(aNewCard);

			// Comment on a card
			trello.Cards.AddComment(aNewCard, "My comment");

			// Update entire card (also works for list, board and checklist)
			aNewCard.Name = "an updated name";
			aNewCard.Desc = "an updated description";
			trello.Cards.Update(aNewCard);

			// Create a checklist
            var aNewChecklist = trello.Checklists.Add("My checklist", aNewCard);

			// Add the checklist to a card
			//trello.Cards.AddChecklist(aNewCard, aNewChecklist);

			// Add check items
			trello.Checklists.AddCheckItem(aNewChecklist, "My check item");

			// Search in Boards, Cards, Members, Organizations and Actions
			var results = trello.Search("some search query");
			Console.WriteLine("Found {0} boards", results.Boards.Count);
			Console.WriteLine("Found {0} cards", results.Cards.Count);
			Console.WriteLine("Found {0} cards", results.Members.Count);
			// etc...

			// Or search per model individually
			IEnumerable<Card> cards = trello.Cards.Search("some search query", limit: 10);
			foreach (var card in cards)
				Console.WriteLine(card.Name);

			// Do things asynchronously! Same API as the sync one, except it returns Task.
			Task<IEnumerable<Card>> cardsTask = trello.Async.Cards.ForMe();
			cardsTask.Wait();
		}
	}
}
