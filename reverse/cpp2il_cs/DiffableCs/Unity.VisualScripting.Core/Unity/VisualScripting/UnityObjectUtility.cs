namespace Unity.VisualScripting;

[Extension]
public static class UnityObjectUtility
{
	[CompilerGenerated]
	private sealed class <>c__6
	{
		public static readonly <>c__6<T> <>9; //Field offset: 0x0
		public static Func<T, Boolean> <>9__6_0; //Field offset: 0x0

		private static <>c__6`1() { }

		public <>c__6`1() { }

		internal bool <NotUnityNull>b__6_0(T i) { }

	}

	[CompilerGenerated]
	private sealed class <FindObjectsOfTypeIncludingInactive>d__7 : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private T <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private int <i>5__2; //Field offset: 0x0
		private GameObject[] <>7__wrap2; //Field offset: 0x0
		private int <>7__wrap3; //Field offset: 0x0
		private T[] <>7__wrap4; //Field offset: 0x0
		private int <>7__wrap5; //Field offset: 0x0

		private override T System.Collections.Generic.IEnumerator<T>.Current
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
		public <FindObjectsOfTypeIncludingInactive>d__7`1(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

		[DebuggerHidden]
		private override T System.Collections.Generic.IEnumerator<T>.get_Current() { }

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
	public static T AsUnityNull(T obj) { }

	[IteratorStateMachine(typeof(<FindObjectsOfTypeIncludingInactive>d__7`1))]
	public static IEnumerable<T> FindObjectsOfTypeIncludingInactive() { }

	[Extension]
	public static bool IsDestroyed(object target) { }

	[Extension]
	public static bool IsUnityNull(object obj) { }

	[Extension]
	public static IEnumerable<T> NotUnityNull(IEnumerable<T> enumerable) { }

	[Extension]
	public static string ToSafeString(object uo) { }

	[Extension]
	public static string ToSafeString(object obj) { }

	public static bool TrulyEqual(object a, object b) { }

}

