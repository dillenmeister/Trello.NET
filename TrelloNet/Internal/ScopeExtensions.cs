using System;
using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal static class ScopeExtensions
	{
		private static readonly Dictionary<Scope, string> Map = new Dictionary<Scope, string> 
		{
			{ Scope.ReadOnly, "read"},
			{ Scope.ReadWrite, "read,write"},
			{ Scope.ReadOnlyAccount, "read,account"},
			{ Scope.ReadWriteAccount, "read,write,account"}
		};

		internal static string ToScopeString(this Scope scope)
		{
			return Map[scope];			
		}
	}
}