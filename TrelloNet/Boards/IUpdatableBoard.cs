namespace TrelloNet
{
	public interface IUpdatableBoard
	{
		string Id { get; }
		string Name { get; }
		string Desc { get; }
		bool Closed { get; }
	}
}