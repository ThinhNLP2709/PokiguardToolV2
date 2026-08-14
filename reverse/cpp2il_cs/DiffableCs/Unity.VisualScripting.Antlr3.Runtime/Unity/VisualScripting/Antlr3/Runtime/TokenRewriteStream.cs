namespace Unity.VisualScripting.Antlr3.Runtime;

public class TokenRewriteStream : CommonTokenStream
{
	private class DeleteOp : ReplaceOp
	{

		public DeleteOp(int from, int to, TokenRewriteStream parent) { }

		public virtual string ToString() { }

	}

	private class InsertBeforeOp : RewriteOperation
	{

		public InsertBeforeOp(int index, object text, TokenRewriteStream parent) { }

		public virtual int Execute(StringBuilder buf) { }

	}

	private class ReplaceOp : RewriteOperation
	{
		protected private int lastIndex; //Field offset: 0x28

		public ReplaceOp(int from, int to, object text, TokenRewriteStream parent) { }

		public virtual int Execute(StringBuilder buf) { }

		public virtual string ToString() { }

	}

	private class RewriteOpComparer : IComparer
	{

		public RewriteOpComparer() { }

		public override int Compare(object o1, object o2) { }

	}

	private class RewriteOperation
	{
		protected private int instructionIndex; //Field offset: 0x10
		protected private int index; //Field offset: 0x14
		protected private object text; //Field offset: 0x18
		protected private TokenRewriteStream parent; //Field offset: 0x20

		protected private RewriteOperation(int index, object text, TokenRewriteStream parent) { }

		public override int Execute(StringBuilder buf) { }

		public virtual string ToString() { }

	}

	public const string DEFAULT_PROGRAM_NAME = "default"; //Field offset: 0x0
	public const int PROGRAM_INIT_SIZE = 100; //Field offset: 0x0
	public const int MIN_TOKEN_INDEX = 0; //Field offset: 0x0
	protected IDictionary programs; //Field offset: 0x40
	protected IDictionary lastRewriteTokenIndexes; //Field offset: 0x48

	public TokenRewriteStream() { }

	public TokenRewriteStream(ITokenSource tokenSource) { }

	public TokenRewriteStream(ITokenSource tokenSource, int channel) { }

	protected string CatOpText(object a, object b) { }

	public override void Delete(string programName, IToken from, IToken to) { }

	public override void Delete(string programName, int from, int to) { }

	public override void Delete(IToken from, IToken to) { }

	public override void Delete(IToken indexT) { }

	public override void Delete(int from, int to) { }

	public override void Delete(int index) { }

	public override void DeleteProgram(string programName) { }

	public override void DeleteProgram() { }

	protected IList GetKindOfOps(IList rewrites, Type kind) { }

	protected IList GetKindOfOps(IList rewrites, Type kind, int before) { }

	public override int GetLastRewriteTokenIndex() { }

	protected override int GetLastRewriteTokenIndex(string programName) { }

	protected override IList GetProgram(string name) { }

	protected private override void Init() { }

	private IList InitializeProgram(string name) { }

	public override void InsertAfter(int index, object text) { }

	public override void InsertAfter(IToken t, object text) { }

	public override void InsertAfter(string programName, int index, object text) { }

	public override void InsertAfter(string programName, IToken t, object text) { }

	public override void InsertBefore(string programName, IToken t, object text) { }

	public override void InsertBefore(int index, object text) { }

	public override void InsertBefore(IToken t, object text) { }

	public override void InsertBefore(string programName, int index, object text) { }

	protected IDictionary ReduceToSingleOperationPerIndex(IList rewrites) { }

	public override void Replace(IToken from, IToken to, object text) { }

	public override void Replace(IToken indexT, object text) { }

	public override void Replace(int from, int to, object text) { }

	public override void Replace(int index, object text) { }

	public override void Replace(string programName, int from, int to, object text) { }

	public override void Replace(string programName, IToken from, IToken to, object text) { }

	public override void Rollback(int instructionIndex) { }

	public override void Rollback(string programName, int instructionIndex) { }

	protected override void SetLastRewriteTokenIndex(string programName, int i) { }

	public override string ToDebugString() { }

	public override string ToDebugString(int start, int end) { }

	public override string ToOriginalString() { }

	public override string ToOriginalString(int start, int end) { }

	public virtual string ToString() { }

	public override string ToString(string programName) { }

	public virtual string ToString(int start, int end) { }

	public override string ToString(string programName, int start, int end) { }

}

