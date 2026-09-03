/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class MatchmakingManager : MonoBehaviour // TypeDefIndex: 224
{
	// Fields
	[CompilerGenerated]
	private static MatchmakingManager _Instance_k__BackingField; // 0x00
	public float searchTimeout; // 0x20
	[Header("UI t\u00ECm tr\u1EADn")]
	public GameObject panelSearching; // 0x28
	public UnityEngine.UI.Text txtStatus; // 0x30
	public GameObject BtnBackLobby; // 0x38
	public GameObject BtnBackQuangTruong; // 0x40
	public Button btnCancel; // 0x48
	[Header("Lobby panel (optional)")]
	[Tooltip("Panel lobby PVP \u2014 g\u00E1n n\u1EBFu mu\u1ED1n SetLobbyVisible() \u0111i\u1EC1u khi\u1EC3n. B\u1ECF tr\u1ED1ng c\u0169ng OK.")]
	public GameObject lobbyPanel; // 0x50
	[Header("Gh\u00E9p tr\u1EADn button (optional \u2014 auto-disable khi click)")]
	[Tooltip("Button \'Gh\u00E9p tr\u1EADn\' \u2014 g\u00E1n \u0111\u1EC3 auto-lock sau khi click, tr\u00E1nh spam")]
	public Button btnStartMatchmaking; // 0x58
	[Header("Modal Blocker (optional \u2014 \u0111\u1EC3 tr\u1ED1ng s\u1EBD auto-t\u1EA1o)")]
	[Tooltip("GameObject full-screen ch\u1EB7n click xuy\u00EAn xu\u1ED1ng UI kh\u00E1c khi \u0111ang searching. N\u1EBFu null s\u1EBD auto-t\u1EA1o.")]
	public GameObject modalBlocker; // 0x60
	internal bool _isSearching; // 0x68
	internal bool _waitingInRoom; // 0x69
	private Coroutine _statusCoroutine; // 0x70
	private Coroutine _timeoutCoroutine; // 0x78
	private float _searchElapsedSeconds; // 0x80
	private float _lastClickTime; // 0x84
	private const float CLICK_DEBOUNCE = 0.8f; // Metadata: 0x0064C069
	private bool _isTransitioning; // 0x88
	private ChatService _subscribedCs; // 0x90

	// Properties
	public static MatchmakingManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180695980-0x00000001806959C0 0x00000001806959C0-0x0000000180695A20

	// Nested types
	[CompilerGenerated]
	private sealed class _ClearTransitioningAfter_d__33 : IEnumerator<object> // TypeDefIndex: 225
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public MatchmakingManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClearTransitioningAfter_d__33(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806A4650-0x00000001806A4710
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A4710-0x00000001806A4750
	}

	[CompilerGenerated]
	private sealed class _MmJoinWatchdog_d__44 : IEnumerator<object> // TypeDefIndex: 226
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchmakingManager __4__this; // 0x20
		public string roomId; // 0x28
		private float _t_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _MmJoinWatchdog_d__44(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806A4F30-0x00000001806A5070
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A5070-0x00000001806A50B0
	}

	[CompilerGenerated]
	private sealed class _SearchTimeoutCoroutine_d__31 : IEnumerator<object> // TypeDefIndex: 227
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchmakingManager __4__this; // 0x20
		private float _elapsed_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SearchTimeoutCoroutine_d__31(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806A50B0-0x00000001806A51B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A51B0-0x00000001806A51F0
	}

	[CompilerGenerated]
	private sealed class _SearchingStatusCoroutine_d__27 : IEnumerator<object> // TypeDefIndex: 228
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchmakingManager __4__this; // 0x20
		private string[] _dots_5__2; // 0x28
		private int _i_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SearchingStatusCoroutine_d__27(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001806A51F0-0x00000001806A5590
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A5590-0x00000001806A55D0
	}

	[CompilerGenerated]
	private sealed class _StopSearchingSafely_d__32 : IEnumerator<object> // TypeDefIndex: 229
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchmakingManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _StopSearchingSafely_d__32(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806A55D0-0x00000001806A5690
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A5690-0x00000001806A56D0
	}

	// Constructors
	public MatchmakingManager(); // 0x0000000180695960-0x0000000180695980

	// Methods
	private void Awake(); // 0x0000000180693360-0x0000000180693450
	private void Start(); // 0x0000000180695160-0x0000000180695240
	private void OnDestroy(); // 0x0000000180694320-0x0000000180694400
	private bool TrySubscribeWs(); // 0x00000001806955C0-0x0000000180695750
	private void UnsubscribeWs(); // 0x0000000180695820-0x0000000180695960
	[IteratorStateMachine(typeof(_SearchingStatusCoroutine_d__27))]
	private IEnumerator SearchingStatusCoroutine(); // 0x0000000180694470-0x00000001806944E0
	private void StartSearchingStatus(); // 0x00000001806949D0-0x0000000180694A70
	private void StopStatusCoroutine(); // 0x0000000180695580-0x00000001806955C0
	public void StartSearching(); // 0x0000000180694A70-0x0000000180695160
	[IteratorStateMachine(typeof(_SearchTimeoutCoroutine_d__31))]
	private IEnumerator SearchTimeoutCoroutine(); // 0x0000000180694400-0x0000000180694470
	[IteratorStateMachine(typeof(_StopSearchingSafely_d__32))]
	private IEnumerator StopSearchingSafely(); // 0x0000000180695240-0x00000001806952B0
	[IteratorStateMachine(typeof(_ClearTransitioningAfter_d__33))]
	private IEnumerator ClearTransitioningAfter(float sec); // 0x0000000180693450-0x00000001806934D0
	private void LockStartButton(bool locked); // 0x0000000180694200-0x0000000180694290
	private void HideBackButtons(); // 0x0000000180694050-0x0000000180694140
	private void ShowBackButtons(); // 0x0000000180694680-0x0000000180694750
	public void ForceResetState(); // 0x00000001806938E0-0x00000001806939C0
	public void StopSearching(); // 0x00000001806952B0-0x0000000180695580
	public void SetLobbyVisible(bool visible); // 0x00000001806945F0-0x0000000180694680
	public void SetActiveButtonNeeded(bool cancel = false /* Metadata: 0x0064C066 */, bool BackQuangTruong = false /* Metadata: 0x0064C067 */, bool BackLobby = true /* Metadata: 0x0064C068 */); // 0x00000001806944E0-0x00000001806945F0
	private static bool IsMmRoomProps(WsRoomService ws); // 0x0000000180694140-0x0000000180694200
	public static string ExtractRoomIdDisplay(string roomName); // 0x0000000180693830-0x00000001806938E0
	private void HandleMatchmakingFound(ChatMessageDTO msg); // 0x0000000180693B70-0x0000000180693E00
	[IteratorStateMachine(typeof(_MmJoinWatchdog_d__44))]
	private IEnumerator MmJoinWatchdog(string roomId); // 0x0000000180694290-0x0000000180694320
	private void HandleMmRoomEntered(string roomId); // 0x0000000180693F10-0x0000000180694050
	private void HandleMmRoomEnterFailed(string reason); // 0x0000000180693E00-0x0000000180693F10
	private void UnhookRoomEvents(); // 0x0000000180695750-0x0000000180695820
	private void HandleMatchmakingFailed(string reason); // 0x00000001806939C0-0x0000000180693B70
	private void ShowPanel(bool show); // 0x0000000180694840-0x00000001806949D0
	private void EnsureModalBlocker(); // 0x00000001806934D0-0x0000000180693830
	private void ShowModalBlocker(bool show); // 0x0000000180694750-0x0000000180694840
}

