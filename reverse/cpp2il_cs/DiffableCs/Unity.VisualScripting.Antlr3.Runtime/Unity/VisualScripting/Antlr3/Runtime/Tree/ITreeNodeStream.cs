namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public interface ITreeNodeStream : IIntStream
{

	public bool HasUniqueNavigationNodes
	{
		 set { } //Length: 0
	}

	public ITokenStream TokenStream
	{
		 get { } //Length: 0
	}

	public ITreeAdaptor TreeAdaptor
	{
		 get { } //Length: 0
	}

	public object TreeSource
	{
		 get { } //Length: 0
	}

	public object Get(int i) { }

	public ITokenStream get_TokenStream() { }

	public ITreeAdaptor get_TreeAdaptor() { }

	public object get_TreeSource() { }

	public object LT(int k) { }

	public void ReplaceChildren(object parent, int startChildIndex, int stopChildIndex, object t) { }

	public void set_HasUniqueNavigationNodes(bool value) { }

	public string ToString(object start, object stop) { }

}

