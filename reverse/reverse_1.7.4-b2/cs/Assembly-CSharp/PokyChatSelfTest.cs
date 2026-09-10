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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class PokyChatSelfTest : MonoBehaviour // TypeDefIndex: 500
{
	// Fields
	public const string PREF_KEY = "PokyChatSelfTest"; // Metadata: 0x0068B36A
	public const string REPORT_PATH = "Temp/PokyChatSelfTest.txt"; // Metadata: 0x0068B37B
	public const string SHOT_DIR = "Temp/PokySkinShots"; // Metadata: 0x0068B395
	private const float WAIT_DOCK_SEC = 120f; // Metadata: 0x0068B3A8
	private const float SETTLE_SEC = 1.5f; // Metadata: 0x0068B3AC
	private const float SHOT_SEC = 0.9f; // Metadata: 0x0068B3B0
	private const float WS_ROUNDTRIP_SEC = 3f; // Metadata: 0x0068B3B4
	private const string LONG_VI = "Ch\u00FAc m\u1EEBng! B\u1EA1n v\u1EEBa nh\u1EADn \u0111\u01B0\u1EE3c ph\u1EA7n th\u01B0\u1EDFng \u0111\u1EB7c bi\u1EC7t c\u1EE7a s\u1EF1 ki\u1EC7n m\u00F9a h\u00E8 \u2014 h\u00E3y m\u1EDF h\u1ED9p qu\u00E0 \u0111\u1EC3 nh\u1EADn nh\u00E9!"; // Metadata: 0x0068B3B8
	private readonly StringBuilder _report; // 0x20
	private readonly List<string> _errors; // 0x28
	private int _pass; // 0x30
	private int _fail; // 0x34
	private const BindingFlags PRIV = BindingFlags.Default | BindingFlags.Instance | BindingFlags.NonPublic; // Metadata: 0x0068B449

	// Nested types
	[CompilerGenerated]
	private sealed class _DragDockTo_d__26 : IEnumerator<object> // TypeDefIndex: 501
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DragDockTo_d__26(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BCBB0-0x00000001803BCBF0
		private bool MoveNext(); // 0x00000001803BC740-0x00000001803BCB70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BCB70-0x00000001803BCBB0
	}

	[CompilerGenerated]
	private sealed class _Run_d__17 : IEnumerator<object> // TypeDefIndex: 502
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
		private Transform _window_5__10; // 0x68
		private Transform _contentWorld_5__11; // 0x70
		private GameObject _rowTemplate_5__12; // 0x78
		private int _rowsBefore_5__13; // 0x80
		private ChatService _cs_5__14; // 0x88
		private string _me_5__15; // 0x90
		private GameObject _tray_5__16; // 0x98
		private int _forceBefore_5__17; // 0xA0
		private Vector2 _hubPos_5__18; // 0xA4
		private int _okCorner_5__19; // 0xAC
		private Vector2 _beforeTap_5__20; // 0xB0
		private Vector2 _keep_5__21; // 0xB8
		private string _user_5__22; // 0xC0
		private Vector2 _hubBefore_5__23; // 0xC8
		private Vector2[] __7__wrap23; // 0xD0
		private int __7__wrap24; // 0xD8
		private Vector2 _t_5__26; // 0xDC
		private Image _dotMine_5__27; // 0xE8
		private Image _dotOther_5__28; // 0xF0

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Run_d__17(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803C2B80-0x00000001803C2CD0
		private bool MoveNext(); // 0x00000001803BCCE0-0x00000001803C2B40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803C2B40-0x00000001803C2B80
	}

	// Constructors
	public PokyChatSelfTest(); // 0x00000001803A2D30-0x00000001803A2DD0

	// Methods
	private void OnEnable(); // 0x00000001803A2550-0x00000001803A25E0
	private void OnDisable(); // 0x00000001803A24C0-0x00000001803A2550
	private void OnLog(string condition, string stack, LogType type); // 0x00000001803A25E0-0x00000001803A2730
	private void Start(); // 0x00000001803A2B10-0x00000001803A2BC0
	[IteratorStateMachine(typeof(_Run_d__17))]
	private IEnumerator Run(); // 0x00000001803A2800-0x00000001803A2870
	private void CheckLayoutSpec(TeamChatPanel panel, RectTransform window); // 0x000000018039FEF0-0x00000001803A1220
	private static bool IsGreenish(Color c); // 0x00000001803A2470-0x00000001803A24A0
	private void CheckMinSize(Transform root, string path, float w, float h); // 0x00000001803A1440-0x00000001803A1820
	private void CheckMinFont(Transform root, string path, int min); // 0x00000001803A1220-0x00000001803A1440
	private void CheckFxGate(TeamChatPanel panel); // 0x000000018039F720-0x000000018039FC90
	private static bool ReadUiFxFlag(TeamChatPanel panel = null); // 0x00000001803A2730-0x00000001803A2800
	private void AuditTree(GameObject root, string label); // 0x000000018039EFD0-0x000000018039F720
	private static bool HasRuntimeListener(Button b); // 0x00000001803A2040-0x00000001803A2230
	[IteratorStateMachine(typeof(_DragDockTo_d__26))]
	private IEnumerator DragDockTo(RectTransform rt, Vector2 screenTarget); // 0x00000001803A1B70-0x00000001803A1C00
	private static Vector2 ScreenCenterOf(RectTransform rt); // 0x00000001803A2870-0x00000001803A2900
	private static object Field(object target, string name); // 0x00000001803A1C00-0x00000001803A1C80
	private static void Invoke(object target, string name, object[] args); // 0x00000001803A2230-0x00000001803A2340
	private static string SpriteName(Image img); // 0x00000001803A2A70-0x00000001803A2B10
	private static Rect WorldRect(RectTransform rt); // 0x00000001803A2BC0-0x00000001803A2D30
	private static bool IsFullyOnScreen(RectTransform rt); // 0x00000001803A2340-0x00000001803A2470
	private static string Corners(RectTransform rt); // 0x00000001803A18B0-0x00000001803A1B70
	private void Shot(string key); // 0x00000001803A2900-0x00000001803A2A70
	private void Check(bool ok, string failMsg); // 0x00000001803A1820-0x00000001803A18B0
	private void CheckImageDto(); // 0x000000018039FC90-0x000000018039FEF0
	private void Line(string s); // 0x00000001803A24A0-0x00000001803A24C0
	private void Finish(); // 0x00000001803A1C80-0x00000001803A2040
}

