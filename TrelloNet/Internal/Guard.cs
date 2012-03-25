using System;

namespace TrelloNet.Internal
{
	internal static class Guard
	{
		public static void NotNull(object parameter, string parameterName)
		{
			if (parameter == null)
				throw new ArgumentNullException(parameterName);
		}

		public static void NotNullOrEmpty(string parameter, string parameterName)
		{
			if (parameter == null)
				throw new ArgumentNullException(parameterName);
			if (parameter == string.Empty)
				throw new ArgumentException(string.Format("Parameter {0} is empty.", parameterName), parameterName);
		}

		public static void InRange(int parameter, int min, int max, string parameterName)
		{
			if(parameter < min || parameter > max)
				throw new ArgumentOutOfRangeException(parameterName, parameter, string.Format("Parameter {0} is out of range (must be between {1} and {2})", parameterName, min, max));
		}

		private static void LengthBetween(string parameter, int min, int max, string parameterName)
		{
			NotNull(parameter, parameterName);
			if (parameter.Length < min || parameter.Length > max)
				throw new ArgumentOutOfRangeException(parameterName, parameter.Length, string.Format("Length of string parameter {0} is out of range (must be between {1} and {2})", parameterName, min, max));
		}

		public static void OptionalTrelloString(string parameter, string parameterName)
		{
			LengthBetween(parameter, 0, 16384, parameterName);
		}

		public static void RequiredTrelloString(string parameter, string parameterName)
		{
			LengthBetween(parameter, 1, 16384, parameterName);
		}
	}
}