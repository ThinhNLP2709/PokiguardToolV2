//Type is in global namespace

public class NotificationPopup : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <AutoClose>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public NotificationPopup <>4__this; //Field offset: 0x20

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
		public <AutoClose>d__20(int <>1__state) { }

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
	private sealed class <FadeIn>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public NotificationPopup <>4__this; //Field offset: 0x20
		private float <elapsed>5__2; //Field offset: 0x28

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
		public <FadeIn>d__18(int <>1__state) { }

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
	private sealed class <FadeOut>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public NotificationPopup <>4__this; //Field offset: 0x20
		private float <elapsed>5__2; //Field offset: 0x28
		private float <startAlpha>5__3; //Field offset: 0x2C

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
		public <FadeOut>d__19(int <>1__state) { }

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

	[Header("UI Components")]
	public TextMeshProUGUI txtTitle; //Field offset: 0x20
	public TextMeshProUGUI txtMessage; //Field offset: 0x28
	public Image imgReward; //Field offset: 0x30
	public TextMeshProUGUI txtRewardAmount; //Field offset: 0x38
	public Button btnClose; //Field offset: 0x40
	public GameObject rewardContainer; //Field offset: 0x48
	[Header("Animation")]
	public float fadeInDuration; //Field offset: 0x50
	public float autoCloseDuration; //Field offset: 0x54
	[Header("Audio")]
	public AudioClip successSound; //Field offset: 0x58
	public AudioClip errorSound; //Field offset: 0x60
	private CanvasGroup canvasGroup; //Field offset: 0x68
	private AudioSource audioSource; //Field offset: 0x70

	public NotificationPopup() { }

	[IteratorStateMachine(typeof(<AutoClose>d__20))]
	private IEnumerator AutoClose() { }

	private void Awake() { }

	public void Close() { }

	[IteratorStateMachine(typeof(<FadeIn>d__18))]
	private IEnumerator FadeIn() { }

	[IteratorStateMachine(typeof(<FadeOut>d__19))]
	private IEnumerator FadeOut() { }

	private void PlaySound(AudioClip clip) { }

	private void Show(string title, string message, bool isSuccess) { }

	public void ShowError(string title, string message) { }

	public void ShowMessage(string title, string message) { }

	public void ShowSuccess(string title, string message, Sprite rewardSprite, string rewardText) { }

}

