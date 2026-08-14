namespace UnityEngine.InputSystem.Utilities;

[Extension]
internal static class MiscHelpers
{
	[CompilerGenerated]
	private sealed class <EveryNth>d__1 : IEnumerable<TValue>, IEnumerable, IEnumerator<TValue>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private TValue <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEnumerable<TValue> enumerable; //Field offset: 0x0
		public IEnumerable<TValue> <>3__enumerable; //Field offset: 0x0
		private int start; //Field offset: 0x0
		public int <>3__start; //Field offset: 0x0
		private int n; //Field offset: 0x0
		public int <>3__n; //Field offset: 0x0
		private int <index>5__2; //Field offset: 0x0
		private IEnumerator<TValue> <>7__wrap2; //Field offset: 0x0

		private override TValue System.Collections.Generic.IEnumerator<TValue>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 172
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 173
		}

		[DebuggerHidden]
		public <EveryNth>d__1`1(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TValue> System.Collections.Generic.IEnumerable<TValue>.GetEnumerator() { }

		[DebuggerHidden]
		private override TValue System.Collections.Generic.IEnumerator<TValue>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}


	[Extension]
	[IteratorStateMachine(typeof(<EveryNth>d__1`1))]
	public static IEnumerable<TValue> EveryNth(IEnumerable<TValue> enumerable, int n, int start = 0) { }

	[Extension]
	public static TValue GetValueOrDefault(Dictionary<TKey, TValue> dictionary, TKey key) { }

	[Extension]
	public static int IndexOf(IEnumerable<TValue> enumerable, TValue value) { }

}

