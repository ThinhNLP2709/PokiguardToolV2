/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class TreasureWheelSource : IWheelSource // TypeDefIndex: 1132
{
	// Fields
	private TreasureWheelStatusData _data; // 0x10
	private TreasureWheelEventDTO _event; // 0x18
	private readonly Dictionary<int, string> _slotPrizeType; // 0x20
	private string _nonce; // 0x28
	private int _totalSpins; // 0x30
	private int _spinsToday; // 0x34
	[CompilerGenerated]
	private bool _Expired_k__BackingField; // 0x38

	// Properties
	public WheelKind Kind { get; } // 0x0000000180546A00-0x0000000180546A10 
	public bool SupportsBonusClaim { get; } // 0x00000001802EB990-0x00000001802EB9A0 
	public long RatesId { get; } // 0x00000001802EB860-0x00000001802EB870 
	public bool Expired { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805469F0-0x0000000180546A00 0x0000000180546A10-0x0000000180546A20

	// Nested types
	[Serializable]
	private class SpinEnvelope // TypeDefIndex: 1133
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public string code; // 0x20
		public TreasureWheelSpinData data; // 0x28

		// Constructors
		public SpinEnvelope(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1134
	{
		// Fields
		public TreasureWheelStatusData d; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Load_b__0(TreasureWheelStatusData x); // 0x0000000180317090-0x00000001803170A0
		internal void _Load_b__1(string e); // 0x0000000180317080-0x0000000180317090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 1135
	{
		// Fields
		public TreasureWheelSpinData d; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass22_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Spin_b__0(TreasureWheelSpinData x); // 0x0000000180317090-0x00000001803170A0
		internal void _Spin_b__1(string e); // 0x0000000180317080-0x0000000180317090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 1136
	{
		// Fields
		public TreasureWheelClaimData d; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass26_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ClaimBonus_b__0(TreasureWheelClaimData x); // 0x0000000180317090-0x00000001803170A0
		internal void _ClaimBonus_b__1(string e); // 0x0000000180317080-0x0000000180317090
	}

	[CompilerGenerated]
	private sealed class _ClaimBonus_d__26 : IEnumerator<object> // TypeDefIndex: 1137
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TreasureWheelSource __4__this; // 0x20
		public long bonusId; // 0x28
		public Action<string> err; // 0x30
		public int userId; // 0x38
		private __c__DisplayClass26_0 __8__1; // 0x40
		public Action<string> ok; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClaimBonus_d__26(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180372850-0x0000000180372880
		private bool MoveNext(); // 0x0000000180561490-0x0000000180561A00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180561A00-0x0000000180561A40
	}

	[CompilerGenerated]
	private sealed class _Load_d__16 : IEnumerator<object> // TypeDefIndex: 1138
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public Action<string> err; // 0x28
		private __c__DisplayClass16_0 __8__1; // 0x30
		public Action<WheelBoardVM> ok; // 0x38
		public TreasureWheelSource __4__this; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__16(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180561A40-0x00000001805620D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805620D0-0x0000000180562110
	}

	[CompilerGenerated]
	private sealed class _Spin_d__22 : IEnumerator<object> // TypeDefIndex: 1139
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TreasureWheelSource __4__this; // 0x20
		public Action<string> err; // 0x28
		public int userId; // 0x30
		public int count; // 0x34
		private __c__DisplayClass22_0 __8__1; // 0x38
		public Action<WheelSpinOutcome> ok; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Spin_d__22(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x00000001805623E0-0x0000000180562FD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180562FD0-0x0000000180563010
	}

	// Constructors
	public TreasureWheelSource(); // 0x0000000180546970-0x00000001805469F0

	// Methods
	[IteratorStateMachine(typeof(_Load_d__16))]
	public IEnumerator Load(int userId, Action<WheelBoardVM> ok, Action<string> err); // 0x0000000180546400-0x00000001805464C0
	private WheelBoardVM Empty(); // 0x0000000180546330-0x0000000180546400
	private void BuildSlots(WheelBoardVM vm, TreasureWheelPrizeDTO[] prizes); // 0x0000000180545BF0-0x0000000180545F80
	private void ApplyCounters(WheelBoardVM vm); // 0x0000000180545AB0-0x0000000180545BF0
	private long WalletOf(string currency); // 0x0000000180546640-0x00000001805467C0
	public bool CanAfford(int count, out string why); // 0x0000000180545F80-0x0000000180546260
	[IteratorStateMachine(typeof(_Spin_d__22))]
	public IEnumerator Spin(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err); // 0x00000001805464C0-0x0000000180546580
	private static TreasureWheelSpinData TryParseSpinBody(string err); // 0x0000000180546580-0x0000000180546640
	private void WarnIfSlotMismatch(TreasureWheelSpinResultDTO[] results, int target); // 0x00000001805467C0-0x0000000180546970
	[IteratorStateMachine(typeof(_ClaimBonus_d__26))]
	public IEnumerator ClaimBonus(int userId, long bonusId, Action<string> ok, Action<string> err); // 0x0000000180546260-0x0000000180546330
}

