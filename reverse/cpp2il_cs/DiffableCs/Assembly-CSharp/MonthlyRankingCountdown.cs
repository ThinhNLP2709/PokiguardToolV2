//Type is in global namespace

public class MonthlyRankingCountdown : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__16_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <CheckRewardStatus>b__16_1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <CheckRewardStatus>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MonthlyRankingCountdown <>4__this; //Field offset: 0x20

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
		public <CheckRewardStatus>d__16(int <>1__state) { }

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
	private sealed class <HideNotificationAfterDelay>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		public MonthlyRankingCountdown <>4__this; //Field offset: 0x28

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
		public <HideNotificationAfterDelay>d__18(int <>1__state) { }

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

	[Header("UI References")]
	public Text timeMonthText; //Field offset: 0x20
	public Text labelText; //Field offset: 0x28
	[Header("Settings")]
	public bool showDebugLogs; //Field offset: 0x30
	public int checkStatusIntervalMinutes; //Field offset: 0x34
	[Header("Optional: Notification UI")]
	public GameObject notificationPanel; //Field offset: 0x38
	public Text notificationText; //Field offset: 0x40
	private DateTime nextMonthStart; //Field offset: 0x48
	private bool rewardsSentThisMonth; //Field offset: 0x50

	public MonthlyRankingCountdown() { }

	[CompilerGenerated]
	private void <CheckRewardStatus>b__16_0(MonthlyRankingStatusResponse response) { }

	private void CalculateNextMonthStart() { }

	[IteratorStateMachine(typeof(<CheckRewardStatus>d__16))]
	private IEnumerator CheckRewardStatus() { }

	private string FormatTimeSpan(TimeSpan timeSpan) { }

	[IteratorStateMachine(typeof(<HideNotificationAfterDelay>d__18))]
	private IEnumerator HideNotificationAfterDelay(float delay) { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void PeriodicCheckStatus() { }

	private void ShowNotification(string message) { }

	private void Start() { }

	private void StartRepeatingTasks() { }

	private void UpdateCountdown() { }

}

