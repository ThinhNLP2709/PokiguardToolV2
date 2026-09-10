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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class BoardWsApplier : MonoBehaviour // TypeDefIndex: 385
{
	// Fields
	private Board board; // 0x20
	private bool _subscribed; // 0x28
	private string _bootstrappedMatchId; // 0x30
	[CompilerGenerated]
	private static string _BootstrappedMatchId_k__BackingField; // 0x00
	private bool _boardBuildRunning; // 0x38
	private const int SPAWN_YIELD_EVERY = 16; // Metadata: 0x0068B19A
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
	internal const string BossUsername = "__BOSS__"; // Metadata: 0x0068B19B
	private bool _batchTouchesBoard; // 0x74
	private bool _suppressBarRefresh; // 0x75
	private float _lastCastVfxAt; // 0x78
	private const float CastVfxDedupeSec = 3f; // Metadata: 0x0068B1A4
	private static readonly Dictionary<string, int> _audioTagBuf; // 0x10
	private const float ShuffleShrinkSec = 0.22f; // Metadata: 0x0068B1A8
	private const float ShuffleWaveDelayPerCell = 0.018f; // Metadata: 0x0068B1AC
	private const float ShuffleEmptyBoardSec = 0.05f; // Metadata: 0x0068B1B0
	private bool _healPopupBusy; // 0x7C
	private readonly Queue<HealPopupReq> _healPopupQueue; // 0x80
	private const int HealPopupQueueMax = 3; // Metadata: 0x0068B1B4
	private const float HealPopupGapSec = 0.25f; // Metadata: 0x0068B1B5
	private const string NODE_GUILD_HUNT_HINT = "txtGuildHuntHint"; // Metadata: 0x0068B1B9
	private static readonly Color GUILD_HINT_COLOR; // 0x18
	private static readonly Color GUILD_KILLABLE_COLOR; // 0x28
	private static readonly Color GUILD_REVIVE_COLOR; // 0x38
	private UnityEngine.UI.Text _guildHuntHint; // 0x88
	private bool _guildKillableAnnounced; // 0x90
	private const float DotConvertTelegraphSec = 0.35f; // Metadata: 0x0068B1CA
	private const float DotConvertMorphSec = 0.25f; // Metadata: 0x0068B1CE
	private const float DotConvertStaggerSec = 0.04f; // Metadata: 0x0068B1D2
	private readonly List<GameObject> _convertHalos; // 0x98
	private const float MegaIcarusMarkHoldSec = 0.9f; // Metadata: 0x0068B1D6
	private const float EvolveHpRevealSec = 0.15f; // Metadata: 0x0068B1DA
	private const float RemoteCardLabelLifeSec = 1.55f; // Metadata: 0x0068B1DE
	private static readonly Dictionary<int, Sprite> _remoteCardArtCache; // 0x48
	private static readonly Dictionary<int, Sprite> _bossCardArtCache; // 0x50
	private static int _localShownCardId; // 0x58
	private static float _localShownAt; // 0x5C
	private const float LocalShownTtlSec = 20f; // Metadata: 0x0068B1E2
	private const float InvalidSwapFlashSec = 0.25f; // Metadata: 0x0068B1E6
	private readonly HashSet<string> _offlineToastShown; // 0xA0
	private bool _pendingCritAtSelf; // 0xA8
	private bool _pendingCritAtEnemy; // 0xA9

	// Properties
	public static string BootstrappedMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018035A7C0-0x000000018035A810 0x000000018035A810-0x000000018035A880

	// Nested types
	private struct HealPopupReq // TypeDefIndex: 386
	{
		// Fields
		public bool npcSide; // 0x00
		public int amount; // 0x04
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass109_0 // TypeDefIndex: 387
	{
		// Fields
		public Image img; // 0x10
		public Color home; // 0x18

		// Constructors
		public __c__DisplayClass109_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FlashBossHpBar_b__0(float t); // 0x0000000180360F00-0x0000000180361040
		internal void _FlashBossHpBar_b__1(); // 0x0000000180361040-0x00000001803610D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass111_0 // TypeDefIndex: 388
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 home; // 0x18

		// Constructors
		public __c__DisplayClass111_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayGuildReviveFx_b__0(float t); // 0x00000001803610D0-0x00000001803611A0
		internal void _PlayGuildReviveFx_b__1(); // 0x00000001803611A0-0x0000000180361230
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass128_0 // TypeDefIndex: 389
	{
		// Fields
		public SpriteRenderer sr; // 0x10
		public Color color; // 0x18
		public GameObject halo; // 0x28
		public float life; // 0x30
		public Action<float> __9__2; // 0x38

		// Constructors
		public __c__DisplayClass128_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SpawnConvertHalo_b__0(float a); // 0x0000000180361290-0x0000000180361340
		internal void _SpawnConvertHalo_b__1(); // 0x0000000180361340-0x0000000180361480
		internal void _SpawnConvertHalo_b__2(float a); // 0x0000000180361480-0x0000000180361530
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass134_0 // TypeDefIndex: 390
	{
		// Fields
		public SpriteRenderer host; // 0x10
		public Color baseColor; // 0x18
		public GameObject go; // 0x28
		public Action<float> __9__2; // 0x30
		public Action __9__3; // 0x38

		// Constructors
		public __c__DisplayClass134_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayEnemyEvolveFlash_b__0(float t); // 0x0000000180361530-0x0000000180361650
		internal void _PlayEnemyEvolveFlash_b__1(); // 0x0000000180361650-0x0000000180361800
		internal void _PlayEnemyEvolveFlash_b__2(float t); // 0x0000000180361800-0x0000000180361920
		internal void _PlayEnemyEvolveFlash_b__3(); // 0x0000000180361920-0x00000001803619B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass137_0 // TypeDefIndex: 391
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18
		public Action __9__1; // 0x28

		// Constructors
		public __c__DisplayClass137_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayEnemyPowerUpPunch_b__0(); // 0x00000001803619B0-0x0000000180361B20
		internal void _PlayEnemyPowerUpPunch_b__1(); // 0x0000000180361B20-0x0000000180361BC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass140_0 // TypeDefIndex: 392
	{
		// Fields
		public bool done; // 0x10

		// Constructors
		public __c__DisplayClass140_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RunWithTimeout_b__0(); // 0x000000018034AB40-0x000000018034AB50
	}

	[CompilerGenerated]
	private sealed class _ApplyCardUse_d__147 : IEnumerator<object> // TypeDefIndex: 393
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplier __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyCardUse_d__147(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018035D0B0-0x000000018035D8D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018035D8D0-0x000000018035D910
	}

	[CompilerGenerated]
	private sealed class _ApplyDestroySequenced_d__77 : IEnumerator<object> // TypeDefIndex: 394
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplier __4__this; // 0x28
		public int destroyRound; // 0x30
		public float speed; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDestroySequenced_d__77(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018035D910-0x000000018035DFC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018035DFC0-0x000000018035E000
	}

	[CompilerGenerated]
	private sealed class _ApplyDotConvert_d__125 : IEnumerator<object> // TypeDefIndex: 395
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDotConvert_d__125(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018035EF90-0x000000018035F0B0
		private bool MoveNext(); // 0x000000018035E000-0x000000018035EF50
		private void __m__Finally1(); // 0x000000018035F0B0-0x000000018035F0D0
		private void __m__Finally2(); // 0x000000018035F0B0-0x000000018035F0D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018035EF50-0x000000018035EF90
	}

	[CompilerGenerated]
	private sealed class _ApplyMegaIcarusMark_d__130 : IEnumerator<object> // TypeDefIndex: 396
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyMegaIcarusMark_d__130(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018035F0D0-0x000000018035F9F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018035F9F0-0x000000018035FA30
	}

	[CompilerGenerated]
	private sealed class _ApplyOp_d__73 : IEnumerator<object> // TypeDefIndex: 397
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplier __4__this; // 0x28
		public float speed; // 0x30
		public int destroyRound; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOp_d__73(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180371A50-0x0000000180372360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180372360-0x00000001803723A0
	}

	[CompilerGenerated]
	private sealed class _ApplyOpsInner_d__71 : IEnumerator<object> // TypeDefIndex: 398
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOpsInner_d__71(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180372850-0x0000000180372880
		private bool MoveNext(); // 0x00000001803723A0-0x0000000180372810
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180372810-0x0000000180372850
	}

	[CompilerGenerated]
	private sealed class _ApplyOpsSequential_d__58 : IEnumerator<object> // TypeDefIndex: 399
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOpsSequential_d__58(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180372880-0x0000000180372EF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180372EF0-0x0000000180372F30
	}

	[CompilerGenerated]
	private sealed class _ApplyShuffle_d__84 : IEnumerator<object> // TypeDefIndex: 400
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30
		private BoardCellDTO[][] _grid_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyShuffle_d__84(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x0000000180372F30-0x0000000180373860
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180373860-0x00000001803738A0
	}

	[CompilerGenerated]
	private sealed class _ApplyVfx_d__120 : IEnumerator<object> // TypeDefIndex: 401
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplier __4__this; // 0x28
		public float speed; // 0x30
		private int _healed_5__2; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyVfx_d__120(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803738A0-0x00000001803740B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803740B0-0x00000001803740F0
	}

	[CompilerGenerated]
	private sealed class _BootstrapMatch_d__20 : IEnumerator<object> // TypeDefIndex: 402
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		public BoardCellDTO[][] preBoard; // 0x30
		private float _wait_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BootstrapMatch_d__20(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803740F0-0x00000001803744B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803744B0-0x00000001803744F0
	}

	[CompilerGenerated]
	private sealed class _ClearGalaxyHintsAfter_d__66 : IEnumerator<object> // TypeDefIndex: 403
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplier __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClearGalaxyHintsAfter_d__66(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803744F0-0x00000001803745B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803745B0-0x00000001803745F0
	}

	[CompilerGenerated]
	private sealed class _ClearMega2HintsAfter_d__67 : IEnumerator<object> // TypeDefIndex: 404
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplier __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClearMega2HintsAfter_d__67(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803745F0-0x00000001803746B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803746B0-0x00000001803746F0
	}

	[CompilerGenerated]
	private sealed class _ClearMegaIcarusHintsAfter_d__68 : IEnumerator<object> // TypeDefIndex: 405
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplier __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClearMegaIcarusHintsAfter_d__68(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803746F0-0x00000001803747B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803747B0-0x00000001803747F0
	}

	[CompilerGenerated]
	private sealed class _DrainBatchQueue_d__56 : IEnumerator<object> // TypeDefIndex: 406
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DrainBatchQueue_d__56(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180375070-0x0000000180375110
		private bool MoveNext(); // 0x0000000180374E60-0x0000000180375030
		private void __m__Finally1(); // 0x0000000180375110-0x0000000180375140
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180375030-0x0000000180375070
	}

	[CompilerGenerated]
	private sealed class _DrainHealPopupQueue_d__98 : IEnumerator<object> // TypeDefIndex: 407
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DrainHealPopupQueue_d__98(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180375140-0x00000001803753D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803753D0-0x0000000180375410
	}

	[CompilerGenerated]
	private sealed class _EnsureFusionCardsWhenReady_d__144 : IEnumerator<object> // TypeDefIndex: 408
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		private float _deadline_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _EnsureFusionCardsWhenReady_d__144(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180375410-0x0000000180375660
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180375660-0x00000001803756A0
	}

	[CompilerGenerated]
	private sealed class _LoadBoardFromSnapshot_d__25 : IEnumerator<object> // TypeDefIndex: 409
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		public BoardCellDTO[][] preBoard; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadBoardFromSnapshot_d__25(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180375EC0-0x0000000180375F50
		private bool MoveNext(); // 0x0000000180375D30-0x0000000180375E80
		private void __m__Finally1(); // 0x0000000180375F50-0x0000000180375F80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180375E80-0x0000000180375EC0
	}

	[CompilerGenerated]
	private sealed class _LoadBoardFromSnapshotCore_d__26 : IEnumerator<object> // TypeDefIndex: 410
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadBoardFromSnapshotCore_d__26(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180372850-0x0000000180372880
		private bool MoveNext(); // 0x00000001803756A0-0x0000000180375CF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180375CF0-0x0000000180375D30
	}

	[CompilerGenerated]
	private sealed class _PlayFusionResultFx_d__139 : IEnumerator<object> // TypeDefIndex: 411
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public bool isLocal; // 0x28
		public int actorNum; // 0x2C
		public bool success; // 0x30
		public int ghostPetId; // 0x34
		private bool _hidBoard_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayFusionResultFx_d__139(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180376E90-0x0000000180376F00
		private bool MoveNext(); // 0x0000000180376880-0x0000000180376E50
		private void __m__Finally1(); // 0x0000000180376F00-0x0000000180376FA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180376E50-0x0000000180376E90
	}

	[CompilerGenerated]
	private sealed class _PlayInvalidSwapFeedback_d__165 : IEnumerator<object> // TypeDefIndex: 412
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayInvalidSwapFeedback_d__165(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180377340-0x0000000180377380
		private bool MoveNext(); // 0x0000000180376FA0-0x0000000180377300
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180377300-0x0000000180377340
	}

	[CompilerGenerated]
	private sealed class _PlayRemoteCardWithOwnerLabel_d__149 : IEnumerator<object> // TypeDefIndex: 413
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Sprite art; // 0x20
		public string ownerName; // 0x28
		public BoardWsApplier __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayRemoteCardWithOwnerLabel_d__149(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180377380-0x00000001803774A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803774A0-0x00000001803774E0
	}

	[CompilerGenerated]
	private sealed class _ResyncMatch_d__22 : IEnumerator<object> // TypeDefIndex: 414
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		public BoardCellDTO[][] preBoard; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ResyncMatch_d__22(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180377C70-0x0000000180378020
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180378020-0x0000000180378060
	}

	[CompilerGenerated]
	private sealed class _RunThenFlag_d__141 : IEnumerator<object> // TypeDefIndex: 415
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public IEnumerator inner; // 0x20
		public Action onDone; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RunThenFlag_d__141(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180378060-0x00000001803780D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803780D0-0x0000000180378110
	}

	[CompilerGenerated]
	private sealed class _RunWithTimeout_d__140 : IEnumerator<object> // TypeDefIndex: 416
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public IEnumerator inner; // 0x28
		public float timeoutSec; // 0x30
		private __c__DisplayClass140_0 __8__1; // 0x38
		private float _deadline_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RunWithTimeout_d__140(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x0000000180378110-0x0000000180378310
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180378310-0x0000000180378350
	}

	[CompilerGenerated]
	private sealed class _ShowRemoteCardOwnerLabel_d__150 : IEnumerator<object> // TypeDefIndex: 417
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string ownerName; // 0x20
		private GameObject _go_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowRemoteCardOwnerLabel_d__150(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180378350-0x0000000180378830
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180378830-0x0000000180378870
	}

	[CompilerGenerated]
	private sealed class _WaitForFallToSettle_d__45 : IEnumerator<object> // TypeDefIndex: 418
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitForFallToSettle_d__45(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180378C60-0x0000000180378DF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180378DF0-0x0000000180378E30
	}

	// Constructors
	public BoardWsApplier(); // 0x000000018035A540-0x000000018035A7C0
	static BoardWsApplier(); // 0x000000018035A390-0x000000018035A540

	// Methods
	private void Awake(); // 0x000000018034DFD0-0x000000018034DFE0
	private void Start(); // 0x0000000180358FF0-0x0000000180359020
	private void OnEnable(); // 0x0000000180355330-0x0000000180355350
	private void OnDisable(); // 0x00000001803551C0-0x0000000180355330
	private void OnDestroy(); // 0x0000000180354F70-0x00000001803551C0
	private void RegisterBusyProbe(); // 0x0000000180357420-0x0000000180357520
	private bool IsRendererBusy(); // 0x00000001803545F0-0x0000000180354620
	private void EnsureBoardRef(); // 0x000000018034F2E0-0x000000018034F4B0
	private void EnsureMoveHint(); // 0x000000018034FBB0-0x000000018034FCC0
	private void TrySubscribe(); // 0x00000001803590A0-0x0000000180359680
	private void HandleEnergyDeltaWarn(ChatMessageDTO m); // 0x0000000180350D70-0x0000000180350F40
	private void Unsubscribe(); // 0x00000001803597B0-0x0000000180359D90
	private void HandleMatchStart(ChatMessageDTO m); // 0x0000000180352310-0x00000001803526B0
	[IteratorStateMachine(typeof(_BootstrapMatch_d__20))]
	private IEnumerator BootstrapMatch(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x000000018034E1B0-0x000000018034E260
	private void HandleMatchResync(ChatMessageDTO m); // 0x0000000180352120-0x0000000180352310
	[IteratorStateMachine(typeof(_ResyncMatch_d__22))]
	private IEnumerator ResyncMatch(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x0000000180357C60-0x0000000180357D10
	private void ResetStatusFxForMatch(); // 0x00000001803576E0-0x00000001803578D0
	[IteratorStateMachine(typeof(_LoadBoardFromSnapshot_d__25))]
	private IEnumerator LoadBoardFromSnapshot(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x00000001803547E0-0x0000000180354890
	[IteratorStateMachine(typeof(_LoadBoardFromSnapshotCore_d__26))]
	private IEnumerator LoadBoardFromSnapshotCore(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x0000000180354730-0x00000001803547E0
	private void ClearDotsAbsentFromSnapshot(BoardCellDTO[][] serverBoard); // 0x000000018034E5B0-0x000000018034E810
	private void ClearAllDots(); // 0x000000018034E260-0x000000018034E450
	private Transform GetCachedDotsParent(); // 0x0000000180350750-0x0000000180350820
	private GameObject FindDotPrefabByTag(string tag); // 0x0000000180350030-0x0000000180350240
	private void EnsurePrefabTable(); // 0x000000018034FCC0-0x000000018034FF00
	private static void WarnTagManagerOnce(string tag); // 0x000000018035A2D0-0x000000018035A390
	private void SpawnDotByTag(int col, int row, string tag, int multiplier, bool fallFromAbove = false /* Metadata: 0x0068B18E */); // 0x0000000180358A30-0x0000000180358FF0
	[IteratorStateMachine(typeof(_WaitForFallToSettle_d__45))]
	private IEnumerator WaitForFallToSettle(); // 0x000000018035A260-0x000000018035A2D0
	private static bool IsSkillCardOp(MatchOpDTO op); // 0x0000000180354620-0x0000000180354730
	private static bool IsBossCardOp(MatchOpDTO op); // 0x00000001803543D0-0x0000000180354490
	private static bool IsLocalUserCardOp(MatchOpDTO op); // 0x00000001803544E0-0x00000001803545F0
	private static bool BatchTouchesBoard(List<MatchOpDTO> ops); // 0x000000018034DFE0-0x000000018034E1B0
	private static bool HasSkillCardOp(List<MatchOpDTO> ops); // 0x0000000180353EE0-0x0000000180354060
	private static string ReadSkillElementType(List<MatchOpDTO> ops); // 0x0000000180356D60-0x0000000180356F60
	private void HandleOpsApplied(List<MatchOpDTO> ops); // 0x00000001803526B0-0x0000000180352920
	private void EnqueueFxOnly(IEnumerator fx); // 0x000000018034F210-0x000000018034F2E0
	[IteratorStateMachine(typeof(_DrainBatchQueue_d__56))]
	private IEnumerator DrainBatchQueue(); // 0x000000018034F130-0x000000018034F1A0
	[IteratorStateMachine(typeof(_ApplyOpsSequential_d__58))]
	private IEnumerator ApplyOpsSequential(List<MatchOpDTO> ops, WsCombatBatch combat); // 0x000000018034C3C0-0x000000018034C470
	private static bool DetectFullPowerSpend(List<MatchOpDTO> ops, string actorUsername); // 0x000000018034EDA0-0x000000018034F050
	private void HandleBossAction(ChatMessageDTO m); // 0x0000000180350A90-0x0000000180350D70
	private static string ReadSingleBossTarget(Dictionary<string, object> p); // 0x0000000180356B90-0x0000000180356D60
	private void SwitchDisplayToBossVictim(string username); // 0x0000000180359020-0x00000001803590A0
	private void HandleSkillCast(ChatMessageDTO m); // 0x0000000180352E20-0x0000000180353A70
	[IteratorStateMachine(typeof(_ClearGalaxyHintsAfter_d__66))]
	private IEnumerator ClearGalaxyHintsAfter(float sec); // 0x000000018034E810-0x000000018034E890
	[IteratorStateMachine(typeof(_ClearMega2HintsAfter_d__67))]
	private IEnumerator ClearMega2HintsAfter(float sec); // 0x000000018034E890-0x000000018034E910
	[IteratorStateMachine(typeof(_ClearMegaIcarusHintsAfter_d__68))]
	private IEnumerator ClearMegaIcarusHintsAfter(float sec); // 0x000000018034E910-0x000000018034E990
	private void HandleSkillHint(ChatMessageDTO m); // 0x0000000180353A70-0x0000000180353E60
	private void HandleQteEvent(ChatMessageDTO m); // 0x0000000180352B40-0x0000000180352E20
	[IteratorStateMachine(typeof(_ApplyOpsInner_d__71))]
	private IEnumerator ApplyOpsInner(List<MatchOpDTO> ops); // 0x000000018034C330-0x000000018034C3C0
	private void ApplyFallOrSpawn(MatchOpDTO op); // 0x000000018034B770-0x000000018034B7F0
	[IteratorStateMachine(typeof(_ApplyOp_d__73))]
	private IEnumerator ApplyOp(MatchOpDTO op, float speed, int destroyRound); // 0x000000018034C280-0x000000018034C330
	private void ApplyHighlight(MatchOpDTO op); // 0x000000018034BD90-0x000000018034C1E0
	private void ApplySwap(MatchOpDTO op); // 0x000000018034DC40-0x000000018034DF30
	private void ClearPredictionFlag(GameObject go); // 0x000000018034E990-0x000000018034EA30
	[IteratorStateMachine(typeof(_ApplyDestroySequenced_d__77))]
	private IEnumerator ApplyDestroySequenced(MatchOpDTO op, float speed, int destroyRound); // 0x000000018034B620-0x000000018034B6D0
	private static void PlayMatchAudioOncePerTag(List<GameObject> targets, int destroyRound); // 0x00000001803560F0-0x0000000180356430
	private int VerifyBoardAgainstServer(BoardCellDTO[][] serverBoard); // 0x0000000180359E80-0x000000018035A260
	[IteratorStateMachine(typeof(_ApplyShuffle_d__84))]
	private IEnumerator ApplyShuffle(MatchOpDTO op, float speed); // 0x000000018034C710-0x000000018034C7B0
	private static BoardCellDTO[][] ParseShuffleBoard(MatchOpDTO op); // 0x0000000180355350-0x0000000180355530
	private static string ReadString(Dictionary<string, object> d, string key, string fb = null); // 0x0000000180356F60-0x0000000180357020
	private void ApplyFall(MatchOpDTO op); // 0x000000018034B7F0-0x000000018034BA70
	private void ApplySpawn(MatchOpDTO op); // 0x000000018034C7B0-0x000000018034CA40
	private void ApplyStatChange(MatchOpDTO op); // 0x000000018034CA40-0x000000018034D470
	private static string ReadReason(Dictionary<string, object> data); // 0x0000000180356B00-0x0000000180356B90
	private static bool IsHealReason(string reason); // 0x0000000180354490-0x00000001803544E0
	private void ShowHealPopup(string user, int amount); // 0x00000001803582D0-0x00000001803584D0
	[IteratorStateMachine(typeof(_DrainHealPopupQueue_d__98))]
	private IEnumerator DrainHealPopupQueue(); // 0x000000018034F1A0-0x000000018034F210
	private void ApplyBossHp(MatchOpDTO op); // 0x000000018034B0F0-0x000000018034B590
	private static bool InGuildBossMatch(MatchService ms); // 0x0000000180354310-0x00000001803543D0
	private void HandleGuildBossHp(ChatMessageDTO m); // 0x0000000180351A70-0x0000000180351E70
	private void ApplyGuildBossHpValue(long hp, bool force); // 0x000000018034BA70-0x000000018034BD90
	private void FlashBossHpBar(); // 0x0000000180350380-0x00000001803506A0
	private void ShowGuildMateDamage(ChatMessageDTO m); // 0x0000000180358140-0x00000001803582D0
	private void PlayGuildReviveFx(MatchService ms); // 0x0000000180355B90-0x0000000180355FD0
	private void ShowGuildKillToast(ChatMessageDTO m); // 0x0000000180357F50-0x0000000180358140
	private void RefreshGuildBossUi(); // 0x00000001803570B0-0x0000000180357420
	private void ResetGuildBossUi(); // 0x0000000180357680-0x00000001803576E0
	private void SetGuildHuntHint(string content); // 0x0000000180357E40-0x0000000180357F50
	private bool EnsureGuildHuntHint(); // 0x000000018034F520-0x000000018034FBB0
	private void ApplyShieldExpire(MatchOpDTO op); // 0x000000018034C470-0x000000018034C710
	private void ApplyStatus(MatchOpDTO op); // 0x000000018034D470-0x000000018034DC40
	private int ResolveActorByUsername(string username); // 0x00000001803578D0-0x00000001803579D0
	[IteratorStateMachine(typeof(_ApplyVfx_d__120))]
	private IEnumerator ApplyVfx(MatchOpDTO op, float speed); // 0x000000018034DF30-0x000000018034DFD0
	[IteratorStateMachine(typeof(_ApplyDotConvert_d__125))]
	private IEnumerator ApplyDotConvert(MatchOpDTO op, float speed); // 0x000000018034B6D0-0x000000018034B770
	private GameObject DotAt(int col, int row); // 0x000000018034F050-0x000000018034F130
	private static Color ConvertGlowColor(string tag); // 0x000000018034EAC0-0x000000018034EC70
	private void SpawnConvertHalo(GameObject host, Color color, float life); // 0x0000000180358540-0x0000000180358A30
	private void ClearConvertHalos(); // 0x000000018034E450-0x000000018034E5B0
	[IteratorStateMachine(typeof(_ApplyMegaIcarusMark_d__130))]
	private IEnumerator ApplyMegaIcarusMark(MatchOpDTO op, float speed); // 0x000000018034C1E0-0x000000018034C280
	private static int CountIn(HashSet<Vector2Int> a, HashSet<Vector2Int> b); // 0x000000018034EC70-0x000000018034EDA0
	private Vector3 HealCellBoardCenter(); // 0x0000000180354060-0x0000000180354260
	private void PlayEnemyEvolveFlash(); // 0x0000000180355530-0x0000000180355780
	private void RefreshBossHpAfterEvolve(int healed); // 0x0000000180357020-0x00000001803570B0
	private void PlayEnemyPowerUpPunch(); // 0x0000000180355780-0x0000000180355AF0
	private void HandleFusionResolved(ChatMessageDTO m); // 0x0000000180350F40-0x0000000180351720
	[IteratorStateMachine(typeof(_PlayFusionResultFx_d__139))]
	private IEnumerator PlayFusionResultFx(bool success, bool isLocal, string actor, string petName, int ghostPetId, int actorNum); // 0x0000000180355AF0-0x0000000180355B90
	[IteratorStateMachine(typeof(_RunWithTimeout_d__140))]
	private IEnumerator RunWithTimeout(IEnumerator inner, float timeoutSec); // 0x0000000180357DA0-0x0000000180357E40
	[IteratorStateMachine(typeof(_RunThenFlag_d__141))]
	private static IEnumerator RunThenFlag(IEnumerator inner, Action onDone); // 0x0000000180357D10-0x0000000180357DA0
	private CardUI FindFusionCardUI(); // 0x0000000180350240-0x0000000180350380
	private void UnlockFusionCard(); // 0x0000000180359680-0x00000001803597B0
	[IteratorStateMachine(typeof(_EnsureFusionCardsWhenReady_d__144))]
	private IEnumerator EnsureFusionCardsWhenReady(); // 0x000000018034F4B0-0x000000018034F520
	private static bool ReadPayloadBool(Dictionary<string, object> p, string key); // 0x0000000180356930-0x0000000180356A50
	private static int ReadPayloadInt(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x0068B18F */); // 0x0000000180356A50-0x0000000180356B00
	[IteratorStateMachine(typeof(_ApplyCardUse_d__147))]
	private IEnumerator ApplyCardUse(MatchOpDTO op); // 0x000000018034B590-0x000000018034B620
	[IteratorStateMachine(typeof(_PlayRemoteCardWithOwnerLabel_d__149))]
	private IEnumerator PlayRemoteCardWithOwnerLabel(Sprite art, string ownerName); // 0x0000000180356430-0x00000001803564E0
	[IteratorStateMachine(typeof(_ShowRemoteCardOwnerLabel_d__150))]
	private IEnumerator ShowRemoteCardOwnerLabel(string ownerName); // 0x00000001803584D0-0x0000000180358540
	private static string ResolveDisplayName(string username); // 0x0000000180357B30-0x0000000180357C60
	private static Sprite LoadCardArtById(int cardId); // 0x0000000180354BC0-0x0000000180354EE0
	private static Sprite LoadBossCardArt(int cardId); // 0x0000000180354890-0x0000000180354BC0
	internal static void NotifyLocalSkillCardShown(int cardId); // 0x0000000180354F00-0x0000000180354F70
	private static bool ConsumeLocalSkillCardShown(int cardId); // 0x000000018034EA30-0x000000018034EAC0
	private CardUI FindCardUIByCardId(int cardId); // 0x000000018034FF00-0x0000000180350030
	private void HandleTurnEnd(); // 0x0000000180353E60-0x0000000180353EE0
	private void HandleMatchReject(string reason); // 0x0000000180351E70-0x0000000180352120
	public void PlayLocalInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x0000000180356080-0x00000001803560F0
	[IteratorStateMachine(typeof(_PlayInvalidSwapFeedback_d__165))]
	private IEnumerator PlayInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x0000000180355FD0-0x0000000180356080
	private void ResetDotToActualPosition(int col, int row); // 0x0000000180357520-0x0000000180357680
	private void HandleGameOver(string winner); // 0x0000000180351720-0x0000000180351A70
	private void HandlePlayerLeft(string username, bool isPermanent, string reason); // 0x0000000180352920-0x0000000180352A80
	private void HandleAfkWarn(string username, int idleCount, int threshold); // 0x0000000180350930-0x0000000180350A90
	private void HandleAfkForfeit(string username, int threshold); // 0x0000000180350820-0x0000000180350930
	private void HandlePlayerRejoin(string username); // 0x0000000180352A80-0x0000000180352B40
	private int ResolveActorNumberFromUsername(string username); // 0x00000001803579D0-0x0000000180357B30
	private bool InBounds(int col, int row); // 0x0000000180354260-0x0000000180354310
	private void UpdateDotPos(GameObject go, int col, int row); // 0x0000000180359D90-0x0000000180359E80
	private static int ReadInt(Dictionary<string, object> d, string key, int fb = 0 /* Metadata: 0x0068B190 */); // 0x0000000180356810-0x0000000180356930
	private static bool ReadBool(Dictionary<string, object> d, string key, bool fb = false /* Metadata: 0x0068B191 */); // 0x00000001803564E0-0x00000001803565F0
	private void MarkCrit(bool atSelf); // 0x0000000180354EE0-0x0000000180354F00
	private void FlushPendingCritLabels(); // 0x00000001803506A0-0x0000000180350750
	private static double ReadDouble(Dictionary<string, object> d, string key, double fb = 0 /* Metadata: 0x0068B192 */); // 0x00000001803565F0-0x0000000180356810
}

