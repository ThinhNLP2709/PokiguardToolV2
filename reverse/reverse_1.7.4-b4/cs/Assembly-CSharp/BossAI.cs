/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	internal static BossAI Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180467EE0-0x0000000180467F20 0x0000000180467F20-0x0000000180467FC0
	public static int LastSavedDamage { get; } // 0x00000001804681B0-0x0000000180468200 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 65
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__23_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180469C80-0x0000000180469D20
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
		internal void _SubmitBossDamage_b__0(); // 0x0000000180308BD0-0x0000000180308BE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass14_1 // TypeDefIndex: 67
	{
		// Fields
		public int retry; // 0x10

		// Constructors
		public __c__DisplayClass14_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SubmitBossDamage_b__1(string err); // 0x0000000180469D20-0x0000000180469E00
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
		internal void _InitializeBossTime_b__0(List<WorldBossDTO> bossList); // 0x0000000180469E00-0x000000018046A540
		internal bool _InitializeBossTime_b__2(WorldBossDTO b); // 0x000000018046A540-0x000000018046A560
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018046A560-0x000000018046A7F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018046A7F0-0x000000018046A830
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018046A830-0x000000018046ACC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018046ACC0-0x000000018046AD00
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
		private bool MoveNext(); // 0x000000018046AD00-0x000000018046B140
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018046B140-0x000000018046B180
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018046B180-0x000000018046B1B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018046B1B0-0x000000018046B1F0
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
		void IDisposable.Dispose(); // 0x000000018046B1F0-0x000000018046B2B0
		private bool MoveNext(); // 0x000000018046B2B0-0x000000018046B950
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018046B950-0x000000018046B990
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018046B990-0x000000018046B9A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018046B9A0-0x000000018046B9E0
	}

	// Constructors
	public BossAI(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180467FC0-0x00000001804681B0
	private void Start(); // 0x0000000180468200-0x0000000180468390
	public void ResetCheckpoint(); // 0x0000000180468390-0x00000001804683A0
	[IteratorStateMachine(typeof(_TrySaveCheckpointDamage_d__12))]
	private IEnumerator TrySaveCheckpointDamage(); // 0x00000001804683A0-0x00000001804683E0
	public bool IsBossTurn(); // 0x00000001804683E0-0x0000000180468420
	[IteratorStateMachine(typeof(_SubmitBossDamage_d__14))]
	public IEnumerator SubmitBossDamage(bool playerWon, int turnCount); // 0x0000000180468420-0x00000001804684E0
	internal int CountBossSetupPotential(string[,] boards); // 0x00000001804684E0-0x0000000180468850
	private void ReturnFromBossTimeout(); // 0x0000000180468850-0x0000000180468AA0
	private void ShowBossTimeoutPopup(); // 0x0000000180468AA0-0x0000000180469170
	[IteratorStateMachine(typeof(_AutoReturnFromBossTimeout_d__19))]
	private IEnumerator AutoReturnFromBossTimeout(float delay); // 0x0000000180469170-0x0000000180469230
	private void StartBossCountdown(); // 0x0000000180469230-0x00000001804693F0
	private void OnBossTimeoutConfirm(); // 0x00000001804693F0-0x0000000180469650
	internal void StopBossCountdown(); // 0x0000000180469650-0x00000001804696E0
	[IteratorStateMachine(typeof(_InitializeBossTime_d__23))]
	internal IEnumerator InitializeBossTime(); // 0x00000001804696E0-0x0000000180469780
	internal static DateTime GetServerAdjustedNow(Board b); // 0x0000000180469780-0x00000001804698E0
	internal static DateTime GetEffectiveBossEndTime(Board b); // 0x00000001804698E0-0x0000000180469910
	[IteratorStateMachine(typeof(_BossCountdownCoroutine_d__26))]
	private IEnumerator BossCountdownCoroutine(); // 0x0000000180469910-0x00000001804699B0
	private void FreezeBoardOnTimeout(); // 0x00000001804699B0-0x0000000180469B50
	[IteratorStateMachine(typeof(_SaveDamageAndShowTimeout_d__28))]
	private IEnumerator SaveDamageAndShowTimeout(); // 0x0000000180469B50-0x0000000180469BF0
	[CompilerGenerated]
	private void _OnBossTimeoutConfirm_b__21_0(); // 0x0000000180469BF0-0x0000000180469C80
}

