namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public abstract class BaseTree : ITree
{
	protected IList children; //Field offset: 0x10

	public override int CharPositionInLine
	{
		 get { } //Length: 3
	}

	public override int ChildCount
	{
		 get { } //Length: 78
	}

	public override int ChildIndex
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public IList Children
	{
		 get { } //Length: 5
	}

	public override bool IsNil
	{
		 get { } //Length: 3
	}

	public override int Line
	{
		 get { } //Length: 3
	}

	public override ITree Parent
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public abstract string Text
	{
		 get { } //Length: 0
	}

	public abstract int TokenStartIndex
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public abstract int TokenStopIndex
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public abstract int Type
	{
		 get { } //Length: 0
	}

	public BaseTree() { }

	public BaseTree(ITree node) { }

	public override void AddChild(ITree t) { }

	public void AddChildren(IList kids) { }

	protected private override IList CreateChildrenList() { }

	public override object DeleteChild(int i) { }

	public abstract ITree DupNode() { }

	public override void FreshenParentAndChildIndexes() { }

	public override void FreshenParentAndChildIndexes(int offset) { }

	public override int get_CharPositionInLine() { }

	public override int get_ChildCount() { }

	public override int get_ChildIndex() { }

	public IList get_Children() { }

	public override bool get_IsNil() { }

	public override int get_Line() { }

	public override ITree get_Parent() { }

	public abstract string get_Text() { }

	public abstract int get_TokenStartIndex() { }

	public abstract int get_TokenStopIndex() { }

	public abstract int get_Type() { }

	public override ITree GetAncestor(int ttype) { }

	public override IList GetAncestors() { }

	public override ITree GetChild(int i) { }

	public override bool HasAncestor(int ttype) { }

	public override void ReplaceChildren(int startChildIndex, int stopChildIndex, object t) { }

	public override void SanityCheckParentAndChildIndexes(ITree parent, int i) { }

	public override void SanityCheckParentAndChildIndexes() { }

	public override void set_ChildIndex(int value) { }

	public override void set_Parent(ITree value) { }

	public abstract void set_TokenStartIndex(int value) { }

	public abstract void set_TokenStopIndex(int value) { }

	public override void SetChild(int i, ITree t) { }

	public abstract string ToString() { }

	public override string ToStringTree() { }

}

