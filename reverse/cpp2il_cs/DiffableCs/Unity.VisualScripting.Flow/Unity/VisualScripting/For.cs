namespace Unity.VisualScripting;

[UnitCategory("Control")]
[UnitOrder(9)]
[UnitTitle("For Loop")]
public sealed class For : LoopUnit
{
	[CompilerGenerated]
	private sealed class <LoopCoroutine>d__21 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public For <>4__this; //Field offset: 0x20
		public Flow flow; //Field offset: 0x28
		private int <loop>5__2; //Field offset: 0x30
		private int <currentIndex>5__3; //Field offset: 0x34
		private int <lastIndex>5__4; //Field offset: 0x38
		private bool <ascending>5__5; //Field offset: 0x3C
		private GraphStack <stack>5__6; //Field offset: 0x40

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
		public <LoopCoroutine>d__21(int <>1__state) { }

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

	[CompilerGenerated]
	private ValueInput <firstIndex>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueInput <lastIndex>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueInput <step>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ValueOutput <currentIndex>k__BackingField; //Field offset: 0xC0

	[DoNotSerialize]
	[PortLabel("Index")]
	public private ValueOutput currentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("First")]
	public private ValueInput firstIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Last")]
	public private ValueInput lastIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueInput step
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public For() { }

	private bool CanMoveNext(int currentIndex, int lastIndex, bool ascending) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_currentIndex() { }

	[CompilerGenerated]
	public ValueInput get_firstIndex() { }

	[CompilerGenerated]
	public ValueInput get_lastIndex() { }

	[CompilerGenerated]
	public ValueInput get_step() { }

	public bool IsStepValueZero() { }

	protected virtual ControlOutput Loop(Flow flow) { }

	[IteratorStateMachine(typeof(<LoopCoroutine>d__21))]
	protected virtual IEnumerator LoopCoroutine(Flow flow) { }

	private void MoveNext(Flow flow, ref int currentIndex) { }

	[CompilerGenerated]
	private void set_currentIndex(ValueOutput value) { }

	[CompilerGenerated]
	private void set_firstIndex(ValueInput value) { }

	[CompilerGenerated]
	private void set_lastIndex(ValueInput value) { }

	[CompilerGenerated]
	private void set_step(ValueInput value) { }

	private int Start(Flow flow, out int currentIndex, out int lastIndex, out bool ascending) { }

}

