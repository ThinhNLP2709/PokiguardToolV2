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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	private const int SPAWN_YIELD_EVERY = 16; // Metadata: 0x005EF474
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
	internal const string BossUsername = "__BOSS__"; // Metadata: 0x005EF475
	private bool _batchTouchesBoard; // 0x74
	private Coroutine _drainCo; // 0x78
	private GuardedEnumerator _activeRun; // 0x80
	[TupleElementNames(new string[3] {"ops", "combat", "fx" })]
	private ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator> _activeBatch; // 0x88
	private float _activeBatchStartedAt; // 0xA0
	private const float RenderBatchHardCapSec = 30f; // Metadata: 0x005EF47E
	private float _lastFaultResyncAt; // 0xA4
	private bool _suppressBarRefresh; // 0xA8
	private float _lastCastVfxAt; // 0xAC
	private const float CastVfxDedupeSec = 3f; // Metadata: 0x005EF482
	private static readonly Dictionary<string, int> _audioTagBuf; // 0x10
	private const float ShuffleShrinkSec = 0.22f; // Metadata: 0x005EF486
	private const float ShuffleWaveDelayPerCell = 0.018f; // Metadata: 0x005EF48A
	private const float ShuffleEmptyBoardSec = 0.05f; // Metadata: 0x005EF48E
	private bool _healPopupBusy; // 0xB0
	private readonly Queue<HealPopupReq> _healPopupQueue; // 0xB8
	private const int HealPopupQueueMax = 3; // Metadata: 0x005EF492
	private const float HealPopupGapSec = 0.25f; // Metadata: 0x005EF493
	private static readonly Color GUILD_HINT_COLOR; // 0x18
	private static readonly Color GUILD_DANGER_COLOR; // 0x28
	private GuildRaidHud _raidHud; // 0xC0
	private Coroutine _raidClockCo; // 0xC8
	private bool _raidHudLogged; // 0xD0
	private long _raidMyDamage; // 0xD8
	private bool _raidTerminalShown; // 0xE0
	private const float DotConvertTelegraphSec = 0.35f; // Metadata: 0x005EF497
	private const float DotConvertMorphSec = 0.25f; // Metadata: 0x005EF49B
	private const float DotConvertStaggerSec = 0.04f; // Metadata: 0x005EF49F
	private readonly List<GameObject> _convertHalos; // 0xE8
	private const float MegaIcarusMarkHoldSec = 0.9f; // Metadata: 0x005EF4A3
	private const float EvolveHpRevealSec = 0.15f; // Metadata: 0x005EF4A7
	private const float RemoteCardLabelLifeSec = 1.55f; // Metadata: 0x005EF4AB
	private static readonly Dictionary<int, Sprite> _remoteCardArtCache; // 0x38
	private static readonly Dictionary<int, Sprite> _bossCardArtCache; // 0x40
	private static int _localShownCardId; // 0x48
	private static float _localShownAt; // 0x4C
	private const float LocalShownTtlSec = 20f; // Metadata: 0x005EF4AF
	private const float InvalidSwapFlashSec = 0.25f; // Metadata: 0x005EF4B3
	private readonly HashSet<string> _offlineToastShown; // 0xF0
	private bool _pendingCritAtSelf; // 0xF8
	private bool _pendingCritAtEnemy; // 0xF9

	// Properties
	public static string BootstrappedMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018035DDF0-0x000000018035DE50 0x000000018035DE50-0x000000018035DF00

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
		internal void _FlashBossHpBar_b__0(float t); // 0x0000000180375570-0x0000000180375730
		internal void _FlashBossHpBar_b__1(); // 0x0000000180375730-0x0000000180375840
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
		internal void _SpawnConvertHalo_b__0(float a); // 0x0000000180375840-0x00000001803759C0
		internal void _SpawnConvertHalo_b__1(); // 0x00000001803759C0-0x0000000180375BD0
		internal void _SpawnConvertHalo_b__2(float a); // 0x0000000180375BD0-0x0000000180375D50
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
		internal void _PlayEnemyEvolveFlash_b__0(float t); // 0x0000000180375D50-0x0000000180375F40
		internal void _PlayEnemyEvolveFlash_b__1(); // 0x0000000180375F40-0x0000000180376220
		internal void _PlayEnemyEvolveFlash_b__2(float t); // 0x0000000180376220-0x0000000180376410
		internal void _PlayEnemyEvolveFlash_b__3(); // 0x0000000180376410-0x0000000180376560
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
		internal void _PlayEnemyPowerUpPunch_b__0(); // 0x0000000180376560-0x0000000180376790
		internal void _PlayEnemyPowerUpPunch_b__1(); // 0x0000000180376790-0x0000000180376900
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass164_0 // TypeDefIndex: 444
	{
		// Fields
		public bool done; // 0x10

		// Constructors
		public __c__DisplayClass164_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RunWithTimeout_b__0(); // 0x0000000180308BD0-0x0000000180308BE0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180376900-0x0000000180377640
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180377640-0x0000000180377680
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180377680-0x0000000180377EC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180377EC0-0x0000000180377F00
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
		void IDisposable.Dispose(); // 0x0000000180377F00-0x0000000180378070
		private bool MoveNext(); // 0x0000000180378070-0x0000000180379490
		private void __m__Finally1(); // 0x0000000180379490-0x00000001803794A0
		private void __m__Finally2(); // 0x0000000180379490-0x00000001803794A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803794A0-0x00000001803794E0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001803794E0-0x0000000180379750
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180379750-0x0000000180379790
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180379790-0x000000018037A4A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037A4A0-0x000000018037A4E0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018037A4E0-0x000000018037B300
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037B300-0x000000018037B340
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
		void IDisposable.Dispose(); // 0x000000018037B340-0x000000018037B3B0
		private bool MoveNext(); // 0x000000018037B3B0-0x000000018037BB10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037BB10-0x000000018037BB50
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018037BB50-0x000000018037C6C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037C6C0-0x000000018037C700
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
		private bool MoveNext(); // 0x000000018037C700-0x000000018037D3E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037D3E0-0x000000018037D420
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018037D420-0x000000018037E150
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037E150-0x000000018037E190
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018037E190-0x000000018037E680
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037E680-0x000000018037E6C0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018037E6C0-0x000000018037E7B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037E7B0-0x000000018037E7F0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018037E7F0-0x000000018037E8E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037E8E0-0x000000018037E920
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018037E920-0x000000018037EA10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037EA10-0x000000018037EA50
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
		void IDisposable.Dispose(); // 0x000000018037EA50-0x000000018037EB20
		private bool MoveNext(); // 0x000000018037EB20-0x000000018037EF90
		private void __m__Finally1(); // 0x000000018037EF90-0x000000018037F030
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037F030-0x000000018037F070
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018037F070-0x000000018037F360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037F360-0x000000018037F3A0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018037F3A0-0x000000018037F7E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037F7E0-0x000000018037F820
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
		void IDisposable.Dispose(); // 0x000000018037F820-0x000000018037F8B0
		private bool MoveNext(); // 0x000000018037F8B0-0x000000018037FBE0
		private void __m__Finally1(); // 0x000000018037FBE0-0x000000018037FC10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018037FC10-0x000000018037FC50
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
		void IDisposable.Dispose(); // 0x000000018037B340-0x000000018037B3B0
		private bool MoveNext(); // 0x000000018037FC50-0x0000000180380590
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180380590-0x00000001803805D0
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
		void IDisposable.Dispose(); // 0x00000001803805D0-0x0000000180380640
		private bool MoveNext(); // 0x0000000180380640-0x00000001803812B0
		private void __m__Finally1(); // 0x00000001803812B0-0x00000001803813D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803813D0-0x0000000180381410
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
		void IDisposable.Dispose(); // 0x0000000180381410-0x00000001803814D0
		private bool MoveNext(); // 0x00000001803814D0-0x0000000180381C20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180381C20-0x0000000180381C60
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180381C60-0x0000000180381F00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180381F00-0x0000000180381F40
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
		private bool MoveNext(); // 0x0000000180381F40-0x00000001803824A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803824A0-0x00000001803824E0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001803824E0-0x0000000180382AE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180382AE0-0x0000000180382B20
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180382B20-0x0000000180382BC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180382BC0-0x0000000180382C00
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
		private bool MoveNext(); // 0x0000000180382C00-0x0000000180382FD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180382FD0-0x0000000180383010
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
		private bool MoveNext(); // 0x0000000180383010-0x00000001803836B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803836B0-0x00000001803836F0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001803836F0-0x00000001803839F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803839F0-0x0000000180383A30
	}

	// Constructors
	public BoardWsApplier(); // 0x00000001803749D0-0x0000000180374F30
	static BoardWsApplier(); // 0x0000000180374F30-0x0000000180375570

	// Methods
	private void Awake(); // 0x000000018035B980-0x000000018035BA60
	private void Start(); // 0x000000018035BA60-0x000000018035BA90
	private void OnEnable(); // 0x000000018035BA90-0x000000018035BAB0
	private void OnDisable(); // 0x000000018035BAB0-0x000000018035BC70
	private void OnDestroy(); // 0x000000018035BC70-0x000000018035BF70
	private void RegisterBusyProbe(); // 0x000000018035BF70-0x000000018035C0C0
	private bool IsRendererBusy(); // 0x000000018035C0C0-0x000000018035C0F0
	private void EnsureBoardRef(); // 0x000000018035C0F0-0x000000018035C440
	private void EnsureMoveHint(); // 0x000000018035C440-0x000000018035C660
	private void TrySubscribe(); // 0x000000018035C660-0x000000018035D070
	private void HandleEnergyDeltaWarn(ChatMessageDTO m); // 0x000000018035D070-0x000000018035D3F0
	private void Unsubscribe(); // 0x000000018035D3F0-0x000000018035DDF0
	private void HandleMatchStart(ChatMessageDTO m); // 0x000000018035DF00-0x000000018035E5F0
	[IteratorStateMachine(typeof(_BootstrapMatch_d__20))]
	private IEnumerator BootstrapMatch(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x000000018035E5F0-0x000000018035E750
	private void HandleMatchResync(ChatMessageDTO m); // 0x000000018035E750-0x000000018035EAA0
	[IteratorStateMachine(typeof(_ResyncMatch_d__22))]
	private IEnumerator ResyncMatch(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x000000018035EAA0-0x000000018035EC00
	private void ResetStatusFxForMatch(); // 0x000000018035EC00-0x000000018035EF60
	[IteratorStateMachine(typeof(_LoadBoardFromSnapshot_d__25))]
	private IEnumerator LoadBoardFromSnapshot(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x000000018035EF60-0x000000018035F0C0
	[IteratorStateMachine(typeof(_LoadBoardFromSnapshotCore_d__26))]
	private IEnumerator LoadBoardFromSnapshotCore(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x000000018035F0C0-0x000000018035F220
	private void ClearDotsAbsentFromSnapshot(BoardCellDTO[][] serverBoard); // 0x000000018035F220-0x000000018035F540
	private void ClearAllDots(); // 0x000000018035F540-0x000000018035F770
	private Transform GetCachedDotsParent(); // 0x000000018035F770-0x000000018035FAC0
	private GameObject FindDotPrefabByTag(string tag); // 0x000000018035FAC0-0x000000018035FE90
	private void EnsurePrefabTable(); // 0x000000018035FE90-0x0000000180360270
	private static void WarnTagManagerOnce(string tag); // 0x0000000180360270-0x0000000180360350
	private void SpawnDotByTag(int col, int row, string tag, int multiplier, bool fallFromAbove = false /* Metadata: 0x005EF468 */); // 0x0000000180360350-0x0000000180360C10
	[IteratorStateMachine(typeof(_WaitForFallToSettle_d__45))]
	private IEnumerator WaitForFallToSettle(); // 0x0000000180360C10-0x0000000180360CB0
	private static bool IsSkillCardOp(MatchOpDTO op); // 0x0000000180360CB0-0x0000000180360E80
	private static bool IsBossCardOp(MatchOpDTO op); // 0x0000000180360E80-0x0000000180360FD0
	private static bool IsLocalUserCardOp(MatchOpDTO op); // 0x0000000180360FD0-0x00000001803611A0
	private static bool BatchTouchesBoard(List<MatchOpDTO> ops); // 0x00000001803611A0-0x00000001803614B0
	private static bool HasSkillCardOp(List<MatchOpDTO> ops); // 0x00000001803614B0-0x0000000180361690
	private static string ReadSkillElementType(List<MatchOpDTO> ops); // 0x0000000180361690-0x00000001803618F0
	private void HandleOpsApplied(List<MatchOpDTO> ops); // 0x00000001803618F0-0x0000000180361C90
	private void EnqueueFxOnly(IEnumerator fx); // 0x0000000180361C90-0x0000000180361D80
	private void KickDrain(); // 0x0000000180361D80-0x0000000180361EB0
	[IteratorStateMachine(typeof(_DrainBatchQueue_d__62))]
	private IEnumerator DrainBatchQueue(); // 0x0000000180361EB0-0x0000000180361F50
	private void AbortRenderInFlight(string reason); // 0x0000000180361F50-0x0000000180362190
	private void AbortStuckRenderIfAny(string where); // 0x0000000180362190-0x00000001803623B0
	private void RecoverFromRenderError([TupleElementNames(new string[3] {"ops", "combat", "fx" })] ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator> batch, Exception e); // 0x00000001803623B0-0x00000001803626F0
	private void RestoreBoardAfterAbortedRender(bool openInput); // 0x00000001803626F0-0x0000000180362940
	private void NormalizeDotsAfterAbort(); // 0x0000000180362940-0x0000000180362D10
	private void RequestResyncAfterRenderFault(); // 0x0000000180362D10-0x0000000180362F90
	[IteratorStateMachine(typeof(_ApplyOpsSequential_d__71))]
	private IEnumerator ApplyOpsSequential(List<MatchOpDTO> ops, WsCombatBatch combat); // 0x0000000180362F90-0x00000001803630F0
	private static bool DetectFullPowerSpend(List<MatchOpDTO> ops, string actorUsername, List<WsCombatStepDTO> steps = null); // 0x00000001803630F0-0x0000000180363110
	private void HandleBossAction(ChatMessageDTO m); // 0x0000000180363110-0x00000001803635E0
	private static string ReadSingleBossTarget(Dictionary<string, object> p); // 0x00000001803635E0-0x00000001803637E0
	private void SwitchDisplayToBossVictim(string username); // 0x00000001803637E0-0x0000000180363860
	private void HandleSkillCast(ChatMessageDTO m); // 0x0000000180363860-0x0000000180364870
	[IteratorStateMachine(typeof(_ClearGalaxyHintsAfter_d__79))]
	private IEnumerator ClearGalaxyHintsAfter(float sec); // 0x0000000180364870-0x0000000180364930
	[IteratorStateMachine(typeof(_ClearMega2HintsAfter_d__80))]
	private IEnumerator ClearMega2HintsAfter(float sec); // 0x0000000180364930-0x00000001803649F0
	[IteratorStateMachine(typeof(_ClearMegaIcarusHintsAfter_d__81))]
	private IEnumerator ClearMegaIcarusHintsAfter(float sec); // 0x00000001803649F0-0x0000000180364AB0
	private void HandleSkillHint(ChatMessageDTO m); // 0x0000000180364AB0-0x00000001803650B0
	private void HandleQteEvent(ChatMessageDTO m); // 0x00000001803650B0-0x0000000180365410
	[IteratorStateMachine(typeof(_ApplyOpsInner_d__84))]
	private IEnumerator ApplyOpsInner(List<MatchOpDTO> ops); // 0x0000000180365410-0x0000000180365520
	private void ApplyFallOrSpawn(MatchOpDTO op); // 0x0000000180365520-0x00000001803655D0
	[IteratorStateMachine(typeof(_ApplyOp_d__86))]
	private IEnumerator ApplyOp(MatchOpDTO op, float speed, int destroyRound); // 0x00000001803655D0-0x00000001803656F0
	private void ApplyHighlight(MatchOpDTO op); // 0x00000001803656F0-0x0000000180365C70
	private void ApplySwap(MatchOpDTO op); // 0x0000000180365C70-0x0000000180366050
	private void ClearPredictionFlag(GameObject go); // 0x0000000180366050-0x0000000180366170
	[IteratorStateMachine(typeof(_ApplyDestroySequenced_d__90))]
	private IEnumerator ApplyDestroySequenced(MatchOpDTO op, float speed, int destroyRound); // 0x0000000180366170-0x0000000180366290
	private static void PlayMatchAudioOncePerTag(List<GameObject> targets, int destroyRound); // 0x0000000180366290-0x00000001803667E0
	private int VerifyBoardAgainstServer(BoardCellDTO[][] serverBoard); // 0x00000001803667E0-0x0000000180366D60
	[IteratorStateMachine(typeof(_ApplyShuffle_d__97))]
	private IEnumerator ApplyShuffle(MatchOpDTO op, float speed); // 0x0000000180366D60-0x0000000180366E80
	private static BoardCellDTO[][] ParseShuffleBoard(MatchOpDTO op); // 0x0000000180366E80-0x0000000180367090
	private static string ReadString(Dictionary<string, object> d, string key, string fb = null); // 0x0000000180367090-0x0000000180367130
	private void ApplyFall(MatchOpDTO op); // 0x0000000180367130-0x0000000180367490
	private void ApplySpawn(MatchOpDTO op); // 0x0000000180367490-0x00000001803677D0
	private void ApplyStatChange(MatchOpDTO op); // 0x00000001803677D0-0x00000001803685A0
	private static string ReadReason(Dictionary<string, object> data); // 0x00000001803685A0-0x0000000180368640
	private static bool IsHealReason(string reason); // 0x0000000180368640-0x0000000180368730
	private void ShowHealPopup(string user, int amount); // 0x0000000180368730-0x0000000180368A40
	[IteratorStateMachine(typeof(_DrainHealPopupQueue_d__111))]
	private IEnumerator DrainHealPopupQueue(); // 0x0000000180368A40-0x0000000180368AE0
	private void ApplyBossHp(MatchOpDTO op); // 0x0000000180368AE0-0x0000000180369010
	private static bool InGuildBossMatch(MatchService ms); // 0x0000000180369010-0x0000000180369250
	private void HandleGuildBossHp(ChatMessageDTO m); // 0x0000000180369250-0x00000001803695F0
	private static string GuildKillBanner(ChatMessageDTO m); // 0x00000001803695F0-0x00000001803697C0
	private void ApplyGuildBossHpValue(long hp, bool force); // 0x00000001803697C0-0x0000000180369CF0
	private void FlashBossHpBar(); // 0x0000000180369CF0-0x000000018036A260
	private void ShowGuildMateDamage(ChatMessageDTO m); // 0x000000018036A260-0x000000018036A610
	private void PlayRaidTerminalFx(string banner, Color color); // 0x000000018036A610-0x000000018036A7B0
	private void RefreshGuildBossUi(); // 0x000000018036A7B0-0x000000018036AC90
	private void ResetGuildBossUi(); // 0x000000018036AC90-0x000000018036AE00
	private void TearDownRaidHud(); // 0x000000018036AE00-0x000000018036AFC0
	private void OnSceneUnloadedForRaidHud(Scene scene); // 0x000000018036AFC0-0x000000018036B170
	private static bool IsMatchSceneName(string name); // 0x000000018036B170-0x000000018036B2F0
	private static bool IsMatchRigAlive(); // 0x000000018036B2F0-0x000000018036B400
	private static Transform FindMatchHudCanvas(); // 0x000000018036B400-0x000000018036B960
	[IteratorStateMachine(typeof(_RaidClockLoop_d__134))]
	private IEnumerator RaidClockLoop(); // 0x000000018036B960-0x000000018036BA00
	private static long RaidClosesAtMs(); // 0x000000018036BA00-0x000000018036BBA0
	private void UpdateRaidClockText(); // 0x000000018036BBA0-0x000000018036BF70
	private void UpdateRaidDamageText(); // 0x000000018036BF70-0x000000018036C1B0
	private bool EnsureRaidHud(); // 0x000000018036C1B0-0x000000018036C6B0
	private void ApplyShieldExpire(MatchOpDTO op); // 0x000000018036C6B0-0x000000018036C970
	private void ApplyStatus(MatchOpDTO op); // 0x000000018036C970-0x000000018036D2D0
	private int ResolveActorByUsername(string username); // 0x000000018036D2D0-0x000000018036D390
	[IteratorStateMachine(typeof(_ApplyVfx_d__142))]
	private IEnumerator ApplyVfx(MatchOpDTO op, float speed); // 0x000000018036D390-0x000000018036D4B0
	[IteratorStateMachine(typeof(_ApplyGalaxyRickyPick_d__143))]
	private IEnumerator ApplyGalaxyRickyPick(MatchOpDTO op, float speed); // 0x000000018036D4B0-0x000000018036D570
	[IteratorStateMachine(typeof(_ApplyDotConvert_d__148))]
	private IEnumerator ApplyDotConvert(MatchOpDTO op, float speed); // 0x000000018036D570-0x000000018036D690
	private GameObject DotAt(int col, int row); // 0x000000018036D690-0x000000018036D7F0
	private static Color ConvertGlowColor(string tag); // 0x000000018036D7F0-0x000000018036DA50
	private void SpawnConvertHalo(GameObject host, Color color, float life); // 0x000000018036DA50-0x000000018036E3E0
	private void ClearConvertHalos(); // 0x000000018036E3E0-0x000000018036E5E0
	[IteratorStateMachine(typeof(_ApplyMegaIcarusMark_d__153))]
	private IEnumerator ApplyMegaIcarusMark(MatchOpDTO op, float speed); // 0x000000018036E5E0-0x000000018036E700
	private static int CountIn(HashSet<Vector2Int> a, HashSet<Vector2Int> b); // 0x000000018036E700-0x000000018036E880
	private Vector3 HealCellBoardCenter(); // 0x000000018036E880-0x000000018036EC90
	private void PlayEnemyEvolveFlash(); // 0x000000018036EC90-0x000000018036F0D0
	private void RefreshBossHpAfterEvolve(int healed); // 0x000000018036F0D0-0x000000018036F170
	private void PlayEnemyPowerUpPunch(); // 0x000000018036F170-0x000000018036F780
	private void HandleFusionResolved(ChatMessageDTO m); // 0x000000018036F780-0x00000001803702F0
	private SpriteRenderer FusionPityHostFor(int actorNum); // 0x00000001803702F0-0x0000000180370410
	[IteratorStateMachine(typeof(_PlayFusionResultFx_d__163))]
	private IEnumerator PlayFusionResultFx(bool success, bool isLocal, string actor, string petName, int ghostPetId, int actorNum, int pityBefore, int pityAfter); // 0x0000000180370410-0x00000001803704F0
	[IteratorStateMachine(typeof(_RunWithTimeout_d__164))]
	private IEnumerator RunWithTimeout(IEnumerator inner, float timeoutSec); // 0x00000001803704F0-0x0000000180370610
	[IteratorStateMachine(typeof(_RunThenFlag_d__165))]
	private static IEnumerator RunThenFlag(IEnumerator inner, Action onDone); // 0x0000000180370610-0x0000000180370720
	private CardUI FindFusionCardUI(); // 0x0000000180370720-0x0000000180370AC0
	private void UnlockFusionCard(); // 0x0000000180370AC0-0x0000000180370E00
	[IteratorStateMachine(typeof(_EnsureFusionCardsWhenReady_d__168))]
	private IEnumerator EnsureFusionCardsWhenReady(); // 0x0000000180370E00-0x0000000180370EA0
	private static bool ReadPayloadBool(Dictionary<string, object> p, string key); // 0x0000000180370EA0-0x0000000180371020
	private static int ReadPayloadInt(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x005EF469 */); // 0x0000000180371020-0x0000000180371160
	private static bool IsGalaxyRickyCardOp(MatchOpDTO op); // 0x0000000180371160-0x0000000180371250
	[IteratorStateMachine(typeof(_ApplyCardUse_d__172))]
	private IEnumerator ApplyCardUse(MatchOpDTO op); // 0x0000000180371250-0x0000000180371360
	[IteratorStateMachine(typeof(_PlayRemoteCardWithOwnerLabel_d__174))]
	private IEnumerator PlayRemoteCardWithOwnerLabel(Sprite art, string ownerName); // 0x0000000180371360-0x00000001803714C0
	[IteratorStateMachine(typeof(_ShowRemoteCardOwnerLabel_d__175))]
	private IEnumerator ShowRemoteCardOwnerLabel(string ownerName); // 0x00000001803714C0-0x0000000180371560
	private static string ResolveDisplayName(string username); // 0x0000000180371560-0x0000000180371630
	private static Sprite LoadCardArtById(int cardId); // 0x0000000180371630-0x0000000180371C20
	private static Sprite LoadBossCardArt(int cardId); // 0x0000000180371C20-0x0000000180372210
	internal static void NotifyLocalSkillCardShown(int cardId); // 0x0000000180372210-0x00000001803722C0
	private static bool ConsumeLocalSkillCardShown(int cardId); // 0x00000001803722C0-0x0000000180372390
	private CardUI FindCardUIByCardId(int cardId); // 0x0000000180372390-0x0000000180372550
	private void HandleTurnEnd(); // 0x0000000180372550-0x0000000180372600
	private void HandleMatchReject(string reason); // 0x0000000180372600-0x0000000180372C20
	public void PlayLocalInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x0000000180372C20-0x0000000180372D00
	[IteratorStateMachine(typeof(_PlayInvalidSwapFeedback_d__190))]
	private IEnumerator PlayInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x0000000180372D00-0x0000000180372DD0
	private void ResetDotToActualPosition(int col, int row); // 0x0000000180372DD0-0x0000000180373020
	private void HandleGameOver(string winner); // 0x0000000180373020-0x0000000180373860
	private void HandlePlayerLeft(string username, bool isPermanent, string reason); // 0x0000000180373860-0x0000000180373B10
	private void HandleAfkWarn(string username, int idleCount, int threshold); // 0x0000000180373B10-0x0000000180373D00
	private void HandleAfkForfeit(string username, int threshold); // 0x0000000180373D00-0x0000000180373EA0
	private void HandlePlayerRejoin(string username); // 0x0000000180373EA0-0x0000000180374000
	private int ResolveActorNumberFromUsername(string username); // 0x0000000180374000-0x0000000180374130
	private bool InBounds(int col, int row); // 0x0000000180374130-0x0000000180374260
	private void UpdateDotPos(GameObject go, int col, int row); // 0x0000000180374260-0x0000000180374400
	private static int ReadInt(Dictionary<string, object> d, string key, int fb = 0 /* Metadata: 0x005EF46A */); // 0x0000000180374400-0x0000000180374520
	private static bool ReadBool(Dictionary<string, object> d, string key, bool fb = false /* Metadata: 0x005EF46B */); // 0x0000000180374520-0x0000000180374690
	private void MarkCrit(bool atSelf); // 0x0000000180374690-0x00000001803746B0
	private void FlushPendingCritLabels(); // 0x00000001803746B0-0x0000000180374770
	private static double ReadDouble(Dictionary<string, object> d, string key, double fb = 0 /* Metadata: 0x005EF46C */); // 0x0000000180374770-0x00000001803749D0
}

