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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class MatchmakingManager : MonoBehaviour // TypeDefIndex: 250
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
	private const float CLICK_DEBOUNCE = 0.8f; // Metadata: 0x005ED9AC
	private bool _isTransitioning; // 0x88
	private ChatService _subscribedCs; // 0x90

	// Properties
	public static MatchmakingManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D5FD80-0x0000000180D5FDC0 0x0000000180D5FDC0-0x0000000180D5FE60

	// Nested types
	[CompilerGenerated]
	private sealed class _ClearTransitioningAfter_d__33 : IEnumerator<object> // TypeDefIndex: 251
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public MatchmakingManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClearTransitioningAfter_d__33(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180D644C0-0x0000000180D645A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D645A0-0x0000000180D645E0
	}

	[CompilerGenerated]
	private sealed class _MmJoinWatchdog_d__44 : IEnumerator<object> // TypeDefIndex: 252
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchmakingManager __4__this; // 0x20
		public string roomId; // 0x28
		private float _t_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _MmJoinWatchdog_d__44(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180D645E0-0x0000000180D64770
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D64770-0x0000000180D647B0
	}

	[CompilerGenerated]
	private sealed class _SearchTimeoutCoroutine_d__31 : IEnumerator<object> // TypeDefIndex: 253
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchmakingManager __4__this; // 0x20
		private float _elapsed_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SearchTimeoutCoroutine_d__31(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180D647B0-0x0000000180D64930
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D64930-0x0000000180D64970
	}

	[CompilerGenerated]
	private sealed class _SearchingStatusCoroutine_d__27 : IEnumerator<object> // TypeDefIndex: 254
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchmakingManager __4__this; // 0x20
		private string[] _dots_5__2; // 0x28
		private int _i_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SearchingStatusCoroutine_d__27(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180D64970-0x0000000180D64D90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D64D90-0x0000000180D64DD0
	}

	[CompilerGenerated]
	private sealed class _StopSearchingSafely_d__32 : IEnumerator<object> // TypeDefIndex: 255
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchmakingManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _StopSearchingSafely_d__32(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180D64DD0-0x0000000180D64EC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D64EC0-0x0000000180D64F00
	}

	// Constructors
	public MatchmakingManager(); // 0x0000000180D64460-0x0000000180D644C0

	// Methods
	private void Awake(); // 0x0000000180D5FE60-0x0000000180D5FFE0
	private void Start(); // 0x0000000180D5FFE0-0x0000000180D60150
	private void OnDestroy(); // 0x0000000180D60150-0x0000000180D602C0
	private bool TrySubscribeWs(); // 0x0000000180D602C0-0x0000000180D607A0
	private void UnsubscribeWs(); // 0x0000000180D607A0-0x0000000180D60BA0
	[IteratorStateMachine(typeof(_SearchingStatusCoroutine_d__27))]
	private IEnumerator SearchingStatusCoroutine(); // 0x0000000180D60BA0-0x0000000180D60C40
	private void StartSearchingStatus(); // 0x0000000180D60C40-0x0000000180D60D60
	private void StopStatusCoroutine(); // 0x0000000180D60D60-0x0000000180D60DE0
	public void StartSearching(); // 0x0000000180D60DE0-0x0000000180D61840
	[IteratorStateMachine(typeof(_SearchTimeoutCoroutine_d__31))]
	private IEnumerator SearchTimeoutCoroutine(); // 0x0000000180D61840-0x0000000180D618E0
	[IteratorStateMachine(typeof(_StopSearchingSafely_d__32))]
	private IEnumerator StopSearchingSafely(); // 0x0000000180D618E0-0x0000000180D61980
	[IteratorStateMachine(typeof(_ClearTransitioningAfter_d__33))]
	private IEnumerator ClearTransitioningAfter(float sec); // 0x0000000180D61980-0x0000000180D61A40
	private void LockStartButton(bool locked); // 0x0000000180D61A40-0x0000000180D61B50
	private void HideBackButtons(); // 0x0000000180D61B50-0x0000000180D61E70
	private void ShowBackButtons(); // 0x0000000180D61E70-0x0000000180D62090
	public void ForceResetState(); // 0x0000000180D62090-0x0000000180D62190
	public void StopSearching(); // 0x0000000180D62190-0x0000000180D62540
	public void SetLobbyVisible(bool visible); // 0x0000000180D62540-0x0000000180D62690
	public void SetActiveButtonNeeded(bool cancel = false /* Metadata: 0x005ED9A9 */, bool BackQuangTruong = false /* Metadata: 0x005ED9AA */, bool BackLobby = true /* Metadata: 0x005ED9AB */); // 0x0000000180D62690-0x0000000180D629E0
	private static bool IsMmRoomProps(WsRoomService ws); // 0x0000000180D629E0-0x0000000180D62B70
	public static string ExtractRoomIdDisplay(string roomName); // 0x0000000180D62B70-0x0000000180D62C30
	private void HandleMatchmakingFound(ChatMessageDTO msg); // 0x0000000180D62C30-0x0000000180D62F70
	[IteratorStateMachine(typeof(_MmJoinWatchdog_d__44))]
	private IEnumerator MmJoinWatchdog(string roomId); // 0x0000000180D62F70-0x0000000180D63080
	private void HandleMmRoomEntered(string roomId); // 0x0000000180D63080-0x0000000180D633E0
	private void HandleMmRoomEnterFailed(string reason); // 0x0000000180D633E0-0x0000000180D63580
	private void UnhookRoomEvents(); // 0x0000000180D63580-0x0000000180D63660
	private void HandleMatchmakingFailed(string reason); // 0x0000000180D63660-0x0000000180D63950
	private void ShowPanel(bool show); // 0x0000000180D63950-0x0000000180D63BC0
	private void EnsureModalBlocker(); // 0x0000000180D63BC0-0x0000000180D64170
	private void ShowModalBlocker(bool show); // 0x0000000180D64170-0x0000000180D64460
}

