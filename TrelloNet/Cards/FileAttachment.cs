namespace TrelloNet
{
	public class FileAttachment
	{
		/// <param name="filePath">A file</param>
		public FileAttachment(string filePath)
		{
			FilePath = filePath;
		}

		/// <param name="filePath">A file.</param>
		/// <param name="name">A string with a length from 0 to 256.</param>
		public FileAttachment(string filePath, string name)
		{
			FilePath = filePath;
			Name = name;
		}

		/// <summary>
		/// A file.
		/// </summary>
		public string FilePath { get; set; }

		/// <summary>
		///  A string with a length from 0 to 256.
		/// </summary>
		public string Name { get; set; }
	}
}