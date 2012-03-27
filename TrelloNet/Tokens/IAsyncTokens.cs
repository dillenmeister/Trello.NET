using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncTokens
	{
		/// <summary>
		/// GET /tokens/[token]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<Token> WithToken(string token);
	}
}