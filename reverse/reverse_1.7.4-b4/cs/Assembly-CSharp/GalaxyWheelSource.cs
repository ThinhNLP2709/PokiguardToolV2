/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GalaxyWheelSource : IWheelSource // TypeDefIndex: 1531
{
	// Fields
	private GachaBannersData _data; // 0x10
	private GachaBannerDTO _banner; // 0x18
	private readonly Dictionary<int, string> _slotPrizeType; // 0x20
	private string _nonce; // 0x28

	// Properties
	public bool SupportsBonusClaim { get; } // 0x000000018028A030-0x000000018028A040 
	public long RatesId { get; } // 0x000000018083F570-0x000000018083F590 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1532
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__10_3; // 0x08

		// Constructors
		static __c(); // 0x0000000180840650-0x00000001808406F0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Load_b__10_3(string e); // 0x00000001808406F0-0x0000000180840770
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass10_0 // TypeDefIndex: 1533
	{
		// Fields
		public GachaBannersData data; // 0x10
		public string error; // 0x18
		public GachaRatesData rates; // 0x20

		// Constructors
		public __c__DisplayClass10_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Load_b__0(GachaBannersData d); // 0x00000001802D8AB0-0x00000001802D8B10
		internal void _Load_b__1(string e); // 0x00000001802B4F80-0x00000001802B4FE0
		internal void _Load_b__2(GachaRatesData d); // 0x00000001802B4BC0-0x00000001802B4C20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1534
	{
		// Fields
		public GachaRollResultData d; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Spin_b__0(GachaRollResultData x); // 0x00000001802D8AB0-0x00000001802D8B10
		internal void _Spin_b__1(string e); // 0x00000001802B4F80-0x00000001802B4FE0
	}

	[CompilerGenerated]
	private sealed class _ClaimBonus_d__18 : IEnumerator<object> // TypeDefIndex: 1535
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
		public _ClaimBonus_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180840770-0x00000001808407E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808407E0-0x0000000180840820
	}

	[CompilerGenerated]
	private sealed class _Load_d__10 : IEnumerator<object> // TypeDefIndex: 1536
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__10(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180840820-0x00000001808408E0
		private bool MoveNext(); // 0x00000001808408E0-0x0000000180841730
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180841730-0x0000000180841770
	}

	[CompilerGenerated]
	private sealed class _Spin_d__16 : IEnumerator<object> // TypeDefIndex: 1537
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Spin_d__16(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180841770-0x0000000180842170
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180842170-0x00000001808421B0
	}

	// Constructors
	public GalaxyWheelSource(); // 0x0000000180840590-0x0000000180840650

	// Methods
	[IteratorStateMachine(typeof(_Load_d__10))]
	public IEnumerator Load(int userId, Action<WheelBoardVM> ok, Action<string> err); // 0x000000018083F590-0x000000018083F700
	private static GachaBannerDTO PickGalaxy(GachaBannersData data); // 0x000000018083F700-0x000000018083F7D0
	private void BuildSlots(WheelBoardVM vm, GachaRatesData rates); // 0x000000018083F7D0-0x000000018083FB40
	private void ApplyDailyQuota(WheelBoardVM vm); // 0x000000018083FB40-0x000000018083FD40
	private long WalletOf(string currency); // 0x000000018083FD40-0x000000018083FF70
	public bool CanAfford(int count, out string why); // 0x000000018083FF70-0x0000000180840190
	[IteratorStateMachine(typeof(_Spin_d__16))]
	public IEnumerator Spin(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err); // 0x0000000180840190-0x0000000180840310
	private void WarnIfSlotMismatch(GachaRollItemDTO[] results, int target); // 0x0000000180840310-0x00000001808404F0
	[IteratorStateMachine(typeof(_ClaimBonus_d__18))]
	public IEnumerator ClaimBonus(int userId, long bonusId, Action<string> ok, Action<string> err); // 0x00000001808404F0-0x0000000180840590
}

