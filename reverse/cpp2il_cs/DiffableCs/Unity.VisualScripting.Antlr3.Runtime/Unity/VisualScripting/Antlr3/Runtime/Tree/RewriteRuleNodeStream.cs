namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public class RewriteRuleNodeStream : RewriteRuleElementStream<Object>
{

	public RewriteRuleNodeStream(ITreeAdaptor adaptor, string elementDescription) { }

	public RewriteRuleNodeStream(ITreeAdaptor adaptor, string elementDescription, object oneElement) { }

	public RewriteRuleNodeStream(ITreeAdaptor adaptor, string elementDescription, IList<Object> elements) { }

	[Obsolete("This constructor is for internal use only and might be phased out soon. Use instead the one with IList<T>.")]
	public RewriteRuleNodeStream(ITreeAdaptor adaptor, string elementDescription, IList elements) { }

	public object NextNode() { }

	protected virtual object ToTree(object el) { }

}

