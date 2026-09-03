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

public class BossItem : MonoBehaviour // TypeDefIndex: 333
{
	// Fields
	[Header("UI Elements - T\u1EF1 \u0111\u1ED9ng t\u00ECm n\u1EBFu kh\u00F4ng g\u00E1n")]
	public Image imgBoss; // 0x20
	public Image imgStatus; // 0x28
	public UnityEngine.UI.Text txtName; // 0x30
	public UnityEngine.UI.Text txtTime; // 0x38
	public UnityEngine.UI.Text txtStatus; // 0x40
	public Button btnFight; // 0x48
	public GameObject upcomingBadge; // 0x50
	public GameObject endedOverlay; // 0x58
	public GameObject anmt; // 0x60
	[Header("Panel Notice")]
	public GameObject panelNotice; // 0x68
	public UnityEngine.UI.Text txtNoticeMessage; // 0x70
	private WorldBossDTO bossData; // 0x78
	private DateTime startTime; // 0x80
	private DateTime endTime; // 0x88
	private long _serverClockOffsetMs; // 0x90
	private Transform uiTransform; // 0x98
	private Outline txtStatusOutline; // 0xA0
	private Color colorActive; // 0xA8
	private Color colorUpcoming; // 0xB8
	private Color colorEnded; // 0xC8

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 334
	{
		// Fields
		public bool ready; // 0x10
		public bool failed; // 0x11
		public string failReason; // 0x18

		// Constructors
		public __c__DisplayClass28_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CreateBossRoomThenLoadScene_b__0(); // 0x000000018030F220-0x000000018030F230
		internal void _CreateBossRoomThenLoadScene_b__1(string r); // 0x0000000180439990-0x00000001804399B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_1 // TypeDefIndex: 335
	{
		// Fields
		public bool started; // 0x10
		public bool startFailed; // 0x11
		public string startFailReason; // 0x18

		// Constructors
		public __c__DisplayClass28_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CreateBossRoomThenLoadScene_b__2(ChatMessageDTO _); // 0x000000018030F220-0x000000018030F230
		internal void _CreateBossRoomThenLoadScene_b__3(ChatMessageDTO m); // 0x00000001806FFA20-0x00000001806FFA50
	}

	[CompilerGenerated]
	private sealed class _CreateBossRoomThenLoadScene_d__28 : IEnumerator<object> // TypeDefIndex: 336
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossItem __4__this; // 0x20
		private __c__DisplayClass28_0 __8__1; // 0x28
		private __c__DisplayClass28_1 __8__2; // 0x30
		private Action _onReady_5__2; // 0x38
		private Action<string> _onFailed_5__3; // 0x40
		private float _tWs_5__4; // 0x48
		private float _t_5__5; // 0x4C
		private Action<ChatMessageDTO> _onStarting_5__6; // 0x50
		private Action<ChatMessageDTO> _onStartFailed_5__7; // 0x58
		private float _tStart_5__8; // 0x60

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CreateBossRoomThenLoadScene_d__28(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001806FF6B0-0x00000001806FF730
		private bool MoveNext(); // 0x00000001806FEA40-0x00000001806FF670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806FF670-0x00000001806FF6B0
	}

	// Constructors
	public BossItem(); // 0x00000001806F3E80-0x00000001806F3EC0

	// Methods
	private void Awake(); // 0x00000001806F1850-0x00000001806F19E0
	private void AutoFindUIComponents(); // 0x00000001806F0780-0x00000001806F1850
	public void SetupBoss(WorldBossDTO boss); // 0x00000001806F2880-0x00000001806F3000
	private void LoadBossSprite(long petId); // 0x00000001806F1E00-0x00000001806F2070
	public void UpdateCountdown(); // 0x00000001806F3640-0x00000001806F3930
	private void UpdateUI(); // 0x00000001806F3930-0x00000001806F3E80
	private string FormatTimeSpan(TimeSpan time); // 0x00000001806F1C20-0x00000001806F1E00
	private void OnFightClicked(); // 0x00000001806F2070-0x00000001806F2880
	[IteratorStateMachine(typeof(_CreateBossRoomThenLoadScene_d__28))]
	private IEnumerator CreateBossRoomThenLoadScene(); // 0x00000001806F1BB0-0x00000001806F1C20
	private void ShowNotice(string message); // 0x00000001806F3000-0x00000001806F3570
	private void CloseNotice(); // 0x00000001806F19E0-0x00000001806F1BB0
	[CompilerGenerated]
	private void _SetupBoss_b__22_0(); // 0x00000001806F3620-0x00000001806F3630
	[CompilerGenerated]
	private void _ShowNotice_b__29_0(); // 0x00000001806F3630-0x00000001806F3640
	[CompilerGenerated]
	private void _CloseNotice_b__30_0(); // 0x00000001806F3570-0x00000001806F3620
}

