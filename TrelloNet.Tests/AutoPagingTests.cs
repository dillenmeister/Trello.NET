using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using TrelloNet.Extensions;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class AutoPagingTests
	{
		private IActions _actions;

		[SetUp]
		public void Setup()
		{
			_actions = A.Fake<IActions>();
		}

		[Test]
		public void ForBoard_WithPageSizeOf1AndTotalOf1ActionExists_ShouldMakeTwoCalls()
		{
			const int pageSize = 1;
			SetupActionsForBoardToReturn(pageSize, 0, new[] { new Action() });
			SetupActionsForBoardToReturn(pageSize, 1, Enumerable.Empty<Action>());

			_actions.AutoPaged(pageSize).ForBoard(new BoardId("dummy")).ToList();

			A.CallTo(() => _actions.ForBoard(A<IBoardId>._, A<IEnumerable<ActionType>>._, A<ISince>._, A<Paging>._)).MustHaveHappened(Repeated.Exactly.Twice);
		}

		[Test]
		public void ForBoard_WithPageSizeOf1AndTotalOf2ActionsExists_ShouldMakeThreeCalls()
		{
			const int pageSize = 1;
			SetupActionsForBoardToReturn(pageSize, 0, new[] { new Action() });
			SetupActionsForBoardToReturn(pageSize, 1, new[] { new Action() });
			SetupActionsForBoardToReturn(pageSize, 2, Enumerable.Empty<Action>());

			_actions.AutoPaged(pageSize).ForBoard(new BoardId("dummy")).ToList();

			A.CallTo(() => _actions.ForBoard(A<IBoardId>._, A<IEnumerable<ActionType>>._, A<ISince>._, A<Paging>._)).MustHaveHappened(Repeated.Exactly.Times(3));
		}

		[Test]
		public void ForBoard_WithPageSizeOf2AndTotalOf1ActionExists_ShouldMakeOneCall()
		{
			const int pageSize = 2;
			SetupActionsForBoardToReturn(pageSize, 0, new[] { new Action() });
			SetupActionsForBoardToReturn(pageSize, 1, Enumerable.Empty<Action>());

			_actions.AutoPaged(pageSize).ForBoard(new BoardId("dummy")).ToList();

			A.CallTo(() => _actions.ForBoard(A<IBoardId>._, A<IEnumerable<ActionType>>._, A<ISince>._, A<Paging>._)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void ForBoard_WithPageSizeOf2AndTotalOf2ActionExists_ShouldMakeTwoCalls()
		{
			const int pageSize = 2;
			SetupActionsForBoardToReturn(pageSize, 0, new[] { new Action(), new Action() });
			SetupActionsForBoardToReturn(pageSize, 1, Enumerable.Empty<Action>());

			_actions.AutoPaged(2).ForBoard(new BoardId("dummy")).ToList();

			A.CallTo(() => _actions.ForBoard(A<IBoardId>._, A<IEnumerable<ActionType>>._, A<ISince>._, A<Paging>._)).MustHaveHappened(Repeated.Exactly.Twice);
		}

		[Test]
		public void ForBoard_WithPageSizeOf2AndTotalOf3ActionExists_ShouldMakeTwoCalls()
		{
			const int pageSize = 2;
			SetupActionsForBoardToReturn(pageSize, 0, new[] { new Action(), new Action() });
			SetupActionsForBoardToReturn(pageSize, 1, new[] { new Action() });

			_actions.AutoPaged(2).ForBoard(new BoardId("dummy")).ToList();

			A.CallTo(() => _actions.ForBoard(A<IBoardId>._, A<IEnumerable<ActionType>>._, A<ISince>._, A<Paging>._)).MustHaveHappened(Repeated.Exactly.Twice);
		}

		[Test]
		public void ForBoard_WithPageSizeOf2AndTotalOf4ActionExists_ShouldMakeThreeCalls()
		{
			const int pageSize = 2;
			SetupActionsForBoardToReturn(pageSize, 0, new[] { new Action(), new Action() });
			SetupActionsForBoardToReturn(pageSize, 1, new[] { new Action(), new Action() });
			SetupActionsForBoardToReturn(pageSize, 2, Enumerable.Empty<Action>());

			_actions.AutoPaged(2).ForBoard(new BoardId("dummy")).ToList();

			A.CallTo(() => _actions.ForBoard(A<IBoardId>._, A<IEnumerable<ActionType>>._, A<ISince>._, A<Paging>._)).MustHaveHappened(Repeated.Exactly.Times(3));
		}

		private void SetupActionsForBoardToReturn(int pageLimit, int pageSize, IEnumerable<Action> actionsToReturn)
		{
			A.CallTo(() => _actions.ForBoard(A<IBoardId>._, A<IEnumerable<ActionType>>._, A<ISince>._, A<Paging>
				.That.Matches(p => p.Limit == pageLimit && p.Page == pageSize)))
				.Returns(actionsToReturn);
		}
	}
}