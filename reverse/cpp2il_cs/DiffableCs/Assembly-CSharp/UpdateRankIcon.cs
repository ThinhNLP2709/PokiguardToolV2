//Type is in global namespace

public class UpdateRankIcon : MonoBehaviour, IHubSuspendable
{
	[CompilerGenerated]
	private sealed class <UpdateLoop>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public UpdateRankIcon <>4__this; //Field offset: 0x20
		private WaitForSeconds <wait>5__2; //Field offset: 0x28

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
		public <UpdateLoop>d__8(int <>1__state) { }

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

	public Text txtSource; //Field offset: 0x20
	public Image imgRankIcon; //Field offset: 0x28
	private string _appliedIconName; //Field offset: 0x30
	private Coroutine _loop; //Field offset: 0x38

	public UpdateRankIcon() { }

	private string GetIconName(int points) { }

	private void OnDisable() { }

	private void OnEnable() { }

	public override void OnHubResume() { }

	public override void OnHubSuspend() { }

	private void StartLoop() { }

	private void StopLoop() { }

	private void UpdateIcon() { }

	[IteratorStateMachine(typeof(<UpdateLoop>d__8))]
	private IEnumerator UpdateLoop() { }

}

