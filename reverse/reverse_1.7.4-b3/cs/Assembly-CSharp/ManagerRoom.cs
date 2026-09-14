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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerRoom : MonoBehaviour // TypeDefIndex: 2077
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
	private const int PETS_PER_PAGE = 18; // Metadata: 0x005F0494
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
	private const float LOADING_WATCHDOG_SEC = 25f; // Metadata: 0x005F0495
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
	private const int PET_RESIDENT_BUDGET = 12; // Metadata: 0x005F0499
	private bool _updatePlayerSlotsPending; // 0x168
	private int _myPetAnimToken; // 0x16C
	private int _enemyPetAnimToken; // 0x170

	// Properties
	public bool IsOpeningRoomFlow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001809E5240-0x00000001809E5250 0x00000001809E5250-0x00000001809E5260

	// Nested types
	[Serializable]
	public class PetPageResponse // TypeDefIndex: 2078
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
	private sealed class __c // TypeDefIndex: 2079
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__71_1; // 0x08
		public static Func<CardData, int> __9__79_0; // 0x10

		// Constructors
		static __c(); // 0x00000001809ED720-0x00000001809ED7C0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRoomDataWithoutLoading_b__71_1(string e); // 0x00000001809ED7C0-0x00000001809ED840
		internal int _UpdateLocalSelectedCards_b__79_0(CardData c); // 0x0000000180474AE0-0x0000000180474B00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass108_0 // TypeDefIndex: 2080
	{
		// Fields
		public int token; // 0x10
		public ManagerRoom __4__this; // 0x18
		public int petId; // 0x20

		// Constructors
		public __c__DisplayClass108_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ApplyMyPetAnimation_b__0(AnimationClip[] clips); // 0x00000001809ED840-0x00000001809EDB30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass115_0 // TypeDefIndex: 2081
	{
		// Fields
		public int token; // 0x10
		public ManagerRoom __4__this; // 0x18
		public string petId; // 0x20

		// Constructors
		public __c__DisplayClass115_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ApplyEnemyPetAnimation_b__0(AnimationClip[] clips); // 0x00000001809EDB30-0x00000001809EDE20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass124_0 // TypeDefIndex: 2082
	{
		// Fields
		public bool preloadDone; // 0x10

		// Constructors
		public __c__DisplayClass124_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DelayedLoadScene_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass126_0 // TypeDefIndex: 2083
	{
		// Fields
		public bool failed; // 0x10
		public PetUserDTO myPet; // 0x18
		public PetUserDTO enemyPet; // 0x20
		public UserDTO user; // 0x28

		// Constructors
		public __c__DisplayClass126_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PreloadMatchData_b__0(MatchPrepDataDTO data); // 0x00000001809EDE20-0x00000001809EDF40
		internal void _PreloadMatchData_b__1(string err); // 0x00000001809EDF40-0x00000001809EDFD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass70_0 // TypeDefIndex: 2084
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
		internal void _LoadRoomDataWithLoading_b__0(); // 0x00000001809EDFD0-0x00000001809EE210
		internal void _LoadRoomDataWithLoading_b__3(); // 0x00000001809EE210-0x00000001809EE220
		internal void _LoadRoomDataWithLoading_b__4(string e); // 0x00000001809EE220-0x00000001809EE350
		internal void _LoadRoomDataWithLoading_b__1(string r); // 0x00000001809EE350-0x00000001809EE3B0
		internal void _LoadRoomDataWithLoading_b__2(string _); // 0x00000001809EE3B0-0x00000001809EE3C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass71_0 // TypeDefIndex: 2085
	{
		// Fields
		public bool cacheLoaded; // 0x10

		// Constructors
		public __c__DisplayClass71_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRoomDataWithoutLoading_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass94_0 // TypeDefIndex: 2086
	{
		// Fields
		public string petID; // 0x10
		public ManagerRoom __4__this; // 0x18

		// Constructors
		public __c__DisplayClass94_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DisplayCurrentPetPageCoroutine_b__0(); // 0x00000001809EE3C0-0x00000001809EE3F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass95_0 // TypeDefIndex: 2087
	{
		// Fields
		public string petID; // 0x10

		// Constructors
		public __c__DisplayClass95_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _HookPetRowPrewarm_b__0(BaseEventData _); // 0x00000001809EE3F0-0x00000001809EE4B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass99_0 // TypeDefIndex: 2088
	{
		// Fields
		public Button button; // 0x10

		// Constructors
		public __c__DisplayClass99_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateButton_b__0(); // 0x00000001809EE4B0-0x00000001809EE630
	}

	[CompilerGenerated]
	private sealed class _DelayedLoadScene_d__124 : IEnumerator<object> // TypeDefIndex: 2089
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
		private bool MoveNext(); // 0x00000001809EE630-0x00000001809EEB70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809EEB70-0x00000001809EEBB0
	}

	[CompilerGenerated]
	private sealed class _DisplayCurrentPetPageCoroutine_d__94 : IEnumerator<object> // TypeDefIndex: 2090
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
		private bool MoveNext(); // 0x00000001809EEBB0-0x00000001809EFA80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809EFA80-0x00000001809EFAC0
	}

	[CompilerGenerated]
	private sealed class _EnsureWsThenOpenRoom_d__56 : IEnumerator<object> // TypeDefIndex: 2091
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
		private bool MoveNext(); // 0x00000001809EFAC0-0x00000001809F0680
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F0680-0x00000001809F06C0
	}

	[CompilerGenerated]
	private sealed class _FadeTransition_d__75 : IEnumerator<object> // TypeDefIndex: 2092
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809F06C0-0x00000001809F0C40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F0C40-0x00000001809F0C80
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__85 : IEnumerator<object> // TypeDefIndex: 2093
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809F0C80-0x00000001809F13A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F13A0-0x00000001809F13E0
	}

	[CompilerGenerated]
	private sealed class _LoadRoomDataWithLoading_d__70 : IEnumerator<object> // TypeDefIndex: 2094
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
		void IDisposable.Dispose(); // 0x00000001809F13E0-0x00000001809F1590
		private bool MoveNext(); // 0x00000001809F1590-0x00000001809F2870
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F2870-0x00000001809F28B0
	}

	[CompilerGenerated]
	private sealed class _LoadRoomDataWithoutLoading_d__71 : IEnumerator<object> // TypeDefIndex: 2095
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
		void IDisposable.Dispose(); // 0x00000001805EE460-0x00000001805EE4D0
		private bool MoveNext(); // 0x00000001809F28B0-0x00000001809F2EC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F2EC0-0x00000001809F2F00
	}

	[CompilerGenerated]
	private sealed class _OnStartBattle_d__121 : IEnumerator<object> // TypeDefIndex: 2096
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809F2F00-0x00000001809F31E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F31E0-0x00000001809F3220
	}

	[CompilerGenerated]
	private sealed class _PetPageLoop_d__89 : IEnumerator<object> // TypeDefIndex: 2097
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809F3220-0x00000001809F3400
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F3400-0x00000001809F3440
	}

	[CompilerGenerated]
	private sealed class _PreloadMatchData_d__126 : IEnumerator<object> // TypeDefIndex: 2098
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
		private bool MoveNext(); // 0x00000001809F3440-0x00000001809F3B80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F3B80-0x00000001809F3BC0
	}

	[CompilerGenerated]
	private sealed class _RoomLoadingWatchdogRoutine_d__62 : IEnumerator<object> // TypeDefIndex: 2099
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809F3BC0-0x00000001809F4150
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F4150-0x00000001809F4190
	}

	[CompilerGenerated]
	private sealed class _RunPreloadThenFlag_d__125 : IEnumerator<object> // TypeDefIndex: 2100
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809F4190-0x00000001809F42E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F42E0-0x00000001809F4320
	}

	[CompilerGenerated]
	private sealed class _UpdatePlayerSlotsDebounced_d__104 : IEnumerator<object> // TypeDefIndex: 2101
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809F4320-0x00000001809F43E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809F43E0-0x00000001809F4420
	}

	// Constructors
	public ManagerRoom(); // 0x00000001809ED530-0x00000001809ED640

	// Methods
	private void Start(); // 0x00000001809E1B30-0x00000001809E2200
	private static bool IsReturningFromMatch(); // 0x00000001809E2200-0x00000001809E2320
	internal void ApplyWsEnemyPetFromProperties(); // 0x00000001809E2320-0x00000001809E27E0
	private void HandleUserEnergyDelta(ChatMessageDTO msg); // 0x00000001809E27E0-0x00000001809E29C0
	private void SetupCardSelection(); // 0x00000001809E29C0-0x00000001809E2E10
	private void HandleCardSelectionChanged(); // 0x00000001809E2E10-0x00000001809E2E80
	internal void SaveSelectedCardsToPrefs(); // 0x00000001809E2E80-0x00000001809E30E0
	private void TryRestoreSelectedCards(bool syncAfter); // 0x00000001809E30E0-0x00000001809E32E0
	private static List<int> ReadSavedCardIds(); // 0x00000001809E32E0-0x00000001809E35C0
	private void SetupPetPagination(); // 0x00000001809E35C0-0x00000001809E3820
	public void ShowPetPanel(); // 0x00000001809E3820-0x00000001809E3940
	public void HidePetPanel(); // 0x00000001809E3940-0x00000001809E3A60
	public void ShowCardPanel(); // 0x00000001809E3A60-0x00000001809E3B80
	public void HideCardPanel(); // 0x00000001809E3B80-0x00000001809E3CA0
	private void Update(); // 0x00000001809E3CA0-0x00000001809E3F50
	public void TearDownRoomUi(); // 0x00000001809E3F50-0x00000001809E4770
	public void OpenRoomPanel(bool isLocal, string roomName); // 0x00000001809E4770-0x00000001809E49F0
	[IteratorStateMachine(typeof(_EnsureWsThenOpenRoom_d__56))]
	private IEnumerator EnsureWsThenOpenRoom(bool isLocal, string roomName); // 0x00000001809E49F0-0x00000001809E4B00
	private Dictionary<string, object> BuildInitialBossProps(); // 0x00000001809E4B00-0x00000001809E4C90
	private void ShowLoadingInstant(); // 0x00000001809E4C90-0x00000001809E5000
	private void ArmLoadingWatchdog(); // 0x00000001809E5000-0x00000001809E51A0
	[IteratorStateMachine(typeof(_RoomLoadingWatchdogRoutine_d__62))]
	private IEnumerator RoomLoadingWatchdogRoutine(); // 0x00000001809E51A0-0x00000001809E5240
	public void ShowLoadingImmediate(); // 0x00000001809E5260-0x00000001809E5270
	private void HideLoadingInstant(); // 0x00000001809E5270-0x00000001809E5430
	public void HideLoadingFromMatch(); // 0x00000001809E5430-0x00000001809E5440
	[IteratorStateMachine(typeof(_LoadRoomDataWithLoading_d__70))]
	public IEnumerator LoadRoomDataWithLoading(bool alreadyInRoom = false /* Metadata: 0x005F0491 */); // 0x00000001809E5440-0x00000001809E54F0
	[IteratorStateMachine(typeof(_LoadRoomDataWithoutLoading_d__71))]
	public IEnumerator LoadRoomDataWithoutLoading(); // 0x00000001809E54F0-0x00000001809E5590
	public void ResetRoomHardState(); // 0x00000001809E5590-0x00000001809E58B0
	private void ShowRoomPanelInstant(); // 0x00000001809E58B0-0x00000001809E5B20
	public void CloseRoomPanel(); // 0x00000001809E5B20-0x00000001809E5DE0
	[IteratorStateMachine(typeof(_FadeTransition_d__75))]
	private IEnumerator FadeTransition(); // 0x00000001809E5DE0-0x00000001809E5E80
	public void UpdatePlayerSlots(int mySlotIndex = -1 /* Metadata: 0x005F0492 */); // 0x00000001809E5E80-0x00000001809E6CD0
	public void ClearCardSyncCache(); // 0x00000001809E6CD0-0x00000001809E6D30
	public void UpdateLocalSelectedCards(); // 0x00000001809E6D30-0x00000001809E72D0
	private static bool ArrayEqualsOrdered(int[] a, int[] b); // 0x00000001809E72D0-0x00000001809E7350
	private void EnsurePetsPageSubscription(); // 0x00000001809E7350-0x00000001809E7530
	[IteratorStateMachine(typeof(_LoadPetsPage_d__85))]
	private IEnumerator LoadPetsPage(int userId, int page); // 0x00000001809E7530-0x00000001809E75E0
	private void GoToPetPage(int page); // 0x00000001809E75E0-0x00000001809E76D0
	[IteratorStateMachine(typeof(_PetPageLoop_d__89))]
	private IEnumerator PetPageLoop(); // 0x00000001809E76D0-0x00000001809E7770
	public void RefreshPetList(); // 0x00000001809E7770-0x00000001809E7780
	private void DisplayCurrentPetPage(); // 0x00000001809E7780-0x00000001809E78B0
	[IteratorStateMachine(typeof(_DisplayCurrentPetPageCoroutine_d__94))]
	private IEnumerator DisplayCurrentPetPageCoroutine(); // 0x00000001809E78B0-0x00000001809E7950
	private void HookPetRowPrewarm(GameObject row, string petID); // 0x00000001809E7950-0x00000001809E7D10
	private void UpdatePetPaginationButtons(); // 0x00000001809E7D10-0x00000001809E8050
	private void ShowPreviousPetPage(); // 0x00000001809E8050-0x00000001809E8180
	private void ShowNextPetPage(); // 0x00000001809E8180-0x00000001809E82B0
	private void AnimateButton(Button button); // 0x00000001809E82B0-0x00000001809E85A0
	internal void OnRoomReceived(RoomDTO room); // 0x00000001809E85A0-0x00000001809E8C90
	internal void OnUserReceived(UserDTO user); // 0x00000001809E8C90-0x00000001809E8D20
	public void RequestUpdatePlayerSlots(); // 0x00000001809E8D20-0x00000001809E8DE0
	[IteratorStateMachine(typeof(_UpdatePlayerSlotsDebounced_d__104))]
	private IEnumerator UpdatePlayerSlotsDebounced(); // 0x00000001809E8DE0-0x00000001809E8E80
	private void OnPetClicked(string petIdStr); // 0x00000001809E8E80-0x00000001809E8E90
	private void OnPetClickedInternal(string petIdStr, bool loadAnimation); // 0x00000001809E8E90-0x00000001809E9020
	private void ApplyMyPetAnimation(int petId); // 0x00000001809E9020-0x00000001809E9280
	private static void SetPetRowHighlight(GameObject petRow, bool selected); // 0x00000001809E9280-0x00000001809E9620
	private void RefreshPetListSelectionHighlight(); // 0x00000001809E9620-0x00000001809E9A20
	private static string FormatEnemyPetRoomLabel(RoomDTO room); // 0x00000001809E9A20-0x00000001809E9B70
	private static int ResolveEnemyPetDisplayLevel(RoomDTO room); // 0x00000001809E9B70-0x00000001809E9BE0
	public void OnEnemyPet(string petId); // 0x00000001809E9BE0-0x00000001809E9DF0
	private void ApplyEnemyPetAnimation(string petId); // 0x00000001809E9DF0-0x00000001809E9FC0
	internal void DisplayCardsForSelection(List<CardData> cards); // 0x00000001809E9FC0-0x00000001809EA6A0
	private GameObject CreateCardToggle(CardData card, int index); // 0x00000001809EA6A0-0x00000001809EA850
	private void SetupToggle(GameObject toggleObj, CardData card); // 0x00000001809EA850-0x00000001809EAF90
	private GameObject CreateToggleDynamic(CardData card, int index); // 0x00000001809EAF90-0x00000001809EB960
	public void LoadScene(string nameScene); // 0x00000001809EB960-0x00000001809EB9D0
	[IteratorStateMachine(typeof(_OnStartBattle_d__121))]
	public IEnumerator OnStartBattle(); // 0x00000001809EB9D0-0x00000001809EBA70
	public void StartBattleSequence(); // 0x00000001809EBA70-0x00000001809EBCB0
	public void BeginMatchSceneLoad(); // 0x00000001809EBCB0-0x00000001809EBE90
	[IteratorStateMachine(typeof(_DelayedLoadScene_d__124))]
	private IEnumerator DelayedLoadScene(string sceneName, float delay); // 0x00000001809EBE90-0x00000001809EBFB0
	[IteratorStateMachine(typeof(_RunPreloadThenFlag_d__125))]
	private IEnumerator RunPreloadThenFlag(Action onDone); // 0x00000001809EBFB0-0x00000001809EC0C0
	[IteratorStateMachine(typeof(_PreloadMatchData_d__126))]
	private IEnumerator PreloadMatchData(); // 0x00000001809EC0C0-0x00000001809EC160
	private static void PrewarmTeammatePets(int myPetId); // 0x00000001809EC160-0x00000001809EC350
	public void ShowEnergyWarning(); // 0x00000001809EC350-0x00000001809EC880
	private void HideEnergyWarning(); // 0x00000001809EC880-0x00000001809EC8E0
	public void ClearSelectedCardsState(); // 0x00000001809EC8E0-0x00000001809EC960
	private void ReplaceAnimations(AnimationClip[] newClips, string petId); // 0x00000001809EC960-0x00000001809ECAD0
	public void SetEnemyPetFromProps(int enemyPetId, string enemyPetName, int enemyPetLevel = 0 /* Metadata: 0x005F0493 */); // 0x00000001809ECAD0-0x00000001809ECD80
	private void ReplaceAnimationsEnemyPet(AnimationClip[] newClips, string petId); // 0x00000001809ECD80-0x00000001809ECEF0
	private void OnError(string error); // 0x00000001809E5430-0x00000001809E5440
	private void OnDestroy(); // 0x00000001809ECEF0-0x00000001809ED530
	[CompilerGenerated]
	private void _EnsurePetsPageSubscription_b__84_0(PetsPaginatedDataDTO d); // 0x00000001809ED640-0x00000001809ED6B0
	[CompilerGenerated]
	private void _ShowEnergyWarning_b__128_0(); // 0x00000001809ED6B0-0x00000001809ED720
}

