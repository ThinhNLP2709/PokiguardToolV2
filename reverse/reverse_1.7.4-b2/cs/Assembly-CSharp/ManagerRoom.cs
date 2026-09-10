/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerRoom : MonoBehaviour // TypeDefIndex: 1717
{
	// Fields
	public GameObject roomPanel; // 0x20
	public Button ButtonStart; // 0x28
	public GameObject loading; // 0x30
	public GameObject panelPet; // 0x38
	public GameObject panelCard; // 0x40
	public GameObject btnClosePet; // 0x48
	public GameObject btnCloseCard; // 0x50
	public Button btnBackToChinhPhuc; // 0x58
	[Header("UI Slots - 3 ng\u01B0\u1EDDi ch\u01A1i")]
	public RoomUIGroup_Manager uiGroupManager; // 0x60
	private bool isRotatingPet; // 0x68
	private bool isRotatingCard; // 0x69
	public float rotationSpeed; // 0x6C
	public Animator animator; // 0x70
	public Animator enemyPet; // 0x78
	public Image imgEnemyPet; // 0x80
	public UnityEngine.UI.Text txtNamePetEnemy; // 0x88
	public GameObject petUIPrefab; // 0x90
	public Transform petListContainer; // 0x98
	public Button btnPrevPetPage; // 0xA0
	public Button btnNextPetPage; // 0xA8
	public UnityEngine.UI.Text txtPetPageInfo; // 0xB0
	private PlayerUISlot myLocalPlayerUISlot; // 0xB8
	private int currentPetPage; // 0xC0
	private const int PETS_PER_PAGE = 18; // Metadata: 0x0068D61F
	private PetPageResponse currentPetPageData; // 0xC8
	public GameObject panelSelectCards; // 0xD0
	public ToggleManager toggleManager; // 0xD8
	public GameObject energyWarningPanel; // 0xE0
	public UnityEngine.UI.Text energyWarningText; // 0xE8
	public Button energyWarningOkButton; // 0xF0
	internal int currentUserEnergy; // 0xF8
	internal RoomDTO roomData; // 0x100
	public List<CardData> selectedCards; // 0x108
	public GameObject fadeOverlay; // 0x110
	internal UserDTO currentUser; // 0x118
	internal static ManagerRoom Instance; // 0x00
	internal int myLocalSlotIndex; // 0x120
	private bool _pendingSelectionRestore; // 0x124
	private const string GUILD_ROOM_BG = "Image/GuildUI/guild_room_bg"; // Metadata: 0x0068D620
	private const string GUILD_ROOM_TITLE_NODE = "txtGuildRoomTitle"; // Metadata: 0x0068D63C
	private Sprite _roomBgOriginal; // 0x128
	private Image _roomBgImage; // 0x130
	private bool _guildSkinApplied; // 0x138
	private const float GUILD_TITLE_TOP_OFFSET = -60f; // Metadata: 0x0068D64E
	private static readonly Vector2 GUILD_TITLE_SIZE; // 0x08
	private bool _closingGuildRoom; // 0x139
	private static bool _guildRoomSession; // 0x10
	private const string PREF_GUILD_BATTLE = "IsGuildBossBattle"; // Metadata: 0x0068D652
	private const float LOADING_WATCHDOG_SEC = 25f; // Metadata: 0x0068D664
	private Coroutine _roomLoadingWatchdogCo; // 0x140
	[CompilerGenerated]
	private bool _IsOpeningRoomFlow_k__BackingField; // 0x148
	private int[] _lastSyncedCardIds; // 0x150
	private Action<PetsPaginatedDataDTO> _petsPageHandler; // 0x158
	private PetsPaginatedDataDTO _petsPageData; // 0x160
	private bool _petsPageReady; // 0x168
	private int _requestedPetPage; // 0x16C
	private bool _petPageLoading; // 0x170
	private Coroutine _displayPetPageCoroutine; // 0x178
	private const int PET_RESIDENT_BUDGET = 12; // Metadata: 0x0068D668
	private bool _updatePlayerSlotsPending; // 0x180
	private int _myPetAnimToken; // 0x184
	private int _enemyPetAnimToken; // 0x188

	// Properties
	public bool IsGuildBossRoom { get; } // 0x00000001806600E0-0x0000000180660120 
	public static bool GuildRoomContextNow { get; } // 0x0000000180666310-0x00000001806663D0 
	public bool IsOpeningRoomFlow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806663D0-0x00000001806663E0 0x00000001806663E0-0x00000001806663F0

	// Nested types
	[Serializable]
	public class PetPageResponse // TypeDefIndex: 1718
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
		public PetPageResponse(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1719
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__101_1; // 0x08
		public static Func<CardData, int> __9__109_0; // 0x10

		// Constructors
		static __c(); // 0x00000001806880E0-0x0000000180688150
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadRoomDataWithoutLoading_b__101_1(string e); // 0x0000000180687430-0x00000001806874A0
		internal int _UpdateLocalSelectedCards_b__109_0(CardData c); // 0x0000000180425510-0x0000000180425530
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass100_0 // TypeDefIndex: 1720
	{
		// Fields
		public bool cacheStarted; // 0x10
		public ManagerRoom __4__this; // 0x18
		public int selectedPetId; // 0x20
		public bool cacheLoaded; // 0x24
		public bool cacheDone; // 0x25
		public float loadStart; // 0x28
		public bool isJoiningInvite; // 0x2C
		public bool wsEnterFailed; // 0x2D
		public string wsEnterFailReason; // 0x30
		public bool wsEntered; // 0x38
		public Action __9__3; // 0x40
		public Action<string> __9__4; // 0x48

		// Constructors
		public __c__DisplayClass100_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadRoomDataWithLoading_b__0(); // 0x0000000180687510-0x00000001806876F0
		internal void _LoadRoomDataWithLoading_b__3(); // 0x0000000180687720-0x0000000180687730
		internal void _LoadRoomDataWithLoading_b__4(string e); // 0x0000000180687730-0x00000001806877E0
		internal void _LoadRoomDataWithLoading_b__1(string r); // 0x00000001806876F0-0x0000000180687710
		internal void _LoadRoomDataWithLoading_b__2(string _); // 0x0000000180687710-0x0000000180687720
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass101_0 // TypeDefIndex: 1721
	{
		// Fields
		public bool cacheLoaded; // 0x10

		// Constructors
		public __c__DisplayClass101_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadRoomDataWithoutLoading_b__0(); // 0x000000018034AB40-0x000000018034AB50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass124_0 // TypeDefIndex: 1722
	{
		// Fields
		public string petID; // 0x10
		public ManagerRoom __4__this; // 0x18

		// Constructors
		public __c__DisplayClass124_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _DisplayCurrentPetPageCoroutine_b__0(); // 0x00000001806877E0-0x0000000180687810
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass125_0 // TypeDefIndex: 1723
	{
		// Fields
		public string petID; // 0x10

		// Constructors
		public __c__DisplayClass125_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _HookPetRowPrewarm_b__0(BaseEventData _); // 0x0000000180687810-0x0000000180687880
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass129_0 // TypeDefIndex: 1724
	{
		// Fields
		public Button button; // 0x10

		// Constructors
		public __c__DisplayClass129_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AnimateButton_b__0(); // 0x0000000180687880-0x0000000180687970
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass138_0 // TypeDefIndex: 1725
	{
		// Fields
		public int token; // 0x10
		public ManagerRoom __4__this; // 0x18
		public int petId; // 0x20

		// Constructors
		public __c__DisplayClass138_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ApplyMyPetAnimation_b__0(AnimationClip[] clips); // 0x0000000180687970-0x0000000180687AA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass145_0 // TypeDefIndex: 1726
	{
		// Fields
		public int token; // 0x10
		public ManagerRoom __4__this; // 0x18
		public string petId; // 0x20

		// Constructors
		public __c__DisplayClass145_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ApplyEnemyPetAnimation_b__0(AnimationClip[] clips); // 0x0000000180687B80-0x0000000180687CA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass154_0 // TypeDefIndex: 1727
	{
		// Fields
		public bool preloadDone; // 0x10

		// Constructors
		public __c__DisplayClass154_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _DelayedLoadScene_b__0(); // 0x000000018034AB40-0x000000018034AB50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass156_0 // TypeDefIndex: 1728
	{
		// Fields
		public bool failed; // 0x10
		public PetUserDTO myPet; // 0x18
		public PetUserDTO enemyPet; // 0x20
		public UserDTO user; // 0x28

		// Constructors
		public __c__DisplayClass156_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PreloadMatchData_b__0(MatchPrepDataDTO data); // 0x0000000180687CA0-0x0000000180687D10
		internal void _PreloadMatchData_b__1(string err); // 0x0000000180687D10-0x0000000180687D90
	}

	[CompilerGenerated]
	private sealed class _DelayedLoadScene_d__154 : IEnumerator<object> // TypeDefIndex: 1729
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		private __c__DisplayClass154_0 __8__1; // 0x28
		public ManagerRoom __4__this; // 0x30
		public string sceneName; // 0x38
		private float _preloadStart_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DelayedLoadScene_d__154(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180683030-0x00000001806832D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806832D0-0x0000000180683310
	}

	[CompilerGenerated]
	private sealed class _DisplayCurrentPetPageCoroutine_d__124 : IEnumerator<object> // TypeDefIndex: 1730
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private int _listSelUserPetId_5__2; // 0x28
		private PetUserDTO[] _pets_5__3; // 0x30
		private int _i_5__4; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DisplayCurrentPetPageCoroutine_d__124(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180683310-0x0000000180683C70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180683C70-0x0000000180683CB0
	}

	[CompilerGenerated]
	private sealed class _EnsureWsThenOpenRoom_d__86 : IEnumerator<object> // TypeDefIndex: 1731
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		public bool isLocal; // 0x28
		public string roomName; // 0x30
		private ChatService _chat_5__2; // 0x38
		private float _waited_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _EnsureWsThenOpenRoom_d__86(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x0000000180683CB0-0x0000000180684270
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180684270-0x00000001806842B0
	}

	[CompilerGenerated]
	private sealed class _FadeTransition_d__105 : IEnumerator<object> // TypeDefIndex: 1732
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FadeTransition_d__105(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806842B0-0x00000001806845A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806845A0-0x00000001806845E0
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__115 : IEnumerator<object> // TypeDefIndex: 1733
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		public int page; // 0x28
		private float _deadline_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetsPage_d__115(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806845E0-0x0000000180684900
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180684900-0x0000000180684940
	}

	[CompilerGenerated]
	private sealed class _LoadRoomDataWithLoading_d__100 : IEnumerator<object> // TypeDefIndex: 1734
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		public bool alreadyInRoom; // 0x28
		private __c__DisplayClass100_0 __8__1; // 0x30
		private Action _startCacheLoad_5__2; // 0x38
		private float _joinWaitStart_5__3; // 0x40
		private WsRoomService _wsRoomWait_5__4; // 0x48
		private Action<string> _onWsEnterFailed_5__5; // 0x50
		private Action<string> _onWsEntered_5__6; // 0x58

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoomDataWithLoading_d__100(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180685830-0x00000001806858A0
		private bool MoveNext(); // 0x0000000180684D10-0x00000001806857F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806857F0-0x0000000180685830
	}

	[CompilerGenerated]
	private sealed class _LoadRoomDataWithoutLoading_d__101 : IEnumerator<object> // TypeDefIndex: 1735
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private __c__DisplayClass101_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoomDataWithoutLoading_d__101(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001806858A0-0x0000000180685DE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180685DE0-0x0000000180685E20
	}

	[CompilerGenerated]
	private sealed class _OnStartBattle_d__151 : IEnumerator<object> // TypeDefIndex: 1736
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _OnStartBattle_d__151(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806862B0-0x0000000180686480
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180686480-0x00000001806864C0
	}

	[CompilerGenerated]
	private sealed class _PetPageLoop_d__119 : IEnumerator<object> // TypeDefIndex: 1737
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private int _userId_5__2; // 0x28
		private int _guard_5__3; // 0x2C
		private int _want_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PetPageLoop_d__119(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806864C0-0x00000001806865B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806865B0-0x00000001806865F0
	}

	[CompilerGenerated]
	private sealed class _PreloadMatchData_d__156 : IEnumerator<object> // TypeDefIndex: 1738
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private __c__DisplayClass156_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PreloadMatchData_d__156(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001806865F0-0x0000000180686DA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180686DA0-0x0000000180686DE0
	}

	[CompilerGenerated]
	private sealed class _RoomLoadingWatchdogRoutine_d__92 : IEnumerator<object> // TypeDefIndex: 1739
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private float _deadline_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RoomLoadingWatchdogRoutine_d__92(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180686FA0-0x0000000180687210
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180687210-0x0000000180687250
	}

	[CompilerGenerated]
	private sealed class _RunPreloadThenFlag_d__155 : IEnumerator<object> // TypeDefIndex: 1740
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		public Action onDone; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RunPreloadThenFlag_d__155(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180687250-0x00000001806872D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806872D0-0x0000000180687310
	}

	[CompilerGenerated]
	private sealed class _UpdatePlayerSlotsDebounced_d__134 : IEnumerator<object> // TypeDefIndex: 1741
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UpdatePlayerSlotsDebounced_d__134(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806883C0-0x0000000180688430
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180688430-0x00000001806884C0
	}

	// Constructors
	public ManagerRoom(); // 0x0000000180666280-0x0000000180666310
	static ManagerRoom(); // 0x0000000180666230-0x0000000180666280

	// Methods
	private void Start(); // 0x0000000180664280-0x0000000180664870
	private static bool IsReturningFromMatch(); // 0x00000001806601C0-0x00000001806602B0
	internal void ApplyWsEnemyPetFromProperties(); // 0x000000018065E070-0x000000018065E290
	private void ApplyGuildBossDisplay(); // 0x000000018065D890-0x000000018065D9B0
	private void HandleUserEnergyDelta(ChatMessageDTO msg); // 0x000000018065FA90-0x000000018065FC10
	private void SetupCardSelection(); // 0x00000001806630F0-0x0000000180663290
	private void HandleCardSelectionChanged(); // 0x000000018065FA50-0x000000018065FA90
	internal void SaveSelectedCardsToPrefs(); // 0x00000001806627A0-0x00000001806628F0
	private void TryRestoreSelectedCards(bool syncAfter); // 0x0000000180664BC0-0x0000000180664D60
	private static List<int> ReadSavedCardIds(); // 0x00000001806619C0-0x0000000180661C00
	private void SetupPetPagination(); // 0x0000000180663290-0x00000001806633E0
	public void ShowPetPanel(); // 0x0000000180663E20-0x0000000180663EC0
	public void HidePetPanel(); // 0x000000018065FDD0-0x000000018065FE70
	public void ShowCardPanel(); // 0x00000001806638D0-0x0000000180663970
	public void HideCardPanel(); // 0x000000018065FC10-0x000000018065FCB0
	private void Update(); // 0x0000000180666070-0x0000000180666230
	public void PrepareGuildBossRoom(); // 0x0000000180661790-0x0000000180661830
	private static bool IsInvitedToGuildRoom(bool isLocal); // 0x0000000180660120-0x00000001806601C0
	public void OpenGuildBossRoomPanel(); // 0x0000000180661240-0x0000000180661320
	public void CancelGuildBossRoom(); // 0x000000018065E620-0x000000018065E690
	public void TearDownRoomUi(); // 0x0000000180664870-0x0000000180664BC0
	public void ApplyRoomModeSkin(); // 0x000000018065DEE0-0x000000018065E070
	private Image RoomBgImage(); // 0x0000000180662590-0x00000001806626A0
	private void ApplyGuildRoomSkin(); // 0x000000018065D9B0-0x000000018065DAF0
	private void RestoreGuildRoomSkin(); // 0x00000001806624D0-0x0000000180662590
	private void SetGuildRoomTitle(bool show); // 0x0000000180662AA0-0x0000000180662FA0
	private static void ApplyGuildRoomTitleLayout(Transform t); // 0x000000018065DAF0-0x000000018065DD20
	private static bool JustCameFromGuildBattle(); // 0x00000001806602B0-0x0000000180660320
	internal static void ClearGuildBattleFlag(); // 0x000000018065E6B0-0x000000018065E730
	private static int GuildBossPetIdFromProps(int fallback); // 0x000000018065F960-0x000000018065FA50
	private bool IsGuildBossRoomNow(); // 0x00000001806600E0-0x0000000180660120
	internal static void OpenGuildBossScreenAfterRoomExit(); // 0x0000000180661320-0x00000001806614A0
	public void OpenRoomPanel(bool isLocal, string roomName); // 0x00000001806614A0-0x00000001806616B0
	[IteratorStateMachine(typeof(_EnsureWsThenOpenRoom_d__86))]
	private IEnumerator EnsureWsThenOpenRoom(bool isLocal, string roomName); // 0x000000018065F660-0x000000018065F700
	private Dictionary<string, object> BuildInitialBossProps(); // 0x000000018065E4F0-0x000000018065E620
	private void ShowLoadingInstant(); // 0x0000000180663C00-0x0000000180663D70
	private void ArmLoadingWatchdog(); // 0x000000018065E290-0x000000018065E350
	[IteratorStateMachine(typeof(_RoomLoadingWatchdogRoutine_d__92))]
	private IEnumerator RoomLoadingWatchdogRoutine(); // 0x00000001806626A0-0x0000000180662710
	public void ShowLoadingImmediate(); // 0x0000000180663BF0-0x0000000180663C00
	private void HideLoadingInstant(); // 0x000000018065FD20-0x000000018065FDD0
	public void HideLoadingFromMatch(); // 0x000000018065FD10-0x000000018065FD20
	[IteratorStateMachine(typeof(_LoadRoomDataWithLoading_d__100))]
	public IEnumerator LoadRoomDataWithLoading(bool alreadyInRoom = false /* Metadata: 0x0068D61C */); // 0x00000001806603A0-0x0000000180660420
	[IteratorStateMachine(typeof(_LoadRoomDataWithoutLoading_d__101))]
	public IEnumerator LoadRoomDataWithoutLoading(); // 0x0000000180660420-0x0000000180660490
	public void ResetRoomHardState(); // 0x0000000180662200-0x0000000180662470
	private void ShowRoomPanelInstant(); // 0x0000000180663F60-0x00000001806640A0
	public void CloseRoomPanel(); // 0x000000018065E770-0x000000018065E940
	[IteratorStateMachine(typeof(_FadeTransition_d__105))]
	private IEnumerator FadeTransition(); // 0x000000018065F700-0x000000018065F770
	public void UpdatePlayerSlots(int mySlotIndex = -1 /* Metadata: 0x0068D61D */); // 0x0000000180665450-0x0000000180666070
	public void ClearCardSyncCache(); // 0x000000018065E690-0x000000018065E6B0
	public void UpdateLocalSelectedCards(); // 0x0000000180664E00-0x0000000180665230
	private static bool ArrayEqualsOrdered(int[] a, int[] b); // 0x000000018065E350-0x000000018065E3D0
	private void EnsurePetsPageSubscription(); // 0x000000018065F550-0x000000018065F660
	[IteratorStateMachine(typeof(_LoadPetsPage_d__115))]
	private IEnumerator LoadPetsPage(int userId, int page); // 0x0000000180660320-0x00000001806603A0
	private void GoToPetPage(int page); // 0x000000018065F8A0-0x000000018065F960
	[IteratorStateMachine(typeof(_PetPageLoop_d__119))]
	private IEnumerator PetPageLoop(); // 0x00000001806616B0-0x0000000180661720
	public void RefreshPetList(); // 0x0000000180661F90-0x0000000180661FA0
	private void DisplayCurrentPetPage(); // 0x000000018065F4A0-0x000000018065F550
	[IteratorStateMachine(typeof(_DisplayCurrentPetPageCoroutine_d__124))]
	private IEnumerator DisplayCurrentPetPageCoroutine(); // 0x000000018065F430-0x000000018065F4A0
	private void HookPetRowPrewarm(GameObject row, string petID); // 0x000000018065FE70-0x00000001806600E0
	private void UpdatePetPaginationButtons(); // 0x0000000180665230-0x00000001806653E0
	private void ShowPreviousPetPage(); // 0x0000000180663EC0-0x0000000180663F60
	private void ShowNextPetPage(); // 0x0000000180663D70-0x0000000180663E20
	private void AnimateButton(Button button); // 0x000000018065D590-0x000000018065D760
	internal void OnRoomReceived(RoomDTO room); // 0x0000000180660BB0-0x0000000180661180
	internal void OnUserReceived(UserDTO user); // 0x00000001806611F0-0x0000000180661240
	public void RequestUpdatePlayerSlots(); // 0x0000000180662170-0x0000000180662200
	[IteratorStateMachine(typeof(_UpdatePlayerSlotsDebounced_d__134))]
	private IEnumerator UpdatePlayerSlotsDebounced(); // 0x00000001806653E0-0x0000000180665450
	private void OnPetClicked(string petIdStr); // 0x0000000180660BA0-0x0000000180660BB0
	private void OnPetClickedInternal(string petIdStr, bool loadAnimation); // 0x0000000180660940-0x0000000180660BA0
	private void ApplyMyPetAnimation(int petId); // 0x000000018065DD20-0x000000018065DEE0
	private static void SetPetRowHighlight(GameObject petRow, bool selected); // 0x0000000180662FA0-0x00000001806630F0
	private void RefreshPetListSelectionHighlight(); // 0x0000000180661C00-0x0000000180661F90
	private static string FormatEnemyPetRoomLabel(RoomDTO room); // 0x000000018065F770-0x000000018065F8A0
	private static int ResolveEnemyPetDisplayLevel(RoomDTO room); // 0x0000000180662470-0x00000001806624D0
	public void OnEnemyPet(string petId); // 0x0000000180660740-0x0000000180660940
	private void ApplyEnemyPetAnimation(string petId); // 0x000000018065D760-0x000000018065D890
	internal void DisplayCardsForSelection(List<CardData> cards); // 0x000000018065F070-0x000000018065F430
	private GameObject CreateCardToggle(CardData card, int index); // 0x000000018065E940-0x000000018065EA60
	private void SetupToggle(GameObject toggleObj, CardData card); // 0x00000001806633E0-0x00000001806638D0
	private GameObject CreateToggleDynamic(CardData card, int index); // 0x000000018065EA60-0x000000018065EFD0
	public void LoadScene(string nameScene); // 0x0000000180660490-0x0000000180660500
	[IteratorStateMachine(typeof(_OnStartBattle_d__151))]
	public IEnumerator OnStartBattle(); // 0x0000000180661180-0x00000001806611F0
	public void StartBattleSequence(); // 0x00000001806640A0-0x0000000180664280
	public void BeginMatchSceneLoad(); // 0x000000018065E3D0-0x000000018065E4F0
	[IteratorStateMachine(typeof(_DelayedLoadScene_d__154))]
	private IEnumerator DelayedLoadScene(string sceneName, float delay); // 0x000000018065EFD0-0x000000018065F070
	[IteratorStateMachine(typeof(_RunPreloadThenFlag_d__155))]
	private IEnumerator RunPreloadThenFlag(Action onDone); // 0x0000000180662710-0x00000001806627A0
	[IteratorStateMachine(typeof(_PreloadMatchData_d__156))]
	private IEnumerator PreloadMatchData(); // 0x0000000180661720-0x0000000180661790
	private static void PrewarmTeammatePets(int myPetId); // 0x0000000180661830-0x00000001806619C0
	public void ShowEnergyWarning(); // 0x0000000180663970-0x0000000180663BF0
	private void HideEnergyWarning(); // 0x000000018065FCB0-0x000000018065FD10
	public void ClearSelectedCardsState(); // 0x000000018065E730-0x000000018065E770
	private void ReplaceAnimations(AnimationClip[] newClips, string petId); // 0x0000000180662090-0x0000000180662170
	public void SetEnemyPetFromProps(int enemyPetId, string enemyPetName, int enemyPetLevel = 0 /* Metadata: 0x0068D61E */); // 0x00000001806628F0-0x0000000180662AA0
	private void ReplaceAnimationsEnemyPet(AnimationClip[] newClips, string petId); // 0x0000000180661FA0-0x0000000180662090
	private void OnError(string error); // 0x000000018065FD10-0x000000018065FD20
	private void OnDestroy(); // 0x0000000180660500-0x0000000180660740
	[CompilerGenerated]
	private void _EnsurePetsPageSubscription_b__114_0(PetsPaginatedDataDTO d); // 0x0000000180664D60-0x0000000180664DA0
	[CompilerGenerated]
	private void _ShowEnergyWarning_b__158_0(); // 0x0000000180664DA0-0x0000000180664E00
}

