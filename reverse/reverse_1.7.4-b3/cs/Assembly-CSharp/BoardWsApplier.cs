/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class BoardWsApplier : MonoBehaviour // TypeDefIndex: 438
{
	// Fields
	private Board board; // 0x20
	private bool _subscribed; // 0x28
	private string _bootstrappedMatchId; // 0x30
	[CompilerGenerated]
	private static string _BootstrappedMatchId_k__BackingField; // 0x00
	private bool _boardBuildRunning; // 0x38
	private const int SPAWN_YIELD_EVERY = 16; // Metadata: 0x005EE0A4
	private Transform _cachedDotsParent; // 0x40
	private Board _cachedDotsParentOwner; // 0x48
	private readonly Dictionary<string, GameObject> _prefabByTag; // 0x50
	private object _prefabTableOwner; // 0x58
	private static bool _tagFallbackWarned; // 0x08
	[TupleElementNames(new string[3] {"ops", "combat", "fx" })]
	private readonly Queue<ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator>> _pendingBatches; // 0x60
	private bool _renderRunning; // 0x68
	private bool _boardHiddenForCard; // 0x69
	private float _lastFallStartedAt; // 0x6C
	private float _lastFallNeedSec; // 0x70
	internal const string BossUsername = "__BOSS__"; // Metadata: 0x005EE0A5
	private bool _batchTouchesBoard; // 0x74
	private Coroutine _drainCo; // 0x78
	private GuardedEnumerator _activeRun; // 0x80
	[TupleElementNames(new string[3] {"ops", "combat", "fx" })]
	private ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator> _activeBatch; // 0x88
	private float _activeBatchStartedAt; // 0xA0
	private const float RenderBatchHardCapSec = 30f; // Metadata: 0x005EE0AE
	private float _lastFaultResyncAt; // 0xA4
	private bool _suppressBarRefresh; // 0xA8
	private float _lastCastVfxAt; // 0xAC
	private const float CastVfxDedupeSec = 3f; // Metadata: 0x005EE0B2
	private static readonly Dictionary<string, int> _audioTagBuf; // 0x10
	private const float ShuffleShrinkSec = 0.22f; // Metadata: 0x005EE0B6
	private const float ShuffleWaveDelayPerCell = 0.018f; // Metadata: 0x005EE0BA
	private const float ShuffleEmptyBoardSec = 0.05f; // Metadata: 0x005EE0BE
	private bool _healPopupBusy; // 0xB0
	private readonly Queue<HealPopupReq> _healPopupQueue; // 0xB8
	private const int HealPopupQueueMax = 3; // Metadata: 0x005EE0C2
	private const float HealPopupGapSec = 0.25f; // Metadata: 0x005EE0C3
	private static readonly Color GUILD_HINT_COLOR; // 0x18
	private static readonly Color GUILD_DANGER_COLOR; // 0x28
	private GuildRaidHud _raidHud; // 0xC0
	private Coroutine _raidClockCo; // 0xC8
	private bool _raidHudLogged; // 0xD0
	private long _raidMyDamage; // 0xD8
	private bool _raidTerminalShown; // 0xE0
	private const float DotConvertTelegraphSec = 0.35f; // Metadata: 0x005EE0C7
	private const float DotConvertMorphSec = 0.25f; // Metadata: 0x005EE0CB
	private const float DotConvertStaggerSec = 0.04f; // Metadata: 0x005EE0CF
	private readonly List<GameObject> _convertHalos; // 0xE8
	private const float MegaIcarusMarkHoldSec = 0.9f; // Metadata: 0x005EE0D3
	private const float EvolveHpRevealSec = 0.15f; // Metadata: 0x005EE0D7
	private const float RemoteCardLabelLifeSec = 1.55f; // Metadata: 0x005EE0DB
	private static readonly Dictionary<int, Sprite> _remoteCardArtCache; // 0x38
	private static readonly Dictionary<int, Sprite> _bossCardArtCache; // 0x40
	private static int _localShownCardId; // 0x48
	private static float _localShownAt; // 0x4C
	private const float LocalShownTtlSec = 20f; // Metadata: 0x005EE0DF
	private const float InvalidSwapFlashSec = 0.25f; // Metadata: 0x005EE0E3
	private readonly HashSet<string> _offlineToastShown; // 0xF0
	private bool _pendingCritAtSelf; // 0xF8
	private bool _pendingCritAtEnemy; // 0xF9

	// Properties
	public static string BootstrappedMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018035DBE0-0x000000018035DC40 0x000000018035DC40-0x000000018035DCF0

	// Nested types
	private struct HealPopupReq // TypeDefIndex: 439
	{
		// Fields
		public bool npcSide; // 0x00
		public int amount; // 0x04
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass124_0 // TypeDefIndex: 440
	{
		// Fields
		public Image img; // 0x10
		public Color home; // 0x18

		// Constructors
		public __c__DisplayClass124_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlashBossHpBar_b__0(float t); // 0x00000001803753C0-0x0000000180375580
		internal void _FlashBossHpBar_b__1(); // 0x0000000180375580-0x0000000180375690
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass151_0 // TypeDefIndex: 441
	{
		// Fields
		public SpriteRenderer sr; // 0x10
		public Color color; // 0x18
		public GameObject halo; // 0x28
		public float life; // 0x30
		public Action<float> __9__2; // 0x38

		// Constructors
		public __c__DisplayClass151_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpawnConvertHalo_b__0(float a); // 0x0000000180375690-0x0000000180375810
		internal void _SpawnConvertHalo_b__1(); // 0x0000000180375810-0x0000000180375A20
		internal void _SpawnConvertHalo_b__2(float a); // 0x0000000180375A20-0x0000000180375BA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass157_0 // TypeDefIndex: 442
	{
		// Fields
		public SpriteRenderer host; // 0x10
		public Color baseColor; // 0x18
		public GameObject go; // 0x28
		public Action<float> __9__2; // 0x30
		public Action __9__3; // 0x38

		// Constructors
		public __c__DisplayClass157_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayEnemyEvolveFlash_b__0(float t); // 0x0000000180375BA0-0x0000000180375D90
		internal void _PlayEnemyEvolveFlash_b__1(); // 0x0000000180375D90-0x0000000180376070
		internal void _PlayEnemyEvolveFlash_b__2(float t); // 0x0000000180376070-0x0000000180376260
		internal void _PlayEnemyEvolveFlash_b__3(); // 0x0000000180376260-0x00000001803763B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass160_0 // TypeDefIndex: 443
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18
		public Action __9__1; // 0x28

		// Constructors
		public __c__DisplayClass160_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayEnemyPowerUpPunch_b__0(); // 0x00000001803763B0-0x00000001803765E0
		internal void _PlayEnemyPowerUpPunch_b__1(); // 0x00000001803765E0-0x0000000180376750
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass164_0 // TypeDefIndex: 444
	{
		// Fields
		public bool done; // 0x10

		// Constructors
		public __c__DisplayClass164_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RunWithTimeout_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
	}

	[CompilerGenerated]
	private sealed class _ApplyCardUse_d__172 : IEnumerator<object> // TypeDefIndex: 445
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplier __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyCardUse_d__172(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180376750-0x0000000180377490
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180377490-0x00000001803774D0
	}

	[CompilerGenerated]
	private sealed class _ApplyDestroySequenced_d__90 : IEnumerator<object> // TypeDefIndex: 446
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplier __4__this; // 0x28
		public int destroyRound; // 0x30
		public float speed; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDestroySequenced_d__90(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001803774D0-0x0000000180377D10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180377D10-0x0000000180377D50
	}

	[CompilerGenerated]
	private sealed class _ApplyDotConvert_d__148 : IEnumerator<object> // TypeDefIndex: 447
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
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
		public _ApplyDotConvert_d__148(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180377D50-0x0000000180377EC0
		private bool MoveNext(); // 0x0000000180377EC0-0x00000001803792E0
		private void __m__Finally1(); // 0x00000001803792E0-0x00000001803792F0
		private void __m__Finally2(); // 0x00000001803792E0-0x00000001803792F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803792F0-0x0000000180379330
	}

	[CompilerGenerated]
	private sealed class _ApplyGalaxyRickyPick_d__143 : IEnumerator<object> // TypeDefIndex: 448
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public float speed; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyGalaxyRickyPick_d__143(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180379330-0x00000001803795A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803795A0-0x00000001803795E0
	}

	[CompilerGenerated]
	private sealed class _ApplyMegaIcarusMark_d__153 : IEnumerator<object> // TypeDefIndex: 449
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyMegaIcarusMark_d__153(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001803795E0-0x000000018037A2F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037A2F0-0x000000018037A330
	}

	[CompilerGenerated]
	private sealed class _ApplyOp_d__86 : IEnumerator<object> // TypeDefIndex: 450
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplier __4__this; // 0x28
		public float speed; // 0x30
		public int destroyRound; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOp_d__86(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018037A330-0x000000018037B150
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037B150-0x000000018037B190
	}

	[CompilerGenerated]
	private sealed class _ApplyOpsInner_d__84 : IEnumerator<object> // TypeDefIndex: 451
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
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
		public _ApplyOpsInner_d__84(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018037B190-0x000000018037B200
		private bool MoveNext(); // 0x000000018037B200-0x000000018037B960
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037B960-0x000000018037B9A0
	}

	[CompilerGenerated]
	private sealed class _ApplyOpsSequential_d__71 : IEnumerator<object> // TypeDefIndex: 452
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WsCombatBatch combat; // 0x20
		public List<MatchOpDTO> ops; // 0x28
		public BoardWsApplier __4__this; // 0x30
		private bool _wasFullPower_5__2; // 0x38
		private bool _bossBatch_5__3; // 0x39

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOpsSequential_d__71(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018037B9A0-0x000000018037C510
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037C510-0x000000018037C550
	}

	[CompilerGenerated]
	private sealed class _ApplyShuffle_d__97 : IEnumerator<object> // TypeDefIndex: 453
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30
		private BoardCellDTO[][] _grid_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyShuffle_d__97(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x000000018037C550-0x000000018037D230
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037D230-0x000000018037D270
	}

	[CompilerGenerated]
	private sealed class _ApplyVfx_d__142 : IEnumerator<object> // TypeDefIndex: 454
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplier __4__this; // 0x28
		public float speed; // 0x30
		private int _healed_5__2; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyVfx_d__142(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018037D270-0x000000018037DFA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037DFA0-0x000000018037DFE0
	}

	[CompilerGenerated]
	private sealed class _BootstrapMatch_d__20 : IEnumerator<object> // TypeDefIndex: 455
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		public BoardCellDTO[][] preBoard; // 0x30
		private float _wait_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BootstrapMatch_d__20(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018037DFE0-0x000000018037E4D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037E4D0-0x000000018037E510
	}

	[CompilerGenerated]
	private sealed class _ClearGalaxyHintsAfter_d__79 : IEnumerator<object> // TypeDefIndex: 456
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplier __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClearGalaxyHintsAfter_d__79(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018037E510-0x000000018037E600
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037E600-0x000000018037E640
	}

	[CompilerGenerated]
	private sealed class _ClearMega2HintsAfter_d__80 : IEnumerator<object> // TypeDefIndex: 457
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplier __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClearMega2HintsAfter_d__80(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018037E640-0x000000018037E730
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037E730-0x000000018037E770
	}

	[CompilerGenerated]
	private sealed class _ClearMegaIcarusHintsAfter_d__81 : IEnumerator<object> // TypeDefIndex: 458
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplier __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClearMegaIcarusHintsAfter_d__81(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018037E770-0x000000018037E860
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037E860-0x000000018037E8A0
	}

	[CompilerGenerated]
	private sealed class _DrainBatchQueue_d__62 : IEnumerator<object> // TypeDefIndex: 459
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
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
		void IDisposable.Dispose(); // 0x000000018037E8A0-0x000000018037E970
		private bool MoveNext(); // 0x000000018037E970-0x000000018037EDE0
		private void __m__Finally1(); // 0x000000018037EDE0-0x000000018037EE80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037EE80-0x000000018037EEC0
	}

	[CompilerGenerated]
	private sealed class _DrainHealPopupQueue_d__111 : IEnumerator<object> // TypeDefIndex: 460
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DrainHealPopupQueue_d__111(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018037EEC0-0x000000018037F1B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037F1B0-0x000000018037F1F0
	}

	[CompilerGenerated]
	private sealed class _EnsureFusionCardsWhenReady_d__168 : IEnumerator<object> // TypeDefIndex: 461
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		private float _deadline_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _EnsureFusionCardsWhenReady_d__168(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018037F1F0-0x000000018037F630
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037F630-0x000000018037F670
	}

	[CompilerGenerated]
	private sealed class _LoadBoardFromSnapshot_d__25 : IEnumerator<object> // TypeDefIndex: 462
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		public BoardCellDTO[][] preBoard; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadBoardFromSnapshot_d__25(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018037F670-0x000000018037F700
		private bool MoveNext(); // 0x000000018037F700-0x000000018037FA30
		private void __m__Finally1(); // 0x000000018037FA30-0x000000018037FA60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037FA60-0x000000018037FAA0
	}

	[CompilerGenerated]
	private sealed class _LoadBoardFromSnapshotCore_d__26 : IEnumerator<object> // TypeDefIndex: 463
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
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
		public _LoadBoardFromSnapshotCore_d__26(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018037B190-0x000000018037B200
		private bool MoveNext(); // 0x000000018037FAA0-0x00000001803803E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803803E0-0x0000000180380420
	}

	[CompilerGenerated]
	private sealed class _PlayFusionResultFx_d__163 : IEnumerator<object> // TypeDefIndex: 464
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public bool isLocal; // 0x28
		public int actorNum; // 0x2C
		public bool success; // 0x30
		public int pityAfter; // 0x34
		public int pityBefore; // 0x38
		public int ghostPetId; // 0x3C
		private bool _hidBoard_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayFusionResultFx_d__163(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180380420-0x0000000180380490
		private bool MoveNext(); // 0x0000000180380490-0x0000000180381100
		private void __m__Finally1(); // 0x0000000180381100-0x0000000180381220
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180381220-0x0000000180381260
	}

	[CompilerGenerated]
	private sealed class _PlayInvalidSwapFeedback_d__190 : IEnumerator<object> // TypeDefIndex: 465
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
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
		public _PlayInvalidSwapFeedback_d__190(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180381260-0x0000000180381320
		private bool MoveNext(); // 0x0000000180381320-0x0000000180381A70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180381A70-0x0000000180381AB0
	}

	[CompilerGenerated]
	private sealed class _PlayRemoteCardWithOwnerLabel_d__174 : IEnumerator<object> // TypeDefIndex: 466
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Sprite art; // 0x20
		public string ownerName; // 0x28
		public BoardWsApplier __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayRemoteCardWithOwnerLabel_d__174(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180381AB0-0x0000000180381D50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180381D50-0x0000000180381D90
	}

	[CompilerGenerated]
	private sealed class _RaidClockLoop_d__134 : IEnumerator<object> // TypeDefIndex: 467
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RaidClockLoop_d__134(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180381D90-0x00000001803822F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803822F0-0x0000000180382330
	}

	[CompilerGenerated]
	private sealed class _ResyncMatch_d__22 : IEnumerator<object> // TypeDefIndex: 468
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		public BoardCellDTO[][] preBoard; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ResyncMatch_d__22(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180382330-0x0000000180382930
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180382930-0x0000000180382970
	}

	[CompilerGenerated]
	private sealed class _RunThenFlag_d__165 : IEnumerator<object> // TypeDefIndex: 469
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
		public _RunThenFlag_d__165(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180382970-0x0000000180382A10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180382A10-0x0000000180382A50
	}

	[CompilerGenerated]
	private sealed class _RunWithTimeout_d__164 : IEnumerator<object> // TypeDefIndex: 470
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public IEnumerator inner; // 0x28
		public float timeoutSec; // 0x30
		private __c__DisplayClass164_0 __8__1; // 0x38
		private float _deadline_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RunWithTimeout_d__164(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180382A50-0x0000000180382E20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180382E20-0x0000000180382E60
	}

	[CompilerGenerated]
	private sealed class _ShowRemoteCardOwnerLabel_d__175 : IEnumerator<object> // TypeDefIndex: 471
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string ownerName; // 0x20
		private GameObject _go_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowRemoteCardOwnerLabel_d__175(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180382E60-0x0000000180383500
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180383500-0x0000000180383540
	}

	[CompilerGenerated]
	private sealed class _WaitForFallToSettle_d__45 : IEnumerator<object> // TypeDefIndex: 472
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitForFallToSettle_d__45(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180383540-0x0000000180383840
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180383840-0x0000000180383880
	}

	// Constructors
	public BoardWsApplier(); // 0x00000001803747C0-0x0000000180374D20
	static BoardWsApplier(); // 0x0000000180374D20-0x00000001803752E0

	// Methods
	private void Awake(); // 0x000000018035B770-0x000000018035B850
	private void Start(); // 0x000000018035B850-0x000000018035B880
	private void OnEnable(); // 0x000000018035B880-0x000000018035B8A0
	private void OnDisable(); // 0x000000018035B8A0-0x000000018035BA60
	private void OnDestroy(); // 0x000000018035BA60-0x000000018035BD60
	private void RegisterBusyProbe(); // 0x000000018035BD60-0x000000018035BEB0
	private bool IsRendererBusy(); // 0x000000018035BEB0-0x000000018035BEE0
	private void EnsureBoardRef(); // 0x000000018035BEE0-0x000000018035C230
	private void EnsureMoveHint(); // 0x000000018035C230-0x000000018035C450
	private void TrySubscribe(); // 0x000000018035C450-0x000000018035CE60
	private void HandleEnergyDeltaWarn(ChatMessageDTO m); // 0x000000018035CE60-0x000000018035D1E0
	private void Unsubscribe(); // 0x000000018035D1E0-0x000000018035DBE0
	private void HandleMatchStart(ChatMessageDTO m); // 0x000000018035DCF0-0x000000018035E3E0
	[IteratorStateMachine(typeof(_BootstrapMatch_d__20))]
	private IEnumerator BootstrapMatch(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x000000018035E3E0-0x000000018035E540
	private void HandleMatchResync(ChatMessageDTO m); // 0x000000018035E540-0x000000018035E890
	[IteratorStateMachine(typeof(_ResyncMatch_d__22))]
	private IEnumerator ResyncMatch(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x000000018035E890-0x000000018035E9F0
	private void ResetStatusFxForMatch(); // 0x000000018035E9F0-0x000000018035ED50
	[IteratorStateMachine(typeof(_LoadBoardFromSnapshot_d__25))]
	private IEnumerator LoadBoardFromSnapshot(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x000000018035ED50-0x000000018035EEB0
	[IteratorStateMachine(typeof(_LoadBoardFromSnapshotCore_d__26))]
	private IEnumerator LoadBoardFromSnapshotCore(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x000000018035EEB0-0x000000018035F010
	private void ClearDotsAbsentFromSnapshot(BoardCellDTO[][] serverBoard); // 0x000000018035F010-0x000000018035F330
	private void ClearAllDots(); // 0x000000018035F330-0x000000018035F560
	private Transform GetCachedDotsParent(); // 0x000000018035F560-0x000000018035F8B0
	private GameObject FindDotPrefabByTag(string tag); // 0x000000018035F8B0-0x000000018035FC80
	private void EnsurePrefabTable(); // 0x000000018035FC80-0x0000000180360060
	private static void WarnTagManagerOnce(string tag); // 0x0000000180360060-0x0000000180360140
	private void SpawnDotByTag(int col, int row, string tag, int multiplier, bool fallFromAbove = false /* Metadata: 0x005EE098 */); // 0x0000000180360140-0x0000000180360A00
	[IteratorStateMachine(typeof(_WaitForFallToSettle_d__45))]
	private IEnumerator WaitForFallToSettle(); // 0x0000000180360A00-0x0000000180360AA0
	private static bool IsSkillCardOp(MatchOpDTO op); // 0x0000000180360AA0-0x0000000180360C70
	private static bool IsBossCardOp(MatchOpDTO op); // 0x0000000180360C70-0x0000000180360DC0
	private static bool IsLocalUserCardOp(MatchOpDTO op); // 0x0000000180360DC0-0x0000000180360F90
	private static bool BatchTouchesBoard(List<MatchOpDTO> ops); // 0x0000000180360F90-0x00000001803612A0
	private static bool HasSkillCardOp(List<MatchOpDTO> ops); // 0x00000001803612A0-0x0000000180361480
	private static string ReadSkillElementType(List<MatchOpDTO> ops); // 0x0000000180361480-0x00000001803616E0
	private void HandleOpsApplied(List<MatchOpDTO> ops); // 0x00000001803616E0-0x0000000180361A80
	private void EnqueueFxOnly(IEnumerator fx); // 0x0000000180361A80-0x0000000180361B70
	private void KickDrain(); // 0x0000000180361B70-0x0000000180361CA0
	[IteratorStateMachine(typeof(_DrainBatchQueue_d__62))]
	private IEnumerator DrainBatchQueue(); // 0x0000000180361CA0-0x0000000180361D40
	private void AbortRenderInFlight(string reason); // 0x0000000180361D40-0x0000000180361F80
	private void AbortStuckRenderIfAny(string where); // 0x0000000180361F80-0x00000001803621A0
	private void RecoverFromRenderError([TupleElementNames(new string[3] {"ops", "combat", "fx" })] ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator> batch, Exception e); // 0x00000001803621A0-0x00000001803624E0
	private void RestoreBoardAfterAbortedRender(bool openInput); // 0x00000001803624E0-0x0000000180362730
	private void NormalizeDotsAfterAbort(); // 0x0000000180362730-0x0000000180362B00
	private void RequestResyncAfterRenderFault(); // 0x0000000180362B00-0x0000000180362D80
	[IteratorStateMachine(typeof(_ApplyOpsSequential_d__71))]
	private IEnumerator ApplyOpsSequential(List<MatchOpDTO> ops, WsCombatBatch combat); // 0x0000000180362D80-0x0000000180362EE0
	private static bool DetectFullPowerSpend(List<MatchOpDTO> ops, string actorUsername, List<WsCombatStepDTO> steps = null); // 0x0000000180362EE0-0x0000000180362F00
	private void HandleBossAction(ChatMessageDTO m); // 0x0000000180362F00-0x00000001803633D0
	private static string ReadSingleBossTarget(Dictionary<string, object> p); // 0x00000001803633D0-0x00000001803635D0
	private void SwitchDisplayToBossVictim(string username); // 0x00000001803635D0-0x0000000180363650
	private void HandleSkillCast(ChatMessageDTO m); // 0x0000000180363650-0x0000000180364660
	[IteratorStateMachine(typeof(_ClearGalaxyHintsAfter_d__79))]
	private IEnumerator ClearGalaxyHintsAfter(float sec); // 0x0000000180364660-0x0000000180364720
	[IteratorStateMachine(typeof(_ClearMega2HintsAfter_d__80))]
	private IEnumerator ClearMega2HintsAfter(float sec); // 0x0000000180364720-0x00000001803647E0
	[IteratorStateMachine(typeof(_ClearMegaIcarusHintsAfter_d__81))]
	private IEnumerator ClearMegaIcarusHintsAfter(float sec); // 0x00000001803647E0-0x00000001803648A0
	private void HandleSkillHint(ChatMessageDTO m); // 0x00000001803648A0-0x0000000180364EA0
	private void HandleQteEvent(ChatMessageDTO m); // 0x0000000180364EA0-0x0000000180365200
	[IteratorStateMachine(typeof(_ApplyOpsInner_d__84))]
	private IEnumerator ApplyOpsInner(List<MatchOpDTO> ops); // 0x0000000180365200-0x0000000180365310
	private void ApplyFallOrSpawn(MatchOpDTO op); // 0x0000000180365310-0x00000001803653C0
	[IteratorStateMachine(typeof(_ApplyOp_d__86))]
	private IEnumerator ApplyOp(MatchOpDTO op, float speed, int destroyRound); // 0x00000001803653C0-0x00000001803654E0
	private void ApplyHighlight(MatchOpDTO op); // 0x00000001803654E0-0x0000000180365A60
	private void ApplySwap(MatchOpDTO op); // 0x0000000180365A60-0x0000000180365E40
	private void ClearPredictionFlag(GameObject go); // 0x0000000180365E40-0x0000000180365F60
	[IteratorStateMachine(typeof(_ApplyDestroySequenced_d__90))]
	private IEnumerator ApplyDestroySequenced(MatchOpDTO op, float speed, int destroyRound); // 0x0000000180365F60-0x0000000180366080
	private static void PlayMatchAudioOncePerTag(List<GameObject> targets, int destroyRound); // 0x0000000180366080-0x00000001803665D0
	private int VerifyBoardAgainstServer(BoardCellDTO[][] serverBoard); // 0x00000001803665D0-0x0000000180366B50
	[IteratorStateMachine(typeof(_ApplyShuffle_d__97))]
	private IEnumerator ApplyShuffle(MatchOpDTO op, float speed); // 0x0000000180366B50-0x0000000180366C70
	private static BoardCellDTO[][] ParseShuffleBoard(MatchOpDTO op); // 0x0000000180366C70-0x0000000180366E80
	private static string ReadString(Dictionary<string, object> d, string key, string fb = null); // 0x0000000180366E80-0x0000000180366F20
	private void ApplyFall(MatchOpDTO op); // 0x0000000180366F20-0x0000000180367280
	private void ApplySpawn(MatchOpDTO op); // 0x0000000180367280-0x00000001803675C0
	private void ApplyStatChange(MatchOpDTO op); // 0x00000001803675C0-0x0000000180368390
	private static string ReadReason(Dictionary<string, object> data); // 0x0000000180368390-0x0000000180368430
	private static bool IsHealReason(string reason); // 0x0000000180368430-0x0000000180368520
	private void ShowHealPopup(string user, int amount); // 0x0000000180368520-0x0000000180368830
	[IteratorStateMachine(typeof(_DrainHealPopupQueue_d__111))]
	private IEnumerator DrainHealPopupQueue(); // 0x0000000180368830-0x00000001803688D0
	private void ApplyBossHp(MatchOpDTO op); // 0x00000001803688D0-0x0000000180368E00
	private static bool InGuildBossMatch(MatchService ms); // 0x0000000180368E00-0x0000000180369040
	private void HandleGuildBossHp(ChatMessageDTO m); // 0x0000000180369040-0x00000001803693E0
	private static string GuildKillBanner(ChatMessageDTO m); // 0x00000001803693E0-0x00000001803695B0
	private void ApplyGuildBossHpValue(long hp, bool force); // 0x00000001803695B0-0x0000000180369AE0
	private void FlashBossHpBar(); // 0x0000000180369AE0-0x000000018036A050
	private void ShowGuildMateDamage(ChatMessageDTO m); // 0x000000018036A050-0x000000018036A400
	private void PlayRaidTerminalFx(string banner, Color color); // 0x000000018036A400-0x000000018036A5A0
	private void RefreshGuildBossUi(); // 0x000000018036A5A0-0x000000018036AA80
	private void ResetGuildBossUi(); // 0x000000018036AA80-0x000000018036ABF0
	private void TearDownRaidHud(); // 0x000000018036ABF0-0x000000018036ADB0
	private void OnSceneUnloadedForRaidHud(Scene scene); // 0x000000018036ADB0-0x000000018036AF60
	private static bool IsMatchSceneName(string name); // 0x000000018036AF60-0x000000018036B0E0
	private static bool IsMatchRigAlive(); // 0x000000018036B0E0-0x000000018036B1F0
	private static Transform FindMatchHudCanvas(); // 0x000000018036B1F0-0x000000018036B750
	[IteratorStateMachine(typeof(_RaidClockLoop_d__134))]
	private IEnumerator RaidClockLoop(); // 0x000000018036B750-0x000000018036B7F0
	private static long RaidClosesAtMs(); // 0x000000018036B7F0-0x000000018036B990
	private void UpdateRaidClockText(); // 0x000000018036B990-0x000000018036BD60
	private void UpdateRaidDamageText(); // 0x000000018036BD60-0x000000018036BFA0
	private bool EnsureRaidHud(); // 0x000000018036BFA0-0x000000018036C4A0
	private void ApplyShieldExpire(MatchOpDTO op); // 0x000000018036C4A0-0x000000018036C760
	private void ApplyStatus(MatchOpDTO op); // 0x000000018036C760-0x000000018036D0C0
	private int ResolveActorByUsername(string username); // 0x000000018036D0C0-0x000000018036D180
	[IteratorStateMachine(typeof(_ApplyVfx_d__142))]
	private IEnumerator ApplyVfx(MatchOpDTO op, float speed); // 0x000000018036D180-0x000000018036D2A0
	[IteratorStateMachine(typeof(_ApplyGalaxyRickyPick_d__143))]
	private IEnumerator ApplyGalaxyRickyPick(MatchOpDTO op, float speed); // 0x000000018036D2A0-0x000000018036D360
	[IteratorStateMachine(typeof(_ApplyDotConvert_d__148))]
	private IEnumerator ApplyDotConvert(MatchOpDTO op, float speed); // 0x000000018036D360-0x000000018036D480
	private GameObject DotAt(int col, int row); // 0x000000018036D480-0x000000018036D5E0
	private static Color ConvertGlowColor(string tag); // 0x000000018036D5E0-0x000000018036D840
	private void SpawnConvertHalo(GameObject host, Color color, float life); // 0x000000018036D840-0x000000018036E1D0
	private void ClearConvertHalos(); // 0x000000018036E1D0-0x000000018036E3D0
	[IteratorStateMachine(typeof(_ApplyMegaIcarusMark_d__153))]
	private IEnumerator ApplyMegaIcarusMark(MatchOpDTO op, float speed); // 0x000000018036E3D0-0x000000018036E4F0
	private static int CountIn(HashSet<Vector2Int> a, HashSet<Vector2Int> b); // 0x000000018036E4F0-0x000000018036E670
	private Vector3 HealCellBoardCenter(); // 0x000000018036E670-0x000000018036EA80
	private void PlayEnemyEvolveFlash(); // 0x000000018036EA80-0x000000018036EEC0
	private void RefreshBossHpAfterEvolve(int healed); // 0x000000018036EEC0-0x000000018036EF60
	private void PlayEnemyPowerUpPunch(); // 0x000000018036EF60-0x000000018036F570
	private void HandleFusionResolved(ChatMessageDTO m); // 0x000000018036F570-0x00000001803700E0
	private SpriteRenderer FusionPityHostFor(int actorNum); // 0x00000001803700E0-0x0000000180370200
	[IteratorStateMachine(typeof(_PlayFusionResultFx_d__163))]
	private IEnumerator PlayFusionResultFx(bool success, bool isLocal, string actor, string petName, int ghostPetId, int actorNum, int pityBefore, int pityAfter); // 0x0000000180370200-0x00000001803702E0
	[IteratorStateMachine(typeof(_RunWithTimeout_d__164))]
	private IEnumerator RunWithTimeout(IEnumerator inner, float timeoutSec); // 0x00000001803702E0-0x0000000180370400
	[IteratorStateMachine(typeof(_RunThenFlag_d__165))]
	private static IEnumerator RunThenFlag(IEnumerator inner, Action onDone); // 0x0000000180370400-0x0000000180370510
	private CardUI FindFusionCardUI(); // 0x0000000180370510-0x00000001803708B0
	private void UnlockFusionCard(); // 0x00000001803708B0-0x0000000180370BF0
	[IteratorStateMachine(typeof(_EnsureFusionCardsWhenReady_d__168))]
	private IEnumerator EnsureFusionCardsWhenReady(); // 0x0000000180370BF0-0x0000000180370C90
	private static bool ReadPayloadBool(Dictionary<string, object> p, string key); // 0x0000000180370C90-0x0000000180370E10
	private static int ReadPayloadInt(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x005EE099 */); // 0x0000000180370E10-0x0000000180370F50
	private static bool IsGalaxyRickyCardOp(MatchOpDTO op); // 0x0000000180370F50-0x0000000180371040
	[IteratorStateMachine(typeof(_ApplyCardUse_d__172))]
	private IEnumerator ApplyCardUse(MatchOpDTO op); // 0x0000000180371040-0x0000000180371150
	[IteratorStateMachine(typeof(_PlayRemoteCardWithOwnerLabel_d__174))]
	private IEnumerator PlayRemoteCardWithOwnerLabel(Sprite art, string ownerName); // 0x0000000180371150-0x00000001803712B0
	[IteratorStateMachine(typeof(_ShowRemoteCardOwnerLabel_d__175))]
	private IEnumerator ShowRemoteCardOwnerLabel(string ownerName); // 0x00000001803712B0-0x0000000180371350
	private static string ResolveDisplayName(string username); // 0x0000000180371350-0x0000000180371420
	private static Sprite LoadCardArtById(int cardId); // 0x0000000180371420-0x0000000180371A10
	private static Sprite LoadBossCardArt(int cardId); // 0x0000000180371A10-0x0000000180372000
	internal static void NotifyLocalSkillCardShown(int cardId); // 0x0000000180372000-0x00000001803720B0
	private static bool ConsumeLocalSkillCardShown(int cardId); // 0x00000001803720B0-0x0000000180372180
	private CardUI FindCardUIByCardId(int cardId); // 0x0000000180372180-0x0000000180372340
	private void HandleTurnEnd(); // 0x0000000180372340-0x00000001803723F0
	private void HandleMatchReject(string reason); // 0x00000001803723F0-0x0000000180372A10
	public void PlayLocalInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x0000000180372A10-0x0000000180372AF0
	[IteratorStateMachine(typeof(_PlayInvalidSwapFeedback_d__190))]
	private IEnumerator PlayInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x0000000180372AF0-0x0000000180372BC0
	private void ResetDotToActualPosition(int col, int row); // 0x0000000180372BC0-0x0000000180372E10
	private void HandleGameOver(string winner); // 0x0000000180372E10-0x0000000180373650
	private void HandlePlayerLeft(string username, bool isPermanent, string reason); // 0x0000000180373650-0x0000000180373900
	private void HandleAfkWarn(string username, int idleCount, int threshold); // 0x0000000180373900-0x0000000180373AF0
	private void HandleAfkForfeit(string username, int threshold); // 0x0000000180373AF0-0x0000000180373C90
	private void HandlePlayerRejoin(string username); // 0x0000000180373C90-0x0000000180373DF0
	private int ResolveActorNumberFromUsername(string username); // 0x0000000180373DF0-0x0000000180373F20
	private bool InBounds(int col, int row); // 0x0000000180373F20-0x0000000180374050
	private void UpdateDotPos(GameObject go, int col, int row); // 0x0000000180374050-0x00000001803741F0
	private static int ReadInt(Dictionary<string, object> d, string key, int fb = 0 /* Metadata: 0x005EE09A */); // 0x00000001803741F0-0x0000000180374310
	private static bool ReadBool(Dictionary<string, object> d, string key, bool fb = false /* Metadata: 0x005EE09B */); // 0x0000000180374310-0x0000000180374480
	private void MarkCrit(bool atSelf); // 0x0000000180374480-0x00000001803744A0
	private void FlushPendingCritLabels(); // 0x00000001803744A0-0x0000000180374560
	private static double ReadDouble(Dictionary<string, object> d, string key, double fb = 0 /* Metadata: 0x005EE09C */); // 0x0000000180374560-0x00000001803747C0
}

