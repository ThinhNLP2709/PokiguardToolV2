/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[AddComponentMenu("Input/Player Input Manager")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/PlayerInputManager.html")]
	public class PlayerInputManager : MonoBehaviour // TypeDefIndex: 6240
	{
		// Fields
		public const string PlayerJoinedMessage = "OnPlayerJoined"; // Metadata: 0x00698D58
		public const string PlayerLeftMessage = "OnPlayerLeft"; // Metadata: 0x00698D67
		[CompilerGenerated]
		private static PlayerInputManager _instance_k__BackingField; // 0x00
		[SerializeField]
		internal PlayerNotifications m_NotificationBehavior; // 0x20
		[SerializeField]
		[Tooltip("Set a limit for the maximum number of players who are able to join.")]
		internal int m_MaxPlayerCount; // 0x24
		[SerializeField]
		internal bool m_AllowJoining; // 0x28
		[SerializeField]
		internal PlayerJoinBehavior m_JoinBehavior; // 0x2C
		[SerializeField]
		internal PlayerJoinedEvent m_PlayerJoinedEvent; // 0x30
		[SerializeField]
		internal PlayerLeftEvent m_PlayerLeftEvent; // 0x38
		[SerializeField]
		internal InputActionProperty m_JoinAction; // 0x40
		[SerializeField]
		internal GameObject m_PlayerPrefab; // 0x58
		[SerializeField]
		internal bool m_SplitScreen; // 0x60
		[SerializeField]
		internal bool m_MaintainAspectRatioInSplitScreen; // 0x61
		[SerializeField]
		[Tooltip("Explicitly set a fixed number of screens or otherwise allow the screen to be divided automatically to best fit the number of players.")]
		internal int m_FixedNumberOfSplitScreens; // 0x64
		[SerializeField]
		internal Rect m_SplitScreenRect; // 0x68
		[NonSerialized]
		private bool m_JoinActionDelegateHooked; // 0x78
		[NonSerialized]
		private bool m_UnpairedDeviceUsedDelegateHooked; // 0x79
		[NonSerialized]
		private Action<InputAction.CallbackContext> m_JoinActionDelegate; // 0x80
		[NonSerialized]
		private Action<InputControl, InputEventPtr> m_UnpairedDeviceUsedDelegate; // 0x88
		[NonSerialized]
		private CallbackArray<Action<PlayerInput>> m_PlayerJoinedCallbacks; // 0x90
		[NonSerialized]
		private CallbackArray<Action<PlayerInput>> m_PlayerLeftCallbacks; // 0xE0
	
		// Properties
		public bool splitScreen { get; set; } // 0x000000018033D4F0-0x000000018033D500 0x0000000181D97CC0-0x0000000181D97F00
		public bool maintainAspectRatioInSplitScreen { get; } // 0x00000001804EFDB0-0x00000001804EFDC0 
		public int fixedNumberOfSplitScreens { get; } // 0x00000001802F2020-0x00000001802F2030 
		public Rect splitScreenArea { get; } // 0x0000000181D97A10-0x0000000181D97A20 
		public int playerCount { get; } // 0x0000000181D978E0-0x0000000181D97930 
		public int maxPlayerCount { get; } // 0x0000000180D17D10-0x0000000180D17D20 
		public bool joiningEnabled { get; } // 0x0000000180327270-0x0000000180327280 
		public PlayerJoinBehavior joinBehavior { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x0000000181D97C70-0x0000000181D97CC0
		public InputActionProperty joinAction { get; set; } // 0x000000018155B160-0x000000018155B180 0x0000000181D97BC0-0x0000000181D97C70
		public PlayerNotifications notificationBehavior { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public PlayerJoinedEvent playerJoinedEvent { get; } // 0x0000000181D97930-0x0000000181D979A0 
		public PlayerLeftEvent playerLeftEvent { get; } // 0x0000000181D979A0-0x0000000181D97A10 
		public GameObject playerPrefab { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		public static PlayerInputManager instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D97800-0x0000000181D97840 0x0000000181D97B60-0x0000000181D97BC0
		internal static string[] messages { get; } // 0x0000000181D97840-0x0000000181D978E0 
	
		// Events
		public event Action<PlayerInput> onPlayerJoined {
			add; // 0x0000000181D976C0-0x0000000181D97760
			remove; // 0x0000000181D97A20-0x0000000181D97AC0
		}
		public event Action<PlayerInput> onPlayerLeft {
			add; // 0x0000000181D97760-0x0000000181D97800
			remove; // 0x0000000181D97AC0-0x0000000181D97B60
		}
	
		// Nested types
		[Serializable]
		public class PlayerJoinedEvent : UnityEvent<PlayerInput> // TypeDefIndex: 6241
		{
			// Constructors
			public PlayerJoinedEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class PlayerLeftEvent : UnityEvent<PlayerInput> // TypeDefIndex: 6242
		{
			// Constructors
			public PlayerLeftEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		// Constructors
		public PlayerInputManager(); // 0x0000000181D97690-0x0000000181D976C0
	
		// Methods
		public void EnableJoining(); // 0x0000000181D95B70-0x0000000181D95E80
		public void DisableJoining(); // 0x0000000181D95A30-0x0000000181D95B70
		internal void JoinPlayerFromUI(); // 0x0000000181D963A0-0x0000000181D96400
		public void JoinPlayerFromAction(InputAction.CallbackContext context); // 0x0000000181D96330-0x0000000181D963A0
		public void JoinPlayerFromActionIfNotAlreadyJoined(InputAction.CallbackContext context); // 0x0000000181D96240-0x0000000181D96330
		public PlayerInput JoinPlayer(int playerIndex = -1 /* Metadata: 0x00698D53 */, int splitScreenIndex = -1 /* Metadata: 0x00698D54 */, string controlScheme = null, InputDevice pairWithDevice = null); // 0x0000000181D96400-0x0000000181D965F0
		public PlayerInput JoinPlayer(int playerIndex = -1 /* Metadata: 0x00698D55 */, int splitScreenIndex = -1 /* Metadata: 0x00698D56 */, string controlScheme = null, params InputDevice[] pairWithDevices); // 0x0000000181D965F0-0x0000000181D96820
		private bool CheckIfPlayerCanJoin(int playerIndex = -1 /* Metadata: 0x00698D57 */); // 0x0000000181D95740-0x0000000181D95A30
		private void OnUnpairedDeviceUsed(InputControl control, InputEventPtr eventPtr); // 0x0000000181D96F40-0x0000000181D96FF0
		private void OnEnable(); // 0x0000000181D96B60-0x0000000181D96F40
		private void OnDisable(); // 0x0000000181D96A80-0x0000000181D96B60
		private void UpdateSplitScreen(); // 0x0000000181D96FF0-0x0000000181D97690
		private bool IsDeviceUsableWithPlayerActions(InputDevice device); // 0x0000000181D95E80-0x0000000181D96240
		private void ValidateInputActionAsset(); // 0x00000001802E76C0-0x00000001802E76D0
		internal void NotifyPlayerJoined(PlayerInput player); // 0x0000000181D96820-0x0000000181D96950
		internal void NotifyPlayerLeft(PlayerInput player); // 0x0000000181D96950-0x0000000181D96A80
	}
}
