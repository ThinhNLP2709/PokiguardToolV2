namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public class TreeParser : BaseRecognizer
{
	public const int DOWN = 2; //Field offset: 0x0
	public const int UP = 3; //Field offset: 0x0
	private static readonly string dotdot; //Field offset: 0x0
	private static readonly string doubleEtc; //Field offset: 0x8
	private static readonly string spaces; //Field offset: 0x10
	private static readonly Regex dotdotPattern; //Field offset: 0x18
	private static readonly Regex doubleEtcPattern; //Field offset: 0x20
	private static readonly Regex spacesPattern; //Field offset: 0x28
	protected private ITreeNodeStream input; //Field offset: 0x18

	public virtual IIntStream Input
	{
		 get { } //Length: 5
	}

	public virtual string SourceName
	{
		 get { } //Length: 1694
	}

	public override ITreeNodeStream TreeNodeStream
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	private static TreeParser() { }

	public TreeParser(ITreeNodeStream input) { }

	public TreeParser(ITreeNodeStream input, RecognizerSharedState state) { }

	public virtual IIntStream get_Input() { }

	public virtual string get_SourceName() { }

	public override ITreeNodeStream get_TreeNodeStream() { }

	protected virtual object GetCurrentInputSymbol(IIntStream input) { }

	public virtual string GetErrorHeader(RecognitionException e) { }

	public virtual string GetErrorMessage(RecognitionException e, String[] tokenNames) { }

	protected virtual object GetMissingSymbol(IIntStream input, RecognitionException e, int expectedTokenType, BitSet follow) { }

	public virtual void MatchAny(IIntStream ignore) { }

	protected private virtual object RecoverFromMismatchedToken(IIntStream input, int ttype, BitSet follow) { }

	public virtual void Reset() { }

	public override void set_TreeNodeStream(ITreeNodeStream value) { }

	public override void TraceIn(string ruleName, int ruleIndex) { }

	public override void TraceOut(string ruleName, int ruleIndex) { }

}

