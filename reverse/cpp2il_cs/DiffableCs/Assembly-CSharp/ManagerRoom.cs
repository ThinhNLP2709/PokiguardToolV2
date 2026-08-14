//Type is in global namespace

public class ManagerRoom : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__65_1; //Field offset: 0x8
		public static Func<CardData, Int32> <>9__73_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <LoadRoomDataWithoutLoading>b__65_1(string e) { }

		internal int <UpdateLocalSelectedCards>b__73_0(CardData c) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass108_0
	{
		public bool preloadDone; //Field offset: 0x10

		public <>c__DisplayClass108_0() { }

		internal void <DelayedLoadScene>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass110_0
	{
		public bool failed; //Field offset: 0x10
		public PetUserDTO myPet; //Field offset: 0x18
		public PetUserDTO enemyPet; //Field offset: 0x20
		public UserDTO user; //Field offset: 0x28

		public <>c__DisplayClass110_0() { }

		internal void <PreloadMatchData>b__0(MatchPrepDataDTO data) { }

		internal void <PreloadMatchData>b__1(string err) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass64_0
	{
		public bool cacheStarted; //Field offset: 0x10
		public ManagerRoom <>4__this; //Field offset: 0x18
		public int selectedPetId; //Field offset: 0x20
		public bool cacheLoaded; //Field offset: 0x24
		public bool cacheDone; //Field offset: 0x25
		public float loadStart; //Field offset: 0x28
		public bool isJoiningInvite; //Field offset: 0x2C
		public bool wsEnterFailed; //Field offset: 0x2D
		public string wsEnterFailReason; //Field offset: 0x30
		public bool wsEntered; //Field offset: 0x38
		public Action <>9__3; //Field offset: 0x40
		public Action<String> <>9__4; //Field offset: 0x48

		public <>c__DisplayClass64_0() { }

		internal void <LoadRoomDataWithLoading>b__0() { }

		internal void <LoadRoomDataWithLoading>b__1(string r) { }

		internal void <LoadRoomDataWithLoading>b__2(string _) { }

		internal void <LoadRoomDataWithLoading>b__3() { }

		internal void <LoadRoomDataWithLoading>b__4(string e) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass65_0
	{
		public bool cacheLoaded; //Field offset: 0x10

		public <>c__DisplayClass65_0() { }

		internal void <LoadRoomDataWithoutLoading>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass75_0
	{
		public bool done; //Field offset: 0x10
		public PetsPaginatedDataDTO wsData; //Field offset: 0x18

		public <>c__DisplayClass75_0() { }

		internal void <LoadPetsPage>b__0(PetsPaginatedDataDTO d) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass79_0
	{
		public string petID; //Field offset: 0x10
		public ManagerRoom <>4__this; //Field offset: 0x18

		public <>c__DisplayClass79_0() { }

		internal void <DisplayCurrentPetPageCoroutine>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass83_0
	{
		public Button button; //Field offset: 0x10

		public <>c__DisplayClass83_0() { }

		internal void <AnimateButton>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass92_0
	{
		public int token; //Field offset: 0x10
		public ManagerRoom <>4__this; //Field offset: 0x18
		public int petId; //Field offset: 0x20

		public <>c__DisplayClass92_0() { }

		internal void <ApplyMyPetAnimation>b__0(AnimationClip[] clips) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass99_0
	{
		public int token; //Field offset: 0x10
		public ManagerRoom <>4__this; //Field offset: 0x18
		public string petId; //Field offset: 0x20

		public <>c__DisplayClass99_0() { }

		internal void <ApplyEnemyPetAnimation>b__0(AnimationClip[] clips) { }

	}

	[CompilerGenerated]
	private sealed class <DelayedLoadScene>d__108 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		private <>c__DisplayClass108_0 <>8__1; //Field offset: 0x28
		public ManagerRoom <>4__this; //Field offset: 0x30
		public string sceneName; //Field offset: 0x38
		private float <preloadStart>5__2; //Field offset: 0x40

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
		public <DelayedLoadScene>d__108(int <>1__state) { }

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
	private sealed class <DisplayCurrentPetPageCoroutine>d__79 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoom <>4__this; //Field offset: 0x20
		private int <listSelUserPetId>5__2; //Field offset: 0x28
		private PetUserDTO[] <pets>5__3; //Field offset: 0x30
		private int <i>5__4; //Field offset: 0x38

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
		public <DisplayCurrentPetPageCoroutine>d__79(int <>1__state) { }

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
	private sealed class <EnsureWsThenOpenRoom>d__54 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoom <>4__this; //Field offset: 0x20
		public bool isLocal; //Field offset: 0x28
		public string roomName; //Field offset: 0x30
		private ChatService <chat>5__2; //Field offset: 0x38
		private float <waited>5__3; //Field offset: 0x40

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
		public <EnsureWsThenOpenRoom>d__54(int <>1__state) { }

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
	private sealed class <FadeTransition>d__69 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoom <>4__this; //Field offset: 0x20

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
		public <FadeTransition>d__69(int <>1__state) { }

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
	private sealed class <LoadPetsPage>d__75 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int page; //Field offset: 0x20
		private <>c__DisplayClass75_0 <>8__1; //Field offset: 0x28
		public ManagerRoom <>4__this; //Field offset: 0x30
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
		public <LoadPetsPage>d__75(int <>1__state) { }

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
	private sealed class <LoadRoomDataWithLoading>d__64 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoom <>4__this; //Field offset: 0x20
		private <>c__DisplayClass64_0 <>8__1; //Field offset: 0x28
		private int <userId>5__2; //Field offset: 0x30
		private Action <startCacheLoad>5__3; //Field offset: 0x38
		private float <joinWaitStart>5__4; //Field offset: 0x40
		private WsRoomService <wsRoomWait>5__5; //Field offset: 0x48
		private Action<String> <onWsEnterFailed>5__6; //Field offset: 0x50
		private Action<String> <onWsEntered>5__7; //Field offset: 0x58

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
		public <LoadRoomDataWithLoading>d__64(int <>1__state) { }

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
	private sealed class <LoadRoomDataWithoutLoading>d__65 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private <>c__DisplayClass65_0 <>8__1; //Field offset: 0x20
		public ManagerRoom <>4__this; //Field offset: 0x28
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
		public <LoadRoomDataWithoutLoading>d__65(int <>1__state) { }

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
	private sealed class <OnStartBattle>d__105 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoom <>4__this; //Field offset: 0x20

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
		public <OnStartBattle>d__105(int <>1__state) { }

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
	private sealed class <PreloadMatchData>d__110 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoom <>4__this; //Field offset: 0x20
		private <>c__DisplayClass110_0 <>8__1; //Field offset: 0x28

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
		public <PreloadMatchData>d__110(int <>1__state) { }

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
	private sealed class <RunPreloadThenFlag>d__109 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoom <>4__this; //Field offset: 0x20
		public Action onDone; //Field offset: 0x28

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
		public <RunPreloadThenFlag>d__109(int <>1__state) { }

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
	private sealed class <UpdatePlayerSlotsDebounced>d__88 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoom <>4__this; //Field offset: 0x20

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
		public <UpdatePlayerSlotsDebounced>d__88(int <>1__state) { }

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

	private const int PETS_PER_PAGE = 18; //Field offset: 0x0
	internal static ManagerRoom Instance; //Field offset: 0x0
	public GameObject roomPanel; //Field offset: 0x20
	public Button ButtonStart; //Field offset: 0x28
	public GameObject loading; //Field offset: 0x30
	public GameObject panelPet; //Field offset: 0x38
	public GameObject panelCard; //Field offset: 0x40
	public GameObject btnClosePet; //Field offset: 0x48
	public GameObject btnCloseCard; //Field offset: 0x50
	public Button btnBackToChinhPhuc; //Field offset: 0x58
	[Header("UI Slots - 3 người chơi")]
	public RoomUIGroup_Manager uiGroupManager; //Field offset: 0x60
	private bool isRotatingPet; //Field offset: 0x68
	private bool isRotatingCard; //Field offset: 0x69
	public float rotationSpeed; //Field offset: 0x6C
	public Animator animator; //Field offset: 0x70
	public Animator enemyPet; //Field offset: 0x78
	public Image imgEnemyPet; //Field offset: 0x80
	public Text txtNamePetEnemy; //Field offset: 0x88
	public GameObject petUIPrefab; //Field offset: 0x90
	public Transform petListContainer; //Field offset: 0x98
	public Button btnPrevPetPage; //Field offset: 0xA0
	public Button btnNextPetPage; //Field offset: 0xA8
	public Text txtPetPageInfo; //Field offset: 0xB0
	private PlayerUISlot myLocalPlayerUISlot; //Field offset: 0xB8
	private int currentPetPage; //Field offset: 0xC0
	private PetPageResponse currentPetPageData; //Field offset: 0xC8
	public GameObject panelSelectCards; //Field offset: 0xD0
	public ToggleManager toggleManager; //Field offset: 0xD8
	public GameObject energyWarningPanel; //Field offset: 0xE0
	public Text energyWarningText; //Field offset: 0xE8
	public Button energyWarningOkButton; //Field offset: 0xF0
	internal int currentUserEnergy; //Field offset: 0xF8
	internal RoomDTO roomData; //Field offset: 0x100
	public List<CardData> selectedCards; //Field offset: 0x108
	public GameObject fadeOverlay; //Field offset: 0x110
	internal UserDTO currentUser; //Field offset: 0x118
	internal int myLocalSlotIndex; //Field offset: 0x120
	private bool _pendingSelectionRestore; //Field offset: 0x124
	[CompilerGenerated]
	private bool <IsOpeningRoomFlow>k__BackingField; //Field offset: 0x125
	private Int32[] _lastSyncedCardIds; //Field offset: 0x128
	private Coroutine _displayPetPageCoroutine; //Field offset: 0x130
	private bool _updatePlayerSlotsPending; //Field offset: 0x138
	private int _myPetAnimToken; //Field offset: 0x13C
	private int _enemyPetAnimToken; //Field offset: 0x140

	public private bool IsOpeningRoomFlow
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public ManagerRoom() { }

	[CompilerGenerated]
	private void <ShowEnergyWarning>b__112_0() { }

	private void AnimateButton(Button button) { }

	private void ApplyEnemyPetAnimation(string petId) { }

	private void ApplyMyPetAnimation(int petId) { }

	internal void ApplyWsEnemyPetFromProperties() { }

	private static bool ArrayEqualsOrdered(Int32[] a, Int32[] b) { }

	public void BeginMatchSceneLoad() { }

	private Dictionary<String, Object> BuildInitialBossProps() { }

	public void ClearCardSyncCache() { }

	public void ClearSelectedCardsState() { }

	public void CloseRoomPanel() { }

	private GameObject CreateCardToggle(CardData card, int index) { }

	private GameObject CreateToggleDynamic(CardData card, int index) { }

	[IteratorStateMachine(typeof(<DelayedLoadScene>d__108))]
	private IEnumerator DelayedLoadScene(string sceneName, float delay) { }

	internal void DisplayCardsForSelection(List<CardData> cards) { }

	private void DisplayCurrentPetPage() { }

	[IteratorStateMachine(typeof(<DisplayCurrentPetPageCoroutine>d__79))]
	private IEnumerator DisplayCurrentPetPageCoroutine() { }

	[IteratorStateMachine(typeof(<EnsureWsThenOpenRoom>d__54))]
	private IEnumerator EnsureWsThenOpenRoom(bool isLocal, string roomName) { }

	[IteratorStateMachine(typeof(<FadeTransition>d__69))]
	private IEnumerator FadeTransition() { }

	private static string FormatEnemyPetRoomLabel(RoomDTO room) { }

	[CompilerGenerated]
	public bool get_IsOpeningRoomFlow() { }

	private void HandleCardSelectionChanged() { }

	private void HandleUserEnergyDelta(ChatMessageDTO msg) { }

	public void HideCardPanel() { }

	private void HideEnergyWarning() { }

	public void HideLoadingFromMatch() { }

	private void HideLoadingInstant() { }

	public void HidePetPanel() { }

	[IteratorStateMachine(typeof(<LoadPetsPage>d__75))]
	private IEnumerator LoadPetsPage(int userId, int page) { }

	[IteratorStateMachine(typeof(<LoadRoomDataWithLoading>d__64))]
	public IEnumerator LoadRoomDataWithLoading() { }

	[IteratorStateMachine(typeof(<LoadRoomDataWithoutLoading>d__65))]
	public IEnumerator LoadRoomDataWithoutLoading() { }

	public void LoadScene(string nameScene) { }

	private void OnDestroy() { }

	public void OnEnemyPet(string petId) { }

	private void OnError(string error) { }

	private void OnPetClicked(string petIdStr) { }

	private void OnPetClickedInternal(string petIdStr, bool loadAnimation) { }

	internal void OnRoomReceived(RoomDTO room) { }

	[IteratorStateMachine(typeof(<OnStartBattle>d__105))]
	public IEnumerator OnStartBattle() { }

	internal void OnUserReceived(UserDTO user) { }

	public void OpenRoomPanel(bool isLocal, string roomName) { }

	[IteratorStateMachine(typeof(<PreloadMatchData>d__110))]
	private IEnumerator PreloadMatchData() { }

	private static void PrewarmTeammatePets(int myPetId) { }

	private static List<Int32> ReadSavedCardIds() { }

	public void RefreshPetList() { }

	private void RefreshPetListSelectionHighlight() { }

	private void ReplaceAnimations(AnimationClip[] newClips, string petId) { }

	private void ReplaceAnimationsEnemyPet(AnimationClip[] newClips, string petId) { }

	public void RequestUpdatePlayerSlots() { }

	public void ResetRoomHardState() { }

	private static int ResolveEnemyPetDisplayLevel(RoomDTO room) { }

	[IteratorStateMachine(typeof(<RunPreloadThenFlag>d__109))]
	private IEnumerator RunPreloadThenFlag(Action onDone) { }

	internal void SaveSelectedCardsToPrefs() { }

	[CompilerGenerated]
	private void set_IsOpeningRoomFlow(bool value) { }

	public void SetEnemyPetFromProps(int enemyPetId, string enemyPetName, int enemyPetLevel = 0) { }

	private static void SetPetRowHighlight(GameObject petRow, bool selected) { }

	private void SetupCardSelection() { }

	private void SetupPetPagination() { }

	private void SetupToggle(GameObject toggleObj, CardData card) { }

	public void ShowCardPanel() { }

	public void ShowEnergyWarning() { }

	public void ShowLoadingImmediate() { }

	private void ShowLoadingInstant() { }

	private void ShowNextPetPage() { }

	public void ShowPetPanel() { }

	private void ShowPreviousPetPage() { }

	private void ShowRoomPanelInstant() { }

	private void Start() { }

	public void StartBattleSequence() { }

	private void TryRestoreSelectedCards(bool syncAfter) { }

	private void Update() { }

	public void UpdateLocalSelectedCards() { }

	private void UpdatePetPaginationButtons() { }

	public void UpdatePlayerSlots(int mySlotIndex = -1) { }

	[IteratorStateMachine(typeof(<UpdatePlayerSlotsDebounced>d__88))]
	private IEnumerator UpdatePlayerSlotsDebounced() { }

}

