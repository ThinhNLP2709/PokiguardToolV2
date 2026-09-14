/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class BossAI : MonoBehaviour // TypeDefIndex: 64
{
	// Fields
	[CompilerGenerated]
	private static BossAI _Instance_k__BackingField; // 0x00
	internal Board board; // 0x20
	internal Active active; // 0x28
	private int _lastSavedDamage; // 0x30
	private bool _autoReturning; // 0x34

	// Properties
	internal static BossAI Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180466C70-0x0000000180466CB0 0x0000000180466CB0-0x0000000180466D50
	public static int LastSavedDamage { get; } // 0x0000000180466F40-0x0000000180466F90 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 65
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__23_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180468A10-0x0000000180468AB0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _InitializeBossTime_b__23_1(string error); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 66
	{
		// Fields
		public bool success; // 0x10
		public Action __9__0; // 0x18

		// Constructors
		public __c__DisplayClass14_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SubmitBossDamage_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass14_1 // TypeDefIndex: 67
	{
		// Fields
		public int retry; // 0x10

		// Constructors
		public __c__DisplayClass14_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SubmitBossDamage_b__1(string err); // 0x0000000180468AB0-0x0000000180468B90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 68
	{
		// Fields
		public long bossScheduleId; // 0x10
		public BossAI __4__this; // 0x18
		public bool success; // 0x20
		public Predicate<WorldBossDTO> __9__2; // 0x28

		// Constructors
		public __c__DisplayClass23_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _InitializeBossTime_b__0(List<WorldBossDTO> bossList); // 0x0000000180468B90-0x00000001804692D0
		internal bool _InitializeBossTime_b__2(WorldBossDTO b); // 0x00000001804692D0-0x00000001804692F0
	}

	[CompilerGenerated]
	private sealed class _AutoReturnFromBossTimeout_d__19 : IEnumerator<object> // TypeDefIndex: 69
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossAI __4__this; // 0x20
		public float delay; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AutoReturnFromBossTimeout_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001804692F0-0x0000000180469580
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180469580-0x00000001804695C0
	}

	[CompilerGenerated]
	private sealed class _BossCountdownCoroutine_d__26 : IEnumerator<object> // TypeDefIndex: 70
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossAI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BossCountdownCoroutine_d__26(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001804695C0-0x0000000180469A50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180469A50-0x0000000180469A90
	}

	[CompilerGenerated]
	private sealed class _InitializeBossTime_d__23 : IEnumerator<object> // TypeDefIndex: 71
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossAI __4__this; // 0x20
		private __c__DisplayClass23_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _InitializeBossTime_d__23(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180469A90-0x0000000180469ED0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180469ED0-0x0000000180469F10
	}

	[CompilerGenerated]
	private sealed class _SaveDamageAndShowTimeout_d__28 : IEnumerator<object> // TypeDefIndex: 72
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossAI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SaveDamageAndShowTimeout_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180469F10-0x0000000180469F40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180469F40-0x0000000180469F80
	}

	[CompilerGenerated]
	private sealed class _SubmitBossDamage_d__14 : IEnumerator<object> // TypeDefIndex: 73
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossAI __4__this; // 0x20
		public bool playerWon; // 0x28
		public int turnCount; // 0x2C
		private __c__DisplayClass14_0 __8__1; // 0x30
		private __c__DisplayClass14_1 __8__2; // 0x38
		private long _bossScheduleId_5__2; // 0x40
		private int _totalDamage_5__3; // 0x48
		private int _maxRetries_5__4; // 0x4C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SubmitBossDamage_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180469F80-0x000000018046A040
		private bool MoveNext(); // 0x000000018046A040-0x000000018046A6E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018046A6E0-0x000000018046A720
	}

	[CompilerGenerated]
	private sealed class _TrySaveCheckpointDamage_d__12 : IEnumerator<object> // TypeDefIndex: 74
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TrySaveCheckpointDamage_d__12(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018046A720-0x000000018046A730
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018046A730-0x000000018046A770
	}

	// Constructors
	public BossAI(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180466D50-0x0000000180466F40
	private void Start(); // 0x0000000180466F90-0x0000000180467120
	public void ResetCheckpoint(); // 0x0000000180467120-0x0000000180467130
	[IteratorStateMachine(typeof(_TrySaveCheckpointDamage_d__12))]
	private IEnumerator TrySaveCheckpointDamage(); // 0x0000000180467130-0x0000000180467170
	public bool IsBossTurn(); // 0x0000000180467170-0x00000001804671B0
	[IteratorStateMachine(typeof(_SubmitBossDamage_d__14))]
	public IEnumerator SubmitBossDamage(bool playerWon, int turnCount); // 0x00000001804671B0-0x0000000180467270
	internal int CountBossSetupPotential(string[,] boards); // 0x0000000180467270-0x00000001804675E0
	private void ReturnFromBossTimeout(); // 0x00000001804675E0-0x0000000180467830
	private void ShowBossTimeoutPopup(); // 0x0000000180467830-0x0000000180467F00
	[IteratorStateMachine(typeof(_AutoReturnFromBossTimeout_d__19))]
	private IEnumerator AutoReturnFromBossTimeout(float delay); // 0x0000000180467F00-0x0000000180467FC0
	private void StartBossCountdown(); // 0x0000000180467FC0-0x0000000180468180
	private void OnBossTimeoutConfirm(); // 0x0000000180468180-0x00000001804683E0
	internal void StopBossCountdown(); // 0x00000001804683E0-0x0000000180468470
	[IteratorStateMachine(typeof(_InitializeBossTime_d__23))]
	internal IEnumerator InitializeBossTime(); // 0x0000000180468470-0x0000000180468510
	internal static DateTime GetServerAdjustedNow(Board b); // 0x0000000180468510-0x0000000180468670
	internal static DateTime GetEffectiveBossEndTime(Board b); // 0x0000000180468670-0x00000001804686A0
	[IteratorStateMachine(typeof(_BossCountdownCoroutine_d__26))]
	private IEnumerator BossCountdownCoroutine(); // 0x00000001804686A0-0x0000000180468740
	private void FreezeBoardOnTimeout(); // 0x0000000180468740-0x00000001804688E0
	[IteratorStateMachine(typeof(_SaveDamageAndShowTimeout_d__28))]
	private IEnumerator SaveDamageAndShowTimeout(); // 0x00000001804688E0-0x0000000180468980
	[CompilerGenerated]
	private void _OnBossTimeoutConfirm_b__21_0(); // 0x0000000180468980-0x0000000180468A10
}

