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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class MonthlyRankingCountdown : MonoBehaviour, IHubSuspendable // TypeDefIndex: 2041
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
	private sealed class __c // TypeDefIndex: 2042
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__18_1; // 0x08

		// Constructors
		static __c(); // 0x00000001807274D0-0x0000000180727540
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _CheckRewardStatus_b__18_1(string error); // 0x0000000180726930-0x00000001807269A0
	}

	[CompilerGenerated]
	private sealed class _CheckRewardStatus_d__18 : IEnumerator<object> // TypeDefIndex: 2043
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MonthlyRankingCountdown __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CheckRewardStatus_d__18(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001807236D0-0x00000001807238B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807238B0-0x00000001807238F0
	}

	[CompilerGenerated]
	private sealed class _HideNotificationAfterDelay_d__20 : IEnumerator<object> // TypeDefIndex: 2044
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public MonthlyRankingCountdown __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideNotificationAfterDelay_d__20(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001807241A0-0x00000001807242A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807242A0-0x00000001807242E0
	}

	// Constructors
	public MonthlyRankingCountdown(); // 0x000000018071E0A0-0x000000018071E0C0

	// Methods
	private void Start(); // 0x000000018071DB80-0x000000018071DC10
	private void OnEnable(); // 0x000000018071D7E0-0x000000018071D880
	private void OnDisable(); // 0x000000018071D780-0x000000018071D7E0
	private void StartRepeatingTasks(); // 0x000000018071DA70-0x000000018071DB80
	public void OnHubSuspend(); // 0x000000018071D8B0-0x000000018071D8C0
	public void OnHubResume(); // 0x000000018071D880-0x000000018071D8B0
	private void CalculateNextMonthStart(); // 0x000000018071D290-0x000000018071D360
	private void UpdateCountdown(); // 0x000000018071DDB0-0x000000018071E0A0
	private string FormatTimeSpan(TimeSpan timeSpan); // 0x000000018071D3D0-0x000000018071D700
	private void PeriodicCheckStatus(); // 0x000000018071D8C0-0x000000018071D940
	[IteratorStateMachine(typeof(_CheckRewardStatus_d__18))]
	private IEnumerator CheckRewardStatus(); // 0x000000018071D360-0x000000018071D3D0
	private void ShowNotification(string message); // 0x000000018071D940-0x000000018071DA70
	[IteratorStateMachine(typeof(_HideNotificationAfterDelay_d__20))]
	private IEnumerator HideNotificationAfterDelay(float delay); // 0x000000018071D700-0x000000018071D780
	[CompilerGenerated]
	private void _CheckRewardStatus_b__18_0(MonthlyRankingStatusResponse response); // 0x000000018071DC10-0x000000018071DDB0
}

