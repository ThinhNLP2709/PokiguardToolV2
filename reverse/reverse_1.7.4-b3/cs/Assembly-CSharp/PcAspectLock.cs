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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class PcAspectLock : MonoBehaviour // TypeDefIndex: 1419
{
	// Fields
	public const float TARGET_ASPECT = 2f; // Metadata: 0x005EFB61
	private const int DEFAULT_WIDTH = 1300; // Metadata: 0x005EFB65
	private const int DEFAULT_HEIGHT = 650; // Metadata: 0x005EFB67
	private const float ASPECT_EPSILON = 0.005f; // Metadata: 0x005EFB69
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
	private const int GWLP_WNDPROC = -4; // Metadata: 0x005EFB6D
	private const uint WM_SIZING = 532; // Metadata: 0x005EFB6E
	private const int WMSZ_LEFT = 1; // Metadata: 0x005EFB70
	private const int WMSZ_RIGHT = 2; // Metadata: 0x005EFB71
	private const int WMSZ_TOP = 3; // Metadata: 0x005EFB72
	private const int WMSZ_TOPLEFT = 4; // Metadata: 0x005EFB73
	private const int WMSZ_TOPRIGHT = 5; // Metadata: 0x005EFB74
	private const int WMSZ_BOTTOM = 6; // Metadata: 0x005EFB75

	// Nested types
	private delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam); // TypeDefIndex: 1420; 0x000000018079F200-0x000000018079F220

	private struct RECT // TypeDefIndex: 1421
	{
		// Fields
		public int left; // 0x00
		public int top; // 0x04
		public int right; // 0x08
		public int bottom; // 0x0C
	}

	[CompilerGenerated]
	private sealed class _Start_d__16 : IEnumerator<object> // TypeDefIndex: 1422
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018079F220-0x000000018079F450
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018079F450-0x000000018079F490
	}

	// Constructors
	public PcAspectLock(); // 0x000000018079F0B0-0x000000018079F110

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Install(); // 0x000000018079CD20-0x000000018079CF00
	private void Awake(); // 0x000000018079CF00-0x000000018079D250
	[IteratorStateMachine(typeof(_Start_d__16))]
	private IEnumerator Start(); // 0x000000018079D250-0x000000018079D2F0
	private void OnDestroy(); // 0x000000018079D2F0-0x000000018079D530
	private void OnSceneLoaded(Scene s, LoadSceneMode m); // 0x000000018079D530-0x000000018079D540
	private void Update(); // 0x000000018079D540-0x000000018079D680
	private void NanCuaSoVeTiLe(); // 0x000000018079D680-0x000000018079D7F0
	public void ApplyNow(); // 0x000000018079D7F0-0x000000018079DE60
	public static Rect TinhKhungHinh(float aspectHienTai); // 0x000000018079DE60-0x000000018079DED0
	private void BatBackdrop(); // 0x000000018079DED0-0x000000018079E590
	private void TatBackdrop(); // 0x000000018079E590-0x000000018079E6D0
	private static extern IntPtr GetActiveWindow(); // 0x000000018079E6D0-0x000000018079E740
	private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong); // 0x000000018079E740-0x000000018079E7E0
	private static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong); // 0x000000018079E7E0-0x000000018079E880
	private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam); // 0x000000018079E880-0x000000018079E930
	private static IntPtr SetWndProc(IntPtr hWnd, IntPtr proc); // 0x000000018079E930-0x000000018079E9C0
	private void HookWindow(); // 0x000000018079E9C0-0x000000018079ED60
	private void UnhookWindow(); // 0x000000018079ED60-0x000000018079EDB0
	private IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam); // 0x000000018079EDB0-0x000000018079F0B0
}

