namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public class RewriteRuleTokenStream : RewriteRuleElementStream<IToken>
{

	public RewriteRuleTokenStream(ITreeAdaptor adaptor, string elementDescription) { }

	public RewriteRuleTokenStream(ITreeAdaptor adaptor, string elementDescription, IToken oneElement) { }

	public RewriteRuleTokenStream(ITreeAdaptor adaptor, string elementDescription, IList<IToken> elements) { }

	[Obsolete("This constructor is for internal use only and might be phased out soon. Use instead the one with IList<T>.")]
	public RewriteRuleTokenStream(ITreeAdaptor adaptor, string elementDescription, IList elements) { }

	public object NextNode() { }

	public IToken NextToken() { }

	protected virtual object ToTree(IToken el) { }

}

