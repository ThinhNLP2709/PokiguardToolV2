/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class TreasureWheelSource : IWheelSource // TypeDefIndex: 1539
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
	public bool SupportsBonusClaim { get; } // 0x000000018028A040-0x000000018028A050 
	public long RatesId { get; } // 0x000000018028A410-0x000000018028A420 
	public bool Expired { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808421B0-0x00000001808421C0 0x00000001808421C0-0x00000001808421D0

	// Nested types
	[Serializable]
	private class SpinEnvelope // TypeDefIndex: 1540
	{
		// Fields
		public TreasureWheelSpinData data; // 0x10

		// Constructors
		public SpinEnvelope(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1541
	{
		// Fields
		public TreasureWheelStatusData d; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Load_b__0(TreasureWheelStatusData x); // 0x00000001802D8AB0-0x00000001802D8B10
		internal void _Load_b__1(string e); // 0x00000001802B4F80-0x00000001802B4FE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 1542
	{
		// Fields
		public TreasureWheelSpinData d; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass22_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Spin_b__0(TreasureWheelSpinData x); // 0x00000001802D8AB0-0x00000001802D8B10
		internal void _Spin_b__1(string e); // 0x00000001802B4F80-0x00000001802B4FE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 1543
	{
		// Fields
		public TreasureWheelClaimData d; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ClaimBonus_b__0(TreasureWheelClaimData x); // 0x00000001802D8AB0-0x00000001802D8B10
		internal void _ClaimBonus_b__1(string e); // 0x00000001802B4F80-0x00000001802B4FE0
	}

	[CompilerGenerated]
	private sealed class _ClaimBonus_d__26 : IEnumerator<object> // TypeDefIndex: 1544
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClaimBonus_d__26(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018037B340-0x000000018037B3B0
		private bool MoveNext(); // 0x0000000180843720-0x0000000180843DE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180843DE0-0x0000000180843E20
	}

	[CompilerGenerated]
	private sealed class _Load_d__16 : IEnumerator<object> // TypeDefIndex: 1545
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__16(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180843E20-0x00000001808449A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808449A0-0x00000001808449E0
	}

	[CompilerGenerated]
	private sealed class _Spin_d__22 : IEnumerator<object> // TypeDefIndex: 1546
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Spin_d__22(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x00000001808449E0-0x0000000180845630
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180845630-0x0000000180845670
	}

	// Constructors
	public TreasureWheelSource(); // 0x0000000180843660-0x0000000180843720

	// Methods
	[IteratorStateMachine(typeof(_Load_d__16))]
	public IEnumerator Load(int userId, Action<WheelBoardVM> ok, Action<string> err); // 0x00000001808421D0-0x0000000180842340
	private WheelBoardVM Empty(); // 0x0000000180842340-0x0000000180842570
	private void BuildSlots(WheelBoardVM vm, TreasureWheelPrizeDTO[] prizes); // 0x0000000180842570-0x00000001808429D0
	private void ApplyCounters(WheelBoardVM vm); // 0x00000001808429D0-0x0000000180842BF0
	private long WalletOf(string currency); // 0x0000000180842BF0-0x0000000180842E20
	public bool CanAfford(int count, out string why); // 0x0000000180842E20-0x00000001808430A0
	[IteratorStateMachine(typeof(_Spin_d__22))]
	public IEnumerator Spin(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err); // 0x00000001808430A0-0x0000000180843220
	private static TreasureWheelSpinData TryParseSpinBody(string err); // 0x0000000180843220-0x00000001808432F0
	private void WarnIfSlotMismatch(TreasureWheelSpinResultDTO[] results, int target); // 0x00000001808432F0-0x00000001808434E0
	[IteratorStateMachine(typeof(_ClaimBonus_d__26))]
	public IEnumerator ClaimBonus(int userId, long bonusId, Action<string> ok, Action<string> err); // 0x00000001808434E0-0x0000000180843660
}

