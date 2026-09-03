/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerRoomPVP : MonoBehaviour, IHubSuspendable // TypeDefIndex: 190
{
	// Fields
	public static ManagerRoomPVP Instance; // 0x00
	public const string LobbyPetKey0 = "p0"; // Metadata: 0x0064C038
	public const string LobbyPetKey1 = "p1"; // Metadata: 0x0064C03B
	public const string LobbyWeaponKey0 = "w0"; // Metadata: 0x0064C03E
	public const string LobbyWeaponKey1 = "w1"; // Metadata: 0x0064C041
	public const string LobbyWeaponRarityKey0 = "wr0"; // Metadata: 0x0064C044
	public const string LobbyWeaponRarityKey1 = "wr1"; // Metadata: 0x0064C048
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
	private const int PETS_PER_PAGE = 3; // Metadata: 0x0064C04C
	private PetPageResponse currentPetPageData; // 0xE8
	private PetUserDTO _selectedPetData; // 0xF0
	[Header("Card Selection")]
	public GameObject panelCard; // 0xF8
	public GameObject btnCloseCard; // 0x100
	public ToggleManagerPVP toggleManager; // 0x108
	private bool isRotatingCard; // 0x110
	public float rotationSpeed; // 0x114
	[Header("Energy Warning")]
	public GameObject energyWarningPanel; // 0x118
	public UnityEngine.UI.Text energyWarningText; // 0x120
	public Button energyWarningOkButton; // 0x128
	[Header("Browse room list (ListRoom / listPanel / room template)")]
	[Tooltip("\u1EA8n khi \u0111\u00E3 v\u00E0o ph\u00F2ng; hi\u1EC7n khi \u1EDF s\u1EA3nh PVP.")]
	public GameObject listRoomRoot; // 0x130
	public Transform listPanel; // 0x138
	[Tooltip("Object m\u1EABu \'room\' (\u0111\u1EC3 inactive), s\u1EBD Instantiate khi v\u1EBD list.")]
	public GameObject roomRowTemplate; // 0x140
	[SerializeField]
	[Tooltip("S\u1ED1 ng\u01B0\u1EDDi t\u1ED1i thi\u1EC3u coi l\u00E0 \u0111\u1EA7y \u2192 n\u00FAt \u0110\u00E3 \u0111\u1EA7y (m\u1EB7c 2).")]
	private int browseRoomFullPlayerCount; // 0x148
	private bool _wsListSubscribed; // 0x14C
	private Coroutine _refreshSlotsAfterJoinCo; // 0x150
	internal UserDTO currentUser; // 0x158
	internal RoomDTO roomData; // 0x160
	internal List<CardData> selectedCards; // 0x168
	internal int currentUserEnergy; // 0x170
	private Coroutine _loadCoroutine; // 0x178
	private readonly Dictionary<Animator, RuntimeAnimatorController> _previewBaseControllers; // 0x180
	private readonly Dictionary<Animator, int> _previewAnimToken; // 0x188
	private bool _pendingSelectionRestore; // 0x190
	private bool _slotsRefreshPending; // 0x191

	// Nested types
	[Serializable]
	public class PetPageResponse // TypeDefIndex: 191
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
		public PetPageResponse(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 192
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__66_1; // 0x08
		public static Action<string> __9__68_1; // 0x10
		public static Predicate<CardData> __9__86_0; // 0x18
		public static Func<RoomSummaryDTO, bool> __9__101_0; // 0x20
		public static Func<RoomSummaryDTO, string> __9__101_1; // 0x28
		public static Func<KeyValuePair<string, WsPlayerStateDTO>, bool> __9__103_0; // 0x30
		public static Func<KeyValuePair<string, WsPlayerStateDTO>, int> __9__103_1; // 0x38
		public static Func<KeyValuePair<string, WsPlayerStateDTO>, string> __9__103_2; // 0x40
		public static Func<KeyValuePair<string, WsPlayerStateDTO>, int> __9__103_3; // 0x48
		public static Func<int, bool> __9__103_4; // 0x50

		// Constructors
		static __c(); // 0x0000000180692EB0-0x0000000180692F20
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadPlayerDataWithLoading_b__66_1(string e); // 0x0000000180691D50-0x0000000180691DC0
		internal void _LoadRankPosition_b__68_1(string err); // 0x0000000180691DC0-0x0000000180691E30
		internal bool _DisplayCardsForSelection_b__86_0(CardData c); // 0x0000000180691C40-0x0000000180691D50
		internal bool _RebuildBrowseRoomListUI_b__101_0(RoomSummaryDTO r); // 0x0000000180691E30-0x0000000180691E60
		internal string _RebuildBrowseRoomListUI_b__101_1(RoomSummaryDTO r); // 0x000000018052BA80-0x000000018052BAA0
		internal bool _SyncLobbyPetPreviewIfMaster_b__103_0(KeyValuePair<string, WsPlayerStateDTO> kv); // 0x0000000180691E60-0x0000000180691E70
		internal int _SyncLobbyPetPreviewIfMaster_b__103_1(KeyValuePair<string, WsPlayerStateDTO> kv); // 0x0000000180691E70-0x0000000180691EA0
		internal string _SyncLobbyPetPreviewIfMaster_b__103_2(KeyValuePair<string, WsPlayerStateDTO> kv); // 0x0000000180691EA0-0x0000000180691EB0
		internal int _SyncLobbyPetPreviewIfMaster_b__103_3(KeyValuePair<string, WsPlayerStateDTO> kv); // 0x0000000180691EB0-0x0000000180691ED0
		internal bool _SyncLobbyPetPreviewIfMaster_b__103_4(int id); // 0x0000000180691ED0-0x0000000180691EE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_0 // TypeDefIndex: 193
	{
		// Fields
		public bool cacheLoaded; // 0x10

		// Constructors
		public __c__DisplayClass66_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadPlayerDataWithLoading_b__0(); // 0x000000018030F220-0x000000018030F230
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass73_0 // TypeDefIndex: 194
	{
		// Fields
		public bool done; // 0x10
		public PetsPaginatedDataDTO wsData; // 0x18

		// Constructors
		public __c__DisplayClass73_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadPetsPage_b__0(PetsPaginatedDataDTO d); // 0x00000001802FB060-0x00000001802FB080
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass75_0 // TypeDefIndex: 195
	{
		// Fields
		public ManagerRoomPVP __4__this; // 0x10
		public CanvasGroup cg; // 0x18

		// Constructors
		public __c__DisplayClass75_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DisplayCurrentPetPage_b__0(); // 0x0000000180692120-0x00000001806929C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass75_1 // TypeDefIndex: 196
	{
		// Fields
		public string petIdStr; // 0x10
		public PetUserDTO clickedPet; // 0x18
		public __c__DisplayClass75_0 CS___8__locals1; // 0x20

		// Constructors
		public __c__DisplayClass75_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DisplayCurrentPetPage_b__1(); // 0x00000001806929C0-0x0000000180692A00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass81_0 // TypeDefIndex: 197
	{
		// Fields
		public ManagerRoomPVP __4__this; // 0x10
		public Animator animator; // 0x18
		public int token; // 0x20
		public RuntimeAnimatorController baseController; // 0x28

		// Constructors
		public __c__DisplayClass81_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ApplyPetAnimation_b__0(AnimationClip[] clips); // 0x0000000180692A00-0x0000000180692CA0
	}

	[CompilerGenerated]
	private sealed class _CoRefreshPlayerSlotsAfterJoin_d__94 : IEnumerator<object> // TypeDefIndex: 198
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoomPVP __4__this; // 0x20
		private int _i_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CoRefreshPlayerSlotsAfterJoin_d__94(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018068C8B0-0x000000018068CA00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068CA00-0x000000018068CA40
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__73 : IEnumerator<object> // TypeDefIndex: 199
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int page; // 0x20
		private __c__DisplayClass73_0 __8__1; // 0x28
		public ManagerRoomPVP __4__this; // 0x30
		private Action<PetsPaginatedDataDTO> _onResp_5__2; // 0x38
		private float _deadline_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetsPage_d__73(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018057B200-0x000000018057B240
		private bool MoveNext(); // 0x000000018068E120-0x000000018068E680
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068E680-0x000000018068E6C0
	}

	[CompilerGenerated]
	private sealed class _LoadPlayerDataWithLoading_d__66 : IEnumerator<object> // TypeDefIndex: 200
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoomPVP __4__this; // 0x20
		private __c__DisplayClass66_0 __8__1; // 0x28
		private int _userId_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadPlayerDataWithLoading_d__66(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018068E6C0-0x000000018068ED50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068ED50-0x000000018068ED90
	}

	[CompilerGenerated]
	private sealed class _OnStartBattle_d__108 : IEnumerator<object> // TypeDefIndex: 201
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoomPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OnStartBattle_d__108(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018068FA40-0x000000018068FBE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068FBE0-0x000000018068FC20
	}

	// Constructors
	public ManagerRoomPVP(); // 0x00000001806881F0-0x0000000180688320

	// Methods
	private void Awake(); // 0x0000000180682C10-0x0000000180682C90
	private void OnDestroy(); // 0x00000001806842E0-0x0000000180684330
	public void OnHubSuspend(); // 0x0000000180684540-0x00000001806845A0
	public void OnHubResume(); // 0x0000000180684520-0x0000000180684540
	private void OnEnable(); // 0x00000001806843D0-0x0000000180684520
	private void OnDisable(); // 0x0000000180684330-0x00000001806843D0
	private void Start(); // 0x0000000180686040-0x0000000180686240
	private void Update(); // 0x0000000180688020-0x00000001806881F0
	public void OpenRoomPVP(); // 0x00000001806848E0-0x0000000180684A80
	public void HideRoomPVP(); // 0x0000000180684000-0x0000000180684050
	[IteratorStateMachine(typeof(_LoadPlayerDataWithLoading_d__66))]
	public IEnumerator LoadPlayerDataWithLoading(); // 0x00000001806840D0-0x0000000180684140
	public void DisplayLocalPlayerInfo(UserDTO user); // 0x00000001806835C0-0x0000000180683900
	private void LoadRankPosition(int userId); // 0x0000000180684140-0x00000001806842B0
	private void UpdateLobbyPvpStats(UserDTO user); // 0x0000000180686EB0-0x0000000180687430
	public void ShowPetPanel(); // 0x0000000180685C50-0x0000000180685E30
	public void HidePetPanel(); // 0x0000000180683E40-0x0000000180684000
	private void SetupPetPagination(); // 0x0000000180685210-0x0000000180685360
	[IteratorStateMachine(typeof(_LoadPetsPage_d__73))]
	private IEnumerator LoadPetsPage(int userId, int page); // 0x0000000180684050-0x00000001806840D0
	private void CacheSelectedPetFromPage(); // 0x0000000180682C90-0x0000000180682D30
	private void DisplayCurrentPetPage(); // 0x00000001806833E0-0x00000001806835C0
	private void OnPetClicked(string petIdStr, PetUserDTO petData = null); // 0x0000000180684690-0x0000000180684870
	private void ShowPreviousPetPage(); // 0x0000000180685E30-0x0000000180685EB0
	private void ShowNextPetPage(); // 0x0000000180685BD0-0x0000000180685C50
	private void UpdatePetPaginationButtons(); // 0x0000000180687430-0x00000001806875E0
	private void ApplyPetAnimation(Animator animator, int petId); // 0x00000001806828F0-0x0000000180682C10
	private void SetupCardSelection(); // 0x00000001802E76C0-0x00000001802E76D0
	public void ShowCardPanel(); // 0x0000000180685860-0x00000001806859C0
	public void HideCardPanel(); // 0x0000000180683B90-0x0000000180683CE0
	public void DisplayCardsForSelection(List<CardData> cards); // 0x0000000180682F00-0x00000001806833E0
	private void SaveSelectedCardsToPrefs(); // 0x0000000180684FC0-0x0000000180685110
	internal void TryRestoreSelectedCards(); // 0x00000001806868C0-0x0000000180686D70
	private GameObject CreateCardToggle(CardData card, int index); // 0x0000000180682DF0-0x0000000180682F00
	private void SetupToggle(GameObject obj, CardData card); // 0x0000000180685360-0x0000000180685860
	public void ScheduleRefreshPlayerSlotsAfterJoin(); // 0x0000000180685110-0x0000000180685210
	public void CancelRefreshPlayerSlotsAfterJoin(); // 0x0000000180682D30-0x0000000180682D80
	[IteratorStateMachine(typeof(_CoRefreshPlayerSlotsAfterJoin_d__94))]
	private IEnumerator CoRefreshPlayerSlotsAfterJoin(); // 0x0000000180682D80-0x0000000180682DF0
	public void UpdatePlayerSlots(); // 0x00000001806875E0-0x0000000180688020
	public void OnPVPRoomConnectionChanged(bool inRoom, bool pendingJoinAnotherRoom = false /* Metadata: 0x0064C037 */); // 0x00000001806845A0-0x0000000180684690
	private void EnsureWsRoomListSubscription(); // 0x0000000180683900-0x0000000180683A80
	private void TeardownWsRoomListSubscription(); // 0x0000000180686810-0x00000001806868C0
	private void HandleWsRoomListChanged(); // 0x0000000180683B80-0x0000000180683B90
	private void RebuildBrowseRoomListUI(); // 0x0000000180684A80-0x0000000180684F60
	private void OnBrowseJoinClicked(string roomId); // 0x00000001806842B0-0x00000001806842E0
	private void SyncLobbyPetPreviewIfMaster(); // 0x0000000180686240-0x0000000180686810
	private static int SafeToInt(object v); // 0x0000000180684F60-0x0000000180684FC0
	private bool GetLocalWsReady(); // 0x0000000180683A80-0x0000000180683B80
	public void ShowEnergyWarning(); // 0x00000001806859C0-0x0000000180685BD0
	private void HideEnergyWarning(); // 0x0000000180683CE0-0x0000000180683E40
	[IteratorStateMachine(typeof(_OnStartBattle_d__108))]
	public IEnumerator OnStartBattle(); // 0x0000000180684870-0x00000001806848E0
	public void StartBattleSequence(); // 0x0000000180685EB0-0x0000000180686040
	[CompilerGenerated]
	private void _LoadRankPosition_b__68_0(PvpProfileDTO data); // 0x0000000180686DD0-0x0000000180686EB0
	[CompilerGenerated]
	private void _HidePetPanel_b__71_0(); // 0x000000018048E590-0x000000018048E5C0
	[CompilerGenerated]
	private void _HideCardPanel_b__85_0(); // 0x0000000180686D70-0x0000000180686DA0
	[CompilerGenerated]
	private void _HideEnergyWarning_b__107_0(); // 0x0000000180686DA0-0x0000000180686DD0
}

