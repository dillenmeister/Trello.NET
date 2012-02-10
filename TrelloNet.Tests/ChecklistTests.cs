using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class ChecklistTests : TrelloTestBase
	{
		[Test]
		public void GetByBoard_WelcomeBoard_ReturnsOneChecklist()
		{
			var checkLists = _trello.Checklists.GetByBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(checkLists.Count(), Is.EqualTo(1));
		}

		[Test]
		public void GetByCard_TheChecklistCard_ReturnsOneChecklist()
		{
			var checkLists = _trello.Checklists.GetByCard(new CardId("4f2b8b4d4f2cb9d16d3684fc"));

			Assert.That(checkLists.Count(), Is.EqualTo(1));
		}

		[Test]
		public void GetById_AChecklist_ReturnsThatChecklist()
		{
			var expectedChecklist = new Checklist
			{
				Id = "4f2b8b4d4f2cb9d16d3684c7",
				IdBoard = Constants.WelcomeBoardId,
				Name = "Checklist",
				CheckItems = new List<Checklist.Ítem>
				{
					new Checklist.Ítem { Id = "4f2b8b4d4f2cb9d16d3684c4", Name = "Make your own boards" },
					new Checklist.Ítem { Id = "4f2b8b4d4f2cb9d16d3684c5", Name = "Invite your team" },
					new Checklist.Ítem { Id = "4f2b8b4d4f2cb9d16d3684c6", Name = "Enjoy an ice-cold lemonade" }
				}
			}.ToExpectedObject();

			var actualChecklist = _trello.Checklists.GetById("4f2b8b4d4f2cb9d16d3684c7");

			expectedChecklist.ShouldEqual(actualChecklist);
		}
	}
}