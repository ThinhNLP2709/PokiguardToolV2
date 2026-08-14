namespace Unity.VisualScripting;

[SerializationVersion("A", new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
public abstract class Unit : GraphElement<FlowGraph>, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<InvalidInput, Boolean> <>9__22_0; //Field offset: 0x8
		public static Func<InvalidOutput, Boolean> <>9__22_1; //Field offset: 0x10
		public static Func<IUnitPort, IEnumerable`1<IUnitConnection>> <>9__68_0; //Field offset: 0x18
		public static Func<IUnitPort, Boolean> <>9__69_0; //Field offset: 0x20
		public static Func<IUnitPort, Boolean> <>9__69_1; //Field offset: 0x28

		private static <>c() { }

		public <>c() { }

		internal bool <Disconnect>b__69_0(IUnitPort p) { }

		internal bool <Disconnect>b__69_1(IUnitPort p) { }

		internal IEnumerable<IUnitConnection> <get_connections>b__68_0(IUnitPort p) { }

		internal bool <RemoveUnconnectedInvalidPorts>b__22_0(InvalidInput p) { }

		internal bool <RemoveUnconnectedInvalidPorts>b__22_1(InvalidOutput p) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass86_0
	{
		public Func<Flow, T> getValue; //Field offset: 0x0

		public <>c__DisplayClass86_0`1() { }

		internal object <ValueOutput>b__0(Flow recursion) { }

	}

	internal class DebugData : IUnitDebugData, IGraphElementDebugData
	{
		[CompilerGenerated]
		private int <lastInvokeFrame>k__BackingField; //Field offset: 0x10
		[CompilerGenerated]
		private float <lastInvokeTime>k__BackingField; //Field offset: 0x14
		[CompilerGenerated]
		private Exception <runtimeException>k__BackingField; //Field offset: 0x18

		public override int lastInvokeFrame
		{
			[CompilerGenerated]
			 get { } //Length: 4
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public override float lastInvokeTime
		{
			[CompilerGenerated]
			 get { } //Length: 6
			[CompilerGenerated]
			 set { } //Length: 6
		}

		public override Exception runtimeException
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public DebugData() { }

		[CompilerGenerated]
		public override int get_lastInvokeFrame() { }

		[CompilerGenerated]
		public override float get_lastInvokeTime() { }

		[CompilerGenerated]
		public override Exception get_runtimeException() { }

		[CompilerGenerated]
		public override void set_lastInvokeFrame(int value) { }

		[CompilerGenerated]
		public override void set_lastInvokeTime(float value) { }

		[CompilerGenerated]
		public override void set_runtimeException(Exception value) { }

	}

	[CompilerGenerated]
	private bool <isDefined>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly IUnitPortCollection<ControlInput> <controlInputs>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private readonly IUnitPortCollection<ControlOutput> <controlOutputs>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private readonly IUnitPortCollection<ValueInput> <valueInputs>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private readonly IUnitPortCollection<ValueOutput> <valueOutputs>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private readonly IUnitPortCollection<InvalidInput> <invalidInputs>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	private readonly IUnitPortCollection<InvalidOutput> <invalidOutputs>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private Action onPortsChanged; //Field offset: 0x60
	[CompilerGenerated]
	private Dictionary<String, Object> <defaultValues>k__BackingField; //Field offset: 0x68
	[CompilerGenerated]
	private IConnectionCollection<IUnitRelation, IUnitPort, IUnitPort> <relations>k__BackingField; //Field offset: 0x70
	[CompilerGenerated]
	private bool <isControlRoot>k__BackingField; //Field offset: 0x78
	[CompilerGenerated]
	private Vector2 <position>k__BackingField; //Field offset: 0x7C
	[CompilerGenerated]
	private Exception <definitionException>k__BackingField; //Field offset: 0x88

	public override event Action onPortsChanged
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	[DoNotSerialize]
	public override bool canDefine
	{
		 get { } //Length: 3
	}

	[DoNotSerialize]
	public override IEnumerable<IUnitConnection> connections
	{
		 get { } //Length: 288
	}

	[DoNotSerialize]
	public override IUnitPortCollection<ControlInput> controlInputs
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	[DoNotSerialize]
	public override IUnitPortCollection<ControlOutput> controlOutputs
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	[Serialize]
	public private override Dictionary<String, Object> defaultValues
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[DoNotSerialize]
	public override Exception definitionException
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[DoNotSerialize]
	public override bool failedToDefine
	{
		 get { } //Length: 12
	}

	[DoNotSerialize]
	public override IEnumerable<IUnitInputPort> inputs
	{
		 get { } //Length: 345
	}

	[DoNotSerialize]
	public override IUnitPortCollection<InvalidInput> invalidInputs
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	[DoNotSerialize]
	public override IUnitPortCollection<InvalidOutput> invalidOutputs
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	[DoNotSerialize]
	public override IEnumerable<IUnitPort> invalidPorts
	{
		 get { } //Length: 266
	}

	[DoNotSerialize]
	public override bool isControlRoot
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	[DoNotSerialize]
	public private override bool isDefined
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	[DoNotSerialize]
	public override IEnumerable<IUnitOutputPort> outputs
	{
		 get { } //Length: 345
	}

	[DoNotSerialize]
	public override IEnumerable<IUnitPort> ports
	{
		 get { } //Length: 904
	}

	[Serialize]
	public override Vector2 position
	{
		[CompilerGenerated]
		 get { } //Length: 22
		[CompilerGenerated]
		 set { } //Length: 5
	}

	[DoNotSerialize]
	public private override IConnectionCollection<IUnitRelation, IUnitPort, IUnitPort> relations
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[DoNotSerialize]
	public override IEnumerable<IUnitInputPort> validInputs
	{
		 get { } //Length: 266
	}

	[DoNotSerialize]
	public override IEnumerable<IUnitOutputPort> validOutputs
	{
		 get { } //Length: 266
	}

	[DoNotSerialize]
	public override IEnumerable<IUnitPort> validPorts
	{
		 get { } //Length: 754
	}

	[DoNotSerialize]
	public override IUnitPortCollection<ValueInput> valueInputs
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	[DoNotSerialize]
	public override IUnitPortCollection<ValueOutput> valueOutputs
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	protected Unit() { }

	[CompilerGenerated]
	public override void add_onPortsChanged(Action value) { }

	public virtual void AfterAdd() { }

	protected override void AfterDefine() { }

	protected void Assignment(ControlInput source, ValueOutput destination) { }

	public virtual void BeforeRemove() { }

	protected override void BeforeUndefine() { }

	protected ControlInput ControlInput(string key, Func<Flow, ControlOutput> action) { }

	protected ControlInput ControlInputCoroutine(string key, Func<Flow, IEnumerator> coroutineAction) { }

	protected ControlInput ControlInputCoroutine(string key, Func<Flow, ControlOutput> action, Func<Flow, IEnumerator> coroutineAction) { }

	protected ControlOutput ControlOutput(string key) { }

	protected void CopyFrom(Unit source) { }

	public override IGraphElementDebugData CreateDebugData() { }

	public override void Define() { }

	protected abstract void Definition() { }

	public void Disconnect() { }

	public override void EnsureDefined() { }

	protected void EnsureUniqueInput(string key) { }

	protected void EnsureUniqueOutput(string key) { }

	public override bool get_canDefine() { }

	public override IEnumerable<IUnitConnection> get_connections() { }

	[CompilerGenerated]
	public override IUnitPortCollection<ControlInput> get_controlInputs() { }

	[CompilerGenerated]
	public override IUnitPortCollection<ControlOutput> get_controlOutputs() { }

	[CompilerGenerated]
	public override Dictionary<String, Object> get_defaultValues() { }

	[CompilerGenerated]
	public override Exception get_definitionException() { }

	public override bool get_failedToDefine() { }

	public override IEnumerable<IUnitInputPort> get_inputs() { }

	[CompilerGenerated]
	public override IUnitPortCollection<InvalidInput> get_invalidInputs() { }

	[CompilerGenerated]
	public override IUnitPortCollection<InvalidOutput> get_invalidOutputs() { }

	public override IEnumerable<IUnitPort> get_invalidPorts() { }

	[CompilerGenerated]
	public override bool get_isControlRoot() { }

	[CompilerGenerated]
	public override bool get_isDefined() { }

	public override IEnumerable<IUnitOutputPort> get_outputs() { }

	public override IEnumerable<IUnitPort> get_ports() { }

	[CompilerGenerated]
	public override Vector2 get_position() { }

	[CompilerGenerated]
	public override IConnectionCollection<IUnitRelation, IUnitPort, IUnitPort> get_relations() { }

	public override IEnumerable<IUnitInputPort> get_validInputs() { }

	public override IEnumerable<IUnitOutputPort> get_validOutputs() { }

	public override IEnumerable<IUnitPort> get_validPorts() { }

	[CompilerGenerated]
	public override IUnitPortCollection<ValueInput> get_valueInputs() { }

	[CompilerGenerated]
	public override IUnitPortCollection<ValueOutput> get_valueOutputs() { }

	public virtual AnalyticsIdentifier GetAnalyticsIdentifier() { }

	public virtual void Instantiate(GraphReference instance) { }

	public override void PortsChanged() { }

	private void Relation(IUnitPort source, IUnitPort destination) { }

	[CompilerGenerated]
	public override void remove_onPortsChanged(Action value) { }

	public override void RemoveUnconnectedInvalidPorts() { }

	protected void Requirement(ValueInput source, ValueOutput destination) { }

	protected void Requirement(ValueInput source, ControlInput destination) { }

	[CompilerGenerated]
	private void set_defaultValues(Dictionary<String, Object> value) { }

	[CompilerGenerated]
	protected void set_definitionException(Exception value) { }

	[CompilerGenerated]
	protected override void set_isControlRoot(bool value) { }

	[CompilerGenerated]
	private void set_isDefined(bool value) { }

	[CompilerGenerated]
	public override void set_position(Vector2 value) { }

	[CompilerGenerated]
	private void set_relations(IConnectionCollection<IUnitRelation, IUnitPort, IUnitPort> value) { }

	protected void Succession(ControlInput source, ControlOutput destination) { }

	private void Undefine() { }

	public virtual void Uninstantiate(GraphReference instance) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

	protected ValueInput ValueInput(string key, T default) { }

	protected ValueInput ValueInput(string key) { }

	protected ValueInput ValueInput(Type type, string key) { }

	protected ValueOutput ValueOutput(string key) { }

	protected ValueOutput ValueOutput(Type type, string key, Func<Flow, Object> getValue) { }

	protected ValueOutput ValueOutput(Type type, string key) { }

	protected ValueOutput ValueOutput(string key, Func<Flow, T> getValue) { }

}

