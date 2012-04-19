using System;
using TrelloNet.Internal;

namespace TrelloNet
{
	public static class Since
	{
		public static ISince LastView { get { return new SinceLastView();} }
		public static ISince Date(DateTime date) { return new SinceDate(date); }
	}
}