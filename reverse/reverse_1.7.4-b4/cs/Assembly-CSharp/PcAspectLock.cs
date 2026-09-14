/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class PcAspectLock : MonoBehaviour // TypeDefIndex: 1421
{
	// Fields
	public const float TARGET_ASPECT = 2f; // Metadata: 0x005F0F2E
	private const int DEFAULT_WIDTH = 1300; // Metadata: 0x005F0F32
	private const int DEFAULT_HEIGHT = 650; // Metadata: 0x005F0F34
	private const float ASPECT_EPSILON = 0.005f; // Metadata: 0x005F0F36
	[Tooltip("Gi\u1EEF game \u1EDF c\u1EEDa s\u1ED5 2:1 thay v\u00EC cho to\u00E0n m\u00E0n h\u00ECnh. Xem ghi ch\u00FA gi\u1EDBi h\u1EA1n \u1EDF \u0111\u1EA7u file.")]
	public bool chanFullscreen; // 0x20
	private static PcAspectLock _instance; // 0x00
	private Camera _backdrop; // 0x28
	private int _lastWidth; // 0x30
	private int _lastHeight; // 0x34
	private bool _lastFullscreen; // 0x38
	private bool _daNanCuaSo; // 0x39
	private IntPtr _hwnd; // 0x40
	private IntPtr _oldWndProc; // 0x48
	private WndProcDelegate _hook; // 0x50
	private const int GWLP_WNDPROC = -4; // Metadata: 0x005F0F3A
	private const uint WM_SIZING = 532; // Metadata: 0x005F0F3B
	private const int WMSZ_LEFT = 1; // Metadata: 0x005F0F3D
	private const int WMSZ_RIGHT = 2; // Metadata: 0x005F0F3E
	private const int WMSZ_TOP = 3; // Metadata: 0x005F0F3F
	private const int WMSZ_TOPLEFT = 4; // Metadata: 0x005F0F40
	private const int WMSZ_TOPRIGHT = 5; // Metadata: 0x005F0F41
	private const int WMSZ_BOTTOM = 6; // Metadata: 0x005F0F42

	// Nested types
	private delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam); // TypeDefIndex: 1422; 0x00000001807A1270-0x00000001807A1290

	private struct RECT // TypeDefIndex: 1423
	{
		// Fields
		public int left; // 0x00
		public int top; // 0x04
		public int right; // 0x08
		public int bottom; // 0x0C
	}

	[CompilerGenerated]
	private sealed class _Start_d__16 : IEnumerator<object> // TypeDefIndex: 1424
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PcAspectLock __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Start_d__16(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807A1290-0x00000001807A14C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807A14C0-0x00000001807A1500
	}

	// Constructors
	public PcAspectLock(); // 0x00000001807A1120-0x00000001807A1180

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Install(); // 0x000000018079ED90-0x000000018079EF70
	private void Awake(); // 0x000000018079EF70-0x000000018079F2C0
	[IteratorStateMachine(typeof(_Start_d__16))]
	private IEnumerator Start(); // 0x000000018079F2C0-0x000000018079F360
	private void OnDestroy(); // 0x000000018079F360-0x000000018079F5A0
	private void OnSceneLoaded(Scene s, LoadSceneMode m); // 0x000000018079F5A0-0x000000018079F5B0
	private void Update(); // 0x000000018079F5B0-0x000000018079F6F0
	private void NanCuaSoVeTiLe(); // 0x000000018079F6F0-0x000000018079F860
	public void ApplyNow(); // 0x000000018079F860-0x000000018079FED0
	public static Rect TinhKhungHinh(float aspectHienTai); // 0x000000018079FED0-0x000000018079FF40
	private void BatBackdrop(); // 0x000000018079FF40-0x00000001807A0600
	private void TatBackdrop(); // 0x00000001807A0600-0x00000001807A0740
	private static extern IntPtr GetActiveWindow(); // 0x00000001807A0740-0x00000001807A07B0
	private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong); // 0x00000001807A07B0-0x00000001807A0850
	private static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong); // 0x00000001807A0850-0x00000001807A08F0
	private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam); // 0x00000001807A08F0-0x00000001807A09A0
	private static IntPtr SetWndProc(IntPtr hWnd, IntPtr proc); // 0x00000001807A09A0-0x00000001807A0A30
	private void HookWindow(); // 0x00000001807A0A30-0x00000001807A0DD0
	private void UnhookWindow(); // 0x00000001807A0DD0-0x00000001807A0E20
	private IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam); // 0x00000001807A0E20-0x00000001807A1120
}

