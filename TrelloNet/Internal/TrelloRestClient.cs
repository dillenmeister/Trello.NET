using System;
using System.Net;
using RestSharp;

namespace TrelloNet.Internal
{
	internal class TrelloRestClient : RestClient
	{
		private readonly string _applicationKey;
		private const string BASE_URL = "https://trello.com/1";

		public TrelloRestClient(string applicationKey)
			: base(BASE_URL)
		{
			_applicationKey = applicationKey;
			AddDefaultParameter("key", applicationKey);
			AddHandler("application/json", new TrelloDeserializer());
		}

		public void Authenticate(string memberToken)
		{
			Authenticator = new MemberTokenAuthenticator(memberToken);
		}

		public Uri GetAuthenticationlUrl(string applicationName, AccessMode mode)
		{
			return new Uri(string.Format("{0}/connect?key={1}&name={2}&response_type=token&context={3}", 
				BaseUrl, _applicationKey, applicationName, mode.ToAccessModeString()));
		}

		public T Request<T>(IRestRequest request) where T : class, new()
		{		
			var response = Execute<T>(request);

			if (response.StatusCode == HttpStatusCode.NotFound)
				return null;
			if (response.StatusCode == HttpStatusCode.Unauthorized)
				throw new TrelloUnauthorizedException(response.Content);
			if (response.StatusCode != HttpStatusCode.OK)
				throw new TrelloException(response.Content);

			return response.Data;
		}
	}
}