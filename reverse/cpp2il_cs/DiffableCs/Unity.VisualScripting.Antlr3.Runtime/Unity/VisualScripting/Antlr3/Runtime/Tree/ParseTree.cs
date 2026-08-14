namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public class ParseTree : BaseTree
{
	public object payload; //Field offset: 0x18
	public IList hiddenTokens; //Field offset: 0x20

	public virtual string Text
	{
		 get { } //Length: 20
	}

	public virtual int TokenStartIndex
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public virtual int TokenStopIndex
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public virtual int Type
	{
		 get { } //Length: 3
	}

	public void _ToStringLeaves(StringBuilder buf) { }

	public ParseTree(object label) { }

	public virtual ITree DupNode() { }

	public virtual string get_Text() { }

	public virtual int get_TokenStartIndex() { }

	public virtual int get_TokenStopIndex() { }

	public virtual int get_Type() { }

	public virtual void set_TokenStartIndex(int value) { }

	public virtual void set_TokenStopIndex(int value) { }

	public string ToInputString() { }

	public virtual string ToString() { }

	public string ToStringWithHiddenTokens() { }

}

