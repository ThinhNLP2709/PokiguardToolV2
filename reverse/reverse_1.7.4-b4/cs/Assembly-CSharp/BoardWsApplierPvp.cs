/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class BoardWsApplierPvp : MonoBehaviour // TypeDefIndex: 141
{
	// Fields
	private BoardPVP board; // 0x20
	private ActivePVP active; // 0x28
	private bool _subscribed; // 0x30
	private string _bootstrappedMatchId; // 0x38
	[CompilerGenerated]
	private static string _BootstrappedMatchId_k__BackingField; // 0x00
	private const int SPAWN_YIELD_EVERY = 16; // Metadata: 0x005EEB25
	private static bool _tagFallbackWarnedPvp; // 0x08
	private readonly Dictionary<string, GameObject> _prefabByTag; // 0x40
	private object _prefabTableOwner; // 0x48
	[TupleElementNames(new string[3] {"ops", "combat", "fx" })]
	private readonly Queue<ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator>> _pendingBatches; // 0x50
	private bool _renderRunning; // 0x58
	private bool _boardHiddenForCard; // 0x59
	private float _lastFallStartedAt; // 0x5C
	private float _lastFallNeedSec; // 0x60
	private bool _batchTouchesBoard; // 0x64
	private Coroutine _drainCo; // 0x68
	private GuardedEnumerator _activeRun; // 0x70
	[TupleElementNames(new string[3] {"ops", "combat", "fx" })]
	private ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator> _activeBatch; // 0x78
	private float _activeBatchStartedAt; // 0x90
	private const float RenderBatchHardCapSec = 30f; // Metadata: 0x005EEB26
	private float _lastFaultResyncAt; // 0x94
	private bool _suppressBarRefresh; // 0x98
	private static readonly Dictionary<string, int> _audioTagBuf; // 0x10
	private const float ShuffleShrinkSec = 0.22f; // Metadata: 0x005EEB2A
	private const float ShuffleWaveDelayPerCell = 0.018f; // Metadata: 0x005EEB2E
	private const float ShuffleEmptyBoardSec = 0.05f; // Metadata: 0x005EEB32
	private bool _healPopupBusy; // 0x99
	private readonly Queue<HealPopupReq> _healPopupQueue; // 0xA0
	private const int HealPopupQueueMax = 3; // Metadata: 0x005EEB36
	private const float HealPopupGapSec = 0.25f; // Metadata: 0x005EEB37
	private bool _pendingCritAtSelf; // 0xA8
	private bool _pendingCritAtEnemy; // 0xA9
	private const float MegaIcarusMarkHoldSec = 0.9f; // Metadata: 0x005EEB3B
	private const float DotConvertTelegraphSec = 0.35f; // Metadata: 0x005EEB3F
	private const float DotConvertMorphSec = 0.25f; // Metadata: 0x005EEB43
	private const float DotConvertStaggerSec = 0.04f; // Metadata: 0x005EEB47
	private readonly List<GameObject> _convertHalos; // 0xB0
	private static readonly Dictionary<int, Sprite> _cardArtCache; // 0x18
	private static int _localShownCardId; // 0x20
	private static float _localShownAt; // 0x24
	private const float LocalShownTtlSec = 20f; // Metadata: 0x005EEB4B
	private const float InvalidSwapFlashSec = 0.25f; // Metadata: 0x005EEB4F
	private readonly HashSet<string> _offlineToastShown; // 0xB8

	// Properties
	private bool WsPvpActive { get; } // 0x00000001807B8A80-0x00000001807B8CA0 
	public static string BootstrappedMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807B8E50-0x00000001807B8EB0 0x00000001807B8EB0-0x00000001807B8F60

	// Nested types
	private struct HealPopupReq // TypeDefIndex: 142
	{
		// Fields
		public int actor; // 0x00
		public int amount; // 0x04
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass105_0 // TypeDefIndex: 143
	{
		// Fields
		public bool done; // 0x10

		// Constructors
		public __c__DisplayClass105_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RunWithTimeout_b__0(); // 0x0000000180308BD0-0x0000000180308BE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass130_0 // TypeDefIndex: 144
	{
		// Fields
		public SpriteRenderer sr; // 0x10
		public Color color; // 0x18
		public GameObject halo; // 0x28
		public float life; // 0x30
		public Action<float> __9__2; // 0x38

		// Constructors
		public __c__DisplayClass130_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpawnConvertHalo_b__0(float a); // 0x0000000180AF60D0-0x0000000180AF6250
		internal void _SpawnConvertHalo_b__1(); // 0x0000000180AF6250-0x0000000180AF6460
		internal void _SpawnConvertHalo_b__2(float a); // 0x0000000180AF6460-0x0000000180AF65E0
	}

	[CompilerGenerated]
	private sealed class _ApplyCardUse_d__134 : IEnumerator<object> // TypeDefIndex: 145
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyCardUse_d__134(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AF65E0-0x0000000180AF6E50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AF6E50-0x0000000180AF6E90
	}

	[CompilerGenerated]
	private sealed class _ApplyDestroySequenced_d__79 : IEnumerator<object> // TypeDefIndex: 146
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28
		public int destroyRound; // 0x30
		public float speed; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDestroySequenced_d__79(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AF6E90-0x0000000180AF76D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AF76D0-0x0000000180AF7710
	}

	[CompilerGenerated]
	private sealed class _ApplyDotConvert_d__127 : IEnumerator<object> // TypeDefIndex: 147
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30
		private string _toTag_5__2; // 0x38
		private List<Vector2Int> _cells_5__3; // 0x40
		private Color _glow_5__4; // 0x48
		private List<Vector2Int> __7__wrap4; // 0x58

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDotConvert_d__127(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180377F00-0x0000000180378070
		private bool MoveNext(); // 0x0000000180AF7710-0x0000000180AF8B20
		private void __m__Finally1(); // 0x0000000180379490-0x00000001803794A0
		private void __m__Finally2(); // 0x0000000180379490-0x00000001803794A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AF8B20-0x0000000180AF8B60
	}

	[CompilerGenerated]
	private sealed class _ApplyGalaxyRickyPick_d__158 : IEnumerator<object> // TypeDefIndex: 148
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28
		public float speed; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyGalaxyRickyPick_d__158(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AF8B60-0x0000000180AF9090
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AF9090-0x0000000180AF90D0
	}

	[CompilerGenerated]
	private sealed class _ApplyMegaIcarusMark_d__132 : IEnumerator<object> // TypeDefIndex: 149
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyMegaIcarusMark_d__132(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AF90D0-0x0000000180AF9DD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AF9DD0-0x0000000180AF9E10
	}

	[CompilerGenerated]
	private sealed class _ApplyOp_d__74 : IEnumerator<object> // TypeDefIndex: 150
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28
		public float speed; // 0x30
		public int destroyRound; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOp_d__74(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AF9E10-0x0000000180AFAF40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFAF40-0x0000000180AFAF80
	}

	[CompilerGenerated]
	private sealed class _ApplyOpsSequential_d__72 : IEnumerator<object> // TypeDefIndex: 151
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public List<MatchOpDTO> ops; // 0x28
		private float _phaseStart_5__2; // 0x30
		private int _destroyRound_5__3; // 0x34
		private int _i_5__4; // 0x38
		private MatchOpDTO _op_5__5; // 0x40
		private float _speed_5__6; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOpsSequential_d__72(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018037B340-0x000000018037B3B0
		private bool MoveNext(); // 0x0000000180AFAF80-0x0000000180AFB6E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFB6E0-0x0000000180AFB720
	}

	[CompilerGenerated]
	private sealed class _ApplyOpsThenRender_d__69 : IEnumerator<object> // TypeDefIndex: 152
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public WsCombatBatch combat; // 0x28
		public List<MatchOpDTO> ops; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOpsThenRender_d__69(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AFB720-0x0000000180AFC060
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFC060-0x0000000180AFC0A0
	}

	[CompilerGenerated]
	private sealed class _ApplyShuffle_d__85 : IEnumerator<object> // TypeDefIndex: 153
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30
		private BoardCellDTO[][] _grid_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyShuffle_d__85(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180AFC0A0-0x0000000180AFCD60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFCD60-0x0000000180AFCDA0
	}

	[CompilerGenerated]
	private sealed class _BootstrapMatch_d__26 : IEnumerator<object> // TypeDefIndex: 154
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		public BoardCellDTO[][] preBoard; // 0x30
		private float _wait_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BootstrapMatch_d__26(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AFCDA0-0x0000000180AFD1F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFD1F0-0x0000000180AFD230
	}

	[CompilerGenerated]
	private sealed class _ClearGalaxyHintsAfter_d__118 : IEnumerator<object> // TypeDefIndex: 155
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClearGalaxyHintsAfter_d__118(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AFD230-0x0000000180AFD320
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFD320-0x0000000180AFD360
	}

	[CompilerGenerated]
	private sealed class _ClearMega2HintsAfter_d__117 : IEnumerator<object> // TypeDefIndex: 156
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClearMega2HintsAfter_d__117(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AFD360-0x0000000180AFD450
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFD450-0x0000000180AFD490
	}

	[CompilerGenerated]
	private sealed class _ClearMegaIcarusHintsAfter_d__119 : IEnumerator<object> // TypeDefIndex: 157
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClearMegaIcarusHintsAfter_d__119(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AFD490-0x0000000180AFD580
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFD580-0x0000000180AFD5C0
	}

	[CompilerGenerated]
	private sealed class _DrainBatchQueue_d__62 : IEnumerator<object> // TypeDefIndex: 158
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		[TupleElementNames(new string[3] {"ops", "combat", "fx" })]
		private ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator> _batch_5__2; // 0x28
		private GuardedEnumerator _run_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DrainBatchQueue_d__62(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180AFD5C0-0x0000000180AFD690
		private bool MoveNext(); // 0x0000000180AFD690-0x0000000180AFDAF0
		private void __m__Finally1(); // 0x0000000180AFDAF0-0x0000000180AFDB80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFDB80-0x0000000180AFDBC0
	}

	[CompilerGenerated]
	private sealed class _DrainHealPopupQueue_d__99 : IEnumerator<object> // TypeDefIndex: 159
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DrainHealPopupQueue_d__99(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AFDBC0-0x0000000180AFDE90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFDE90-0x0000000180AFDED0
	}

	[CompilerGenerated]
	private sealed class _EnsureFusionCardsWhenReady_d__108 : IEnumerator<object> // TypeDefIndex: 160
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		private float _deadline_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _EnsureFusionCardsWhenReady_d__108(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AFDED0-0x0000000180AFE310
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFE310-0x0000000180AFE350
	}

	[CompilerGenerated]
	private sealed class _LoadBoardFromSnapshot_d__30 : IEnumerator<object> // TypeDefIndex: 161
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		public BoardCellDTO[][] preBoard; // 0x30
		private float _waitStart_5__2; // 0x38
		private BoardCellDTO[][] _grid_5__3; // 0x40
		private int _spawned_5__4; // 0x48
		private int _col_5__5; // 0x4C
		private int _row_5__6; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadBoardFromSnapshot_d__30(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018037B340-0x000000018037B3B0
		private bool MoveNext(); // 0x0000000180AFE350-0x0000000180AFEBB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFEBB0-0x0000000180AFEBF0
	}

	[CompilerGenerated]
	private sealed class _PlayFusionResultFx_d__104 : IEnumerator<object> // TypeDefIndex: 162
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public bool isLocal; // 0x28
		public int actor; // 0x2C
		public bool success; // 0x30
		public bool actorIsSelfSide; // 0x31
		public int pityAfter; // 0x34
		public int pityBefore; // 0x38
		public int ghostPetId; // 0x3C
		private bool _hidBoard_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayFusionResultFx_d__104(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180AFEBF0-0x0000000180AFEC60
		private bool MoveNext(); // 0x0000000180AFEC60-0x0000000180AFF930
		private void __m__Finally1(); // 0x0000000180AFF930-0x0000000180AFFA50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFFA50-0x0000000180AFFA90
	}

	[CompilerGenerated]
	private sealed class _PlayInvalidSwapFeedback_d__148 : IEnumerator<object> // TypeDefIndex: 163
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public int fc; // 0x28
		public int fr; // 0x2C
		public int tc; // 0x30
		public int tr; // 0x34
		private GameObject _a_5__2; // 0x38
		private GameObject _b_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayInvalidSwapFeedback_d__148(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180381410-0x00000001803814D0
		private bool MoveNext(); // 0x0000000180AFFA90-0x0000000180B001E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B001E0-0x0000000180B00220
	}

	[CompilerGenerated]
	private sealed class _ResyncMatch_d__29 : IEnumerator<object> // TypeDefIndex: 164
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		public BoardCellDTO[][] preBoard; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ResyncMatch_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B00220-0x0000000180B00770
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B00770-0x0000000180B007B0
	}

	[CompilerGenerated]
	private sealed class _RunThenFlag_d__106 : IEnumerator<object> // TypeDefIndex: 165
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public IEnumerator inner; // 0x20
		public Action onDone; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RunThenFlag_d__106(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180382B20-0x0000000180382BC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B007B0-0x0000000180B007F0
	}

	[CompilerGenerated]
	private sealed class _RunWithTimeout_d__105 : IEnumerator<object> // TypeDefIndex: 166
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public IEnumerator inner; // 0x28
		public float timeoutSec; // 0x30
		private __c__DisplayClass105_0 __8__1; // 0x38
		private float _deadline_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RunWithTimeout_d__105(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180B007F0-0x0000000180B00BC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B00BC0-0x0000000180B00C00
	}

	[CompilerGenerated]
	private sealed class _WaitForFallToSettle_d__46 : IEnumerator<object> // TypeDefIndex: 167
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitForFallToSettle_d__46(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B00C00-0x0000000180B00EF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B00EF0-0x0000000180B00F30
	}

	// Constructors
	public BoardWsApplierPvp(); // 0x00000001807C8560-0x00000001807C8AB0
	static BoardWsApplierPvp(); // 0x00000001807C8AB0-0x00000001807C8D90

	// Methods
	private void Awake(); // 0x00000001807B64A0-0x00000001807B64C0
	private void Start(); // 0x00000001807B64C0-0x00000001807B64F0
	private void OnEnable(); // 0x00000001807B64F0-0x00000001807B6510
	private void OnDisable(); // 0x00000001807B6510-0x00000001807B66C0
	private void OnDestroy(); // 0x00000001807B66C0-0x00000001807B6930
	private void RegisterBusyProbe(); // 0x00000001807B6930-0x00000001807B6A80
	private bool IsRendererBusy(); // 0x00000001807B6A80-0x00000001807B6AB0
	private void EnsureRefs(); // 0x00000001807B6AB0-0x00000001807B7010
	private void EnsureMoveHint(); // 0x00000001807B7010-0x00000001807B7230
	private void TrySubscribe(); // 0x00000001807B7230-0x00000001807B78D0
	private void HandleSkillHint(ChatMessageDTO m); // 0x00000001807B78D0-0x00000001807B7E20
	private void HandleQteEvent(ChatMessageDTO m); // 0x00000001807B7E20-0x00000001807B80A0
	private void HandleEnergyDeltaWarn(ChatMessageDTO m); // 0x00000001807B80A0-0x00000001807B8420
	private void Unsubscribe(); // 0x00000001807B8420-0x00000001807B8A80
	public void SendMoveToWs(int fromCol, int fromRow, int toCol, int toRow); // 0x00000001807B8CA0-0x00000001807B8E50
	private void HandleMatchStart(ChatMessageDTO m); // 0x00000001807B8F60-0x00000001807B9510
	[IteratorStateMachine(typeof(_BootstrapMatch_d__26))]
	private IEnumerator BootstrapMatch(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x00000001807B9510-0x00000001807B9670
	private void ResetStatusFxForMatch(); // 0x00000001807B9670-0x00000001807B98D0
	private void HandleMatchResync(ChatMessageDTO m); // 0x00000001807B98D0-0x00000001807B9AD0
	[IteratorStateMachine(typeof(_ResyncMatch_d__29))]
	private IEnumerator ResyncMatch(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x00000001807B9AD0-0x00000001807B9C30
	[IteratorStateMachine(typeof(_LoadBoardFromSnapshot_d__30))]
	private IEnumerator LoadBoardFromSnapshot(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x00000001807B9C30-0x00000001807B9D90
	private bool BoardHasFullGrid(); // 0x00000001807B9D90-0x00000001807BA0A0
	private void ClearDotsAbsentFromSnapshot(BoardCellDTO[][] serverBoard); // 0x00000001807BA0A0-0x00000001807BA3C0
	private void ClearAllDots(); // 0x00000001807BA3C0-0x00000001807BA5E0
	private GameObject FindDotPrefabByTag(string tag); // 0x00000001807BA5E0-0x00000001807BAA80
	private void EnsurePrefabTable(); // 0x00000001807BAA80-0x00000001807BAE60
	private void SpawnDotByTag(int col, int row, string tag, int multiplier, bool fallFromAbove = false /* Metadata: 0x005EEB1A */); // 0x00000001807BAE60-0x00000001807BB7A0
	[IteratorStateMachine(typeof(_WaitForFallToSettle_d__46))]
	private IEnumerator WaitForFallToSettle(); // 0x00000001807BB7A0-0x00000001807BB840
	private static bool IsSkillCardOp(MatchOpDTO op); // 0x00000001807BB840-0x00000001807BBA10
	private static bool IsLocalUserCardOp(MatchOpDTO op); // 0x00000001807BBA10-0x00000001807BBBE0
	private static bool BatchTouchesBoard(List<MatchOpDTO> ops); // 0x00000001807BBBE0-0x00000001807BBEF0
	private static bool HasSkillCardOp(List<MatchOpDTO> ops); // 0x00000001807BBEF0-0x00000001807BC0A0
	private static string ReadSkillElementType(List<MatchOpDTO> ops); // 0x00000001807BC0A0-0x00000001807BC2D0
	private void HandleOpsApplied(List<MatchOpDTO> ops); // 0x00000001807BC2D0-0x00000001807BC580
	private void EnqueueFxOnly(IEnumerator fx); // 0x00000001807BC580-0x00000001807BC670
	private void KickDrain(); // 0x00000001807BC670-0x00000001807BC7A0
	[IteratorStateMachine(typeof(_DrainBatchQueue_d__62))]
	private IEnumerator DrainBatchQueue(); // 0x00000001807BC7A0-0x00000001807BC840
	private void AbortRenderInFlight(string reason); // 0x00000001807BC840-0x00000001807BCA70
	private void AbortStuckRenderIfAny(string where); // 0x00000001807BCA70-0x00000001807BCC80
	private void RecoverFromRenderError([TupleElementNames(new string[3] {"ops", "combat", "fx" })] ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator> batch, Exception e); // 0x00000001807BCC80-0x00000001807BCFC0
	private void RestoreBoardAfterAbortedRender(bool openInput); // 0x00000001807BCFC0-0x00000001807BD5A0
	private void RequestResyncAfterRenderFault(); // 0x00000001807BD5A0-0x00000001807BD820
	[IteratorStateMachine(typeof(_ApplyOpsThenRender_d__69))]
	private IEnumerator ApplyOpsThenRender(List<MatchOpDTO> ops, WsCombatBatch combat); // 0x00000001807BD820-0x00000001807BD980
	private static bool DetectFullPowerSpend(List<MatchOpDTO> ops, string actorUsername, List<WsCombatStepDTO> steps = null); // 0x00000001803630F0-0x0000000180363110
	private static int ResolveActorNumber(string username); // 0x00000001807BD980-0x00000001807BDB10
	[IteratorStateMachine(typeof(_ApplyOpsSequential_d__72))]
	private IEnumerator ApplyOpsSequential(List<MatchOpDTO> ops); // 0x00000001807BDB10-0x00000001807BDC20
	private void ApplyFallOrSpawn(MatchOpDTO op); // 0x00000001807BDC20-0x00000001807BDCD0
	[IteratorStateMachine(typeof(_ApplyOp_d__74))]
	private IEnumerator ApplyOp(MatchOpDTO op, float speed, int destroyRound); // 0x00000001807BDCD0-0x00000001807BDDF0
	private void ApplySwap(MatchOpDTO op); // 0x00000001807BDDF0-0x00000001807BE1D0
	private void ClearPredictionFlag(GameObject go); // 0x00000001807BE1D0-0x00000001807BE2F0
	private void ApplyHighlight(MatchOpDTO op); // 0x00000001807BE2F0-0x00000001807BE870
	private int VerifyBoardAgainstServer(BoardCellDTO[][] serverBoard); // 0x00000001807BE870-0x00000001807BEDF0
	[IteratorStateMachine(typeof(_ApplyDestroySequenced_d__79))]
	private IEnumerator ApplyDestroySequenced(MatchOpDTO op, float speed, int destroyRound); // 0x00000001807BEDF0-0x00000001807BEF10
	private static void PlayMatchAudioOncePerTag(List<GameObject> targets, int destroyRound); // 0x00000001807BEF10-0x00000001807BF460
	[IteratorStateMachine(typeof(_ApplyShuffle_d__85))]
	private IEnumerator ApplyShuffle(MatchOpDTO op, float speed); // 0x00000001807BF460-0x00000001807BF580
	private static BoardCellDTO[][] ParseShuffleBoard(MatchOpDTO op); // 0x00000001807BF580-0x00000001807BF790
	private static string ReadString(Dictionary<string, object> d, string key, string fb = null); // 0x00000001807BF790-0x00000001807BF830
	private void ApplyFall(MatchOpDTO op); // 0x00000001807BF830-0x00000001807BFB90
	private void ApplySpawn(MatchOpDTO op); // 0x00000001807BFB90-0x00000001807BFED0
	private void ApplyStatChange(MatchOpDTO op); // 0x00000001807BFED0-0x00000001807C0890
	private static string ReadReasonPvp(Dictionary<string, object> d); // 0x00000001807C0890-0x00000001807C0930
	private static bool IsHealReasonPvp(string reason); // 0x00000001807C0930-0x00000001807C0A20
	private void ShowHealPopup(int healedActor, int amount); // 0x00000001807C0A20-0x00000001807C0CE0
	[IteratorStateMachine(typeof(_DrainHealPopupQueue_d__99))]
	private IEnumerator DrainHealPopupQueue(); // 0x00000001807C0CE0-0x00000001807C0D80
	private void ApplyShieldExpire(MatchOpDTO op); // 0x00000001807C0D80-0x00000001807C1030
	private void ApplyStatus(MatchOpDTO op); // 0x00000001807C1030-0x00000001807C17E0
	private void HandleFusionResolved(ChatMessageDTO m); // 0x00000001807C17E0-0x00000001807C23E0
	private SpriteRenderer FusionPityHostFor(bool isLocal); // 0x00000001807C23E0-0x00000001807C2510
	[IteratorStateMachine(typeof(_PlayFusionResultFx_d__104))]
	private IEnumerator PlayFusionResultFx(bool success, bool isLocal, bool actorIsSelfSide, string petName, int ghostPetId, int actor, int pityBefore, int pityAfter); // 0x00000001807C2510-0x00000001807C2600
	[IteratorStateMachine(typeof(_RunWithTimeout_d__105))]
	private IEnumerator RunWithTimeout(IEnumerator inner, float timeoutSec); // 0x00000001807C2600-0x00000001807C2720
	[IteratorStateMachine(typeof(_RunThenFlag_d__106))]
	private static IEnumerator RunThenFlag(IEnumerator inner, Action onDone); // 0x00000001807C2720-0x00000001807C2830
	private CardUIPVP FindFusionCardUI(); // 0x00000001807C2830-0x00000001807C2BD0
	[IteratorStateMachine(typeof(_EnsureFusionCardsWhenReady_d__108))]
	private IEnumerator EnsureFusionCardsWhenReady(); // 0x00000001807C2BD0-0x00000001807C2C70
	private static bool ReadPayloadBoolPvp(Dictionary<string, object> p, string key); // 0x00000001807C2C70-0x00000001807C2DF0
	private static int ReadPayloadIntPvp(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x005EEB1B */); // 0x00000001807C2DF0-0x00000001807C2F30
	private static bool ReadBoolPvp(Dictionary<string, object> d, string key); // 0x00000001807C2F30-0x00000001807C30B0
	private void MarkCrit(bool atSelf); // 0x00000001807C30B0-0x00000001807C30D0
	private void FlushPendingCritLabels(); // 0x00000001807C30D0-0x00000001807C3190
	private void HandleSkillCast(ChatMessageDTO m); // 0x00000001807C3190-0x00000001807C4270
	[IteratorStateMachine(typeof(_ClearMega2HintsAfter_d__117))]
	private IEnumerator ClearMega2HintsAfter(float sec); // 0x00000001807C4270-0x00000001807C4330
	[IteratorStateMachine(typeof(_ClearGalaxyHintsAfter_d__118))]
	private IEnumerator ClearGalaxyHintsAfter(float sec); // 0x00000001807C4330-0x00000001807C43F0
	[IteratorStateMachine(typeof(_ClearMegaIcarusHintsAfter_d__119))]
	private IEnumerator ClearMegaIcarusHintsAfter(float sec); // 0x00000001807C43F0-0x00000001807C44B0
	private static int CountIn(HashSet<Vector2Int> a, HashSet<Vector2Int> b); // 0x00000001807C44B0-0x00000001807C4630
	private Vector3 HealCellBoardCenter(); // 0x00000001807C4630-0x00000001807C4A30
	[IteratorStateMachine(typeof(_ApplyDotConvert_d__127))]
	private IEnumerator ApplyDotConvert(MatchOpDTO op, float speed); // 0x00000001807C4A30-0x00000001807C4B50
	private GameObject DotAt(int col, int row); // 0x00000001807C4B50-0x00000001807C4CB0
	private static Color ConvertGlowColor(string tag); // 0x00000001807C4CB0-0x00000001807C4F10
	private void SpawnConvertHalo(GameObject host, Color color, float life); // 0x00000001807C4F10-0x00000001807C58A0
	private void ClearConvertHalos(); // 0x00000001807C58A0-0x00000001807C5AA0
	[IteratorStateMachine(typeof(_ApplyMegaIcarusMark_d__132))]
	private IEnumerator ApplyMegaIcarusMark(MatchOpDTO op, float speed); // 0x00000001807C5AA0-0x00000001807C5BC0
	private static bool IsGalaxyRickyCardOp(MatchOpDTO op); // 0x00000001807C5BC0-0x00000001807C5CB0
	[IteratorStateMachine(typeof(_ApplyCardUse_d__134))]
	private IEnumerator ApplyCardUse(MatchOpDTO op); // 0x00000001807C5CB0-0x00000001807C5DC0
	private static Sprite LoadCardArtById(int cardId); // 0x00000001807C5DC0-0x00000001807C63B0
	public static void ResetStaticState(); // 0x00000001807C63B0-0x00000001807C6420
	internal static void NotifyLocalSkillCardShown(int cardId); // 0x00000001807C6420-0x00000001807C64D0
	private static bool ConsumeLocalSkillCardShown(int cardId); // 0x00000001807C64D0-0x00000001807C65A0
	private CardUIPVP FindCardUIByCardId(int cardId); // 0x00000001807C65A0-0x00000001807C6760
	private void HandleTurnEnd(); // 0x00000001807C6760-0x00000001807C67F0
	private void HandleMatchReject(string reason); // 0x00000001807C67F0-0x00000001807C6DA0
	public void PlayLocalInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x00000001807C6DA0-0x00000001807C6E80
	[IteratorStateMachine(typeof(_PlayInvalidSwapFeedback_d__148))]
	private IEnumerator PlayInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x00000001807C6E80-0x00000001807C6F50
	private void ResetDotToActualPosition(int col, int row); // 0x00000001807C6F50-0x00000001807C71A0
	private void HandleGameOver(string winner); // 0x00000001807C71A0-0x00000001807C7770
	private void HandlePlayerLeft(string username, bool isPermanent, string reason); // 0x00000001807C7770-0x00000001807C7AE0
	private void HandlePlayerRejoin(string username); // 0x00000001807C7AE0-0x00000001807C7BE0
	private void HandleAfkWarn(string username, int idleCount, int threshold); // 0x00000001807C7BE0-0x00000001807C7DE0
	private static void ShowToast(string message); // 0x00000001807C7DE0-0x00000001807C7E00
	private bool InBounds(int col, int row); // 0x00000001807C7E00-0x00000001807C7F20
	private void UpdateDotPos(GameObject go, int col, int row); // 0x00000001807C7F20-0x00000001807C80C0
	[IteratorStateMachine(typeof(_ApplyGalaxyRickyPick_d__158))]
	private IEnumerator ApplyGalaxyRickyPick(MatchOpDTO op, float speed); // 0x00000001807C80C0-0x00000001807C81E0
	private static double ReadDouble(Dictionary<string, object> d, string key, double fb = 0 /* Metadata: 0x005EEB1C */); // 0x00000001807C81E0-0x00000001807C8440
	private static int ReadInt(Dictionary<string, object> d, string key, int fb = 0 /* Metadata: 0x005EEB24 */); // 0x00000001807C8440-0x00000001807C8560
}

