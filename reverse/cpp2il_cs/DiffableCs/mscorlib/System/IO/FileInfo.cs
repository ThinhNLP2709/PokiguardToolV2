namespace System.IO;

public sealed class FileInfo : FileSystemInfo
{

	public DirectoryInfo Directory
	{
		 get { } //Length: 263
	}

	public string DirectoryName
	{
		 get { } //Length: 77
	}

	public long Length
	{
		 get { } //Length: 246
	}

	public virtual string Name
	{
		 get { } //Length: 5
	}

	private FileInfo() { }

	public FileInfo(string fileName) { }

	internal FileInfo(string originalPath, string fullPath = null, string fileName = null, bool isNormalized = false) { }

	private FileInfo(SerializationInfo info, StreamingContext context) { }

	public StreamWriter AppendText() { }

	public StreamWriter CreateText() { }

	public DirectoryInfo get_Directory() { }

	public string get_DirectoryName() { }

	public long get_Length() { }

	public virtual string get_Name() { }

	public FileStream OpenRead() { }

}

