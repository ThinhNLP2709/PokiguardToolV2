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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ManagerRoom : MonoBehaviour // TypeDefIndex: 2079
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
	private const int PETS_PER_PAGE = 18; // Metadata: 0x005F1865
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
	private const float LOADING_WATCHDOG_SEC = 25f; // Metadata: 0x005F1866
	private Coroutine _roomLoadingWatchdogCo; // 0x128
	[CompilerGenerated]
	private bool _IsOpeningRoomFlow_k__BackingField; // 0x130
	private int[] _lastSyncedCardIds; // 0x138
	private Action<PetsPaginatedDataDTO> _petsPageHandler; // 0x140
	private PetsPaginatedDataDTO _petsPageData; // 0x148
	private bool _petsPageReady; // 0x150
	private int _requestedPetPage; // 0x154
	private bool _petPageLoading; // 0x158
	private Coroutine _displayPetPageCoroutine; // 0x160
	private const int PET_RESIDENT_BUDGET = 12; // Metadata: 0x005F186A
	private bool _updatePlayerSlotsPending; // 0x168
	private int _myPetAnimToken; // 0x16C
	private int _enemyPetAnimToken; // 0x170

	// Properties
	public bool IsOpeningRoomFlow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001809E8D60-0x00000001809E8D70 0x00000001809E8D70-0x00000001809E8D80

	// Nested types
	[Serializable]
	public class PetPageResponse // TypeDefIndex: 2080
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
	private sealed class __c // TypeDefIndex: 2081
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__71_1; // 0x08
		public static Func<CardData, int> __9__79_0; // 0x10

		// Constructors
		static __c(); // 0x00000001809F1240-0x00000001809F12E0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRoomDataWithoutLoading_b__71_1(string e); // 0x00000001809F12E0-0x00000001809F1360
		internal int _UpdateLocalSelectedCards_b__79_0(CardData c); // 0x0000000180475D50-0x0000000180475D70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass108_0 // TypeDefIndex: 2082
	{
		// Fields
		public int token; // 0x10
		public ManagerRoom __4__this; // 0x18
		public int petId; // 0x20

		// Constructors
		public __c__DisplayClass108_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ApplyMyPetAnimation_b__0(AnimationClip[] clips); // 0x00000001809F1360-0x00000001809F1650
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass115_0 // TypeDefIndex: 2083
	{
		// Fields
		public int token; // 0x10
		public ManagerRoom __4__this; // 0x18
		public string petId; // 0x20

		// Constructors
		public __c__DisplayClass115_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ApplyEnemyPetAnimation_b__0(AnimationClip[] clips); // 0x00000001809F1650-0x00000001809F1940
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass124_0 // TypeDefIndex: 2084
	{
		// Fields
		public bool preloadDone; // 0x10

		// Constructors
		public __c__DisplayClass124_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DelayedLoadScene_b__0(); // 0x0000000180308BD0-0x0000000180308BE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass126_0 // TypeDefIndex: 2085
	{
		// Fields
		public bool failed; // 0x10
		public PetUserDTO myPet; // 0x18
		public PetUserDTO enemyPet; // 0x20
		public UserDTO user; // 0x28

		// Constructors
		public __c__DisplayClass126_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PreloadMatchData_b__0(MatchPrepDataDTO data); // 0x00000001809F1940-0x00000001809F1A60
		internal void _PreloadMatchData_b__1(string err); // 0x00000001809F1A60-0x00000001809F1AF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass70_0 // TypeDefIndex: 2086
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
		public __c__DisplayClass70_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRoomDataWithLoading_b__0(); // 0x00000001809F1AF0-0x00000001809F1D30
		internal void _LoadRoomDataWithLoading_b__3(); // 0x00000001809F1D30-0x00000001809F1D40
		internal void _LoadRoomDataWithLoading_b__4(string e); // 0x00000001809F1D40-0x00000001809F1E70
		internal void _LoadRoomDataWithLoading_b__1(string r); // 0x00000001809F1E70-0x00000001809F1ED0
		internal void _LoadRoomDataWithLoading_b__2(string _); // 0x00000001809F1ED0-0x00000001809F1EE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass71_0 // TypeDefIndex: 2087
	{
		// Fields
		public bool cacheLoaded; // 0x10

		// Constructors
		public __c__DisplayClass71_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRoomDataWithoutLoading_b__0(); // 0x0000000180308BD0-0x0000000180308BE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass94_0 // TypeDefIndex: 2088
	{
		// Fields
		public string petID; // 0x10
		public ManagerRoom __4__this; // 0x18

		// Constructors
		public __c__DisplayClass94_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DisplayCurrentPetPageCoroutine_b__0(); // 0x00000001809F1EE0-0x00000001809F1F10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass95_0 // TypeDefIndex: 2089
	{
		// Fields
		public string petID; // 0x10

		// Constructors
		public __c__DisplayClass95_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _HookPetRowPrewarm_b__0(BaseEventData _); // 0x00000001809F1F10-0x00000001809F1FD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass99_0 // TypeDefIndex: 2090
	{
		// Fields
		public Button button; // 0x10

		// Constructors
		public __c__DisplayClass99_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateButton_b__0(); // 0x00000001809F1FD0-0x00000001809F2150
	}

	[CompilerGenerated]
	private sealed class _DelayedLoadScene_d__124 : IEnumerator<object> // TypeDefIndex: 2091
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		private __c__DisplayClass124_0 __8__1; // 0x28
		public ManagerRoom __4__this; // 0x30
		public string sceneName; // 0x38
		private float _preloadStart_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DelayedLoadScene_d__124(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001809F2150-0x00000001809F2690
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F2690-0x00000001809F26D0
	}

	[CompilerGenerated]
	private sealed class _DisplayCurrentPetPageCoroutine_d__94 : IEnumerator<object> // TypeDefIndex: 2092
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private int _listSelUserPetId_5__2; // 0x28
		private PetUserDTO[] _pets_5__3; // 0x30
		private int _i_5__4; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisplayCurrentPetPageCoroutine_d__94(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001809F26D0-0x00000001809F35A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F35A0-0x00000001809F35E0
	}

	[CompilerGenerated]
	private sealed class _EnsureWsThenOpenRoom_d__56 : IEnumerator<object> // TypeDefIndex: 2093
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _EnsureWsThenOpenRoom_d__56(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x00000001809F35E0-0x00000001809F41A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F41A0-0x00000001809F41E0
	}

	[CompilerGenerated]
	private sealed class _FadeTransition_d__75 : IEnumerator<object> // TypeDefIndex: 2094
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FadeTransition_d__75(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809F41E0-0x00000001809F4760
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F4760-0x00000001809F47A0
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__85 : IEnumerator<object> // TypeDefIndex: 2095
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		public int page; // 0x28
		private float _deadline_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetsPage_d__85(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809F47A0-0x00000001809F4EC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F4EC0-0x00000001809F4F00
	}

	[CompilerGenerated]
	private sealed class _LoadRoomDataWithLoading_d__70 : IEnumerator<object> // TypeDefIndex: 2096
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		public bool alreadyInRoom; // 0x28
		private __c__DisplayClass70_0 __8__1; // 0x30
		private Action _startCacheLoad_5__2; // 0x38
		private float _joinWaitStart_5__3; // 0x40
		private WsRoomService _wsRoomWait_5__4; // 0x48
		private Action<string> _onWsEnterFailed_5__5; // 0x50
		private Action<string> _onWsEntered_5__6; // 0x58

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoomDataWithLoading_d__70(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001809F4F00-0x00000001809F50B0
		private bool MoveNext(); // 0x00000001809F50B0-0x00000001809F6390
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F6390-0x00000001809F63D0
	}

	[CompilerGenerated]
	private sealed class _LoadRoomDataWithoutLoading_d__71 : IEnumerator<object> // TypeDefIndex: 2097
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private __c__DisplayClass71_0 __8__1; // 0x20
		public ManagerRoom __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoomDataWithoutLoading_d__71(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805EFDE0-0x00000001805EFE50
		private bool MoveNext(); // 0x00000001809F63D0-0x00000001809F69E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F69E0-0x00000001809F6A20
	}

	[CompilerGenerated]
	private sealed class _OnStartBattle_d__121 : IEnumerator<object> // TypeDefIndex: 2098
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _OnStartBattle_d__121(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809F6A20-0x00000001809F6D00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F6D00-0x00000001809F6D40
	}

	[CompilerGenerated]
	private sealed class _PetPageLoop_d__89 : IEnumerator<object> // TypeDefIndex: 2099
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private int _userId_5__2; // 0x28
		private int _guard_5__3; // 0x2C
		private int _want_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PetPageLoop_d__89(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809F6D40-0x00000001809F6F20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F6F20-0x00000001809F6F60
	}

	[CompilerGenerated]
	private sealed class _PreloadMatchData_d__126 : IEnumerator<object> // TypeDefIndex: 2100
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private __c__DisplayClass126_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PreloadMatchData_d__126(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001809F6F60-0x00000001809F76A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F76A0-0x00000001809F76E0
	}

	[CompilerGenerated]
	private sealed class _RoomLoadingWatchdogRoutine_d__62 : IEnumerator<object> // TypeDefIndex: 2101
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		private float _deadline_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RoomLoadingWatchdogRoutine_d__62(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809F76E0-0x00000001809F7C70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F7C70-0x00000001809F7CB0
	}

	[CompilerGenerated]
	private sealed class _RunPreloadThenFlag_d__125 : IEnumerator<object> // TypeDefIndex: 2102
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20
		public Action onDone; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RunPreloadThenFlag_d__125(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809F7CB0-0x00000001809F7E00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F7E00-0x00000001809F7E40
	}

	[CompilerGenerated]
	private sealed class _UpdatePlayerSlotsDebounced_d__104 : IEnumerator<object> // TypeDefIndex: 2103
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpdatePlayerSlotsDebounced_d__104(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809F7E40-0x00000001809F7F00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F7F00-0x00000001809F7F40
	}

	// Constructors
	public ManagerRoom(); // 0x00000001809F1050-0x00000001809F1160

	// Methods
	private void Start(); // 0x00000001809E5650-0x00000001809E5D20
	private static bool IsReturningFromMatch(); // 0x00000001809E5D20-0x00000001809E5E40
	internal void ApplyWsEnemyPetFromProperties(); // 0x00000001809E5E40-0x00000001809E6300
	private void HandleUserEnergyDelta(ChatMessageDTO msg); // 0x00000001809E6300-0x00000001809E64E0
	private void SetupCardSelection(); // 0x00000001809E64E0-0x00000001809E6930
	private void HandleCardSelectionChanged(); // 0x00000001809E6930-0x00000001809E69A0
	internal void SaveSelectedCardsToPrefs(); // 0x00000001809E69A0-0x00000001809E6C00
	private void TryRestoreSelectedCards(bool syncAfter); // 0x00000001809E6C00-0x00000001809E6E00
	private static List<int> ReadSavedCardIds(); // 0x00000001809E6E00-0x00000001809E70E0
	private void SetupPetPagination(); // 0x00000001809E70E0-0x00000001809E7340
	public void ShowPetPanel(); // 0x00000001809E7340-0x00000001809E7460
	public void HidePetPanel(); // 0x00000001809E7460-0x00000001809E7580
	public void ShowCardPanel(); // 0x00000001809E7580-0x00000001809E76A0
	public void HideCardPanel(); // 0x00000001809E76A0-0x00000001809E77C0
	private void Update(); // 0x00000001809E77C0-0x00000001809E7A70
	public void TearDownRoomUi(); // 0x00000001809E7A70-0x00000001809E8290
	public void OpenRoomPanel(bool isLocal, string roomName); // 0x00000001809E8290-0x00000001809E8510
	[IteratorStateMachine(typeof(_EnsureWsThenOpenRoom_d__56))]
	private IEnumerator EnsureWsThenOpenRoom(bool isLocal, string roomName); // 0x00000001809E8510-0x00000001809E8620
	private Dictionary<string, object> BuildInitialBossProps(); // 0x00000001809E8620-0x00000001809E87B0
	private void ShowLoadingInstant(); // 0x00000001809E87B0-0x00000001809E8B20
	private void ArmLoadingWatchdog(); // 0x00000001809E8B20-0x00000001809E8CC0
	[IteratorStateMachine(typeof(_RoomLoadingWatchdogRoutine_d__62))]
	private IEnumerator RoomLoadingWatchdogRoutine(); // 0x00000001809E8CC0-0x00000001809E8D60
	public void ShowLoadingImmediate(); // 0x00000001809E8D80-0x00000001809E8D90
	private void HideLoadingInstant(); // 0x00000001809E8D90-0x00000001809E8F50
	public void HideLoadingFromMatch(); // 0x00000001809E8F50-0x00000001809E8F60
	[IteratorStateMachine(typeof(_LoadRoomDataWithLoading_d__70))]
	public IEnumerator LoadRoomDataWithLoading(bool alreadyInRoom = false /* Metadata: 0x005F1862 */); // 0x00000001809E8F60-0x00000001809E9010
	[IteratorStateMachine(typeof(_LoadRoomDataWithoutLoading_d__71))]
	public IEnumerator LoadRoomDataWithoutLoading(); // 0x00000001809E9010-0x00000001809E90B0
	public void ResetRoomHardState(); // 0x00000001809E90B0-0x00000001809E93D0
	private void ShowRoomPanelInstant(); // 0x00000001809E93D0-0x00000001809E9640
	public void CloseRoomPanel(); // 0x00000001809E9640-0x00000001809E9900
	[IteratorStateMachine(typeof(_FadeTransition_d__75))]
	private IEnumerator FadeTransition(); // 0x00000001809E9900-0x00000001809E99A0
	public void UpdatePlayerSlots(int mySlotIndex = -1 /* Metadata: 0x005F1863 */); // 0x00000001809E99A0-0x00000001809EA7F0
	public void ClearCardSyncCache(); // 0x00000001809EA7F0-0x00000001809EA850
	public void UpdateLocalSelectedCards(); // 0x00000001809EA850-0x00000001809EADF0
	private static bool ArrayEqualsOrdered(int[] a, int[] b); // 0x00000001809EADF0-0x00000001809EAE70
	private void EnsurePetsPageSubscription(); // 0x00000001809EAE70-0x00000001809EB050
	[IteratorStateMachine(typeof(_LoadPetsPage_d__85))]
	private IEnumerator LoadPetsPage(int userId, int page); // 0x00000001809EB050-0x00000001809EB100
	private void GoToPetPage(int page); // 0x00000001809EB100-0x00000001809EB1F0
	[IteratorStateMachine(typeof(_PetPageLoop_d__89))]
	private IEnumerator PetPageLoop(); // 0x00000001809EB1F0-0x00000001809EB290
	public void RefreshPetList(); // 0x00000001809EB290-0x00000001809EB2A0
	private void DisplayCurrentPetPage(); // 0x00000001809EB2A0-0x00000001809EB3D0
	[IteratorStateMachine(typeof(_DisplayCurrentPetPageCoroutine_d__94))]
	private IEnumerator DisplayCurrentPetPageCoroutine(); // 0x00000001809EB3D0-0x00000001809EB470
	private void HookPetRowPrewarm(GameObject row, string petID); // 0x00000001809EB470-0x00000001809EB830
	private void UpdatePetPaginationButtons(); // 0x00000001809EB830-0x00000001809EBB70
	private void ShowPreviousPetPage(); // 0x00000001809EBB70-0x00000001809EBCA0
	private void ShowNextPetPage(); // 0x00000001809EBCA0-0x00000001809EBDD0
	private void AnimateButton(Button button); // 0x00000001809EBDD0-0x00000001809EC0C0
	internal void OnRoomReceived(RoomDTO room); // 0x00000001809EC0C0-0x00000001809EC7B0
	internal void OnUserReceived(UserDTO user); // 0x00000001809EC7B0-0x00000001809EC840
	public void RequestUpdatePlayerSlots(); // 0x00000001809EC840-0x00000001809EC900
	[IteratorStateMachine(typeof(_UpdatePlayerSlotsDebounced_d__104))]
	private IEnumerator UpdatePlayerSlotsDebounced(); // 0x00000001809EC900-0x00000001809EC9A0
	private void OnPetClicked(string petIdStr); // 0x00000001809EC9A0-0x00000001809EC9B0
	private void OnPetClickedInternal(string petIdStr, bool loadAnimation); // 0x00000001809EC9B0-0x00000001809ECB40
	private void ApplyMyPetAnimation(int petId); // 0x00000001809ECB40-0x00000001809ECDA0
	private static void SetPetRowHighlight(GameObject petRow, bool selected); // 0x00000001809ECDA0-0x00000001809ED140
	private void RefreshPetListSelectionHighlight(); // 0x00000001809ED140-0x00000001809ED540
	private static string FormatEnemyPetRoomLabel(RoomDTO room); // 0x00000001809ED540-0x00000001809ED690
	private static int ResolveEnemyPetDisplayLevel(RoomDTO room); // 0x00000001809ED690-0x00000001809ED700
	public void OnEnemyPet(string petId); // 0x00000001809ED700-0x00000001809ED910
	private void ApplyEnemyPetAnimation(string petId); // 0x00000001809ED910-0x00000001809EDAE0
	internal void DisplayCardsForSelection(List<CardData> cards); // 0x00000001809EDAE0-0x00000001809EE1C0
	private GameObject CreateCardToggle(CardData card, int index); // 0x00000001809EE1C0-0x00000001809EE370
	private void SetupToggle(GameObject toggleObj, CardData card); // 0x00000001809EE370-0x00000001809EEAB0
	private GameObject CreateToggleDynamic(CardData card, int index); // 0x00000001809EEAB0-0x00000001809EF480
	public void LoadScene(string nameScene); // 0x00000001809EF480-0x00000001809EF4F0
	[IteratorStateMachine(typeof(_OnStartBattle_d__121))]
	public IEnumerator OnStartBattle(); // 0x00000001809EF4F0-0x00000001809EF590
	public void StartBattleSequence(); // 0x00000001809EF590-0x00000001809EF7D0
	public void BeginMatchSceneLoad(); // 0x00000001809EF7D0-0x00000001809EF9B0
	[IteratorStateMachine(typeof(_DelayedLoadScene_d__124))]
	private IEnumerator DelayedLoadScene(string sceneName, float delay); // 0x00000001809EF9B0-0x00000001809EFAD0
	[IteratorStateMachine(typeof(_RunPreloadThenFlag_d__125))]
	private IEnumerator RunPreloadThenFlag(Action onDone); // 0x00000001809EFAD0-0x00000001809EFBE0
	[IteratorStateMachine(typeof(_PreloadMatchData_d__126))]
	private IEnumerator PreloadMatchData(); // 0x00000001809EFBE0-0x00000001809EFC80
	private static void PrewarmTeammatePets(int myPetId); // 0x00000001809EFC80-0x00000001809EFE70
	public void ShowEnergyWarning(); // 0x00000001809EFE70-0x00000001809F03A0
	private void HideEnergyWarning(); // 0x00000001809F03A0-0x00000001809F0400
	public void ClearSelectedCardsState(); // 0x00000001809F0400-0x00000001809F0480
	private void ReplaceAnimations(AnimationClip[] newClips, string petId); // 0x00000001809F0480-0x00000001809F05F0
	public void SetEnemyPetFromProps(int enemyPetId, string enemyPetName, int enemyPetLevel = 0 /* Metadata: 0x005F1864 */); // 0x00000001809F05F0-0x00000001809F08A0
	private void ReplaceAnimationsEnemyPet(AnimationClip[] newClips, string petId); // 0x00000001809F08A0-0x00000001809F0A10
	private void OnError(string error); // 0x00000001809E8F50-0x00000001809E8F60
	private void OnDestroy(); // 0x00000001809F0A10-0x00000001809F1050
	[CompilerGenerated]
	private void _EnsurePetsPageSubscription_b__84_0(PetsPaginatedDataDTO d); // 0x00000001809F1160-0x00000001809F11D0
	[CompilerGenerated]
	private void _ShowEnergyWarning_b__128_0(); // 0x00000001809F11D0-0x00000001809F1240
}

