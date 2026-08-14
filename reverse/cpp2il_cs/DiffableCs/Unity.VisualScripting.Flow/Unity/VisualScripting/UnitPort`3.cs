namespace Unity.VisualScripting;

public abstract class UnitPort : IUnitPort, IGraphItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass45_0
	{
		public IUnitOutputPort source; //Field offset: 0x0
		public IUnitInputPort destination; //Field offset: 0x0

		public <>c__DisplayClass45_0() { }

		internal bool <ConnectInvalid>b__0(InvalidConnection c) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_0
	{
		public IUnitOutputPort source; //Field offset: 0x0
		public IUnitInputPort destination; //Field offset: 0x0

		public <>c__DisplayClass46_0() { }

		internal bool <DisconnectInvalid>b__0(InvalidConnection c) { }

	}

	[CompilerGenerated]
	private IUnit <unit>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private readonly string <key>k__BackingField; //Field offset: 0x0

	public override IEnumerable<IUnitPort> connectedPorts
	{
		 get { } //Length: 313
	}

	public override IEnumerable<IUnitConnection> connections
	{
		 get { } //Length: 313
	}

	public override IGraph graph
	{
		 get { } //Length: 73
	}

	public override bool hasAnyConnection
	{
		 get { } //Length: 68
	}

	public override bool hasInvalidConnection
	{
		 get { } //Length: 79
	}

	public override bool hasValidConnection
	{
		 get { } //Length: 56
	}

	public abstract IEnumerable<TInvalidOther> invalidConnectedPorts
	{
		 get { } //Length: 0
	}

	public abstract IEnumerable<InvalidConnection> invalidConnections
	{
		 get { } //Length: 0
	}

	public override string key
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public override IEnumerable<IUnitRelation> relations
	{
		 get { } //Length: 439
	}

	public override IUnit unit
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	private override IEnumerable<IUnitConnection> Unity.VisualScripting.IUnitPort.validConnections
	{
		private get { } //Length: 79
	}

	public abstract IEnumerable<TValidOther> validConnectedPorts
	{
		 get { } //Length: 0
	}

	public abstract IEnumerable<TExternalConnection> validConnections
	{
		 get { } //Length: 0
	}

	protected UnitPort`3(string key) { }

	private bool CanConnectTo(IUnitPort port) { }

	public bool CanConnectToInvalid(TInvalidOther port) { }

	public abstract bool CanConnectToValid(TValidOther port) { }

	public override bool CanInvalidlyConnectTo(IUnitPort port) { }

	public override bool CanValidlyConnectTo(IUnitPort port) { }

	public abstract IUnitPort CompatiblePort(IUnit unit) { }

	protected void ConnectInvalid(IUnitOutputPort source, IUnitInputPort destination) { }

	public abstract void ConnectToInvalid(TInvalidOther port) { }

	public abstract void ConnectToValid(TValidOther port) { }

	public override void Disconnect() { }

	public abstract void DisconnectFromInvalid(TInvalidOther port) { }

	public abstract void DisconnectFromValid(TValidOther port) { }

	protected void DisconnectInvalid(IUnitOutputPort source, IUnitInputPort destination) { }

	public override IEnumerable<IUnitPort> get_connectedPorts() { }

	public override IEnumerable<IUnitConnection> get_connections() { }

	public override IGraph get_graph() { }

	public override bool get_hasAnyConnection() { }

	public override bool get_hasInvalidConnection() { }

	public override bool get_hasValidConnection() { }

	public abstract IEnumerable<TInvalidOther> get_invalidConnectedPorts() { }

	public abstract IEnumerable<InvalidConnection> get_invalidConnections() { }

	[CompilerGenerated]
	public override string get_key() { }

	public override IEnumerable<IUnitRelation> get_relations() { }

	[CompilerGenerated]
	public override IUnit get_unit() { }

	public abstract IEnumerable<TValidOther> get_validConnectedPorts() { }

	public abstract IEnumerable<TExternalConnection> get_validConnections() { }

	public override void InvalidlyConnectTo(IUnitPort port) { }

	[CompilerGenerated]
	public override void set_unit(IUnit value) { }

	private override IEnumerable<IUnitConnection> Unity.VisualScripting.IUnitPort.get_validConnections() { }

	public override void ValidlyConnectTo(IUnitPort port) { }

}

