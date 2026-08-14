namespace Unity.VisualScripting;

public sealed class ControlInput : UnitPort<ControlOutput, IUnitOutputPort, ControlConnection>, IUnitControlPort, IUnitPort, IGraphItem, IUnitInputPort
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ControlConnection, ControlOutput> <>9__14_0; //Field offset: 0x8
		public static Func<InvalidConnection, IUnitOutputPort> <>9__16_0; //Field offset: 0x10
		public static Func<ControlOutput, Boolean> <>9__21_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal bool <get_couldBeEntered>b__21_0(ControlOutput cop) { }

		internal IUnitOutputPort <get_invalidConnectedPorts>b__16_0(InvalidConnection c) { }

		internal ControlOutput <get_validConnectedPorts>b__14_0(ControlConnection c) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public Recursion recursion; //Field offset: 0x10

		public <>c__DisplayClass19_0() { }

		internal bool <IsPredictable>b__0(ControlOutput cop) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public ControlOutput port; //Field offset: 0x10

		public <>c__DisplayClass25_0() { }

		internal bool <DisconnectFromValid>b__0(ControlConnection c) { }

	}

	internal readonly Func<Flow, ControlOutput> action; //Field offset: 0x20
	internal readonly Func<Flow, IEnumerator> coroutineAction; //Field offset: 0x28

	public override bool couldBeEntered
	{
		 get { } //Length: 413
	}

	public virtual IEnumerable<IUnitOutputPort> invalidConnectedPorts
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

	public bool requiresCoroutine
	{
		 get { } //Length: 9
	}

	public bool supportsCoroutine
	{
		 get { } //Length: 9
	}

	public virtual IEnumerable<ControlOutput> validConnectedPorts
	{
		 get { } //Length: 300
	}

	public virtual IEnumerable<ControlConnection> validConnections
	{
		 get { } //Length: 158
	}

	public ControlInput(string key, Func<Flow, ControlOutput> action) { }

	public ControlInput(string key, Func<Flow, IEnumerator> coroutineAction) { }

	public ControlInput(string key, Func<Flow, ControlOutput> action, Func<Flow, IEnumerator> coroutineAction) { }

	public virtual bool CanConnectToValid(ControlOutput port) { }

	public virtual IUnitPort CompatiblePort(IUnit unit) { }

	public virtual void ConnectToInvalid(IUnitOutputPort port) { }

	public virtual void ConnectToValid(ControlOutput port) { }

	public virtual void DisconnectFromInvalid(IUnitOutputPort port) { }

	public virtual void DisconnectFromValid(ControlOutput port) { }

	public override bool get_couldBeEntered() { }

	public virtual IEnumerable<IUnitOutputPort> get_invalidConnectedPorts() { }

	public virtual IEnumerable<InvalidConnection> get_invalidConnections() { }

	public override bool get_isPredictable() { }

	public bool get_requiresCoroutine() { }

	public bool get_supportsCoroutine() { }

	public virtual IEnumerable<ControlOutput> get_validConnectedPorts() { }

	public virtual IEnumerable<ControlConnection> get_validConnections() { }

	public bool IsPredictable(Recursion recursion) { }

}

