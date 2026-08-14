namespace Unity.VisualScripting;

[UnitCategory("Graphs/Graph Nodes")]
public abstract class GetGraphs : Unit
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<TGraph, TGraphAsset, TMachine> <>9; //Field offset: 0x0
		public static Func<TMachine, TGraphAsset> <>9__9_1; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal TGraphAsset <Get>b__9_1(TMachine machine) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public GameObject go; //Field offset: 0x0

		public <>c__DisplayClass9_0() { }

		internal bool <Get>b__0(TMachine machine) { }

	}

	[CompilerGenerated]
	private ValueInput <gameObject>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <graphList>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	[NullMeansSelf]
	[PortLabelHidden]
	public ValueInput gameObject
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Graphs")]
	[PortLabelHidden]
	public ValueOutput graphList
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	protected GetGraphs`3() { }

	protected virtual void Definition() { }

	private List<TGraphAsset> Get(Flow flow) { }

	[CompilerGenerated]
	public ValueInput get_gameObject() { }

	[CompilerGenerated]
	public ValueOutput get_graphList() { }

	[CompilerGenerated]
	protected void set_gameObject(ValueInput value) { }

	[CompilerGenerated]
	protected void set_graphList(ValueOutput value) { }

}

