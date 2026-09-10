/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GalaxyWheelSource : IWheelSource // TypeDefIndex: 1124
{
	// Fields
	private GachaBannersData _data; // 0x10
	private GachaBannerDTO _banner; // 0x18
	private readonly Dictionary<int, string> _slotPrizeType; // 0x20
	private string _nonce; // 0x28

	// Properties
	public WheelKind Kind { get; } // 0x0000000180542810-0x0000000180542820 
	public bool SupportsBonusClaim { get; } // 0x00000001802EB840-0x00000001802EB850 
	public long RatesId { get; } // 0x0000000180542820-0x0000000180542840 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1125
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__10_3; // 0x08

		// Constructors
		static __c(); // 0x000000018054B4E0-0x000000018054B550
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Load_b__10_3(string e); // 0x000000018054A960-0x000000018054A9D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass10_0 // TypeDefIndex: 1126
	{
		// Fields
		public GachaBannersData data; // 0x10
		public string error; // 0x18
		public GachaRatesData rates; // 0x20

		// Constructors
		public __c__DisplayClass10_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Load_b__0(GachaBannersData d); // 0x0000000180317090-0x00000001803170A0
		internal void _Load_b__1(string e); // 0x0000000180317080-0x0000000180317090
		internal void _Load_b__2(GachaRatesData d); // 0x0000000180308AD0-0x0000000180308AE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1127
	{
		// Fields
		public GachaRollResultData d; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Spin_b__0(GachaRollResultData x); // 0x0000000180317090-0x00000001803170A0
		internal void _Spin_b__1(string e); // 0x0000000180317080-0x0000000180317090
	}

	[CompilerGenerated]
	private sealed class _ClaimBonus_d__18 : IEnumerator<object> // TypeDefIndex: 1128
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
		public _ClaimBonus_d__18(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180546A20-0x0000000180546A80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180546A80-0x0000000180546AC0
	}

	[CompilerGenerated]
	private sealed class _Load_d__10 : IEnumerator<object> // TypeDefIndex: 1129
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__10(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180547A40-0x0000000180547A80
		private bool MoveNext(); // 0x0000000180546E40-0x0000000180547A00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180547A00-0x0000000180547A40
	}

	[CompilerGenerated]
	private sealed class _Spin_d__16 : IEnumerator<object> // TypeDefIndex: 1130
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Spin_d__16(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x00000001805495D0-0x000000018054A020
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054A020-0x000000018054A060
	}

	// Constructors
	public GalaxyWheelSource(); // 0x0000000180542790-0x0000000180542810

	// Methods
	[IteratorStateMachine(typeof(_Load_d__10))]
	public IEnumerator Load(int userId, Action<WheelBoardVM> ok, Action<string> err); // 0x0000000180542240-0x0000000180542300
	private static GachaBannerDTO PickGalaxy(GachaBannersData data); // 0x0000000180542300-0x00000001805423B0
	private void BuildSlots(WheelBoardVM vm, GachaRatesData rates); // 0x0000000180541D60-0x0000000180542070
	private void ApplyDailyQuota(WheelBoardVM vm); // 0x0000000180541C40-0x0000000180541D60
	private long WalletOf(string currency); // 0x0000000180542470-0x00000001805425F0
	public bool CanAfford(int count, out string why); // 0x0000000180542070-0x00000001805421E0
	[IteratorStateMachine(typeof(_Spin_d__16))]
	public IEnumerator Spin(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err); // 0x00000001805423B0-0x0000000180542470
	private void WarnIfSlotMismatch(GachaRollItemDTO[] results, int target); // 0x00000001805425F0-0x0000000180542790
	[IteratorStateMachine(typeof(_ClaimBonus_d__18))]
	public IEnumerator ClaimBonus(int userId, long bonusId, Action<string> ok, Action<string> err); // 0x00000001805421E0-0x0000000180542240
}

