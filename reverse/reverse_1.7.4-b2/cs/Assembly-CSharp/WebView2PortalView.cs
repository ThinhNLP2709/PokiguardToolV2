/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class WebView2PortalView : IWebPortalView // TypeDefIndex: 1107
{
	// Fields
	private const float GAMEVIEW_TOOLBAR_POINTS = 21f; // Metadata: 0x0068C56A
	private const string USER_DATA_SUBDIR = "webview2"; // Metadata: 0x0068C56E
	private const string BRIDGE_SCRIPT = "window.Unity = window.Unity || {};window.Unity.call = function(m){ try { window.chrome.webview.postMessage(String(m)); } catch(e) {} };"; // Metadata: 0x0068C577
	private static bool _runtimeChecked; // 0x00
	private static bool _runtimeAvailable; // 0x01
	private readonly ConcurrentQueue<Action> _mainThread; // 0x10
	private CoreWebView2Environment _env; // 0x18
	private CoreWebView2Controller _controller; // 0x20
	private CoreWebView2 _core; // 0x28
	private IntPtr _parentHwnd; // 0x30
	private bool _creating; // 0x38
	private bool _destroyed; // 0x39
	private string _pendingUrl; // 0x40
	private bool _wantVisible; // 0x48
	private bool _visibleBeforePause; // 0x49
	private bool _hasMargins; // 0x4A
	private int _ml; // 0x4C
	private int _mt; // 0x50
	private int _mr; // 0x54
	private int _mb; // 0x58
	private Rectangle _lastBounds; // 0x5C
	private Action<string> _onMessage; // 0x70
	private Action _onLoaded; // 0x78
	private Action<string> _onError; // 0x80
	private Action<string> _onHttpError; // 0x88

	// Properties
	public bool IsAlive { get; } // 0x0000000180555FA0-0x0000000180555FC0 

	// Nested types
	private struct POINT // TypeDefIndex: 1108
	{
		// Fields
		public int X; // 0x00
		public int Y; // 0x04
	}

	private struct RECT // TypeDefIndex: 1109
	{
		// Fields
		public int Left; // 0x00
		public int Top; // 0x04
		public int Right; // 0x08
		public int Bottom; // 0x0C
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 1110
	{
		// Fields
		public WebView2PortalView __4__this; // 0x10
		public string msg; // 0x18

		// Constructors
		public __c__DisplayClass34_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _StartCreateAsync_b__0(); // 0x000000018054AB20-0x000000018054AB60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass39_0 // TypeDefIndex: 1111
	{
		// Fields
		public WebView2PortalView __4__this; // 0x10
		public string msg; // 0x18

		// Constructors
		public __c__DisplayClass39_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnWebMessageReceived_b__0(); // 0x000000018054AEA0-0x000000018054AEE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass41_0 // TypeDefIndex: 1112
	{
		// Fields
		public WebView2PortalView __4__this; // 0x10
		public string text; // 0x18

		// Constructors
		public __c__DisplayClass41_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnNavigationCompleted_b__0(); // 0x000000018054B100-0x000000018054B140
		internal void _OnNavigationCompleted_b__1(); // 0x000000018054B140-0x000000018054B1A0
	}

	[CompilerGenerated]
	private struct _StartCreateAsync_d__34 : IAsyncStateMachine // TypeDefIndex: 1113
	{
		// Fields
		public int __1__state; // 0x00
		public AsyncVoidMethodBuilder __t__builder; // 0x08
		public WebView2PortalView __4__this; // 0x28
		private __c__DisplayClass34_0 __8__1; // 0x30
		private TaskAwaiter<CoreWebView2Environment> __u__1; // 0x38
		private TaskAwaiter<CoreWebView2Controller> __u__2; // 0x40
		private TaskAwaiter<string> __u__3; // 0x48

		// Methods
		private void MoveNext(); // 0x000000018054A060-0x000000018054A950
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x000000018054A950-0x000000018054A960
	}

	// Constructors
	public WebView2PortalView(); // 0x0000000180555F20-0x0000000180555FA0

	// Methods
	private static extern IntPtr GetActiveWindow(); // 0x0000000180554DA0-0x0000000180554E10
	private static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint); // 0x0000000180555860-0x00000001805558F0
	private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect); // 0x0000000180554E10-0x0000000180554EA0
	public static bool IsRuntimeAvailable(); // 0x00000001805550B0-0x0000000180555220
	public bool Create(Action<string> onMessage, Action onLoaded, Action<string> onError, Action<string> onHttpError = null); // 0x0000000180554930-0x0000000180554AE0
	private async void StartCreateAsync(); // 0x00000001805559C0-0x0000000180555A50
	private void ApplySettings(); // 0x00000001805548A0-0x0000000180554930
	private void ApplyScale(); // 0x00000001805547D0-0x00000001805548A0
	private void HookEvents(); // 0x0000000180554EA0-0x0000000180555030
	private void UnhookEvents(); // 0x0000000180555D90-0x0000000180555F20
	private void OnWebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e); // 0x0000000180555610-0x0000000180555790
	private void OnNavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e); // 0x00000001805554A0-0x0000000180555590
	private void OnNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e); // 0x0000000180555310-0x00000001805554A0
	private void OnNewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e); // 0x0000000180555590-0x0000000180555610
	private static bool IsAllowedNavigation(string uri); // 0x0000000180555030-0x00000001805550B0
	public void Load(string url); // 0x0000000180555220-0x0000000180555310
	public void SetScreenMargins(int left, int top, int right, int bottom); // 0x00000001805558F0-0x0000000180555910
	public void SetVisible(bool visible); // 0x0000000180555910-0x00000001805559C0
	public void Pause(); // 0x0000000180555790-0x00000001805557B0
	public void Resume(); // 0x0000000180555850-0x0000000180555860
	public void Tick(); // 0x0000000180555A50-0x0000000180555B60
	public void Destroy(); // 0x0000000180554AE0-0x0000000180554DA0
	private static IntPtr ResolveParentHwnd(); // 0x00000001805557B0-0x0000000180555850
	private void ApplyBounds(bool force); // 0x00000001805546A0-0x00000001805547D0
	private bool TryComputeBounds(out Rectangle bounds); // 0x0000000180555B60-0x0000000180555D90
}

