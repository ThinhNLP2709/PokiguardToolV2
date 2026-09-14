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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	private const float CLICK_DEBOUNCE = 0.8f; // Metadata: 0x005EED7C
	private bool _isTransitioning; // 0x88
	private ChatService _subscribedCs; // 0x90

	// Properties
	public static MatchmakingManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D6DB40-0x0000000180D6DB80 0x0000000180D6DB80-0x0000000180D6DC20

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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180D72280-0x0000000180D72360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D72360-0x0000000180D723A0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180D723A0-0x0000000180D72530
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D72530-0x0000000180D72570
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180D72570-0x0000000180D726F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D726F0-0x0000000180D72730
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
		private bool MoveNext(); // 0x0000000180D72730-0x0000000180D72B50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D72B50-0x0000000180D72B90
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180D72B90-0x0000000180D72C80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D72C80-0x0000000180D72CC0
	}

	// Constructors
	public MatchmakingManager(); // 0x0000000180D72220-0x0000000180D72280

	// Methods
	private void Awake(); // 0x0000000180D6DC20-0x0000000180D6DDA0
	private void Start(); // 0x0000000180D6DDA0-0x0000000180D6DF10
	private void OnDestroy(); // 0x0000000180D6DF10-0x0000000180D6E080
	private bool TrySubscribeWs(); // 0x0000000180D6E080-0x0000000180D6E560
	private void UnsubscribeWs(); // 0x0000000180D6E560-0x0000000180D6E960
	[IteratorStateMachine(typeof(_SearchingStatusCoroutine_d__27))]
	private IEnumerator SearchingStatusCoroutine(); // 0x0000000180D6E960-0x0000000180D6EA00
	private void StartSearchingStatus(); // 0x0000000180D6EA00-0x0000000180D6EB20
	private void StopStatusCoroutine(); // 0x0000000180D6EB20-0x0000000180D6EBA0
	public void StartSearching(); // 0x0000000180D6EBA0-0x0000000180D6F600
	[IteratorStateMachine(typeof(_SearchTimeoutCoroutine_d__31))]
	private IEnumerator SearchTimeoutCoroutine(); // 0x0000000180D6F600-0x0000000180D6F6A0
	[IteratorStateMachine(typeof(_StopSearchingSafely_d__32))]
	private IEnumerator StopSearchingSafely(); // 0x0000000180D6F6A0-0x0000000180D6F740
	[IteratorStateMachine(typeof(_ClearTransitioningAfter_d__33))]
	private IEnumerator ClearTransitioningAfter(float sec); // 0x0000000180D6F740-0x0000000180D6F800
	private void LockStartButton(bool locked); // 0x0000000180D6F800-0x0000000180D6F910
	private void HideBackButtons(); // 0x0000000180D6F910-0x0000000180D6FC30
	private void ShowBackButtons(); // 0x0000000180D6FC30-0x0000000180D6FE50
	public void ForceResetState(); // 0x0000000180D6FE50-0x0000000180D6FF50
	public void StopSearching(); // 0x0000000180D6FF50-0x0000000180D70300
	public void SetLobbyVisible(bool visible); // 0x0000000180D70300-0x0000000180D70450
	public void SetActiveButtonNeeded(bool cancel = false /* Metadata: 0x005EED79 */, bool BackQuangTruong = false /* Metadata: 0x005EED7A */, bool BackLobby = true /* Metadata: 0x005EED7B */); // 0x0000000180D70450-0x0000000180D707A0
	private static bool IsMmRoomProps(WsRoomService ws); // 0x0000000180D707A0-0x0000000180D70930
	public static string ExtractRoomIdDisplay(string roomName); // 0x0000000180D70930-0x0000000180D709F0
	private void HandleMatchmakingFound(ChatMessageDTO msg); // 0x0000000180D709F0-0x0000000180D70D30
	[IteratorStateMachine(typeof(_MmJoinWatchdog_d__44))]
	private IEnumerator MmJoinWatchdog(string roomId); // 0x0000000180D70D30-0x0000000180D70E40
	private void HandleMmRoomEntered(string roomId); // 0x0000000180D70E40-0x0000000180D711A0
	private void HandleMmRoomEnterFailed(string reason); // 0x0000000180D711A0-0x0000000180D71340
	private void UnhookRoomEvents(); // 0x0000000180D71340-0x0000000180D71420
	private void HandleMatchmakingFailed(string reason); // 0x0000000180D71420-0x0000000180D71710
	private void ShowPanel(bool show); // 0x0000000180D71710-0x0000000180D71980
	private void EnsureModalBlocker(); // 0x0000000180D71980-0x0000000180D71F30
	private void ShowModalBlocker(bool show); // 0x0000000180D71F30-0x0000000180D72220
}

