//Type is in global namespace

[DisallowMultipleComponent]
public class PetStarPanelController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__48_0; //Field offset: 0x8
		public static Action<String> <>9__56_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <LoadInfoCo>b__48_0(string err) { }

		internal void <UpgradeCo>b__56_1(string err) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass62_0
	{
		public PetStarPanelController <>4__this; //Field offset: 0x10
		public Vector3 home; //Field offset: 0x18

		public <>c__DisplayClass62_0() { }

		internal void <PlayPressFx>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <LoadInfoCo>d__48 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PetStarPanelController <>4__this; //Field offset: 0x20

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
		public <LoadInfoCo>d__48(int <>1__state) { }

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
	private sealed class <UpgradeCo>d__56 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PetStarPanelController <>4__this; //Field offset: 0x20

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
		public <UpgradeCo>d__56(int <>1__state) { }

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

	private const float GLOW_SECONDS_PER_TURN = 8; //Field offset: 0x0
	private const float FLASH_PEAK_ALPHA = 0.55; //Field offset: 0x0
	[Header("Root")]
	public GameObject panelRoot; //Field offset: 0x20
	public Button btnBack; //Field offset: 0x28
	[Header("Khối trưng bày pet")]
	public Image imgPetBig; //Field offset: 0x30
	[Tooltip("Quầng sáng xoay sau pet — tốc độ tăng theo số sao.")]
	public Image imgGlow; //Field offset: 0x38
	public Transform starRow; //Field offset: 0x40
	public Text txtStarLabel; //Field offset: 0x48
	public Text txtPetName; //Field offset: 0x50
	[Header("Preview chỉ số")]
	public Text txtHpNow; //Field offset: 0x58
	public Text txtHpNext; //Field offset: 0x60
	public Text txtAtkNow; //Field offset: 0x68
	public Text txtAtkNext; //Field offset: 0x70
	public Text txtManaNow; //Field offset: 0x78
	public Text txtManaNext; //Field offset: 0x80
	public Text txtBonusNow; //Field offset: 0x88
	public Text txtBonusNext; //Field offset: 0x90
	[Header("Mảnh")]
	public Image imgShardIcon; //Field offset: 0x98
	public Image imgShardPiece; //Field offset: 0xA0
	public Text txtShardProgress; //Field offset: 0xA8
	public Slider sliderShard; //Field offset: 0xB0
	[Header("Hành động")]
	public Button btnUpgrade; //Field offset: 0xB8
	public Text txtUpgradeLabel; //Field offset: 0xC0
	[Header("FX")]
	[Tooltip("Ảnh phủ toàn panel dùng làm nháy sáng khi nâng thành công.")]
	public Image imgFlash; //Field offset: 0xC8
	[Tooltip("Chữ bay lên khi nâng thành công (vd '+15% SỨC MẠNH').")]
	public Text txtFloating; //Field offset: 0xD0
	private int _userId; //Field offset: 0xD8
	private long _petId; //Field offset: 0xE0
	private string _petName; //Field offset: 0xE8
	private int _star; //Field offset: 0xF0
	private int _maxStar; //Field offset: 0xF4
	private int _shardCount; //Field offset: 0xF8
	private int _nextCost; //Field offset: 0xFC
	private bool _busy; //Field offset: 0x100
	private bool _wired; //Field offset: 0x101
	private bool _finalForm; //Field offset: 0x102
	private string _blockedReason; //Field offset: 0x108
	private CanvasGroup _cg; //Field offset: 0x110
	private Vector3 _floatingHome; //Field offset: 0x118
	private bool _floatingHomeSaved; //Field offset: 0x124

	public bool IsOpen
	{
		 get { } //Length: 125
	}

	public PetStarPanelController() { }

	[CompilerGenerated]
	private void <PlaySuccessFx>b__63_0(float v) { }

	[CompilerGenerated]
	private void <PlaySuccessFx>b__63_1() { }

	[CompilerGenerated]
	private void <PlaySuccessFx>b__63_2(float v) { }

	[CompilerGenerated]
	private void <PlaySuccessFx>b__63_3() { }

	[CompilerGenerated]
	private void <ShowFloating>b__64_0(float v) { }

	[CompilerGenerated]
	private void <ShowFloating>b__64_1() { }

	[CompilerGenerated]
	private void <UpgradeCo>b__56_0(PetStarUpgradeResponse resp) { }

	private void Awake() { }

	private void CancelFx() { }

	public void Close() { }

	private static string Delta(int d) { }

	public bool get_IsOpen() { }

	[IteratorStateMachine(typeof(<LoadInfoCo>d__48))]
	private IEnumerator LoadInfoCo() { }

	private void NotifyStarChanged() { }

	private void OnDisable() { }

	private void OnInfoLoaded(PetStarInfoResponse resp) { }

	private void OnUpgradeClicked() { }

	public void Open(long petId, string petName) { }

	private void PaintShard() { }

	private void PaintStars() { }

	private void PaintStats(int hp, int hpNext, int atk, int atkNext, int mana, int manaNext, int bonus, int nextBonus) { }

	private void PlayPressFx() { }

	private void PlaySuccessFx(int oldStar, int newStar, int bonusPercent) { }

	private void Reload() { }

	private static void SetAlpha(Graphic g, float a) { }

	private void SetBusy(bool busy) { }

	private void SetPlaceholders() { }

	private static void SetText(Text t, string s, Color c) { }

	private static void SetText(Text t, string s) { }

	private void ShowFloating(string text) { }

	private void StartGlow() { }

	private void StartPulse() { }

	private void StopPulse() { }

	private void UpdateUpgradeButton(bool owned) { }

	[IteratorStateMachine(typeof(<UpgradeCo>d__56))]
	private IEnumerator UpgradeCo() { }

	private void WireOnce() { }

}

