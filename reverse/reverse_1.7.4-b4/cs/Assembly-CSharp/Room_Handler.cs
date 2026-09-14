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
	private const int SEND_PROPS_MAX_RETRY = 3; // Metadata: 0x005EEA7A
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001802D2D60-0x00000001802D2F00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802D2F00-0x00000001802D2F40
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001802D2F40-0x00000001802D3250
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802D3250-0x00000001802D3290
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001802D3290-0x00000001802D3390
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802D3390-0x00000001802D33D0
	}

	// Constructors
	public Room_Handler(); // 0x00000001802D2D00-0x00000001802D2D60

	// Methods
	private void Awake(); // 0x00000001802CBAB0-0x00000001802CC0A0
	private void OnDestroy(); // 0x00000001802CC0A0-0x00000001802CC500
	private void HandleWsStartMatchFailed(ChatMessageDTO msg); // 0x00000001802CC500-0x00000001802CC810
	private void HandleWsRoomEnteredLobby(string roomId); // 0x00000001802CC810-0x00000001802CCD30
	private int ResolveMySlotFromWs(); // 0x00000001802CCD30-0x00000001802CD0A0
	private void HandleWsMembersChanged(); // 0x00000001802CD0A0-0x00000001802CD370
	private void HandleWsKickFailed(string reason); // 0x00000001802CD370-0x00000001802CD3D0
	private void HandleWsKicked(string reason); // 0x00000001802CD3D0-0x00000001802CDA20
	private void HandleWsRoomLeft(string oldRoomId); // 0x00000001802CDA20-0x00000001802CDC70
	private void HandleWsPlayerStatesChanged(); // 0x00000001802CDC70-0x00000001802CDCD0
	public static bool IsRoomOwner(); // 0x00000001802CDCD0-0x00000001802CDD10
	public static bool IsCreatorName(string username); // 0x00000001802CDD10-0x00000001802CDE30
	public void LeaveRoom(); // 0x00000001802CDE30-0x00000001802CE010
	internal void CleanupLocalRoomState(); // 0x00000001802CE010-0x00000001802CE180
	public void OnKickPlayerByName(string targetUsername); // 0x00000001802CE180-0x00000001802CE460
	private void ShowRoomNotice(string message); // 0x00000001802CE460-0x00000001802CE610
	public void OnReadyButtonClicked(Button button); // 0x00000001802CE610-0x00000001802CF130
	private ElementGateUI ElementGateComponent(); // 0x00000001802CF130-0x00000001802CF3A0
	internal void InitReadyButton(); // 0x00000001802CF3A0-0x00000001802CF980
	public static bool IsRoomLocked(); // 0x00000001802CF980-0x00000001802CFB60
	private void InitLockButton(); // 0x00000001802CFB60-0x00000001802D0650
	private static Transform FindDeepChild(Transform root, string name); // 0x00000001802D0650-0x00000001802D08C0
	private void OnLockRoomClicked(); // 0x00000001802D08C0-0x00000001802D0A20
	private void HandleWsPropertiesChanged(); // 0x00000001802D0A20-0x00000001802D0B80
	private void RefreshLockButtonVisual(); // 0x00000001802D0B80-0x00000001802D0EF0
	public void RefreshRoomOnReturn(); // 0x00000001802D0EF0-0x00000001802D1A10
	[IteratorStateMachine(typeof(_LoadRoomThenHideGlobalLoading_d__38))]
	private IEnumerator LoadRoomThenHideGlobalLoading(ManagerRoom mgr); // 0x00000001802D1A10-0x00000001802D1AB0
	private void UpdateReadyButtonVisual(Button button, UnityEngine.UI.Text buttonText, bool isReady); // 0x00000001802D1AB0-0x00000001802D1C00
	private void SendMySlotProps(int slotIndex); // 0x00000001802D1C00-0x00000001802D1F30
	[IteratorStateMachine(typeof(_WaitForDataAndSend_d__41))]
	private IEnumerator WaitForDataAndSend(int slotIndex, ManagerRoom manager); // 0x00000001802D1F30-0x00000001802D2040
	private void SendPropsWithData(int slotIndex, UserDTO user, ManagerRoom manager); // 0x00000001802D2040-0x00000001802D2060
	private void SendPropsWithDataInternal(int slotIndex, UserDTO user, ManagerRoom manager, int retryCount); // 0x00000001802D2060-0x00000001802D24E0
	[IteratorStateMachine(typeof(_WaitToGetData_d__45))]
	private IEnumerator WaitToGetData(float s, int slotIndex, UserDTO user, ManagerRoom manager, int retryCount); // 0x00000001802D24E0-0x00000001802D2660
	public void UpdatePlayerSlotsFromTracker(); // 0x00000001802D2660-0x00000001802D2670
	private void UpdatePlayerSlotsAfterReconnect(); // 0x00000001802D2670-0x00000001802D2830
	public void OnHubSuspend(); // 0x00000001802D2830-0x00000001802D2840
	public void OnHubResume(); // 0x00000001802D2840-0x00000001802D2880
	private void ClearAllUISlots(); // 0x00000001802D2880-0x00000001802D2D00
}

