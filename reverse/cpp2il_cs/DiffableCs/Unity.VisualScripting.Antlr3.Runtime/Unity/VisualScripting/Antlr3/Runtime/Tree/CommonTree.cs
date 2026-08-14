namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public class CommonTree : BaseTree
{
	public int startIndex; //Field offset: 0x18
	public int stopIndex; //Field offset: 0x1C
	protected IToken token; //Field offset: 0x20
	public CommonTree parent; //Field offset: 0x28
	public int childIndex; //Field offset: 0x30

	public virtual int CharPositionInLine
	{
		 get { } //Length: 206
	}

	public virtual int ChildIndex
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public virtual bool IsNil
	{
		 get { } //Length: 9
	}

	public virtual int Line
	{
		 get { } //Length: 205
	}

	public virtual ITree Parent
	{
		 get { } //Length: 5
		 set { } //Length: 184
	}

	public virtual string Text
	{
		 get { } //Length: 78
	}

	public override IToken Token
	{
		 get { } //Length: 5
	}

	public virtual int TokenStartIndex
	{
		 get { } //Length: 85
		 set { } //Length: 4
	}

	public virtual int TokenStopIndex
	{
		 get { } //Length: 85
		 set { } //Length: 4
	}

	public virtual int Type
	{
		 get { } //Length: 75
	}

	public CommonTree() { }

	public CommonTree(CommonTree node) { }

	public CommonTree(IToken t) { }

	public virtual ITree DupNode() { }

	public virtual int get_CharPositionInLine() { }

	public virtual int get_ChildIndex() { }

	public virtual bool get_IsNil() { }

	public virtual int get_Line() { }

	public virtual ITree get_Parent() { }

	public virtual string get_Text() { }

	public override IToken get_Token() { }

	public virtual int get_TokenStartIndex() { }

	public virtual int get_TokenStopIndex() { }

	public virtual int get_Type() { }

	public virtual void set_ChildIndex(int value) { }

	public virtual void set_Parent(ITree value) { }

	public virtual void set_TokenStartIndex(int value) { }

	public virtual void set_TokenStopIndex(int value) { }

	public void SetUnknownTokenBoundaries() { }

	public virtual string ToString() { }

}

