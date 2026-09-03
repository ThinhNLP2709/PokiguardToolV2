/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class BoardWsApplier : MonoBehaviour // TypeDefIndex: 340
{
	// Fields
	private Board board; // 0x20
	private bool _subscribed; // 0x28
	private string _bootstrappedMatchId; // 0x30
	private bool _boardBuildRunning; // 0x38
	private Transform _cachedDotsParent; // 0x40
	private Board _cachedDotsParentOwner; // 0x48
	private static bool _tagFallbackWarned; // 0x00
	[TupleElementNames(new string[3] {"ops", "combat", "fx" })]
	private readonly Queue<ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator>> _pendingBatches; // 0x50
	private bool _renderRunning; // 0x58
	private bool _boardHiddenForCard; // 0x59
	private float _lastFallStartedAt; // 0x5C
	private float _lastFallNeedSec; // 0x60
	internal const string BossUsername = "__BOSS__"; // Metadata: 0x0064C201
	private bool _suppressBarRefresh; // 0x64
	private float _lastCastVfxAt; // 0x68
	private const float CastVfxDedupeSec = 3f; // Metadata: 0x0064C20A
	private static readonly Dictionary<string, int> _audioTagBuf; // 0x08
	private const float ShuffleShrinkSec = 0.22f; // Metadata: 0x0064C20E
	private const float ShuffleWaveDelayPerCell = 0.018f; // Metadata: 0x0064C212
	private const float ShuffleEmptyBoardSec = 0.05f; // Metadata: 0x0064C216
	private bool _healPopupBusy; // 0x6C
	private const float DotConvertTelegraphSec = 0.35f; // Metadata: 0x0064C21A
	private const float DotConvertMorphSec = 0.25f; // Metadata: 0x0064C21E
	private const float DotConvertStaggerSec = 0.04f; // Metadata: 0x0064C222
	private readonly List<GameObject> _convertHalos; // 0x70
	private const float MegaIcarusMarkHoldSec = 0.9f; // Metadata: 0x0064C226
	private static int _localShownCardId; // 0x10
	private static float _localShownAt; // 0x14
	private const float LocalShownTtlSec = 20f; // Metadata: 0x0064C22A
	private const float InvalidSwapFlashSec = 0.25f; // Metadata: 0x0064C22E
	private readonly HashSet<string> _offlineToastShown; // 0x78
	private bool _pendingCritAtSelf; // 0x80
	private bool _pendingCritAtEnemy; // 0x81

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass100_0 // TypeDefIndex: 341
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18
		public Action __9__1; // 0x28

		// Constructors
		public __c__DisplayClass100_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayEnemyPowerUpPunch_b__0(); // 0x00000001803323F0-0x0000000180332560
		internal void _PlayEnemyPowerUpPunch_b__1(); // 0x0000000180332560-0x0000000180332600
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass103_0 // TypeDefIndex: 342
	{
		// Fields
		public bool done; // 0x10

		// Constructors
		public __c__DisplayClass103_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RunWithTimeout_b__0(); // 0x000000018030F220-0x000000018030F230
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass93_0 // TypeDefIndex: 343
	{
		// Fields
		public SpriteRenderer sr; // 0x10
		public Color color; // 0x18
		public GameObject halo; // 0x28
		public float life; // 0x30
		public Action<float> __9__2; // 0x38

		// Constructors
		public __c__DisplayClass93_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SpawnConvertHalo_b__0(float a); // 0x0000000180332600-0x00000001803326B0
		internal void _SpawnConvertHalo_b__1(); // 0x00000001803326B0-0x00000001803327F0
		internal void _SpawnConvertHalo_b__2(float a); // 0x00000001803327F0-0x00000001803328A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass99_0 // TypeDefIndex: 344
	{
		// Fields
		public SpriteRenderer host; // 0x10
		public Color baseColor; // 0x18
		public GameObject go; // 0x28
		public Action<float> __9__2; // 0x30
		public Action __9__3; // 0x38

		// Constructors
		public __c__DisplayClass99_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayEnemyEvolveFlash_b__0(float t); // 0x00000001803328A0-0x00000001803329C0
		internal void _PlayEnemyEvolveFlash_b__1(); // 0x00000001803329C0-0x0000000180332B70
		internal void _PlayEnemyEvolveFlash_b__2(float t); // 0x0000000180332B70-0x0000000180332C90
		internal void _PlayEnemyEvolveFlash_b__3(); // 0x0000000180332C90-0x0000000180332D20
	}

	[CompilerGenerated]
	private sealed class _ApplyCardUse_d__110 : IEnumerator<object> // TypeDefIndex: 345
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplier __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyCardUse_d__110(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018032AE10-0x000000018032B1C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032B1C0-0x000000018032B200
	}

	[CompilerGenerated]
	private sealed class _ApplyDestroySequenced_d__63 : IEnumerator<object> // TypeDefIndex: 346
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplier __4__this; // 0x28
		public int destroyRound; // 0x30
		public float speed; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDestroySequenced_d__63(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018032B200-0x000000018032B8D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032B8D0-0x000000018032B910
	}

	[CompilerGenerated]
	private sealed class _ApplyDotConvert_d__90 : IEnumerator<object> // TypeDefIndex: 347
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDotConvert_d__90(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018032C7E0-0x000000018032C900
		private bool MoveNext(); // 0x000000018032B910-0x000000018032C7A0
		private void __m__Finally1(); // 0x000000018032C900-0x000000018032C920
		private void __m__Finally2(); // 0x000000018032C900-0x000000018032C920
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032C7A0-0x000000018032C7E0
	}

	[CompilerGenerated]
	private sealed class _ApplyMegaIcarusMark_d__95 : IEnumerator<object> // TypeDefIndex: 348
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyMegaIcarusMark_d__95(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018032C920-0x000000018032D280
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032D280-0x000000018032D2C0
	}

	[CompilerGenerated]
	private sealed class _ApplyOp_d__59 : IEnumerator<object> // TypeDefIndex: 349
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplier __4__this; // 0x28
		public float speed; // 0x30
		public int destroyRound; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOp_d__59(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018032D2C0-0x000000018032DB60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032DB60-0x000000018032DBA0
	}

	[CompilerGenerated]
	private sealed class _ApplyOpsInner_d__57 : IEnumerator<object> // TypeDefIndex: 350
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<MatchOpDTO> ops; // 0x20
		public BoardWsApplier __4__this; // 0x28
		private float _phaseStart_5__2; // 0x30
		private int _destroyRound_5__3; // 0x34
		private int _i_5__4; // 0x38
		private MatchOpDTO _op_5__5; // 0x40
		private float _speed_5__6; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOpsInner_d__57(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018032E010-0x000000018032E040
		private bool MoveNext(); // 0x000000018032DBA0-0x000000018032DFD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032DFD0-0x000000018032E010
	}

	[CompilerGenerated]
	private sealed class _ApplyOpsSequential_d__46 : IEnumerator<object> // TypeDefIndex: 351
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOpsSequential_d__46(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018032E040-0x000000018032E650
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032E650-0x000000018032E690
	}

	[CompilerGenerated]
	private sealed class _ApplyShuffle_d__70 : IEnumerator<object> // TypeDefIndex: 352
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30
		private BoardCellDTO[][] _grid_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyShuffle_d__70(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x000000018032E690-0x000000018032EFC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032EFC0-0x000000018032F000
	}

	[CompilerGenerated]
	private sealed class _ApplyVfx_d__85 : IEnumerator<object> // TypeDefIndex: 353
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplier __4__this; // 0x28
		public float speed; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyVfx_d__85(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018032F000-0x000000018032F750
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032F750-0x000000018032F790
	}

	[CompilerGenerated]
	private sealed class _BootstrapMatch_d__16 : IEnumerator<object> // TypeDefIndex: 354
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		private float _wait_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _BootstrapMatch_d__16(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018032F790-0x000000018032FB40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032FB40-0x000000018032FB80
	}

	[CompilerGenerated]
	private sealed class _ClearGalaxyHintsAfter_d__52 : IEnumerator<object> // TypeDefIndex: 355
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplier __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClearGalaxyHintsAfter_d__52(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018032FB80-0x000000018032FC40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032FC40-0x000000018032FC80
	}

	[CompilerGenerated]
	private sealed class _ClearMega2HintsAfter_d__53 : IEnumerator<object> // TypeDefIndex: 356
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplier __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClearMega2HintsAfter_d__53(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018032FC80-0x000000018032FD40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032FD40-0x000000018032FD80
	}

	[CompilerGenerated]
	private sealed class _ClearMegaIcarusHintsAfter_d__54 : IEnumerator<object> // TypeDefIndex: 357
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplier __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClearMegaIcarusHintsAfter_d__54(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018032FD80-0x000000018032FE40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018032FE40-0x000000018032FE80
	}

	[CompilerGenerated]
	private sealed class _DrainBatchQueue_d__44 : IEnumerator<object> // TypeDefIndex: 358
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DrainBatchQueue_d__44(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180330090-0x0000000180330130
		private bool MoveNext(); // 0x000000018032FE80-0x0000000180330050
		private void __m__Finally1(); // 0x0000000180330130-0x0000000180330160
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180330050-0x0000000180330090
	}

	[CompilerGenerated]
	private sealed class _EnsureFusionCardsWhenReady_d__107 : IEnumerator<object> // TypeDefIndex: 359
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		private float _deadline_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _EnsureFusionCardsWhenReady_d__107(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180330160-0x00000001803303B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803303B0-0x00000001803303F0
	}

	[CompilerGenerated]
	private sealed class _HealPopupRoutine_d__80 : IEnumerator<object> // TypeDefIndex: 360
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public Active act; // 0x28
		public int amount; // 0x30
		public bool npcSide; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HealPopupRoutine_d__80(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803303F0-0x00000001803304F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803304F0-0x0000000180330530
	}

	[CompilerGenerated]
	private sealed class _LoadBoardFromSnapshot_d__21 : IEnumerator<object> // TypeDefIndex: 361
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadBoardFromSnapshot_d__21(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180330C30-0x0000000180330CC0
		private bool MoveNext(); // 0x0000000180330AA0-0x0000000180330BF0
		private void __m__Finally1(); // 0x0000000180330CC0-0x0000000180330CF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180330BF0-0x0000000180330C30
	}

	[CompilerGenerated]
	private sealed class _LoadBoardFromSnapshotCore_d__22 : IEnumerator<object> // TypeDefIndex: 362
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		private float _waitStart_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadBoardFromSnapshotCore_d__22(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180330530-0x0000000180330A60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180330A60-0x0000000180330AA0
	}

	[CompilerGenerated]
	private sealed class _PlayFusionResultFx_d__102 : IEnumerator<object> // TypeDefIndex: 363
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayFusionResultFx_d__102(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180331290-0x0000000180331300
		private bool MoveNext(); // 0x0000000180330CF0-0x0000000180331250
		private void __m__Finally1(); // 0x0000000180331300-0x00000001803313A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180331250-0x0000000180331290
	}

	[CompilerGenerated]
	private sealed class _PlayInvalidSwapFeedback_d__120 : IEnumerator<object> // TypeDefIndex: 364
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayInvalidSwapFeedback_d__120(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180331740-0x0000000180331780
		private bool MoveNext(); // 0x00000001803313A0-0x0000000180331700
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180331700-0x0000000180331740
	}

	[CompilerGenerated]
	private sealed class _ResyncMatch_d__18 : IEnumerator<object> // TypeDefIndex: 365
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ResyncMatch_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180331D90-0x00000001803320C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803320C0-0x0000000180332100
	}

	[CompilerGenerated]
	private sealed class _RunThenFlag_d__104 : IEnumerator<object> // TypeDefIndex: 366
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public IEnumerator inner; // 0x20
		public Action onDone; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RunThenFlag_d__104(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180332100-0x0000000180332170
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180332170-0x00000001803321B0
	}

	[CompilerGenerated]
	private sealed class _RunWithTimeout_d__103 : IEnumerator<object> // TypeDefIndex: 367
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20
		public IEnumerator inner; // 0x28
		public float timeoutSec; // 0x30
		private __c__DisplayClass103_0 __8__1; // 0x38
		private float _deadline_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RunWithTimeout_d__103(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x00000001803321B0-0x00000001803323B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803323B0-0x00000001803323F0
	}

	[CompilerGenerated]
	private sealed class _WaitForFallToSettle_d__36 : IEnumerator<object> // TypeDefIndex: 368
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplier __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitForFallToSettle_d__36(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180332D20-0x0000000180332EB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180332EB0-0x0000000180332EF0
	}

	// Constructors
	public BoardWsApplier(); // 0x00000001806F01B0-0x00000001806F0340
	static BoardWsApplier(); // 0x00000001806F00F0-0x00000001806F01B0

	// Methods
	private void Awake(); // 0x00000001806E6EE0-0x00000001806E6EF0
	private void Start(); // 0x00000001806EEE60-0x00000001806EEE90
	private void OnEnable(); // 0x00000001806EC4B0-0x00000001806EC4D0
	private void OnDisable(); // 0x00000001806EC3A0-0x00000001806EC4B0
	private void OnDestroy(); // 0x00000001806EC290-0x00000001806EC3A0
	private void RegisterBusyProbe(); // 0x00000001806EDA70-0x00000001806EDB70
	private bool IsRendererBusy(); // 0x00000001806EBE20-0x00000001806EBE50
	private void EnsureBoardRef(); // 0x00000001806E7D50-0x00000001806E7F20
	private void EnsureMoveHint(); // 0x00000001806E7F90-0x00000001806E8060
	private void TrySubscribe(); // 0x00000001806EEE90-0x00000001806EF430
	private void HandleEnergyDeltaWarn(ChatMessageDTO m); // 0x00000001806E8B60-0x00000001806E8D30
	private void Unsubscribe(); // 0x00000001806EF560-0x00000001806EFB00
	private void HandleMatchStart(ChatMessageDTO m); // 0x00000001806E9CA0-0x00000001806E9FF0
	[IteratorStateMachine(typeof(_BootstrapMatch_d__16))]
	private IEnumerator BootstrapMatch(Dictionary<string, object> payload); // 0x00000001806E6EF0-0x00000001806E6F80
	private void HandleMatchResync(ChatMessageDTO m); // 0x00000001806E9AE0-0x00000001806E9CA0
	[IteratorStateMachine(typeof(_ResyncMatch_d__18))]
	private IEnumerator ResyncMatch(Dictionary<string, object> payload); // 0x00000001806EE0C0-0x00000001806EE150
	private void ResetStatusFxForMatch(); // 0x00000001806EDCC0-0x00000001806EDE70
	[IteratorStateMachine(typeof(_LoadBoardFromSnapshot_d__21))]
	private IEnumerator LoadBoardFromSnapshot(Dictionary<string, object> payload); // 0x00000001806EBFF0-0x00000001806EC080
	[IteratorStateMachine(typeof(_LoadBoardFromSnapshotCore_d__22))]
	private IEnumerator LoadBoardFromSnapshotCore(Dictionary<string, object> payload); // 0x00000001806EBF60-0x00000001806EBFF0
	private void ClearAllDots(); // 0x00000001806E6F80-0x00000001806E7190
	private Transform GetCachedDotsParent(); // 0x00000001806E85A0-0x00000001806E8670
	private GameObject FindDotPrefabByTag(string tag); // 0x00000001806E8150-0x00000001806E8340
	private static void WarnTagManagerOnce(string tag); // 0x00000001806F0030-0x00000001806F00F0
	private void SpawnDotByTag(int col, int row, string tag, int multiplier, bool fallFromAbove = false /* Metadata: 0x0064C1F5 */); // 0x00000001806EE980-0x00000001806EEE60
	[IteratorStateMachine(typeof(_WaitForFallToSettle_d__36))]
	private IEnumerator WaitForFallToSettle(); // 0x00000001806EFFC0-0x00000001806F0030
	private static bool IsSkillCardOp(MatchOpDTO op); // 0x00000001806EBE50-0x00000001806EBF60
	private static bool IsBossCardOp(MatchOpDTO op); // 0x00000001806EBD10-0x00000001806EBDD0
	private static bool HasSkillCardOp(List<MatchOpDTO> ops); // 0x00000001806EB830-0x00000001806EB9B0
	private static string ReadSkillElementType(List<MatchOpDTO> ops); // 0x00000001806ED7B0-0x00000001806ED9B0
	private void HandleOpsApplied(List<MatchOpDTO> ops); // 0x00000001806E9FF0-0x00000001806EA260
	private void EnqueueFxOnly(IEnumerator fx); // 0x00000001806E7C80-0x00000001806E7D50
	[IteratorStateMachine(typeof(_DrainBatchQueue_d__44))]
	private IEnumerator DrainBatchQueue(); // 0x00000001806E7C10-0x00000001806E7C80
	[IteratorStateMachine(typeof(_ApplyOpsSequential_d__46))]
	private IEnumerator ApplyOpsSequential(List<MatchOpDTO> ops, WsCombatBatch combat); // 0x00000001806E5170-0x00000001806E5220
	private static bool DetectFullPowerSpend(List<MatchOpDTO> ops, string actorUsername); // 0x00000001806E7880-0x00000001806E7B30
	private void HandleBossAction(ChatMessageDTO m); // 0x00000001806E88E0-0x00000001806E8B60
	private void HandleSkillCast(ChatMessageDTO m); // 0x00000001806EA760-0x00000001806EB3C0
	[IteratorStateMachine(typeof(_ClearGalaxyHintsAfter_d__52))]
	private IEnumerator ClearGalaxyHintsAfter(float sec); // 0x00000001806E72F0-0x00000001806E7370
	[IteratorStateMachine(typeof(_ClearMega2HintsAfter_d__53))]
	private IEnumerator ClearMega2HintsAfter(float sec); // 0x00000001806E7370-0x00000001806E73F0
	[IteratorStateMachine(typeof(_ClearMegaIcarusHintsAfter_d__54))]
	private IEnumerator ClearMegaIcarusHintsAfter(float sec); // 0x00000001806E73F0-0x00000001806E7470
	private void HandleSkillHint(ChatMessageDTO m); // 0x00000001806EB3C0-0x00000001806EB7B0
	private void HandleQteEvent(ChatMessageDTO m); // 0x00000001806EA480-0x00000001806EA760
	[IteratorStateMachine(typeof(_ApplyOpsInner_d__57))]
	private IEnumerator ApplyOpsInner(List<MatchOpDTO> ops); // 0x00000001806E50E0-0x00000001806E5170
	private void ApplyFallOrSpawn(MatchOpDTO op); // 0x00000001806E4820-0x00000001806E48A0
	[IteratorStateMachine(typeof(_ApplyOp_d__59))]
	private IEnumerator ApplyOp(MatchOpDTO op, float speed, int destroyRound); // 0x00000001806E5030-0x00000001806E50E0
	private void ApplyHighlight(MatchOpDTO op); // 0x00000001806E4B20-0x00000001806E4F90
	private void ApplySwap(MatchOpDTO op); // 0x00000001806E6B50-0x00000001806E6E40
	private void ClearPredictionFlag(GameObject go); // 0x00000001806E7470-0x00000001806E7510
	[IteratorStateMachine(typeof(_ApplyDestroySequenced_d__63))]
	private IEnumerator ApplyDestroySequenced(MatchOpDTO op, float speed, int destroyRound); // 0x00000001806E46D0-0x00000001806E4780
	private static void PlayMatchAudioOncePerTag(List<GameObject> targets, int destroyRound); // 0x00000001806ECDC0-0x00000001806ED100
	private int VerifyBoardAgainstServer(BoardCellDTO[][] serverBoard); // 0x00000001806EFBE0-0x00000001806EFFC0
	[IteratorStateMachine(typeof(_ApplyShuffle_d__70))]
	private IEnumerator ApplyShuffle(MatchOpDTO op, float speed); // 0x00000001806E54C0-0x00000001806E5560
	private static BoardCellDTO[][] ParseShuffleBoard(MatchOpDTO op); // 0x00000001806EC4D0-0x00000001806EC6B0
	private static string ReadString(Dictionary<string, object> d, string key, string fb = null); // 0x00000001806ED9B0-0x00000001806EDA70
	private void ApplyFall(MatchOpDTO op); // 0x00000001806E48A0-0x00000001806E4B20
	private void ApplySpawn(MatchOpDTO op); // 0x00000001806E5560-0x00000001806E57E0
	private void ApplyStatChange(MatchOpDTO op); // 0x00000001806E57E0-0x00000001806E63A0
	private static string ReadReason(Dictionary<string, object> data); // 0x00000001806ED720-0x00000001806ED7B0
	private static bool IsHealReason(string reason); // 0x00000001806EBDD0-0x00000001806EBE20
	private void ShowHealPopup(string user, int amount); // 0x00000001806EE280-0x00000001806EE450
	[IteratorStateMachine(typeof(_HealPopupRoutine_d__80))]
	private IEnumerator HealPopupRoutine(Active act, bool npcSide, int amount); // 0x00000001806EBBB0-0x00000001806EBC60
	private void ApplyBossHp(MatchOpDTO op); // 0x00000001806E41A0-0x00000001806E4640
	private void ApplyShieldExpire(MatchOpDTO op); // 0x00000001806E5220-0x00000001806E54C0
	private void ApplyStatus(MatchOpDTO op); // 0x00000001806E63A0-0x00000001806E6B50
	private int ResolveActorByUsername(string username); // 0x00000001806EDE70-0x00000001806EDF70
	[IteratorStateMachine(typeof(_ApplyVfx_d__85))]
	private IEnumerator ApplyVfx(MatchOpDTO op, float speed); // 0x00000001806E6E40-0x00000001806E6EE0
	[IteratorStateMachine(typeof(_ApplyDotConvert_d__90))]
	private IEnumerator ApplyDotConvert(MatchOpDTO op, float speed); // 0x00000001806E4780-0x00000001806E4820
	private GameObject DotAt(int col, int row); // 0x00000001806E7B30-0x00000001806E7C10
	private static Color ConvertGlowColor(string tag); // 0x00000001806E75A0-0x00000001806E7750
	private void SpawnConvertHalo(GameObject host, Color color, float life); // 0x00000001806EE450-0x00000001806EE980
	private void ClearConvertHalos(); // 0x00000001806E7190-0x00000001806E72F0
	[IteratorStateMachine(typeof(_ApplyMegaIcarusMark_d__95))]
	private IEnumerator ApplyMegaIcarusMark(MatchOpDTO op, float speed); // 0x00000001806E4F90-0x00000001806E5030
	private static int CountIn(HashSet<Vector2Int> a, HashSet<Vector2Int> b); // 0x00000001806E7750-0x00000001806E7880
	private Vector3 HealCellBoardCenter(); // 0x00000001806EB9B0-0x00000001806EBBB0
	private void PlayEnemyEvolveFlash(); // 0x00000001806EC6B0-0x00000001806EC900
	private void PlayEnemyPowerUpPunch(); // 0x00000001806EC900-0x00000001806ECC70
	private void HandleFusionResolved(ChatMessageDTO m); // 0x00000001806E8D30-0x00000001806E9500
	[IteratorStateMachine(typeof(_PlayFusionResultFx_d__102))]
	private IEnumerator PlayFusionResultFx(bool success, bool isLocal, string actor, string petName, int ghostPetId, int actorNum); // 0x00000001806ECC70-0x00000001806ECD10
	[IteratorStateMachine(typeof(_RunWithTimeout_d__103))]
	private IEnumerator RunWithTimeout(IEnumerator inner, float timeoutSec); // 0x00000001806EE1E0-0x00000001806EE280
	[IteratorStateMachine(typeof(_RunThenFlag_d__104))]
	private static IEnumerator RunThenFlag(IEnumerator inner, Action onDone); // 0x00000001806EE150-0x00000001806EE1E0
	private CardUI FindFusionCardUI(); // 0x00000001806E8340-0x00000001806E8520
	private void UnlockFusionCard(); // 0x00000001806EF430-0x00000001806EF560
	[IteratorStateMachine(typeof(_EnsureFusionCardsWhenReady_d__107))]
	private IEnumerator EnsureFusionCardsWhenReady(); // 0x00000001806E7F20-0x00000001806E7F90
	private static bool ReadPayloadBool(Dictionary<string, object> p, string key); // 0x00000001806ED550-0x00000001806ED670
	private static int ReadPayloadInt(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x0064C1F6 */); // 0x00000001806ED670-0x00000001806ED720
	[IteratorStateMachine(typeof(_ApplyCardUse_d__110))]
	private IEnumerator ApplyCardUse(MatchOpDTO op); // 0x00000001806E4640-0x00000001806E46D0
	private static Sprite LoadBossCardArt(int cardId); // 0x00000001806EC080-0x00000001806EC200
	internal static void NotifyLocalSkillCardShown(int cardId); // 0x00000001806EC220-0x00000001806EC290
	private static bool ConsumeLocalSkillCardShown(int cardId); // 0x00000001806E7510-0x00000001806E75A0
	private CardUI FindCardUIByCardId(int cardId); // 0x00000001806E8060-0x00000001806E8150
	private void HandleTurnEnd(); // 0x00000001806EB7B0-0x00000001806EB830
	private void HandleMatchReject(string reason); // 0x00000001806E9800-0x00000001806E9AE0
	[IteratorStateMachine(typeof(_PlayInvalidSwapFeedback_d__120))]
	private IEnumerator PlayInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x00000001806ECD10-0x00000001806ECDC0
	private void ResetDotToActualPosition(int col, int row); // 0x00000001806EDB70-0x00000001806EDCC0
	private void HandleGameOver(string winner); // 0x00000001806E9500-0x00000001806E9800
	private void HandlePlayerLeft(string username, bool isPermanent, string reason); // 0x00000001806EA260-0x00000001806EA3C0
	private void HandleAfkWarn(string username, int idleCount, int threshold); // 0x00000001806E8780-0x00000001806E88E0
	private void HandleAfkForfeit(string username, int threshold); // 0x00000001806E8670-0x00000001806E8780
	private void HandlePlayerRejoin(string username); // 0x00000001806EA3C0-0x00000001806EA480
	private int ResolveActorNumberFromUsername(string username); // 0x00000001806EDF70-0x00000001806EE0C0
	private bool InBounds(int col, int row); // 0x00000001806EBC60-0x00000001806EBD10
	private void UpdateDotPos(GameObject go, int col, int row); // 0x00000001806EFB00-0x00000001806EFBE0
	private static int ReadInt(Dictionary<string, object> d, string key, int fb = 0 /* Metadata: 0x0064C1F7 */); // 0x00000001806ED430-0x00000001806ED550
	private static bool ReadBool(Dictionary<string, object> d, string key, bool fb = false /* Metadata: 0x0064C1F8 */); // 0x00000001806ED100-0x00000001806ED210
	private void MarkCrit(bool atSelf); // 0x00000001806EC200-0x00000001806EC220
	private void FlushPendingCritLabels(); // 0x00000001806E8520-0x00000001806E85A0
	private static double ReadDouble(Dictionary<string, object> d, string key, double fb = 0 /* Metadata: 0x0064C1F9 */); // 0x00000001806ED210-0x00000001806ED430
}

