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

public class Room_Handler : MonoBehaviour, IHubSuspendable // TypeDefIndex: 53
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
	private const int SEND_PROPS_MAX_RETRY = 3; // Metadata: 0x005ED6AA
	private bool _slotsRefreshPending; // 0x78
	private int _lastSlotsRefreshFrame; // 0x7C

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadRoomThenHideGlobalLoading_d__38 : IEnumerator<object> // TypeDefIndex: 54
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom mgr; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoomThenHideGlobalLoading_d__38(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001802D2D30-0x00000001802D2ED0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802D2ED0-0x00000001802D2F10
	}

	[CompilerGenerated]
	private sealed class _WaitForDataAndSend_d__41 : IEnumerator<object> // TypeDefIndex: 55
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitForDataAndSend_d__41(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001802D2F10-0x00000001802D3220
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802D3220-0x00000001802D3260
	}

	[CompilerGenerated]
	private sealed class _WaitToGetData_d__45 : IEnumerator<object> // TypeDefIndex: 56
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitToGetData_d__45(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001802D3260-0x00000001802D3360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802D3360-0x00000001802D33A0
	}

	// Constructors
	public Room_Handler(); // 0x00000001802D2CD0-0x00000001802D2D30

	// Methods
	private void Awake(); // 0x00000001802CBA80-0x00000001802CC070
	private void OnDestroy(); // 0x00000001802CC070-0x00000001802CC4D0
	private void HandleWsStartMatchFailed(ChatMessageDTO msg); // 0x00000001802CC4D0-0x00000001802CC7E0
	private void HandleWsRoomEnteredLobby(string roomId); // 0x00000001802CC7E0-0x00000001802CCD00
	private int ResolveMySlotFromWs(); // 0x00000001802CCD00-0x00000001802CD070
	private void HandleWsMembersChanged(); // 0x00000001802CD070-0x00000001802CD340
	private void HandleWsKickFailed(string reason); // 0x00000001802CD340-0x00000001802CD3A0
	private void HandleWsKicked(string reason); // 0x00000001802CD3A0-0x00000001802CD9F0
	private void HandleWsRoomLeft(string oldRoomId); // 0x00000001802CD9F0-0x00000001802CDC40
	private void HandleWsPlayerStatesChanged(); // 0x00000001802CDC40-0x00000001802CDCA0
	public static bool IsRoomOwner(); // 0x00000001802CDCA0-0x00000001802CDCE0
	public static bool IsCreatorName(string username); // 0x00000001802CDCE0-0x00000001802CDE00
	public void LeaveRoom(); // 0x00000001802CDE00-0x00000001802CDFE0
	internal void CleanupLocalRoomState(); // 0x00000001802CDFE0-0x00000001802CE150
	public void OnKickPlayerByName(string targetUsername); // 0x00000001802CE150-0x00000001802CE430
	private void ShowRoomNotice(string message); // 0x00000001802CE430-0x00000001802CE5E0
	public void OnReadyButtonClicked(Button button); // 0x00000001802CE5E0-0x00000001802CF100
	private ElementGateUI ElementGateComponent(); // 0x00000001802CF100-0x00000001802CF370
	internal void InitReadyButton(); // 0x00000001802CF370-0x00000001802CF950
	public static bool IsRoomLocked(); // 0x00000001802CF950-0x00000001802CFB30
	private void InitLockButton(); // 0x00000001802CFB30-0x00000001802D0620
	private static Transform FindDeepChild(Transform root, string name); // 0x00000001802D0620-0x00000001802D0890
	private void OnLockRoomClicked(); // 0x00000001802D0890-0x00000001802D09F0
	private void HandleWsPropertiesChanged(); // 0x00000001802D09F0-0x00000001802D0B50
	private void RefreshLockButtonVisual(); // 0x00000001802D0B50-0x00000001802D0EC0
	public void RefreshRoomOnReturn(); // 0x00000001802D0EC0-0x00000001802D19E0
	[IteratorStateMachine(typeof(_LoadRoomThenHideGlobalLoading_d__38))]
	private IEnumerator LoadRoomThenHideGlobalLoading(ManagerRoom mgr); // 0x00000001802D19E0-0x00000001802D1A80
	private void UpdateReadyButtonVisual(Button button, UnityEngine.UI.Text buttonText, bool isReady); // 0x00000001802D1A80-0x00000001802D1BD0
	private void SendMySlotProps(int slotIndex); // 0x00000001802D1BD0-0x00000001802D1F00
	[IteratorStateMachine(typeof(_WaitForDataAndSend_d__41))]
	private IEnumerator WaitForDataAndSend(int slotIndex, ManagerRoom manager); // 0x00000001802D1F00-0x00000001802D2010
	private void SendPropsWithData(int slotIndex, UserDTO user, ManagerRoom manager); // 0x00000001802D2010-0x00000001802D2030
	private void SendPropsWithDataInternal(int slotIndex, UserDTO user, ManagerRoom manager, int retryCount); // 0x00000001802D2030-0x00000001802D24B0
	[IteratorStateMachine(typeof(_WaitToGetData_d__45))]
	private IEnumerator WaitToGetData(float s, int slotIndex, UserDTO user, ManagerRoom manager, int retryCount); // 0x00000001802D24B0-0x00000001802D2630
	public void UpdatePlayerSlotsFromTracker(); // 0x00000001802D2630-0x00000001802D2640
	private void UpdatePlayerSlotsAfterReconnect(); // 0x00000001802D2640-0x00000001802D2800
	public void OnHubSuspend(); // 0x00000001802D2800-0x00000001802D2810
	public void OnHubResume(); // 0x00000001802D2810-0x00000001802D2850
	private void ClearAllUISlots(); // 0x00000001802D2850-0x00000001802D2CD0
}

