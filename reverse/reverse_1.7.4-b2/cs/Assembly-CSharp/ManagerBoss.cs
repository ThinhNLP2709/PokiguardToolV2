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

public class ManagerBoss : MonoBehaviour // TypeDefIndex: 380
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
	private const float BADGE_FIRST_DELAY = 3f; // Metadata: 0x0068B182
	private const float BADGE_MAX_INTERVAL = 600f; // Metadata: 0x0068B186
	private const float BADGE_RETRY_INTERVAL = 60f; // Metadata: 0x0068B18A
	private List<WorldBossDTO> _badgeList; // 0x80
	private long _badgeClockOffsetMs; // 0x88
	private float _badgeRefetchAt; // 0x90
	private bool _badgeHasBootstrap; // 0x94
	private bool _badgeBootstrapOpen; // 0x95

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 381
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action __9__28_0; // 0x08
		public static Action<string> __9__28_1; // 0x10

		// Constructors
		static __c(); // 0x0000000180361FB0-0x0000000180362020
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _HubBadgeLoop_b__28_0(); // 0x00000001802EB6C0-0x00000001802EB6D0
		internal void _HubBadgeLoop_b__28_1(string err); // 0x00000001802EB6C0-0x00000001802EB6D0
	}

	[CompilerGenerated]
	private sealed class _HubBadgeLoop_d__28 : IEnumerator<object> // TypeDefIndex: 382
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerBoss __4__this; // 0x20
		private float _gateStart_5__2; // 0x28
		private WaitForSeconds _tick_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HubBadgeLoop_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x000000018035FFA0-0x0000000180360440
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180360440-0x0000000180360480
	}

	[CompilerGenerated]
	private sealed class _UpdateCountdownLoop_d__27 : IEnumerator<object> // TypeDefIndex: 383
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerBoss __4__this; // 0x20
		private WaitForSeconds _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UpdateCountdownLoop_d__27(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180362020-0x0000000180362270
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180362270-0x0000000180362530
	}

	// Constructors
	public ManagerBoss(); // 0x000000018035CFE0-0x000000018035D0A0

	// Methods
	private void Start(); // 0x000000018035CBA0-0x000000018035CE00
	public void OpenPanel(); // 0x000000018035C950-0x000000018035CA00
	public void OpenPanelXepHang(); // 0x000000018035C7D0-0x000000018035C950
	private void FindExistingBossItems(); // 0x000000018035BFB0-0x000000018035C350
	private void LoadBossList(); // 0x000000018035C530-0x000000018035C660
	private void OnBossListReceived(List<WorldBossDTO> bosses); // 0x000000018035C700-0x000000018035C750
	private void DisplayBosses(); // 0x000000018035BC10-0x000000018035BFB0
	[IteratorStateMachine(typeof(_UpdateCountdownLoop_d__27))]
	private IEnumerator UpdateCountdownLoop(); // 0x000000018035CF70-0x000000018035CFE0
	[IteratorStateMachine(typeof(_HubBadgeLoop_d__28))]
	private IEnumerator HubBadgeLoop(); // 0x000000018035C4C0-0x000000018035C530
	private bool TryApplyWorldBossBadge(HubBadgesData badges); // 0x000000018035CE00-0x000000018035CF70
	private void ApplyHubBadgeList(List<WorldBossDTO> list); // 0x000000018035B7F0-0x000000018035BB70
	private static float NextWait(long markMs, long nowMs, float current); // 0x000000018035C660-0x000000018035C690
	private void RefreshHubBadge(); // 0x000000018035CA10-0x000000018035CA40
	private bool HasActiveBoss(); // 0x000000018035C350-0x000000018035C4C0
	private long NowServerMs(); // 0x000000018035C690-0x000000018035C700
	private void SetHubBadge(bool on); // 0x000000018035CA40-0x000000018035CBA0
	public void ClosePanel(); // 0x000000018035BB70-0x000000018035BC10
	public void RefreshBossList(); // 0x000000018035CA00-0x000000018035CA10
	private void OnError(string error); // 0x000000018035C760-0x000000018035C7D0
	private void OnDestroy(); // 0x000000018035C750-0x000000018035C760
}

