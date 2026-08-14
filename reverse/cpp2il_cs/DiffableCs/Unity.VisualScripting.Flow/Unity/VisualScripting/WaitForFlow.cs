namespace Unity.VisualScripting;

[TypeIcon(typeof(WaitUnit))]
[UnitCategory("Time")]
[UnitOrder(6)]
public sealed class WaitForFlow : Unit, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public int _i; //Field offset: 0x10
		public WaitForFlow <>4__this; //Field offset: 0x18

		public <>c__DisplayClass21_0() { }

		internal ControlOutput <Definition>b__0(Flow flow) { }

		internal IEnumerator <Definition>b__1(Flow flow) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public WaitForFlow <>4__this; //Field offset: 0x10
		public Flow flow; //Field offset: 0x18

		public <>c__DisplayClass25_0() { }

		internal bool <EnterCoroutine>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <EnterCoroutine>d__25 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WaitForFlow <>4__this; //Field offset: 0x20
		public Flow flow; //Field offset: 0x28
		public int index; //Field offset: 0x30
		private <>c__DisplayClass25_0 <>8__1; //Field offset: 0x38
		private Data <data>5__2; //Field offset: 0x40

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <EnterCoroutine>d__25(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	internal sealed class Data : IGraphElementData
	{
		public Boolean[] inputsActivated; //Field offset: 0x10
		public bool isWaitingCoroutine; //Field offset: 0x18

		public Data() { }

	}

	[CompilerGenerated]
	private bool <resetOnExit>k__BackingField; //Field offset: 0x90
	[SerializeAs("inputCount")]
	private int _inputCount; //Field offset: 0x94
	[CompilerGenerated]
	private ReadOnlyCollection<ControlInput> <awaitedInputs>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ControlInput <reset>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	public private ReadOnlyCollection<ControlInput> awaitedInputs
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ControlOutput exit
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[Inspectable]
	[UnitHeaderInspectable("Inputs")]
	public int inputCount
	{
		 get { } //Length: 7
		 set { } //Length: 39
	}

	[DoNotSerialize]
	public private ControlInput reset
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Inspectable]
	[Serialize]
	public bool resetOnExit
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	public WaitForFlow() { }

	private bool CheckActivated(Flow flow) { }

	public override IGraphElementData CreateData() { }

	protected virtual void Definition() { }

	private ControlOutput Enter(Flow flow, int index) { }

	[IteratorStateMachine(typeof(<EnterCoroutine>d__25))]
	private IEnumerator EnterCoroutine(Flow flow, int index) { }

	[CompilerGenerated]
	public ReadOnlyCollection<ControlInput> get_awaitedInputs() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	public int get_inputCount() { }

	[CompilerGenerated]
	public ControlInput get_reset() { }

	[CompilerGenerated]
	public bool get_resetOnExit() { }

	private ControlOutput Reset(Flow flow) { }

	[CompilerGenerated]
	private void set_awaitedInputs(ReadOnlyCollection<ControlInput> value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

	public void set_inputCount(int value) { }

	[CompilerGenerated]
	private void set_reset(ControlInput value) { }

	[CompilerGenerated]
	public void set_resetOnExit(bool value) { }

}

