# Trello.NET
A .NET client library for [Trello](https://trello.com).

###Currently supports:
* Reading members
* Reading/updating boards
* Reading/updating lists
* Reading/some updating of cards
* Reading checklists
* Reading organizations
* Reading notifications
* Reading tokens

###Currently does not support:
* Updating members
* Some updating of cards
* Updating checklists
* Updating organizations
* OAuth
* Actions		

###Some example usage:

```csharp

	// Visit https://trello.com/1/appKey/generate to get your application key
	ITrello trello = new Trello("[your application key]");

	// Optional: Have the user browse to this url to authenticate your application
	var urlForAuthentication = trello.GetAuthenticationUrl("[a name for your application]", AccessMode.ReadOnly);

	// The user will receive a token, call Authenticate with it
	trello.Authenticate("[the token the user got]");

	// Get a member
	Member memberTrello = trello.Members.WithId("trello");

	// Get the authenticated member
	Member me = trello.Members.Me();

	// Get a board
	Board theTrelloDevBoard = trello.Boards.WithId("4d5ea62fd76aa1136000000c");

	// Get an organization
	Organization trelloApps = trello.Organizations.WithId("trelloapps");

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
	trello.Cards.AddLabel(aNewCard, Color.Green);

	// Assign member to card
	trello.Cards.AddMember(aNewCard, me);

	// Delete a card
	trello.Cards.Delete(aNewCard);

	// Comment on a card
	trello.Cards.AddComment(aNewCard, "my comment");

	// Create a checklist
	var aNewChecklist = trello.Checklists.Add("My checklist", aNewBoard);

	// Add the checklist to a card
	trello.Cards.AddChecklist(aNewCard, aNewChecklist);

```
	
License: [Apache License, Version 2.0](http://www.apache.org/licenses/LICENSE-2.0.html)	