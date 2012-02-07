using System;

namespace TrelloNet.Internal
{
	internal static class EnumExtentions
	{
		internal static string ToTrelloString(this Enum e)
		{
// ReSharper disable SpecifyACultureInStringConversionExplicitly
			return e.ToString().ToLowerInvariant();
// ReSharper restore SpecifyACultureInStringConversionExplicitly
		}
	}
}