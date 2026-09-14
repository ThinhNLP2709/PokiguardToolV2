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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class WebPortalService : MonoBehaviour // TypeDefIndex: 1515
{
	// Fields
	[CompilerGenerated]
	private static Action<int, int> OnRechargeSuccess; // 0x00
	[CompilerGenerated]
	private static Action OnPasswordChanged; // 0x08
	[CompilerGenerated]
	private static Action OnClosed; // 0x10
	public const string FLAG_KEY = "webportal.enabled"; // Metadata: 0x005F11CE
	private const float READY_TIMEOUT = 15f; // Metadata: 0x005F11E0
	private const int MAX_REOPEN = 2; // Metadata: 0x005F11E4
	private const float MARGIN_RECHECK = 0.5f; // Metadata: 0x005F11E5
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
	public static WebPortalService Instance { get; } // 0x0000000180834D80-0x0000000180834DC0 
	public bool IsOpen { get; } // 0x0000000180835250-0x0000000180835260 

	// Events
	public static event Action<int, int> OnRechargeSuccess {
		add; // 0x00000001808346A0-0x00000001808347D0
		remove; // 0x00000001808347D0-0x0000000180834900
	}
	public static event Action OnPasswordChanged {
		add; // 0x0000000180834900-0x0000000180834A20
		remove; // 0x0000000180834A20-0x0000000180834B40
	}
	public static event Action OnClosed {
		add; // 0x0000000180834B40-0x0000000180834C60
		remove; // 0x0000000180834C60-0x0000000180834D80
	}

	// Nested types
	[Serializable]
	private class TicketRequest // TypeDefIndex: 1516
	{
		// Fields
		public string purpose; // 0x10

		// Constructors
		public TicketRequest(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 1517
	{
		// Fields
		public WebPortalService __4__this; // 0x10
		public Transform canvasRoot; // 0x18
		public Action onReady; // 0x20

		// Constructors
		public __c__DisplayClass40_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OpenPanel_b__0(GameObject panel); // 0x0000000180839D40-0x000000018083A340
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 1518
	{
		// Fields
		public int token; // 0x10
		public WebPortalService __4__this; // 0x18
		public bool reopen; // 0x20

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RequestTicket_b__0(string raw); // 0x000000018083A340-0x000000018083A390
		internal void _RequestTicket_b__1(string err); // 0x000000018083A390-0x000000018083A490
	}

	[CompilerGenerated]
	private sealed class _PostGuestTicket_d__48 : IEnumerator<object> // TypeDefIndex: 1519
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
		void IDisposable.Dispose(); // 0x000000018083A490-0x000000018083A5C0
		private bool MoveNext(); // 0x000000018083A5C0-0x000000018083ABC0
		private void __m__Finally1(); // 0x000000018083ABC0-0x000000018083AC20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018083AC20-0x000000018083AC60
	}

	[CompilerGenerated]
	private sealed class _ReadyTimeout_d__66 : IEnumerator<object> // TypeDefIndex: 1520
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018083AC60-0x000000018083AE30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018083AE30-0x000000018083AE70
	}

	// Constructors
	public WebPortalService(); // 0x0000000180839CD0-0x0000000180839D30

	// Methods
	public static WebPortalService EnsureInstance(); // 0x0000000180834DC0-0x0000000180834FB0
	private void Awake(); // 0x0000000180834FB0-0x0000000180835250
	public static void Open(WebPortalPurpose purpose); // 0x0000000180835260-0x0000000180835290
	public static void OpenGuest(WebPortalPurpose purpose); // 0x0000000180835290-0x0000000180835370
	public static void CloseIfOpen(); // 0x0000000180835370-0x0000000180835490
	private void OpenInternal(WebPortalPurpose purpose, bool guest); // 0x0000000180835490-0x0000000180835650
	public void Close(); // 0x0000000180835650-0x0000000180835960
	private void OpenPanel(Action onReady); // 0x0000000180835960-0x0000000180835B80
	private GameObject BuildFallbackPanel(Transform parent); // 0x0000000180835B80-0x0000000180835F00
	private void WirePanel(); // 0x0000000180835F00-0x00000001808364A0
	private void Reload(); // 0x00000001808364A0-0x00000001808365D0
	private void RefreshHubUser(); // 0x00000001808365D0-0x0000000180836720
	private static Transform ResolveCanvasRoot(); // 0x0000000180836720-0x0000000180836A90
	private void RequestTicket(bool reopen); // 0x0000000180836A90-0x0000000180836FA0
	[IteratorStateMachine(typeof(_PostGuestTicket_d__48))]
	private IEnumerator PostGuestTicket(string purposeWire, Action<string> onOk, Action<string> onErr); // 0x0000000180836FA0-0x0000000180837100
	private void OnTicketResponse(string raw, bool reopen); // 0x0000000180837100-0x0000000180837510
	private void OnTicketError(string err); // 0x0000000180837510-0x00000001808375E0
	public static bool IsTrustedPortalUrl(string url); // 0x00000001808375E0-0x0000000180837A60
	private void LoadInWebView(string url); // 0x0000000180837A60-0x0000000180837B00
	private bool CreateWebView(); // 0x0000000180837B00-0x0000000180837F30
	private void DestroyWebView(); // 0x0000000180837F30-0x0000000180838080
	private void OpenExternal(string url); // 0x0000000180838080-0x0000000180838210
	private void OnWebLoaded(); // 0x0000000180838210-0x0000000180838220
	private void OnWebError(string msg); // 0x0000000180838220-0x00000001808382C0
	private void OnWebHttpError(string msg); // 0x00000001808382C0-0x0000000180838380
	private void MarkReady(); // 0x0000000180838380-0x00000001808384F0
	private void OnJsMessage(string raw); // 0x00000001808384F0-0x0000000180838A80
	private void HandleReopen(); // 0x0000000180838A80-0x0000000180838BD0
	private void HandleRechargeSuccess(int safiaAdded, int newBalance); // 0x0000000180838BD0-0x0000000180838E00
	private void HandleExternal(string url); // 0x0000000180838E00-0x0000000180838EF0
	private void StartTimeout(); // 0x0000000180838EF0-0x0000000180839010
	private void StopTimeout(); // 0x0000000180478B60-0x0000000180478BE0
	[IteratorStateMachine(typeof(_ReadyTimeout_d__66))]
	private IEnumerator ReadyTimeout(); // 0x0000000180839010-0x00000001808390B0
	private void ShowFatal(string message); // 0x00000001808390B0-0x0000000180839240
	private void Update(); // 0x0000000180839240-0x0000000180839430
	private void ApplyMargins(bool force); // 0x0000000180839430-0x0000000180839700
	private void OnApplicationPause(bool paused); // 0x0000000180839700-0x0000000180839770
	private void OnDestroy(); // 0x0000000180839770-0x0000000180839940
	private static void SafeRaise(Action ev); // 0x0000000180839940-0x0000000180839AD0
	private static void SafeRaise(Action<int, int> ev, int a, int b); // 0x0000000180839AD0-0x0000000180839CD0
	[CompilerGenerated]
	private void _OpenInternal_b__38_0(); // 0x0000000180839D30-0x0000000180839D40
}

