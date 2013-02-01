namespace TrelloNet
{
	public class BytesAttachment
	{
		/// <param name="contents">A file.</param>
		/// <param name="name">A string with a length from 0 to 256.</param>
		public BytesAttachment(byte[] contents, string name)
		{
			Contents = contents;
			Name = name;
		}

		/// <param name="contents">A file.</param>
		/// <param name="name">A string with a length from 0 to 256.</param>
		/// <param name="fileName">File name.</param>
		public BytesAttachment(byte[] contents, string name, string fileName)
		{
			Contents = contents;
			Name = name;
			FileName = fileName;
		}

		/// <summary>
		/// A file.
		/// </summary>
		public byte[] Contents { get; set; }

		/// <summary>
		///  A string with a length from 0 to 256.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// File name.
		/// </summary>
		public string FileName { get; set; }
	}
}