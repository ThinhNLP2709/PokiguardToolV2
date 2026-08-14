namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public abstract class RewriteRuleElementStream
{
	protected int cursor; //Field offset: 0x0
	protected T singleElement; //Field offset: 0x0
	protected IList<T> elements; //Field offset: 0x0
	protected bool dirty; //Field offset: 0x0
	protected string elementDescription; //Field offset: 0x0
	protected ITreeAdaptor adaptor; //Field offset: 0x0

	public int Count
	{
		 get { } //Length: 98
	}

	public string Description
	{
		 get { } //Length: 5
	}

	protected object _Next() { }

	public RewriteRuleElementStream`1(ITreeAdaptor adaptor, string elementDescription) { }

	public RewriteRuleElementStream`1(ITreeAdaptor adaptor, string elementDescription, T oneElement) { }

	public RewriteRuleElementStream`1(ITreeAdaptor adaptor, string elementDescription, IList<T> elements) { }

	[Obsolete("This constructor is for internal use only and might be phased out soon. Use instead the one with IList<T>.")]
	public RewriteRuleElementStream`1(ITreeAdaptor adaptor, string elementDescription, IList elements) { }

	public void Add(T el) { }

	public int get_Count() { }

	public string get_Description() { }

	public bool HasNext() { }

	public override object NextTree() { }

	public override void Reset() { }

	[Obsolete("Please use property Count instead.")]
	public int Size() { }

	protected override object ToTree(T el) { }

}

