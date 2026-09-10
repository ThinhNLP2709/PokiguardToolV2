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

public class Room_Handler : MonoBehaviour, IHubSuspendable // TypeDefIndex: 52
{
	// Fields
	public static Room_Handler Instance; // 0x00
	[Header("Room Settings")]
	[SerializeField]
	private byte maxPlayers; // 0x20
	[Header("UI")]
	public GameObject panelRoom; // 0x28
	[Header("Ready Button Settings")]
	[SerializeField]
	internal Button readyButton; // 0x30
	[SerializeField]
	internal Color disabledColor; // 0x38
	public string currentRoomName; // 0x48
	public Transform[] panelCard; // 0x50
	internal ManagerRoom managerRoom; // 0x58
	private string _lastKnownOwner; // 0x60
	private Button _btnLockRoom; // 0x68
	private UnityEngine.UI.Text _btnLockRoomLabel; // 0x70
	private static bool _forceCloseRoomOnReturn; // 0x08
	private const int SEND_PROPS_MAX_RETRY = 3; // Metadata: 0x0068AA60
	private bool _slotsRefreshPending; // 0x78
	private int _lastSlotsRefreshFrame; // 0x7C

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadRoomThenHideGlobalLoading_d__38 : IEnumerator<object> // TypeDefIndex: 53
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom mgr; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoomThenHideGlobalLoading_d__38(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180315E00-0x0000000180315F00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180315F00-0x0000000180315F40
	}

	[CompilerGenerated]
	private sealed class _WaitForDataAndSend_d__41 : IEnumerator<object> // TypeDefIndex: 54
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom manager; // 0x20
		public Room_Handler __4__this; // 0x28
		public int slotIndex; // 0x30
		private float _timeout_5__2; // 0x34
		private float _elapsed_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitForDataAndSend_d__41(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180317260-0x0000000180317500
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180317500-0x0000000180317540
	}

	[CompilerGenerated]
	private sealed class _WaitToGetData_d__45 : IEnumerator<object> // TypeDefIndex: 55
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float s; // 0x20
		public Room_Handler __4__this; // 0x28
		public int slotIndex; // 0x30
		public UserDTO user; // 0x38
		public ManagerRoom manager; // 0x40
		public int retryCount; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitToGetData_d__45(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180317650-0x0000000180317720
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180317720-0x0000000180317760
	}

	// Constructors
	public Room_Handler(); // 0x0000000180314830-0x0000000180314870

	// Methods
	private void Awake(); // 0x00000001803101A0-0x00000001803105A0
	private void OnDestroy(); // 0x0000000180312390-0x0000000180312710
	private void HandleWsStartMatchFailed(ChatMessageDTO msg); // 0x0000000180311600-0x0000000180311780
	private void HandleWsRoomEnteredLobby(string roomId); // 0x0000000180311190-0x0000000180311470
	private int ResolveMySlotFromWs(); // 0x0000000180313B00-0x0000000180313D90
	private void HandleWsMembersChanged(); // 0x0000000180310F50-0x00000001803110B0
	private void HandleWsKickFailed(string reason); // 0x0000000180310B70-0x0000000180310BD0
	private void HandleWsKicked(string reason); // 0x0000000180310BD0-0x0000000180310F50
	private void HandleWsRoomLeft(string oldRoomId); // 0x0000000180311470-0x0000000180311600
	private void HandleWsPlayerStatesChanged(); // 0x00000001803110B0-0x00000001803110F0
	public static bool IsRoomOwner(); // 0x00000001803121B0-0x00000001803121F0
	public static bool IsCreatorName(string username); // 0x0000000180312040-0x00000001803120B0
	public void LeaveRoom(); // 0x00000001803121F0-0x0000000180312320
	internal void CleanupLocalRoomState(); // 0x00000001803105A0-0x0000000180310680
	public void OnKickPlayerByName(string targetUsername); // 0x0000000180312760-0x0000000180312980
	private void ShowRoomNotice(string message); // 0x0000000180314270-0x00000001803144A0
	public void OnReadyButtonClicked(Button button); // 0x0000000180312AA0-0x00000001803132D0
	private ElementGateUI ElementGateComponent(); // 0x0000000180310980-0x0000000180310A80
	internal void InitReadyButton(); // 0x0000000180311C80-0x0000000180312040
	public static bool IsRoomLocked(); // 0x00000001803120B0-0x00000001803121B0
	private void InitLockButton(); // 0x0000000180311780-0x0000000180311C80
	private static Transform FindDeepChild(Transform root, string name); // 0x0000000180310A80-0x0000000180310B70
	private void OnLockRoomClicked(); // 0x0000000180312980-0x0000000180312AA0
	private void HandleWsPropertiesChanged(); // 0x00000001803110F0-0x0000000180311190
	private void RefreshLockButtonVisual(); // 0x00000001803132D0-0x00000001803134B0
	public void RefreshRoomOnReturn(); // 0x00000001803134B0-0x0000000180313B00
	[IteratorStateMachine(typeof(_LoadRoomThenHideGlobalLoading_d__38))]
	private IEnumerator LoadRoomThenHideGlobalLoading(ManagerRoom mgr); // 0x0000000180312320-0x0000000180312390
	private void UpdateReadyButtonVisual(Button button, UnityEngine.UI.Text buttonText, bool isReady); // 0x0000000180314600-0x00000001803146D0
	private void SendMySlotProps(int slotIndex); // 0x0000000180313D90-0x0000000180313FB0
	[IteratorStateMachine(typeof(_WaitForDataAndSend_d__41))]
	private IEnumerator WaitForDataAndSend(int slotIndex, ManagerRoom manager); // 0x00000001803146D0-0x0000000180314770
	private void SendPropsWithData(int slotIndex, UserDTO user, ManagerRoom manager); // 0x0000000180314250-0x0000000180314270
	private void SendPropsWithDataInternal(int slotIndex, UserDTO user, ManagerRoom manager, int retryCount); // 0x0000000180313FB0-0x0000000180314250
	[IteratorStateMachine(typeof(_WaitToGetData_d__45))]
	private IEnumerator WaitToGetData(float s, int slotIndex, UserDTO user, ManagerRoom manager, int retryCount); // 0x0000000180314770-0x0000000180314830
	public void UpdatePlayerSlotsFromTracker(); // 0x00000001803145F0-0x0000000180314600
	private void UpdatePlayerSlotsAfterReconnect(); // 0x00000001803144A0-0x00000001803145F0
	public void OnHubSuspend(); // 0x0000000180312750-0x0000000180312760
	public void OnHubResume(); // 0x0000000180312710-0x0000000180312750
	private void ClearAllUISlots(); // 0x0000000180310680-0x0000000180310980
}

