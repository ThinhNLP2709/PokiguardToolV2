/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class WebPortalService : MonoBehaviour // TypeDefIndex: 908
{
	// Fields
	[CompilerGenerated]
	private static Action<int, int> OnRechargeSuccess; // 0x00
	[CompilerGenerated]
	private static Action OnPasswordChanged; // 0x08
	[CompilerGenerated]
	private static Action OnClosed; // 0x10
	public const string FLAG_KEY = "webportal.enabled"; // Metadata: 0x0064CDA9
	private const float READY_TIMEOUT = 15f; // Metadata: 0x0064CDBB
	private const int MAX_REOPEN = 2; // Metadata: 0x0064CDBF
	private const float MARGIN_RECHECK = 0.5f; // Metadata: 0x0064CDC0
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
	public static WebPortalService Instance { get; } // 0x0000000180465490-0x00000001804654D0 
	public bool IsOpen { get; } // 0x00000001804654D0-0x00000001804654E0 

	// Events
	public static event Action<int, int> OnRechargeSuccess {
		add; // 0x00000001804653C0-0x0000000180465490
		remove; // 0x0000000180465660-0x0000000180465730
	}
	public static event Action OnPasswordChanged {
		add; // 0x0000000180465300-0x00000001804653C0
		remove; // 0x00000001804655A0-0x0000000180465660
	}
	public static event Action OnClosed {
		add; // 0x0000000180465240-0x0000000180465300
		remove; // 0x00000001804654E0-0x00000001804655A0
	}

	// Nested types
	[Serializable]
	private class TicketRequest // TypeDefIndex: 909
	{
		// Fields
		public string purpose; // 0x10

		// Constructors
		public TicketRequest(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass38_0 // TypeDefIndex: 910
	{
		// Fields
		public WebPortalService __4__this; // 0x10
		public Transform canvasRoot; // 0x18
		public Action onReady; // 0x20

		// Constructors
		public __c__DisplayClass38_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OpenPanel_b__0(GameObject panel); // 0x0000000180458350-0x0000000180458690
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass45_0 // TypeDefIndex: 911
	{
		// Fields
		public int token; // 0x10
		public WebPortalService __4__this; // 0x18
		public bool reopen; // 0x20

		// Constructors
		public __c__DisplayClass45_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RequestTicket_b__0(string raw); // 0x0000000180458970-0x00000001804589C0
		internal void _RequestTicket_b__1(string err); // 0x00000001804589C0-0x0000000180458AB0
	}

	[CompilerGenerated]
	private sealed class _ReadyTimeout_d__63 : IEnumerator<object> // TypeDefIndex: 912
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WebPortalService __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ReadyTimeout_d__63(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180455F10-0x0000000180456030
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180456030-0x0000000180456070
	}

	// Constructors
	public WebPortalService(); // 0x0000000180465220-0x0000000180465240

	// Methods
	public static WebPortalService EnsureInstance(); // 0x00000001804625E0-0x0000000180462700
	private void Awake(); // 0x0000000180461C30-0x0000000180461D30
	public static void Open(WebPortalPurpose purpose); // 0x0000000180463F60-0x0000000180464200
	public static void CloseIfOpen(); // 0x0000000180461F20-0x0000000180461FC0
	private void OpenInternal(WebPortalPurpose purpose); // 0x0000000180463B80-0x0000000180463D00
	public void Close(); // 0x0000000180461FC0-0x0000000180462180
	private void OpenPanel(Action onReady); // 0x0000000180463D00-0x0000000180463F60
	private GameObject BuildFallbackPanel(Transform parent); // 0x0000000180461D30-0x0000000180461F20
	private void WirePanel(); // 0x0000000180464ED0-0x0000000180465220
	private void Reload(); // 0x0000000180464340-0x00000001804643F0
	private void RefreshHubUser(); // 0x0000000180464270-0x0000000180464340
	private static Transform ResolveCanvasRoot(); // 0x0000000180464600-0x0000000180464740
	private void RequestTicket(bool reopen); // 0x00000001804643F0-0x0000000180464600
	private void OnTicketResponse(string raw, bool reopen); // 0x0000000180463490-0x0000000180463880
	private void OnTicketError(string err); // 0x00000001804633D0-0x0000000180463490
	public static bool IsTrustedPortalUrl(string url); // 0x00000001804629E0-0x0000000180462B80
	private void LoadInWebView(string url); // 0x0000000180462B80-0x0000000180462C90
	private bool CreateWebView(); // 0x0000000180462180-0x00000001804624E0
	private void DestroyWebView(); // 0x00000001804624E0-0x00000001804625E0
	private void OpenExternal(string url); // 0x00000001804639C0-0x0000000180463B80
	private void OnWebLoaded(); // 0x00000001804639B0-0x00000001804639C0
	private void OnWebError(string msg); // 0x0000000180463880-0x0000000180463910
	private void OnWebHttpError(string msg); // 0x0000000180463910-0x00000001804639B0
	private void MarkReady(); // 0x0000000180462C90-0x0000000180462DA0
	private void OnJsMessage(string raw); // 0x0000000180462EC0-0x00000001804633D0
	private void HandleReopen(); // 0x0000000180462920-0x00000001804629E0
	private void HandleRechargeSuccess(int safiaAdded, int newBalance); // 0x00000001804627D0-0x0000000180462920
	private void HandleExternal(string url); // 0x0000000180462700-0x00000001804627D0
	private void StartTimeout(); // 0x0000000180464CB0-0x0000000180464D60
	private void StopTimeout(); // 0x000000018030CEC0-0x000000018030CF00
	[IteratorStateMachine(typeof(_ReadyTimeout_d__63))]
	private IEnumerator ReadyTimeout(); // 0x0000000180464200-0x0000000180464270
	private void ShowFatal(string message); // 0x0000000180464AB0-0x0000000180464CB0
	private void Update(); // 0x0000000180464D70-0x0000000180464ED0
	private void ApplyMargins(bool force); // 0x00000001804619F0-0x0000000180461C30
	private void OnApplicationPause(bool paused); // 0x0000000180462DA0-0x0000000180462E00
	private void OnDestroy(); // 0x0000000180462E00-0x0000000180462EC0
	private static void SafeRaise(Action ev); // 0x0000000180464740-0x00000001804648D0
	private static void SafeRaise(Action<int, int> ev, int a, int b); // 0x00000001804648D0-0x0000000180464AB0
	[CompilerGenerated]
	private void _OpenInternal_b__36_0(); // 0x0000000180464D60-0x0000000180464D70
}

