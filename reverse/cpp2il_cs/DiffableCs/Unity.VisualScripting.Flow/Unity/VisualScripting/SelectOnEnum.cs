namespace Unity.VisualScripting;

[TypeIcon(typeof(ISelectUnit))]
[UnitCategory("Control")]
[UnitOrder(7)]
[UnitShortTitle("Select")]
[UnitSubtitle("On Enum")]
[UnitTitle("Select On Enum")]
public sealed class SelectOnEnum : Unit, ISelectUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private Dictionary<Object, ValueInput> <branches>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <selector>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <selection>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private Type <enumType>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	public private Dictionary<Object, ValueInput> branches
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public virtual bool canDefine
	{
		 get { } //Length: 116
	}

	[Inspectable]
	[Serialize]
	[TypeFilter(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {}, Enums = True, Classes = False, Interfaces = False, Structs = False, Primitives = False)]
	[UnitHeaderInspectable]
	public Type enumType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private override ValueOutput selection
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput selector
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public SelectOnEnum() { }

	public object Branch(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public Dictionary<Object, ValueInput> get_branches() { }

	public virtual bool get_canDefine() { }

	[CompilerGenerated]
	public Type get_enumType() { }

	[CompilerGenerated]
	public override ValueOutput get_selection() { }

	[CompilerGenerated]
	public ValueInput get_selector() { }

	[CompilerGenerated]
	private void set_branches(Dictionary<Object, ValueInput> value) { }

	[CompilerGenerated]
	public void set_enumType(Type value) { }

	[CompilerGenerated]
	private void set_selection(ValueOutput value) { }

	[CompilerGenerated]
	private void set_selector(ValueInput value) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

