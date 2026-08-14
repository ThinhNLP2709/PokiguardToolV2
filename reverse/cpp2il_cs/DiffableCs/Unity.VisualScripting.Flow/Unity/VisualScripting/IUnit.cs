namespace Unity.VisualScripting;

public interface IUnit : IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public event Action onPortsChanged
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public bool canDefine
	{
		 get { } //Length: 0
	}

	public IEnumerable<IUnitConnection> connections
	{
		 get { } //Length: 0
	}

	public IUnitPortCollection<ControlInput> controlInputs
	{
		 get { } //Length: 0
	}

	public IUnitPortCollection<ControlOutput> controlOutputs
	{
		 get { } //Length: 0
	}

	public Dictionary<String, Object> defaultValues
	{
		 get { } //Length: 0
	}

	public Exception definitionException
	{
		 get { } //Length: 0
	}

	public bool failedToDefine
	{
		 get { } //Length: 0
	}

	public FlowGraph graph
	{
		 get { } //Length: 0
	}

	public IEnumerable<IUnitInputPort> inputs
	{
		 get { } //Length: 0
	}

	public IUnitPortCollection<InvalidInput> invalidInputs
	{
		 get { } //Length: 0
	}

	public IUnitPortCollection<InvalidOutput> invalidOutputs
	{
		 get { } //Length: 0
	}

	public IEnumerable<IUnitPort> invalidPorts
	{
		 get { } //Length: 0
	}

	public bool isControlRoot
	{
		 get { } //Length: 0
	}

	public bool isDefined
	{
		 get { } //Length: 0
	}

	public IEnumerable<IUnitOutputPort> outputs
	{
		 get { } //Length: 0
	}

	public IEnumerable<IUnitPort> ports
	{
		 get { } //Length: 0
	}

	public Vector2 position
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IConnectionCollection<IUnitRelation, IUnitPort, IUnitPort> relations
	{
		 get { } //Length: 0
	}

	public IEnumerable<IUnitInputPort> validInputs
	{
		 get { } //Length: 0
	}

	public IEnumerable<IUnitOutputPort> validOutputs
	{
		 get { } //Length: 0
	}

	public IEnumerable<IUnitPort> validPorts
	{
		 get { } //Length: 0
	}

	public IUnitPortCollection<ValueInput> valueInputs
	{
		 get { } //Length: 0
	}

	public IUnitPortCollection<ValueOutput> valueOutputs
	{
		 get { } //Length: 0
	}

	[CompilerGenerated]
	public void add_onPortsChanged(Action value) { }

	public void Define() { }

	public void EnsureDefined() { }

	public bool get_canDefine() { }

	public IEnumerable<IUnitConnection> get_connections() { }

	public IUnitPortCollection<ControlInput> get_controlInputs() { }

	public IUnitPortCollection<ControlOutput> get_controlOutputs() { }

	public Dictionary<String, Object> get_defaultValues() { }

	public Exception get_definitionException() { }

	public bool get_failedToDefine() { }

	public FlowGraph get_graph() { }

	public IEnumerable<IUnitInputPort> get_inputs() { }

	public IUnitPortCollection<InvalidInput> get_invalidInputs() { }

	public IUnitPortCollection<InvalidOutput> get_invalidOutputs() { }

	public IEnumerable<IUnitPort> get_invalidPorts() { }

	public bool get_isControlRoot() { }

	public bool get_isDefined() { }

	public IEnumerable<IUnitOutputPort> get_outputs() { }

	public IEnumerable<IUnitPort> get_ports() { }

	public Vector2 get_position() { }

	public IConnectionCollection<IUnitRelation, IUnitPort, IUnitPort> get_relations() { }

	public IEnumerable<IUnitInputPort> get_validInputs() { }

	public IEnumerable<IUnitOutputPort> get_validOutputs() { }

	public IEnumerable<IUnitPort> get_validPorts() { }

	public IUnitPortCollection<ValueInput> get_valueInputs() { }

	public IUnitPortCollection<ValueOutput> get_valueOutputs() { }

	public void PortsChanged() { }

	[CompilerGenerated]
	public void remove_onPortsChanged(Action value) { }

	public void RemoveUnconnectedInvalidPorts() { }

	public void set_position(Vector2 value) { }

}

