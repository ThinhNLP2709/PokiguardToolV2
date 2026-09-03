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

public class ManagerBoss : MonoBehaviour // TypeDefIndex: 337
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

	// Nested types
	[CompilerGenerated]
	private sealed class _UpdateCountdownLoop_d__19 : IEnumerator<object> // TypeDefIndex: 338
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerBoss __4__this; // 0x20
		private WaitForSeconds _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UpdateCountdownLoop_d__19(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001806FFE40-0x0000000180700090
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180700090-0x00000001807001E0
	}

	// Constructors
	public ManagerBoss(); // 0x00000001806FB910-0x00000001806FB9D0

	// Methods
	private void Start(); // 0x00000001806FB620-0x00000001806FB8A0
	public void OpenPanel(); // 0x00000001806FB560-0x00000001806FB610
	public void OpenPanelXepHang(); // 0x00000001806FB3E0-0x00000001806FB560
	private void FindExistingBossItems(); // 0x00000001806FAD90-0x00000001806FB130
	private void LoadBossList(); // 0x00000001806FB200-0x00000001806FB330
	private void OnBossListReceived(List<WorldBossDTO> bosses); // 0x00000001806FB330-0x00000001806FB360
	private void DisplayBosses(); // 0x00000001806FA9F0-0x00000001806FAD90
	[IteratorStateMachine(typeof(_UpdateCountdownLoop_d__19))]
	private IEnumerator UpdateCountdownLoop(); // 0x00000001806FB8A0-0x00000001806FB910
	private void HideStatusAndAnimation(); // 0x00000001806FB130-0x00000001806FB200
	public void ClosePanel(); // 0x00000001806FA950-0x00000001806FA9F0
	public void RefreshBossList(); // 0x00000001806FB610-0x00000001806FB620
	private void OnError(string error); // 0x00000001806FB370-0x00000001806FB3E0
	private void OnDestroy(); // 0x00000001806FB360-0x00000001806FB370
}

