using System;

namespace TrelloNet.Internal
{
	internal static class ScopeExtensions
	{
		internal static string ToScopeString(this Scope scope)
		{
			if (scope == Scope.ReadOnly)
				return "read";
			if (scope == Scope.ReadWrite)
				return "read,write";

			throw new InvalidOperationException("Unknown scope: " + scope);
		}
	}
}