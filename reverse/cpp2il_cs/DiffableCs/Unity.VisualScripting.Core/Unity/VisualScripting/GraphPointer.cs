namespace Unity.VisualScripting;

public abstract class GraphPointer
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<IGraphParentElement, Guid> <>9__38_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal Guid <get_parentElementGuids>b__38_0(IGraphParentElement parentElement) { }

	}

	[CompilerGenerated]
	private static Func<IGraphRoot, IGraphDebugData> <fetchRootDebugDataBinding>k__BackingField; //Field offset: 0x0
	internal static Action<IGraphRoot> releaseDebugDataBinding; //Field offset: 0x8
	[CompilerGenerated]
	private IGraphRoot <root>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private GameObject <gameObject>k__BackingField; //Field offset: 0x18
	protected readonly List<IGraphParent> parentStack; //Field offset: 0x20
	protected readonly List<IGraphParentElement> parentElementStack; //Field offset: 0x28
	protected readonly List<IGraph> graphStack; //Field offset: 0x30
	protected readonly List<IGraphData> dataStack; //Field offset: 0x38
	protected readonly List<IGraphDebugData> debugDataStack; //Field offset: 0x40

	protected IGraphData _data
	{
		 get { } //Length: 89
		 set { } //Length: 104
	}

	protected IGraphDebugData _debugData
	{
		 get { } //Length: 89
		 set { } //Length: 104
	}

	protected IGraphData _parentData
	{
		 get { } //Length: 90
	}

	public MonoBehaviour component
	{
		 get { } //Length: 114
	}

	public IGraphData data
	{
		 get { } //Length: 250
	}

	public IGraphDebugData debugData
	{
		 get { } //Length: 250
	}

	public int depth
	{
		 get { } //Length: 60
	}

	public static Func<IGraphRoot, IGraphDebugData> fetchRootDebugDataBinding
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		 set { } //Length: 81
	}

	public private GameObject gameObject
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public IGraph graph
	{
		 get { } //Length: 89
	}

	public bool hasData
	{
		 get { } //Length: 96
	}

	public bool hasDebugData
	{
		 get { } //Length: 96
	}

	public bool isChild
	{
		 get { } //Length: 64
	}

	public bool isRoot
	{
		 get { } //Length: 64
	}

	public bool isValid
	{
		 get { } //Length: 1072
	}

	public IMachine machine
	{
		 get { } //Length: 58
	}

	public IMacro macro
	{
		 get { } //Length: 58
	}

	public IGraphParent parent
	{
		 get { } //Length: 89
	}

	public IGraphParentElement parentElement
	{
		 get { } //Length: 218
	}

	public IEnumerable<Guid> parentElementGuids
	{
		 get { } //Length: 273
	}

	public IGraphRoot root
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public IGraph rootGraph
	{
		 get { } //Length: 70
	}

	public object rootObject
	{
		 get { } //Length: 114
	}

	public Nullable<Scene> scene
	{
		 get { } //Length: 195
	}

	public ScriptableObject scriptableObject
	{
		 get { } //Length: 114
	}

	public GameObject self
	{
		 get { } //Length: 5
	}

	public object serializedObject
	{
		 get { } //Length: 282
	}

	internal GraphPointer() { }

	public abstract GraphReference AsReference() { }

	public int ComputeHashCode() { }

	public override void CopyFrom(GraphPointer other) { }

	public bool DefinitionEquals(GraphPointer other) { }

	public void EnsureChild() { }

	public void EnsureDataAvailable() { }

	public void EnsureDebugDataAvailable() { }

	public void EnsureDepthValid(int depth) { }

	public void EnsureValid() { }

	public void EnsureWithin() { }

	protected void EnterParentElement(Guid parentElementGuid) { }

	protected void EnterParentElement(IGraphParentElement parentElement) { }

	private void EnterValidParentElement(IGraphParentElement parentElement) { }

	protected void ExitParentElement() { }

	protected IGraphData get__data() { }

	protected IGraphDebugData get__debugData() { }

	protected IGraphData get__parentData() { }

	public MonoBehaviour get_component() { }

	public IGraphData get_data() { }

	public IGraphDebugData get_debugData() { }

	public int get_depth() { }

	[CompilerGenerated]
	public static Func<IGraphRoot, IGraphDebugData> get_fetchRootDebugDataBinding() { }

	[CompilerGenerated]
	public GameObject get_gameObject() { }

	public IGraph get_graph() { }

	public bool get_hasData() { }

	public bool get_hasDebugData() { }

	public bool get_isChild() { }

	public bool get_isRoot() { }

	public bool get_isValid() { }

	public IMachine get_machine() { }

	public IMacro get_macro() { }

	public IGraphParent get_parent() { }

	public IGraphParentElement get_parentElement() { }

	public IEnumerable<Guid> get_parentElementGuids() { }

	[CompilerGenerated]
	public IGraphRoot get_root() { }

	public IGraph get_rootGraph() { }

	public object get_rootObject() { }

	public Nullable<Scene> get_scene() { }

	public ScriptableObject get_scriptableObject() { }

	public GameObject get_self() { }

	public object get_serializedObject() { }

	public T GetElementData(IGraphElementWithData element) { }

	public T GetElementDebugData(IGraphElementWithDebugData element) { }

	public T GetGraphData() { }

	public T GetGraphDebugData() { }

	public T GetParent() { }

	protected void Initialize(object rootObject, IEnumerable<Guid> parentElementGuids, bool ensureValid) { }

	protected void Initialize(IGraphRoot root, IEnumerable<IGraphParentElement> parentElements, bool ensureValid) { }

	protected void Initialize(IGraphRoot root) { }

	public bool InstanceEquals(GraphPointer other) { }

	protected static bool IsValidRoot(IGraphRoot root) { }

	protected static bool IsValidRoot(object rootObject) { }

	public bool IsWithin() { }

	protected void set__data(IGraphData value) { }

	protected void set__debugData(IGraphDebugData value) { }

	[CompilerGenerated]
	public static void set_fetchRootDebugDataBinding(Func<IGraphRoot, IGraphDebugData> value) { }

	[CompilerGenerated]
	private void set_gameObject(GameObject value) { }

	[CompilerGenerated]
	protected void set_root(IGraphRoot value) { }

	public virtual string ToString() { }

	protected bool TryEnterParentElement(Guid parentElementGuid, out string error, Nullable<Int32> maxRecursionDepth = null) { }

	protected bool TryEnterParentElement(IGraphParentElement parentElement, out string error, Nullable<Int32> maxRecursionDepth = null, bool skipContainsCheck = false) { }

}

