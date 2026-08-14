namespace Unity.VisualScripting;

public abstract class MultiInputUnit : Unit, IMultiInputUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[SerializeAs("inputCount")]
	private int _inputCount; //Field offset: 0x0
	[CompilerGenerated]
	private ReadOnlyCollection<ValueInput> <multiInputs>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	[Inspectable]
	[UnitHeaderInspectable("Inputs")]
	public override int inputCount
	{
		 get { } //Length: 7
		 set { } //Length: 98
	}

	[DoNotSerialize]
	protected override int minInputCount
	{
		 get { } //Length: 6
	}

	[DoNotSerialize]
	public override ReadOnlyCollection<ValueInput> multiInputs
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	protected MultiInputUnit`1() { }

	protected virtual void Definition() { }

	public override int get_inputCount() { }

	protected override int get_minInputCount() { }

	[CompilerGenerated]
	public override ReadOnlyCollection<ValueInput> get_multiInputs() { }

	protected void InputsAllowNull() { }

	public override void set_inputCount(int value) { }

	[CompilerGenerated]
	protected void set_multiInputs(ReadOnlyCollection<ValueInput> value) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

