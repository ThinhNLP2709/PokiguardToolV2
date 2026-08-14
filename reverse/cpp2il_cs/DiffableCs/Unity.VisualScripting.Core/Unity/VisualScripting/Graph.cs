namespace Unity.VisualScripting;

public abstract class Graph : IGraph, IDisposable, IPrewarmable, IAotStubbable, ISerializationDepender, ISerializationCallbackReceiver
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<IGraphElement, IEnumerable`1<ISerializationDependency>> <>9__27_0; //Field offset: 0x8
		public static Comparison<IGraphElement> <>9__30_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal IEnumerable<ISerializationDependency> <get_deserializationDependencies>b__27_0(IGraphElement e) { }

		internal int <OnAfterDependenciesDeserialized>b__30_0(IGraphElement a, IGraphElement b) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public HashSet<Object> visited; //Field offset: 0x10

		public <>c__DisplayClass31_0() { }

		internal bool <GetAotStubs>b__0(IGraphElement element) { }

		internal IGraphElement <GetAotStubs>b__1(IGraphElement element) { }

		internal IEnumerable<Object> <GetAotStubs>b__2(IGraphElement element) { }

	}

	[SerializeAs("elements")]
	private List<IGraphElement> _elements; //Field offset: 0x10
	[CompilerGenerated]
	private readonly MergedGraphElementCollection <elements>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <title>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private string <summary>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private Vector2 <pan>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private float <zoom>k__BackingField; //Field offset: 0x38
	private bool prewarmed; //Field offset: 0x3C

	public override IEnumerable<ISerializationDependency> deserializationDependencies
	{
		 get { } //Length: 273
	}

	[DoNotSerialize]
	public override MergedGraphElementCollection elements
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	[Serialize]
	public override Vector2 pan
	{
		[CompilerGenerated]
		 get { } //Length: 19
		[CompilerGenerated]
		 set { } //Length: 5
	}

	[InspectorTextArea(minLines = 1, maxLines = 10)]
	[Serialize]
	public override string summary
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[Serialize]
	public override string title
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[Serialize]
	public override float zoom
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	protected Graph() { }

	public abstract IGraphData CreateData() { }

	public override IGraphDebugData CreateDebugData() { }

	public override void Dispose() { }

	public override IEnumerable<ISerializationDependency> get_deserializationDependencies() { }

	[CompilerGenerated]
	public override MergedGraphElementCollection get_elements() { }

	[CompilerGenerated]
	public override Vector2 get_pan() { }

	[CompilerGenerated]
	public override string get_summary() { }

	[CompilerGenerated]
	public override string get_title() { }

	[CompilerGenerated]
	public override float get_zoom() { }

	public override IEnumerable<Object> GetAotStubs(HashSet<Object> visited) { }

	public override void Instantiate(GraphReference instance) { }

	public override void OnAfterDependenciesDeserialized() { }

	public override void OnAfterDeserialize() { }

	public override void OnBeforeSerialize() { }

	public override void Prewarm() { }

	[CompilerGenerated]
	public override void set_pan(Vector2 value) { }

	[CompilerGenerated]
	public void set_summary(string value) { }

	[CompilerGenerated]
	public void set_title(string value) { }

	[CompilerGenerated]
	public override void set_zoom(float value) { }

	public virtual string ToString() { }

	public override void Uninstantiate(GraphReference instance) { }

}

