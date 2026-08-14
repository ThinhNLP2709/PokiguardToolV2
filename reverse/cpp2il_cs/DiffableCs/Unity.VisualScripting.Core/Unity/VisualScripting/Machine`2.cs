namespace Unity.VisualScripting;

public abstract class Machine : LudiqBehaviour, IMachine, IGraphRoot, IGraphParent, IGraphNester, IAotStubbable
{
	[CompilerGenerated]
	private GraphNest<TGraph, TMacro> <nest>k__BackingField; //Field offset: 0x0
	[DoNotSerialize]
	private bool _alive; //Field offset: 0x0
	[DoNotSerialize]
	private bool _enabled; //Field offset: 0x0
	[DoNotSerialize]
	private GameObject threadSafeGameObject; //Field offset: 0x0
	[DoNotSerialize]
	private bool isReferenceCached; //Field offset: 0x0
	[DoNotSerialize]
	private GraphReference _reference; //Field offset: 0x0
	[CompilerGenerated]
	private IGraphData <graphData>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	public TGraph graph
	{
		 get { } //Length: 42
	}

	[DoNotSerialize]
	public override IGraphData graphData
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[DoNotSerialize]
	protected bool hasGraph
	{
		 get { } //Length: 153
	}

	public bool isDescriptionValid
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	[Serialize]
	public private GraphNest<TGraph, TMacro> nest
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[DoNotSerialize]
	protected GraphReference reference
	{
		 get { } //Length: 92
	}

	[DoNotSerialize]
	private override IGraphNest Unity.VisualScripting.IGraphNester.nest
	{
		private get { } //Length: 5
	}

	[DoNotSerialize]
	private override IGraph Unity.VisualScripting.IGraphParent.childGraph
	{
		private get { } //Length: 57
	}

	[DoNotSerialize]
	private override bool Unity.VisualScripting.IGraphParent.isSerializationRoot
	{
		private get { } //Length: 3
	}

	[DoNotSerialize]
	private override object Unity.VisualScripting.IGraphParent.serializedObject
	{
		private get { } //Length: 227
	}

	[DoNotSerialize]
	private override GameObject Unity.VisualScripting.IMachine.threadSafeGameObject
	{
		private get { } //Length: 5
	}

	protected Machine`2() { }

	protected override void Awake() { }

	private void CacheReference() { }

	private void ClearCachedReference() { }

	public abstract TGraph DefaultGraph() { }

	public TGraph get_graph() { }

	[CompilerGenerated]
	public override IGraphData get_graphData() { }

	protected bool get_hasGraph() { }

	public bool get_isDescriptionValid() { }

	[CompilerGenerated]
	public GraphNest<TGraph, TMacro> get_nest() { }

	protected GraphReference get_reference() { }

	public override IEnumerable<Object> GetAotStubs(HashSet<Object> visited) { }

	public override GraphPointer GetReference() { }

	public override void InstantiateNest() { }

	protected override void OnDestroy() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	protected override void OnInstantiateWhileEnabled() { }

	protected override void OnUninstantiateWhileEnabled() { }

	protected override void OnValidate() { }

	[CompilerGenerated]
	public override void set_graphData(IGraphData value) { }

	public void set_isDescriptionValid(bool value) { }

	[CompilerGenerated]
	private void set_nest(GraphNest<TGraph, TMacro> value) { }

	public override void TriggerAnimationEvent(AnimationEvent animationEvent) { }

	public override void TriggerUnityEvent(string name) { }

	public override void UninstantiateNest() { }

	private override IGraphNest Unity.VisualScripting.IGraphNester.get_nest() { }

	private override IGraph Unity.VisualScripting.IGraphParent.DefaultGraph() { }

	private override IGraph Unity.VisualScripting.IGraphParent.get_childGraph() { }

	private override bool Unity.VisualScripting.IGraphParent.get_isSerializationRoot() { }

	private override object Unity.VisualScripting.IGraphParent.get_serializedObject() { }

	private override GameObject Unity.VisualScripting.IMachine.get_threadSafeGameObject() { }

}

