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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class PcAspectLock : MonoBehaviour // TypeDefIndex: 1040
{
	// Fields
	public const float TARGET_ASPECT = 2f; // Metadata: 0x0068C30A
	private const int DEFAULT_WIDTH = 1300; // Metadata: 0x0068C30E
	private const int DEFAULT_HEIGHT = 650; // Metadata: 0x0068C310
	private const float ASPECT_EPSILON = 0.005f; // Metadata: 0x0068C312
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
	private const int GWLP_WNDPROC = -4; // Metadata: 0x0068C316
	private const uint WM_SIZING = 532; // Metadata: 0x0068C317
	private const int WMSZ_LEFT = 1; // Metadata: 0x0068C319
	private const int WMSZ_RIGHT = 2; // Metadata: 0x0068C31A
	private const int WMSZ_TOP = 3; // Metadata: 0x0068C31B
	private const int WMSZ_TOPLEFT = 4; // Metadata: 0x0068C31C
	private const int WMSZ_TOPRIGHT = 5; // Metadata: 0x0068C31D
	private const int WMSZ_BOTTOM = 6; // Metadata: 0x0068C31E

	// Nested types
	private delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam); // TypeDefIndex: 1041; 0x00000001805101A0-0x00000001805101C0

	private struct RECT // TypeDefIndex: 1042
	{
		// Fields
		public int left; // 0x00
		public int top; // 0x04
		public int right; // 0x08
		public int bottom; // 0x0C
	}

	[CompilerGenerated]
	private sealed class _Start_d__16 : IEnumerator<object> // TypeDefIndex: 1043
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PcAspectLock __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Start_d__16(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018050F560-0x000000018050F690
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018050F690-0x000000018050F6D0
	}

	// Constructors
	public PcAspectLock(); // 0x00000001804FF540-0x00000001804FF560

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Install(); // 0x00000001804FEB20-0x00000001804FEC20
	private void Awake(); // 0x00000001804FE450-0x00000001804FE5C0
	[IteratorStateMachine(typeof(_Start_d__16))]
	private IEnumerator Start(); // 0x00000001804FF060-0x00000001804FF0D0
	private void OnDestroy(); // 0x00000001804FECE0-0x00000001804FEE00
	private void OnSceneLoaded(Scene s, LoadSceneMode m); // 0x00000001804FEE00-0x00000001804FEE10
	private void Update(); // 0x00000001804FF210-0x00000001804FF270
	private void NanCuaSoVeTiLe(); // 0x00000001804FEC20-0x00000001804FECE0
	public void ApplyNow(); // 0x00000001804FE130-0x00000001804FE450
	public static Rect TinhKhungHinh(float aspectHienTai); // 0x00000001804FF150-0x00000001804FF1C0
	private void BatBackdrop(); // 0x00000001804FE5C0-0x00000001804FE7A0
	private void TatBackdrop(); // 0x00000001804FF0D0-0x00000001804FF150
	private static extern IntPtr GetActiveWindow(); // 0x00000001804FE860-0x00000001804FE8D0
	private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong); // 0x00000001804FEEB0-0x00000001804FEF50
	private static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong); // 0x00000001804FEE10-0x00000001804FEEB0
	private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam); // 0x00000001804FE7A0-0x00000001804FE860
	private static IntPtr SetWndProc(IntPtr hWnd, IntPtr proc); // 0x00000001804FEF50-0x00000001804FF060
	private void HookWindow(); // 0x00000001804FE8D0-0x00000001804FEB20
	private void UnhookWindow(); // 0x00000001804FF1C0-0x00000001804FF210
	private IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam); // 0x00000001804FF270-0x00000001804FF540
}

