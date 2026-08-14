//Type is in global namespace

public class ManagerRoomPVP : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__63_1; //Field offset: 0x8
		public static Action<String> <>9__65_1; //Field offset: 0x10
		public static Predicate<CardData> <>9__83_0; //Field offset: 0x18
		public static Func<RoomSummaryDTO, Boolean> <>9__97_0; //Field offset: 0x20
		public static Func<RoomSummaryDTO, String> <>9__97_1; //Field offset: 0x28
		public static Func<KeyValuePair`2<String, WsPlayerStateDTO>, Boolean> <>9__99_0; //Field offset: 0x30
		public static Func<KeyValuePair`2<String, WsPlayerStateDTO>, Int32> <>9__99_1; //Field offset: 0x38
		public static Func<KeyValuePair`2<String, WsPlayerStateDTO>, String> <>9__99_2; //Field offset: 0x40
		public static Func<KeyValuePair`2<String, WsPlayerStateDTO>, Int32> <>9__99_3; //Field offset: 0x48
		public static Func<Int32, Boolean> <>9__99_4; //Field offset: 0x50

		private static <>c() { }

		public <>c() { }

		internal bool <DisplayCardsForSelection>b__83_0(CardData c) { }

		internal void <LoadPlayerDataWithLoading>b__63_1(string e) { }

		internal void <LoadRankPosition>b__65_1(string err) { }

		internal bool <RebuildBrowseRoomListUI>b__97_0(RoomSummaryDTO r) { }

		internal string <RebuildBrowseRoomListUI>b__97_1(RoomSummaryDTO r) { }

		internal bool <SyncLobbyPetPreviewIfMaster>b__99_0(KeyValuePair<String, WsPlayerStateDTO> kv) { }

		internal int <SyncLobbyPetPreviewIfMaster>b__99_1(KeyValuePair<String, WsPlayerStateDTO> kv) { }

		internal string <SyncLobbyPetPreviewIfMaster>b__99_2(KeyValuePair<String, WsPlayerStateDTO> kv) { }

		internal int <SyncLobbyPetPreviewIfMaster>b__99_3(KeyValuePair<String, WsPlayerStateDTO> kv) { }

		internal bool <SyncLobbyPetPreviewIfMaster>b__99_4(int id) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass63_0
	{
		public bool cacheLoaded; //Field offset: 0x10

		public <>c__DisplayClass63_0() { }

		internal void <LoadPlayerDataWithLoading>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass70_0
	{
		public bool done; //Field offset: 0x10
		public PetsPaginatedDataDTO wsData; //Field offset: 0x18

		public <>c__DisplayClass70_0() { }

		internal void <LoadPetsPage>b__0(PetsPaginatedDataDTO d) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass72_0
	{
		public ManagerRoomPVP <>4__this; //Field offset: 0x10
		public CanvasGroup cg; //Field offset: 0x18

		public <>c__DisplayClass72_0() { }

		internal void <DisplayCurrentPetPage>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass72_1
	{
		public string petIdStr; //Field offset: 0x10
		public PetUserDTO clickedPet; //Field offset: 0x18
		public <>c__DisplayClass72_0 CS$<>8__locals1; //Field offset: 0x20

		public <>c__DisplayClass72_1() { }

		internal void <DisplayCurrentPetPage>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass78_0
	{
		public ManagerRoomPVP <>4__this; //Field offset: 0x10
		public Animator animator; //Field offset: 0x18
		public int token; //Field offset: 0x20
		public RuntimeAnimatorController baseController; //Field offset: 0x28

		public <>c__DisplayClass78_0() { }

		internal void <ApplyPetAnimation>b__0(AnimationClip[] clips) { }

	}

	[CompilerGenerated]
	private sealed class <CoRefreshPlayerSlotsAfterJoin>d__91 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoomPVP <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28

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
		public <CoRefreshPlayerSlotsAfterJoin>d__91(int <>1__state) { }

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
	private sealed class <LoadPetsPage>d__70 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int page; //Field offset: 0x20
		private <>c__DisplayClass70_0 <>8__1; //Field offset: 0x28
		public ManagerRoomPVP <>4__this; //Field offset: 0x30
		private Action<PetsPaginatedDataDTO> <onResp>5__2; //Field offset: 0x38
		private float <deadline>5__3; //Field offset: 0x40

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
		public <LoadPetsPage>d__70(int <>1__state) { }

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
	private sealed class <LoadPlayerDataWithLoading>d__63 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoomPVP <>4__this; //Field offset: 0x20
		private <>c__DisplayClass63_0 <>8__1; //Field offset: 0x28
		private int <userId>5__2; //Field offset: 0x30

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
		public <LoadPlayerDataWithLoading>d__63(int <>1__state) { }

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
	private sealed class <OnStartBattle>d__104 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoomPVP <>4__this; //Field offset: 0x20

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
		public <OnStartBattle>d__104(int <>1__state) { }

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

	internal class PetPageResponse
	{
		public PetUserDTO[] content; //Field offset: 0x10
		public int totalPages; //Field offset: 0x18
		public int totalElements; //Field offset: 0x1C
		public int number; //Field offset: 0x20
		public int size; //Field offset: 0x24
		public bool first; //Field offset: 0x28
		public bool last; //Field offset: 0x29
		public int numberOfElements; //Field offset: 0x2C

		public PetPageResponse() { }

	}

	public static ManagerRoomPVP Instance; //Field offset: 0x0
	public const string LobbyWeaponRarityKey1 = "wr1"; //Field offset: 0x0
	public const string LobbyWeaponRarityKey0 = "wr0"; //Field offset: 0x0
	public const string LobbyWeaponKey1 = "w1"; //Field offset: 0x0
	private const int PETS_PER_PAGE = 3; //Field offset: 0x0
	public const string LobbyPetKey1 = "p1"; //Field offset: 0x0
	public const string LobbyPetKey0 = "p0"; //Field offset: 0x0
	public const string LobbyWeaponKey0 = "w0"; //Field offset: 0x0
	[Header("UI")]
	public GameObject loading; //Field offset: 0x20
	[Header("UI Slots - 4 người (2 phe)")]
	public RoomUIGroup_ManagerPVP uiGroupManager; //Field offset: 0x28
	[Header("Local Player Info UI")]
	public SpriteRenderer imgLocalAvatar; //Field offset: 0x30
	public Image imgLocalLevelFrame; //Field offset: 0x38
	public Text txtLocalName; //Field offset: 0x40
	public SpriteRenderer imgLocalPet; //Field offset: 0x48
	public Animator localPetAnimator; //Field offset: 0x50
	[Header("Lobby PVP Stats")]
	public Text txtLobbyRankName; //Field offset: 0x58
	public Text txtLobbyWinLoss; //Field offset: 0x60
	public Text txtLobbyWinRate; //Field offset: 0x68
	public Text txtLobbyWinStreak; //Field offset: 0x70
	public Text txtLobbyBestStreak; //Field offset: 0x78
	public Text txtLobbyRankPosition; //Field offset: 0x80
	public Image imgLobbyRankIcon; //Field offset: 0x88
	public Slider sliderLobbyRankProgress; //Field offset: 0x90
	public Text txtLobbyRankPoints; //Field offset: 0x98
	[Header("Pet Panel")]
	public GameObject panelPet; //Field offset: 0xA0
	public GameObject btnClosePet; //Field offset: 0xA8
	public GameObject petUIPrefab; //Field offset: 0xB0
	public Transform petListContainer; //Field offset: 0xB8
	public Button btnPrevPetPage; //Field offset: 0xC0
	public Button btnNextPetPage; //Field offset: 0xC8
	public Text txtPetPageInfo; //Field offset: 0xD0
	public Animator localPetAnimatorInPanel; //Field offset: 0xD8
	private bool isRotatingPet; //Field offset: 0xE0
	private int currentPetPage; //Field offset: 0xE4
	private PetPageResponse currentPetPageData; //Field offset: 0xE8
	private PetUserDTO _selectedPetData; //Field offset: 0xF0
	[Header("Card Selection")]
	public GameObject panelCard; //Field offset: 0xF8
	public GameObject btnCloseCard; //Field offset: 0x100
	public ToggleManagerPVP toggleManager; //Field offset: 0x108
	private bool isRotatingCard; //Field offset: 0x110
	public float rotationSpeed; //Field offset: 0x114
	[Header("Energy Warning")]
	public GameObject energyWarningPanel; //Field offset: 0x118
	public Text energyWarningText; //Field offset: 0x120
	public Button energyWarningOkButton; //Field offset: 0x128
	[Header("Browse room list (ListRoom / listPanel / room template)")]
	[Tooltip("Ẩn khi đã vào phòng; hiện khi ở sảnh PVP.")]
	public GameObject listRoomRoot; //Field offset: 0x130
	public Transform listPanel; //Field offset: 0x138
	[Tooltip("Object mẫu 'room' (để inactive), sẽ Instantiate khi vẽ list.")]
	public GameObject roomRowTemplate; //Field offset: 0x140
	[SerializeField]
	[Tooltip("Số người tối thiểu coi là đầy → nút Đã đầy (mặc 2).")]
	private int browseRoomFullPlayerCount; //Field offset: 0x148
	private bool _wsListSubscribed; //Field offset: 0x14C
	private Coroutine _refreshSlotsAfterJoinCo; //Field offset: 0x150
	internal UserDTO currentUser; //Field offset: 0x158
	internal RoomDTO roomData; //Field offset: 0x160
	internal List<CardData> selectedCards; //Field offset: 0x168
	internal int currentUserEnergy; //Field offset: 0x170
	private Coroutine _loadCoroutine; //Field offset: 0x178
	private readonly Dictionary<Animator, RuntimeAnimatorController> _previewBaseControllers; //Field offset: 0x180
	private readonly Dictionary<Animator, Int32> _previewAnimToken; //Field offset: 0x188
	private bool _pendingSelectionRestore; //Field offset: 0x190

	public ManagerRoomPVP() { }

	[CompilerGenerated]
	private void <HideCardPanel>b__82_0() { }

	[CompilerGenerated]
	private void <HideEnergyWarning>b__103_0() { }

	[CompilerGenerated]
	private void <HidePetPanel>b__68_0() { }

	[CompilerGenerated]
	private void <LoadRankPosition>b__65_0(PvpProfileDTO data) { }

	private void ApplyPetAnimation(Animator animator, int petId) { }

	private void Awake() { }

	private void CacheSelectedPetFromPage() { }

	public void CancelRefreshPlayerSlotsAfterJoin() { }

	[IteratorStateMachine(typeof(<CoRefreshPlayerSlotsAfterJoin>d__91))]
	private IEnumerator CoRefreshPlayerSlotsAfterJoin() { }

	private GameObject CreateCardToggle(CardData card, int index) { }

	public void DisplayCardsForSelection(List<CardData> cards) { }

	private void DisplayCurrentPetPage() { }

	public void DisplayLocalPlayerInfo(UserDTO user) { }

	private void EnsureWsRoomListSubscription() { }

	private bool GetLocalWsReady() { }

	private void HandleWsRoomListChanged() { }

	public void HideCardPanel() { }

	private void HideEnergyWarning() { }

	public void HidePetPanel() { }

	public void HideRoomPVP() { }

	[IteratorStateMachine(typeof(<LoadPetsPage>d__70))]
	private IEnumerator LoadPetsPage(int userId, int page) { }

	[IteratorStateMachine(typeof(<LoadPlayerDataWithLoading>d__63))]
	public IEnumerator LoadPlayerDataWithLoading() { }

	private void LoadRankPosition(int userId) { }

	private void OnBrowseJoinClicked(string roomId) { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnPetClicked(string petIdStr, PetUserDTO petData = null) { }

	public void OnPVPRoomConnectionChanged(bool inRoom, bool pendingJoinAnotherRoom = false) { }

	[IteratorStateMachine(typeof(<OnStartBattle>d__104))]
	public IEnumerator OnStartBattle() { }

	public void OpenRoomPVP() { }

	private void RebuildBrowseRoomListUI() { }

	private static int SafeToInt(object v) { }

	private void SaveSelectedCardsToPrefs() { }

	public void ScheduleRefreshPlayerSlotsAfterJoin() { }

	private void SetupCardSelection() { }

	private void SetupPetPagination() { }

	private void SetupToggle(GameObject obj, CardData card) { }

	public void ShowCardPanel() { }

	public void ShowEnergyWarning() { }

	private void ShowNextPetPage() { }

	public void ShowPetPanel() { }

	private void ShowPreviousPetPage() { }

	private void Start() { }

	public void StartBattleSequence() { }

	private void SyncLobbyPetPreviewIfMaster() { }

	private void TeardownWsRoomListSubscription() { }

	internal void TryRestoreSelectedCards() { }

	private void Update() { }

	private void UpdateLobbyPvpStats(UserDTO user) { }

	private void UpdatePetPaginationButtons() { }

	public void UpdatePlayerSlots() { }

}

