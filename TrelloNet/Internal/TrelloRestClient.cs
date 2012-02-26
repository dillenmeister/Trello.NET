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

		public Uri GetAuthorizationUrl(string applicationName, Scope scope, Expiration expiration)
		{
			Guard.NotNullOrEmpty(applicationName, "applicationName");

			return new Uri(string.Format("{0}/connect?key={1}&name={2}&response_type=token&scope={3}&expiration={4}", 
				BaseUrl, _applicationKey, applicationName, scope.ToScopeString(), expiration.ToExpirationString()));
		}

		public void Request(IRestRequest request)
		{
			var response = Execute(request);

			HandleUnsuccessfulRequest(request, response);
		}

		public T Request<T>(IRestRequest request) where T : class, new()
		{		
			var response = Execute<T>(request);

			HandleUnsuccessfulRequest(request, response);

			if (response.StatusCode == HttpStatusCode.NotFound)
				return null;

			return response.Data;
		}

		private static void HandleUnsuccessfulRequest(IRestRequest request, IRestResponse response)
		{
			// If PUT, POST or DELETE and not found, we'll throw, but for GET it's fine.
			if (request.Method == Method.GET && response.StatusCode == HttpStatusCode.NotFound)
				return;

			if (response.StatusCode == HttpStatusCode.Unauthorized)
				throw new TrelloUnauthorizedException(response.Content);
			if (response.StatusCode != HttpStatusCode.OK)
				throw new TrelloException(response.Content);
		}
	}
}