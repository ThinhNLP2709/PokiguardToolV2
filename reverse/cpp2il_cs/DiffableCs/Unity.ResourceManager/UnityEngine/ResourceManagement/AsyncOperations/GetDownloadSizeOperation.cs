namespace UnityEngine.ResourceManagement.AsyncOperations;

internal class GetDownloadSizeOperation : AsyncOperationBase<Int64>
{
	[CompilerGenerated]
	private sealed class <Calculate>d__3 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GetDownloadSizeOperation <>4__this; //Field offset: 0x20
		private long <size>5__2; //Field offset: 0x28
		private IEnumerator<IResourceLocation> <>7__wrap2; //Field offset: 0x30

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
		public <Calculate>d__3(int <>1__state) { }

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

	private IEnumerable<IResourceLocation> m_Locations; //Field offset: 0x98
	private Coroutine m_AsyncCalculation; //Field offset: 0xA0

	public GetDownloadSizeOperation() { }

	[IteratorStateMachine(typeof(<Calculate>d__3))]
	private IEnumerator Calculate() { }

	private void CalculateSync() { }

	protected virtual void Execute() { }

	public void Init(IEnumerable<IResourceLocation> locations, ResourceManager resourceManager) { }

	protected virtual bool InvokeWaitForCompletion() { }

}

