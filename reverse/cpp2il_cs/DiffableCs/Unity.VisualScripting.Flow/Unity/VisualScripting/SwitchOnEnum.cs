namespace Unity.VisualScripting;

[TypeIcon(typeof(IBranchUnit))]
[UnitCategory("Control")]
[UnitOrder(3)]
[UnitShortTitle("Switch")]
[UnitSubtitle("On Enum")]
[UnitTitle("Switch On Enum")]
public sealed class SwitchOnEnum : Unit, IBranchUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private Dictionary<Enum, ControlOutput> <branches>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private Type <enumType>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <enum>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	public private Dictionary<Enum, ControlOutput> branches
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

	[DoNotSerialize]
	[PortLabelHidden]
	public private override ControlInput enter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput enum
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
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

	public SwitchOnEnum() { }

	protected virtual void Definition() { }

	public ControlOutput Enter(Flow flow) { }

	[CompilerGenerated]
	public Dictionary<Enum, ControlOutput> get_branches() { }

	public virtual bool get_canDefine() { }

	[CompilerGenerated]
	public override ControlInput get_enter() { }

	[CompilerGenerated]
	public ValueInput get_enum() { }

	[CompilerGenerated]
	public Type get_enumType() { }

	[CompilerGenerated]
	private void set_branches(Dictionary<Enum, ControlOutput> value) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_enum(ValueInput value) { }

	[CompilerGenerated]
	public void set_enumType(Type value) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

