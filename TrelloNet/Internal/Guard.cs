using System;

namespace TrelloNet.Internal
{
	internal static class Guard
	{
		public static void NotNull(object parameter, string parameterName)
		{
			if(parameter == null)
				throw new ArgumentNullException(parameterName);
		}

		public static void NotNullOrEmpty(string parameter, string parameterName)
		{
			if (parameter == null)
				throw new ArgumentNullException(parameterName);
			if(parameter == string.Empty)
				throw new ArgumentException(string.Format("Parameter {0} is empty.", parameterName), parameterName);
		}
	}
}