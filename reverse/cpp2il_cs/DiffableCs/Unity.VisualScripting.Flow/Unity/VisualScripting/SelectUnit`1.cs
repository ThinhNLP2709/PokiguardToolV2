namespace Unity.VisualScripting;

[TypeIcon(typeof(ISelectUnit))]
public abstract class SelectUnit : Unit, ISelectUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private List<KeyValuePair`2<T, ValueInput>> <branches>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private List<T> <options>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <selector>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <default>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <selection>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	public private List<KeyValuePair`2<T, ValueInput>> branches
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
	public private ValueInput default
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

	protected SelectUnit`1() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public List<KeyValuePair`2<T, ValueInput>> get_branches() { }

	public virtual bool get_canDefine() { }

	[CompilerGenerated]
	public ValueInput get_default() { }

	[CompilerGenerated]
	public List<T> get_options() { }

	[CompilerGenerated]
	public override ValueOutput get_selection() { }

	[CompilerGenerated]
	public ValueInput get_selector() { }

	protected override bool Matches(T a, T b) { }

	public object Result(Flow flow) { }

	[CompilerGenerated]
	private void set_branches(List<KeyValuePair`2<T, ValueInput>> value) { }

	[CompilerGenerated]
	private void set_default(ValueInput value) { }

	[CompilerGenerated]
	public void set_options(List<T> value) { }

	[CompilerGenerated]
	private void set_selection(ValueOutput value) { }

	[CompilerGenerated]
	private void set_selector(ValueInput value) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

