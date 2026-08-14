namespace Unity.VisualScripting.Antlr3.Runtime;

public class ANTLRInputStream : ANTLRReaderStream
{

	protected ANTLRInputStream() { }

	public ANTLRInputStream(Stream istream) { }

	public ANTLRInputStream(Stream istream, Encoding encoding) { }

	public ANTLRInputStream(Stream istream, int size) { }

	public ANTLRInputStream(Stream istream, int size, Encoding encoding) { }

	public ANTLRInputStream(Stream istream, int size, int readBufferSize, Encoding encoding) { }

}

