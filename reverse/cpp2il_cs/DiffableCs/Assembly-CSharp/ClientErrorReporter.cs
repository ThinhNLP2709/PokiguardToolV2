//Type is in global namespace

public class ClientErrorReporter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <SendReport>d__15 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ClientErrorReporter <>4__this; //Field offset: 0x20
		public PendingReport report; //Field offset: 0x28
		public string token; //Field offset: 0x40
		private UnityWebRequest <request>5__2; //Field offset: 0x48

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
		public <SendReport>d__15(int <>1__state) { }

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

	private class ClientLogPayload
	{
		public string level; //Field offset: 0x10
		public string message; //Field offset: 0x18
		public string stack; //Field offset: 0x20
		public string scene; //Field offset: 0x28
		public string version; //Field offset: 0x30

		public ClientLogPayload() { }

	}

	private struct PendingReport
	{
		public string level; //Field offset: 0x0
		public string message; //Field offset: 0x8
		public string stack; //Field offset: 0x10

	}

	private const int MaxReportsPerSession = 15; //Field offset: 0x0
	private const float MinSecondsBetweenSends = 5; //Field offset: 0x0
	private const int MaxMessageLength = 500; //Field offset: 0x0
	private const int MaxStackLength = 2000; //Field offset: 0x0
	private static ClientErrorReporter _instance; //Field offset: 0x0
	private readonly ConcurrentQueue<PendingReport> _pending; //Field offset: 0x20
	private readonly HashSet<Int32> _sentHashes; //Field offset: 0x28
	private int _sentCount; //Field offset: 0x30
	private float _lastSendAt; //Field offset: 0x34
	private bool _sending; //Field offset: 0x38

	public ClientErrorReporter() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	private static void Bootstrap() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnLogMessage(string condition, string stackTrace, LogType type) { }

	[IteratorStateMachine(typeof(<SendReport>d__15))]
	private IEnumerator SendReport(PendingReport report, string token) { }

	private static string Truncate(string s, int max) { }

	private void Update() { }

}

