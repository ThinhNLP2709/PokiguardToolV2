namespace Unity.VisualScripting;

[UnitCategory("Graphs/Graph Nodes")]
public abstract class GetGraph : Unit
{
	[CompilerGenerated]
	private ValueInput <gameObject>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <graphOutput>k__BackingField; //Field offset: 0x0

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
	[PortLabel("Graph")]
	[PortLabelHidden]
	public ValueOutput graphOutput
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	protected GetGraph`3() { }

	protected virtual void Definition() { }

	private TGraphAsset Get(Flow flow) { }

	[CompilerGenerated]
	public ValueInput get_gameObject() { }

	[CompilerGenerated]
	public ValueOutput get_graphOutput() { }

	[CompilerGenerated]
	protected void set_gameObject(ValueInput value) { }

	[CompilerGenerated]
	protected void set_graphOutput(ValueOutput value) { }

}

