/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class WebPortalService : MonoBehaviour // TypeDefIndex: 1102
{
	// Fields
	[CompilerGenerated]
	private static Action<int, int> OnRechargeSuccess; // 0x00
	[CompilerGenerated]
	private static Action OnPasswordChanged; // 0x08
	[CompilerGenerated]
	private static Action OnClosed; // 0x10
	public const string FLAG_KEY = "webportal.enabled"; // Metadata: 0x0068C54F
	private const float READY_TIMEOUT = 15f; // Metadata: 0x0068C561
	private const int MAX_REOPEN = 2; // Metadata: 0x0068C565
	private const float MARGIN_RECHECK = 0.5f; // Metadata: 0x0068C566
	private static WebPortalService _instance; // 0x18
	private PanelWebPortal _panel; // 0x20
	private GameObject _fallbackPanelGo; // 0x28
	private IWebPortalView _view; // 0x30
	private WebPortalPurpose _purpose; // 0x38
	private bool _open; // 0x3C
	private bool _ready; // 0x3D
	private bool _ticketInFlight; // 0x3E
	private int _reopenCount; // 0x40
	private string _lastUrl; // 0x48
	private int _openToken; // 0x50
	private Coroutine _timeoutCo; // 0x58
	private int _lastScreenW; // 0x60
	private int _lastScreenH; // 0x64
	private float _marginTimer; // 0x68
	private int _lastL; // 0x6C
	private int _lastT; // 0x70
	private int _lastR; // 0x74
	private int _lastB; // 0x78

	// Properties
	public static WebPortalService Instance { get; } // 0x0000000180554400-0x0000000180554440 
	public bool IsOpen { get; } // 0x0000000180554440-0x0000000180554450 

	// Events
	public static event Action<int, int> OnRechargeSuccess {
		add; // 0x0000000180554330-0x0000000180554400
		remove; // 0x00000001805545D0-0x00000001805546A0
	}
	public static event Action OnPasswordChanged {
		add; // 0x0000000180554270-0x0000000180554330
		remove; // 0x0000000180554510-0x00000001805545D0
	}
	public static event Action OnClosed {
		add; // 0x00000001805541B0-0x0000000180554270
		remove; // 0x0000000180554450-0x0000000180554510
	}

	// Nested types
	[Serializable]
	private class TicketRequest // TypeDefIndex: 1103
	{
		// Fields
		public string purpose; // 0x10

		// Constructors
		public TicketRequest(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass38_0 // TypeDefIndex: 1104
	{
		// Fields
		public WebPortalService __4__this; // 0x10
		public Transform canvasRoot; // 0x18
		public Action onReady; // 0x20

		// Constructors
		public __c__DisplayClass38_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OpenPanel_b__0(GameObject panel); // 0x000000018054AB60-0x000000018054AEA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass45_0 // TypeDefIndex: 1105
	{
		// Fields
		public int token; // 0x10
		public WebPortalService __4__this; // 0x18
		public bool reopen; // 0x20

		// Constructors
		public __c__DisplayClass45_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RequestTicket_b__0(string raw); // 0x000000018054B1A0-0x000000018054B1F0
		internal void _RequestTicket_b__1(string err); // 0x000000018054B1F0-0x000000018054B2E0
	}

	[CompilerGenerated]
	private sealed class _ReadyTimeout_d__63 : IEnumerator<object> // TypeDefIndex: 1106
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WebPortalService __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ReadyTimeout_d__63(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180548290-0x00000001805483B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805483B0-0x00000001805483F0
	}

	// Constructors
	public WebPortalService(); // 0x0000000180554190-0x00000001805541B0

	// Methods
	public static WebPortalService EnsureInstance(); // 0x0000000180551550-0x0000000180551670
	private void Awake(); // 0x0000000180550BA0-0x0000000180550CA0
	public static void Open(WebPortalPurpose purpose); // 0x0000000180552ED0-0x0000000180553170
	public static void CloseIfOpen(); // 0x0000000180550E90-0x0000000180550F30
	private void OpenInternal(WebPortalPurpose purpose); // 0x0000000180552AF0-0x0000000180552C70
	public void Close(); // 0x0000000180550F30-0x00000001805510F0
	private void OpenPanel(Action onReady); // 0x0000000180552C70-0x0000000180552ED0
	private GameObject BuildFallbackPanel(Transform parent); // 0x0000000180550CA0-0x0000000180550E90
	private void WirePanel(); // 0x0000000180553E40-0x0000000180554190
	private void Reload(); // 0x00000001805532B0-0x0000000180553360
	private void RefreshHubUser(); // 0x00000001805531E0-0x00000001805532B0
	private static Transform ResolveCanvasRoot(); // 0x0000000180553570-0x00000001805536B0
	private void RequestTicket(bool reopen); // 0x0000000180553360-0x0000000180553570
	private void OnTicketResponse(string raw, bool reopen); // 0x0000000180552400-0x00000001805527F0
	private void OnTicketError(string err); // 0x0000000180552340-0x0000000180552400
	public static bool IsTrustedPortalUrl(string url); // 0x0000000180551950-0x0000000180551AF0
	private void LoadInWebView(string url); // 0x0000000180551AF0-0x0000000180551C00
	private bool CreateWebView(); // 0x00000001805510F0-0x0000000180551450
	private void DestroyWebView(); // 0x0000000180551450-0x0000000180551550
	private void OpenExternal(string url); // 0x0000000180552930-0x0000000180552AF0
	private void OnWebLoaded(); // 0x0000000180552920-0x0000000180552930
	private void OnWebError(string msg); // 0x00000001805527F0-0x0000000180552880
	private void OnWebHttpError(string msg); // 0x0000000180552880-0x0000000180552920
	private void MarkReady(); // 0x0000000180551C00-0x0000000180551D10
	private void OnJsMessage(string raw); // 0x0000000180551E30-0x0000000180552340
	private void HandleReopen(); // 0x0000000180551890-0x0000000180551950
	private void HandleRechargeSuccess(int safiaAdded, int newBalance); // 0x0000000180551740-0x0000000180551890
	private void HandleExternal(string url); // 0x0000000180551670-0x0000000180551740
	private void StartTimeout(); // 0x0000000180553C20-0x0000000180553CD0
	private void StopTimeout(); // 0x0000000180423640-0x0000000180423680
	[IteratorStateMachine(typeof(_ReadyTimeout_d__63))]
	private IEnumerator ReadyTimeout(); // 0x0000000180553170-0x00000001805531E0
	private void ShowFatal(string message); // 0x0000000180553A20-0x0000000180553C20
	private void Update(); // 0x0000000180553CE0-0x0000000180553E40
	private void ApplyMargins(bool force); // 0x0000000180550960-0x0000000180550BA0
	private void OnApplicationPause(bool paused); // 0x0000000180551D10-0x0000000180551D70
	private void OnDestroy(); // 0x0000000180551D70-0x0000000180551E30
	private static void SafeRaise(Action ev); // 0x00000001805536B0-0x0000000180553840
	private static void SafeRaise(Action<int, int> ev, int a, int b); // 0x0000000180553840-0x0000000180553A20
	[CompilerGenerated]
	private void _OpenInternal_b__36_0(); // 0x0000000180553CD0-0x0000000180553CE0
}

