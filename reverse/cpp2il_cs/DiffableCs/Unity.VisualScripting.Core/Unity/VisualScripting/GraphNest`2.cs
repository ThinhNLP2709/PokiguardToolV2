namespace Unity.VisualScripting;

public sealed class GraphNest : IGraphNest, IAotStubbable
{
	[CompilerGenerated]
	private sealed class <get_deserializationDependencies>d__41 : IEnumerable<ISerializationDependency>, IEnumerable, IEnumerator<ISerializationDependency>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private ISerializationDependency <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		public GraphNest<TGraph, TMacro> <>4__this; //Field offset: 0x0

		private override ISerializationDependency System.Collections.Generic.IEnumerator<Unity.VisualScripting.ISerializationDependency>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <get_deserializationDependencies>d__41(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<ISerializationDependency> System.Collections.Generic.IEnumerable<Unity.VisualScripting.ISerializationDependency>.GetEnumerator() { }

		[DebuggerHidden]
		private override ISerializationDependency System.Collections.Generic.IEnumerator<Unity.VisualScripting.ISerializationDependency>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private IGraphNester <nester>k__BackingField; //Field offset: 0x0
	[DoNotSerialize]
	private GraphSource _source; //Field offset: 0x0
	[DoNotSerialize]
	private TMacro _macro; //Field offset: 0x0
	[DoNotSerialize]
	private TGraph _embed; //Field offset: 0x0
	[CompilerGenerated]
	private Action beforeGraphChange; //Field offset: 0x0
	[CompilerGenerated]
	private Action afterGraphChange; //Field offset: 0x0

	public event Action afterGraphChange
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public event Action beforeGraphChange
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public IEnumerable<ISerializationDependency> deserializationDependencies
	{
		[IteratorStateMachine(typeof(<get_deserializationDependencies>d__41))]
		 get { } //Length: 143
	}

	[Serialize]
	public TGraph embed
	{
		 get { } //Length: 5
		 set { } //Length: 105
	}

	[DoNotSerialize]
	public TGraph graph
	{
		 get { } //Length: 181
	}

	[DoNotSerialize]
	public override bool hasBackgroundEmbed
	{
		 get { } //Length: 18
	}

	[Serialize]
	public TMacro macro
	{
		 get { } //Length: 5
		 set { } //Length: 183
	}

	[DoNotSerialize]
	public override IGraphNester nester
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[Serialize]
	public override GraphSource source
	{
		 get { } //Length: 4
		 set { } //Length: 90
	}

	private override IGraph Unity.VisualScripting.IGraphNest.embed
	{
		private get { } //Length: 5
		private set { } //Length: 205
	}

	private override IGraph Unity.VisualScripting.IGraphNest.graph
	{
		private get { } //Length: 20
	}

	private override Type Unity.VisualScripting.IGraphNest.graphType
	{
		private get { } //Length: 57
	}

	private override IMacro Unity.VisualScripting.IGraphNest.macro
	{
		private get { } //Length: 5
		private set { } //Length: 274
	}

	private override Type Unity.VisualScripting.IGraphNest.macroType
	{
		private get { } //Length: 57
	}

	public GraphNest`2() { }

	[CompilerGenerated]
	public void add_afterGraphChange(Action value) { }

	[CompilerGenerated]
	public void add_beforeGraphChange(Action value) { }

	private void AfterGraphChange() { }

	private void BeforeGraphChange() { }

	[IteratorStateMachine(typeof(<get_deserializationDependencies>d__41))]
	public IEnumerable<ISerializationDependency> get_deserializationDependencies() { }

	public TGraph get_embed() { }

	public TGraph get_graph() { }

	public override bool get_hasBackgroundEmbed() { }

	public TMacro get_macro() { }

	[CompilerGenerated]
	public override IGraphNester get_nester() { }

	public override GraphSource get_source() { }

	public override IEnumerable<Object> GetAotStubs(HashSet<Object> visited) { }

	[CompilerGenerated]
	public void remove_afterGraphChange(Action value) { }

	[CompilerGenerated]
	public void remove_beforeGraphChange(Action value) { }

	public void set_embed(TGraph value) { }

	public void set_macro(TMacro value) { }

	[CompilerGenerated]
	public override void set_nester(IGraphNester value) { }

	public override void set_source(GraphSource value) { }

	public void SwitchToEmbed(TGraph embed) { }

	public void SwitchToMacro(TMacro macro) { }

	private override IGraph Unity.VisualScripting.IGraphNest.get_embed() { }

	private override IGraph Unity.VisualScripting.IGraphNest.get_graph() { }

	private override Type Unity.VisualScripting.IGraphNest.get_graphType() { }

	private override IMacro Unity.VisualScripting.IGraphNest.get_macro() { }

	private override Type Unity.VisualScripting.IGraphNest.get_macroType() { }

	private override void Unity.VisualScripting.IGraphNest.set_embed(IGraph value) { }

	private override void Unity.VisualScripting.IGraphNest.set_macro(IMacro value) { }

}

