namespace Unity.VisualScripting.Antlr3.Runtime;

public interface ICharStream : IIntStream
{

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

	public int get_CharPositionInLine() { }

	public int get_Line() { }

	public int LT(int i) { }

	public void set_CharPositionInLine(int value) { }

	public void set_Line(int value) { }

	public string Substring(int start, int stop) { }

}

