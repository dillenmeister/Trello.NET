using System;

namespace TrelloNet
{
	public interface ISince
	{
		bool LastView { get; }
		DateTime Date { get; }
	}
}