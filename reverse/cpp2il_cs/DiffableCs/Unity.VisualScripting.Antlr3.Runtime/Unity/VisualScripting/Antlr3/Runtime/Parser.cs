namespace Unity.VisualScripting.Antlr3.Runtime;

public class Parser : BaseRecognizer
{
	protected private ITokenStream input; //Field offset: 0x18

	public virtual IIntStream Input
	{
		 get { } //Length: 5
	}

	public virtual string SourceName
	{
		 get { } //Length: 73
	}

	public override ITokenStream TokenStream
	{
		 get { } //Length: 5
		 set { } //Length: 83
	}

	public Parser(ITokenStream input) { }

	public Parser(ITokenStream input, RecognizerSharedState state) { }

	public virtual IIntStream get_Input() { }

	public virtual string get_SourceName() { }

	public override ITokenStream get_TokenStream() { }

	protected virtual object GetCurrentInputSymbol(IIntStream input) { }

	protected virtual object GetMissingSymbol(IIntStream input, RecognitionException e, int expectedTokenType, BitSet follow) { }

	public virtual void Reset() { }

	public override void set_TokenStream(ITokenStream value) { }

	public override void TraceIn(string ruleName, int ruleIndex) { }

	public override void TraceOut(string ruleName, int ruleIndex) { }

}

