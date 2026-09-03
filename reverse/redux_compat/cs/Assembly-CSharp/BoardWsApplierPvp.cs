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
public class BoardWsApplierPvp : MonoBehaviour // TypeDefIndex: 132
{
	// Fields
	private BoardPVP board; // 0x20
	private ActivePVP active; // 0x28
	private bool _subscribed; // 0x30
	private string _bootstrappedMatchId; // 0x38
	private static bool _tagFallbackWarnedPvp; // 0x00
	[TupleElementNames(new string[3] {"ops", "combat", "fx" })]
	private readonly Queue<ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator>> _pendingBatches; // 0x40
	private bool _renderRunning; // 0x48
	private bool _boardHiddenForCard; // 0x49
	private float _lastFallStartedAt; // 0x4C
	private float _lastFallNeedSec; // 0x50
	private bool _suppressBarRefresh; // 0x54
	private static readonly Dictionary<string, int> _audioTagBuf; // 0x08
	private const float ShuffleShrinkSec = 0.22f; // Metadata: 0x0064BFFE
	private const float ShuffleWaveDelayPerCell = 0.018f; // Metadata: 0x0064C002
	private const float ShuffleEmptyBoardSec = 0.05f; // Metadata: 0x0064C006
	private bool _healPopupBusy; // 0x55
	private bool _pendingCritAtSelf; // 0x56
	private bool _pendingCritAtEnemy; // 0x57
	private const float MegaIcarusMarkHoldSec = 0.9f; // Metadata: 0x0064C00A
	private const float DotConvertTelegraphSec = 0.35f; // Metadata: 0x0064C00E
	private const float DotConvertMorphSec = 0.25f; // Metadata: 0x0064C012
	private const float DotConvertStaggerSec = 0.04f; // Metadata: 0x0064C016
	private readonly List<GameObject> _convertHalos; // 0x58
	private static int _localShownCardId; // 0x10
	private static float _localShownAt; // 0x14
	private const float LocalShownTtlSec = 20f; // Metadata: 0x0064C01A
	private const float InvalidSwapFlashSec = 0.25f; // Metadata: 0x0064C01E
	private readonly HashSet<string> _offlineToastShown; // 0x60

	// Properties
	private bool WsPvpActive { get; } // 0x0000000180522640-0x00000001805227B0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass73_0 // TypeDefIndex: 133
	{
		// Fields
		public bool done; // 0x10

		// Constructors
		public __c__DisplayClass73_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RunWithTimeout_b__0(); // 0x000000018030F220-0x000000018030F230
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass98_0 // TypeDefIndex: 134
	{
		// Fields
		public SpriteRenderer sr; // 0x10
		public Color color; // 0x18
		public GameObject halo; // 0x28
		public float life; // 0x30
		public Action<float> __9__2; // 0x38

		// Constructors
		public __c__DisplayClass98_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SpawnConvertHalo_b__0(float a); // 0x0000000180627E40-0x0000000180627EF0
		internal void _SpawnConvertHalo_b__1(); // 0x0000000180627EF0-0x0000000180628030
		internal void _SpawnConvertHalo_b__2(float a); // 0x0000000180628030-0x00000001806280E0
	}

	[CompilerGenerated]
	private sealed class _ApplyCardUse_d__101 : IEnumerator<object> // TypeDefIndex: 135
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyCardUse_d__101(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180621B20-0x0000000180621EE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180621EE0-0x0000000180621F20
	}

	[CompilerGenerated]
	private sealed class _ApplyDestroySequenced_d__52 : IEnumerator<object> // TypeDefIndex: 136
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28
		public int destroyRound; // 0x30
		public float speed; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDestroySequenced_d__52(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180621F20-0x00000001806225F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806225F0-0x0000000180622630
	}

	[CompilerGenerated]
	private sealed class _ApplyDotConvert_d__95 : IEnumerator<object> // TypeDefIndex: 137
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDotConvert_d__95(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018032C7E0-0x000000018032C900
		private bool MoveNext(); // 0x0000000180622630-0x00000001806234C0
		private void __m__Finally1(); // 0x000000018032C900-0x000000018032C920
		private void __m__Finally2(); // 0x000000018032C900-0x000000018032C920
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806234C0-0x0000000180623500
	}

	[CompilerGenerated]
	private sealed class _ApplyMegaIcarusMark_d__100 : IEnumerator<object> // TypeDefIndex: 138
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyMegaIcarusMark_d__100(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180623500-0x0000000180623E30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180623E30-0x0000000180623E70
	}

	[CompilerGenerated]
	private sealed class _ApplyOp_d__47 : IEnumerator<object> // TypeDefIndex: 139
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchOpDTO op; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28
		public float speed; // 0x30
		public int destroyRound; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOp_d__47(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180623E70-0x0000000180624980
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180624980-0x00000001806249C0
	}

	[CompilerGenerated]
	private sealed class _ApplyOpsSequential_d__45 : IEnumerator<object> // TypeDefIndex: 140
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<MatchOpDTO> ops; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28
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
		public _ApplyOpsSequential_d__45(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018032E010-0x000000018032E040
		private bool MoveNext(); // 0x00000001806249C0-0x0000000180624DF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180624DF0-0x0000000180624E30
	}

	[CompilerGenerated]
	private sealed class _ApplyOpsThenRender_d__42 : IEnumerator<object> // TypeDefIndex: 141
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public WsCombatBatch combat; // 0x28
		public List<MatchOpDTO> ops; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyOpsThenRender_d__42(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180624E30-0x0000000180625380
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180625380-0x00000001806253C0
	}

	[CompilerGenerated]
	private sealed class _ApplyShuffle_d__58 : IEnumerator<object> // TypeDefIndex: 142
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public MatchOpDTO op; // 0x28
		public float speed; // 0x30
		private BoardCellDTO[][] _grid_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyShuffle_d__58(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x00000001806253C0-0x0000000180625CD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180625CD0-0x0000000180625D10
	}

	[CompilerGenerated]
	private sealed class _BootstrapMatch_d__20 : IEnumerator<object> // TypeDefIndex: 143
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		private float _wait_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _BootstrapMatch_d__20(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180625D10-0x0000000180625FE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180625FE0-0x0000000180626020
	}

	[CompilerGenerated]
	private sealed class _ClearGalaxyHintsAfter_d__86 : IEnumerator<object> // TypeDefIndex: 144
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClearGalaxyHintsAfter_d__86(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180626020-0x00000001806260E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806260E0-0x0000000180626120
	}

	[CompilerGenerated]
	private sealed class _ClearMega2HintsAfter_d__85 : IEnumerator<object> // TypeDefIndex: 145
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClearMega2HintsAfter_d__85(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180626120-0x00000001806261E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806261E0-0x0000000180626220
	}

	[CompilerGenerated]
	private sealed class _ClearMegaIcarusHintsAfter_d__87 : IEnumerator<object> // TypeDefIndex: 146
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public BoardWsApplierPvp __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClearMegaIcarusHintsAfter_d__87(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180626220-0x00000001806262E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806262E0-0x0000000180626320
	}

	[CompilerGenerated]
	private sealed class _DrainBatchQueue_d__40 : IEnumerator<object> // TypeDefIndex: 147
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DrainBatchQueue_d__40(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180626530-0x00000001806265D0
		private bool MoveNext(); // 0x0000000180626320-0x00000001806264F0
		private void __m__Finally1(); // 0x00000001806265D0-0x0000000180626600
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806264F0-0x0000000180626530
	}

	[CompilerGenerated]
	private sealed class _EnsureFusionCardsWhenReady_d__76 : IEnumerator<object> // TypeDefIndex: 148
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		private float _deadline_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _EnsureFusionCardsWhenReady_d__76(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180626600-0x0000000180626850
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180626850-0x0000000180626890
	}

	[CompilerGenerated]
	private sealed class _HealPopupRoutine_d__68 : IEnumerator<object> // TypeDefIndex: 149
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public int amount; // 0x28
		public int healedActor; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HealPopupRoutine_d__68(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180626890-0x00000001806269A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806269A0-0x00000001806269E0
	}

	[CompilerGenerated]
	private sealed class _LoadBoardFromSnapshot_d__24 : IEnumerator<object> // TypeDefIndex: 150
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28
		private float _waitStart_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadBoardFromSnapshot_d__24(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806269E0-0x0000000180626E90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180626E90-0x0000000180626ED0
	}

	[CompilerGenerated]
	private sealed class _PlayFusionResultFx_d__72 : IEnumerator<object> // TypeDefIndex: 151
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayFusionResultFx_d__72(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001806274A0-0x0000000180627510
		private bool MoveNext(); // 0x0000000180626ED0-0x0000000180627460
		private void __m__Finally1(); // 0x0000000180627510-0x00000001806275B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180627460-0x00000001806274A0
	}

	[CompilerGenerated]
	private sealed class _PlayInvalidSwapFeedback_d__113 : IEnumerator<object> // TypeDefIndex: 152
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayInvalidSwapFeedback_d__113(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180331740-0x0000000180331780
		private bool MoveNext(); // 0x00000001806275B0-0x0000000180627910
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180627910-0x0000000180627950
	}

	[CompilerGenerated]
	private sealed class _ResyncMatch_d__23 : IEnumerator<object> // TypeDefIndex: 153
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public Dictionary<string, object> payload; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ResyncMatch_d__23(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180627950-0x0000000180627B80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180627B80-0x0000000180627BC0
	}

	[CompilerGenerated]
	private sealed class _RunThenFlag_d__74 : IEnumerator<object> // TypeDefIndex: 154
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
		public _RunThenFlag_d__74(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180332100-0x0000000180332170
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180627BC0-0x0000000180627C00
	}

	[CompilerGenerated]
	private sealed class _RunWithTimeout_d__73 : IEnumerator<object> // TypeDefIndex: 155
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20
		public IEnumerator inner; // 0x28
		public float timeoutSec; // 0x30
		private __c__DisplayClass73_0 __8__1; // 0x38
		private float _deadline_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RunWithTimeout_d__73(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x0000000180627C00-0x0000000180627E00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180627E00-0x0000000180627E40
	}

	[CompilerGenerated]
	private sealed class _WaitForFallToSettle_d__34 : IEnumerator<object> // TypeDefIndex: 156
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardWsApplierPvp __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitForFallToSettle_d__34(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806280E0-0x0000000180628260
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180628260-0x00000001806282A0
	}

	// Constructors
	public BoardWsApplierPvp(); // 0x00000001805224B0-0x0000000180522640
	static BoardWsApplierPvp(); // 0x00000001805223F0-0x00000001805224B0

	// Methods
	private void Awake(); // 0x000000018051A820-0x000000018051A840
	private void Start(); // 0x0000000180521570-0x00000001805215A0
	private void OnEnable(); // 0x000000018051F290-0x000000018051F2B0
	private void OnDisable(); // 0x000000018051F180-0x000000018051F290
	private void OnDestroy(); // 0x000000018051F070-0x000000018051F180
	private void RegisterBusyProbe(); // 0x0000000180520290-0x0000000180520390
	private bool IsRendererBusy(); // 0x000000018051EC90-0x000000018051ECC0
	private void EnsureRefs(); // 0x000000018051B7D0-0x000000018051BA60
	private void EnsureMoveHint(); // 0x000000018051B700-0x000000018051B7D0
	private void TrySubscribe(); // 0x00000001805215A0-0x0000000180521A50
	private void HandleEnergyDeltaWarn(ChatMessageDTO m); // 0x000000018051C180-0x000000018051C350
	private void Unsubscribe(); // 0x0000000180521A50-0x0000000180521ED0
	public void SendMoveToWs(int fromCol, int fromRow, int toCol, int toRow); // 0x0000000180520950-0x0000000180520A70
	private void HandleMatchStart(ChatMessageDTO m); // 0x000000018051D160-0x000000018051D4A0
	[IteratorStateMachine(typeof(_BootstrapMatch_d__20))]
	private IEnumerator BootstrapMatch(Dictionary<string, object> payload); // 0x000000018051A840-0x000000018051A8D0
	private void ResetStatusFxForMatch(); // 0x0000000180520550-0x0000000180520650
	private void HandleMatchResync(ChatMessageDTO m); // 0x000000018051D070-0x000000018051D160
	[IteratorStateMachine(typeof(_ResyncMatch_d__23))]
	private IEnumerator ResyncMatch(Dictionary<string, object> payload); // 0x0000000180520790-0x0000000180520820
	[IteratorStateMachine(typeof(_LoadBoardFromSnapshot_d__24))]
	private IEnumerator LoadBoardFromSnapshot(Dictionary<string, object> payload); // 0x000000018051EDD0-0x000000018051EE60
	private void ClearAllDots(); // 0x000000018051A8D0-0x000000018051AAD0
	private GameObject FindDotPrefabByTag(string tag); // 0x000000018051BB50-0x000000018051BDB0
	private void SpawnDotByTag(int col, int row, string tag, int multiplier, bool fallFromAbove = false /* Metadata: 0x0064BFF3 */); // 0x0000000180521120-0x0000000180521570
	[IteratorStateMachine(typeof(_WaitForFallToSettle_d__34))]
	private IEnumerator WaitForFallToSettle(); // 0x0000000180522380-0x00000001805223F0
	private static bool IsSkillCardOp(MatchOpDTO op); // 0x000000018051ECC0-0x000000018051EDD0
	private static bool HasSkillCardOp(List<MatchOpDTO> ops); // 0x000000018051E7D0-0x000000018051E920
	private static string ReadSkillElementType(List<MatchOpDTO> ops); // 0x0000000180520000-0x00000001805201D0
	private void HandleOpsApplied(List<MatchOpDTO> ops); // 0x000000018051D4A0-0x000000018051D690
	private void EnqueueFxOnly(IEnumerator fx); // 0x000000018051B5C0-0x000000018051B690
	[IteratorStateMachine(typeof(_DrainBatchQueue_d__40))]
	private IEnumerator DrainBatchQueue(); // 0x000000018051B550-0x000000018051B5C0
	[IteratorStateMachine(typeof(_ApplyOpsThenRender_d__42))]
	private IEnumerator ApplyOpsThenRender(List<MatchOpDTO> ops, WsCombatBatch combat); // 0x0000000180519230-0x00000001805192E0
	private static bool DetectFullPowerSpend(List<MatchOpDTO> ops, string actorUsername); // 0x000000018051B1C0-0x000000018051B470
	private static int ResolveActorNumber(string username); // 0x0000000180520650-0x0000000180520790
	[IteratorStateMachine(typeof(_ApplyOpsSequential_d__45))]
	private IEnumerator ApplyOpsSequential(List<MatchOpDTO> ops); // 0x00000001805191A0-0x0000000180519230
	private void ApplyFallOrSpawn(MatchOpDTO op); // 0x00000001805188F0-0x0000000180518970
	[IteratorStateMachine(typeof(_ApplyOp_d__47))]
	private IEnumerator ApplyOp(MatchOpDTO op, float speed, int destroyRound); // 0x00000001805190F0-0x00000001805191A0
	private void ApplySwap(MatchOpDTO op); // 0x000000018051A530-0x000000018051A820
	private void ClearPredictionFlag(GameObject go); // 0x000000018051ADB0-0x000000018051AE50
	private void ApplyHighlight(MatchOpDTO op); // 0x0000000180518BE0-0x0000000180519050
	private int VerifyBoardAgainstServer(BoardCellDTO[][] serverBoard); // 0x0000000180521FB0-0x0000000180522380
	[IteratorStateMachine(typeof(_ApplyDestroySequenced_d__52))]
	private IEnumerator ApplyDestroySequenced(MatchOpDTO op, float speed, int destroyRound); // 0x00000001805187A0-0x0000000180518850
	private static void PlayMatchAudioOncePerTag(List<GameObject> targets, int destroyRound); // 0x000000018051F600-0x000000018051F940
	[IteratorStateMachine(typeof(_ApplyShuffle_d__58))]
	private IEnumerator ApplyShuffle(MatchOpDTO op, float speed); // 0x00000001805194F0-0x0000000180519590
	private static BoardCellDTO[][] ParseShuffleBoard(MatchOpDTO op); // 0x000000018051F2B0-0x000000018051F490
	private static string ReadString(Dictionary<string, object> d, string key, string fb = null); // 0x00000001805201D0-0x0000000180520290
	private void ApplyFall(MatchOpDTO op); // 0x0000000180518970-0x0000000180518BE0
	private void ApplySpawn(MatchOpDTO op); // 0x0000000180519590-0x0000000180519810
	private void ApplyStatChange(MatchOpDTO op); // 0x0000000180519810-0x000000018051A0A0
	private static string ReadReasonPvp(Dictionary<string, object> d); // 0x000000018051FF70-0x0000000180520000
	private static bool IsHealReasonPvp(string reason); // 0x000000018051EC40-0x000000018051EC90
	private void ShowHealPopup(int healedActor, int amount); // 0x0000000180520A70-0x0000000180520BB0
	[IteratorStateMachine(typeof(_HealPopupRoutine_d__68))]
	private IEnumerator HealPopupRoutine(int healedActor, int amount); // 0x000000018051EB10-0x000000018051EBA0
	private void ApplyShieldExpire(MatchOpDTO op); // 0x00000001805192E0-0x00000001805194F0
	private void ApplyStatus(MatchOpDTO op); // 0x000000018051A0A0-0x000000018051A530
	private void HandleFusionResolved(ChatMessageDTO m); // 0x000000018051C350-0x000000018051CB30
	[IteratorStateMachine(typeof(_PlayFusionResultFx_d__72))]
	private IEnumerator PlayFusionResultFx(bool success, bool isLocal, bool actorIsSelfSide, string petName, int ghostPetId, int actor); // 0x000000018051F490-0x000000018051F550
	[IteratorStateMachine(typeof(_RunWithTimeout_d__73))]
	private IEnumerator RunWithTimeout(IEnumerator inner, float timeoutSec); // 0x00000001805208B0-0x0000000180520950
	[IteratorStateMachine(typeof(_RunThenFlag_d__74))]
	private static IEnumerator RunThenFlag(IEnumerator inner, Action onDone); // 0x0000000180520820-0x00000001805208B0
	private CardUIPVP FindFusionCardUI(); // 0x000000018051BDB0-0x000000018051BF90
	[IteratorStateMachine(typeof(_EnsureFusionCardsWhenReady_d__76))]
	private IEnumerator EnsureFusionCardsWhenReady(); // 0x000000018051B690-0x000000018051B700
	private static bool ReadPayloadBoolPvp(Dictionary<string, object> p, string key); // 0x000000018051FDA0-0x000000018051FEC0
	private static int ReadPayloadIntPvp(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x0064BFF4 */); // 0x000000018051FEC0-0x000000018051FF70
	private static bool ReadBoolPvp(Dictionary<string, object> d, string key); // 0x000000018051F940-0x000000018051FA60
	private void MarkCrit(bool atSelf); // 0x000000018051EFF0-0x000000018051F000
	private void FlushPendingCritLabels(); // 0x000000018051BF90-0x000000018051C000
	private void HandleSkillCast(ChatMessageDTO m); // 0x000000018051D9E0-0x000000018051E740
	[IteratorStateMachine(typeof(_ClearMega2HintsAfter_d__85))]
	private IEnumerator ClearMega2HintsAfter(float sec); // 0x000000018051ACB0-0x000000018051AD30
	[IteratorStateMachine(typeof(_ClearGalaxyHintsAfter_d__86))]
	private IEnumerator ClearGalaxyHintsAfter(float sec); // 0x000000018051AC30-0x000000018051ACB0
	[IteratorStateMachine(typeof(_ClearMegaIcarusHintsAfter_d__87))]
	private IEnumerator ClearMegaIcarusHintsAfter(float sec); // 0x000000018051AD30-0x000000018051ADB0
	private static int CountIn(HashSet<Vector2Int> a, HashSet<Vector2Int> b); // 0x000000018051B090-0x000000018051B1C0
	private Vector3 HealCellBoardCenter(); // 0x000000018051E920-0x000000018051EB10
	[IteratorStateMachine(typeof(_ApplyDotConvert_d__95))]
	private IEnumerator ApplyDotConvert(MatchOpDTO op, float speed); // 0x0000000180518850-0x00000001805188F0
	private GameObject DotAt(int col, int row); // 0x000000018051B470-0x000000018051B550
	private static Color ConvertGlowColor(string tag); // 0x000000018051AEE0-0x000000018051B090
	private void SpawnConvertHalo(GameObject host, Color color, float life); // 0x0000000180520BF0-0x0000000180521120
	private void ClearConvertHalos(); // 0x000000018051AAD0-0x000000018051AC30
	[IteratorStateMachine(typeof(_ApplyMegaIcarusMark_d__100))]
	private IEnumerator ApplyMegaIcarusMark(MatchOpDTO op, float speed); // 0x0000000180519050-0x00000001805190F0
	[IteratorStateMachine(typeof(_ApplyCardUse_d__101))]
	private IEnumerator ApplyCardUse(MatchOpDTO op); // 0x0000000180518710-0x00000001805187A0
	private static Sprite LoadCardArtById(int cardId); // 0x000000018051EE60-0x000000018051EFF0
	public static void ResetStaticState(); // 0x00000001805204E0-0x0000000180520550
	internal static void NotifyLocalSkillCardShown(int cardId); // 0x000000018051F000-0x000000018051F070
	private static bool ConsumeLocalSkillCardShown(int cardId); // 0x000000018051AE50-0x000000018051AEE0
	private CardUIPVP FindCardUIByCardId(int cardId); // 0x000000018051BA60-0x000000018051BB50
	private void HandleTurnEnd(); // 0x000000018051E740-0x000000018051E7D0
	private void HandleMatchReject(string reason); // 0x000000018051CDA0-0x000000018051D070
	[IteratorStateMachine(typeof(_PlayInvalidSwapFeedback_d__113))]
	private IEnumerator PlayInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x000000018051F550-0x000000018051F600
	private void ResetDotToActualPosition(int col, int row); // 0x0000000180520390-0x00000001805204E0
	private void HandleGameOver(string winner); // 0x000000018051CB30-0x000000018051CDA0
	private void HandlePlayerLeft(string username, bool isPermanent, string reason); // 0x000000018051D690-0x000000018051D900
	private void HandlePlayerRejoin(string username); // 0x000000018051D900-0x000000018051D9E0
	private void HandleAfkWarn(string username, int idleCount, int threshold); // 0x000000018051C000-0x000000018051C180
	private static void ShowToast(string message); // 0x0000000180520BB0-0x0000000180520BF0
	private bool InBounds(int col, int row); // 0x000000018051EBA0-0x000000018051EC40
	private void UpdateDotPos(GameObject go, int col, int row); // 0x0000000180521ED0-0x0000000180521FB0
	private static double ReadDouble(Dictionary<string, object> d, string key, double fb = 0 /* Metadata: 0x0064BFF5 */); // 0x000000018051FA60-0x000000018051FC80
	private static int ReadInt(Dictionary<string, object> d, string key, int fb = 0 /* Metadata: 0x0064BFFD */); // 0x000000018051FC80-0x000000018051FDA0
}

