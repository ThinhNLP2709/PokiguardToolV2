/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class DailyWheelSource : IWheelSource // TypeDefIndex: 920
{
	// Fields
	private static bool _bulkUnsupported; // 0x00
	private WheelConfigDTO _config; // 0x10
	private int _gold; // 0x18
	private int _freeSpins; // 0x1C
	private int _cost; // 0x20
	private string _nonce; // 0x28

	// Properties
	public WheelKind Kind { get; } // 0x00000001802E7860-0x00000001802E7870 
	public bool SupportsBonusClaim { get; } // 0x00000001802E7840-0x00000001802E7850 
	public long RatesId { get; } // 0x00000001802E7860-0x00000001802E7870 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass12_0 // TypeDefIndex: 921
	{
		// Fields
		public WheelConfigDTO cfg; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass12_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Load_b__0(WheelConfigDTO d); // 0x00000001803780D0-0x00000001803780E0
		internal void _Load_b__1(string e); // 0x00000001802FAF70-0x00000001802FAF80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 922
	{
		// Fields
		public Action<string> err; // 0x10
		public bool retryLegacy; // 0x18

		// Constructors
		public __c__DisplayClass15_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Spin_b__0(string e); // 0x0000000180457FA0-0x00000001804580F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass17_0 // TypeDefIndex: 923
	{
		// Fields
		public WheelBulkSpinData data; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass17_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SpinBulk_b__0(WheelBulkSpinData d); // 0x00000001803780D0-0x00000001803780E0
		internal void _SpinBulk_b__1(string e); // 0x00000001802FAF70-0x00000001802FAF80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 924
	{
		// Fields
		public SpinResultDTO res; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass18_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SpinSequential_b__0(SpinResultDTO d); // 0x00000001803780D0-0x00000001803780E0
		internal void _SpinSequential_b__1(string e); // 0x00000001802FAF70-0x00000001802FAF80
	}

	[CompilerGenerated]
	private sealed class _ClaimBonus_d__26 : IEnumerator<object> // TypeDefIndex: 925
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> err; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClaimBonus_d__26(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180454FF0-0x0000000180455050
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180455050-0x0000000180455090
	}

	[CompilerGenerated]
	private sealed class _Load_d__12 : IEnumerator<object> // TypeDefIndex: 926
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__12(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x0000000180455930-0x0000000180455ED0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180455ED0-0x0000000180455F10
	}

	[CompilerGenerated]
	private sealed class _Spin_d__15 : IEnumerator<object> // TypeDefIndex: 927
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Spin_d__15(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018032E010-0x000000018032E040
		private bool MoveNext(); // 0x0000000180457020-0x00000001804573E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804573E0-0x0000000180457420
	}

	[CompilerGenerated]
	private sealed class _SpinBulk_d__17 : IEnumerator<object> // TypeDefIndex: 928
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SpinBulk_d__17(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018032E010-0x000000018032E040
		private bool MoveNext(); // 0x0000000180456350-0x00000001804568D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804568D0-0x0000000180456910
	}

	[CompilerGenerated]
	private sealed class _SpinSequential_d__18 : IEnumerator<object> // TypeDefIndex: 929
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SpinSequential_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180456FD0-0x0000000180457020
		private bool MoveNext(); // 0x0000000180456910-0x0000000180456F90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180456F90-0x0000000180456FD0
	}

	// Constructors
	public DailyWheelSource(); // 0x0000000180451D70-0x0000000180451D80

	// Methods
	[IteratorStateMachine(typeof(_Load_d__12))]
	public IEnumerator Load(int userId, Action<WheelBoardVM> ok, Action<string> err); // 0x0000000180451500-0x00000001804515C0
	public bool CanAfford(int count, out string why); // 0x0000000180450EF0-0x00000001804510A0
	public bool NeedsGold(int count); // 0x0000000180451670-0x0000000180451680
	[IteratorStateMachine(typeof(_Spin_d__15))]
	public IEnumerator Spin(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err); // 0x0000000180451910-0x00000001804519D0
	private static bool LooksLikeMissingEndpoint(string e); // 0x00000001804515C0-0x0000000180451670
	[IteratorStateMachine(typeof(_SpinBulk_d__17))]
	private IEnumerator SpinBulk(int userId, int count, string mode, Action<WheelSpinOutcome> ok, Action<string> err); // 0x0000000180451780-0x0000000180451850
	[IteratorStateMachine(typeof(_SpinSequential_d__18))]
	private IEnumerator SpinSequential(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err); // 0x0000000180451850-0x0000000180451910
	private void Finish(WheelSpinOutcome outcome); // 0x0000000180451330-0x0000000180451500
	private static int BestSlot(List<WheelResultVM> list); // 0x0000000180450E00-0x0000000180450EF0
	private WheelResultVM Convert(WheelBulkResultDTO r); // 0x0000000180451210-0x0000000180451330
	private WheelResultVM Convert(SpinResultDTO r); // 0x0000000180451100-0x0000000180451210
	private WheelResultVM Wrap(SpinRewardDTO daily); // 0x0000000180451AD0-0x0000000180451D70
	private int SlotOfPrizeIndex(int prizeIndex); // 0x0000000180451680-0x0000000180451780
	private int WeaponImageOf(int prizeIndex); // 0x00000001804519D0-0x0000000180451AD0
	[IteratorStateMachine(typeof(_ClaimBonus_d__26))]
	public IEnumerator ClaimBonus(int userId, long bonusId, Action<string> ok, Action<string> err); // 0x00000001804510A0-0x0000000180451100
}

