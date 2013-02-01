namespace TrelloNet
{
	public class UrlAttachment
	{
		/// <summary>
		/// A string with a length from 1 to 256 (optional).
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// A string with a length from 1 to 16384.
		/// </summary>
		public string Url { get; set; }

		/// <param name="url">A string with a length from 1 to 16384.</param>
		/// <param name="name">A string with a length from 1 to 256.</param>
		public UrlAttachment(string url, string name)
		{
			Name = name;
            Url = url;
		}

		/// <param name="url">A string with a length from 1 to 16384.</param>
		public UrlAttachment(string url)
		{
            Url = url;
		}
	}
}