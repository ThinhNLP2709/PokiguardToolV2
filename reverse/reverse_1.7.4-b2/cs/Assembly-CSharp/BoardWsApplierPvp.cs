/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class BoardWsApplierPvp : MonoBehaviour // TypeDefIndex: 143
{
	// Fields
	private BoardPVP board; // 0x20
	private ActivePVP active; // 0x28
	private bool _subscribed; // 0x30
	private string _bootstrappedMatchId; // 0x38
	[CompilerGenerated]
	private static string _BootstrappedMatchId_k__BackingField; // 0x00
	private const int SPAWN_YIELD_EVERY = 16; // Metadata: 0x0068AB32
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
	private bool _suppressBarRefresh; // 0x65
	private static readonly Dictionary<string, int> _audioTagBuf; // 0x10
	private const float ShuffleShrinkSec = 0.22f; // Metadata: 0x0068AB33
	private const float ShuffleWaveDelayPerCell = 0.018f; // Metadata: 0x0068AB37
	private const float ShuffleEmptyBoardSec = 0.05f; // Metadata: 0x0068AB3B
	private bool _healPopupBusy; // 0x66
	private readonly Queue<HealPopupReq> _healPopupQueue; // 0x68
	private const int HealPopupQueueMax = 3; // Metadata: 0x0068AB3F
	private const float HealPopupGapSec = 0.25f; // Metadata: 0x0068AB40
	private bool _pendingCritAtSelf; // 0x70
	private bool _pendingCritAtEnemy; // 0x71
	private const float MegaIcarusMarkHoldSec = 0.9f; // Metadata: 0x0068AB44
	private const float DotConvertTelegraphSec = 0.35f; // Metadata: 0x0068AB48
	private const float DotConvertMorphSec = 0.25f; // Metadata: 0x0068AB4C
	private const float DotConvertStaggerSec = 0.04f; // Metadata: 0x0068AB50
	private readonly List<GameObject> _convertHalos; // 0x78
	private static readonly Dictionary<int, Sprite> _cardArtCache; // 0x18
	private static int _localShownCardId; // 0x20
	private static float _localShownAt; // 0x24
	private const float LocalShownTtlSec = 20f; // Metadata: 0x0068AB54
	private const float InvalidSwapFlashSec = 0.25f; // Metadata: 0x0068AB58
	private readonly HashSet<string> _offlineToastShown; // 0x80

	// Properties
	private bool WsPvpActive { get; } // 0x00000001806519C0-0x0000000180651B30 
	public static string BootstrappedMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180651970-0x00000001806519C0 0x0000000180651B30-0x0000000180651BA0

	// Nested types
	private struct HealPopupReq // TypeDefIndex: 144
	{
		// Fields
		public int actor; // 0x00
		public int amount; // 0x04
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass117_0 // TypeDefIndex: 145
	{
		// Fields
		public SpriteRenderer sr; // 0x10
		public Color color; // 0x18
		public GameObject halo; // 0x28
		public float life; // 0x30
		public Action<float> __9__2; // 0x38

		// Constructors
		public __c__DisplayClass117_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SpawnConvertHalo_b__0(float a); // 0x0000000180828CD0-0x0000000180828D80
		internal void _SpawnConvertHalo_b__1(); // 0x0000000180828D80-0x0000000180828EC0
		internal void _SpawnConvertHalo_b__2(float a); // 0x0000000180828EC0-0x0000000180828F70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass92_0 // TypeDefIndex: 146
	{
		// Fields
		public bool done; // 0x10

		// Constructors
		public __c__DisplayClass92_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RunWithTimeout_b__0(); // 0x000000018034AB40-0x000000018034AB50
	}

	[CompilerGenerated]
	private sealed class _ApplyCardUse_d__120 : IEnumerator<object> // TypeDefIndex: 147
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyCardUse_d__120(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018081DA10-0x000000018081DEC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018081DEC0-0x000000018081DF00
	}

	[CompilerGenerated]
	private sealed class _ApplyDestroySequenced_d__67 : IEnumerator<object> // TypeDefIndex: 148
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28
		public int destroyRound; // 0x30
		public float speed; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDestroySequenced_d__67(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018081DF00-0x000000018081E5B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018081E5B0-0x000000018081E5F0
	}

	[CompilerGenerated]
	private sealed class _ApplyDotConvert_d__114 : IEnumerator<object> // TypeDefIndex: 149
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDotConvert_d__114(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018035EF90-0x000000018035F0B0
		private bool MoveNext(); // 0x000000018081E5F0-0x000000018081F460
		private void __m__Finally1(); // 0x000000018035F0B0-0x000000018035F0D0
		private void __m__Finally2(); // 0x000000018035F0B0-0x000000018035F0D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018081F460-0x000000018081F4A0
	}

	[CompilerGenerated]
	private sealed class _ApplyMegaIcarusMark_d__119 : IEnumerator<object> // TypeDefIndex: 150
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyMegaIcarusMark_d__119(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018081F4A0-0x000000018081FD90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018081FD90-0x000000018081FDD0
	}

	[CompilerGenerated]
	private sealed class _ApplyOp_d__62 : IEnumerator<object> // TypeDefIndex: 151
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28
		public float speed; // 0x30
		public int destroyRound; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOp_d__62(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018081FDD0-0x0000000180820950
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180820950-0x0000000180820990
	}

	[CompilerGenerated]
	private sealed class _ApplyOpsSequential_d__60 : IEnumerator<object> // TypeDefIndex: 152
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOpsSequential_d__60(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180372850-0x0000000180372880
		private bool MoveNext(); // 0x0000000180820990-0x0000000180820E00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180820E00-0x0000000180820E40
	}

	[CompilerGenerated]
	private sealed class _ApplyOpsThenRender_d__57 : IEnumerator<object> // TypeDefIndex: 153
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public WsCombatBatch combat; // 0x28
		public List<MatchOpDTO> ops; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOpsThenRender_d__57(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180820E40-0x0000000180821400
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180821400-0x0000000180821440
	}

	[CompilerGenerated]
	private sealed class _ApplyShuffle_d__73 : IEnumerator<object> // TypeDefIndex: 154
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30
		private BoardCellDTO[][] _grid_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyShuffle_d__73(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x0000000180821440-0x0000000180821D50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180821D50-0x0000000180821D90
	}

	[CompilerGenerated]
	private sealed class _BootstrapMatch_d__26 : IEnumerator<object> // TypeDefIndex: 155
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		public BoardCellDTO[][] preBoard; // 0x30
		private float _wait_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BootstrapMatch_d__26(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180822650-0x0000000180822920
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180822920-0x0000000180822960
	}

	[CompilerGenerated]
	private sealed class _ClearGalaxyHintsAfter_d__105 : IEnumerator<object> // TypeDefIndex: 156
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClearGalaxyHintsAfter_d__105(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180822960-0x0000000180822A20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180822A20-0x0000000180822A60
	}

	[CompilerGenerated]
	private sealed class _ClearMega2HintsAfter_d__104 : IEnumerator<object> // TypeDefIndex: 157
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClearMega2HintsAfter_d__104(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180822A60-0x0000000180822B20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180822B20-0x0000000180822B60
	}

	[CompilerGenerated]
	private sealed class _ClearMegaIcarusHintsAfter_d__106 : IEnumerator<object> // TypeDefIndex: 158
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClearMegaIcarusHintsAfter_d__106(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180822B60-0x0000000180822C20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180822C20-0x0000000180822C60
	}

	[CompilerGenerated]
	private sealed class _DrainBatchQueue_d__55 : IEnumerator<object> // TypeDefIndex: 159
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DrainBatchQueue_d__55(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180822E70-0x0000000180822F10
		private bool MoveNext(); // 0x0000000180822C60-0x0000000180822E30
		private void __m__Finally1(); // 0x0000000180822F10-0x0000000180822F40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180822E30-0x0000000180822E70
	}

	[CompilerGenerated]
	private sealed class _DrainHealPopupQueue_d__87 : IEnumerator<object> // TypeDefIndex: 160
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DrainHealPopupQueue_d__87(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180822F40-0x0000000180823180
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180823180-0x00000001808231C0
	}

	[CompilerGenerated]
	private sealed class _EnsureFusionCardsWhenReady_d__95 : IEnumerator<object> // TypeDefIndex: 161
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		private float _deadline_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _EnsureFusionCardsWhenReady_d__95(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001808231C0-0x0000000180823410
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180823410-0x0000000180823450
	}

	[CompilerGenerated]
	private sealed class _LoadBoardFromSnapshot_d__30 : IEnumerator<object> // TypeDefIndex: 162
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadBoardFromSnapshot_d__30(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180372850-0x0000000180372880
		private bool MoveNext(); // 0x0000000180825430-0x0000000180825A20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180825A20-0x0000000180825A60
	}

	[CompilerGenerated]
	private sealed class _PlayFusionResultFx_d__91 : IEnumerator<object> // TypeDefIndex: 163
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public bool isLocal; // 0x28
		public int actor; // 0x2C
		public bool success; // 0x30
		public bool actorIsSelfSide; // 0x31
		public int ghostPetId; // 0x34
		private bool _hidBoard_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayFusionResultFx_d__91(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180827440-0x00000001808274B0
		private bool MoveNext(); // 0x0000000180826D60-0x0000000180827400
		private void __m__Finally1(); // 0x00000001808274B0-0x0000000180827550
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180827400-0x0000000180827440
	}

	[CompilerGenerated]
	private sealed class _PlayInvalidSwapFeedback_d__134 : IEnumerator<object> // TypeDefIndex: 164
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayInvalidSwapFeedback_d__134(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180377340-0x0000000180377380
		private bool MoveNext(); // 0x0000000180827550-0x00000001808278B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808278B0-0x00000001808278F0
	}

	[CompilerGenerated]
	private sealed class _ResyncMatch_d__29 : IEnumerator<object> // TypeDefIndex: 165
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		public BoardCellDTO[][] preBoard; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ResyncMatch_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180827DF0-0x00000001808280A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808280A0-0x00000001808280E0
	}

	[CompilerGenerated]
	private sealed class _RunThenFlag_d__93 : IEnumerator<object> // TypeDefIndex: 166
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
		public _RunThenFlag_d__93(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180378060-0x00000001803780D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808283B0-0x00000001808283F0
	}

	[CompilerGenerated]
	private sealed class _RunWithTimeout_d__92 : IEnumerator<object> // TypeDefIndex: 167
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public IEnumerator inner; // 0x28
		public float timeoutSec; // 0x30
		private __c__DisplayClass92_0 __8__1; // 0x38
		private float _deadline_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RunWithTimeout_d__92(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x00000001808283F0-0x00000001808285F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808285F0-0x0000000180828630
	}

	[CompilerGenerated]
	private sealed class _WaitForFallToSettle_d__46 : IEnumerator<object> // TypeDefIndex: 168
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitForFallToSettle_d__46(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180829740-0x00000001808298C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808298C0-0x0000000180829900
	}

	// Constructors
	public BoardWsApplierPvp(); // 0x0000000180651700-0x0000000180651970
	static BoardWsApplierPvp(); // 0x00000001806515E0-0x0000000180651700

	// Methods
	private void Awake(); // 0x00000001806484A0-0x00000001806484C0
	private void Start(); // 0x0000000180650610-0x0000000180650640
	private void OnEnable(); // 0x000000018064E120-0x000000018064E140
	private void OnDisable(); // 0x000000018064E010-0x000000018064E120
	private void OnDestroy(); // 0x000000018064DE20-0x000000018064E010
	private void RegisterBusyProbe(); // 0x000000018064F190-0x000000018064F290
	private bool IsRendererBusy(); // 0x000000018064D890-0x000000018064D8C0
	private void EnsureRefs(); // 0x0000000180649D10-0x0000000180649FD0
	private void EnsureMoveHint(); // 0x00000001806499C0-0x0000000180649AD0
	private void TrySubscribe(); // 0x0000000180650640-0x0000000180650B90
	private void HandleSkillHint(ChatMessageDTO m); // 0x000000018064CF50-0x000000018064D2C0
	private void HandleQteEvent(ChatMessageDTO m); // 0x000000018064C040-0x000000018064C270
	private void HandleEnergyDeltaWarn(ChatMessageDTO m); // 0x000000018064A820-0x000000018064A9F0
	private void Unsubscribe(); // 0x0000000180650B90-0x00000001806510B0
	public void SendMoveToWs(int fromCol, int fromRow, int toCol, int toRow); // 0x000000018064F8D0-0x000000018064F9F0
	private void HandleMatchStart(ChatMessageDTO m); // 0x000000018064B850-0x000000018064BB00
	[IteratorStateMachine(typeof(_BootstrapMatch_d__26))]
	private IEnumerator BootstrapMatch(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x0000000180648820-0x00000001806488D0
	private void ResetStatusFxForMatch(); // 0x000000018064F460-0x000000018064F5B0
	private void HandleMatchResync(ChatMessageDTO m); // 0x000000018064B730-0x000000018064B850
	[IteratorStateMachine(typeof(_ResyncMatch_d__29))]
	private IEnumerator ResyncMatch(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x000000018064F6F0-0x000000018064F7A0
	[IteratorStateMachine(typeof(_LoadBoardFromSnapshot_d__30))]
	private IEnumerator LoadBoardFromSnapshot(Dictionary<string, object> payload, BoardCellDTO[][] preBoard = null); // 0x000000018064D9D0-0x000000018064DA80
	private bool BoardHasFullGrid(); // 0x0000000180648690-0x0000000180648820
	private void ClearDotsAbsentFromSnapshot(BoardCellDTO[][] serverBoard); // 0x0000000180648C20-0x0000000180648E80
	private void ClearAllDots(); // 0x00000001806488D0-0x0000000180648AC0
	private GameObject FindDotPrefabByTag(string tag); // 0x000000018064A100-0x000000018064A3D0
	private void EnsurePrefabTable(); // 0x0000000180649AD0-0x0000000180649D10
	private void SpawnDotByTag(int col, int row, string tag, int multiplier, bool fallFromAbove = false /* Metadata: 0x0068AB27 */); // 0x00000001806500D0-0x0000000180650610
	[IteratorStateMachine(typeof(_WaitForFallToSettle_d__46))]
	private IEnumerator WaitForFallToSettle(); // 0x0000000180651570-0x00000001806515E0
	private static bool IsSkillCardOp(MatchOpDTO op); // 0x000000018064D8C0-0x000000018064D9D0
	private static bool IsLocalUserCardOp(MatchOpDTO op); // 0x000000018064D780-0x000000018064D890
	private static bool BatchTouchesBoard(List<MatchOpDTO> ops); // 0x00000001806484C0-0x0000000180648690
	private static bool HasSkillCardOp(List<MatchOpDTO> ops); // 0x000000018064D350-0x000000018064D4A0
	private static string ReadSkillElementType(List<MatchOpDTO> ops); // 0x000000018064EF00-0x000000018064F0D0
	private void HandleOpsApplied(List<MatchOpDTO> ops); // 0x000000018064BB00-0x000000018064BCF0
	private void EnqueueFxOnly(IEnumerator fx); // 0x0000000180649880-0x0000000180649950
	[IteratorStateMachine(typeof(_DrainBatchQueue_d__55))]
	private IEnumerator DrainBatchQueue(); // 0x00000001806497A0-0x0000000180649810
	[IteratorStateMachine(typeof(_ApplyOpsThenRender_d__57))]
	private IEnumerator ApplyOpsThenRender(List<MatchOpDTO> ops, WsCombatBatch combat); // 0x0000000180646E40-0x0000000180646EF0
	private static bool DetectFullPowerSpend(List<MatchOpDTO> ops, string actorUsername); // 0x0000000180649410-0x00000001806496C0
	private static int ResolveActorNumber(string username); // 0x000000018064F5B0-0x000000018064F6F0
	[IteratorStateMachine(typeof(_ApplyOpsSequential_d__60))]
	private IEnumerator ApplyOpsSequential(List<MatchOpDTO> ops); // 0x0000000180646DB0-0x0000000180646E40
	private void ApplyFallOrSpawn(MatchOpDTO op); // 0x0000000180646520-0x00000001806465A0
	[IteratorStateMachine(typeof(_ApplyOp_d__62))]
	private IEnumerator ApplyOp(MatchOpDTO op, float speed, int destroyRound); // 0x0000000180646D00-0x0000000180646DB0
	private void ApplySwap(MatchOpDTO op); // 0x00000001806481B0-0x00000001806484A0
	private void ClearPredictionFlag(GameObject go); // 0x0000000180649000-0x00000001806490A0
	private void ApplyHighlight(MatchOpDTO op); // 0x0000000180646810-0x0000000180646C60
	private int VerifyBoardAgainstServer(BoardCellDTO[][] serverBoard); // 0x00000001806511A0-0x0000000180651570
	[IteratorStateMachine(typeof(_ApplyDestroySequenced_d__67))]
	private IEnumerator ApplyDestroySequenced(MatchOpDTO op, float speed, int destroyRound); // 0x00000001806463D0-0x0000000180646480
	private static void PlayMatchAudioOncePerTag(List<GameObject> targets, int destroyRound); // 0x000000018064E500-0x000000018064E840
	[IteratorStateMachine(typeof(_ApplyShuffle_d__73))]
	private IEnumerator ApplyShuffle(MatchOpDTO op, float speed); // 0x0000000180647100-0x00000001806471A0
	private static BoardCellDTO[][] ParseShuffleBoard(MatchOpDTO op); // 0x000000018064E140-0x000000018064E320
	private static string ReadString(Dictionary<string, object> d, string key, string fb = null); // 0x000000018064F0D0-0x000000018064F190
	private void ApplyFall(MatchOpDTO op); // 0x00000001806465A0-0x0000000180646810
	private void ApplySpawn(MatchOpDTO op); // 0x00000001806471A0-0x0000000180647430
	private void ApplyStatChange(MatchOpDTO op); // 0x0000000180647430-0x0000000180647D00
	private static string ReadReasonPvp(Dictionary<string, object> d); // 0x000000018064EE70-0x000000018064EF00
	private static bool IsHealReasonPvp(string reason); // 0x000000018064D730-0x000000018064D780
	private void ShowHealPopup(int healedActor, int amount); // 0x000000018064F9F0-0x000000018064FB60
	[IteratorStateMachine(typeof(_DrainHealPopupQueue_d__87))]
	private IEnumerator DrainHealPopupQueue(); // 0x0000000180649810-0x0000000180649880
	private void ApplyShieldExpire(MatchOpDTO op); // 0x0000000180646EF0-0x0000000180647100
	private void ApplyStatus(MatchOpDTO op); // 0x0000000180647D00-0x00000001806481B0
	private void HandleFusionResolved(ChatMessageDTO m); // 0x000000018064A9F0-0x000000018064B1D0
	[IteratorStateMachine(typeof(_PlayFusionResultFx_d__91))]
	private IEnumerator PlayFusionResultFx(bool success, bool isLocal, bool actorIsSelfSide, string petName, int ghostPetId, int actor); // 0x000000018064E320-0x000000018064E3E0
	[IteratorStateMachine(typeof(_RunWithTimeout_d__92))]
	private IEnumerator RunWithTimeout(IEnumerator inner, float timeoutSec); // 0x000000018064F830-0x000000018064F8D0
	[IteratorStateMachine(typeof(_RunThenFlag_d__93))]
	private static IEnumerator RunThenFlag(IEnumerator inner, Action onDone); // 0x000000018064F7A0-0x000000018064F830
	private CardUIPVP FindFusionCardUI(); // 0x000000018064A3D0-0x000000018064A600
	[IteratorStateMachine(typeof(_EnsureFusionCardsWhenReady_d__95))]
	private IEnumerator EnsureFusionCardsWhenReady(); // 0x0000000180649950-0x00000001806499C0
	private static bool ReadPayloadBoolPvp(Dictionary<string, object> p, string key); // 0x000000018064ECA0-0x000000018064EDC0
	private static int ReadPayloadIntPvp(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x0068AB28 */); // 0x000000018064EDC0-0x000000018064EE70
	private static bool ReadBoolPvp(Dictionary<string, object> d, string key); // 0x000000018064E840-0x000000018064E960
	private void MarkCrit(bool atSelf); // 0x000000018064DDA0-0x000000018064DDB0
	private void FlushPendingCritLabels(); // 0x000000018064A600-0x000000018064A6A0
	private void HandleSkillCast(ChatMessageDTO m); // 0x000000018064C270-0x000000018064CF50
	[IteratorStateMachine(typeof(_ClearMega2HintsAfter_d__104))]
	private IEnumerator ClearMega2HintsAfter(float sec); // 0x0000000180648F00-0x0000000180648F80
	[IteratorStateMachine(typeof(_ClearGalaxyHintsAfter_d__105))]
	private IEnumerator ClearGalaxyHintsAfter(float sec); // 0x0000000180648E80-0x0000000180648F00
	[IteratorStateMachine(typeof(_ClearMegaIcarusHintsAfter_d__106))]
	private IEnumerator ClearMegaIcarusHintsAfter(float sec); // 0x0000000180648F80-0x0000000180649000
	private static int CountIn(HashSet<Vector2Int> a, HashSet<Vector2Int> b); // 0x00000001806492E0-0x0000000180649410
	private Vector3 HealCellBoardCenter(); // 0x000000018064D4A0-0x000000018064D690
	[IteratorStateMachine(typeof(_ApplyDotConvert_d__114))]
	private IEnumerator ApplyDotConvert(MatchOpDTO op, float speed); // 0x0000000180646480-0x0000000180646520
	private GameObject DotAt(int col, int row); // 0x00000001806496C0-0x00000001806497A0
	private static Color ConvertGlowColor(string tag); // 0x0000000180649130-0x00000001806492E0
	private void SpawnConvertHalo(GameObject host, Color color, float life); // 0x000000018064FBA0-0x00000001806500D0
	private void ClearConvertHalos(); // 0x0000000180648AC0-0x0000000180648C20
	[IteratorStateMachine(typeof(_ApplyMegaIcarusMark_d__119))]
	private IEnumerator ApplyMegaIcarusMark(MatchOpDTO op, float speed); // 0x0000000180646C60-0x0000000180646D00
	[IteratorStateMachine(typeof(_ApplyCardUse_d__120))]
	private IEnumerator ApplyCardUse(MatchOpDTO op); // 0x0000000180646340-0x00000001806463D0
	private static Sprite LoadCardArtById(int cardId); // 0x000000018064DA80-0x000000018064DDA0
	public static void ResetStaticState(); // 0x000000018064F3F0-0x000000018064F460
	internal static void NotifyLocalSkillCardShown(int cardId); // 0x000000018064DDB0-0x000000018064DE20
	private static bool ConsumeLocalSkillCardShown(int cardId); // 0x00000001806490A0-0x0000000180649130
	private CardUIPVP FindCardUIByCardId(int cardId); // 0x0000000180649FD0-0x000000018064A100
	private void HandleTurnEnd(); // 0x000000018064D2C0-0x000000018064D350
	private void HandleMatchReject(string reason); // 0x000000018064B480-0x000000018064B730
	public void PlayLocalInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x000000018064E490-0x000000018064E500
	[IteratorStateMachine(typeof(_PlayInvalidSwapFeedback_d__134))]
	private IEnumerator PlayInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x000000018064E3E0-0x000000018064E490
	private void ResetDotToActualPosition(int col, int row); // 0x000000018064F290-0x000000018064F3F0
	private void HandleGameOver(string winner); // 0x000000018064B1D0-0x000000018064B480
	private void HandlePlayerLeft(string username, bool isPermanent, string reason); // 0x000000018064BCF0-0x000000018064BF60
	private void HandlePlayerRejoin(string username); // 0x000000018064BF60-0x000000018064C040
	private void HandleAfkWarn(string username, int idleCount, int threshold); // 0x000000018064A6A0-0x000000018064A820
	private static void ShowToast(string message); // 0x000000018064FB60-0x000000018064FBA0
	private bool InBounds(int col, int row); // 0x000000018064D690-0x000000018064D730
	private void UpdateDotPos(GameObject go, int col, int row); // 0x00000001806510B0-0x00000001806511A0
	private static double ReadDouble(Dictionary<string, object> d, string key, double fb = 0 /* Metadata: 0x0068AB29 */); // 0x000000018064E960-0x000000018064EB80
	private static int ReadInt(Dictionary<string, object> d, string key, int fb = 0 /* Metadata: 0x0068AB31 */); // 0x000000018064EB80-0x000000018064ECA0
}

