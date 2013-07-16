using System;

namespace TrelloNet.Internal
{
	internal class SinceDate : ISince
	{
		private readonly DateTime _date;

		public SinceDate(DateTime date)
		{
            // Trello uses UTC internally, so if dates are not
            // specified as being otherwise, assume UTC
		    if (date.Kind == DateTimeKind.Unspecified)
		        date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
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