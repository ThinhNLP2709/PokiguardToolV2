/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class DailyWheelSource : IWheelSource // TypeDefIndex: 1519
{
	// Fields
	private static bool _bulkUnsupported; // 0x00
	private WheelConfigDTO _config; // 0x10
	private int _gold; // 0x18
	private int _freeSpins; // 0x1C
	private int _cost; // 0x20
	private string _nonce; // 0x28

	// Properties
	public bool SupportsBonusClaim { get; } // 0x000000018028A030-0x000000018028A040 
	public long RatesId { get; } // 0x000000018028A410-0x000000018028A420 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass12_0 // TypeDefIndex: 1520
	{
		// Fields
		public WheelConfigDTO cfg; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass12_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Load_b__0(WheelConfigDTO d); // 0x00000001802D8A80-0x00000001802D8AE0
		internal void _Load_b__1(string e); // 0x00000001802B4F80-0x00000001802B4FE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 1521
	{
		// Fields
		public Action<string> err; // 0x10
		public bool retryLegacy; // 0x18

		// Constructors
		public __c__DisplayClass15_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Spin_b__0(string e); // 0x000000018083A8C0-0x000000018083AA30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass17_0 // TypeDefIndex: 1522
	{
		// Fields
		public WheelBulkSpinData data; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass17_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpinBulk_b__0(WheelBulkSpinData d); // 0x00000001802D8A80-0x00000001802D8AE0
		internal void _SpinBulk_b__1(string e); // 0x00000001802B4F80-0x00000001802B4FE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 1523
	{
		// Fields
		public SpinResultDTO res; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass18_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpinSequential_b__0(SpinResultDTO d); // 0x00000001802D8A80-0x00000001802D8AE0
		internal void _SpinSequential_b__1(string e); // 0x00000001802B4F80-0x00000001802B4FE0
	}

	[CompilerGenerated]
	private sealed class _ClaimBonus_d__27 : IEnumerator<object> // TypeDefIndex: 1524
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> err; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClaimBonus_d__27(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018083AA30-0x000000018083AAA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018083AAA0-0x000000018083AAE0
	}

	[CompilerGenerated]
	private sealed class _Load_d__12 : IEnumerator<object> // TypeDefIndex: 1525
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__12(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x000000018083AAE0-0x000000018083B520
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018083B520-0x000000018083B560
	}

	[CompilerGenerated]
	private sealed class _Spin_d__15 : IEnumerator<object> // TypeDefIndex: 1526
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Spin_d__15(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018037B190-0x000000018037B200
		private bool MoveNext(); // 0x000000018083B560-0x000000018083BC20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018083BC20-0x000000018083BC60
	}

	[CompilerGenerated]
	private sealed class _SpinBulk_d__17 : IEnumerator<object> // TypeDefIndex: 1527
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SpinBulk_d__17(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018037B190-0x000000018037B200
		private bool MoveNext(); // 0x000000018083BC60-0x000000018083C5A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018083C5A0-0x000000018083C5E0
	}

	[CompilerGenerated]
	private sealed class _SpinSequential_d__18 : IEnumerator<object> // TypeDefIndex: 1528
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SpinSequential_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018083C5E0-0x000000018083C6F0
		private bool MoveNext(); // 0x000000018083C6F0-0x000000018083D370
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018083D370-0x000000018083D3B0
	}

	// Constructors
	public DailyWheelSource(); // 0x000000018083A8B0-0x000000018083A8C0

	// Methods
	[IteratorStateMachine(typeof(_Load_d__12))]
	public IEnumerator Load(int userId, Action<WheelBoardVM> ok, Action<string> err); // 0x0000000180838D20-0x0000000180838E90
	public bool CanAfford(int count, out string why); // 0x0000000180838E90-0x00000001808390D0
	public bool NeedsGold(int count); // 0x00000001808390D0-0x00000001808390E0
	[IteratorStateMachine(typeof(_Spin_d__15))]
	public IEnumerator Spin(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err); // 0x00000001808390E0-0x0000000180839260
	private static bool LooksLikeMissingEndpoint(string e); // 0x0000000180839260-0x0000000180839310
	[IteratorStateMachine(typeof(_SpinBulk_d__17))]
	private IEnumerator SpinBulk(int userId, int count, string mode, Action<WheelSpinOutcome> ok, Action<string> err); // 0x0000000180839310-0x00000001808394E0
	[IteratorStateMachine(typeof(_SpinSequential_d__18))]
	private IEnumerator SpinSequential(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err); // 0x00000001808394E0-0x0000000180839660
	private void Finish(WheelSpinOutcome outcome); // 0x0000000180839660-0x0000000180839920
	private static int BestSlot(List<WheelResultVM> list); // 0x0000000180839920-0x0000000180839A90
	private WheelResultVM Convert(WheelBulkResultDTO r); // 0x0000000180839A90-0x0000000180839D30
	private WheelResultVM Convert(SpinResultDTO r); // 0x0000000180839D30-0x0000000180839FC0
	private WheelResultVM Wrap(SpinRewardDTO daily); // 0x0000000180839FC0-0x000000018083A510
	private long EquipIconOf(int prizeIndex, WeaponDropDTO drop); // 0x000000018083A510-0x000000018083A5C0
	private int SlotOfPrizeIndex(int prizeIndex); // 0x000000018083A5C0-0x000000018083A700
	private int WeaponImageOf(int prizeIndex); // 0x000000018083A700-0x000000018083A810
	[IteratorStateMachine(typeof(_ClaimBonus_d__27))]
	public IEnumerator ClaimBonus(int userId, long bonusId, Action<string> ok, Action<string> err); // 0x000000018083A810-0x000000018083A8B0
}

