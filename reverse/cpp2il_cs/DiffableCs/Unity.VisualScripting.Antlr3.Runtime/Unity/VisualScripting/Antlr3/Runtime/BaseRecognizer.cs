namespace Unity.VisualScripting.Antlr3.Runtime;

public abstract class BaseRecognizer
{
	public const int MEMO_RULE_FAILED = -2; //Field offset: 0x0
	public const int MEMO_RULE_UNKNOWN = -1; //Field offset: 0x0
	public const int INITIAL_FOLLOW_STACK_SIZE = 100; //Field offset: 0x0
	public const int DEFAULT_TOKEN_CHANNEL = 0; //Field offset: 0x0
	public const int HIDDEN = 99; //Field offset: 0x0
	public static readonly string NEXT_TOKEN_RULE_NAME; //Field offset: 0x0
	protected private RecognizerSharedState state; //Field offset: 0x10

	public int BacktrackingLevel
	{
		 get { } //Length: 26
		 set { } //Length: 26
	}

	public override string GrammarFileName
	{
		 get { } //Length: 3
	}

	public abstract IIntStream Input
	{
		 get { } //Length: 0
	}

	public int NumberOfSyntaxErrors
	{
		 get { } //Length: 26
	}

	public abstract string SourceName
	{
		 get { } //Length: 0
	}

	public override String[] TokenNames
	{
		 get { } //Length: 3
	}

	private static BaseRecognizer() { }

	public BaseRecognizer() { }

	public BaseRecognizer(RecognizerSharedState state) { }

	public override bool AlreadyParsedRule(IIntStream input, int ruleIndex) { }

	public override void BeginBacktrack(int level) { }

	public override void BeginResync() { }

	protected private override BitSet CombineFollows(bool exact) { }

	protected private override BitSet ComputeContextSensitiveRuleFOLLOW() { }

	protected private override BitSet ComputeErrorRecoverySet() { }

	public override void ConsumeUntil(IIntStream input, BitSet set) { }

	public override void ConsumeUntil(IIntStream input, int tokenType) { }

	public override void DisplayRecognitionError(String[] tokenNames, RecognitionException e) { }

	public override void EmitErrorMessage(string msg) { }

	public override void EndBacktrack(int level, bool successful) { }

	public override void EndResync() { }

	public bool Failed() { }

	public int get_BacktrackingLevel() { }

	public override string get_GrammarFileName() { }

	public abstract IIntStream get_Input() { }

	public int get_NumberOfSyntaxErrors() { }

	public abstract string get_SourceName() { }

	public override String[] get_TokenNames() { }

	protected override object GetCurrentInputSymbol(IIntStream input) { }

	public override string GetErrorHeader(RecognitionException e) { }

	public override string GetErrorMessage(RecognitionException e, String[] tokenNames) { }

	protected override object GetMissingSymbol(IIntStream input, RecognitionException e, int expectedTokenType, BitSet follow) { }

	public override IList GetRuleInvocationStack() { }

	public static IList GetRuleInvocationStack(Exception e, string recognizerClassName) { }

	public override int GetRuleMemoization(int ruleIndex, int ruleStartIndex) { }

	public int GetRuleMemoizationCacheSize() { }

	public override string GetTokenErrorDisplay(IToken t) { }

	public override object Match(IIntStream input, int ttype, BitSet follow) { }

	public override void MatchAny(IIntStream input) { }

	public override void Memoize(IIntStream input, int ruleIndex, int ruleStartIndex) { }

	public bool MismatchIsMissingToken(IIntStream input, BitSet follow) { }

	public bool MismatchIsUnwantedToken(IIntStream input, int ttype) { }

	protected void PushFollow(BitSet fset) { }

	public override void Recover(IIntStream input, RecognitionException re) { }

	public override object RecoverFromMismatchedSet(IIntStream input, RecognitionException e, BitSet follow) { }

	protected private override object RecoverFromMismatchedToken(IIntStream input, int ttype, BitSet follow) { }

	public override void ReportError(RecognitionException e) { }

	public override void Reset() { }

	public void set_BacktrackingLevel(int value) { }

	public override IList ToStrings(IList tokens) { }

	public override void TraceIn(string ruleName, int ruleIndex, object inputSymbol) { }

	public override void TraceOut(string ruleName, int ruleIndex, object inputSymbol) { }

}

