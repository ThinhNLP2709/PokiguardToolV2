namespace Unity.VisualScripting;

public interface IUnitPort : IGraphItem
{

	public IEnumerable<IUnitPort> connectedPorts
	{
		 get { } //Length: 0
	}

	public IEnumerable<IUnitConnection> connections
	{
		 get { } //Length: 0
	}

	public bool hasAnyConnection
	{
		 get { } //Length: 0
	}

	public bool hasInvalidConnection
	{
		 get { } //Length: 0
	}

	public bool hasValidConnection
	{
		 get { } //Length: 0
	}

	public IEnumerable<InvalidConnection> invalidConnections
	{
		 get { } //Length: 0
	}

	public string key
	{
		 get { } //Length: 0
	}

	public IEnumerable<IUnitRelation> relations
	{
		 get { } //Length: 0
	}

	public IUnit unit
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IEnumerable<IUnitConnection> validConnections
	{
		 get { } //Length: 0
	}

	public bool CanInvalidlyConnectTo(IUnitPort port) { }

	public bool CanValidlyConnectTo(IUnitPort port) { }

	public IUnitPort CompatiblePort(IUnit unit) { }

	public void Disconnect() { }

	public IEnumerable<IUnitPort> get_connectedPorts() { }

	public IEnumerable<IUnitConnection> get_connections() { }

	public bool get_hasAnyConnection() { }

	public bool get_hasInvalidConnection() { }

	public bool get_hasValidConnection() { }

	public IEnumerable<InvalidConnection> get_invalidConnections() { }

	public string get_key() { }

	public IEnumerable<IUnitRelation> get_relations() { }

	public IUnit get_unit() { }

	public IEnumerable<IUnitConnection> get_validConnections() { }

	public void InvalidlyConnectTo(IUnitPort port) { }

	public void set_unit(IUnit value) { }

	public void ValidlyConnectTo(IUnitPort port) { }

}

