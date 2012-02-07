using RestSharp;

namespace TrelloNet.Internal
{
	internal class MemberTokenAuthenticator : IAuthenticator
	{
		private readonly string _token;

		public MemberTokenAuthenticator(string token)
		{
			_token = token;
		}

		public void Authenticate(IRestClient client, IRestRequest request)
		{
			request.AddParameter("token", _token);
		}
	}
}