namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public class TreeWizard
{
	internal interface ContextVisitor
	{

		public void Visit(object t, object parent, int childIndex, IDictionary labels) { }

	}

	private sealed class InvokeVisitorOnPatternMatchContextVisitor : ContextVisitor
	{
		private TreeWizard owner; //Field offset: 0x10
		private TreePattern pattern; //Field offset: 0x18
		private ContextVisitor visitor; //Field offset: 0x20
		private Hashtable labels; //Field offset: 0x28

		public InvokeVisitorOnPatternMatchContextVisitor(TreeWizard owner, TreePattern pattern, ContextVisitor visitor) { }

		public override void Visit(object t, object parent, int childIndex, IDictionary unusedlabels) { }

	}

	private sealed class PatternMatchingContextVisitor : ContextVisitor
	{
		private TreeWizard owner; //Field offset: 0x10
		private TreePattern pattern; //Field offset: 0x18
		private IList list; //Field offset: 0x20

		public PatternMatchingContextVisitor(TreeWizard owner, TreePattern pattern, IList list) { }

		public override void Visit(object t, object parent, int childIndex, IDictionary labels) { }

	}

	private sealed class RecordAllElementsVisitor : Visitor
	{
		private IList list; //Field offset: 0x10

		public RecordAllElementsVisitor(IList list) { }

		public virtual void Visit(object t) { }

	}

	internal class TreePattern : CommonTree
	{
		public string label; //Field offset: 0x38
		public bool hasTextArg; //Field offset: 0x40

		public TreePattern(IToken payload) { }

		public virtual string ToString() { }

	}

	internal class TreePatternTreeAdaptor : CommonTreeAdaptor
	{

		public TreePatternTreeAdaptor() { }

		public virtual object Create(IToken payload) { }

	}

	internal abstract class Visitor : ContextVisitor
	{

		protected Visitor() { }

		public abstract void Visit(object t) { }

		public override void Visit(object t, object parent, int childIndex, IDictionary labels) { }

	}

	internal class WildcardTreePattern : TreePattern
	{

		public WildcardTreePattern(IToken payload) { }

	}

	protected ITreeAdaptor adaptor; //Field offset: 0x10
	protected IDictionary tokenNameToTypeMap; //Field offset: 0x18

	protected static bool _Equals(object t1, object t2, ITreeAdaptor adaptor) { }

	protected void _Index(object t, IDictionary m) { }

	protected bool _Parse(object t1, TreePattern t2, IDictionary labels) { }

	protected void _Visit(object t, object parent, int childIndex, int ttype, ContextVisitor visitor) { }

	public TreeWizard(ITreeAdaptor adaptor) { }

	public TreeWizard(ITreeAdaptor adaptor, String[] tokenNames) { }

	public TreeWizard(String[] tokenNames) { }

	public TreeWizard(ITreeAdaptor adaptor, IDictionary tokenNameToTypeMap) { }

	public IDictionary ComputeTokenTypes(String[] tokenNames) { }

	public object Create(string pattern) { }

	public static bool Equals(object t1, object t2, ITreeAdaptor adaptor) { }

	public bool Equals(object t1, object t2) { }

	public IList Find(object t, int ttype) { }

	public IList Find(object t, string pattern) { }

	public object FindFirst(object t, int ttype) { }

	public object FindFirst(object t, string pattern) { }

	public int GetTokenType(string tokenName) { }

	public IDictionary Index(object t) { }

	public bool Parse(object t, string pattern, IDictionary labels) { }

	public bool Parse(object t, string pattern) { }

	public void Visit(object t, int ttype, ContextVisitor visitor) { }

	public void Visit(object t, string pattern, ContextVisitor visitor) { }

}

