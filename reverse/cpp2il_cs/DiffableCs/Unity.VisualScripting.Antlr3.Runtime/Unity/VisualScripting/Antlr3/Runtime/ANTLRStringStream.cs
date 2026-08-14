namespace Unity.VisualScripting.Antlr3.Runtime;

public class ANTLRStringStream : ICharStream, IIntStream
{
	protected private Char[] data; //Field offset: 0x10
	protected int n; //Field offset: 0x18
	protected private int p; //Field offset: 0x1C
	protected private int line; //Field offset: 0x20
	protected private int charPositionInLine; //Field offset: 0x24
	protected private int markDepth; //Field offset: 0x28
	protected private IList markers; //Field offset: 0x30
	protected int lastMarker; //Field offset: 0x38
	protected string name; //Field offset: 0x40

	public override int CharPositionInLine
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public override int Count
	{
		 get { } //Length: 4
	}

	public override int Line
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public override string SourceName
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	protected ANTLRStringStream() { }

	public ANTLRStringStream(string input) { }

	public ANTLRStringStream(Char[] data, int numberOfActualCharsInArray) { }

	public override void Consume() { }

	public override int get_CharPositionInLine() { }

	public override int get_Count() { }

	public override int get_Line() { }

	public override string get_SourceName() { }

	public override int Index() { }

	public override int LA(int i) { }

	public override int LT(int i) { }

	public override int Mark() { }

	public override void Release(int marker) { }

	public override void Reset() { }

	public override void Rewind(int m) { }

	public override void Rewind() { }

	public override void Seek(int index) { }

	public override void set_CharPositionInLine(int value) { }

	public override void set_Line(int value) { }

	public override void set_SourceName(string value) { }

	[Obsolete("Please use property Count instead.")]
	public override int Size() { }

	public override string Substring(int start, int stop) { }

}

