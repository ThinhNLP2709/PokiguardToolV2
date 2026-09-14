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

public class ManagerBoss : MonoBehaviour // TypeDefIndex: 376
{
	// Fields
	[Header("UI References")]
	public Button btnClose; // 0x20
	public GameObject panelBoss; // 0x28
	public GameObject panelBossTG; // 0x30
	public GameObject panelNotice; // 0x38
	public Button btnXepHang; // 0x40
	public GameObject panelXepHang; // 0x48
	[Header("Status Display")]
	public UnityEngine.UI.Text txtStatusOutside; // 0x50
	public GameObject statusObject; // 0x58
	public GameObject anmtObject; // 0x60
	private List<WorldBossDTO> bossList; // 0x68
	private List<BossItem> bossItems; // 0x70
	private Coroutine _countdownCo; // 0x78
	private const float BADGE_FIRST_DELAY = 3f; // Metadata: 0x005EDD4F
	private const float BADGE_MAX_INTERVAL = 600f; // Metadata: 0x005EDD53
	private const float BADGE_RETRY_INTERVAL = 60f; // Metadata: 0x005EDD57
	private List<WorldBossDTO> _badgeList; // 0x80
	private long _badgeClockOffsetMs; // 0x88
	private float _badgeRefetchAt; // 0x90
	private bool _badgeHasBootstrap; // 0x94
	private bool _badgeBootstrapOpen; // 0x95

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 377
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action __9__28_0; // 0x08
		public static Action<string> __9__28_1; // 0x10

		// Constructors
		static __c(); // 0x0000000180320670-0x0000000180320710
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _HubBadgeLoop_b__28_0(); // 0x000000018028A320-0x000000018028A330
		internal void _HubBadgeLoop_b__28_1(string err); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class _HubBadgeLoop_d__28 : IEnumerator<object> // TypeDefIndex: 378
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerBoss __4__this; // 0x20
		private float _gateStart_5__2; // 0x28
		private WaitForSeconds _tick_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HubBadgeLoop_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180320710-0x0000000180320B80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180320B80-0x0000000180320BC0
	}

	[CompilerGenerated]
	private sealed class _UpdateCountdownLoop_d__27 : IEnumerator<object> // TypeDefIndex: 379
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerBoss __4__this; // 0x20
		private WaitForSeconds _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpdateCountdownLoop_d__27(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180320BC0-0x0000000180320F70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180320F70-0x0000000180320FB0
	}

	// Constructors
	public ManagerBoss(); // 0x00000001803204C0-0x0000000180320670

	// Methods
	private void Start(); // 0x000000018031D8B0-0x000000018031DE30
	public void OpenPanel(); // 0x000000018031DE30-0x000000018031DF70
	public void OpenPanelXepHang(); // 0x000000018031DF70-0x000000018031E410
	private void FindExistingBossItems(); // 0x000000018031E410-0x000000018031EB80
	private void LoadBossList(); // 0x000000018031EB80-0x000000018031ECE0
	private void OnBossListReceived(List<WorldBossDTO> bosses); // 0x000000018031ECE0-0x000000018031ED60
	private void DisplayBosses(); // 0x000000018031ED60-0x000000018031F2E0
	[IteratorStateMachine(typeof(_UpdateCountdownLoop_d__27))]
	private IEnumerator UpdateCountdownLoop(); // 0x000000018031F2E0-0x000000018031F380
	[IteratorStateMachine(typeof(_HubBadgeLoop_d__28))]
	private IEnumerator HubBadgeLoop(); // 0x000000018031F380-0x000000018031F420
	private bool TryApplyWorldBossBadge(HubBadgesData badges); // 0x000000018031F420-0x000000018031F620
	private void ApplyHubBadgeList(List<WorldBossDTO> list); // 0x000000018031F620-0x000000018031FB00
	private static float NextWait(long markMs, long nowMs, float current); // 0x000000018031FB00-0x000000018031FB30
	private void RefreshHubBadge(); // 0x000000018031FB30-0x000000018031FB60
	private bool HasActiveBoss(); // 0x000000018031FB60-0x000000018031FD30
	private long NowServerMs(); // 0x000000018031FD30-0x000000018031FDF0
	private void SetHubBadge(bool on); // 0x000000018031FDF0-0x0000000180320200
	public void ClosePanel(); // 0x0000000180320200-0x00000001803203C0
	public void RefreshBossList(); // 0x00000001803203C0-0x00000001803203D0
	private void OnError(string error); // 0x00000001803203D0-0x0000000180320450
	private void OnDestroy(); // 0x0000000180320450-0x00000001803204C0
}

