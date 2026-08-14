namespace System.IO;

public abstract class FileSystemInfo : MarshalByRefObject, ISerializable
{
	private WIN32_FILE_ATTRIBUTE_DATA _data; //Field offset: 0x18
	private int _dataInitialized; //Field offset: 0x3C
	protected string FullPath; //Field offset: 0x40
	protected string OriginalPath; //Field offset: 0x48
	internal string _name; //Field offset: 0x50

	public FileAttributes Attributes
	{
		 get { } //Length: 109
	}

	public override bool Exists
	{
		 get { } //Length: 129
	}

	internal bool ExistsCore
	{
		internal get { } //Length: 126
	}

	public override string FullName
	{
		 get { } //Length: 5
	}

	internal long LengthCore
	{
		internal get { } //Length: 119
	}

	public override string Name
	{
		 get { } //Length: 5
	}

	internal string NormalizedPath
	{
		internal get { } //Length: 181
	}

	protected FileSystemInfo() { }

	protected FileSystemInfo(SerializationInfo info, StreamingContext context) { }

	private void EnsureDataInitialized() { }

	public FileAttributes get_Attributes() { }

	public override bool get_Exists() { }

	internal bool get_ExistsCore() { }

	public override string get_FullName() { }

	internal long get_LengthCore() { }

	public override string get_Name() { }

	internal string get_NormalizedPath() { }

	[ComVisible(False)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context) { }

	internal void Invalidate() { }

	public void Refresh() { }

	public virtual string ToString() { }

}

