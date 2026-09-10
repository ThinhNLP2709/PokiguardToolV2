/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

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
	internal static BossAI Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180417700-0x0000000180417740 0x0000000180417790-0x00000001804177F0
	public static int LastSavedDamage { get; } // 0x0000000180417740-0x0000000180417790 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 65
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__23_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180426020-0x0000000180426090
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _InitializeBossTime_b__23_1(string error); // 0x00000001802EB6C0-0x00000001802EB6D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 66
	{
		// Fields
		public bool success; // 0x10
		public Action __9__0; // 0x18

		// Constructors
		public __c__DisplayClass14_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SubmitBossDamage_b__0(); // 0x000000018034AB40-0x000000018034AB50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass14_1 // TypeDefIndex: 67
	{
		// Fields
		public int retry; // 0x10

		// Constructors
		public __c__DisplayClass14_1(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SubmitBossDamage_b__1(string err); // 0x0000000180425550-0x00000001804255F0
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
		public __c__DisplayClass23_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _InitializeBossTime_b__0(List<WorldBossDTO> bossList); // 0x0000000180425640-0x0000000180425C40
		internal bool _InitializeBossTime_b__2(WorldBossDTO b); // 0x0000000180425C40-0x0000000180425C60
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AutoReturnFromBossTimeout_d__19(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180424340-0x00000001804245F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804245F0-0x0000000180424630
	}

	[CompilerGenerated]
	private sealed class _BossCountdownCoroutine_d__26 : IEnumerator<object> // TypeDefIndex: 70
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossAI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BossCountdownCoroutine_d__26(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180424630-0x00000001804249E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804249E0-0x0000000180424A20
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _InitializeBossTime_d__23(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180424A20-0x0000000180424D20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180424D20-0x0000000180424D60
	}

	[CompilerGenerated]
	private sealed class _SaveDamageAndShowTimeout_d__28 : IEnumerator<object> // TypeDefIndex: 72
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossAI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SaveDamageAndShowTimeout_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180424D60-0x0000000180424D90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180424D90-0x0000000180424DD0
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SubmitBossDamage_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180425260-0x00000001804252A0
		private bool MoveNext(); // 0x0000000180424DD0-0x0000000180425220
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180425220-0x0000000180425260
	}

	[CompilerGenerated]
	private sealed class _TrySaveCheckpointDamage_d__12 : IEnumerator<object> // TypeDefIndex: 74
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _TrySaveCheckpointDamage_d__12(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804252A0-0x00000001804252B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804252B0-0x00000001804252F0
	}

	// Constructors
	public BossAI(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180416450-0x0000000180416530
	private void Start(); // 0x0000000180417460-0x0000000180417580
	public void ResetCheckpoint(); // 0x0000000180416D40-0x0000000180416D50
	[IteratorStateMachine(typeof(_TrySaveCheckpointDamage_d__12))]
	private IEnumerator TrySaveCheckpointDamage(); // 0x0000000180417670-0x00000001804176C0
	public bool IsBossTurn(); // 0x0000000180416B80-0x0000000180416BC0
	[IteratorStateMachine(typeof(_SubmitBossDamage_d__14))]
	public IEnumerator SubmitBossDamage(bool playerWon, int turnCount); // 0x00000001804175E0-0x0000000180417670
	internal int CountBossSetupPotential(string[,] boards); // 0x00000001804165A0-0x0000000180416900
	private void ReturnFromBossTimeout(); // 0x0000000180416D50-0x0000000180416ED0
	private void ShowBossTimeoutPopup(); // 0x0000000180416F40-0x0000000180417370
	[IteratorStateMachine(typeof(_AutoReturnFromBossTimeout_d__19))]
	private IEnumerator AutoReturnFromBossTimeout(float delay); // 0x00000001804163D0-0x0000000180416450
	private void StartBossCountdown(); // 0x0000000180417370-0x0000000180417460
	private void OnBossTimeoutConfirm(); // 0x0000000180416BC0-0x0000000180416D40
	internal void StopBossCountdown(); // 0x0000000180417580-0x00000001804175E0
	[IteratorStateMachine(typeof(_InitializeBossTime_d__23))]
	internal IEnumerator InitializeBossTime(); // 0x0000000180416B10-0x0000000180416B80
	internal static DateTime GetServerAdjustedNow(Board b); // 0x0000000180416A40-0x0000000180416B10
	internal static DateTime GetEffectiveBossEndTime(Board b); // 0x0000000180416A10-0x0000000180416A40
	[IteratorStateMachine(typeof(_BossCountdownCoroutine_d__26))]
	private IEnumerator BossCountdownCoroutine(); // 0x0000000180416530-0x00000001804165A0
	private void FreezeBoardOnTimeout(); // 0x0000000180416900-0x0000000180416A10
	[IteratorStateMachine(typeof(_SaveDamageAndShowTimeout_d__28))]
	private IEnumerator SaveDamageAndShowTimeout(); // 0x0000000180416ED0-0x0000000180416F40
	[CompilerGenerated]
	private void _OnBossTimeoutConfirm_b__21_0(); // 0x00000001804176C0-0x0000000180417700
}

