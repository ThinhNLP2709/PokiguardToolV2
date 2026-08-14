namespace Unity.VisualScripting.Antlr3.Runtime;

public abstract class Lexer : BaseRecognizer, ITokenSource
{
	private const int TOKEN_dot_EOF = -1; //Field offset: 0x0
	protected private ICharStream input; //Field offset: 0x18

	public override int CharIndex
	{
		 get { } //Length: 73
	}

	public override int CharPositionInLine
	{
		 get { } //Length: 73
	}

	public override ICharStream CharStream
	{
		 get { } //Length: 5
		 set { } //Length: 83
	}

	public virtual IIntStream Input
	{
		 get { } //Length: 5
	}

	public override int Line
	{
		 get { } //Length: 70
	}

	public virtual string SourceName
	{
		 get { } //Length: 73
	}

	public override string Text
	{
		 get { } //Length: 172
		 set { } //Length: 35
	}

	public Lexer() { }

	public Lexer(ICharStream input) { }

	public Lexer(ICharStream input, RecognizerSharedState state) { }

	public override void Emit(IToken token) { }

	public override IToken Emit() { }

	public override int get_CharIndex() { }

	public override int get_CharPositionInLine() { }

	public override ICharStream get_CharStream() { }

	public virtual IIntStream get_Input() { }

	public override int get_Line() { }

	public virtual string get_SourceName() { }

	public override string get_Text() { }

	public string GetCharErrorDisplay(int c) { }

	public virtual string GetErrorMessage(RecognitionException e, String[] tokenNames) { }

	public override void Match(int c) { }

	public override void Match(string s) { }

	public override void MatchAny() { }

	public override void MatchRange(int a, int b) { }

	public abstract void mTokens() { }

	public override IToken NextToken() { }

	public override void Recover(RecognitionException re) { }

	public virtual void ReportError(RecognitionException e) { }

	public virtual void Reset() { }

	public override void set_CharStream(ICharStream value) { }

	public override void set_Text(string value) { }

	public void Skip() { }

	public override void TraceIn(string ruleName, int ruleIndex) { }

	public override void TraceOut(string ruleName, int ruleIndex) { }

}

