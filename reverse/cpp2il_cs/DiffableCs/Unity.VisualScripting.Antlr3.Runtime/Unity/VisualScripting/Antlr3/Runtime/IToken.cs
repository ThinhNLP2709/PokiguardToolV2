namespace Unity.VisualScripting.Antlr3.Runtime;

public interface IToken
{

	public int Channel
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int CharPositionInLine
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int Line
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string Text
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int TokenIndex
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int Type
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int get_Channel() { }

	public int get_CharPositionInLine() { }

	public int get_Line() { }

	public string get_Text() { }

	public int get_TokenIndex() { }

	public int get_Type() { }

	public void set_Channel(int value) { }

	public void set_CharPositionInLine(int value) { }

	public void set_Line(int value) { }

	public void set_Text(string value) { }

	public void set_TokenIndex(int value) { }

	public void set_Type(int value) { }

}

