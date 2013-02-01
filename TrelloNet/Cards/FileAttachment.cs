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
		/// <param name="name"> A string with a length from 0 to 256.</param>
		public FileAttachment(string filePath, string name)
		{
			FilePath = filePath;
			Name = name;
		}

		public string FilePath { get; set; }
		public string Name { get; set; }
	}
}