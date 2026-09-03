/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class GalaxyWheelSource : IWheelSource // TypeDefIndex: 930
{
	// Fields
	private GachaBannersData _data; // 0x10
	private GachaBannerDTO _banner; // 0x18
	private readonly Dictionary<int, string> _slotPrizeType; // 0x20
	private string _nonce; // 0x28

	// Properties
	public WheelKind Kind { get; } // 0x0000000180472790-0x00000001804727A0 
	public bool SupportsBonusClaim { get; } // 0x00000001802E7840-0x00000001802E7850 
	public long RatesId { get; } // 0x00000001804727A0-0x00000001804727C0 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 931
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__10_3; // 0x08

		// Constructors
		static __c(); // 0x000000018047A050-0x000000018047A0C0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Load_b__10_3(string e); // 0x0000000180479A60-0x0000000180479AD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass10_0 // TypeDefIndex: 932
	{
		// Fields
		public GachaBannersData data; // 0x10
		public string error; // 0x18
		public GachaRatesData rates; // 0x20

		// Constructors
		public __c__DisplayClass10_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Load_b__0(GachaBannersData d); // 0x00000001803780D0-0x00000001803780E0
		internal void _Load_b__1(string e); // 0x00000001802FAF70-0x00000001802FAF80
		internal void _Load_b__2(GachaRatesData d); // 0x000000018033E830-0x000000018033E840
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 933
	{
		// Fields
		public GachaRollResultData d; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Spin_b__0(GachaRollResultData x); // 0x00000001803780D0-0x00000001803780E0
		internal void _Spin_b__1(string e); // 0x00000001802FAF70-0x00000001802FAF80
	}

	[CompilerGenerated]
	private sealed class _ClaimBonus_d__18 : IEnumerator<object> // TypeDefIndex: 934
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
		public _ClaimBonus_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804763B0-0x0000000180476410
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180476410-0x0000000180476450
	}

	[CompilerGenerated]
	private sealed class _Load_d__10 : IEnumerator<object> // TypeDefIndex: 935
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public Action<string> err; // 0x28
		private __c__DisplayClass10_0 __8__1; // 0x30
		public GalaxyWheelSource __4__this; // 0x38
		public Action<WheelBoardVM> ok; // 0x40
		private WheelBoardVM _vm_5__2; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__10(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804776D0-0x0000000180477710
		private bool MoveNext(); // 0x0000000180476A00-0x0000000180477690
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180477690-0x00000001804776D0
	}

	[CompilerGenerated]
	private sealed class _Spin_d__16 : IEnumerator<object> // TypeDefIndex: 936
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GalaxyWheelSource __4__this; // 0x20
		public Action<string> err; // 0x28
		public int userId; // 0x30
		public int count; // 0x34
		private __c__DisplayClass16_0 __8__1; // 0x38
		public Action<WheelSpinOutcome> ok; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Spin_d__16(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x00000001804783A0-0x0000000180478E70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180478E70-0x0000000180478EB0
	}

	// Constructors
	public GalaxyWheelSource(); // 0x0000000180472710-0x0000000180472790

	// Methods
	[IteratorStateMachine(typeof(_Load_d__10))]
	public IEnumerator Load(int userId, Action<WheelBoardVM> ok, Action<string> err); // 0x00000001804721C0-0x0000000180472280
	private static GachaBannerDTO PickGalaxy(GachaBannersData data); // 0x0000000180472280-0x0000000180472330
	private void BuildSlots(WheelBoardVM vm, GachaRatesData rates); // 0x0000000180471CE0-0x0000000180471FF0
	private void ApplyDailyQuota(WheelBoardVM vm); // 0x0000000180471BC0-0x0000000180471CE0
	private long WalletOf(string currency); // 0x00000001804723F0-0x0000000180472570
	public bool CanAfford(int count, out string why); // 0x0000000180471FF0-0x0000000180472160
	[IteratorStateMachine(typeof(_Spin_d__16))]
	public IEnumerator Spin(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err); // 0x0000000180472330-0x00000001804723F0
	private void WarnIfSlotMismatch(GachaRollItemDTO[] results, int target); // 0x0000000180472570-0x0000000180472710
	[IteratorStateMachine(typeof(_ClaimBonus_d__18))]
	public IEnumerator ClaimBonus(int userId, long bonusId, Action<string> ok, Action<string> err); // 0x0000000180472160-0x00000001804721C0
}

