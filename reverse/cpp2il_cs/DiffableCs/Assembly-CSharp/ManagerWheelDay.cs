//Type is in global namespace

public class ManagerWheelDay : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__59_1; //Field offset: 0x8
		public static Action<String> <>9__75_1; //Field offset: 0x10
		public static Action<String> <>9__76_1; //Field offset: 0x18
		public static UnityAction <>9__83_0; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal void <CallSpinFreeServerAPI>b__75_1(string error) { }

		internal void <CallSpinGoldServerAPI>b__76_1(string error) { }

		internal void <LoadWheelDataCoroutine>b__59_1(string error) { }

		internal void <SpinWheelToIndexCoroutine>b__83_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass59_0
	{
		public WheelConfigDTO configData; //Field offset: 0x10

		public <>c__DisplayClass59_0() { }

		internal void <LoadWheelDataCoroutine>b__0(WheelConfigDTO config) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass69_0
	{
		public SpinResultDTO spinResult; //Field offset: 0x10

		public <>c__DisplayClass69_0() { }

		internal void <CheckAndSpinFreeMany>b__0(SpinResultDTO result) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass70_0
	{
		public SpinResultDTO spinResult; //Field offset: 0x10

		public <>c__DisplayClass70_0() { }

		internal void <CheckAndSpinFree>b__0(SpinResultDTO result) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass74_0
	{
		public SpinResultDTO spinResult; //Field offset: 0x10

		public <>c__DisplayClass74_0() { }

		internal void <CheckAndSpinGold>b__0(SpinResultDTO result) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass75_0
	{
		public SpinResultDTO result; //Field offset: 0x10

		public <>c__DisplayClass75_0() { }

		internal void <CallSpinFreeServerAPI>b__0(SpinResultDTO response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass76_0
	{
		public SpinResultDTO result; //Field offset: 0x10

		public <>c__DisplayClass76_0() { }

		internal void <CallSpinGoldServerAPI>b__0(SpinResultDTO response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass83_0
	{
		public bool spinCompleted; //Field offset: 0x10

		public <>c__DisplayClass83_0() { }

		internal void <SpinWheelToIndexCoroutine>b__1(WheelPiece piece) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass90_0
	{
		public Transform t; //Field offset: 0x10
		public Vector3 basePos; //Field offset: 0x18
		public ManagerWheelDay <>4__this; //Field offset: 0x28

		public <>c__DisplayClass90_0() { }

		internal void <ShakePanel>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <CallSpinFreeServerAPI>d__75 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int userId; //Field offset: 0x20
		public Action<SpinResultDTO> callback; //Field offset: 0x28
		private <>c__DisplayClass75_0 <>8__1; //Field offset: 0x30

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
		public <CallSpinFreeServerAPI>d__75(int <>1__state) { }

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
	private sealed class <CallSpinGoldServerAPI>d__76 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int userId; //Field offset: 0x20
		public Action<SpinResultDTO> callback; //Field offset: 0x28
		private <>c__DisplayClass76_0 <>8__1; //Field offset: 0x30

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
		public <CallSpinGoldServerAPI>d__76(int <>1__state) { }

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
	private sealed class <CheckAndSpinFree>d__70 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerWheelDay <>4__this; //Field offset: 0x20
		public int userId; //Field offset: 0x28
		private <>c__DisplayClass70_0 <>8__1; //Field offset: 0x30
		private SpinRewardDTO <reward>5__2; //Field offset: 0x38

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
		public <CheckAndSpinFree>d__70(int <>1__state) { }

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
	private sealed class <CheckAndSpinFreeMany>d__69 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerWheelDay <>4__this; //Field offset: 0x20
		public int userId; //Field offset: 0x28
		private <>c__DisplayClass69_0 <>8__1; //Field offset: 0x30
		private SpinRewardDTO <reward>5__2; //Field offset: 0x38

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
		public <CheckAndSpinFreeMany>d__69(int <>1__state) { }

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
	private sealed class <CheckAndSpinGold>d__74 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerWheelDay <>4__this; //Field offset: 0x20
		public int userId; //Field offset: 0x28
		private <>c__DisplayClass74_0 <>8__1; //Field offset: 0x30
		private SpinRewardDTO <reward>5__2; //Field offset: 0x38

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
		public <CheckAndSpinGold>d__74(int <>1__state) { }

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
	private sealed class <LoadWheelDataCoroutine>d__59 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int userId; //Field offset: 0x20
		private <>c__DisplayClass59_0 <>8__1; //Field offset: 0x28
		public ManagerWheelDay <>4__this; //Field offset: 0x30

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
		public <LoadWheelDataCoroutine>d__59(int <>1__state) { }

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
	private sealed class <SpinWheelToIndexCoroutine>d__83 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerWheelDay <>4__this; //Field offset: 0x20
		public int targetIndex; //Field offset: 0x28
		private <>c__DisplayClass83_0 <>8__1; //Field offset: 0x30

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
		public <SpinWheelToIndexCoroutine>d__83(int <>1__state) { }

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

	public const string PANEL_KEY = "PanelWheelDay"; //Field offset: 0x0
	public static ManagerWheelDay Instance; //Field offset: 0x0
	private static Sprite _weaponPieceSprite; //Field offset: 0x8
	private static bool _weaponPieceLoaded; //Field offset: 0x10
	[Header("Panel References")]
	public GameObject panelWheelDay; //Field offset: 0x20
	public GameObject panelNoticeResult; //Field offset: 0x28
	public Button btnBack; //Field offset: 0x30
	[Header("Picker Wheel Reference")]
	public PickerWheel pickerWheel; //Field offset: 0x38
	[Header("Buttons")]
	public Button btnRun; //Field offset: 0x40
	public Button btnRunMany; //Field offset: 0x48
	public Text txtBtnRun; //Field offset: 0x50
	public Text txtBtnRunMany; //Field offset: 0x58
	public Text txtCountWheel; //Field offset: 0x60
	[Header("Reward Display - Trong boardReward")]
	public Transform listPanel; //Field offset: 0x68
	[Header("Notice Result")]
	public Transform listReward; //Field offset: 0x70
	public Button btnGet; //Field offset: 0x78
	public Text txtMessage; //Field offset: 0x80
	[Header("Reward Prefabs")]
	public GameObject rewardPetPrefab; //Field offset: 0x88
	public GameObject rewardAvatarPrefab; //Field offset: 0x90
	public GameObject rewardGoldPrefab; //Field offset: 0x98
	public GameObject rewardRubyPrefab; //Field offset: 0xA0
	public GameObject rewardEnergyPrefab; //Field offset: 0xA8
	public GameObject rewardStonePrefab; //Field offset: 0xB0
	[Header("Reward Prefabs — loại quà mới (để trống sẽ tự mượn prefab Pet)")]
	public GameObject rewardShardPrefab; //Field offset: 0xB8
	public GameObject rewardWeaponPrefab; //Field offset: 0xC0
	public GameObject rewardWeaponPiecePrefab; //Field offset: 0xC8
	[Header("FX kết quả (tuỳ chọn — để trống là bỏ qua, không lỗi)")]
	public Image imgResultGlow; //Field offset: 0xD0
	public RectTransform pointerTransform; //Field offset: 0xD8
	public AudioSource fxAudioSource; //Field offset: 0xE0
	public AudioClip sfxWinCommon; //Field offset: 0xE8
	public AudioClip sfxWinRare; //Field offset: 0xF0
	[Header("Stone Sprites - 5 Hệ, mỗi hệ 7 Level")]
	public Sprite[] stoneFire; //Field offset: 0xF8
	public Sprite[] stoneWater; //Field offset: 0x100
	public Sprite[] stoneWood; //Field offset: 0x108
	public Sprite[] stoneEarth; //Field offset: 0x110
	public Sprite[] stoneMetal; //Field offset: 0x118
	[Header("Default Icons")]
	public Sprite iconGold; //Field offset: 0x120
	public Sprite iconRuby; //Field offset: 0x128
	public Sprite iconEnergy; //Field offset: 0x130
	[Header("Settings")]
	public int spinCost; //Field offset: 0x138
	public int duplicateCompensation; //Field offset: 0x13C
	private WheelConfigDTO wheelConfig; //Field offset: 0x140
	private List<SpinRewardDTO> currentRewards; //Field offset: 0x148
	private readonly List<WeaponDropDTO> pendingWeaponDrops; //Field offset: 0x150
	private bool isSpinning; //Field offset: 0x158
	private bool shouldStopMultiSpin; //Field offset: 0x159
	private int currentSpinCount; //Field offset: 0x15C
	private int targetSpinCount; //Field offset: 0x160
	private int currentUserGold; //Field offset: 0x164
	private int currentFreeSpins; //Field offset: 0x168
	[Header("Notice Confirm")]
	public GameObject panelNoticeConfirm; //Field offset: 0x170
	public Text txtConfirmMessage; //Field offset: 0x178
	public Button btnConfirmYes; //Field offset: 0x180
	public Button btnConfirmNo; //Field offset: 0x188
	private int pendingSpinCount; //Field offset: 0x190
	private int _shakeTweenId; //Field offset: 0x194

	public ManagerWheelDay() { }

	[CompilerGenerated]
	private void <CloseConfirmPanel>b__81_0() { }

	[CompilerGenerated]
	private void <CloseNoticeResult>b__102_0() { }

	[CompilerGenerated]
	private void <ClosePanel>b__105_0() { }

	[CompilerGenerated]
	private void <InitializeButtons>b__55_0() { }

	[CompilerGenerated]
	private void <ShowPanelWithAnimation>b__60_0() { }

	private void AddRewardToListPanel(SpinRewardDTO reward) { }

	private void AddRewardToNoticeResult(SpinRewardDTO reward) { }

	private void ApplyRewardVisual(GameObject rewardObj, SpinRewardDTO reward) { }

	private void Awake() { }

	private string BuildRewardCountLabel(SpinRewardDTO reward) { }

	private SpinRewardDTO BuildRewardFromServerResult(SpinResultDTO spinResult) { }

	[IteratorStateMachine(typeof(<CallSpinFreeServerAPI>d__75))]
	private IEnumerator CallSpinFreeServerAPI(int userId, Action<SpinResultDTO> callback) { }

	[IteratorStateMachine(typeof(<CallSpinGoldServerAPI>d__76))]
	private IEnumerator CallSpinGoldServerAPI(int userId, Action<SpinResultDTO> callback) { }

	[IteratorStateMachine(typeof(<CheckAndSpinFree>d__70))]
	private IEnumerator CheckAndSpinFree(int userId) { }

	[IteratorStateMachine(typeof(<CheckAndSpinFreeMany>d__69))]
	private IEnumerator CheckAndSpinFreeMany(int userId) { }

	[IteratorStateMachine(typeof(<CheckAndSpinGold>d__74))]
	private IEnumerator CheckAndSpinGold(int userId) { }

	private void ClearAllUI() { }

	private void ClearListPanel() { }

	private void ClearListReward() { }

	private void CloseConfirmPanel() { }

	private void CloseNoticeResult() { }

	public void ClosePanel() { }

	private int FindWeaponImageId(int slotIndex) { }

	private void FlushWeaponDropPopups() { }

	public static string FormatVND(long amount) { }

	private Sprite GetPrizeSprite(WheelPrizeDTO prize) { }

	private GameObject GetRewardPrefab(string prizeType) { }

	private Sprite GetRewardSprite(SpinRewardDTO reward) { }

	private Sprite GetStoneSprite(string elementType, int level) { }

	private Sprite GetWeaponPieceSprite() { }

	private void InitializeButtons() { }

	private bool IsRareResult(SpinRewardDTO reward) { }

	private static bool IsShardType(string prizeType) { }

	[IteratorStateMachine(typeof(<LoadWheelDataCoroutine>d__59))]
	private IEnumerator LoadWheelDataCoroutine(int userId) { }

	private void OnBtnRunManyClicked() { }

	private void OnConfirmNo() { }

	private void OnConfirmYes() { }

	public void OpenWheelPanel() { }

	private void PlayPointerTick() { }

	private void PlayResultFx(SpinRewardDTO reward) { }

	private void SetButtonsInteractable(bool interactable) { }

	private void SetupWheelPieces() { }

	private void ShakePanel() { }

	private void ShowConfirmSpin(int spinCount) { }

	private void ShowErrorMessage(string message) { }

	private void ShowNeedGoldMessage(int spinCount) { }

	private void ShowNotEnoughResourceMessage() { }

	private void ShowNoticeResult() { }

	private void ShowPanelWithAnimation() { }

	[IteratorStateMachine(typeof(<SpinWheelToIndexCoroutine>d__83))]
	private IEnumerator SpinWheelToIndexCoroutine(int targetIndex) { }

	private void Start() { }

	private void StartResultGlow(string rarity) { }

	private void StartSpin(int count) { }

	private void StopResultGlow() { }

	private void UpdateButtonsState() { }

}

