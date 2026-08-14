namespace Unity.VisualScripting.Antlr3.Runtime;

public class ANTLRFileStream : ANTLRStringStream
{
	protected string fileName; //Field offset: 0x48

	public virtual string SourceName
	{
		 get { } //Length: 5
	}

	protected ANTLRFileStream() { }

	public ANTLRFileStream(string fileName) { }

	public ANTLRFileStream(string fileName, Encoding encoding) { }

	public virtual string get_SourceName() { }

	private long GetFileLength(FileInfo file) { }

	public override void Load(string fileName, Encoding encoding) { }

}

