/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class WebPortalService : MonoBehaviour // TypeDefIndex: 1513
{
	// Fields
	[CompilerGenerated]
	private static Action<int, int> OnRechargeSuccess; // 0x00
	[CompilerGenerated]
	private static Action OnPasswordChanged; // 0x08
	[CompilerGenerated]
	private static Action OnClosed; // 0x10
	public const string FLAG_KEY = "webportal.enabled"; // Metadata: 0x005EFE01
	private const float READY_TIMEOUT = 15f; // Metadata: 0x005EFE13
	private const int MAX_REOPEN = 2; // Metadata: 0x005EFE17
	private const float MARGIN_RECHECK = 0.5f; // Metadata: 0x005EFE18
	private static WebPortalService _instance; // 0x18
	private PanelWebPortal _panel; // 0x20
	private GameObject _fallbackPanelGo; // 0x28
	private IWebPortalView _view; // 0x30
	private WebPortalPurpose _purpose; // 0x38
	private bool _guest; // 0x3C
	private bool _open; // 0x3D
	private bool _ready; // 0x3E
	private bool _ticketInFlight; // 0x3F
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
	public static WebPortalService Instance { get; } // 0x0000000180832C70-0x0000000180832CB0 
	public bool IsOpen { get; } // 0x0000000180833140-0x0000000180833150 

	// Events
	public static event Action<int, int> OnRechargeSuccess {
		add; // 0x0000000180832590-0x00000001808326C0
		remove; // 0x00000001808326C0-0x00000001808327F0
	}
	public static event Action OnPasswordChanged {
		add; // 0x00000001808327F0-0x0000000180832910
		remove; // 0x0000000180832910-0x0000000180832A30
	}
	public static event Action OnClosed {
		add; // 0x0000000180832A30-0x0000000180832B50
		remove; // 0x0000000180832B50-0x0000000180832C70
	}

	// Nested types
	[Serializable]
	private class TicketRequest // TypeDefIndex: 1514
	{
		// Fields
		public string purpose; // 0x10

		// Constructors
		public TicketRequest(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 1515
	{
		// Fields
		public WebPortalService __4__this; // 0x10
		public Transform canvasRoot; // 0x18
		public Action onReady; // 0x20

		// Constructors
		public __c__DisplayClass40_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OpenPanel_b__0(GameObject panel); // 0x0000000180837BF0-0x00000001808381F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 1516
	{
		// Fields
		public int token; // 0x10
		public WebPortalService __4__this; // 0x18
		public bool reopen; // 0x20

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RequestTicket_b__0(string raw); // 0x00000001808381F0-0x0000000180838240
		internal void _RequestTicket_b__1(string err); // 0x0000000180838240-0x0000000180838340
	}

	[CompilerGenerated]
	private sealed class _PostGuestTicket_d__48 : IEnumerator<object> // TypeDefIndex: 1517
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string purposeWire; // 0x20
		public Action<string> onOk; // 0x28
		public Action<string> onErr; // 0x30
		private UnityWebRequest _req_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PostGuestTicket_d__48(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180838340-0x0000000180838470
		private bool MoveNext(); // 0x0000000180838470-0x0000000180838A70
		private void __m__Finally1(); // 0x0000000180838A70-0x0000000180838AD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180838AD0-0x0000000180838B10
	}

	[CompilerGenerated]
	private sealed class _ReadyTimeout_d__66 : IEnumerator<object> // TypeDefIndex: 1518
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WebPortalService __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ReadyTimeout_d__66(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180838B10-0x0000000180838CE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180838CE0-0x0000000180838D20
	}

	// Constructors
	public WebPortalService(); // 0x0000000180837B80-0x0000000180837BE0

	// Methods
	public static WebPortalService EnsureInstance(); // 0x0000000180832CB0-0x0000000180832EA0
	private void Awake(); // 0x0000000180832EA0-0x0000000180833140
	public static void Open(WebPortalPurpose purpose); // 0x0000000180833150-0x0000000180833180
	public static void OpenGuest(WebPortalPurpose purpose); // 0x0000000180833180-0x0000000180833260
	public static void CloseIfOpen(); // 0x0000000180833260-0x0000000180833380
	private void OpenInternal(WebPortalPurpose purpose, bool guest); // 0x0000000180833380-0x0000000180833540
	public void Close(); // 0x0000000180833540-0x0000000180833850
	private void OpenPanel(Action onReady); // 0x0000000180833850-0x0000000180833A70
	private GameObject BuildFallbackPanel(Transform parent); // 0x0000000180833A70-0x0000000180833DF0
	private void WirePanel(); // 0x0000000180833DF0-0x0000000180834390
	private void Reload(); // 0x0000000180834390-0x00000001808344C0
	private void RefreshHubUser(); // 0x00000001808344C0-0x0000000180834610
	private static Transform ResolveCanvasRoot(); // 0x0000000180834610-0x0000000180834980
	private void RequestTicket(bool reopen); // 0x0000000180834980-0x0000000180834E50
	[IteratorStateMachine(typeof(_PostGuestTicket_d__48))]
	private IEnumerator PostGuestTicket(string purposeWire, Action<string> onOk, Action<string> onErr); // 0x0000000180834E50-0x0000000180834FB0
	private void OnTicketResponse(string raw, bool reopen); // 0x0000000180834FB0-0x00000001808353C0
	private void OnTicketError(string err); // 0x00000001808353C0-0x0000000180835490
	public static bool IsTrustedPortalUrl(string url); // 0x0000000180835490-0x0000000180835910
	private void LoadInWebView(string url); // 0x0000000180835910-0x00000001808359B0
	private bool CreateWebView(); // 0x00000001808359B0-0x0000000180835DE0
	private void DestroyWebView(); // 0x0000000180835DE0-0x0000000180835F30
	private void OpenExternal(string url); // 0x0000000180835F30-0x00000001808360C0
	private void OnWebLoaded(); // 0x00000001808360C0-0x00000001808360D0
	private void OnWebError(string msg); // 0x00000001808360D0-0x0000000180836170
	private void OnWebHttpError(string msg); // 0x0000000180836170-0x0000000180836230
	private void MarkReady(); // 0x0000000180836230-0x00000001808363A0
	private void OnJsMessage(string raw); // 0x00000001808363A0-0x0000000180836930
	private void HandleReopen(); // 0x0000000180836930-0x0000000180836A80
	private void HandleRechargeSuccess(int safiaAdded, int newBalance); // 0x0000000180836A80-0x0000000180836CB0
	private void HandleExternal(string url); // 0x0000000180836CB0-0x0000000180836DA0
	private void StartTimeout(); // 0x0000000180836DA0-0x0000000180836EC0
	private void StopTimeout(); // 0x00000001804778F0-0x0000000180477970
	[IteratorStateMachine(typeof(_ReadyTimeout_d__66))]
	private IEnumerator ReadyTimeout(); // 0x0000000180836EC0-0x0000000180836F60
	private void ShowFatal(string message); // 0x0000000180836F60-0x00000001808370F0
	private void Update(); // 0x00000001808370F0-0x00000001808372E0
	private void ApplyMargins(bool force); // 0x00000001808372E0-0x00000001808375B0
	private void OnApplicationPause(bool paused); // 0x00000001808375B0-0x0000000180837620
	private void OnDestroy(); // 0x0000000180837620-0x00000001808377F0
	private static void SafeRaise(Action ev); // 0x00000001808377F0-0x0000000180837980
	private static void SafeRaise(Action<int, int> ev, int a, int b); // 0x0000000180837980-0x0000000180837B80
	[CompilerGenerated]
	private void _OpenInternal_b__38_0(); // 0x0000000180837BE0-0x0000000180837BF0
}

