namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public interface ITree
{

	public int CharPositionInLine
	{
		 get { } //Length: 0
	}

	public int ChildCount
	{
		 get { } //Length: 0
	}

	public int ChildIndex
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool IsNil
	{
		 get { } //Length: 0
	}

	public int Line
	{
		 get { } //Length: 0
	}

	public ITree Parent
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string Text
	{
		 get { } //Length: 0
	}

	public int TokenStartIndex
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int TokenStopIndex
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int Type
	{
		 get { } //Length: 0
	}

	public void AddChild(ITree t) { }

	public object DeleteChild(int i) { }

	public ITree DupNode() { }

	public void FreshenParentAndChildIndexes() { }

	public int get_CharPositionInLine() { }

	public int get_ChildCount() { }

	public int get_ChildIndex() { }

	public bool get_IsNil() { }

	public int get_Line() { }

	public ITree get_Parent() { }

	public string get_Text() { }

	public int get_TokenStartIndex() { }

	public int get_TokenStopIndex() { }

	public int get_Type() { }

	public ITree GetAncestor(int ttype) { }

	public IList GetAncestors() { }

	public ITree GetChild(int i) { }

	public bool HasAncestor(int ttype) { }

	public void ReplaceChildren(int startChildIndex, int stopChildIndex, object t) { }

	public void set_ChildIndex(int value) { }

	public void set_Parent(ITree value) { }

	public void set_TokenStartIndex(int value) { }

	public void set_TokenStopIndex(int value) { }

	public void SetChild(int i, ITree t) { }

	public string ToString() { }

	public string ToStringTree() { }

}

