namespace TrelloNet
{
	public interface IUpdatableBoard
	{
		string Id { get; }
		string Name { get; }
		bool Closed { get; }
	}
}