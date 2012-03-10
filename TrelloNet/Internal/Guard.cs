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
	}
}