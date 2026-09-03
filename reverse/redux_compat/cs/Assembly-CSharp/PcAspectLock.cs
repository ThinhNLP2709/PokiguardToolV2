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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class PcAspectLock : MonoBehaviour // TypeDefIndex: 842
{
	// Fields
	public const float TARGET_ASPECT = 2f; // Metadata: 0x0064CB79
	private const int DEFAULT_WIDTH = 1300; // Metadata: 0x0064CB7D
	private const int DEFAULT_HEIGHT = 650; // Metadata: 0x0064CB7F
	private const float ASPECT_EPSILON = 0.005f; // Metadata: 0x0064CB81
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
	private const int GWLP_WNDPROC = -4; // Metadata: 0x0064CB85
	private const uint WM_SIZING = 532; // Metadata: 0x0064CB86
	private const int WMSZ_LEFT = 1; // Metadata: 0x0064CB88
	private const int WMSZ_RIGHT = 2; // Metadata: 0x0064CB89
	private const int WMSZ_TOP = 3; // Metadata: 0x0064CB8A
	private const int WMSZ_TOPLEFT = 4; // Metadata: 0x0064CB8B
	private const int WMSZ_TOPRIGHT = 5; // Metadata: 0x0064CB8C
	private const int WMSZ_BOTTOM = 6; // Metadata: 0x0064CB8D

	// Nested types
	private delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam); // TypeDefIndex: 843; 0x000000018043A200-0x000000018043A220

	private struct RECT // TypeDefIndex: 844
	{
		// Fields
		public int left; // 0x00
		public int top; // 0x04
		public int right; // 0x08
		public int bottom; // 0x0C
	}

	[CompilerGenerated]
	private sealed class _Start_d__16 : IEnumerator<object> // TypeDefIndex: 845
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PcAspectLock __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Start_d__16(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804395E0-0x0000000180439710
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180439710-0x0000000180439750
	}

	// Constructors
	public PcAspectLock(); // 0x00000001804298B0-0x00000001804298D0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Install(); // 0x0000000180428E90-0x0000000180428F90
	private void Awake(); // 0x00000001804287C0-0x0000000180428930
	[IteratorStateMachine(typeof(_Start_d__16))]
	private IEnumerator Start(); // 0x00000001804293D0-0x0000000180429440
	private void OnDestroy(); // 0x0000000180429050-0x0000000180429170
	private void OnSceneLoaded(Scene s, LoadSceneMode m); // 0x0000000180429170-0x0000000180429180
	private void Update(); // 0x0000000180429580-0x00000001804295E0
	private void NanCuaSoVeTiLe(); // 0x0000000180428F90-0x0000000180429050
	public void ApplyNow(); // 0x00000001804284A0-0x00000001804287C0
	public static Rect TinhKhungHinh(float aspectHienTai); // 0x00000001804294C0-0x0000000180429530
	private void BatBackdrop(); // 0x0000000180428930-0x0000000180428B10
	private void TatBackdrop(); // 0x0000000180429440-0x00000001804294C0
	private static extern IntPtr GetActiveWindow(); // 0x0000000180428BD0-0x0000000180428C40
	private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong); // 0x0000000180429220-0x00000001804292C0
	private static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong); // 0x0000000180429180-0x0000000180429220
	private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam); // 0x0000000180428B10-0x0000000180428BD0
	private static IntPtr SetWndProc(IntPtr hWnd, IntPtr proc); // 0x00000001804292C0-0x00000001804293D0
	private void HookWindow(); // 0x0000000180428C40-0x0000000180428E90
	private void UnhookWindow(); // 0x0000000180429530-0x0000000180429580
	private IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam); // 0x00000001804295E0-0x00000001804298B0
}

