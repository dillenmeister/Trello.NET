using System.Threading.Tasks;

namespace TrelloNet
{
    public interface IAsyncAdvanced
    {  /// <summary>
        /// Issue a GET request.
        /// </summary>
        /// <typeparam name="T">The type the response is deserialized to</typeparam>
        /// <param name="uri">The URI to the resource</param>
        /// <param name="arguments">Additional arguments to the request</param>
        /// <returns>The response deserialized to the specified type</returns>
        Task<T> Get<T>(string uri, dynamic arguments = null) where T : class, new();

        /// <summary>
        /// Issue a GET request.
        /// </summary>
        /// <param name="uri">The URI to the resource</param>
        /// <param name="arguments">Additional arguments to the request</param>
        /// <returns>The response deserialized to a dynamic object</returns>
        Task<dynamic> Get(string uri, dynamic arguments = null);

        /// <summary>
        /// Issue a PUT request.
        /// </summary>
        /// <typeparam name="T">The type the response is deserialized to</typeparam>
        /// <param name="uri">The URI to the resource</param>
        /// <param name="arguments">Additional arguments to the request</param>
        /// <returns>The response deserialized to the specified type</returns>
        Task<T> Put<T>(string uri, dynamic arguments = null) where T : class, new();

        /// <summary>
        /// Issue a PUT request.
        /// </summary>
        /// <param name="uri">The URI to the resource</param>
        /// <param name="arguments">Additional arguments to the request</param>
        /// <returns>The response deserialized to a dynamic object</returns>
        Task<dynamic> Put(string uri, dynamic arguments = null);

        /// <summary>
        /// Issue a POST request.
        /// </summary>
        /// <typeparam name="T">The type the response is deserialized to</typeparam>
        /// <param name="uri">The URI to the resource</param>
        /// <param name="arguments">Additional arguments to the request</param>
        /// <returns>The response deserialized to the specified type</returns>
        Task<T> Post<T>(string uri, dynamic arguments = null) where T : class, new();

        /// <summary>
        /// Issue a POST request.
        /// </summary>
        /// <param name="uri">The URI to the resource</param>
        /// <param name="arguments">Additional arguments to the request</param>
        /// <returns>The response deserialized to a dynamic object</returns>
        Task<dynamic> Post(string uri, dynamic arguments = null);

        /// <summary>
        /// Issue a DELETE request.
        /// </summary>
        /// <typeparam name="T">The type the response is deserialized to</typeparam>
        /// <param name="uri">The URI to the resource</param>
        /// <param name="arguments">Additional arguments to the request</param>
        /// <returns>The response deserialized to the specified type</returns>
        Task<T> Delete<T>(string uri, dynamic arguments = null) where T : class, new();

        /// <summary>
        /// Issue a DELETE request.
        /// </summary>
        /// <param name="uri">The URI to the resource</param>
        /// <param name="arguments">Additional arguments to the request</param>
        /// <returns>The response deserialized to a dynamic object</returns>
        Task<dynamic> Delete(string uri, dynamic arguments = null);
    }
}