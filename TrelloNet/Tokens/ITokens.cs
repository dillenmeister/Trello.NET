namespace TrelloNet
{
	public interface ITokens
	{
		/// <summary>
		/// GET /tokens/[token]
		/// </summary>
		Token WithToken(string token);
	}
}