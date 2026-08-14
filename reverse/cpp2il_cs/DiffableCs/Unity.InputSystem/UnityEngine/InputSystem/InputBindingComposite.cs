namespace UnityEngine.InputSystem;

public abstract class InputBindingComposite
{
	[CompilerGenerated]
	private sealed class <GetPartNames>d__12 : IEnumerable<String>, IEnumerable, IEnumerator<String>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private string <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private string composite; //Field offset: 0x28
		public string <>3__composite; //Field offset: 0x30
		private FieldInfo[] <>7__wrap1; //Field offset: 0x38
		private int <>7__wrap2; //Field offset: 0x40

		private override string System.Collections.Generic.IEnumerator<System.String>.Current
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
		public <GetPartNames>d__12(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<String> System.Collections.Generic.IEnumerable<System.String>.GetEnumerator() { }

		[DebuggerHidden]
		private override string System.Collections.Generic.IEnumerator<System.String>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	internal static TypeTable s_Composites; //Field offset: 0x0

	public abstract int valueSizeInBytes
	{
		 get { } //Length: 0
	}

	public abstract Type valueType
	{
		 get { } //Length: 0
	}

	protected InputBindingComposite() { }

	internal void CallFinishSetup(ref InputBindingCompositeContext context) { }

	public override float EvaluateMagnitude(ref InputBindingCompositeContext context) { }

	protected override void FinishSetup(ref InputBindingCompositeContext context) { }

	public abstract int get_valueSizeInBytes() { }

	public abstract Type get_valueType() { }

	internal static string GetDisplayFormatString(string composite) { }

	public static string GetExpectedControlLayoutName(string composite, string part) { }

	[IteratorStateMachine(typeof(<GetPartNames>d__12))]
	internal static IEnumerable<String> GetPartNames(string composite) { }

	internal static Type GetValueType(string composite) { }

	public abstract void ReadValue(ref InputBindingCompositeContext context, Void* buffer, int bufferSize) { }

	public abstract object ReadValueAsObject(ref InputBindingCompositeContext context) { }

}

