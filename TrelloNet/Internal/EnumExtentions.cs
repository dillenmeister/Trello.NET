using System;

namespace TrelloNet.Internal
{
	internal static class EnumExtentions
	{
		internal static string ToTrelloString(this Enum e)
		{
			var s = e.ToString();
			return s.Substring(0, 1).ToLower() + s.Substring(1);
		}
	}
}