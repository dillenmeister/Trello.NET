using System;

namespace TrelloNet.Internal
{
	internal class SinceDate : ISince
	{
		private readonly DateTime _date;

		public SinceDate(DateTime date)
		{
			_date = date;
		}

		public bool LastView
		{
			get { return false; }
		}

		public DateTime Date
		{
			get { return _date; }
		}
	}
}