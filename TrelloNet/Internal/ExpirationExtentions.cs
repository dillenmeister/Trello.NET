using System;

namespace TrelloNet.Internal
{
	internal static class ExpirationExtentions
	{
		internal static string ToExpirationString(this Expiration mode)
		{
			if (mode == Expiration.ThirtyDays)
				return "30days";
			if (mode == Expiration.OneHour)
				return "1hour";
			if (mode == Expiration.OneDay)
				return "1day";
			if (mode == Expiration.Never)
				return "never";

			throw new InvalidOperationException("Unknown expiration: " + mode);
		}
	}
}