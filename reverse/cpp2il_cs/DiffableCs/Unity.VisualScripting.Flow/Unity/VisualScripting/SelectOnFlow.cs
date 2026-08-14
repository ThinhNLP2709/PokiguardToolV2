namespace Unity.VisualScripting;

[TypeIcon(typeof(ISelectUnit))]
[UnitCategory("Control")]
[UnitOrder(8)]
[UnitShortTitle("Select")]
[UnitSubtitle("On Flow")]
[UnitTitle("Select On Flow")]
public sealed class SelectOnFlow : Unit, ISelectUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public ValueInput branchValue; //Field offset: 0x10
		public SelectOnFlow <>4__this; //Field offset: 0x18

		public <>c__DisplayClass16_0() { }

		internal ControlOutput <Definition>b__0(Flow flow) { }

	}

	[SerializeAs("branchCount")]
	private int _branchCount; //Field offset: 0x90
	[CompilerGenerated]
	private Dictionary<ControlInput, ValueInput> <branches>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueOutput <selection>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	[Inspectable]
	[UnitHeaderInspectable("Branches")]
	public int branchCount
	{
		 get { } //Length: 7
		 set { } //Length: 39
	}

	[DoNotSerialize]
	public private Dictionary<ControlInput, ValueInput> branches
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ControlOutput exit
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
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

	public SelectOnFlow() { }

	protected virtual void Definition() { }

	public int get_branchCount() { }

	[CompilerGenerated]
	public Dictionary<ControlInput, ValueInput> get_branches() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	[CompilerGenerated]
	public override ValueOutput get_selection() { }

	public ControlOutput Select(Flow flow, ValueInput branchValue) { }

	public void set_branchCount(int value) { }

	[CompilerGenerated]
	private void set_branches(Dictionary<ControlInput, ValueInput> value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

	[CompilerGenerated]
	private void set_selection(ValueOutput value) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

