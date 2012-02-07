using System;

namespace TrelloNet.Internal
{
	internal static class AccessModeExtentions
	{
		internal static string ToAccessModeString(this AccessMode mode)
		{
			if (mode == AccessMode.ReadOnly)
				return "read";
			if (mode == AccessMode.ReadWrite)
				return "read,write";

			throw new InvalidOperationException("Unknown access mode: " + mode);
		}
	}
}