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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

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
	private const float CLICK_DEBOUNCE = 0.8f; // Metadata: 0x0068AD81
	private bool _isTransitioning; // 0x88
	private ChatService _subscribedCs; // 0x90

	// Properties
	public static MatchmakingManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808481F0-0x0000000180848230 0x0000000180848230-0x0000000180848290

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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClearTransitioningAfter_d__33(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180851D90-0x0000000180851E50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180851E50-0x0000000180851E90
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _MmJoinWatchdog_d__44(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180852670-0x00000001808527B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808527B0-0x00000001808527F0
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SearchTimeoutCoroutine_d__31(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001808528C0-0x00000001808529C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808529C0-0x0000000180852A00
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SearchingStatusCoroutine_d__27(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180852A00-0x0000000180852DA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180852DA0-0x0000000180852DE0
	}

	[CompilerGenerated]
	private sealed class _StopSearchingSafely_d__32 : IEnumerator<object> // TypeDefIndex: 255
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchmakingManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _StopSearchingSafely_d__32(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180852DE0-0x0000000180852EA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180852EA0-0x0000000180852EE0
	}

	// Constructors
	public MatchmakingManager(); // 0x00000001808481D0-0x00000001808481F0

	// Methods
	private void Awake(); // 0x0000000180845BD0-0x0000000180845CC0
	private void Start(); // 0x00000001808479D0-0x0000000180847AB0
	private void OnDestroy(); // 0x0000000180846B90-0x0000000180846C70
	private bool TrySubscribeWs(); // 0x0000000180847E30-0x0000000180847FC0
	private void UnsubscribeWs(); // 0x0000000180848090-0x00000001808481D0
	[IteratorStateMachine(typeof(_SearchingStatusCoroutine_d__27))]
	private IEnumerator SearchingStatusCoroutine(); // 0x0000000180846CE0-0x0000000180846D50
	private void StartSearchingStatus(); // 0x0000000180847240-0x00000001808472E0
	private void StopStatusCoroutine(); // 0x0000000180847DF0-0x0000000180847E30
	public void StartSearching(); // 0x00000001808472E0-0x00000001808479D0
	[IteratorStateMachine(typeof(_SearchTimeoutCoroutine_d__31))]
	private IEnumerator SearchTimeoutCoroutine(); // 0x0000000180846C70-0x0000000180846CE0
	[IteratorStateMachine(typeof(_StopSearchingSafely_d__32))]
	private IEnumerator StopSearchingSafely(); // 0x0000000180847AB0-0x0000000180847B20
	[IteratorStateMachine(typeof(_ClearTransitioningAfter_d__33))]
	private IEnumerator ClearTransitioningAfter(float sec); // 0x0000000180845CC0-0x0000000180845D40
	private void LockStartButton(bool locked); // 0x0000000180846A70-0x0000000180846B00
	private void HideBackButtons(); // 0x00000001808468C0-0x00000001808469B0
	private void ShowBackButtons(); // 0x0000000180846EF0-0x0000000180846FC0
	public void ForceResetState(); // 0x0000000180846150-0x0000000180846230
	public void StopSearching(); // 0x0000000180847B20-0x0000000180847DF0
	public void SetLobbyVisible(bool visible); // 0x0000000180846E60-0x0000000180846EF0
	public void SetActiveButtonNeeded(bool cancel = false /* Metadata: 0x0068AD7E */, bool BackQuangTruong = false /* Metadata: 0x0068AD7F */, bool BackLobby = true /* Metadata: 0x0068AD80 */); // 0x0000000180846D50-0x0000000180846E60
	private static bool IsMmRoomProps(WsRoomService ws); // 0x00000001808469B0-0x0000000180846A70
	public static string ExtractRoomIdDisplay(string roomName); // 0x00000001808460A0-0x0000000180846150
	private void HandleMatchmakingFound(ChatMessageDTO msg); // 0x00000001808463E0-0x0000000180846670
	[IteratorStateMachine(typeof(_MmJoinWatchdog_d__44))]
	private IEnumerator MmJoinWatchdog(string roomId); // 0x0000000180846B00-0x0000000180846B90
	private void HandleMmRoomEntered(string roomId); // 0x0000000180846780-0x00000001808468C0
	private void HandleMmRoomEnterFailed(string reason); // 0x0000000180846670-0x0000000180846780
	private void UnhookRoomEvents(); // 0x0000000180847FC0-0x0000000180848090
	private void HandleMatchmakingFailed(string reason); // 0x0000000180846230-0x00000001808463E0
	private void ShowPanel(bool show); // 0x00000001808470B0-0x0000000180847240
	private void EnsureModalBlocker(); // 0x0000000180845D40-0x00000001808460A0
	private void ShowModalBlocker(bool show); // 0x0000000180846FC0-0x00000001808470B0
}

