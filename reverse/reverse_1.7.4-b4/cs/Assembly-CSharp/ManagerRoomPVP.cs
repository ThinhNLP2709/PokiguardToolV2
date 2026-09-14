/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ManagerRoomPVP : MonoBehaviour, IHubSuspendable // TypeDefIndex: 211
{
	// Fields
	public static ManagerRoomPVP Instance; // 0x00
	public const string LobbyPetKey0 = "p0"; // Metadata: 0x005EED39
	public const string LobbyPetKey1 = "p1"; // Metadata: 0x005EED3C
	public const string LobbyWeaponKey0 = "w0"; // Metadata: 0x005EED3F
	public const string LobbyWeaponKey1 = "w1"; // Metadata: 0x005EED42
	public const string LobbyWeaponRarityKey0 = "wr0"; // Metadata: 0x005EED45
	public const string LobbyWeaponRarityKey1 = "wr1"; // Metadata: 0x005EED49
	[Header("UI")]
	public GameObject loading; // 0x20
	[Header("UI Slots - 4 ng\u01B0\u1EDDi (2 phe)")]
	public RoomUIGroup_ManagerPVP uiGroupManager; // 0x28
	[Header("Local Player Info UI")]
	public SpriteRenderer imgLocalAvatar; // 0x30
	public Image imgLocalLevelFrame; // 0x38
	public UnityEngine.UI.Text txtLocalName; // 0x40
	public SpriteRenderer imgLocalPet; // 0x48
	public Animator localPetAnimator; // 0x50
	[Header("Lobby PVP Stats")]
	public UnityEngine.UI.Text txtLobbyRankName; // 0x58
	public UnityEngine.UI.Text txtLobbyWinLoss; // 0x60
	public UnityEngine.UI.Text txtLobbyWinRate; // 0x68
	public UnityEngine.UI.Text txtLobbyWinStreak; // 0x70
	public UnityEngine.UI.Text txtLobbyBestStreak; // 0x78
	public UnityEngine.UI.Text txtLobbyRankPosition; // 0x80
	public Image imgLobbyRankIcon; // 0x88
	public Slider sliderLobbyRankProgress; // 0x90
	public UnityEngine.UI.Text txtLobbyRankPoints; // 0x98
	[Header("Pet Panel")]
	public GameObject panelPet; // 0xA0
	public GameObject btnClosePet; // 0xA8
	public GameObject petUIPrefab; // 0xB0
	public Transform petListContainer; // 0xB8
	public Button btnPrevPetPage; // 0xC0
	public Button btnNextPetPage; // 0xC8
	public UnityEngine.UI.Text txtPetPageInfo; // 0xD0
	public Animator localPetAnimatorInPanel; // 0xD8
	private bool isRotatingPet; // 0xE0
	private int currentPetPage; // 0xE4
	private const int PETS_PER_PAGE = 8; // Metadata: 0x005EED4D
	private float _petPanelScale; // 0xE8
	private PetPageResponse currentPetPageData; // 0xF0
	private PetUserDTO _selectedPetData; // 0xF8
	[Header("Card Selection")]
	public GameObject panelCard; // 0x100
	public GameObject btnCloseCard; // 0x108
	public ToggleManagerPVP toggleManager; // 0x110
	private bool isRotatingCard; // 0x118
	public float rotationSpeed; // 0x11C
	[Header("Energy Warning")]
	public GameObject energyWarningPanel; // 0x120
	public UnityEngine.UI.Text energyWarningText; // 0x128
	public Button energyWarningOkButton; // 0x130
	[Header("Browse room list (ListRoom / listPanel / room template)")]
	[Tooltip("\u1EA8n khi \u0111\u00E3 v\u00E0o ph\u00F2ng; hi\u1EC7n khi \u1EDF s\u1EA3nh PVP.")]
	public GameObject listRoomRoot; // 0x138
	public Transform listPanel; // 0x140
	[Tooltip("Object m\u1EABu \'room\' (\u0111\u1EC3 inactive), s\u1EBD Instantiate khi v\u1EBD list.")]
	public GameObject roomRowTemplate; // 0x148
	[SerializeField]
	[Tooltip("S\u1ED1 ng\u01B0\u1EDDi t\u1ED1i thi\u1EC3u coi l\u00E0 \u0111\u1EA7y \u2192 n\u00FAt \u0110\u00E3 \u0111\u1EA7y (m\u1EB7c 2).")]
	private int browseRoomFullPlayerCount; // 0x150
	private bool _wsListSubscribed; // 0x154
	private Coroutine _refreshSlotsAfterJoinCo; // 0x158
	internal UserDTO currentUser; // 0x160
	internal RoomDTO roomData; // 0x168
	internal List<CardData> selectedCards; // 0x170
	internal int currentUserEnergy; // 0x178
	private Coroutine _loadCoroutine; // 0x180
	private static readonly bool LobbyButtonsEnabled; // 0x08
	private bool _lobbyButtonsWired; // 0x188
	private const float PET_ARROW_ROOM = 58f; // Metadata: 0x005EED4E
	private const float PET_ARROW_GAP = 30f; // Metadata: 0x005EED52
	private const float PET_PANEL_MAX_SCALE = 1f; // Metadata: 0x005EED56
	private int _petsPageInFlight; // 0x18C
	private Action<PetsPaginatedDataDTO> _petsRespHandler; // 0x190
	private int _petsReqToken; // 0x198
	private readonly Dictionary<Animator, RuntimeAnimatorController> _previewBaseControllers; // 0x1A0
	private readonly Dictionary<Animator, int> _previewAnimToken; // 0x1A8
	public const bool CARD_SELECTION_ENABLED = false; // Metadata: 0x005EED5A
	private bool _pendingSelectionRestore; // 0x1B0
	private bool _slotsRefreshPending; // 0x1B1
	private string _lastSlotsSig; // 0x1B8
	private readonly List<PVPBrowseRoomRowUI> _browseRows; // 0x1C0
	private bool _browsePoolInitialized; // 0x1C8
	private string _lastBrowseSig; // 0x1D0

	// Nested types
	[Serializable]
	public class PetPageResponse // TypeDefIndex: 212
	{
		// Fields
		public PetUserDTO[] content; // 0x10
		public int totalPages; // 0x18
		public int totalElements; // 0x1C
		public int number; // 0x20
		public int size; // 0x24
		public bool first; // 0x28
		public bool last; // 0x29
		public int numberOfElements; // 0x2C

		// Constructors
		public PetPageResponse(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 213
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__78_1; // 0x08
		public static Action<string> __9__80_1; // 0x10
		public static Func<RoomSummaryDTO, bool> __9__129_0; // 0x18
		public static Func<RoomSummaryDTO, string> __9__129_1; // 0x20
		public static Predicate<PVPBrowseRoomRowUI> __9__129_2; // 0x28
		public static Func<KeyValuePair<string, WsPlayerStateDTO>, bool> __9__132_0; // 0x30
		public static Func<KeyValuePair<string, WsPlayerStateDTO>, int> __9__132_1; // 0x38
		public static Func<KeyValuePair<string, WsPlayerStateDTO>, string> __9__132_2; // 0x40
		public static Func<KeyValuePair<string, WsPlayerStateDTO>, int> __9__132_3; // 0x48
		public static Func<int, bool> __9__132_4; // 0x50

		// Constructors
		static __c(); // 0x0000000180C8E400-0x0000000180C8E4A0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPlayerDataWithLoading_b__78_1(string e); // 0x0000000180C8E4A0-0x0000000180C8E520
		internal void _LoadRankPosition_b__80_1(string err); // 0x0000000180C8E520-0x0000000180C8E5A0
		internal bool _RebuildBrowseRoomListUI_b__129_0(RoomSummaryDTO r); // 0x0000000180C8E5A0-0x0000000180C8E5C0
		internal string _RebuildBrowseRoomListUI_b__129_1(RoomSummaryDTO r); // 0x00000001807AA060-0x00000001807AA080
		internal bool _RebuildBrowseRoomListUI_b__129_2(PVPBrowseRoomRowUI r); // 0x0000000180C8E5C0-0x0000000180C8E6A0
		internal bool _SyncLobbyPetPreviewIfMaster_b__132_0(KeyValuePair<string, WsPlayerStateDTO> kv); // 0x0000000180C8E6A0-0x0000000180C8E6B0
		internal int _SyncLobbyPetPreviewIfMaster_b__132_1(KeyValuePair<string, WsPlayerStateDTO> kv); // 0x0000000180C8E6B0-0x0000000180C8E6E0
		internal string _SyncLobbyPetPreviewIfMaster_b__132_2(KeyValuePair<string, WsPlayerStateDTO> kv); // 0x0000000180C8E6E0-0x0000000180C8E6F0
		internal int _SyncLobbyPetPreviewIfMaster_b__132_3(KeyValuePair<string, WsPlayerStateDTO> kv); // 0x0000000180C8E6F0-0x0000000180C8E710
		internal bool _SyncLobbyPetPreviewIfMaster_b__132_4(int id); // 0x0000000180C8E710-0x0000000180C8E720
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass102_0 // TypeDefIndex: 214
	{
		// Fields
		public ManagerRoomPVP __4__this; // 0x10
		public Animator animator; // 0x18
		public int token; // 0x20
		public RuntimeAnimatorController baseController; // 0x28

		// Constructors
		public __c__DisplayClass102_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ApplyPetAnimation_b__0(AnimationClip[] clips); // 0x0000000180C8E720-0x0000000180C8EBF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass78_0 // TypeDefIndex: 215
	{
		// Fields
		public bool cacheLoaded; // 0x10

		// Constructors
		public __c__DisplayClass78_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPlayerDataWithLoading_b__0(); // 0x0000000180308BD0-0x0000000180308BE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass94_0 // TypeDefIndex: 216
	{
		// Fields
		public bool done; // 0x10
		public int page; // 0x14
		public PetsPaginatedDataDTO wsData; // 0x18

		// Constructors
		public __c__DisplayClass94_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPetsPage_b__0(PetsPaginatedDataDTO d); // 0x0000000180C8EBF0-0x0000000180C8EC60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass96_0 // TypeDefIndex: 217
	{
		// Fields
		public ManagerRoomPVP __4__this; // 0x10
		public CanvasGroup cg; // 0x18

		// Constructors
		public __c__DisplayClass96_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DisplayCurrentPetPage_b__0(); // 0x0000000180C8EC60-0x0000000180C8FB20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass96_1 // TypeDefIndex: 218
	{
		// Fields
		public string petIdStr; // 0x10
		public PetUserDTO clickedPet; // 0x18
		public __c__DisplayClass96_0 CS___8__locals1; // 0x20

		// Constructors
		public __c__DisplayClass96_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DisplayCurrentPetPage_b__1(); // 0x0000000180C8FB20-0x0000000180C8FB60
	}

	[CompilerGenerated]
	private sealed class _ClampLobbyButtonsNextFrame_d__69 : IEnumerator<object> // TypeDefIndex: 219
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Transform main; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClampLobbyButtonsNextFrame_d__69(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180C8FB60-0x0000000180C8FE40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180C8FE40-0x0000000180C8FE80
	}

	[CompilerGenerated]
	private sealed class _CoRefreshPlayerSlotsAfterJoin_d__116 : IEnumerator<object> // TypeDefIndex: 220
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoomPVP __4__this; // 0x20
		private int _i_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CoRefreshPlayerSlotsAfterJoin_d__116(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180C8FE80-0x0000000180C90010
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180C90010-0x0000000180C90050
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__94 : IEnumerator<object> // TypeDefIndex: 221
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int page; // 0x20
		public ManagerRoomPVP __4__this; // 0x28
		private __c__DisplayClass94_0 __8__1; // 0x30
		private int _myToken_5__2; // 0x38
		private Action<PetsPaginatedDataDTO> _onResp_5__3; // 0x40
		private float _deadline_5__4; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetsPage_d__94(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803E1CC0-0x00000001803E1D80
		private bool MoveNext(); // 0x0000000180C90050-0x0000000180C90CB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180C90CB0-0x0000000180C90CF0
	}

	[CompilerGenerated]
	private sealed class _LoadPlayerDataWithLoading_d__78 : IEnumerator<object> // TypeDefIndex: 222
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoomPVP __4__this; // 0x20
		private __c__DisplayClass78_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadPlayerDataWithLoading_d__78(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180C90CF0-0x0000000180C91890
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180C91890-0x0000000180C918D0
	}

	[CompilerGenerated]
	private sealed class _OnStartBattle_d__137 : IEnumerator<object> // TypeDefIndex: 223
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoomPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _OnStartBattle_d__137(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180C918D0-0x0000000180C91C10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180C91C10-0x0000000180C91C50
	}

	// Constructors
	public ManagerRoomPVP(); // 0x0000000180C8DE40-0x0000000180C8E150

	// Methods
	private void Awake(); // 0x0000000180C80FB0-0x0000000180C81080
	private void OnDestroy(); // 0x0000000180C81080-0x0000000180C810D0
	public void OnHubSuspend(); // 0x0000000180C810D0-0x0000000180C810F0
	public void OnHubResume(); // 0x0000000180C810F0-0x0000000180C81160
	private void OnEnable(); // 0x0000000180C81160-0x0000000180C814C0
	private void EnsureLobbyButtons(); // 0x0000000180C814C0-0x0000000180C81C20
	private static void HideLobbyButton(Transform t); // 0x0000000180C81C20-0x0000000180C81DE0
	private static int MaxSpriteOrder(Transform root); // 0x0000000180C81DE0-0x0000000180C81FA0
	private static void RaiseAboveSprites(Transform t, int spriteTop); // 0x0000000180C81FA0-0x0000000180C82290
	private static void WireLobbyButton(Transform t, Image refImg, string label, UnityAction call); // 0x0000000180C82290-0x0000000180C82C90
	[IteratorStateMachine(typeof(_ClampLobbyButtonsNextFrame_d__69))]
	private IEnumerator ClampLobbyButtonsNextFrame(Transform main); // 0x0000000180C82C90-0x0000000180C82D30
	private static void ClampInsideRootCanvas(RectTransform rt, float margin); // 0x0000000180C82D30-0x0000000180C832B0
	private void OnLobbyRankingClicked(); // 0x0000000180C832B0-0x0000000180C83410
	private void OnLobbyTournamentClicked(); // 0x0000000180C83410-0x0000000180C83480
	private void OnDisable(); // 0x0000000180C83480-0x0000000180C83630
	private void Start(); // 0x0000000180C83630-0x0000000180C837B0
	private void Update(); // 0x0000000180C837B0-0x0000000180C83A70
	public void OpenRoomPVP(); // 0x0000000180C83A70-0x0000000180C83EB0
	public void HideRoomPVP(); // 0x0000000180C83EB0-0x0000000180C83F00
	[IteratorStateMachine(typeof(_LoadPlayerDataWithLoading_d__78))]
	public IEnumerator LoadPlayerDataWithLoading(); // 0x0000000180C83F00-0x0000000180C83FA0
	public void DisplayLocalPlayerInfo(UserDTO user); // 0x0000000180C83FA0-0x0000000180C84610
	private void LoadRankPosition(int userId); // 0x0000000180C84610-0x0000000180C84820
	private void UpdateLobbyPvpStats(UserDTO user); // 0x0000000180C84820-0x0000000180C85270
	public void ShowPetPanel(); // 0x0000000180C85270-0x0000000180C856C0
	public void HidePetPanel(); // 0x0000000180C856C0-0x0000000180C85A20
	private void SetupPetPagination(); // 0x0000000180C85A20-0x0000000180C85C90
	private void ApplyPetPanelLayout(); // 0x0000000180C85C90-0x0000000180C86790
	private static void PlacePetArrow(Button b, float x); // 0x0000000180C86790-0x0000000180C869C0
	private void CleanupPetsRequest(); // 0x0000000180C869C0-0x0000000180C86B60
	[IteratorStateMachine(typeof(_LoadPetsPage_d__94))]
	private IEnumerator LoadPetsPage(int userId, int page); // 0x0000000180C86B60-0x0000000180C86C10
	private void CacheSelectedPetFromPage(); // 0x0000000180C86C10-0x0000000180C86CB0
	private void DisplayCurrentPetPage(); // 0x0000000180C86CB0-0x0000000180C86FD0
	private void OnPetClicked(string petIdStr, PetUserDTO petData = null); // 0x0000000180C86FD0-0x0000000180C87280
	private void ShowPreviousPetPage(); // 0x0000000180C87280-0x0000000180C87310
	private void ShowNextPetPage(); // 0x0000000180C87310-0x0000000180C873A0
	private void UpdatePetPaginationButtons(); // 0x0000000180C873A0-0x0000000180C876E0
	private void ApplyPetAnimation(Animator animator, int petId); // 0x0000000180C876E0-0x0000000180C87D70
	private void SetupCardSelection(); // 0x0000000180C87D70-0x0000000180C87FB0
	public void HideCardPanel(); // 0x0000000180C87FB0-0x0000000180C88190
	public void DisplayCardsForSelection(List<CardData> cards); // 0x0000000180C88190-0x0000000180C883C0
	private void SaveSelectedCardsToPrefs(); // 0x0000000180C883C0-0x0000000180C88620
	internal void TryRestoreSelectedCards(); // 0x0000000180C88620-0x0000000180C88A90
	private GameObject CreateCardToggle(CardData card, int index); // 0x0000000180C88A90-0x0000000180C88C30
	private void SetupToggle(GameObject obj, CardData card); // 0x0000000180C88C30-0x0000000180C89360
	public void ScheduleRefreshPlayerSlotsAfterJoin(); // 0x0000000180C89360-0x0000000180C89550
	public void CancelRefreshPlayerSlotsAfterJoin(); // 0x0000000180C89550-0x0000000180C895D0
	[IteratorStateMachine(typeof(_CoRefreshPlayerSlotsAfterJoin_d__116))]
	private IEnumerator CoRefreshPlayerSlotsAfterJoin(); // 0x0000000180C895D0-0x0000000180C89670
	internal void InvalidateSlotsCache(); // 0x0000000180C89670-0x0000000180C896D0
	private string ComputeSlotsSignature(WsRoomService ws, string localUsername); // 0x0000000180C896D0-0x0000000180C8A3C0
	public void UpdatePlayerSlots(); // 0x0000000180C8A3C0-0x0000000180C8B440
	public void OnPVPRoomConnectionChanged(bool inRoom, bool pendingJoinAnotherRoom = false /* Metadata: 0x005EED38 */); // 0x0000000180C8B440-0x0000000180C8B670
	private void EnsureWsRoomListSubscription(); // 0x0000000180C8B670-0x0000000180C8B810
	private void TeardownWsRoomListSubscription(); // 0x0000000180C8B810-0x0000000180C8B8D0
	private void HandleWsRoomListChanged(); // 0x0000000180C8B8D0-0x0000000180C8B8E0
	private void RebuildBrowseRoomListUI(); // 0x0000000180C8B8E0-0x0000000180C8CB20
	private static void AppendRoomProp(StringBuilder sb, RoomSummaryDTO room, string key); // 0x0000000180C8CB20-0x0000000180C8CC40
	private void OnBrowseJoinClicked(string roomId); // 0x0000000180C8CC40-0x0000000180C8CC70
	private void SyncLobbyPetPreviewIfMaster(); // 0x0000000180C8CC70-0x0000000180C8D420
	private static int SafeToInt(object v); // 0x0000000180C8D420-0x0000000180C8D480
	private bool GetLocalWsReady(); // 0x0000000180C8D480-0x0000000180C8D580
	public void ShowEnergyWarning(); // 0x0000000180C8D580-0x0000000180C8D9B0
	private void HideEnergyWarning(); // 0x0000000180C8D9B0-0x0000000180C8DB90
	[IteratorStateMachine(typeof(_OnStartBattle_d__137))]
	public IEnumerator OnStartBattle(); // 0x0000000180C8DB90-0x0000000180C8DC30
	public void StartBattleSequence(); // 0x0000000180C8DC30-0x0000000180C8DE40
	[CompilerGenerated]
	private void _LoadRankPosition_b__80_0(PvpProfileDTO data); // 0x0000000180C8E150-0x0000000180C8E300
	[CompilerGenerated]
	private void _HidePetPanel_b__83_0(); // 0x0000000180895790-0x0000000180895810
	[CompilerGenerated]
	private void _HideCardPanel_b__107_0(); // 0x0000000180C8E300-0x0000000180C8E380
	[CompilerGenerated]
	private void _HideEnergyWarning_b__136_0(); // 0x0000000180C8E380-0x0000000180C8E400
}

