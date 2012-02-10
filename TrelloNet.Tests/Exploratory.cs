using NUnit.Framework;
using TrelloNet.Internal;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class Exploratory
	{
		private ITrelloToBe _trello;

		[Test, Explicit]
		public void Demonstrate_Functionality()
		{
			
		}
	}

	public interface ITrelloToBe
	{
		IMembers Members { get; }
		IBoards Boards { get; }
		ILists Lists { get; }
		ICards Cards { get; }
		IChecklists Checklists { get; }
		IOrganizations Organizations { get;}
	}
}
