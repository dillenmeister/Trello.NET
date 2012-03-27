namespace TrelloNet.Internal
{
	public static class BooleanExtensions
	{		 
		public static string ToTrelloString(this bool value)
		{
			return value ? "true" : "false";
		}
	}
}