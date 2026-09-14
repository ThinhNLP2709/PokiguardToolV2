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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class MonthlyRankingCountdown : MonoBehaviour, IHubSuspendable // TypeDefIndex: 2435
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
	private sealed class __c // TypeDefIndex: 2436
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__18_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180B72980-0x0000000180B72A20
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CheckRewardStatus_b__18_1(string error); // 0x0000000180B72A20-0x0000000180B72AA0
	}

	[CompilerGenerated]
	private sealed class _CheckRewardStatus_d__18 : IEnumerator<object> // TypeDefIndex: 2437
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MonthlyRankingCountdown __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CheckRewardStatus_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B72AA0-0x0000000180B72DB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B72DB0-0x0000000180B72DF0
	}

	[CompilerGenerated]
	private sealed class _HideNotificationAfterDelay_d__20 : IEnumerator<object> // TypeDefIndex: 2438
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public MonthlyRankingCountdown __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HideNotificationAfterDelay_d__20(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B72DF0-0x0000000180B73000
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B73000-0x0000000180B73040
	}

	// Constructors
	public MonthlyRankingCountdown(); // 0x0000000180B72860-0x0000000180B728B0

	// Methods
	private void Start(); // 0x0000000180B714F0-0x0000000180B71530
	private void OnEnable(); // 0x0000000180B71530-0x0000000180B715E0
	private void OnDisable(); // 0x0000000180B715E0-0x0000000180B71640
	private void StartRepeatingTasks(); // 0x0000000180B71640-0x0000000180B71710
	public void OnHubSuspend(); // 0x0000000180B71710-0x0000000180B71720
	public void OnHubResume(); // 0x0000000180B71720-0x0000000180B717B0
	private void CalculateNextMonthStart(); // 0x0000000180B717B0-0x0000000180B71930
	private void UpdateCountdown(); // 0x0000000180B71930-0x0000000180B71FF0
	private string FormatTimeSpan(TimeSpan timeSpan); // 0x0000000180B71FF0-0x0000000180B72420
	private void PeriodicCheckStatus(); // 0x0000000180B72420-0x0000000180B72450
	[IteratorStateMachine(typeof(_CheckRewardStatus_d__18))]
	private IEnumerator CheckRewardStatus(); // 0x0000000180B72450-0x0000000180B724F0
	private void ShowNotification(string message); // 0x0000000180B724F0-0x0000000180B727A0
	[IteratorStateMachine(typeof(_HideNotificationAfterDelay_d__20))]
	private IEnumerator HideNotificationAfterDelay(float delay); // 0x0000000180B727A0-0x0000000180B72860
	[CompilerGenerated]
	private void _CheckRewardStatus_b__18_0(MonthlyRankingStatusResponse response); // 0x0000000180B728B0-0x0000000180B72980
}

