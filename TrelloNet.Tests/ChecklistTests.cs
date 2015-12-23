﻿using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class ChecklistTests : TrelloTestBase
	{
		private readonly IBoardId _welcomeBoardWritable = new BoardId(Constants.WelcomeBoardId);

		[Test]
		public void ForBoard_WelcomeBoard_ReturnsFourChecklists()
		{
			var checkLists = _trelloReadOnly.Checklists.ForBoard(new BoardId("4f9e6802644163614d59db7f"));
			
			Assert.That(checkLists.Count(), Is.EqualTo(4));
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
			var checkLists = _trelloReadOnly.Checklists.ForCard(new CardId(Constants.TestCardId3));

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
                Id = "546f24e794e56071fe322419",
				IdBoard = Constants.WelcomeBoardId,
				Name = "Checklist",
                Pos = 16384,
				CheckItems = new List<CheckItem>
				{
					new CheckItem { Id = "546f24ebcf6d51143ddce2da", Name = "Item 1", Pos = 17236 },
					new CheckItem { Id = "546f24edde86240a2c988534", Name = "Item 2", Pos = 34510 }
				}
			}.ToExpectedObject();

			var actualChecklist = _trelloReadOnly.Checklists.WithId(Constants.ChecklistId);

			expectedChecklist.ShouldEqual(actualChecklist);
		}

		[Test]
		public void WithId_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Checklists.WithId(null),
						Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "id"));
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
            var checklist = _trelloReadWrite.Checklists.Add("a new checklist", new CardId(Constants.TestCardId2));

			Assert.That(checklist.CheckItems.Count, Is.EqualTo(0));
			Assert.That(checklist.Id, Is.Not.Empty);
			Assert.That(checklist.IdBoard, Is.EqualTo(_welcomeBoardWritable.GetBoardId()));
			Assert.That(checklist.Name, Is.EqualTo("a new checklist"));			
		}

		[Test]
		public void Scenario_ChangeNameOfAChecklist()
		{
            var checklist = _trelloReadWrite.Checklists.Add("a checklist", new CardId(Constants.TestCardId2));

			_trelloReadWrite.Checklists.ChangeName(checklist, "a new name");

			var checklistAfterChange = _trelloReadWrite.Checklists.WithId(checklist.Id);
			Assert.That(checklistAfterChange.Name, Is.EqualTo("a new name"));
		}

		[Test]
		public void Scenario_AddAndDeleteCheckItem()
		{
            var checklist = _trelloReadWrite.Checklists.Add("a checklist", new CardId(Constants.TestCardId2));

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
            Assert.That(() => _trelloReadWrite.Checklists.Add(name, new CardId(Constants.TestCardId2)),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void Add_NameIsTooLong_Throws()
		{
            Assert.That(() => _trelloReadWrite.Checklists.Add(new string('x', 16385), new CardId(Constants.TestCardId2)),
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
            var checklist = _trelloReadWrite.Checklists.WithId(Constants.ChecklistId);

			checklist.Name = "Updated name";

			_trelloReadWrite.Checklists.Update(checklist);

			var checklistsAfterUpdate = _trelloReadWrite.Checklists.WithId(checklist.Id);

			checklist.Name = "Checklist";

			_trelloReadWrite.Checklists.Update(checklist);

			Assert.That(checklistsAfterUpdate.Name, Is.EqualTo("Updated name"));
		}
	}
}
