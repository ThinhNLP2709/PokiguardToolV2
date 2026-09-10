/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class DailyWheelSource : IWheelSource // TypeDefIndex: 1114
{
	// Fields
	private static bool _bulkUnsupported; // 0x00
	private WheelConfigDTO _config; // 0x10
	private int _gold; // 0x18
	private int _freeSpins; // 0x1C
	private int _cost; // 0x20
	private string _nonce; // 0x28

	// Properties
	public WheelKind Kind { get; } // 0x00000001802EB860-0x00000001802EB870 
	public bool SupportsBonusClaim { get; } // 0x00000001802EB840-0x00000001802EB850 
	public long RatesId { get; } // 0x00000001802EB860-0x00000001802EB870 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass12_0 // TypeDefIndex: 1115
	{
		// Fields
		public WheelConfigDTO cfg; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass12_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Load_b__0(WheelConfigDTO d); // 0x0000000180317090-0x00000001803170A0
		internal void _Load_b__1(string e); // 0x0000000180317080-0x0000000180317090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 1116
	{
		// Fields
		public Action<string> err; // 0x10
		public bool retryLegacy; // 0x18

		// Constructors
		public __c__DisplayClass15_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Spin_b__0(string e); // 0x000000018054A9D0-0x000000018054AB20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass17_0 // TypeDefIndex: 1117
	{
		// Fields
		public WheelBulkSpinData data; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass17_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SpinBulk_b__0(WheelBulkSpinData d); // 0x0000000180317090-0x00000001803170A0
		internal void _SpinBulk_b__1(string e); // 0x0000000180317080-0x0000000180317090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 1118
	{
		// Fields
		public SpinResultDTO res; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass18_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SpinSequential_b__0(SpinResultDTO d); // 0x0000000180317090-0x00000001803170A0
		internal void _SpinSequential_b__1(string e); // 0x0000000180317080-0x0000000180317090
	}

	[CompilerGenerated]
	private sealed class _ClaimBonus_d__27 : IEnumerator<object> // TypeDefIndex: 1119
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> err; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClaimBonus_d__27(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180546AC0-0x0000000180546B20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180546B20-0x0000000180546B60
	}

	[CompilerGenerated]
	private sealed class _Load_d__12 : IEnumerator<object> // TypeDefIndex: 1120
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public Action<string> err; // 0x28
		private __c__DisplayClass12_0 __8__1; // 0x30
		public DailyWheelSource __4__this; // 0x38
		public Action<WheelBoardVM> ok; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__12(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180547A80-0x0000000180548250
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180548250-0x0000000180548290
	}

	[CompilerGenerated]
	private sealed class _Spin_d__15 : IEnumerator<object> // TypeDefIndex: 1121
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> err; // 0x20
		public int userId; // 0x28
		public int count; // 0x2C
		public DailyWheelSource __4__this; // 0x30
		public Action<WheelSpinOutcome> ok; // 0x38
		private __c__DisplayClass15_0 __8__1; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Spin_d__15(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180372850-0x0000000180372880
		private bool MoveNext(); // 0x00000001805491D0-0x0000000180549590
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180549590-0x00000001805495D0
	}

	[CompilerGenerated]
	private sealed class _SpinBulk_d__17 : IEnumerator<object> // TypeDefIndex: 1122
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string mode; // 0x20
		public int count; // 0x28
		public DailyWheelSource __4__this; // 0x30
		public int userId; // 0x38
		private __c__DisplayClass17_0 __8__1; // 0x40
		public Action<string> err; // 0x48
		public Action<WheelSpinOutcome> ok; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SpinBulk_d__17(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180372850-0x0000000180372880
		private bool MoveNext(); // 0x00000001805483F0-0x00000001805489C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805489C0-0x0000000180548A00
	}

	[CompilerGenerated]
	private sealed class _SpinSequential_d__18 : IEnumerator<object> // TypeDefIndex: 1123
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public DailyWheelSource __4__this; // 0x20
		public int userId; // 0x28
		private __c__DisplayClass18_0 __8__1; // 0x30
		public int count; // 0x38
		public Action<string> err; // 0x40
		public Action<WheelSpinOutcome> ok; // 0x48
		private WheelSpinOutcome _outcome_5__2; // 0x50
		private string _lastError_5__3; // 0x58
		private long _lastT_5__4; // 0x60
		private int _i_5__5; // 0x68
		private bool _useFree_5__6; // 0x6C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SpinSequential_d__18(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180549180-0x00000001805491D0
		private bool MoveNext(); // 0x0000000180548A00-0x0000000180549140
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180549140-0x0000000180549180
	}

	// Constructors
	public DailyWheelSource(); // 0x0000000180541C30-0x0000000180541C40

	// Methods
	[IteratorStateMachine(typeof(_Load_d__12))]
	public IEnumerator Load(int userId, Action<WheelBoardVM> ok, Action<string> err); // 0x00000001805413B0-0x0000000180541470
	public bool CanAfford(int count, out string why); // 0x0000000180540CB0-0x0000000180540E60
	public bool NeedsGold(int count); // 0x0000000180541520-0x0000000180541530
	[IteratorStateMachine(typeof(_Spin_d__15))]
	public IEnumerator Spin(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err); // 0x00000001805417C0-0x0000000180541880
	private static bool LooksLikeMissingEndpoint(string e); // 0x0000000180541470-0x0000000180541520
	[IteratorStateMachine(typeof(_SpinBulk_d__17))]
	private IEnumerator SpinBulk(int userId, int count, string mode, Action<WheelSpinOutcome> ok, Action<string> err); // 0x0000000180541630-0x0000000180541700
	[IteratorStateMachine(typeof(_SpinSequential_d__18))]
	private IEnumerator SpinSequential(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err); // 0x0000000180541700-0x00000001805417C0
	private void Finish(WheelSpinOutcome outcome); // 0x00000001805411E0-0x00000001805413B0
	private static int BestSlot(List<WheelResultVM> list); // 0x0000000180540BC0-0x0000000180540CB0
	private WheelResultVM Convert(WheelBulkResultDTO r); // 0x0000000180540FE0-0x0000000180541120
	private WheelResultVM Convert(SpinResultDTO r); // 0x0000000180540EC0-0x0000000180540FE0
	private WheelResultVM Wrap(SpinRewardDTO daily); // 0x0000000180541980-0x0000000180541C30
	private long EquipIconOf(int prizeIndex, WeaponDropDTO drop); // 0x0000000180541120-0x00000001805411E0
	private int SlotOfPrizeIndex(int prizeIndex); // 0x0000000180541530-0x0000000180541630
	private int WeaponImageOf(int prizeIndex); // 0x0000000180541880-0x0000000180541980
	[IteratorStateMachine(typeof(_ClaimBonus_d__27))]
	public IEnumerator ClaimBonus(int userId, long bonusId, Action<string> ok, Action<string> err); // 0x0000000180540E60-0x0000000180540EC0
}

