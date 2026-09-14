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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class MonthlyRankingCountdown : MonoBehaviour, IHubSuspendable // TypeDefIndex: 2442
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
	private sealed class __c // TypeDefIndex: 2443
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__18_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180B7FCB0-0x0000000180B7FD50
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CheckRewardStatus_b__18_1(string error); // 0x0000000180B7FD50-0x0000000180B7FDD0
	}

	[CompilerGenerated]
	private sealed class _CheckRewardStatus_d__18 : IEnumerator<object> // TypeDefIndex: 2444
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B7FDD0-0x0000000180B80110
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B80110-0x0000000180B80150
	}

	[CompilerGenerated]
	private sealed class _HideNotificationAfterDelay_d__20 : IEnumerator<object> // TypeDefIndex: 2445
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B80150-0x0000000180B80360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B80360-0x0000000180B803A0
	}

	// Constructors
	public MonthlyRankingCountdown(); // 0x0000000180B7FB90-0x0000000180B7FBE0

	// Methods
	private void Start(); // 0x0000000180B7E820-0x0000000180B7E860
	private void OnEnable(); // 0x0000000180B7E860-0x0000000180B7E910
	private void OnDisable(); // 0x0000000180B7E910-0x0000000180B7E970
	private void StartRepeatingTasks(); // 0x0000000180B7E970-0x0000000180B7EA40
	public void OnHubSuspend(); // 0x0000000180B7EA40-0x0000000180B7EA50
	public void OnHubResume(); // 0x0000000180B7EA50-0x0000000180B7EAE0
	private void CalculateNextMonthStart(); // 0x0000000180B7EAE0-0x0000000180B7EC60
	private void UpdateCountdown(); // 0x0000000180B7EC60-0x0000000180B7F320
	private string FormatTimeSpan(TimeSpan timeSpan); // 0x0000000180B7F320-0x0000000180B7F750
	private void PeriodicCheckStatus(); // 0x0000000180B7F750-0x0000000180B7F780
	[IteratorStateMachine(typeof(_CheckRewardStatus_d__18))]
	private IEnumerator CheckRewardStatus(); // 0x0000000180B7F780-0x0000000180B7F820
	private void ShowNotification(string message); // 0x0000000180B7F820-0x0000000180B7FAD0
	[IteratorStateMachine(typeof(_HideNotificationAfterDelay_d__20))]
	private IEnumerator HideNotificationAfterDelay(float delay); // 0x0000000180B7FAD0-0x0000000180B7FB90
	[CompilerGenerated]
	private void _CheckRewardStatus_b__18_0(MonthlyRankingStatusResponse response); // 0x0000000180B7FBE0-0x0000000180B7FCB0
}

