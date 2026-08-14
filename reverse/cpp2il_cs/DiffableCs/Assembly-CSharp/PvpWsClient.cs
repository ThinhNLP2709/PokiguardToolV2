//Type is in global namespace

public class PvpWsClient : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <RetrySubscribe>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PvpWsClient <>4__this; //Field offset: 0x20

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
		public <RetrySubscribe>d__13(int <>1__state) { }

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

	private static PvpWsClient _instance; //Field offset: 0x0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnPongReceived; //Field offset: 0x20
	private bool _subscribed; //Field offset: 0x28

	public event Action<ChatMessageDTO> OnPongReceived
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public static PvpWsClient Instance
	{
		 get { } //Length: 288
	}

	public static bool UsePvpWs
	{
		 get { } //Length: 60
	}

	public PvpWsClient() { }

	[CompilerGenerated]
	public void add_OnPongReceived(Action<ChatMessageDTO> value) { }

	private void Awake() { }

	public static PvpWsClient get_Instance() { }

	public static bool get_UsePvpWs() { }

	private void HandlePong(ChatMessageDTO msg) { }

	private void OnDisable() { }

	private void OnEnable() { }

	[CompilerGenerated]
	public void remove_OnPongReceived(Action<ChatMessageDTO> value) { }

	[IteratorStateMachine(typeof(<RetrySubscribe>d__13))]
	private IEnumerator RetrySubscribe() { }

	public void SendPing(string roomId = null) { }

	private void TrySubscribe() { }

	private void Unsubscribe() { }

}

