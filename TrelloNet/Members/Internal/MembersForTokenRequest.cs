namespace TrelloNet.Internal
{
	internal class MembersForTokenRequest : TokensRequest
	{
		public MembersForTokenRequest(string token)
			: base(token, "member")
		{
		}
	}
}