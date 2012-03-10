using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncTokens
	{
		Task<Token> WithToken(string token);
	}
}