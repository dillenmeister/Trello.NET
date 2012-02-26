using System;

namespace TrelloNet.Internal
{
	internal static class ExpirationExtentions
	{
		internal static string ToExpirationString(this Expiration expiration)
		{
			if (expiration == Expiration.ThirtyDays)
				return "30days";
			if (expiration == Expiration.OneHour)
				return "1hour";
			if (expiration == Expiration.OneDay)
				return "1day";
			if (expiration == Expiration.Never)
				return "never";

			throw new InvalidOperationException("Unknown expiration: " + expiration);
		}
	}
}