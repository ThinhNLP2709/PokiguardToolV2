namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public class UnBufferedTreeNodeStream : ITreeNodeStream, IIntStream
{
	internal class TreeWalkState
	{
		protected private int currentChildIndex; //Field offset: 0x10
		protected private int absoluteNodeIndex; //Field offset: 0x14
		protected private object currentNode; //Field offset: 0x18
		protected private object previousNode; //Field offset: 0x20
		protected private int nodeStackSize; //Field offset: 0x28
		protected private int indexStackSize; //Field offset: 0x2C
		protected private Object[] lookahead; //Field offset: 0x30

		public TreeWalkState() { }

	}

	public const int INITIAL_LOOKAHEAD_BUFFER_SIZE = 5; //Field offset: 0x0
	private ITree currentEnumerationNode; //Field offset: 0x10
	protected bool uniqueNavigationNodes; //Field offset: 0x18
	protected private object root; //Field offset: 0x20
	protected ITokenStream tokens; //Field offset: 0x28
	private ITreeAdaptor adaptor; //Field offset: 0x30
	protected private StackList nodeStack; //Field offset: 0x38
	protected private StackList indexStack; //Field offset: 0x40
	protected private object currentNode; //Field offset: 0x48
	protected private object previousNode; //Field offset: 0x50
	protected private int currentChildIndex; //Field offset: 0x58
	protected int absoluteNodeIndex; //Field offset: 0x5C
	protected private Object[] lookahead; //Field offset: 0x60
	protected private int head; //Field offset: 0x68
	protected private int tail; //Field offset: 0x6C
	protected IList markers; //Field offset: 0x70
	protected int markDepth; //Field offset: 0x78
	protected int lastMarker; //Field offset: 0x7C
	protected object down; //Field offset: 0x80
	protected object up; //Field offset: 0x88
	protected object eof; //Field offset: 0x90

	public override int Count
	{
		 get { } //Length: 572
	}

	public override object Current
	{
		 get { } //Length: 5
	}

	public override bool HasUniqueNavigationNodes
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	protected int LookaheadSize
	{
		 get { } //Length: 51
	}

	public override string SourceName
	{
		 get { } //Length: 73
	}

	public override ITokenStream TokenStream
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public override ITreeAdaptor TreeAdaptor
	{
		 get { } //Length: 5
	}

	public override object TreeSource
	{
		 get { } //Length: 5
	}

	public UnBufferedTreeNodeStream(object tree) { }

	public UnBufferedTreeNodeStream(ITreeAdaptor adaptor, object tree) { }

	protected private override void AddLookahead(object node) { }

	protected private override void AddNavigationNode(int ttype) { }

	public override void Consume() { }

	protected private override void fill(int k) { }

	public override object Get(int i) { }

	public override int get_Count() { }

	public override object get_Current() { }

	public bool get_HasUniqueNavigationNodes() { }

	protected int get_LookaheadSize() { }

	public override string get_SourceName() { }

	public override ITokenStream get_TokenStream() { }

	public override ITreeAdaptor get_TreeAdaptor() { }

	public override object get_TreeSource() { }

	protected private override object handleRootNode() { }

	public override int Index() { }

	public override int LA(int i) { }

	public override object LT(int k) { }

	public override int Mark() { }

	public override bool MoveNext() { }

	public override void Release(int marker) { }

	public override void ReplaceChildren(object parent, int startChildIndex, int stopChildIndex, object t) { }

	public override void Reset() { }

	public override void Rewind() { }

	public override void Rewind(int marker) { }

	public override void Seek(int index) { }

	public override void set_HasUniqueNavigationNodes(bool value) { }

	public void set_TokenStream(ITokenStream value) { }

	[Obsolete("Please use property Count instead.")]
	public override int Size() { }

	public virtual string ToString() { }

	public override string ToString(object start, object stop) { }

	protected private override void ToStringWork(object p, object stop, StringBuilder buf) { }

	protected private override object VisitChild(int child) { }

	protected private override void WalkBackToMostRecentNodeWithUnvisitedChildren() { }

}

