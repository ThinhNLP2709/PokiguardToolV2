namespace Unity.VisualScripting.Antlr3.Runtime;

public class RecognizerSharedState
{
	public BitSet[] following; //Field offset: 0x10
	public int followingStackPointer; //Field offset: 0x18
	public bool errorRecovery; //Field offset: 0x1C
	public int lastErrorIndex; //Field offset: 0x20
	public bool failed; //Field offset: 0x24
	public int syntaxErrors; //Field offset: 0x28
	public int backtracking; //Field offset: 0x2C
	public IDictionary[] ruleMemo; //Field offset: 0x30
	public IToken token; //Field offset: 0x38
	public int tokenStartCharIndex; //Field offset: 0x40
	public int tokenStartLine; //Field offset: 0x44
	public int tokenStartCharPositionInLine; //Field offset: 0x48
	public int channel; //Field offset: 0x4C
	public int type; //Field offset: 0x50
	public string text; //Field offset: 0x58

	public RecognizerSharedState() { }

}

