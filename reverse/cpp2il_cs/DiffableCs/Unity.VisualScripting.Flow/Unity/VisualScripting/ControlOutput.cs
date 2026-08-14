namespace Unity.VisualScripting;

public sealed class ControlOutput : UnitPort<ControlInput, IUnitInputPort, ControlConnection>, IUnitControlPort, IUnitPort, IGraphItem, IUnitOutputPort
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ControlConnection, ControlInput> <>9__6_0; //Field offset: 0x8
		public static Func<InvalidConnection, IUnitInputPort> <>9__8_0; //Field offset: 0x10
		public static Func<IUnitRelation, Boolean> <>9__11_0; //Field offset: 0x18
		public static Func<IUnitRelation, Boolean> <>9__13_0; //Field offset: 0x20
		public static Func<IUnitRelation, Boolean> <>9__13_1; //Field offset: 0x28

		private static <>c() { }

		public <>c() { }

		internal bool <get_couldBeEntered>b__13_0(IUnitRelation r) { }

		internal bool <get_couldBeEntered>b__13_1(IUnitRelation r) { }

		internal IUnitInputPort <get_invalidConnectedPorts>b__8_0(InvalidConnection c) { }

		internal ControlInput <get_validConnectedPorts>b__6_0(ControlConnection c) { }

		internal bool <IsPredictable>b__11_0(IUnitRelation r) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public Recursion recursion; //Field offset: 0x10

		public <>c__DisplayClass11_0() { }

		internal bool <IsPredictable>b__1(IUnitRelation r) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public ControlInput port; //Field offset: 0x10

		public <>c__DisplayClass21_0() { }

		internal bool <DisconnectFromValid>b__0(ControlConnection c) { }

	}


	public ControlConnection connection
	{
		 get { } //Length: 129
	}

	public override bool couldBeEntered
	{
		 get { } //Length: 708
	}

	public virtual bool hasValidConnection
	{
		 get { } //Length: 142
	}

	public virtual IEnumerable<IUnitInputPort> invalidConnectedPorts
	{
		 get { } //Length: 300
	}

	public virtual IEnumerable<InvalidConnection> invalidConnections
	{
		 get { } //Length: 158
	}

	public override bool isPredictable
	{
		 get { } //Length: 213
	}

	public virtual IEnumerable<ControlInput> validConnectedPorts
	{
		 get { } //Length: 300
	}

	public virtual IEnumerable<ControlConnection> validConnections
	{
		 get { } //Length: 158
	}

	public ControlOutput(string key) { }

	public virtual bool CanConnectToValid(ControlInput port) { }

	public virtual IUnitPort CompatiblePort(IUnit unit) { }

	public virtual void ConnectToInvalid(IUnitInputPort port) { }

	public virtual void ConnectToValid(ControlInput port) { }

	public virtual void DisconnectFromInvalid(IUnitInputPort port) { }

	public virtual void DisconnectFromValid(ControlInput port) { }

	public ControlConnection get_connection() { }

	public override bool get_couldBeEntered() { }

	public virtual bool get_hasValidConnection() { }

	public virtual IEnumerable<IUnitInputPort> get_invalidConnectedPorts() { }

	public virtual IEnumerable<InvalidConnection> get_invalidConnections() { }

	public override bool get_isPredictable() { }

	public virtual IEnumerable<ControlInput> get_validConnectedPorts() { }

	public virtual IEnumerable<ControlConnection> get_validConnections() { }

	public bool IsPredictable(Recursion recursion) { }

}

