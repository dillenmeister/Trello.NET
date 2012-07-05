using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class SearchTests : TrelloTestBase
	{
		[Test]
		public void Search_WithTestQuery_ReturnsCorrectAction()
		{
			var expected = new List<Action> 
			{ 
				new CommentCardAction
				{
						Id = "4f3f5d073cf351b24302417d",
						IdMemberCreator = "4ece5a165237e5db06624a2a",
						Date = DateTime.Parse("2012-02-18 08:10:47.335"),
						Data = new CommentCardAction.ActionData
						{
							Board = new BoardName { Id = "4f2b8b4d4f2cb9d16d3684c9", Name = "Welcome Board" },
							Card = new CardName { Id = "4f2b8b4d4f2cb9d16d3684e6", Name = "Welcome to Trello!" },
							Text = "A test comment"
						}
				}					
			}.ToExpectedObject();
			
			var actual = _trelloReadOnly.Search("test").Actions;

			expected.ShouldEqual(actual);
		}

		[Test]
		public void Search_WithTestQuery_ReturnsCorrectBoard()
		{
			var expected = new Board
			{
				Closed = false,
				Name = "Welcome Board",
				Desc = "A test description",
				IdOrganization = Constants.TestOrganizationId,
				Pinned = true,
				Url = "https://trello.com/board/welcome-board/" + Constants.WelcomeBoardId,
				Id = Constants.WelcomeBoardId,
				Prefs = new BoardPreferences
				{
					Comments = CommentPermission.Members,
					Invitations = InvitationPermission.Members,
					PermissionLevel = PermissionLevel.Private,
					Voting = VotingPermission.Members
				},
				LabelNames = new Dictionary<Color, string>
				{
					{ Color.Yellow, "" },
					{ Color.Red, "" },
					{ Color.Purple, "" },
					{ Color.Orange, "" },
					{ Color.Green, "label name" },
					{ Color.Blue, "" },
				}
			}.ToExpectedObject();

			var actual = _trelloReadOnly.Search("Welcome Board").Boards.First();

			expected.ShouldEqual(actual);
		}		
	}
}