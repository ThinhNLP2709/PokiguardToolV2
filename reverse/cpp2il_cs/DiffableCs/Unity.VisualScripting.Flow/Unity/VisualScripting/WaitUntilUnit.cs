namespace Unity.VisualScripting;

[UnitOrder(2)]
[UnitShortTitle("Wait Until")]
[UnitTitle("Wait Until")]
public class WaitUntilUnit : WaitUnit
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public Flow flow; //Field offset: 0x10
		public WaitUntilUnit <>4__this; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal bool <Await>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <Await>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Flow flow; //Field offset: 0x20
		public WaitUntilUnit <>4__this; //Field offset: 0x28

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
		public <Await>d__5(int <>1__state) { }

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
	private ValueInput <condition>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	public private ValueInput condition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public WaitUntilUnit() { }

	[IteratorStateMachine(typeof(<Await>d__5))]
	protected virtual IEnumerator Await(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_condition() { }

	[CompilerGenerated]
	private void set_condition(ValueInput value) { }

}

