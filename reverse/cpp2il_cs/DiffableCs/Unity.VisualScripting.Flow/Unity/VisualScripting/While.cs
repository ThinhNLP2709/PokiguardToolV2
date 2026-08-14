namespace Unity.VisualScripting;

[UnitCategory("Control")]
[UnitOrder(11)]
[UnitTitle("While Loop")]
public class While : LoopUnit
{
	[CompilerGenerated]
	private sealed class <LoopCoroutine>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public While <>4__this; //Field offset: 0x20
		public Flow flow; //Field offset: 0x28
		private int <loop>5__2; //Field offset: 0x30
		private GraphStack <stack>5__3; //Field offset: 0x38

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
		public <LoopCoroutine>d__8(int <>1__state) { }

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
	private ValueInput <condition>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput condition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public While() { }

	private bool CanMoveNext(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_condition() { }

	protected virtual ControlOutput Loop(Flow flow) { }

	[IteratorStateMachine(typeof(<LoopCoroutine>d__8))]
	protected virtual IEnumerator LoopCoroutine(Flow flow) { }

	[CompilerGenerated]
	private void set_condition(ValueInput value) { }

	private int Start(Flow flow) { }

}

