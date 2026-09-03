/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class PokyChatSelfTest : MonoBehaviour // TypeDefIndex: 431
{
	// Fields
	public const string PREF_KEY = "PokyChatSelfTest"; // Metadata: 0x0064C2F1
	public const string REPORT_PATH = "Temp/PokyChatSelfTest.txt"; // Metadata: 0x0064C302
	public const string SHOT_DIR = "Temp/PokySkinShots"; // Metadata: 0x0064C31C
	private const float WAIT_DOCK_SEC = 120f; // Metadata: 0x0064C32F
	private const float SETTLE_SEC = 1.5f; // Metadata: 0x0064C333
	private const float SHOT_SEC = 0.9f; // Metadata: 0x0064C337
	private const float WS_ROUNDTRIP_SEC = 3f; // Metadata: 0x0064C33B
	private const string LONG_VI = "Ch\u00FAc m\u1EEBng! B\u1EA1n v\u1EEBa nh\u1EADn \u0111\u01B0\u1EE3c ph\u1EA7n th\u01B0\u1EDFng \u0111\u1EB7c bi\u1EC7t c\u1EE7a s\u1EF1 ki\u1EC7n m\u00F9a h\u00E8 \u2014 h\u00E3y m\u1EDF h\u1ED9p qu\u00E0 \u0111\u1EC3 nh\u1EADn nh\u00E9!"; // Metadata: 0x0064C33F
	private readonly StringBuilder _report; // 0x20
	private readonly List<string> _errors; // 0x28
	private int _pass; // 0x30
	private int _fail; // 0x34
	private const BindingFlags PRIV = BindingFlags.Default | BindingFlags.Instance | BindingFlags.NonPublic; // Metadata: 0x0064C3D0

	// Nested types
	[CompilerGenerated]
	private sealed class _DragDockTo_d__20 : IEnumerator<object> // TypeDefIndex: 432
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RectTransform rt; // 0x20
		public Vector2 screenTarget; // 0x28
		private GameObject _go_5__2; // 0x30
		private Vector2 _start_5__3; // 0x38
		private PointerEventData _ped_5__4; // 0x40
		private Vector2 _prev_5__5; // 0x48
		private int _i_5__6; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DragDockTo_d__20(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180356CD0-0x0000000180356D10
		private bool MoveNext(); // 0x0000000180356860-0x0000000180356C90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180356C90-0x0000000180356CD0
	}

	[CompilerGenerated]
	private sealed class _Run_d__17 : IEnumerator<object> // TypeDefIndex: 433
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PokyChatSelfTest __4__this; // 0x20
		private float _t0_5__2; // 0x28
		private ChatDock _dock_5__3; // 0x30
		private RectTransform _btnRect_5__4; // 0x38
		private GameObject _badge_5__5; // 0x40
		private UnityEngine.UI.Text _badgeText_5__6; // 0x48
		private Canvas _canvas_5__7; // 0x50
		private Button _dockBtn_5__8; // 0x58
		private TeamChatPanel _panel_5__9; // 0x60
		private Transform _contentWorld_5__10; // 0x68
		private int _rowsBefore_5__11; // 0x70
		private ChatService _cs_5__12; // 0x78
		private GameObject _tray_5__13; // 0x80
		private Vector2 _hubPos_5__14; // 0x88
		private int _okCorner_5__15; // 0x90
		private Vector2 _beforeTap_5__16; // 0x94
		private Vector2 _keep_5__17; // 0x9C
		private string _user_5__18; // 0xA8
		private Vector2 _hubBefore_5__19; // 0xB0
		private Vector2[] __7__wrap19; // 0xB8
		private int __7__wrap20; // 0xC0
		private Vector2 _t_5__22; // 0xC4

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Run_d__17(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018035B7B0-0x000000018035B8A0
		private bool MoveNext(); // 0x0000000180356FE0-0x000000018035B770
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018035B770-0x000000018035B7B0
	}

	// Constructors
	public PokyChatSelfTest(); // 0x0000000180349050-0x00000001803490F0

	// Methods
	private void OnEnable(); // 0x0000000180348940-0x00000001803489D0
	private void OnDisable(); // 0x00000001803488B0-0x0000000180348940
	private void OnLog(string condition, string stack, LogType type); // 0x00000001803489D0-0x0000000180348B20
	private void Start(); // 0x0000000180348E30-0x0000000180348EE0
	[IteratorStateMachine(typeof(_Run_d__17))]
	private IEnumerator Run(); // 0x0000000180348B20-0x0000000180348B90
	private void AuditTree(GameObject root, string label); // 0x00000001803474F0-0x0000000180347C40
	private static bool HasRuntimeListener(Button b); // 0x0000000180348460-0x0000000180348650
	[IteratorStateMachine(typeof(_DragDockTo_d__20))]
	private IEnumerator DragDockTo(RectTransform rt, Vector2 screenTarget); // 0x0000000180347F90-0x0000000180348020
	private static Vector2 ScreenCenterOf(RectTransform rt); // 0x0000000180348B90-0x0000000180348C20
	private static object Field(object target, string name); // 0x0000000180348020-0x00000001803480A0
	private static void Invoke(object target, string name, object[] args); // 0x0000000180348650-0x0000000180348760
	private static string SpriteName(Image img); // 0x0000000180348D90-0x0000000180348E30
	private static Rect WorldRect(RectTransform rt); // 0x0000000180348EE0-0x0000000180349050
	private static bool IsFullyOnScreen(RectTransform rt); // 0x0000000180348760-0x0000000180348890
	private static string Corners(RectTransform rt); // 0x0000000180347CD0-0x0000000180347F90
	private void Shot(string key); // 0x0000000180348C20-0x0000000180348D90
	private void Check(bool ok, string failMsg); // 0x0000000180347C40-0x0000000180347CD0
	private void Line(string s); // 0x0000000180348890-0x00000001803488B0
	private void Finish(); // 0x00000001803480A0-0x0000000180348460
}

