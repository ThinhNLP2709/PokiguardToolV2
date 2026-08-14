//Type is in global namespace

public static class MatchAssetGate
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public AnimationClip[] result; //Field offset: 0x10
		public bool done; //Field offset: 0x18

		public <>c__DisplayClass1_0() { }

		internal void <EnsureReady>b__0(AnimationClip[] clips) { }

	}

	[CompilerGenerated]
	private sealed class <EnsureReady>d__1 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchKind kind; //Field offset: 0x20
		public Action<String> onProgress; //Field offset: 0x28
		public IEnumerable<Int32> petIds; //Field offset: 0x30
		private <>c__DisplayClass1_0 <>8__1; //Field offset: 0x38
		private float <t0>5__2; //Field offset: 0x40
		private List<Int32> <unique>5__3; //Field offset: 0x48
		private int <i>5__4; //Field offset: 0x50
		private string <petPath>5__5; //Field offset: 0x58

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
		public <EnsureReady>d__1(int <>1__state) { }

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

	private const float TIMEOUT_SECONDS = 25; //Field offset: 0x0

	[IteratorStateMachine(typeof(<EnsureReady>d__1))]
	public static IEnumerator EnsureReady(MatchKind kind, IEnumerable<Int32> petIds, Action<String> onProgress = null) { }

	public static IEnumerator EnsureReady(MatchKind kind, int myPetId, int enemyPetId, Action<String> onProgress = null) { }

	private static void Report(Action<String> onProgress, string message) { }

	private static bool TimedOut(float t0) { }

}

