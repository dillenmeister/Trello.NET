using System;
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
		public void ForBoard_WelcomeBoard_ReturnsTwoChecklists()
		{
			var checkLists = _trelloReadOnly.Checklists.ForBoard(new BoardId(Constants.WelcomeBoardId));

			// For some reason there are two checklists, but only one is actually visible. The other one is not attached to any card which is strange.
			Assert.That(checkLists.Count(), Is.EqualTo(2));
		}

		[Test]
		public void ForBoard_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Checklists.ForBoard(null),
						Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "board"));
		}

		[Test]
		public void GetByCard_TheChecklistCard_ReturnsOneChecklist()
		{
			var checkLists = _trelloReadOnly.Checklists.ForCard(new CardId("4f2b8b4d4f2cb9d16d3684fc"));

			Assert.That(checkLists.Count(), Is.EqualTo(1));
		}

		[Test]
		public void ForCard_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Checklists.ForCard(null),
						Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "card"));
		}

		[Test]
		public void WithId_AChecklist_ReturnsThatChecklist()
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

			var actualChecklist = _trelloReadOnly.Checklists.WithId("4f2b8b4d4f2cb9d16d3684c7");

			expectedChecklist.ShouldEqual(actualChecklist);
		}

		[Test]
		public void WithId_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Checklists.WithId(null),
						Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "checklistId"));
		}

		[Test]
		public void ToString_EqualsName()
		{
			var checklist = new Checklist { Name = "a name" };

			Assert.That(checklist.ToString(), Is.EqualTo("a name"));
		}

		[Test]
		public void Scenario_AddChecklist()
		{
			var board = _trelloReadWrite.Boards.ForMe().First(b => b.Name == "Welcome Board");

			var checklist = _trelloReadWrite.Checklists.Add("a new checklist", board);

			Assert.That(checklist.CheckItems.Count, Is.EqualTo(0));
			Assert.That(checklist.Id, Is.Not.Empty);
			Assert.That(checklist.IdBoard, Is.EqualTo(board.Id));
			Assert.That(checklist.Name, Is.EqualTo("a new checklist"));			
		}

		[Test]
		public void Scenario_ChangeNameOfAChecklist()
		{
			var board = _trelloReadWrite.Boards.ForMe().First(b => b.Name == "Welcome Board");
			var checklist = _trelloReadWrite.Checklists.Add("a checklist", board);

			_trelloReadWrite.Checklists.ChangeName(checklist, "a new name");

			var checklistAfterChange = _trelloReadWrite.Checklists.WithId(checklist.Id);
			Assert.That(checklistAfterChange.Name, Is.EqualTo("a new name"));
		}

		[Test]
		public void Scenario_AddAndDeleteCheckItem()
		{
			var board = _trelloReadWrite.Boards.ForMe().First(b => b.Name == "Welcome Board");
			var checklist = _trelloReadWrite.Checklists.Add("a checklist", board);

			_trelloReadWrite.Checklists.AddCheckItem(checklist, "a new check item");

			var checklistAfterAdd = _trelloReadWrite.Checklists.WithId(checklist.Id);

			Assert.That(checklistAfterAdd.CheckItems.Count, Is.EqualTo(1));
			Assert.That(checklistAfterAdd.CheckItems.First().Name, Is.EqualTo("a new check item"));

			_trelloReadWrite.Checklists.RemoveCheckItem(checklist, checklistAfterAdd.CheckItems.First().Id);

			var checklistAfterRemove = _trelloReadWrite.Checklists.WithId(checklist.Id);
			Assert.That(checklistAfterRemove.CheckItems.Count, Is.EqualTo(0));
		}

		[TestCase("")]
		[TestCase(null)]
		public void Add_NameIsInvalid_Throws(string name)
		{
			Assert.That(() => _trelloReadWrite.Checklists.Add(name, new BoardId("dummy")),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void Add_NameIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadWrite.Checklists.Add(new string('x', 16385), new BoardId("dummy")),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[TestCase("")]
		[TestCase(null)]
		public void ChangeName_NameIsInvalid_Throws(string name)
		{
			Assert.That(() => _trelloReadWrite.Checklists.ChangeName(new ChecklistId("dummy"), name),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void ChangeName_NameIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadWrite.Checklists.ChangeName(new ChecklistId("dummy"), new string('x', 16385)),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[TestCase("")]
		[TestCase(null)]
		public void AddCheckItem_NameIsInvalid_Throws(string name)
		{
			Assert.That(() => _trelloReadWrite.Checklists.AddCheckItem(new ChecklistId("dummy"), name),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void AddCheckItem_NameIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadWrite.Checklists.AddCheckItem(new ChecklistId("dummy"), new string('x', 16385)),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void Scenario_UpdateName()
		{
			var checklist = _trelloReadWrite.Checklists.WithId("4f41e4803374646b5c74bd67");

			checklist.Name = "Updated name";

			_trelloReadWrite.Checklists.Update(checklist);

			var checklistsAfterUpdate = _trelloReadWrite.Checklists.WithId(checklist.Id);

			checklist.Name = "Checklist";

			_trelloReadWrite.Checklists.Update(checklist);

			Assert.That(checklistsAfterUpdate.Name, Is.EqualTo("Updated name"));
		}
	}
}