namespace Unity.VisualScripting;

[TypeIcon(typeof(FlowGraph))]
public sealed class SetScriptGraph : SetGraph<FlowGraph, ScriptGraphAsset, ScriptMachine>
{
	[CompilerGenerated]
	private ScriptGraphContainerType <containerType>k__BackingField; //Field offset: 0xB8

	[Inspectable]
	[Serialize]
	[UnitHeaderInspectable]
	[UsedImplicitly]
	public ScriptGraphContainerType containerType
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		 set { } //Length: 7
	}

	protected virtual bool isGameObject
	{
		 get { } //Length: 11
	}

	public SetScriptGraph() { }

	[CompilerGenerated]
	public ScriptGraphContainerType get_containerType() { }

	protected virtual bool get_isGameObject() { }

	[CompilerGenerated]
	public void set_containerType(ScriptGraphContainerType value) { }

}

