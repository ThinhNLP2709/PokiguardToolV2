namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public class RewriteRuleSubtreeStream : RewriteRuleElementStream<Object>
{
	private sealed class ProcessHandler : MulticastDelegate
	{

		public ProcessHandler(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(object o, AsyncCallback callback, object object) { }

		public override object EndInvoke(IAsyncResult result) { }

		public override object Invoke(object o) { }

	}


	public RewriteRuleSubtreeStream(ITreeAdaptor adaptor, string elementDescription) { }

	public RewriteRuleSubtreeStream(ITreeAdaptor adaptor, string elementDescription, object oneElement) { }

	public RewriteRuleSubtreeStream(ITreeAdaptor adaptor, string elementDescription, IList<Object> elements) { }

	[Obsolete("This constructor is for internal use only and might be phased out soon. Use instead the one with IList<T>.")]
	public RewriteRuleSubtreeStream(ITreeAdaptor adaptor, string elementDescription, IList elements) { }

	[CompilerGenerated]
	private object <NextNode>b__0(object o) { }

	[CompilerGenerated]
	private object <NextTree>b__1(object o) { }

	private object Dup(object el) { }

	private object FetchObject(ProcessHandler ph) { }

	public object NextNode() { }

	public virtual object NextTree() { }

	private bool RequiresDuplication() { }

}

