//Type is in global namespace

public class BossItem : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public bool ready; //Field offset: 0x10
		public bool failed; //Field offset: 0x11
		public string failReason; //Field offset: 0x18

		public <>c__DisplayClass28_0() { }

		internal void <CreateBossRoomThenLoadScene>b__0() { }

		internal void <CreateBossRoomThenLoadScene>b__1(string r) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_1
	{
		public bool started; //Field offset: 0x10
		public bool startFailed; //Field offset: 0x11
		public string startFailReason; //Field offset: 0x18

		public <>c__DisplayClass28_1() { }

		internal void <CreateBossRoomThenLoadScene>b__2(ChatMessageDTO _) { }

		internal void <CreateBossRoomThenLoadScene>b__3(ChatMessageDTO m) { }

	}

	[CompilerGenerated]
	private sealed class <CreateBossRoomThenLoadScene>d__28 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BossItem <>4__this; //Field offset: 0x20
		private <>c__DisplayClass28_0 <>8__1; //Field offset: 0x28
		private <>c__DisplayClass28_1 <>8__2; //Field offset: 0x30
		private Action <onReady>5__2; //Field offset: 0x38
		private Action<String> <onFailed>5__3; //Field offset: 0x40
		private float <tWs>5__4; //Field offset: 0x48
		private float <t>5__5; //Field offset: 0x4C
		private Action<ChatMessageDTO> <onStarting>5__6; //Field offset: 0x50
		private Action<ChatMessageDTO> <onStartFailed>5__7; //Field offset: 0x58
		private float <tStart>5__8; //Field offset: 0x60

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
		public <CreateBossRoomThenLoadScene>d__28(int <>1__state) { }

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

	[Header("UI Elements - Tự động tìm nếu không gán")]
	public Image imgBoss; //Field offset: 0x20
	public Image imgStatus; //Field offset: 0x28
	public Text txtName; //Field offset: 0x30
	public Text txtTime; //Field offset: 0x38
	public Text txtStatus; //Field offset: 0x40
	public Button btnFight; //Field offset: 0x48
	public GameObject upcomingBadge; //Field offset: 0x50
	public GameObject endedOverlay; //Field offset: 0x58
	public GameObject anmt; //Field offset: 0x60
	[Header("Panel Notice")]
	public GameObject panelNotice; //Field offset: 0x68
	public Text txtNoticeMessage; //Field offset: 0x70
	private WorldBossDTO bossData; //Field offset: 0x78
	private DateTime startTime; //Field offset: 0x80
	private DateTime endTime; //Field offset: 0x88
	private long _serverClockOffsetMs; //Field offset: 0x90
	private Transform uiTransform; //Field offset: 0x98
	private Outline txtStatusOutline; //Field offset: 0xA0
	private Color colorActive; //Field offset: 0xA8
	private Color colorUpcoming; //Field offset: 0xB8
	private Color colorEnded; //Field offset: 0xC8

	public BossItem() { }

	[CompilerGenerated]
	private void <CloseNotice>b__30_0() { }

	[CompilerGenerated]
	private void <SetupBoss>b__22_0() { }

	[CompilerGenerated]
	private void <ShowNotice>b__29_0() { }

	private void AutoFindUIComponents() { }

	private void Awake() { }

	private void CloseNotice() { }

	[IteratorStateMachine(typeof(<CreateBossRoomThenLoadScene>d__28))]
	private IEnumerator CreateBossRoomThenLoadScene() { }

	private string FormatTimeSpan(TimeSpan time) { }

	private void LoadBossSprite(long petId) { }

	private void OnFightClicked() { }

	public void SetupBoss(WorldBossDTO boss) { }

	private void ShowNotice(string message) { }

	public void UpdateCountdown() { }

	private void UpdateUI() { }

}

