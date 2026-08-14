namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public abstract class BaseTreeAdaptor : ITreeAdaptor
{
	protected IDictionary treeToUniqueIDMap; //Field offset: 0x10
	protected int uniqueNodeID; //Field offset: 0x18

	protected BaseTreeAdaptor() { }

	public override void AddChild(object t, object child) { }

	public override object BecomeRoot(object newRoot, object oldRoot) { }

	public override object BecomeRoot(IToken newRoot, object oldRoot) { }

	public override object Create(int tokenType, IToken fromToken) { }

	public override object Create(int tokenType, IToken fromToken, string text) { }

	public override object Create(int tokenType, string text) { }

	public abstract object Create(IToken param1) { }

	public abstract IToken CreateToken(IToken fromToken) { }

	public abstract IToken CreateToken(int tokenType, string text) { }

	public override object DeleteChild(object t, int i) { }

	public abstract object DupNode(object param1) { }

	public override object DupTree(object t, object parent) { }

	public override object DupTree(object tree) { }

	public override object ErrorNode(ITokenStream input, IToken start, IToken stop, RecognitionException e) { }

	public override object GetChild(object t, int i) { }

	public override int GetChildCount(object t) { }

	public abstract int GetChildIndex(object t) { }

	public override object GetNilNode() { }

	public override string GetNodeText(object t) { }

	public override int GetNodeType(object t) { }

	public abstract object GetParent(object t) { }

	public abstract IToken GetToken(object treeNode) { }

	public abstract int GetTokenStartIndex(object t) { }

	public abstract int GetTokenStopIndex(object t) { }

	public override int GetUniqueID(object node) { }

	public override bool IsNil(object tree) { }

	public abstract void ReplaceChildren(object parent, int startChildIndex, int stopChildIndex, object t) { }

	public override object RulePostProcessing(object root) { }

	public override void SetChild(object t, int i, object child) { }

	public abstract void SetChildIndex(object t, int index) { }

	public override void SetNodeText(object t, string text) { }

	public override void SetNodeType(object t, int type) { }

	public abstract void SetParent(object t, object parent) { }

	public abstract void SetTokenBoundaries(object param1, IToken param2, IToken param3) { }

}

