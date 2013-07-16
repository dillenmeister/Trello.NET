using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using RestSharp;

namespace TrelloNet.Internal
{
	internal class TrelloRestClient : RestClient
	{
		private readonly string _applicationKey;
		private const string BASE_URL = "https://api.trello.com/1";

		public TrelloRestClient(string applicationKey)
			: base(BASE_URL)
		{
			_applicationKey = applicationKey;
			this.AddDefaultParameter("key", applicationKey);
			AddHandler("application/json", new TrelloDeserializer());
		}

		public void Authenticate(string memberToken)
		{
			Authenticator = memberToken == null ? null : new MemberTokenAuthenticator(memberToken);
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

			ThrowIfRequestWasUnsuccessful(request, response);
		}

		public T Request<T>(IRestRequest request) where T : class, new()
		{
			var response = Execute<T>(request);

			ThrowIfRequestWasUnsuccessful(request, response);

			return response.StatusCode == HttpStatusCode.NotFound ? null : response.Data;
		}

		public Task RequestAsync(IRestRequest request)
		{
			var tcs = new TaskCompletionSource<object>();

			ExecuteAsync(request, (response, handle) =>
			{
				try
				{
					ThrowIfRequestWasUnsuccessful(request, response);
					tcs.SetResult(null);
				}
				catch (Exception e)
				{
					tcs.SetException(e);
				}
			});

			return tcs.Task;
		}

		public Task<T> RequestAsync<T>(IRestRequest request) where T : class, new()
		{
			var tcs = new TaskCompletionSource<T>();

			ExecuteAsync<T>(request, (response, handle) =>
			{
				try
				{
					ThrowIfRequestWasUnsuccessful(request, response);
					tcs.SetResult(response.StatusCode == HttpStatusCode.NotFound ? null : response.Data);
				}
				catch (Exception e)
				{
					tcs.SetException(e);
				}
			});

			return tcs.Task;
		}

		public Task<IEnumerable<T>> RequestListAsync<T>(IRestRequest request)
		{
			var tcs = new TaskCompletionSource<IEnumerable<T>>();

			ExecuteAsync<List<T>>(request, (response, handle) =>
			{
				try
				{
					ThrowIfRequestWasUnsuccessful(request, response);
					tcs.SetResult(response.StatusCode == HttpStatusCode.NotFound ? null : response.Data);
				}
				catch (Exception e)
				{
					tcs.SetException(e);
				}
			});

			return tcs.Task;
		}

		private void ThrowIfRequestWasUnsuccessful(IRestRequest request, IRestResponse response)
		{
			Debug.WriteLine(BuildUri(request));
			Debug.WriteLine(response.Content);

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