using System;

namespace TrelloNet
{
	public interface IUpdatableCard
	{
		string Id { get; set; }
		string Name { get; set; }
		string Desc { get; set; }
		bool Closed { get; set; }
		string IdList { get; set; }
		DateTime? Due { get; set; }

	}
}