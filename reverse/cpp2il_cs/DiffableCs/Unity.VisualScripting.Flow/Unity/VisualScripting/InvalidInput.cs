namespace Unity.VisualScripting;

public sealed class InvalidInput : UnitPort<IUnitOutputPort, IUnitOutputPort, InvalidConnection>, IUnitInvalidPort, IUnitPort, IGraphItem, IUnitInputPort
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<InvalidConnection, IUnitOutputPort> <>9__6_0; //Field offset: 0x8
		public static Func<InvalidConnection, IUnitOutputPort> <>9__8_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal IUnitOutputPort <get_invalidConnectedPorts>b__8_0(InvalidConnection c) { }

		internal IUnitOutputPort <get_validConnectedPorts>b__6_0(InvalidConnection c) { }

	}


	public virtual IEnumerable<IUnitOutputPort> invalidConnectedPorts
	{
		 get { } //Length: 300
	}

	public virtual IEnumerable<InvalidConnection> invalidConnections
	{
		 get { } //Length: 48
	}

	public virtual IEnumerable<IUnitOutputPort> validConnectedPorts
	{
		 get { } //Length: 300
	}

	public virtual IEnumerable<InvalidConnection> validConnections
	{
		 get { } //Length: 158
	}

	public InvalidInput(string key) { }

	public virtual bool CanConnectToValid(IUnitOutputPort port) { }

	public virtual IUnitPort CompatiblePort(IUnit unit) { }

	public virtual void ConnectToInvalid(IUnitOutputPort port) { }

	public virtual void ConnectToValid(IUnitOutputPort port) { }

	public virtual void DisconnectFromInvalid(IUnitOutputPort port) { }

	public virtual void DisconnectFromValid(IUnitOutputPort port) { }

	public virtual IEnumerable<IUnitOutputPort> get_invalidConnectedPorts() { }

	public virtual IEnumerable<InvalidConnection> get_invalidConnections() { }

	public virtual IEnumerable<IUnitOutputPort> get_validConnectedPorts() { }

	public virtual IEnumerable<InvalidConnection> get_validConnections() { }

}

