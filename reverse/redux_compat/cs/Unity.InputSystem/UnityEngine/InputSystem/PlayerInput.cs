/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[AddComponentMenu("Input/Player Input")]
	[DisallowMultipleComponent]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/PlayerInput.html")]
	public class PlayerInput : MonoBehaviour // TypeDefIndex: 6235
	{
		// Fields
		public const string DeviceLostMessage = "OnDeviceLost"; // Metadata: 0x00698D23
		public const string DeviceRegainedMessage = "OnDeviceRegained"; // Metadata: 0x00698D30
		public const string ControlsChangedMessage = "OnControlsChanged"; // Metadata: 0x00698D41
		private int m_AllMapsHashCode; // 0x20
		[SerializeField]
		[Tooltip("Input actions associated with the player.")]
		internal InputActionAsset m_Actions; // 0x28
		[SerializeField]
		[Tooltip("Determine how notifications should be sent when an input-related event associated with the player happens.")]
		internal PlayerNotifications m_NotificationBehavior; // 0x30
		[SerializeField]
		[Tooltip("UI InputModule that should have it\'s input actions synchronized to this PlayerInput\'s actions.")]
		internal InputSystemUIInputModule m_UIInputModule; // 0x38
		[SerializeField]
		[Tooltip("Event that is triggered when the PlayerInput loses a paired device (e.g. its battery runs out).")]
		internal DeviceLostEvent m_DeviceLostEvent; // 0x40
		[SerializeField]
		internal DeviceRegainedEvent m_DeviceRegainedEvent; // 0x48
		[SerializeField]
		internal ControlsChangedEvent m_ControlsChangedEvent; // 0x50
		[SerializeField]
		internal ActionEvent[] m_ActionEvents; // 0x58
		[SerializeField]
		internal bool m_NeverAutoSwitchControlSchemes; // 0x60
		[SerializeField]
		internal string m_DefaultControlScheme; // 0x68
		[SerializeField]
		internal string m_DefaultActionMap; // 0x70
		[SerializeField]
		internal int m_SplitScreenIndex; // 0x78
		[SerializeField]
		[Tooltip("Reference to the player\'s view camera. Note that this is only required when using split-screen and/or per-player UIs. Otherwise it is safe to leave this property uninitialized.")]
		internal Camera m_Camera; // 0x80
		[NonSerialized]
		private InputValue m_InputValueObject; // 0x88
		[NonSerialized]
		internal InputActionMap m_CurrentActionMap; // 0x90
		[NonSerialized]
		private int m_PlayerIndex; // 0x98
		[NonSerialized]
		private bool m_InputActive; // 0x9C
		[NonSerialized]
		private bool m_Enabled; // 0x9D
		[NonSerialized]
		internal bool m_ActionsInitialized; // 0x9E
		[NonSerialized]
		private Dictionary<string, string> m_ActionMessageNames; // 0xA0
		[NonSerialized]
		private InputUser m_InputUser; // 0xA8
		[NonSerialized]
		private Action<InputAction.CallbackContext> m_ActionTriggeredDelegate; // 0xB0
		[NonSerialized]
		private CallbackArray<Action<PlayerInput>> m_DeviceLostCallbacks; // 0xB8
		[NonSerialized]
		private CallbackArray<Action<PlayerInput>> m_DeviceRegainedCallbacks; // 0x108
		[NonSerialized]
		private CallbackArray<Action<PlayerInput>> m_ControlsChangedCallbacks; // 0x158
		[NonSerialized]
		private CallbackArray<Action<InputAction.CallbackContext>> m_ActionTriggeredCallbacks; // 0x1A8
		[NonSerialized]
		private Action<InputControl, InputEventPtr> m_UnpairedDeviceUsedDelegate; // 0x1F8
		[NonSerialized]
		private Func<InputDevice, InputEventPtr, bool> m_PreFilterUnpairedDeviceUsedDelegate; // 0x200
		[NonSerialized]
		private bool m_OnUnpairedDeviceUsedHooked; // 0x208
		[NonSerialized]
		private Action<InputDevice, InputDeviceChange> m_DeviceChangeDelegate; // 0x210
		[NonSerialized]
		private bool m_OnDeviceChangeHooked; // 0x218
		internal static int s_AllActivePlayersCount; // 0x00
		internal static PlayerInput[] s_AllActivePlayers; // 0x08
		private static Action<InputUser, InputUserChange, InputDevice> s_UserChangeDelegate; // 0x10
		private static int s_InitPairWithDevicesCount; // 0x18
		private static InputDevice[] s_InitPairWithDevices; // 0x20
		private static int s_InitPlayerIndex; // 0x28
		private static int s_InitSplitScreenIndex; // 0x2C
		private static string s_InitControlScheme; // 0x30
		internal static bool s_DestroyIfDeviceSetupUnsuccessful; // 0x38
	
		// Properties
		public bool inputIsActive { get; } // 0x0000000181974800-0x0000000181974810 
		[Obsolete("Use inputIsActive instead.")]
		public bool active { get; } // 0x0000000181974800-0x0000000181974810 
		public int playerIndex { get; } // 0x000000018033D1D0-0x000000018033D1E0 
		public int splitScreenIndex { get; } // 0x000000018169BB50-0x000000018169BB60 
		public InputActionAsset actions { get; set; } // 0x0000000181D9E250-0x0000000181D9E2A0 0x0000000181D9EA90-0x0000000181D9EBA0
		public string currentControlScheme { get; } // 0x0000000181D9E390-0x0000000181D9E420 
		public string defaultControlScheme { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		public bool neverAutoSwitchControlSchemes { get; set; } // 0x000000018033D4F0-0x000000018033D500 0x0000000181D9EC20-0x0000000181D9EC60
		public InputActionMap currentActionMap { get; set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000181D9EBA0-0x0000000181D9EC20
		public string defaultActionMap { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		public PlayerNotifications notificationBehavior { get; set; } // 0x000000018033D100-0x000000018033D110 0x0000000181D9EC60-0x0000000181D9ECB0
		public ReadOnlyArray<ActionEvent> actionEvents { get; set; } // 0x0000000181D9E220-0x0000000181D9E250 0x0000000181D9EA10-0x0000000181D9EA90
		public DeviceLostEvent deviceLostEvent { get; } // 0x0000000181D9E420-0x0000000181D9E490 
		public DeviceRegainedEvent deviceRegainedEvent { get; } // 0x0000000181D9E490-0x0000000181D9E500 
		public ControlsChangedEvent controlsChangedEvent { get; } // 0x0000000181D9E320-0x0000000181D9E390 
		public Camera camera { get; set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
		public InputSystemUIInputModule uiInputModule { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x0000000181D9ECB0-0x0000000181D9EDC0
		public InputUser user { get; } // 0x00000001806671D0-0x00000001806671E0 
		public ReadOnlyArray<InputDevice> devices { get; } // 0x0000000181D9E500-0x0000000181D9E590 
		public bool hasMissingRequiredDevices { get; } // 0x0000000181D9E590-0x0000000181D9E680 
		public static ReadOnlyArray<PlayerInput> all { get; } // 0x0000000181D9E2A0-0x0000000181D9E320 
		public static bool isSinglePlayer { get; } // 0x0000000181D9E680-0x0000000181D9E790 
	
		// Events
		public event Action<InputAction.CallbackContext> onActionTriggered {
			add; // 0x0000000181D9DFA0-0x0000000181D9E040
			remove; // 0x0000000181D9E790-0x0000000181D9E830
		}
		public event Action<PlayerInput> onDeviceLost {
			add; // 0x0000000181D9E0E0-0x0000000181D9E180
			remove; // 0x0000000181D9E8D0-0x0000000181D9E970
		}
		public event Action<PlayerInput> onDeviceRegained {
			add; // 0x0000000181D9E180-0x0000000181D9E220
			remove; // 0x0000000181D9E970-0x0000000181D9EA10
		}
		public event Action<PlayerInput> onControlsChanged {
			add; // 0x0000000181D9E040-0x0000000181D9E0E0
			remove; // 0x0000000181D9E830-0x0000000181D9E8D0
		}
	
		// Nested types
		[Serializable]
		public class ActionEvent : UnityEvent<InputAction.CallbackContext> // TypeDefIndex: 6236
		{
			// Fields
			[SerializeField]
			private string m_ActionId; // 0x30
			[SerializeField]
			private string m_ActionName; // 0x38
	
			// Properties
			public string actionId { get; } // 0x000000018031E110-0x000000018031E120 
			public string actionName { get; } // 0x00000001803272A0-0x00000001803272B0 
	
			// Constructors
			public ActionEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
			public ActionEvent(InputAction action); // 0x0000000181D8A2A0-0x0000000181D8A4D0
			public ActionEvent(Guid actionGUID, string name = null); // 0x0000000181D8A4D0-0x0000000181D8A530
		}
	
		[Serializable]
		public class DeviceLostEvent : UnityEvent<PlayerInput> // TypeDefIndex: 6237
		{
			// Constructors
			public DeviceLostEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class DeviceRegainedEvent : UnityEvent<PlayerInput> // TypeDefIndex: 6238
		{
			// Constructors
			public DeviceRegainedEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class ControlsChangedEvent : UnityEvent<PlayerInput> // TypeDefIndex: 6239
		{
			// Constructors
			public ControlsChangedEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		// Constructors
		public PlayerInput(); // 0x0000000181D9DF80-0x0000000181D9DFA0
		static PlayerInput(); // 0x0000000181D9DF30-0x0000000181D9DF80
	
		// Methods
		public TDevice GetDevice<TDevice>()
			where TDevice : InputDevice;
		public void ActivateInput(); // 0x0000000181D97F00-0x0000000181D97FC0
		private void UpdateDelegates(); // 0x0000000181D9DD70-0x0000000181D9DF30
		public void DeactivateInput(); // 0x0000000181D992B0-0x0000000181D992E0
		[Obsolete("Use DeactivateInput instead.")]
		public void PassivateInput(); // 0x0000000181D992B0-0x0000000181D992E0
		public bool SwitchCurrentControlScheme(params InputDevice[] devices); // 0x0000000181D9D100-0x0000000181D9D360
		public void SwitchCurrentControlScheme(string controlScheme, params InputDevice[] devices); // 0x0000000181D9D360-0x0000000181D9D4B0
		public void SwitchCurrentActionMap(string mapNameOrId); // 0x0000000181D9CF10-0x0000000181D9D100
		public static PlayerInput GetPlayerByIndex(int playerIndex); // 0x0000000181D998E0-0x0000000181D99A10
		public static PlayerInput FindFirstPairedToDevice(InputDevice device); // 0x0000000181D996D0-0x0000000181D998E0
		public static PlayerInput Instantiate(GameObject prefab, int playerIndex = -1 /* Metadata: 0x00698D1F */, string controlScheme = null, int splitScreenIndex = -1 /* Metadata: 0x00698D20 */, InputDevice pairWithDevice = null); // 0x0000000181D9A4B0-0x0000000181D9A640
		public static PlayerInput Instantiate(GameObject prefab, int playerIndex = -1 /* Metadata: 0x00698D21 */, string controlScheme = null, int splitScreenIndex = -1 /* Metadata: 0x00698D22 */, params InputDevice[] pairWithDevices); // 0x0000000181D9A300-0x0000000181D9A4B0
		private static PlayerInput DoInstantiate(GameObject prefab); // 0x0000000181D99340-0x0000000181D996D0
		private void InitializeActions(); // 0x0000000181D99E10-0x0000000181D9A170
		private void CopyActionAssetAndApplyBindingOverrides(); // 0x0000000181D99040-0x0000000181D992B0
		private void UninitializeActions(); // 0x0000000181D9DA10-0x0000000181D9DC30
		private void InstallOnActionTriggeredHook(); // 0x0000000181D9A170-0x0000000181D9A300
		private void UninstallOnActionTriggeredHook(); // 0x0000000181D9DC30-0x0000000181D9DD70
		private void OnActionTriggered(InputAction.CallbackContext context); // 0x0000000181D9A640-0x0000000181D9A880
		private void CacheMessageNames(); // 0x0000000181D98D30-0x0000000181D99020
		private void ClearCaches(); // 0x0000000181D99020-0x0000000181D99040
		private void AssignUserAndDevices(); // 0x0000000181D982B0-0x0000000181D98D30
		private bool HaveBindingForDevice(InputDevice device); // 0x0000000181D99D10-0x0000000181D99E10
		private void UnassignUserAndDevices(); // 0x0000000181D9D8E0-0x0000000181D9DA10
		private bool TryToActivateControlScheme(InputControlScheme controlScheme); // 0x0000000181D9D4B0-0x0000000181D9D8E0
		private void AssignPlayerIndex(); // 0x0000000181D97FC0-0x0000000181D982B0
		private void OnEnable(); // 0x0000000181D9AE50-0x0000000181D9B3A0
		private void StartListeningForUnpairedDeviceActivity(); // 0x0000000181D9C040-0x0000000181D9C350
		private void StopListeningForUnpairedDeviceActivity(); // 0x0000000181D9C3C0-0x0000000181D9C620
		private void StartListeningForDeviceChanges(); // 0x0000000181D9BF70-0x0000000181D9C040
		private void StopListeningForDeviceChanges(); // 0x0000000181D9C350-0x0000000181D9C3C0
		private void OnDisable(); // 0x0000000181D9A9B0-0x0000000181D9AE50
		public void DebugLogAction(InputAction.CallbackContext context); // 0x0000000181D992E0-0x0000000181D99340
		private void HandleDeviceLost(); // 0x0000000181D99B10-0x0000000181D99C10
		private void HandleDeviceRegained(); // 0x0000000181D99C10-0x0000000181D99D10
		private void HandleControlsChanged(); // 0x0000000181D99A10-0x0000000181D99B10
		private static void OnUserChange(InputUser user, InputUserChange change, InputDevice device); // 0x0000000181D9BD10-0x0000000181D9BF70
		private static bool OnPreFilterUnpairedDeviceUsed(InputDevice device, InputEventPtr eventPtr); // 0x0000000181D9B3A0-0x0000000181D9B570
		private void OnUnpairedDeviceUsed(InputControl control, InputEventPtr eventPtr); // 0x0000000181D9B570-0x0000000181D9BD10
		private void OnDeviceChange(InputDevice device, InputDeviceChange change); // 0x0000000181D9A880-0x0000000181D9A9B0
		private void SwitchControlSchemeInternal(ref InputControlScheme controlScheme, params InputDevice[] devices); // 0x0000000181D9C620-0x0000000181D9CF10
	}
}
