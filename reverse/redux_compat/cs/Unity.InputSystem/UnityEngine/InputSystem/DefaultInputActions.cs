/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public class DefaultInputActions : IInputActionCollection2, IDisposable // TypeDefIndex: 6229
	{
		// Fields
		[CompilerGenerated]
		private readonly InputActionAsset _asset_k__BackingField; // 0x10
		private readonly InputActionMap m_Player; // 0x18
		private IPlayerActions m_PlayerActionsCallbackInterface; // 0x20
		private readonly InputAction m_Player_Move; // 0x28
		private readonly InputAction m_Player_Look; // 0x30
		private readonly InputAction m_Player_Fire; // 0x38
		private readonly InputActionMap m_UI; // 0x40
		private IUIActions m_UIActionsCallbackInterface; // 0x48
		private readonly InputAction m_UI_Navigate; // 0x50
		private readonly InputAction m_UI_Submit; // 0x58
		private readonly InputAction m_UI_Cancel; // 0x60
		private readonly InputAction m_UI_Point; // 0x68
		private readonly InputAction m_UI_Click; // 0x70
		private readonly InputAction m_UI_ScrollWheel; // 0x78
		private readonly InputAction m_UI_MiddleClick; // 0x80
		private readonly InputAction m_UI_RightClick; // 0x88
		private readonly InputAction m_UI_TrackedDevicePosition; // 0x90
		private readonly InputAction m_UI_TrackedDeviceOrientation; // 0x98
		private int m_KeyboardMouseSchemeIndex; // 0xA0
		private int m_GamepadSchemeIndex; // 0xA4
		private int m_TouchSchemeIndex; // 0xA8
		private int m_JoystickSchemeIndex; // 0xAC
		private int m_XRSchemeIndex; // 0xB0
	
		// Properties
		public InputActionAsset asset { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public InputBinding? bindingMask { get; set; } // 0x0000000181D8B530-0x0000000181D8B580 0x0000000181D8B620-0x0000000181D8B680
		public ReadOnlyArray<InputDevice>? devices { get; set; } // 0x0000000181D8B5E0-0x0000000181D8B620 0x0000000181D8B680-0x0000000181D8B6C0
		public ReadOnlyArray<InputControlScheme> controlSchemes { get; } // 0x0000000181D8B5A0-0x0000000181D8B5E0 
		public IEnumerable<InputBinding> bindings { get; } // 0x0000000181D8B580-0x0000000181D8B5A0 
		public PlayerActions Player { get; } // 0x0000000180E10430-0x0000000180E10450 
		public UIActions UI { get; } // 0x0000000180E10430-0x0000000180E10450 
		public InputControlScheme KeyboardMouseScheme { get; } // 0x0000000181D8B2C0-0x0000000181D8B390 
		public InputControlScheme GamepadScheme { get; } // 0x0000000181D8B120-0x0000000181D8B1F0 
		public InputControlScheme TouchScheme { get; } // 0x0000000181D8B390-0x0000000181D8B460 
		public InputControlScheme JoystickScheme { get; } // 0x0000000181D8B1F0-0x0000000181D8B2C0 
		public InputControlScheme XRScheme { get; } // 0x0000000181D8B460-0x0000000181D8B530 
	
		// Nested types
		public struct PlayerActions // TypeDefIndex: 6230
		{
			// Fields
			private DefaultInputActions m_Wrapper; // 0x00
	
			// Properties
			public InputAction Move { get; } // 0x0000000181D956F0-0x0000000181D95710 
			public InputAction Look { get; } // 0x0000000181D956D0-0x0000000181D956F0 
			public InputAction Fire { get; } // 0x0000000181A23D50-0x0000000181A23D70 
			public bool enabled { get; } // 0x0000000181D95710-0x0000000181D95740 
	
			// Constructors
			public PlayerActions(DefaultInputActions wrapper); // 0x0000000180E02C90-0x0000000180E02CA0
	
			// Methods
			public InputActionMap Get(); // 0x0000000181A23EB0-0x0000000181A23ED0
			public void Enable(); // 0x0000000181D94840-0x0000000181D94870
			public void Disable(); // 0x0000000181D94810-0x0000000181D94840
			public static implicit operator InputActionMap(PlayerActions set); // 0x0000000180FB0360-0x0000000180FB0380
			public void SetCallbacks(IPlayerActions instance); // 0x0000000181D94870-0x0000000181D956D0
		}
	
		public struct UIActions // TypeDefIndex: 6231
		{
			// Fields
			private DefaultInputActions m_Wrapper; // 0x00
	
			// Properties
			public InputAction Navigate { get; } // 0x0000000181DA5800-0x0000000181DA5820 
			public InputAction Submit { get; } // 0x0000000181DA5880-0x0000000181DA58A0 
			public InputAction Cancel { get; } // 0x0000000181DA57A0-0x0000000181DA57C0 
			public InputAction Point { get; } // 0x0000000181DA5820-0x0000000181DA5840 
			public InputAction Click { get; } // 0x0000000181DA57C0-0x0000000181DA57E0 
			public InputAction ScrollWheel { get; } // 0x0000000181DA5860-0x0000000181DA5880 
			public InputAction MiddleClick { get; } // 0x0000000181DA57E0-0x0000000181DA5800 
			public InputAction RightClick { get; } // 0x0000000181DA5840-0x0000000181DA5860 
			public InputAction TrackedDevicePosition { get; } // 0x0000000181DA58C0-0x0000000181DA58E0 
			public InputAction TrackedDeviceOrientation { get; } // 0x0000000181DA58A0-0x0000000181DA58C0 
			public bool enabled { get; } // 0x0000000181DA58E0-0x0000000181DA5910 
	
			// Constructors
			public UIActions(DefaultInputActions wrapper); // 0x0000000180E02C90-0x0000000180E02CA0
	
			// Methods
			public InputActionMap Get(); // 0x0000000181DA2820-0x0000000181DA2840
			public void Enable(); // 0x0000000181DA27F0-0x0000000181DA2820
			public void Disable(); // 0x0000000181DA27C0-0x0000000181DA27F0
			public static implicit operator InputActionMap(UIActions set); // 0x0000000181DA5910-0x0000000181DA5930
			public void SetCallbacks(IUIActions instance); // 0x0000000181DA2840-0x0000000181DA57A0
		}
	
		public interface IPlayerActions // TypeDefIndex: 6232
		{
			// Methods
			void OnMove(InputAction.CallbackContext context);
			void OnLook(InputAction.CallbackContext context);
			void OnFire(InputAction.CallbackContext context);
		}
	
		public interface IUIActions // TypeDefIndex: 6233
		{
			// Methods
			void OnNavigate(InputAction.CallbackContext context);
			void OnSubmit(InputAction.CallbackContext context);
			void OnCancel(InputAction.CallbackContext context);
			void OnPoint(InputAction.CallbackContext context);
			void OnClick(InputAction.CallbackContext context);
			void OnScrollWheel(InputAction.CallbackContext context);
			void OnMiddleClick(InputAction.CallbackContext context);
			void OnRightClick(InputAction.CallbackContext context);
			void OnTrackedDevicePosition(InputAction.CallbackContext context);
			void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
		}
	
		// Constructors
		public DefaultInputActions(); // 0x0000000181D8AD10-0x0000000181D8B120
	
		// Methods
		public void Dispose(); // 0x0000000181D8AC00-0x0000000181D8AC50
		public bool Contains(InputAction action); // 0x0000000181D8ABC0-0x0000000181D8ABE0
		public IEnumerator<InputAction> GetEnumerator(); // 0x0000000181D8ACF0-0x0000000181D8AD10
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181D8ACF0-0x0000000181D8AD10
		public void Enable(); // 0x0000000181D8AC50-0x0000000181D8AC70
		public void Disable(); // 0x0000000181D8ABE0-0x0000000181D8AC00
		public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false /* Metadata: 0x00698D1E */); // 0x0000000181D8AC70-0x0000000181D8AC90
		public int FindBinding(InputBinding bindingMask, out InputAction action); // 0x0000000181D8AC90-0x0000000181D8ACF0
	}
}
