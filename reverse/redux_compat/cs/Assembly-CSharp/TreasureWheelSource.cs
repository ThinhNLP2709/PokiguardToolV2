/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class TreasureWheelSource : IWheelSource // TypeDefIndex: 938
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
	public WheelKind Kind { get; } // 0x0000000180476390-0x00000001804763A0 
	public bool SupportsBonusClaim { get; } // 0x00000001802E7990-0x00000001802E79A0 
	public long RatesId { get; } // 0x00000001802E7860-0x00000001802E7870 
	public bool Expired { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0

	// Nested types
	[Serializable]
	private class SpinEnvelope // TypeDefIndex: 939
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public string code; // 0x20
		public TreasureWheelSpinData data; // 0x28

		// Constructors
		public SpinEnvelope(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 940
	{
		// Fields
		public TreasureWheelStatusData d; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Load_b__0(TreasureWheelStatusData x); // 0x00000001803780D0-0x00000001803780E0
		internal void _Load_b__1(string e); // 0x00000001802FAF70-0x00000001802FAF80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 941
	{
		// Fields
		public TreasureWheelSpinData d; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass22_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Spin_b__0(TreasureWheelSpinData x); // 0x00000001803780D0-0x00000001803780E0
		internal void _Spin_b__1(string e); // 0x00000001802FAF70-0x00000001802FAF80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 942
	{
		// Fields
		public TreasureWheelClaimData d; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass26_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ClaimBonus_b__0(TreasureWheelClaimData x); // 0x00000001803780D0-0x00000001803780E0
		internal void _ClaimBonus_b__1(string e); // 0x00000001802FAF70-0x00000001802FAF80
	}

	[CompilerGenerated]
	private sealed class _ClaimBonus_d__26 : IEnumerator<object> // TypeDefIndex: 943
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClaimBonus_d__26(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018032E010-0x000000018032E040
		private bool MoveNext(); // 0x0000000180476450-0x00000001804769C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804769C0-0x0000000180476A00
	}

	[CompilerGenerated]
	private sealed class _Load_d__16 : IEnumerator<object> // TypeDefIndex: 944
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__16(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x0000000180477710-0x0000000180478090
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180478090-0x00000001804780D0
	}

	[CompilerGenerated]
	private sealed class _Spin_d__22 : IEnumerator<object> // TypeDefIndex: 945
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Spin_d__22(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x0000000180478EB0-0x0000000180479A20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180479A20-0x0000000180479A60
	}

	// Constructors
	public TreasureWheelSource(); // 0x0000000180476300-0x0000000180476380

	// Methods
	[IteratorStateMachine(typeof(_Load_d__16))]
	public IEnumerator Load(int userId, Action<WheelBoardVM> ok, Action<string> err); // 0x0000000180475D90-0x0000000180475E50
	private WheelBoardVM Empty(); // 0x0000000180475CA0-0x0000000180475D90
	private void BuildSlots(WheelBoardVM vm, TreasureWheelPrizeDTO[] prizes); // 0x0000000180475720-0x0000000180475A70
	private void ApplyCounters(WheelBoardVM vm); // 0x00000001804755E0-0x0000000180475720
	private long WalletOf(string currency); // 0x0000000180475FD0-0x0000000180476150
	public bool CanAfford(int count, out string why); // 0x0000000180475A70-0x0000000180475BE0
	[IteratorStateMachine(typeof(_Spin_d__22))]
	public IEnumerator Spin(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err); // 0x0000000180475E50-0x0000000180475F10
	private static TreasureWheelSpinData TryParseSpinBody(string err); // 0x0000000180475F10-0x0000000180475FD0
	private void WarnIfSlotMismatch(TreasureWheelSpinResultDTO[] results, int target); // 0x0000000180476150-0x0000000180476300
	[IteratorStateMachine(typeof(_ClaimBonus_d__26))]
	public IEnumerator ClaimBonus(int userId, long bonusId, Action<string> ok, Action<string> err); // 0x0000000180475BE0-0x0000000180475CA0
}

