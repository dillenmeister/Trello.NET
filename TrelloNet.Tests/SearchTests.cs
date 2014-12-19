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
        [Test, Ignore("Search over actions is temporarily disabled and will return no results according to https://trello.com/docs/api/search/index.html")]
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
						},
						MemberCreator = new Action.ActionMember
						{
							FullName = "Oskar Dillén",
							Username = "oskardillen",
							Id = "4ece5a165237e5db06624a2a",
							AvatarHash = "bb5dc0160e87c6573ef69c9d4a284bd2",
							Initials = "OD"
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
                Name = Constants.TestBoardName,
                IdOrganization = Constants.TestOrganizationId,
                Pinned = false,
                Starred = true,
                Url = "https://trello.com/b/UTWsO3Jc/trello-net-test-board",
                Id = Constants.WelcomeBoardId,
                Prefs = new BoardPreferences
                {
                    Comments = CommentPermission.Members,
                    Invitations = InvitationPermission.Members,
                    PermissionLevel = PermissionLevel.Private,
                    Voting = VotingPermission.Members
                },
                LabelNames = new Dictionary<String, string>
				{
					{ "green", "" },
					{ "yellow", "" },
					{ "orange", "" },
					{ "red", "" },
					{ "purple", "" },
					{ "blue", "" },
                    { "sky", "" },
                    { "lime", "" },
                    { "pink", "" },
                    { "black", "" },
				}
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Search(Constants.TestBoardName).Boards.First();

            expected.ShouldEqual(actual);
        }

        [Test]
        public void Search_WithTestQuery_ReturnsCorrectCard()
        {
            var expected = new Card
            {
                Id = "54915d3a6c094da5f474c559",
                Name = "Search test card",
                Desc = "",
                Closed = false,
                IdList = Constants.WelcomeBoardBasicsListId,
                IdBoard = Constants.WelcomeBoardId,
                Due = new DateTime(2015, 01, 01, 12, 00, 00),
                Labels = new List<Card.Label>(),
                IdShort = 66,
                Url = "https://trello.com/c/acv9Fblm/66-search-test-card",
                ShortUrl = "https://trello.com/c/acv9Fblm",
                Pos = 327679,
                DateLastActivity = new DateTime(2014, 12, 17, 10, 43, 23, 012),
                Badges = new Card.CardBadges
                {
                    Votes = 1,
                    Attachments = 1,
                    Comments = 2,
                    CheckItems = 0,
                    CheckItemsChecked = 0,
                    Description = false,
                    Due = new DateTime(2015, 01, 01, 12, 00, 00),
                    FogBugz = ""
                },
                IdMembers = new List<string> { "4f9e6801644163614d59db73" }
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Search("Search test card").Cards.First();

            expected.ShouldEqual(actual);
        }

        [Test]
        public void Search_WithTestQuery_ReturnsCorrectMember()
        {
            var expected = new
            {
                FullName = "Christopher Downes-Ward",
                Username = "christopherdownesward",
                Id = "4f9e6801644163614d59db73",
                AvatarHash = "5db13c831c6f50ac6e97217bc77f4034",
                Initials = "CDW"
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Search("Christopher Downes-Ward").Members.First();

            expected.ShouldMatch(actual);
        }

        [Test]
        public void Search_WithTestQueryButWithoutMemberModelType_ReturnsNoMembers()
        {
            var actual = _trelloReadOnly.Search("Trello.NET Test User", modelTypes: new[] { ModelType.Actions }).Members;

            Assert.That(actual.Count(), Is.EqualTo(0));
        }

        [Test, Ignore("Search over actions is temporarily disabled and will return no results according to https://trello.com/docs/api/search/index.html")]
        public void Search_WithActionsSince_ReturnsCorrectActions()
        {
            var shouldBeOneAction = _trelloReadOnly.Search("test", actionsSince: DateTime.Parse("2012-02-18")).Actions;
            var shouldBeEmpty = _trelloReadOnly.Search("test", actionsSince: DateTime.Parse("2012-02-19")).Actions;

            Assert.That(shouldBeOneAction.Count(), Is.EqualTo(1));
            Assert.That(shouldBeEmpty.Count(), Is.EqualTo(0));
        }

        [Test, Ignore("Searching for organizations doesn't seem to work in Trello")]
        public void Search_WithTestQuery_ReturnsCorrectOrganization()
        {
            var expected = new Organization
            {
                Id = "4f2b94c0c1c87fcb65422344",
                DisplayName = "Trello.NET Test Organization",
                Name = "trellnettestorganization",
                Desc = "organization description",
                Url = "https://trello.com/trellnettestorganization",
                Website = "http://www.test.com"
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Search("Trello.NET Test Organization").Organizations.First();

            expected.ShouldEqual(actual);
        }
    }
}