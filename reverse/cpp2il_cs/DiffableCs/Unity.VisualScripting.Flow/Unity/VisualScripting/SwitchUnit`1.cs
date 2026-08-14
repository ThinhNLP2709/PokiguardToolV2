namespace Unity.VisualScripting;

[TypeIcon(typeof(IBranchUnit))]
public abstract class SwitchUnit : Unit, IBranchUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private List<KeyValuePair`2<T, ControlOutput>> <branches>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private List<T> <options>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <selector>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ControlOutput <default>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	public private List<KeyValuePair`2<T, ControlOutput>> branches
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public virtual bool canDefine
	{
		 get { } //Length: 12
	}

	[DoNotSerialize]
	public private ControlOutput default
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
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

	[Inspectable]
	[Serialize]
	public List<T> options
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
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

	protected SwitchUnit`1() { }

	protected virtual void Definition() { }

	public ControlOutput Enter(Flow flow) { }

	[CompilerGenerated]
	public List<KeyValuePair`2<T, ControlOutput>> get_branches() { }

	public virtual bool get_canDefine() { }

	[CompilerGenerated]
	public ControlOutput get_default() { }

	[CompilerGenerated]
	public override ControlInput get_enter() { }

	[CompilerGenerated]
	public List<T> get_options() { }

	[CompilerGenerated]
	public ValueInput get_selector() { }

	protected override bool Matches(T a, T b) { }

	[CompilerGenerated]
	private void set_branches(List<KeyValuePair`2<T, ControlOutput>> value) { }

	[CompilerGenerated]
	private void set_default(ControlOutput value) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	public void set_options(List<T> value) { }

	[CompilerGenerated]
	private void set_selector(ValueInput value) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

