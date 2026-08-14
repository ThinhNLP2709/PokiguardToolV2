namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public class CommonTreeAdaptor : BaseTreeAdaptor
{

	public CommonTreeAdaptor() { }

	public virtual object Create(IToken payload) { }

	public virtual IToken CreateToken(int tokenType, string text) { }

	public virtual IToken CreateToken(IToken fromToken) { }

	public virtual object DupNode(object t) { }

	public virtual object GetChild(object t, int i) { }

	public virtual int GetChildCount(object t) { }

	public virtual int GetChildIndex(object t) { }

	public virtual string GetNodeText(object t) { }

	public virtual int GetNodeType(object t) { }

	public virtual object GetParent(object t) { }

	public virtual IToken GetToken(object treeNode) { }

	public virtual int GetTokenStartIndex(object t) { }

	public virtual int GetTokenStopIndex(object t) { }

	public virtual void ReplaceChildren(object parent, int startChildIndex, int stopChildIndex, object t) { }

	public virtual void SetChildIndex(object t, int index) { }

	public virtual void SetParent(object t, object parent) { }

	public virtual void SetTokenBoundaries(object t, IToken startToken, IToken stopToken) { }

}

