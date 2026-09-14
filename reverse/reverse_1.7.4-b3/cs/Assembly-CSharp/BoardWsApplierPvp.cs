/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
	private const int SPAWN_YIELD_EVERY = 16; // Metadata: 0x005ED755
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
	private const float RenderBatchHardCapSec = 30f; // Metadata: 0x005ED756
	private float _lastFaultResyncAt; // 0x94
	private bool _suppressBarRefresh; // 0x98
	private static readonly Dictionary<string, int> _audioTagBuf; // 0x10
	private const float ShuffleShrinkSec = 0.22f; // Metadata: 0x005ED75A
	private const float ShuffleWaveDelayPerCell = 0.018f; // Metadata: 0x005ED75E
	private const float ShuffleEmptyBoardSec = 0.05f; // Metadata: 0x005ED762
	private bool _healPopupBusy; // 0x99
	private readonly Queue<HealPopupReq> _healPopupQueue; // 0xA0
	private const int HealPopupQueueMax = 3; // Metadata: 0x005ED766
	private const float HealPopupGapSec = 0.25f; // Metadata: 0x005ED767
	private bool _pendingCritAtSelf; // 0xA8
	private bool _pendingCritAtEnemy; // 0xA9
	private const float MegaIcarusMarkHoldSec = 0.9f; // Metadata: 0x005ED76B
	private const float DotConvertTelegraphSec = 0.35f; // Metadata: 0x005ED76F
	private const float DotConvertMorphSec = 0.25f; // Metadata: 0x005ED773
	private const float DotConvertStaggerSec = 0.04f; // Metadata: 0x005ED777
	private readonly List<GameObject> _convertHalos; // 0xB0
	private static readonly Dictionary<int, Sprite> _cardArtCache; // 0x18
	private static int _localShownCardId; // 0x20
	private static float _localShownAt; // 0x24
	private const float LocalShownTtlSec = 20f; // Metadata: 0x005ED77B
	private const float InvalidSwapFlashSec = 0.25f; // Metadata: 0x005ED77F
	private readonly HashSet<string> _offlineToastShown; // 0xB8

	// Properties
	private bool WsPvpActive { get; } // 0x00000001807B6A10-0x00000001807B6C30 
	public static string BootstrappedMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807B6DE0-0x00000001807B6E40 0x00000001807B6E40-0x00000001807B6EF0

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
		internal void _RunWithTimeout_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
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
		internal void _SpawnConvertHalo_b__0(float a); // 0x0000000180AFA310-0x0000000180AFA490
		internal void _SpawnConvertHalo_b__1(); // 0x0000000180AFA490-0x0000000180AFA6A0
		internal void _SpawnConvertHalo_b__2(float a); // 0x0000000180AFA6A0-0x0000000180AFA820
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AFA820-0x0000000180AFB090
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFB090-0x0000000180AFB0D0
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AFB0D0-0x0000000180AFB910
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFB910-0x0000000180AFB950
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
		void IDisposable.Dispose(); // 0x0000000180377D50-0x0000000180377EC0
		private bool MoveNext(); // 0x0000000180AFB950-0x0000000180AFCD60
		private void __m__Finally1(); // 0x00000001803792E0-0x00000001803792F0
		private void __m__Finally2(); // 0x00000001803792E0-0x00000001803792F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFCD60-0x0000000180AFCDA0
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AFCDA0-0x0000000180AFD2D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFD2D0-0x0000000180AFD310
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AFD310-0x0000000180AFE010
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFE010-0x0000000180AFE050
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AFE050-0x0000000180AFF180
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFF180-0x0000000180AFF1C0
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
		void IDisposable.Dispose(); // 0x000000018037B190-0x000000018037B200
		private bool MoveNext(); // 0x0000000180AFF1C0-0x0000000180AFF920
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AFF920-0x0000000180AFF960
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AFF960-0x0000000180B002A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B002A0-0x0000000180B002E0
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
		private bool MoveNext(); // 0x0000000180B002E0-0x0000000180B00FA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B00FA0-0x0000000180B00FE0
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B00FE0-0x0000000180B01430
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B01430-0x0000000180B01470
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B01470-0x0000000180B01560
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B01560-0x0000000180B015A0
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B015A0-0x0000000180B01690
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B01690-0x0000000180B016D0
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B016D0-0x0000000180B017C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B017C0-0x0000000180B01800
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
		void IDisposable.Dispose(); // 0x0000000180B01800-0x0000000180B018D0
		private bool MoveNext(); // 0x0000000180B018D0-0x0000000180B01D30
		private void __m__Finally1(); // 0x0000000180B01D30-0x0000000180B01DC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B01DC0-0x0000000180B01E00
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B01E00-0x0000000180B020D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B020D0-0x0000000180B02110
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B02110-0x0000000180B02550
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B02550-0x0000000180B02590
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
		void IDisposable.Dispose(); // 0x000000018037B190-0x000000018037B200
		private bool MoveNext(); // 0x0000000180B02590-0x0000000180B02DF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B02DF0-0x0000000180B02E30
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
		void IDisposable.Dispose(); // 0x0000000180B02E30-0x0000000180B02EA0
		private bool MoveNext(); // 0x0000000180B02EA0-0x0000000180B03B70
		private void __m__Finally1(); // 0x0000000180B03B70-0x0000000180B03C90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B03C90-0x0000000180B03CD0
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
		void IDisposable.Dispose(); // 0x0000000180381260-0x0000000180381320
		private bool MoveNext(); // 0x0000000180B03CD0-0x0000000180B04420
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B04420-0x0000000180B04460
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B04460-0x0000000180B049B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B049B0-0x0000000180B049F0
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180382970-0x0000000180382A10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B049F0-0x0000000180B04A30
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
		private bool MoveNext(); // 0x0000000180B04A30-0x0000000180B04E00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B04E00-0x0000000180B04E40
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B04E40-0x0000000180B05130
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B05130-0x0000000180B05170
	}

	// Constructors
	public BoardWsApplierPvp(); // 0x00000001807C64F0-0x00000001807C6A40
	static BoardWsApplierPvp(); // 0x00000001807C6A40-0x00000001807C6D20

	// Methods
	private void Awake(); // 0x00000001807B4430-0x00000001807B4450
	private void Start(); // 0x00000001807B4450-0x00000001807B4480
	private void OnEnable(); // 0x00000001807B4480-0x00000001807B44A0
	private void OnDisable(); // 0x00000001807B44A0-0x00000001807B4650
	private void OnDestroy(); // 0x00000001807B4650-0x00000001807B48C0
	private void RegisterBusyProbe(); // 0x00000001807B48C0-0x00000001807B4A10
	private bool IsRendererBusy(); // 0x00000001807B4A10-0x00000001807B4A40
	private void EnsureRefs(); // 0x00000001807B4A40-0x00000001807B4FA0
	private void EnsureMoveHint(); // 0x00000001807B4FA0-0x00000001807B51C0
	private void TrySubscribe(); // 0x00000001807B51C0-0x00000001807B5860
	private void HandleSkillHint(ChatMessageDTO m); // 0x00000001807B5860-0x00000001807B5DB0
	private void HandleQteEvent(ChatMessageDTO m); // 0x00000001807B5DB0-0x00000001807B6030
	private void HandleEnergyDeltaWarn(ChatMessageDTO m); // 0x00000001807B6030-0x00000001807B63B0
	private void Unsubscribe(); // 0x00000001807B63B0-0x00000001807B6A10
	public void SendMoveToWs(int fromCol, int fromRow, int toCol, int toRow); // 0x00000001807B6C30-0x00000001807B6DE0
	private void HandleMatchStart(ChatMessageDTO m); // 0x00000001807B6EF0-0x00000001807B74A0
	[IteratorStateMachine(typeof(_BootstrapMatch_d__26))]
	private IEnumerator BootstrapMatch(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x00000001807B74A0-0x00000001807B7600
	private void ResetStatusFxForMatch(); // 0x00000001807B7600-0x00000001807B7860
	private void HandleMatchResync(ChatMessageDTO m); // 0x00000001807B7860-0x00000001807B7A60
	[IteratorStateMachine(typeof(_ResyncMatch_d__29))]
	private IEnumerator ResyncMatch(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x00000001807B7A60-0x00000001807B7BC0
	[IteratorStateMachine(typeof(_LoadBoardFromSnapshot_d__30))]
	private IEnumerator LoadBoardFromSnapshot(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x00000001807B7BC0-0x00000001807B7D20
	private bool BoardHasFullGrid(); // 0x00000001807B7D20-0x00000001807B8030
	private void ClearDotsAbsentFromSnapshot(BoardCellDTO[][] serverBoard); // 0x00000001807B8030-0x00000001807B8350
	private void ClearAllDots(); // 0x00000001807B8350-0x00000001807B8570
	private GameObject FindDotPrefabByTag(string tag); // 0x00000001807B8570-0x00000001807B8A10
	private void EnsurePrefabTable(); // 0x00000001807B8A10-0x00000001807B8DF0
	private void SpawnDotByTag(int col, int row, string tag, int multiplier, bool fallFromAbove = false /* Metadata: 0x005ED74A */); // 0x00000001807B8DF0-0x00000001807B9730
	[IteratorStateMachine(typeof(_WaitForFallToSettle_d__46))]
	private IEnumerator WaitForFallToSettle(); // 0x00000001807B9730-0x00000001807B97D0
	private static bool IsSkillCardOp(MatchOpDTO op); // 0x00000001807B97D0-0x00000001807B99A0
	private static bool IsLocalUserCardOp(MatchOpDTO op); // 0x00000001807B99A0-0x00000001807B9B70
	private static bool BatchTouchesBoard(List<MatchOpDTO> ops); // 0x00000001807B9B70-0x00000001807B9E80
	private static bool HasSkillCardOp(List<MatchOpDTO> ops); // 0x00000001807B9E80-0x00000001807BA030
	private static string ReadSkillElementType(List<MatchOpDTO> ops); // 0x00000001807BA030-0x00000001807BA260
	private void HandleOpsApplied(List<MatchOpDTO> ops); // 0x00000001807BA260-0x00000001807BA510
	private void EnqueueFxOnly(IEnumerator fx); // 0x00000001807BA510-0x00000001807BA600
	private void KickDrain(); // 0x00000001807BA600-0x00000001807BA730
	[IteratorStateMachine(typeof(_DrainBatchQueue_d__62))]
	private IEnumerator DrainBatchQueue(); // 0x00000001807BA730-0x00000001807BA7D0
	private void AbortRenderInFlight(string reason); // 0x00000001807BA7D0-0x00000001807BAA00
	private void AbortStuckRenderIfAny(string where); // 0x00000001807BAA00-0x00000001807BAC10
	private void RecoverFromRenderError([TupleElementNames(new string[3] {"ops", "combat", "fx" })] ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator> batch, Exception e); // 0x00000001807BAC10-0x00000001807BAF50
	private void RestoreBoardAfterAbortedRender(bool openInput); // 0x00000001807BAF50-0x00000001807BB530
	private void RequestResyncAfterRenderFault(); // 0x00000001807BB530-0x00000001807BB7B0
	[IteratorStateMachine(typeof(_ApplyOpsThenRender_d__69))]
	private IEnumerator ApplyOpsThenRender(List<MatchOpDTO> ops, WsCombatBatch combat); // 0x00000001807BB7B0-0x00000001807BB910
	private static bool DetectFullPowerSpend(List<MatchOpDTO> ops, string actorUsername, List<WsCombatStepDTO> steps = null); // 0x0000000180362EE0-0x0000000180362F00
	private static int ResolveActorNumber(string username); // 0x00000001807BB910-0x00000001807BBAA0
	[IteratorStateMachine(typeof(_ApplyOpsSequential_d__72))]
	private IEnumerator ApplyOpsSequential(List<MatchOpDTO> ops); // 0x00000001807BBAA0-0x00000001807BBBB0
	private void ApplyFallOrSpawn(MatchOpDTO op); // 0x00000001807BBBB0-0x00000001807BBC60
	[IteratorStateMachine(typeof(_ApplyOp_d__74))]
	private IEnumerator ApplyOp(MatchOpDTO op, float speed, int destroyRound); // 0x00000001807BBC60-0x00000001807BBD80
	private void ApplySwap(MatchOpDTO op); // 0x00000001807BBD80-0x00000001807BC160
	private void ClearPredictionFlag(GameObject go); // 0x00000001807BC160-0x00000001807BC280
	private void ApplyHighlight(MatchOpDTO op); // 0x00000001807BC280-0x00000001807BC800
	private int VerifyBoardAgainstServer(BoardCellDTO[][] serverBoard); // 0x00000001807BC800-0x00000001807BCD80
	[IteratorStateMachine(typeof(_ApplyDestroySequenced_d__79))]
	private IEnumerator ApplyDestroySequenced(MatchOpDTO op, float speed, int destroyRound); // 0x00000001807BCD80-0x00000001807BCEA0
	private static void PlayMatchAudioOncePerTag(List<GameObject> targets, int destroyRound); // 0x00000001807BCEA0-0x00000001807BD3F0
	[IteratorStateMachine(typeof(_ApplyShuffle_d__85))]
	private IEnumerator ApplyShuffle(MatchOpDTO op, float speed); // 0x00000001807BD3F0-0x00000001807BD510
	private static BoardCellDTO[][] ParseShuffleBoard(MatchOpDTO op); // 0x00000001807BD510-0x00000001807BD720
	private static string ReadString(Dictionary<string, object> d, string key, string fb = null); // 0x00000001807BD720-0x00000001807BD7C0
	private void ApplyFall(MatchOpDTO op); // 0x00000001807BD7C0-0x00000001807BDB20
	private void ApplySpawn(MatchOpDTO op); // 0x00000001807BDB20-0x00000001807BDE60
	private void ApplyStatChange(MatchOpDTO op); // 0x00000001807BDE60-0x00000001807BE820
	private static string ReadReasonPvp(Dictionary<string, object> d); // 0x00000001807BE820-0x00000001807BE8C0
	private static bool IsHealReasonPvp(string reason); // 0x00000001807BE8C0-0x00000001807BE9B0
	private void ShowHealPopup(int healedActor, int amount); // 0x00000001807BE9B0-0x00000001807BEC70
	[IteratorStateMachine(typeof(_DrainHealPopupQueue_d__99))]
	private IEnumerator DrainHealPopupQueue(); // 0x00000001807BEC70-0x00000001807BED10
	private void ApplyShieldExpire(MatchOpDTO op); // 0x00000001807BED10-0x00000001807BEFC0
	private void ApplyStatus(MatchOpDTO op); // 0x00000001807BEFC0-0x00000001807BF770
	private void HandleFusionResolved(ChatMessageDTO m); // 0x00000001807BF770-0x00000001807C0370
	private SpriteRenderer FusionPityHostFor(bool isLocal); // 0x00000001807C0370-0x00000001807C04A0
	[IteratorStateMachine(typeof(_PlayFusionResultFx_d__104))]
	private IEnumerator PlayFusionResultFx(bool success, bool isLocal, bool actorIsSelfSide, string petName, int ghostPetId, int actor, int pityBefore, int pityAfter); // 0x00000001807C04A0-0x00000001807C0590
	[IteratorStateMachine(typeof(_RunWithTimeout_d__105))]
	private IEnumerator RunWithTimeout(IEnumerator inner, float timeoutSec); // 0x00000001807C0590-0x00000001807C06B0
	[IteratorStateMachine(typeof(_RunThenFlag_d__106))]
	private static IEnumerator RunThenFlag(IEnumerator inner, Action onDone); // 0x00000001807C06B0-0x00000001807C07C0
	private CardUIPVP FindFusionCardUI(); // 0x00000001807C07C0-0x00000001807C0B60
	[IteratorStateMachine(typeof(_EnsureFusionCardsWhenReady_d__108))]
	private IEnumerator EnsureFusionCardsWhenReady(); // 0x00000001807C0B60-0x00000001807C0C00
	private static bool ReadPayloadBoolPvp(Dictionary<string, object> p, string key); // 0x00000001807C0C00-0x00000001807C0D80
	private static int ReadPayloadIntPvp(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x005ED74B */); // 0x00000001807C0D80-0x00000001807C0EC0
	private static bool ReadBoolPvp(Dictionary<string, object> d, string key); // 0x00000001807C0EC0-0x00000001807C1040
	private void MarkCrit(bool atSelf); // 0x00000001807C1040-0x00000001807C1060
	private void FlushPendingCritLabels(); // 0x00000001807C1060-0x00000001807C1120
	private void HandleSkillCast(ChatMessageDTO m); // 0x00000001807C1120-0x00000001807C2200
	[IteratorStateMachine(typeof(_ClearMega2HintsAfter_d__117))]
	private IEnumerator ClearMega2HintsAfter(float sec); // 0x00000001807C2200-0x00000001807C22C0
	[IteratorStateMachine(typeof(_ClearGalaxyHintsAfter_d__118))]
	private IEnumerator ClearGalaxyHintsAfter(float sec); // 0x00000001807C22C0-0x00000001807C2380
	[IteratorStateMachine(typeof(_ClearMegaIcarusHintsAfter_d__119))]
	private IEnumerator ClearMegaIcarusHintsAfter(float sec); // 0x00000001807C2380-0x00000001807C2440
	private static int CountIn(HashSet<Vector2Int> a, HashSet<Vector2Int> b); // 0x00000001807C2440-0x00000001807C25C0
	private Vector3 HealCellBoardCenter(); // 0x00000001807C25C0-0x00000001807C29C0
	[IteratorStateMachine(typeof(_ApplyDotConvert_d__127))]
	private IEnumerator ApplyDotConvert(MatchOpDTO op, float speed); // 0x00000001807C29C0-0x00000001807C2AE0
	private GameObject DotAt(int col, int row); // 0x00000001807C2AE0-0x00000001807C2C40
	private static Color ConvertGlowColor(string tag); // 0x00000001807C2C40-0x00000001807C2EA0
	private void SpawnConvertHalo(GameObject host, Color color, float life); // 0x00000001807C2EA0-0x00000001807C3830
	private void ClearConvertHalos(); // 0x00000001807C3830-0x00000001807C3A30
	[IteratorStateMachine(typeof(_ApplyMegaIcarusMark_d__132))]
	private IEnumerator ApplyMegaIcarusMark(MatchOpDTO op, float speed); // 0x00000001807C3A30-0x00000001807C3B50
	private static bool IsGalaxyRickyCardOp(MatchOpDTO op); // 0x00000001807C3B50-0x00000001807C3C40
	[IteratorStateMachine(typeof(_ApplyCardUse_d__134))]
	private IEnumerator ApplyCardUse(MatchOpDTO op); // 0x00000001807C3C40-0x00000001807C3D50
	private static Sprite LoadCardArtById(int cardId); // 0x00000001807C3D50-0x00000001807C4340
	public static void ResetStaticState(); // 0x00000001807C4340-0x00000001807C43B0
	internal static void NotifyLocalSkillCardShown(int cardId); // 0x00000001807C43B0-0x00000001807C4460
	private static bool ConsumeLocalSkillCardShown(int cardId); // 0x00000001807C4460-0x00000001807C4530
	private CardUIPVP FindCardUIByCardId(int cardId); // 0x00000001807C4530-0x00000001807C46F0
	private void HandleTurnEnd(); // 0x00000001807C46F0-0x00000001807C4780
	private void HandleMatchReject(string reason); // 0x00000001807C4780-0x00000001807C4D30
	public void PlayLocalInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x00000001807C4D30-0x00000001807C4E10
	[IteratorStateMachine(typeof(_PlayInvalidSwapFeedback_d__148))]
	private IEnumerator PlayInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x00000001807C4E10-0x00000001807C4EE0
	private void ResetDotToActualPosition(int col, int row); // 0x00000001807C4EE0-0x00000001807C5130
	private void HandleGameOver(string winner); // 0x00000001807C5130-0x00000001807C5700
	private void HandlePlayerLeft(string username, bool isPermanent, string reason); // 0x00000001807C5700-0x00000001807C5A70
	private void HandlePlayerRejoin(string username); // 0x00000001807C5A70-0x00000001807C5B70
	private void HandleAfkWarn(string username, int idleCount, int threshold); // 0x00000001807C5B70-0x00000001807C5D70
	private static void ShowToast(string message); // 0x00000001807C5D70-0x00000001807C5D90
	private bool InBounds(int col, int row); // 0x00000001807C5D90-0x00000001807C5EB0
	private void UpdateDotPos(GameObject go, int col, int row); // 0x00000001807C5EB0-0x00000001807C6050
	[IteratorStateMachine(typeof(_ApplyGalaxyRickyPick_d__158))]
	private IEnumerator ApplyGalaxyRickyPick(MatchOpDTO op, float speed); // 0x00000001807C6050-0x00000001807C6170
	private static double ReadDouble(Dictionary<string, object> d, string key, double fb = 0 /* Metadata: 0x005ED74C */); // 0x00000001807C6170-0x00000001807C63D0
	private static int ReadInt(Dictionary<string, object> d, string key, int fb = 0 /* Metadata: 0x005ED754 */); // 0x00000001807C63D0-0x00000001807C64F0
}

