namespace Unity.VisualScripting;

public sealed class FlowGraphData : GraphData<FlowGraph>, IGraphDataWithVariables, IGraphData, IGraphEventListenerData
{
	[CompilerGenerated]
	private readonly VariableDeclarations <variables>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private bool <isListening>k__BackingField; //Field offset: 0x40

	public override bool isListening
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public override VariableDeclarations variables
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public FlowGraphData(FlowGraph definition) { }

	[CompilerGenerated]
	public override bool get_isListening() { }

	[CompilerGenerated]
	public override VariableDeclarations get_variables() { }

	[CompilerGenerated]
	public void set_isListening(bool value) { }

}

