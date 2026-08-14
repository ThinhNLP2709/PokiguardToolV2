namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public class CommonTreeNodeStream : ITreeNodeStream, IIntStream, IEnumerable
{
	internal sealed class CommonTreeNodeStreamEnumerator : IEnumerator
	{
		private CommonTreeNodeStream _nodeStream; //Field offset: 0x10
		private int _index; //Field offset: 0x18
		private object _currentItem; //Field offset: 0x20

		public override object Current
		{
			 get { } //Length: 102
		}

		internal CommonTreeNodeStreamEnumerator() { }

		internal CommonTreeNodeStreamEnumerator(CommonTreeNodeStream nodeStream) { }

		public override object get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

	}

	public const int DEFAULT_INITIAL_BUFFER_SIZE = 100; //Field offset: 0x0
	public const int INITIAL_CALL_STACK_SIZE = 10; //Field offset: 0x0
	protected object down; //Field offset: 0x10
	protected object up; //Field offset: 0x18
	protected object eof; //Field offset: 0x20
	protected IList nodes; //Field offset: 0x28
	protected private object root; //Field offset: 0x30
	protected ITokenStream tokens; //Field offset: 0x38
	private ITreeAdaptor adaptor; //Field offset: 0x40
	protected bool uniqueNavigationNodes; //Field offset: 0x48
	protected int p; //Field offset: 0x4C
	protected int lastMarker; //Field offset: 0x50
	protected StackList calls; //Field offset: 0x58

	public override int Count
	{
		 get { } //Length: 101
	}

	public override object CurrentSymbol
	{
		 get { } //Length: 171
	}

	public override bool HasUniqueNavigationNodes
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public override string SourceName
	{
		 get { } //Length: 94
	}

	public override ITokenStream TokenStream
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public override ITreeAdaptor TreeAdaptor
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public override object TreeSource
	{
		 get { } //Length: 5
	}

	public CommonTreeNodeStream(object tree) { }

	public CommonTreeNodeStream(ITreeAdaptor adaptor, object tree) { }

	public CommonTreeNodeStream(ITreeAdaptor adaptor, object tree, int initialBufferSize) { }

	protected void AddNavigationNode(int ttype) { }

	public override void Consume() { }

	protected void FillBuffer() { }

	public void FillBuffer(object t) { }

	public override object Get(int i) { }

	public override int get_Count() { }

	public override object get_CurrentSymbol() { }

	public bool get_HasUniqueNavigationNodes() { }

	public override string get_SourceName() { }

	public override ITokenStream get_TokenStream() { }

	public override ITreeAdaptor get_TreeAdaptor() { }

	public override object get_TreeSource() { }

	public override IEnumerator GetEnumerator() { }

	protected int GetNodeIndex(object node) { }

	public override int Index() { }

	public override int LA(int i) { }

	protected object LB(int k) { }

	public override object LT(int k) { }

	public override int Mark() { }

	public int Pop() { }

	public void Push(int index) { }

	public override void Release(int marker) { }

	public override void ReplaceChildren(object parent, int startChildIndex, int stopChildIndex, object t) { }

	public void Reset() { }

	public override void Rewind(int marker) { }

	public override void Rewind() { }

	public override void Seek(int index) { }

	public override void set_HasUniqueNavigationNodes(bool value) { }

	public override void set_TokenStream(ITokenStream value) { }

	public void set_TreeAdaptor(ITreeAdaptor value) { }

	[Obsolete("Please use property Count instead.")]
	public override int Size() { }

	public virtual string ToString() { }

	public override string ToString(object start, object stop) { }

	public string ToTokenString(int start, int stop) { }

}

