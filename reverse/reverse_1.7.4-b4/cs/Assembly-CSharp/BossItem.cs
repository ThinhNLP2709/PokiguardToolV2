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
	private const float START_INFLIGHT_MAX_SEC = 40f; // Metadata: 0x005EEEEA

	// Properties
	private static bool StartInFlight { get; } // 0x00000001803034A0-0x0000000180303570 

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
		internal void _CreateBossRoomThenLoadScene_b__0(); // 0x0000000180308BD0-0x0000000180308BE0
		internal void _CreateBossRoomThenLoadScene_b__1(string r); // 0x0000000180308BE0-0x0000000180308C40
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
		internal void _CreateBossRoomThenLoadScene_b__2(ChatMessageDTO _); // 0x0000000180308BD0-0x0000000180308BE0
		internal void _CreateBossRoomThenLoadScene_b__3(ChatMessageDTO m); // 0x0000000180308C40-0x0000000180308CB0
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
		void IDisposable.Dispose(); // 0x0000000180308CB0-0x0000000180308EB0
		private bool MoveNext(); // 0x0000000180308EB0-0x000000018030A670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018030A670-0x000000018030A6B0
	}

	// Constructors
	public BossItem(); // 0x00000001803089D0-0x0000000180308A50
	static BossItem(); // 0x0000000180308A50-0x0000000180308A90

	// Methods
	private static void SetStartInFlight(bool on); // 0x0000000180303570-0x0000000180303630
	private void Awake(); // 0x0000000180303630-0x00000001803038F0
	private void AutoFindUIComponents(); // 0x00000001803038F0-0x0000000180305100
	public void SetupBoss(WorldBossDTO boss); // 0x0000000180305100-0x0000000180305BB0
	private void LoadBossSprite(long petId); // 0x0000000180305BB0-0x0000000180305FA0
	public void UpdateCountdown(); // 0x0000000180305FA0-0x0000000180306360
	private void UpdateUI(); // 0x0000000180306360-0x0000000180306DE0
	private string FormatTimeSpan(TimeSpan time); // 0x0000000180306DE0-0x0000000180307160
	private void OnFightClicked(); // 0x0000000180307160-0x0000000180307B10
	[IteratorStateMachine(typeof(_CreateBossRoomThenLoadScene_d__33))]
	private IEnumerator CreateBossRoomThenLoadScene(); // 0x0000000180307B10-0x0000000180307BB0
	private void ShowNotice(string message); // 0x0000000180307BB0-0x0000000180308640
	private void CloseNotice(); // 0x0000000180308640-0x00000001803089D0
	[CompilerGenerated]
	private void _SetupBoss_b__27_0(); // 0x0000000180308A90-0x0000000180308AA0
	[CompilerGenerated]
	private void _ShowNotice_b__34_0(); // 0x0000000180308AA0-0x0000000180308AB0
	[CompilerGenerated]
	private void _CloseNotice_b__35_0(); // 0x0000000180308AB0-0x0000000180308BD0
}

