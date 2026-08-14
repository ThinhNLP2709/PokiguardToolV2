namespace Unity.VisualScripting;

public sealed class InvalidOutput : UnitPort<IUnitInputPort, IUnitInputPort, InvalidConnection>, IUnitInvalidPort, IUnitPort, IGraphItem, IUnitOutputPort
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<InvalidConnection, IUnitInputPort> <>9__6_0; //Field offset: 0x8
		public static Func<InvalidConnection, IUnitInputPort> <>9__8_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal IUnitInputPort <get_invalidConnectedPorts>b__8_0(InvalidConnection c) { }

		internal IUnitInputPort <get_validConnectedPorts>b__6_0(InvalidConnection c) { }

	}


	public virtual IEnumerable<IUnitInputPort> invalidConnectedPorts
	{
		 get { } //Length: 300
	}

	public virtual IEnumerable<InvalidConnection> invalidConnections
	{
		 get { } //Length: 48
	}

	public virtual IEnumerable<IUnitInputPort> validConnectedPorts
	{
		 get { } //Length: 300
	}

	public virtual IEnumerable<InvalidConnection> validConnections
	{
		 get { } //Length: 158
	}

	public InvalidOutput(string key) { }

	public virtual bool CanConnectToValid(IUnitInputPort port) { }

	public virtual IUnitPort CompatiblePort(IUnit unit) { }

	public virtual void ConnectToInvalid(IUnitInputPort port) { }

	public virtual void ConnectToValid(IUnitInputPort port) { }

	public virtual void DisconnectFromInvalid(IUnitInputPort port) { }

	public virtual void DisconnectFromValid(IUnitInputPort port) { }

	public virtual IEnumerable<IUnitInputPort> get_invalidConnectedPorts() { }

	public virtual IEnumerable<InvalidConnection> get_invalidConnections() { }

	public virtual IEnumerable<IUnitInputPort> get_validConnectedPorts() { }

	public virtual IEnumerable<InvalidConnection> get_validConnections() { }

}

