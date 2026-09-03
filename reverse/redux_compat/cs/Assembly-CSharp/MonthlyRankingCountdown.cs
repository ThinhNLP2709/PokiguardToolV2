/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class MonthlyRankingCountdown : MonoBehaviour, IHubSuspendable // TypeDefIndex: 1760
{
	// Fields
	[Header("UI References")]
	public UnityEngine.UI.Text timeMonthText; // 0x20
	public UnityEngine.UI.Text labelText; // 0x28
	[Header("Settings")]
	public bool showDebugLogs; // 0x30
	public int checkStatusIntervalMinutes; // 0x34
	[Header("Optional: Notification UI")]
	public GameObject notificationPanel; // 0x38
	public UnityEngine.UI.Text notificationText; // 0x40
	private DateTime nextMonthStart; // 0x48
	private bool rewardsSentThisMonth; // 0x50

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1761
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__18_1; // 0x08

		// Constructors
		static __c(); // 0x00000001805FE910-0x00000001805FE980
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CheckRewardStatus_b__18_1(string error); // 0x00000001805FDFF0-0x00000001805FE060
	}

	[CompilerGenerated]
	private sealed class _CheckRewardStatus_d__18 : IEnumerator<object> // TypeDefIndex: 1762
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MonthlyRankingCountdown __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CheckRewardStatus_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805FBCC0-0x00000001805FBEA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805FBEA0-0x00000001805FBEE0
	}

	[CompilerGenerated]
	private sealed class _HideNotificationAfterDelay_d__20 : IEnumerator<object> // TypeDefIndex: 1763
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public MonthlyRankingCountdown __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideNotificationAfterDelay_d__20(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805FC1D0-0x00000001805FC2D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805FC2D0-0x00000001805FC310
	}

	// Constructors
	public MonthlyRankingCountdown(); // 0x00000001805F56F0-0x00000001805F5710

	// Methods
	private void Start(); // 0x00000001805F51D0-0x00000001805F5260
	private void OnEnable(); // 0x00000001805F4E30-0x00000001805F4ED0
	private void OnDisable(); // 0x00000001805F4DD0-0x00000001805F4E30
	private void StartRepeatingTasks(); // 0x00000001805F50C0-0x00000001805F51D0
	public void OnHubSuspend(); // 0x00000001805F4F00-0x00000001805F4F10
	public void OnHubResume(); // 0x00000001805F4ED0-0x00000001805F4F00
	private void CalculateNextMonthStart(); // 0x00000001805F48E0-0x00000001805F49B0
	private void UpdateCountdown(); // 0x00000001805F5400-0x00000001805F56F0
	private string FormatTimeSpan(TimeSpan timeSpan); // 0x00000001805F4A20-0x00000001805F4D50
	private void PeriodicCheckStatus(); // 0x00000001805F4F10-0x00000001805F4F90
	[IteratorStateMachine(typeof(_CheckRewardStatus_d__18))]
	private IEnumerator CheckRewardStatus(); // 0x00000001805F49B0-0x00000001805F4A20
	private void ShowNotification(string message); // 0x00000001805F4F90-0x00000001805F50C0
	[IteratorStateMachine(typeof(_HideNotificationAfterDelay_d__20))]
	private IEnumerator HideNotificationAfterDelay(float delay); // 0x00000001805F4D50-0x00000001805F4DD0
	[CompilerGenerated]
	private void _CheckRewardStatus_b__18_0(MonthlyRankingStatusResponse response); // 0x00000001805F5260-0x00000001805F5400
}

