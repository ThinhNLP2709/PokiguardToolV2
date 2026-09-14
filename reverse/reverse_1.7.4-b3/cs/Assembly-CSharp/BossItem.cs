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

public class BossItem : MonoBehaviour // TypeDefIndex: 356
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
	private static float s_startInFlightSince; // 0x00
	private const float START_INFLIGHT_MAX_SEC = 40f; // Metadata: 0x005EDB1A

	// Properties
	private static bool StartInFlight { get; } // 0x0000000180303470-0x0000000180303540 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass33_0 // TypeDefIndex: 357
	{
		// Fields
		public bool ready; // 0x10
		public bool failed; // 0x11
		public string failReason; // 0x18

		// Constructors
		public __c__DisplayClass33_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CreateBossRoomThenLoadScene_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
		internal void _CreateBossRoomThenLoadScene_b__1(string r); // 0x0000000180308BB0-0x0000000180308C10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass33_1 // TypeDefIndex: 358
	{
		// Fields
		public bool started; // 0x10
		public bool startFailed; // 0x11
		public string startFailReason; // 0x18

		// Constructors
		public __c__DisplayClass33_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CreateBossRoomThenLoadScene_b__2(ChatMessageDTO _); // 0x0000000180308BA0-0x0000000180308BB0
		internal void _CreateBossRoomThenLoadScene_b__3(ChatMessageDTO m); // 0x0000000180308C10-0x0000000180308C80
	}

	[CompilerGenerated]
	private sealed class _CreateBossRoomThenLoadScene_d__33 : IEnumerator<object> // TypeDefIndex: 359
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossItem __4__this; // 0x20
		private __c__DisplayClass33_0 __8__1; // 0x28
		private __c__DisplayClass33_1 __8__2; // 0x30
		private Action _onReady_5__2; // 0x38
		private Action<string> _onFailed_5__3; // 0x40
		private float _tWs_5__4; // 0x48
		private float _t_5__5; // 0x4C
		private Action<ChatMessageDTO> _onStarting_5__6; // 0x50
		private Action<ChatMessageDTO> _onStartFailed_5__7; // 0x58
		private float _tStart_5__8; // 0x60

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CreateBossRoomThenLoadScene_d__33(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180308C80-0x0000000180308E80
		private bool MoveNext(); // 0x0000000180308E80-0x000000018030A640
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018030A640-0x000000018030A680
	}

	// Constructors
	public BossItem(); // 0x00000001803089A0-0x0000000180308A20
	static BossItem(); // 0x0000000180308A20-0x0000000180308A60

	// Methods
	private static void SetStartInFlight(bool on); // 0x0000000180303540-0x0000000180303600
	private void Awake(); // 0x0000000180303600-0x00000001803038C0
	private void AutoFindUIComponents(); // 0x00000001803038C0-0x00000001803050D0
	public void SetupBoss(WorldBossDTO boss); // 0x00000001803050D0-0x0000000180305B80
	private void LoadBossSprite(long petId); // 0x0000000180305B80-0x0000000180305F70
	public void UpdateCountdown(); // 0x0000000180305F70-0x0000000180306330
	private void UpdateUI(); // 0x0000000180306330-0x0000000180306DB0
	private string FormatTimeSpan(TimeSpan time); // 0x0000000180306DB0-0x0000000180307130
	private void OnFightClicked(); // 0x0000000180307130-0x0000000180307AE0
	[IteratorStateMachine(typeof(_CreateBossRoomThenLoadScene_d__33))]
	private IEnumerator CreateBossRoomThenLoadScene(); // 0x0000000180307AE0-0x0000000180307B80
	private void ShowNotice(string message); // 0x0000000180307B80-0x0000000180308610
	private void CloseNotice(); // 0x0000000180308610-0x00000001803089A0
	[CompilerGenerated]
	private void _SetupBoss_b__27_0(); // 0x0000000180308A60-0x0000000180308A70
	[CompilerGenerated]
	private void _ShowNotice_b__34_0(); // 0x0000000180308A70-0x0000000180308A80
	[CompilerGenerated]
	private void _CloseNotice_b__35_0(); // 0x0000000180308A80-0x0000000180308BA0
}

