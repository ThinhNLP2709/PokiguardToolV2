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

public class Room_Handler : MonoBehaviour, IHubSuspendable // TypeDefIndex: 44
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
	private const int SEND_PROPS_MAX_RETRY = 3; // Metadata: 0x0064BF77
	private bool _slotsRefreshPending; // 0x78
	private int _lastSlotsRefreshFrame; // 0x7C

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadRoomThenHideGlobalLoading_d__39 : IEnumerator<object> // TypeDefIndex: 45
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom mgr; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoomThenHideGlobalLoading_d__39(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018030E680-0x000000018030E780
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018030E780-0x000000018030E7C0
	}

	[CompilerGenerated]
	private sealed class _WaitForDataAndSend_d__42 : IEnumerator<object> // TypeDefIndex: 46
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitForDataAndSend_d__42(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018030FB50-0x000000018030FDF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018030FDF0-0x000000018030FE30
	}

	[CompilerGenerated]
	private sealed class _WaitToGetData_d__46 : IEnumerator<object> // TypeDefIndex: 47
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitToGetData_d__46(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018030FE30-0x000000018030FF00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018030FF00-0x000000018030FF40
	}

	// Constructors
	public Room_Handler(); // 0x000000018030B9B0-0x000000018030B9F0

	// Methods
	private void Awake(); // 0x00000001803072D0-0x00000001803076D0
	private void OnDestroy(); // 0x00000001803095E0-0x0000000180309960
	private void HandleWsStartMatchFailed(ChatMessageDTO msg); // 0x00000001803087F0-0x0000000180308970
	private void HandleWsRoomEnteredLobby(string roomId); // 0x00000001803083D0-0x0000000180308680
	private int ResolveMySlotFromWs(); // 0x000000018030ACA0-0x000000018030AF30
	private void HandleWsMembersChanged(); // 0x0000000180308190-0x00000001803082F0
	private void HandleWsKickFailed(string reason); // 0x0000000180307DD0-0x0000000180307E30
	private void HandleWsKicked(string reason); // 0x0000000180307E30-0x0000000180308190
	private void HandleWsRoomLeft(string oldRoomId); // 0x0000000180308680-0x00000001803087F0
	private void HandleWsPlayerStatesChanged(); // 0x00000001803082F0-0x0000000180308330
	public static bool IsRoomOwner(); // 0x0000000180309400-0x0000000180309440
	public static bool IsCreatorName(string username); // 0x0000000180309290-0x0000000180309300
	public void LeaveRoom(); // 0x0000000180309440-0x0000000180309570
	internal void CleanupLocalRoomState(); // 0x00000001803076D0-0x00000001803077B0
	public void OnKickPlayerByName(string targetUsername); // 0x00000001803099B0-0x0000000180309BD0
	private void ShowRoomNotice(string message); // 0x000000018030B410-0x000000018030B640
	public void OnReadyButtonClicked(Button button); // 0x0000000180309CF0-0x000000018030A4B0
	private ElementGateUI ElementGateComponent(); // 0x0000000180307B80-0x0000000180307C60
	private bool ElementGateSatisfied(); // 0x0000000180307C60-0x0000000180307CE0
	internal void InitReadyButton(); // 0x0000000180308E70-0x0000000180309290
	public static bool IsRoomLocked(); // 0x0000000180309300-0x0000000180309400
	private void InitLockButton(); // 0x0000000180308970-0x0000000180308E70
	private static Transform FindDeepChild(Transform root, string name); // 0x0000000180307CE0-0x0000000180307DD0
	private void OnLockRoomClicked(); // 0x0000000180309BD0-0x0000000180309CF0
	private void HandleWsPropertiesChanged(); // 0x0000000180308330-0x00000001803083D0
	private void RefreshLockButtonVisual(); // 0x000000018030A4B0-0x000000018030A690
	public void RefreshRoomOnReturn(); // 0x000000018030A690-0x000000018030ACA0
	[IteratorStateMachine(typeof(_LoadRoomThenHideGlobalLoading_d__39))]
	private IEnumerator LoadRoomThenHideGlobalLoading(ManagerRoom mgr); // 0x0000000180309570-0x00000001803095E0
	private void UpdateReadyButtonVisual(Button button, UnityEngine.UI.Text buttonText, bool isReady); // 0x000000018030B780-0x000000018030B850
	private void SendMySlotProps(int slotIndex); // 0x000000018030AF30-0x000000018030B150
	[IteratorStateMachine(typeof(_WaitForDataAndSend_d__42))]
	private IEnumerator WaitForDataAndSend(int slotIndex, ManagerRoom manager); // 0x000000018030B850-0x000000018030B8F0
	private void SendPropsWithData(int slotIndex, UserDTO user, ManagerRoom manager); // 0x000000018030B3F0-0x000000018030B410
	private void SendPropsWithDataInternal(int slotIndex, UserDTO user, ManagerRoom manager, int retryCount); // 0x000000018030B150-0x000000018030B3F0
	[IteratorStateMachine(typeof(_WaitToGetData_d__46))]
	private IEnumerator WaitToGetData(float s, int slotIndex, UserDTO user, ManagerRoom manager, int retryCount); // 0x000000018030B8F0-0x000000018030B9B0
	public void UpdatePlayerSlotsFromTracker(); // 0x000000018030B770-0x000000018030B780
	private void UpdatePlayerSlotsAfterReconnect(); // 0x000000018030B640-0x000000018030B770
	public void OnHubSuspend(); // 0x00000001803099A0-0x00000001803099B0
	public void OnHubResume(); // 0x0000000180309960-0x00000001803099A0
	private void ClearAllUISlots(); // 0x00000001803077B0-0x0000000180307B80
}

