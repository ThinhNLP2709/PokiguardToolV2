namespace Unity.VisualScripting;

[DisplayName("Script Graph")]
[SerializationVersion("A", new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
public sealed class FlowGraph : Graph, IGraphWithVariables, IGraph, IDisposable, IPrewarmable, IAotStubbable, ISerializationDepender, ISerializationCallbackReceiver, IGraphEventListener
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, Boolean> <>9__9_2; //Field offset: 0x8
		public static Func<String, String> <>9__9_3; //Field offset: 0x10
		public static Func<IUnitPortDefinition, Boolean> <>9__53_0; //Field offset: 0x18
		public static Func<IUnitPortDefinition, String> <>9__53_1; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal bool <get_validPortDefinitions>b__53_0(IUnitPortDefinition upd) { }

		internal string <get_validPortDefinitions>b__53_1(IUnitPortDefinition upd) { }

		internal bool <GetDynamicVariableNames>b__9_2(string name) { }

		internal string <GetDynamicVariableNames>b__9_3(string name) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public VariableKind kind; //Field offset: 0x10
		public GraphReference reference; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal bool <GetDynamicVariableNames>b__0(IUnifiedVariableUnit v) { }

		internal string <GetDynamicVariableNames>b__1(IUnifiedVariableUnit v) { }

	}

	private const string DefinitionRemoveWarningTitle = "Remove Port Definition"; //Field offset: 0x0
	private const string DefinitionRemoveWarningMessage = "Removing this definition will break any existing connection to this port. Are you sure you want to continue?"; //Field offset: 0x0
	[CompilerGenerated]
	private VariableDeclarations <variables>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private GraphElementCollection<IUnit> <units>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private GraphConnectionCollection<ControlConnection, ControlOutput, ControlInput> <controlConnections>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	private GraphConnectionCollection<ValueConnection, ValueOutput, ValueInput> <valueConnections>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private GraphConnectionCollection<InvalidConnection, IUnitOutputPort, IUnitInputPort> <invalidConnections>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private GraphElementCollection<GraphGroup> <groups>k__BackingField; //Field offset: 0x68
	[CompilerGenerated]
	private GraphElementCollection<StickyNote> <sticky>k__BackingField; //Field offset: 0x70
	[CompilerGenerated]
	private UnitPortDefinitionCollection<ControlInputDefinition> <controlInputDefinitions>k__BackingField; //Field offset: 0x78
	[CompilerGenerated]
	private UnitPortDefinitionCollection<ControlOutputDefinition> <controlOutputDefinitions>k__BackingField; //Field offset: 0x80
	[CompilerGenerated]
	private UnitPortDefinitionCollection<ValueInputDefinition> <valueInputDefinitions>k__BackingField; //Field offset: 0x88
	[CompilerGenerated]
	private UnitPortDefinitionCollection<ValueOutputDefinition> <valueOutputDefinitions>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private Action onPortDefinitionsChanged; //Field offset: 0x98

	public event Action onPortDefinitionsChanged
	{
		[CompilerGenerated]
		 add { } //Length: 162
		[CompilerGenerated]
		 remove { } //Length: 162
	}

	[DoNotSerialize]
	public private GraphConnectionCollection<ControlConnection, ControlOutput, ControlInput> controlConnections
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[InspectorLabel("Trigger Inputs")]
	[InspectorWide(True)]
	[Serialize]
	[WarnBeforeRemoving("Remove Port Definition", "Removing this definition will break any existing connection to this port. Are you sure you want to continue?")]
	public private UnitPortDefinitionCollection<ControlInputDefinition> controlInputDefinitions
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[InspectorLabel("Trigger Outputs")]
	[InspectorWide(True)]
	[Serialize]
	[WarnBeforeRemoving("Remove Port Definition", "Removing this definition will break any existing connection to this port. Are you sure you want to continue?")]
	public private UnitPortDefinitionCollection<ControlOutputDefinition> controlOutputDefinitions
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	[DoNotSerialize]
	public private GraphElementCollection<GraphGroup> groups
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[DoNotSerialize]
	public private GraphConnectionCollection<InvalidConnection, IUnitOutputPort, IUnitInputPort> invalidConnections
	{
		[CompilerGenerated]
		 get { } //Length: 694
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[DoNotSerialize]
	public private GraphElementCollection<StickyNote> sticky
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[DoNotSerialize]
	public private GraphElementCollection<IUnit> units
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public IEnumerable<IUnitPortDefinition> validPortDefinitions
	{
		 get { } //Length: 883
	}

	[DoNotSerialize]
	public private GraphConnectionCollection<ValueConnection, ValueOutput, ValueInput> valueConnections
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[InspectorLabel("Data Inputs")]
	[InspectorWide(True)]
	[Serialize]
	[WarnBeforeRemoving("Remove Port Definition", "Removing this definition will break any existing connection to this port. Are you sure you want to continue?")]
	public private UnitPortDefinitionCollection<ValueInputDefinition> valueInputDefinitions
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[InspectorLabel("Data Outputs")]
	[InspectorWide(True)]
	[Serialize]
	[WarnBeforeRemoving("Remove Port Definition", "Removing this definition will break any existing connection to this port. Are you sure you want to continue?")]
	public private UnitPortDefinitionCollection<ValueOutputDefinition> valueOutputDefinitions
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Serialize]
	public private override VariableDeclarations variables
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public FlowGraph() { }

	[CompilerGenerated]
	public void add_onPortDefinitionsChanged(Action value) { }

	public virtual IGraphData CreateData() { }

	[CompilerGenerated]
	public GraphConnectionCollection<ControlConnection, ControlOutput, ControlInput> get_controlConnections() { }

	[CompilerGenerated]
	public UnitPortDefinitionCollection<ControlInputDefinition> get_controlInputDefinitions() { }

	[CompilerGenerated]
	public UnitPortDefinitionCollection<ControlOutputDefinition> get_controlOutputDefinitions() { }

	[CompilerGenerated]
	public GraphElementCollection<GraphGroup> get_groups() { }

	[CompilerGenerated]
	public GraphConnectionCollection<InvalidConnection, IUnitOutputPort, IUnitInputPort> get_invalidConnections() { }

	[CompilerGenerated]
	public GraphElementCollection<StickyNote> get_sticky() { }

	[CompilerGenerated]
	public GraphElementCollection<IUnit> get_units() { }

	public IEnumerable<IUnitPortDefinition> get_validPortDefinitions() { }

	[CompilerGenerated]
	public GraphConnectionCollection<ValueConnection, ValueOutput, ValueInput> get_valueConnections() { }

	[CompilerGenerated]
	public UnitPortDefinitionCollection<ValueInputDefinition> get_valueInputDefinitions() { }

	[CompilerGenerated]
	public UnitPortDefinitionCollection<ValueOutputDefinition> get_valueOutputDefinitions() { }

	[CompilerGenerated]
	public override VariableDeclarations get_variables() { }

	public override IEnumerable<String> GetDynamicVariableNames(VariableKind kind, GraphReference reference) { }

	public override bool IsListening(GraphPointer pointer) { }

	public void PortDefinitionsChanged() { }

	[CompilerGenerated]
	public void remove_onPortDefinitionsChanged(Action value) { }

	[CompilerGenerated]
	private void set_controlConnections(GraphConnectionCollection<ControlConnection, ControlOutput, ControlInput> value) { }

	[CompilerGenerated]
	private void set_controlInputDefinitions(UnitPortDefinitionCollection<ControlInputDefinition> value) { }

	[CompilerGenerated]
	private void set_controlOutputDefinitions(UnitPortDefinitionCollection<ControlOutputDefinition> value) { }

	[CompilerGenerated]
	private void set_groups(GraphElementCollection<GraphGroup> value) { }

	[CompilerGenerated]
	private void set_invalidConnections(GraphConnectionCollection<InvalidConnection, IUnitOutputPort, IUnitInputPort> value) { }

	[CompilerGenerated]
	private void set_sticky(GraphElementCollection<StickyNote> value) { }

	[CompilerGenerated]
	private void set_units(GraphElementCollection<IUnit> value) { }

	[CompilerGenerated]
	private void set_valueConnections(GraphConnectionCollection<ValueConnection, ValueOutput, ValueInput> value) { }

	[CompilerGenerated]
	private void set_valueInputDefinitions(UnitPortDefinitionCollection<ValueInputDefinition> value) { }

	[CompilerGenerated]
	private void set_valueOutputDefinitions(UnitPortDefinitionCollection<ValueOutputDefinition> value) { }

	[CompilerGenerated]
	private void set_variables(VariableDeclarations value) { }

	public override void StartListening(GraphStack stack) { }

	public override void StopListening(GraphStack stack) { }

	public static FlowGraph WithInputOutput() { }

	public static FlowGraph WithStartUpdate() { }

}

