namespace Unity.VisualScripting;

[DisableAnnotation]
public abstract class Macro : MacroScriptableObject, IMacro, IGraphRoot, IGraphParent, ISerializationDependency, ISerializationCallbackReceiver, IAotStubbable
{
	[SerializeAs("graph")]
	private TGraph _graph; //Field offset: 0x0
	[DoNotSerialize]
	private GraphReference _reference; //Field offset: 0x0
	[CompilerGenerated]
	private bool <Unity.VisualScripting.ISerializationDependency.IsDeserialized>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	public TGraph graph
	{
		 get { } //Length: 5
		 set { } //Length: 114
	}

	public bool isDescriptionValid
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	[DoNotSerialize]
	protected GraphReference reference
	{
		 get { } //Length: 142
	}

	[DoNotSerialize]
	private override IGraph Unity.VisualScripting.IGraphParent.childGraph
	{
		private get { } //Length: 5
	}

	[DoNotSerialize]
	private override bool Unity.VisualScripting.IGraphParent.isSerializationRoot
	{
		private get { } //Length: 3
	}

	[DoNotSerialize]
	private override object Unity.VisualScripting.IGraphParent.serializedObject
	{
		private get { } //Length: 4
	}

	[DoNotSerialize]
	private override IGraph Unity.VisualScripting.IMacro.graph
	{
		private get { } //Length: 5
		private set { } //Length: 201
	}

	private override bool Unity.VisualScripting.ISerializationDependency.IsDeserialized
	{
		[CompilerGenerated]
		private get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	protected Macro`1() { }

	public abstract TGraph DefaultGraph() { }

	public TGraph get_graph() { }

	public bool get_isDescriptionValid() { }

	protected GraphReference get_reference() { }

	public override IEnumerable<Object> GetAotStubs(HashSet<Object> visited) { }

	public override GraphPointer GetReference() { }

	protected virtual void OnAfterDeserialize() { }

	protected virtual void OnBeforeDeserialize() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	public void set_graph(TGraph value) { }

	public void set_isDescriptionValid(bool value) { }

	private override IGraph Unity.VisualScripting.IGraphParent.DefaultGraph() { }

	private override IGraph Unity.VisualScripting.IGraphParent.get_childGraph() { }

	private override bool Unity.VisualScripting.IGraphParent.get_isSerializationRoot() { }

	private override object Unity.VisualScripting.IGraphParent.get_serializedObject() { }

	private override IGraph Unity.VisualScripting.IMacro.get_graph() { }

	private override void Unity.VisualScripting.IMacro.set_graph(IGraph value) { }

	[CompilerGenerated]
	private override bool Unity.VisualScripting.ISerializationDependency.get_IsDeserialized() { }

	[CompilerGenerated]
	private override void Unity.VisualScripting.ISerializationDependency.set_IsDeserialized(bool value) { }

}

