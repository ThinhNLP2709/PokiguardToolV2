namespace Unity.VisualScripting.Antlr3.Runtime;

public class ANTLRReaderStream : ANTLRStringStream
{
	public static readonly int READ_BUFFER_SIZE; //Field offset: 0x0
	public static readonly int INITIAL_BUFFER_SIZE; //Field offset: 0x4

	private static ANTLRReaderStream() { }

	protected ANTLRReaderStream() { }

	public ANTLRReaderStream(TextReader reader) { }

	public ANTLRReaderStream(TextReader reader, int size) { }

	public ANTLRReaderStream(TextReader reader, int size, int readChunkSize) { }

	public override void Load(TextReader reader, int size, int readChunkSize) { }

}

