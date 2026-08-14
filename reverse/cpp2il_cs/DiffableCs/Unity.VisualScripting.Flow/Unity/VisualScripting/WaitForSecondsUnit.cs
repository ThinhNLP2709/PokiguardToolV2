namespace Unity.VisualScripting;

[UnitOrder(1)]
[UnitTitle("Wait For Seconds")]
public class WaitForSecondsUnit : WaitUnit
{
	[CompilerGenerated]
	private sealed class <Await>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Flow flow; //Field offset: 0x20
		public WaitForSecondsUnit <>4__this; //Field offset: 0x28

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
		public <Await>d__9(int <>1__state) { }

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
	private ValueInput <seconds>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <unscaledTime>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	[PortLabel("Delay")]
	public private ValueInput seconds
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Unscaled")]
	public private ValueInput unscaledTime
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public WaitForSecondsUnit() { }

	[IteratorStateMachine(typeof(<Await>d__9))]
	protected virtual IEnumerator Await(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_seconds() { }

	[CompilerGenerated]
	public ValueInput get_unscaledTime() { }

	[CompilerGenerated]
	private void set_seconds(ValueInput value) { }

	[CompilerGenerated]
	private void set_unscaledTime(ValueInput value) { }

}

