# Trello.NET
A .NET client library for [Trello](https://trello.com).

Currently supports readonly access to members, boards, lists, cards, checklists and organization.

Does not support reading actions, notifications, tokens or adding, updating and deleting of any data.

Some example usage:

```csharp

	// Visit https://trello.com/1/appKey/generate to get your application key
	ITrello trello = new Trello("[your application key]");
	
	// Optional: Have the user browse to this url to authenticate your application
	var urlForAuthentication = trello.GetAuthenticationUrl("[a name for your application]");

	// The user will receive a token, call Authenticate with it
	trello.Authenticate("[the token the user got]");
	
	// Get a member
	Member me = trello.Member("me");
	Member memberTrello = trello.Member("trello");
	
	// Get a board
	Board theTrelloDevBoard = trello.Board("4d5ea62fd76aa1136000000c");
	
	// Get an organization
	Organization trelloApps = trello.Organization("trelloapps");
	
	// Get all members of a board
	IEnumerable<Member> membersOfTrelloDevBoard = trello.Members(theTrelloDevBoard);
	
	// Get all owners of a board
	IEnumerable<Member> ownersOfTrelloDevBoard = trello.Members(theTrelloDevBoard, MemberFilter.Owners);
	
	// Get all members of an organization
	IEnumerable<Member> membersInTrelloAppsOrg = trello.Members(trelloApps);
	
	// Get all boards of a member
	IEnumerable<Board> allMyBoards = trello.Boards(me);
	
	//Get all boards of an organization
	IEnumerable<Board> allBoardsOfTrelloAppsOrg = trello.Boards(trelloApps);
	
	// Get all closed boards of an organization
	IEnumerable<Board> closedBoardsOfTrelloAppsOrg = trello.Boards(trelloApps, BoardFilter.Closed);
	
	// Get all lists on a board
	IEnumerable<List> allListsInTheTrelloDevBoard = trello.Lists(theTrelloDevBoard);
	
	// Get all cards on a board
	IEnumerable<Card> allCardsOnTheTrelloDevBoard = trello.Cards(theTrelloDevBoard);
	
	// Get all cards assigned to a member
	IEnumerable<Card> allCardsAssignedToMe = trello.Cards(me);
	
	// Get all organizations that a member belongs to
	IEnumerable<Organization> allMyOrganizations = trello.Organizations(me);
```
	
License: [Apache License, Version 2.0](http://www.apache.org/licenses/LICENSE-2.0.html)	