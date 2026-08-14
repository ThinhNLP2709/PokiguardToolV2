namespace Unity.VisualScripting;

public sealed class ValueOutput : UnitPort<ValueInput, IUnitInputPort, ValueConnection>, IUnitValuePort, IUnitPort, IGraphItem, IUnitOutputPort
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ValueConnection, ValueInput> <>9__16_0; //Field offset: 0x8
		public static Func<InvalidConnection, IUnitInputPort> <>9__18_0; //Field offset: 0x10
		public static Func<Flow, Boolean> <>9__25_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal IUnitInputPort <get_invalidConnectedPorts>b__18_0(InvalidConnection c) { }

		internal ValueInput <get_validConnectedPorts>b__16_0(ValueConnection c) { }

		internal bool <Predictable>b__25_0(Flow flow) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public ValueInput port; //Field offset: 0x10

		public <>c__DisplayClass22_0() { }

		internal bool <DisconnectFromValid>b__0(ValueConnection c) { }

	}

	internal readonly Func<Flow, Object> getValue; //Field offset: 0x20
	internal Func<Flow, Boolean> canPredictValue; //Field offset: 0x28
	[CompilerGenerated]
	private readonly Type <type>k__BackingField; //Field offset: 0x30

	public virtual IEnumerable<IUnitInputPort> invalidConnectedPorts
	{
		 get { } //Length: 300
	}

	public virtual IEnumerable<InvalidConnection> invalidConnections
	{
		 get { } //Length: 158
	}

	public bool supportsFetch
	{
		 get { } //Length: 9
	}

	public bool supportsPrediction
	{
		 get { } //Length: 9
	}

	public override Type type
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public virtual IEnumerable<ValueInput> validConnectedPorts
	{
		 get { } //Length: 300
	}

	public virtual IEnumerable<ValueConnection> validConnections
	{
		 get { } //Length: 158
	}

	public ValueOutput(string key, Type type, Func<Flow, Object> getValue) { }

	public ValueOutput(string key, Type type) { }

	public virtual bool CanConnectToValid(ValueInput port) { }

	public virtual IUnitPort CompatiblePort(IUnit unit) { }

	public virtual void ConnectToInvalid(IUnitInputPort port) { }

	public virtual void ConnectToValid(ValueInput port) { }

	public virtual void DisconnectFromInvalid(IUnitInputPort port) { }

	public virtual void DisconnectFromValid(ValueInput port) { }

	public virtual IEnumerable<IUnitInputPort> get_invalidConnectedPorts() { }

	public virtual IEnumerable<InvalidConnection> get_invalidConnections() { }

	public bool get_supportsFetch() { }

	public bool get_supportsPrediction() { }

	[CompilerGenerated]
	public override Type get_type() { }

	public virtual IEnumerable<ValueInput> get_validConnectedPorts() { }

	public virtual IEnumerable<ValueConnection> get_validConnections() { }

	public ValueOutput Predictable() { }

	public ValueOutput PredictableIf(Func<Flow, Boolean> condition) { }

}

