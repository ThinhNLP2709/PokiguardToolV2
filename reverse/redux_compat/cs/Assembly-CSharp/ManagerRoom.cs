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

public class ManagerRoom : MonoBehaviour // TypeDefIndex: 1468
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
	private const int PETS_PER_PAGE = 18; // Metadata: 0x0064D6F4
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
	private const float LOADING_WATCHDOG_SEC = 25f; // Metadata: 0x0064D6F5
	private Coroutine _roomLoadingWatchdogCo; // 0x128
	[CompilerGenerated]
	private bool _IsOpeningRoomFlow_k__BackingField; // 0x130
	private int[] _lastSyncedCardIds; // 0x138
	private Coroutine _displayPetPageCoroutine; // 0x140
	private bool _updatePlayerSlotsPending; // 0x148
	private int _myPetAnimToken; // 0x14C
	private int _enemyPetAnimToken; // 0x150

	// Properties
	public bool IsOpeningRoomFlow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805580E0-0x00000001805580F0 0x00000001805580F0-0x0000000180558100

	// Nested types
	[Serializable]
	public class PetPageResponse // TypeDefIndex: 1469
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
	private sealed class __c // TypeDefIndex: 1470
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__70_1; // 0x08
		public static Func<CardData, int> __9__78_0; // 0x10

		// Constructors
		static __c(); // 0x0000000180562DA0-0x0000000180562E10
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadRoomDataWithoutLoading_b__70_1(string e); // 0x0000000180560B70-0x0000000180560BE0
		internal int _UpdateLocalSelectedCards_b__78_0(CardData c); // 0x000000018030F1E0-0x000000018030F200
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass104_0 // TypeDefIndex: 1471
	{
		// Fields
		public int token; // 0x10
		public ManagerRoom __4__this; // 0x18
		public string petId; // 0x20

		// Constructors
		public __c__DisplayClass104_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ApplyEnemyPetAnimation_b__0(AnimationClip[] clips); // 0x0000000180561AB0-0x0000000180561C80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass113_0 // TypeDefIndex: 1472
	{
		// Fields
		public bool preloadDone; // 0x10

		// Constructors
		public __c__DisplayClass113_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DelayedLoadScene_b__0(); // 0x000000018030F220-0x000000018030F230
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass115_0 // TypeDefIndex: 1473
	{
		// Fields
		public bool failed; // 0x10
		public PetUserDTO myPet; // 0x18
		public PetUserDTO enemyPet; // 0x20
		public UserDTO user; // 0x28

		// Constructors
		public __c__DisplayClass115_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PreloadMatchData_b__0(MatchPrepDataDTO data); // 0x0000000180561C80-0x0000000180561CF0
		internal void _PreloadMatchData_b__1(string err); // 0x0000000180561CF0-0x0000000180561D70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass69_0 // TypeDefIndex: 1474
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
		public __c__DisplayClass69_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadRoomDataWithLoading_b__0(); // 0x0000000180562840-0x00000001805629C0
		internal void _LoadRoomDataWithLoading_b__3(); // 0x00000001805629F0-0x0000000180562A00
		internal void _LoadRoomDataWithLoading_b__4(string e); // 0x0000000180562A00-0x0000000180562AB0
		internal void _LoadRoomDataWithLoading_b__1(string r); // 0x00000001805629C0-0x00000001805629E0
		internal void _LoadRoomDataWithLoading_b__2(string _); // 0x00000001805629E0-0x00000001805629F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass70_0 // TypeDefIndex: 1475
	{
		// Fields
		public bool cacheLoaded; // 0x10

		// Constructors
		public __c__DisplayClass70_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadRoomDataWithoutLoading_b__0(); // 0x000000018030F220-0x000000018030F230
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass80_0 // TypeDefIndex: 1476
	{
		// Fields
		public bool done; // 0x10
		public PetsPaginatedDataDTO wsData; // 0x18

		// Constructors
		public __c__DisplayClass80_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadPetsPage_b__0(PetsPaginatedDataDTO d); // 0x00000001802FB060-0x00000001802FB080
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass84_0 // TypeDefIndex: 1477
	{
		// Fields
		public string petID; // 0x10
		public ManagerRoom __4__this; // 0x18

		// Constructors
		public __c__DisplayClass84_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DisplayCurrentPetPageCoroutine_b__0(); // 0x0000000180562AB0-0x0000000180562AE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass88_0 // TypeDefIndex: 1478
	{
		// Fields
		public Button button; // 0x10

		// Constructors
		public __c__DisplayClass88_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AnimateButton_b__0(); // 0x0000000180562AE0-0x0000000180562BD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass97_0 // TypeDefIndex: 1479
	{
		// Fields
		public int token; // 0x10
		public ManagerRoom __4__this; // 0x18
		public int petId; // 0x20

		// Constructors
		public __c__DisplayClass97_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ApplyMyPetAnimation_b__0(AnimationClip[] clips); // 0x0000000180562BD0-0x0000000180562DA0
	}

	[CompilerGenerated]
	private sealed class _DelayedLoadScene_d__113 : IEnumerator<object> // TypeDefIndex: 1480
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		private __c__DisplayClass113_0 __8__1; // 0x28
		public ManagerRoom __4__this; // 0x30
		public string sceneName; // 0x38
		private float _preloadStart_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DelayedLoadScene_d__113(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018055A430-0x000000018055A720
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055A720-0x000000018055A760
	}

	[CompilerGenerated]
	private sealed class _DisplayCurrentPetPageCoroutine_d__84 : IEnumerator<object> // TypeDefIndex: 1481
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private int _listSelUserPetId_5__2; // 0x28
		private PetUserDTO[] _pets_5__3; // 0x30
		private int _i_5__4; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DisplayCurrentPetPageCoroutine_d__84(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x00000001805795A0-0x0000000180579E40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180579E40-0x0000000180579E80
	}

	[CompilerGenerated]
	private sealed class _EnsureWsThenOpenRoom_d__55 : IEnumerator<object> // TypeDefIndex: 1482
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _EnsureWsThenOpenRoom_d__55(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x0000000180579E80-0x000000018057A440
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057A440-0x000000018057A480
	}

	[CompilerGenerated]
	private sealed class _FadeTransition_d__74 : IEnumerator<object> // TypeDefIndex: 1483
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FadeTransition_d__74(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018057A480-0x000000018057A750
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057A750-0x000000018057A790
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__80 : IEnumerator<object> // TypeDefIndex: 1484
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int page; // 0x20
		private __c__DisplayClass80_0 __8__1; // 0x28
		public ManagerRoom __4__this; // 0x30
		private Action<PetsPaginatedDataDTO> _onResp_5__2; // 0x38
		private float _deadline_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetsPage_d__80(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018057B200-0x000000018057B240
		private bool MoveNext(); // 0x000000018057ACD0-0x000000018057B1C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057B1C0-0x000000018057B200
	}

	[CompilerGenerated]
	private sealed class _LoadRoomDataWithLoading_d__69 : IEnumerator<object> // TypeDefIndex: 1485
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private __c__DisplayClass69_0 __8__1; // 0x28
		private int _userId_5__2; // 0x30
		private Action _startCacheLoad_5__3; // 0x38
		private float _joinWaitStart_5__4; // 0x40
		private WsRoomService _wsRoomWait_5__5; // 0x48
		private Action<string> _onWsEnterFailed_5__6; // 0x50
		private Action<string> _onWsEntered_5__7; // 0x58

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoomDataWithLoading_d__69(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018057BD70-0x000000018057BDE0
		private bool MoveNext(); // 0x000000018057B240-0x000000018057BD30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057BD30-0x000000018057BD70
	}

	[CompilerGenerated]
	private sealed class _LoadRoomDataWithoutLoading_d__70 : IEnumerator<object> // TypeDefIndex: 1486
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private __c__DisplayClass70_0 __8__1; // 0x20
		public ManagerRoom __4__this; // 0x28
		private int _userId_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoomDataWithoutLoading_d__70(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BE030-0x00000001803BE060
		private bool MoveNext(); // 0x000000018057BDE0-0x000000018057C300
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057C300-0x000000018057C340
	}

	[CompilerGenerated]
	private sealed class _OnStartBattle_d__110 : IEnumerator<object> // TypeDefIndex: 1487
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OnStartBattle_d__110(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018057C340-0x000000018057C510
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057C510-0x000000018057C550
	}

	[CompilerGenerated]
	private sealed class _PreloadMatchData_d__115 : IEnumerator<object> // TypeDefIndex: 1488
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private __c__DisplayClass115_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PreloadMatchData_d__115(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018057CA50-0x000000018057D190
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057D190-0x000000018057D1D0
	}

	[CompilerGenerated]
	private sealed class _RoomLoadingWatchdogRoutine_d__61 : IEnumerator<object> // TypeDefIndex: 1489
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private float _deadline_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RoomLoadingWatchdogRoutine_d__61(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018057D390-0x000000018057D600
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057D600-0x000000018057D640
	}

	[CompilerGenerated]
	private sealed class _RunPreloadThenFlag_d__114 : IEnumerator<object> // TypeDefIndex: 1490
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		public Action onDone; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RunPreloadThenFlag_d__114(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018057D640-0x000000018057D6C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057D6C0-0x000000018057D700
	}

	[CompilerGenerated]
	private sealed class _UpdatePlayerSlotsDebounced_d__93 : IEnumerator<object> // TypeDefIndex: 1491
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UpdatePlayerSlotsDebounced_d__93(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018057E350-0x000000018057E3C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057E3C0-0x000000018057E400
	}

	// Constructors
	public ManagerRoom(); // 0x0000000180558050-0x00000001805580E0

	// Methods
	private void Start(); // 0x0000000180556550-0x0000000180556B20
	private static bool IsReturningFromMatch(); // 0x0000000180553210-0x0000000180553300
	internal void ApplyWsEnemyPetFromProperties(); // 0x0000000180551700-0x0000000180551A70
	private void HandleUserEnergyDelta(ChatMessageDTO msg); // 0x0000000180552E30-0x0000000180552FB0
	private void SetupCardSelection(); // 0x00000001805553D0-0x0000000180555570
	private void HandleCardSelectionChanged(); // 0x0000000180552DF0-0x0000000180552E30
	internal void SaveSelectedCardsToPrefs(); // 0x0000000180554FA0-0x00000001805550F0
	private void TryRestoreSelectedCards(bool syncAfter); // 0x0000000180556B20-0x0000000180556CA0
	private static List<int> ReadSavedCardIds(); // 0x0000000180554320-0x0000000180554560
	private void SetupPetPagination(); // 0x0000000180555570-0x00000001805556C0
	public void ShowPetPanel(); // 0x0000000180556130-0x00000001805561D0
	public void HidePetPanel(); // 0x0000000180553170-0x0000000180553210
	public void ShowCardPanel(); // 0x0000000180555BB0-0x0000000180555C50
	public void HideCardPanel(); // 0x0000000180552FB0-0x0000000180553050
	private void Update(); // 0x0000000180557E90-0x0000000180558050
	public void OpenRoomPanel(bool isLocal, string roomName); // 0x0000000180553FF0-0x0000000180554120
	[IteratorStateMachine(typeof(_EnsureWsThenOpenRoom_d__55))]
	private IEnumerator EnsureWsThenOpenRoom(bool isLocal, string roomName); // 0x0000000180552BD0-0x0000000180552C70
	private Dictionary<string, object> BuildInitialBossProps(); // 0x0000000180551CD0-0x0000000180551E00
	private void ShowLoadingInstant(); // 0x0000000180555EE0-0x0000000180556050
	private void ArmLoadingWatchdog(); // 0x0000000180551A70-0x0000000180551B30
	[IteratorStateMachine(typeof(_RoomLoadingWatchdogRoutine_d__61))]
	private IEnumerator RoomLoadingWatchdogRoutine(); // 0x0000000180554EA0-0x0000000180554F10
	public void ShowLoadingImmediate(); // 0x0000000180555ED0-0x0000000180555EE0
	private void HideLoadingInstant(); // 0x00000001805530C0-0x0000000180553170
	public void HideLoadingFromMatch(); // 0x00000001805530B0-0x00000001805530C0
	[IteratorStateMachine(typeof(_LoadRoomDataWithLoading_d__69))]
	public IEnumerator LoadRoomDataWithLoading(); // 0x0000000180553380-0x00000001805533F0
	[IteratorStateMachine(typeof(_LoadRoomDataWithoutLoading_d__70))]
	public IEnumerator LoadRoomDataWithoutLoading(); // 0x00000001805533F0-0x0000000180553460
	public void ResetRoomHardState(); // 0x0000000180554BD0-0x0000000180554E40
	private void ShowRoomPanelInstant(); // 0x00000001805562B0-0x0000000180556370
	public void CloseRoomPanel(); // 0x0000000180551E60-0x0000000180551FC0
	[IteratorStateMachine(typeof(_FadeTransition_d__74))]
	private IEnumerator FadeTransition(); // 0x0000000180552C70-0x0000000180552CE0
	public void UpdatePlayerSlots(int mySlotIndex = -1 /* Metadata: 0x0064D6F2 */); // 0x0000000180557330-0x0000000180557E90
	public void ClearCardSyncCache(); // 0x0000000180551E00-0x0000000180551E20
	public void UpdateLocalSelectedCards(); // 0x0000000180556D00-0x0000000180557110
	private static bool ArrayEqualsOrdered(int[] a, int[] b); // 0x0000000180551B30-0x0000000180551BB0
	[IteratorStateMachine(typeof(_LoadPetsPage_d__80))]
	private IEnumerator LoadPetsPage(int userId, int page); // 0x0000000180553300-0x0000000180553380
	public void RefreshPetList(); // 0x00000001805548C0-0x0000000180554970
	private void DisplayCurrentPetPage(); // 0x0000000180552B20-0x0000000180552BD0
	[IteratorStateMachine(typeof(_DisplayCurrentPetPageCoroutine_d__84))]
	private IEnumerator DisplayCurrentPetPageCoroutine(); // 0x0000000180552AB0-0x0000000180552B20
	private void UpdatePetPaginationButtons(); // 0x0000000180557110-0x00000001805572C0
	private void ShowPreviousPetPage(); // 0x00000001805561D0-0x00000001805562B0
	private void ShowNextPetPage(); // 0x0000000180556050-0x0000000180556130
	private void AnimateButton(Button button); // 0x0000000180551240-0x0000000180551410
	internal void OnRoomReceived(RoomDTO room); // 0x0000000180553B50-0x0000000180553F30
	internal void OnUserReceived(UserDTO user); // 0x0000000180553FA0-0x0000000180553FF0
	public void RequestUpdatePlayerSlots(); // 0x0000000180554B40-0x0000000180554BD0
	[IteratorStateMachine(typeof(_UpdatePlayerSlotsDebounced_d__93))]
	private IEnumerator UpdatePlayerSlotsDebounced(); // 0x00000001805572C0-0x0000000180557330
	private void OnPetClicked(string petIdStr); // 0x0000000180553B40-0x0000000180553B50
	private void OnPetClickedInternal(string petIdStr, bool loadAnimation); // 0x00000001805538D0-0x0000000180553B40
	private void ApplyMyPetAnimation(int petId); // 0x0000000180551540-0x0000000180551700
	private static void SetPetRowHighlight(GameObject petRow, bool selected); // 0x0000000180555280-0x00000001805553D0
	private void RefreshPetListSelectionHighlight(); // 0x0000000180554560-0x00000001805548C0
	private static string FormatEnemyPetRoomLabel(RoomDTO room); // 0x0000000180552CE0-0x0000000180552DF0
	private static int ResolveEnemyPetDisplayLevel(RoomDTO room); // 0x0000000180554E40-0x0000000180554EA0
	public void OnEnemyPet(string petId); // 0x00000001805536D0-0x00000001805538D0
	private void ApplyEnemyPetAnimation(string petId); // 0x0000000180551410-0x0000000180551540
	internal void DisplayCardsForSelection(List<CardData> cards); // 0x00000001805526F0-0x0000000180552AB0
	private GameObject CreateCardToggle(CardData card, int index); // 0x0000000180551FC0-0x00000001805520E0
	private void SetupToggle(GameObject toggleObj, CardData card); // 0x00000001805556C0-0x0000000180555BB0
	private GameObject CreateToggleDynamic(CardData card, int index); // 0x00000001805520E0-0x0000000180552650
	public void LoadScene(string nameScene); // 0x0000000180553460-0x00000001805534D0
	[IteratorStateMachine(typeof(_OnStartBattle_d__110))]
	public IEnumerator OnStartBattle(); // 0x0000000180553F30-0x0000000180553FA0
	public void StartBattleSequence(); // 0x0000000180556370-0x0000000180556550
	public void BeginMatchSceneLoad(); // 0x0000000180551BB0-0x0000000180551CD0
	[IteratorStateMachine(typeof(_DelayedLoadScene_d__113))]
	private IEnumerator DelayedLoadScene(string sceneName, float delay); // 0x0000000180552650-0x00000001805526F0
	[IteratorStateMachine(typeof(_RunPreloadThenFlag_d__114))]
	private IEnumerator RunPreloadThenFlag(Action onDone); // 0x0000000180554F10-0x0000000180554FA0
	[IteratorStateMachine(typeof(_PreloadMatchData_d__115))]
	private IEnumerator PreloadMatchData(); // 0x0000000180554120-0x0000000180554190
	private static void PrewarmTeammatePets(int myPetId); // 0x0000000180554190-0x0000000180554320
	public void ShowEnergyWarning(); // 0x0000000180555C50-0x0000000180555ED0
	private void HideEnergyWarning(); // 0x0000000180553050-0x00000001805530B0
	public void ClearSelectedCardsState(); // 0x0000000180551E20-0x0000000180551E60
	private void ReplaceAnimations(AnimationClip[] newClips, string petId); // 0x0000000180554A60-0x0000000180554B40
	public void SetEnemyPetFromProps(int enemyPetId, string enemyPetName, int enemyPetLevel = 0 /* Metadata: 0x0064D6F3 */); // 0x00000001805550F0-0x0000000180555280
	private void ReplaceAnimationsEnemyPet(AnimationClip[] newClips, string petId); // 0x0000000180554970-0x0000000180554A60
	private void OnError(string error); // 0x00000001805530B0-0x00000001805530C0
	private void OnDestroy(); // 0x00000001805534D0-0x00000001805536D0
	[CompilerGenerated]
	private void _ShowEnergyWarning_b__117_0(); // 0x0000000180556CA0-0x0000000180556D00
}

