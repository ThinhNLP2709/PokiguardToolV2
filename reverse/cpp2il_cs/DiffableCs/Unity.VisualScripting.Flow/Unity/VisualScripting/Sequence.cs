namespace Unity.VisualScripting;

[UnitCategory("Control")]
[UnitOrder(13)]
public sealed class Sequence : Unit
{
	[CompilerGenerated]
	private sealed class <EnterCoroutine>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Flow flow; //Field offset: 0x20
		public Sequence <>4__this; //Field offset: 0x28
		private GraphStack <stack>5__2; //Field offset: 0x30
		private IEnumerator<ControlOutput> <>7__wrap2; //Field offset: 0x38

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
		public <EnterCoroutine>d__14(int <>1__state) { }

		private void <>m__Finally1() { }

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

	[SerializeAs("outputCount")]
	private int _outputCount; //Field offset: 0x90
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ReadOnlyCollection<ControlOutput> <multiOutputs>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ControlInput enter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ReadOnlyCollection<ControlOutput> multiOutputs
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[Inspectable]
	[InspectorLabel("Steps")]
	[UnitHeaderInspectable("Steps")]
	public int outputCount
	{
		 get { } //Length: 7
		 set { } //Length: 39
	}

	public Sequence() { }

	public void CopyFrom(Sequence source) { }

	protected virtual void Definition() { }

	private ControlOutput Enter(Flow flow) { }

	[IteratorStateMachine(typeof(<EnterCoroutine>d__14))]
	private IEnumerator EnterCoroutine(Flow flow) { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ReadOnlyCollection<ControlOutput> get_multiOutputs() { }

	public int get_outputCount() { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_multiOutputs(ReadOnlyCollection<ControlOutput> value) { }

	public void set_outputCount(int value) { }

}

