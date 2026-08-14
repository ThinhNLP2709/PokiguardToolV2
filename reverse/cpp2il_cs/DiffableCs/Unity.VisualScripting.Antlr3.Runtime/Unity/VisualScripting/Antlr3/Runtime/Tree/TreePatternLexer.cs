namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public class TreePatternLexer
{
	public const int EOF = -1; //Field offset: 0x0
	public const int BEGIN = 1; //Field offset: 0x0
	public const int END = 2; //Field offset: 0x0
	public const int ID = 3; //Field offset: 0x0
	public const int ARG = 4; //Field offset: 0x0
	public const int PERCENT = 5; //Field offset: 0x0
	public const int COLON = 6; //Field offset: 0x0
	public const int DOT = 7; //Field offset: 0x0
	protected string pattern; //Field offset: 0x10
	protected int p; //Field offset: 0x18
	protected int c; //Field offset: 0x1C
	protected int n; //Field offset: 0x20
	public StringBuilder sval; //Field offset: 0x28
	public bool error; //Field offset: 0x30

	public TreePatternLexer(string pattern) { }

	protected void Consume() { }

	public int NextToken() { }

}

