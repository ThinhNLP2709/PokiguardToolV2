/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class BossAI : MonoBehaviour // TypeDefIndex: 54
{
	// Fields
	[CompilerGenerated]
	private static BossAI _Instance_k__BackingField; // 0x00
	internal Board board; // 0x20
	internal Active active; // 0x28
	private int _lastSavedDamage; // 0x30
	private bool _autoReturning; // 0x34

	// Properties
	internal static BossAI Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FDE70-0x00000001802FDEB0 0x00000001802FDF00-0x00000001802FDF60
	public static int LastSavedDamage { get; } // 0x00000001802FDEB0-0x00000001802FDF00 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 55
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__23_1; // 0x08

		// Constructors
		static __c(); // 0x000000018030FA70-0x000000018030FAE0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _InitializeBossTime_b__23_1(string error); // 0x00000001802E76C0-0x00000001802E76D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 56
	{
		// Fields
		public bool success; // 0x10
		public Action __9__0; // 0x18

		// Constructors
		public __c__DisplayClass14_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SubmitBossDamage_b__0(); // 0x000000018030F220-0x000000018030F230
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass14_1 // TypeDefIndex: 57
	{
		// Fields
		public int retry; // 0x10

		// Constructors
		public __c__DisplayClass14_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SubmitBossDamage_b__1(string err); // 0x000000018030F230-0x000000018030F2D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 58
	{
		// Fields
		public long bossScheduleId; // 0x10
		public BossAI __4__this; // 0x18
		public bool success; // 0x20
		public Predicate<WorldBossDTO> __9__2; // 0x28

		// Constructors
		public __c__DisplayClass23_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _InitializeBossTime_b__0(List<WorldBossDTO> bossList); // 0x000000018030F320-0x000000018030F920
		internal bool _InitializeBossTime_b__2(WorldBossDTO b); // 0x000000018030F920-0x000000018030F940
	}

	[CompilerGenerated]
	private sealed class _AutoReturnFromBossTimeout_d__19 : IEnumerator<object> // TypeDefIndex: 59
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossAI __4__this; // 0x20
		public float delay; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AutoReturnFromBossTimeout_d__19(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018030DAA0-0x000000018030DD50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018030DD50-0x000000018030DD90
	}

	[CompilerGenerated]
	private sealed class _BossCountdownCoroutine_d__26 : IEnumerator<object> // TypeDefIndex: 60
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossAI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _BossCountdownCoroutine_d__26(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018030DD90-0x000000018030E140
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018030E140-0x000000018030E180
	}

	[CompilerGenerated]
	private sealed class _InitializeBossTime_d__23 : IEnumerator<object> // TypeDefIndex: 61
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossAI __4__this; // 0x20
		private __c__DisplayClass23_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _InitializeBossTime_d__23(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018030E340-0x000000018030E640
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018030E640-0x000000018030E680
	}

	[CompilerGenerated]
	private sealed class _SaveDamageAndShowTimeout_d__28 : IEnumerator<object> // TypeDefIndex: 62
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossAI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SaveDamageAndShowTimeout_d__28(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018030EA30-0x000000018030EA60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018030EA60-0x000000018030EAA0
	}

	[CompilerGenerated]
	private sealed class _SubmitBossDamage_d__14 : IEnumerator<object> // TypeDefIndex: 63
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SubmitBossDamage_d__14(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018030EF30-0x000000018030EF70
		private bool MoveNext(); // 0x000000018030EAA0-0x000000018030EEF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018030EEF0-0x000000018030EF30
	}

	[CompilerGenerated]
	private sealed class _TrySaveCheckpointDamage_d__12 : IEnumerator<object> // TypeDefIndex: 64
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _TrySaveCheckpointDamage_d__12(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018030EF70-0x000000018030EF80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018030EF80-0x000000018030EFC0
	}

	// Constructors
	public BossAI(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x00000001802FCBC0-0x00000001802FCCA0
	private void Start(); // 0x00000001802FDBD0-0x00000001802FDCF0
	public void ResetCheckpoint(); // 0x00000001802FD4B0-0x00000001802FD4C0
	[IteratorStateMachine(typeof(_TrySaveCheckpointDamage_d__12))]
	private IEnumerator TrySaveCheckpointDamage(); // 0x00000001802FDDE0-0x00000001802FDE30
	public bool IsBossTurn(); // 0x00000001802FD2F0-0x00000001802FD330
	[IteratorStateMachine(typeof(_SubmitBossDamage_d__14))]
	public IEnumerator SubmitBossDamage(bool playerWon, int turnCount); // 0x00000001802FDD50-0x00000001802FDDE0
	internal int CountBossSetupPotential(string[,] boards); // 0x00000001802FCD10-0x00000001802FD070
	private void ReturnFromBossTimeout(); // 0x00000001802FD4C0-0x00000001802FD640
	private void ShowBossTimeoutPopup(); // 0x00000001802FD6B0-0x00000001802FDAE0
	[IteratorStateMachine(typeof(_AutoReturnFromBossTimeout_d__19))]
	private IEnumerator AutoReturnFromBossTimeout(float delay); // 0x00000001802FCB40-0x00000001802FCBC0
	private void StartBossCountdown(); // 0x00000001802FDAE0-0x00000001802FDBD0
	private void OnBossTimeoutConfirm(); // 0x00000001802FD330-0x00000001802FD4B0
	internal void StopBossCountdown(); // 0x00000001802FDCF0-0x00000001802FDD50
	[IteratorStateMachine(typeof(_InitializeBossTime_d__23))]
	internal IEnumerator InitializeBossTime(); // 0x00000001802FD280-0x00000001802FD2F0
	internal static DateTime GetServerAdjustedNow(Board b); // 0x00000001802FD1B0-0x00000001802FD280
	internal static DateTime GetEffectiveBossEndTime(Board b); // 0x00000001802FD180-0x00000001802FD1B0
	[IteratorStateMachine(typeof(_BossCountdownCoroutine_d__26))]
	private IEnumerator BossCountdownCoroutine(); // 0x00000001802FCCA0-0x00000001802FCD10
	private void FreezeBoardOnTimeout(); // 0x00000001802FD070-0x00000001802FD180
	[IteratorStateMachine(typeof(_SaveDamageAndShowTimeout_d__28))]
	private IEnumerator SaveDamageAndShowTimeout(); // 0x00000001802FD640-0x00000001802FD6B0
	[CompilerGenerated]
	private void _OnBossTimeoutConfirm_b__21_0(); // 0x00000001802FDE30-0x00000001802FDE70
}

