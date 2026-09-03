/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class WebView2PortalView : IWebPortalView // TypeDefIndex: 913
{
	// Fields
	private const float GAMEVIEW_TOOLBAR_POINTS = 21f; // Metadata: 0x0064CDC4
	private const string USER_DATA_SUBDIR = "webview2"; // Metadata: 0x0064CDC8
	private const string BRIDGE_SCRIPT = "window.Unity = window.Unity || {};window.Unity.call = function(m){ try { window.chrome.webview.postMessage(String(m)); } catch(e) {} };"; // Metadata: 0x0064CDD1
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
	public bool IsAlive { get; } // 0x0000000180467030-0x0000000180467050 

	// Nested types
	private struct POINT // TypeDefIndex: 914
	{
		// Fields
		public int X; // 0x00
		public int Y; // 0x04
	}

	private struct RECT // TypeDefIndex: 915
	{
		// Fields
		public int Left; // 0x00
		public int Top; // 0x04
		public int Right; // 0x08
		public int Bottom; // 0x0C
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 916
	{
		// Fields
		public WebView2PortalView __4__this; // 0x10
		public string msg; // 0x18

		// Constructors
		public __c__DisplayClass34_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _StartCreateAsync_b__0(); // 0x0000000180458310-0x0000000180458350
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass39_0 // TypeDefIndex: 917
	{
		// Fields
		public WebView2PortalView __4__this; // 0x10
		public string msg; // 0x18

		// Constructors
		public __c__DisplayClass39_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnWebMessageReceived_b__0(); // 0x0000000180458690-0x00000001804586D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass41_0 // TypeDefIndex: 918
	{
		// Fields
		public WebView2PortalView __4__this; // 0x10
		public string text; // 0x18

		// Constructors
		public __c__DisplayClass41_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnNavigationCompleted_b__0(); // 0x00000001804586D0-0x0000000180458710
		internal void _OnNavigationCompleted_b__1(); // 0x0000000180458710-0x0000000180458770
	}

	[CompilerGenerated]
	private struct _StartCreateAsync_d__34 : IAsyncStateMachine // TypeDefIndex: 919
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
		private void MoveNext(); // 0x0000000180457420-0x0000000180457D10
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000180457D10-0x0000000180457D20
	}

	// Constructors
	public WebView2PortalView(); // 0x0000000180466FB0-0x0000000180467030

	// Methods
	private static extern IntPtr GetActiveWindow(); // 0x0000000180465E30-0x0000000180465EA0
	private static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint); // 0x00000001804668F0-0x0000000180466980
	private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect); // 0x0000000180465EA0-0x0000000180465F30
	public static bool IsRuntimeAvailable(); // 0x0000000180466140-0x00000001804662B0
	public bool Create(Action<string> onMessage, Action onLoaded, Action<string> onError, Action<string> onHttpError = null); // 0x00000001804659C0-0x0000000180465B70
	private async void StartCreateAsync(); // 0x0000000180466A50-0x0000000180466AE0
	private void ApplySettings(); // 0x0000000180465930-0x00000001804659C0
	private void ApplyScale(); // 0x0000000180465860-0x0000000180465930
	private void HookEvents(); // 0x0000000180465F30-0x00000001804660C0
	private void UnhookEvents(); // 0x0000000180466E20-0x0000000180466FB0
	private void OnWebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e); // 0x00000001804666A0-0x0000000180466820
	private void OnNavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e); // 0x0000000180466530-0x0000000180466620
	private void OnNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e); // 0x00000001804663A0-0x0000000180466530
	private void OnNewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e); // 0x0000000180466620-0x00000001804666A0
	private static bool IsAllowedNavigation(string uri); // 0x00000001804660C0-0x0000000180466140
	public void Load(string url); // 0x00000001804662B0-0x00000001804663A0
	public void SetScreenMargins(int left, int top, int right, int bottom); // 0x0000000180466980-0x00000001804669A0
	public void SetVisible(bool visible); // 0x00000001804669A0-0x0000000180466A50
	public void Pause(); // 0x0000000180466820-0x0000000180466840
	public void Resume(); // 0x00000001804668E0-0x00000001804668F0
	public void Tick(); // 0x0000000180466AE0-0x0000000180466BF0
	public void Destroy(); // 0x0000000180465B70-0x0000000180465E30
	private static IntPtr ResolveParentHwnd(); // 0x0000000180466840-0x00000001804668E0
	private void ApplyBounds(bool force); // 0x0000000180465730-0x0000000180465860
	private bool TryComputeBounds(out Rectangle bounds); // 0x0000000180466BF0-0x0000000180466E20
}

