namespace Unity.VisualScripting.Antlr3.Runtime;

public class ClassicToken : IToken
{
	protected private string text; //Field offset: 0x10
	protected private int type; //Field offset: 0x18
	protected private int line; //Field offset: 0x1C
	protected private int charPositionInLine; //Field offset: 0x20
	protected private int channel; //Field offset: 0x24
	protected private int index; //Field offset: 0x28

	public override int Channel
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public override int CharPositionInLine
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public override ICharStream InputStream
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public override int Line
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public override string Text
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public override int TokenIndex
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public override int Type
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public ClassicToken(int type) { }

	public ClassicToken(IToken oldToken) { }

	public ClassicToken(int type, string text) { }

	public ClassicToken(int type, string text, int channel) { }

	public override int get_Channel() { }

	public override int get_CharPositionInLine() { }

	public override ICharStream get_InputStream() { }

	public override int get_Line() { }

	public override string get_Text() { }

	public override int get_TokenIndex() { }

	public override int get_Type() { }

	public override void set_Channel(int value) { }

	public override void set_CharPositionInLine(int value) { }

	public override void set_InputStream(ICharStream value) { }

	public override void set_Line(int value) { }

	public override void set_Text(string value) { }

	public override void set_TokenIndex(int value) { }

	public override void set_Type(int value) { }

	public virtual string ToString() { }

}

