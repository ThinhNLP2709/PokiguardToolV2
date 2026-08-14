namespace Unity.VisualScripting;

[DisplayName("Subgraph Node")]
[RenamedFrom("Bolt.SuperUnit")]
[RenamedFrom("Unity.VisualScripting.SuperUnit")]
[TypeIcon(typeof(FlowGraph))]
[UnitCategory("Nesting")]
[UnitTitle("Subgraph")]
public sealed class SubgraphUnit : NesterUnit<FlowGraph, ScriptGraphAsset>, IGraphEventListener, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public string key; //Field offset: 0x10
		public SubgraphUnit <>4__this; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal ControlOutput <Definition>b__0(Flow flow) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_1
	{
		public string key; //Field offset: 0x10
		public SubgraphUnit <>4__this; //Field offset: 0x18

		public <>c__DisplayClass7_1() { }

		internal object <Definition>b__1(Flow flow) { }

	}

	internal sealed class Data : IGraphElementData
	{
		public bool isListening; //Field offset: 0x10

		public Data() { }

	}


	public SubgraphUnit() { }

	public SubgraphUnit(ScriptGraphAsset macro) { }

	public virtual void AfterAdd() { }

	public virtual void BeforeRemove() { }

	public override IGraphElementData CreateData() { }

	public virtual FlowGraph DefaultGraph() { }

	protected virtual void Definition() { }

	public override bool IsListening(GraphPointer pointer) { }

	public override void StartListening(GraphStack stack) { }

	private void StartWatchingPortDefinitions() { }

	public override void StopListening(GraphStack stack) { }

	private void StopWatchingPortDefinitions() { }

	public static SubgraphUnit WithInputOutput() { }

	public static SubgraphUnit WithStartUpdate() { }

}

