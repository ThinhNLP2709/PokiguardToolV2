/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.UI
{
	[AddComponentMenu("Input/Virtual Mouse")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/UISupport.html#virtual-mouse-cursor-control")]
	public class VirtualMouseInput : MonoBehaviour // TypeDefIndex: 6315
	{
		// Fields
		[Header("Cursor")]
		[SerializeField]
		[Tooltip("Whether the component should set the cursor position of the hardware mouse cursor, if one is available. If so, the software cursor pointed (to by \'Cursor Graphic\') will be hidden.")]
		private CursorMode m_CursorMode; // 0x20
		[SerializeField]
		[Tooltip("The graphic that represents the software cursor. This is hidden if a hardware cursor (see \'Cursor Mode\') is used.")]
		private Graphic m_CursorGraphic; // 0x28
		[SerializeField]
		[Tooltip("The transform for the software cursor. Will only be set if a software cursor is used (see \'Cursor Mode\'). Moving the cursor updates the anchored position of the transform.")]
		private RectTransform m_CursorTransform; // 0x30
		[Header("Motion")]
		[SerializeField]
		[Tooltip("Speed in pixels per second with which to move the cursor. Scaled by the input from \'Stick Action\'.")]
		private float m_CursorSpeed; // 0x38
		[SerializeField]
		[Tooltip("Scale factor to apply to \'Scroll Wheel Action\' when setting the mouse \'scrollWheel\' control.")]
		private float m_ScrollSpeed; // 0x3C
		[SerializeField]
		[Space(10f)]
		[Tooltip("Vector2 action that moves the cursor left/right (X) and up/down (Y) on screen.")]
		private InputActionProperty m_StickAction; // 0x40
		[SerializeField]
		[Tooltip("Button action that triggers a left-click on the mouse.")]
		private InputActionProperty m_LeftButtonAction; // 0x58
		[SerializeField]
		[Tooltip("Button action that triggers a middle-click on the mouse.")]
		private InputActionProperty m_MiddleButtonAction; // 0x70
		[SerializeField]
		[Tooltip("Button action that triggers a right-click on the mouse.")]
		private InputActionProperty m_RightButtonAction; // 0x88
		[SerializeField]
		[Tooltip("Button action that triggers a forward button (button #4) click on the mouse.")]
		private InputActionProperty m_ForwardButtonAction; // 0xA0
		[SerializeField]
		[Tooltip("Button action that triggers a back button (button #5) click on the mouse.")]
		private InputActionProperty m_BackButtonAction; // 0xB8
		[SerializeField]
		[Tooltip("Vector2 action that feeds into the mouse \'scrollWheel\' action (scaled by \'Scroll Speed\').")]
		private InputActionProperty m_ScrollWheelAction; // 0xD0
		private Canvas m_Canvas; // 0xE8
		private CanvasScaler m_CanvasScaler; // 0xF0
		private Mouse m_VirtualMouse; // 0xF8
		private Mouse m_SystemMouse; // 0x100
		private Action m_AfterInputUpdateDelegate; // 0x108
		private Action<InputAction.CallbackContext> m_ButtonActionTriggeredDelegate; // 0x110
		private double m_LastTime; // 0x118
		private Vector2 m_LastStickValue; // 0x120
	
		// Properties
		public RectTransform cursorTransform { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public float cursorSpeed { get; set; } // 0x0000000181C62E80-0x0000000181C62E90 0x0000000181C62E90-0x0000000181C62EA0
		public CursorMode cursorMode { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000181DBE600-0x0000000181DBE710
		public Graphic cursorGraphic { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181DBE5D0-0x0000000181DBE600
		public float scrollSpeed { get; set; } // 0x0000000181C58AB0-0x0000000181C58AC0 0x0000000181DBEB40-0x0000000181DBEB50
		public Mouse virtualMouse { get; } // 0x0000000180CDCEE0-0x0000000180CDCEF0 
		public InputActionProperty stickAction { get; set; } // 0x000000018155B160-0x000000018155B180 0x0000000181DBEB80-0x0000000181DBEBB0
		public InputActionProperty leftButtonAction { get; set; } // 0x0000000181DBE440-0x0000000181DBE460 0x0000000181DBE820-0x0000000181DBE920
		public InputActionProperty rightButtonAction { get; set; } // 0x0000000181DBE480-0x0000000181DBE4A0 0x0000000181DBEA30-0x0000000181DBEB40
		public InputActionProperty middleButtonAction { get; set; } // 0x0000000181DBE460-0x0000000181DBE480 0x0000000181DBE920-0x0000000181DBEA30
		public InputActionProperty forwardButtonAction { get; set; } // 0x0000000181DBE420-0x0000000181DBE440 0x0000000181DBE710-0x0000000181DBE820
		public InputActionProperty backButtonAction { get; set; } // 0x0000000181DBE400-0x0000000181DBE420 0x0000000181DBE4C0-0x0000000181DBE5D0
		public InputActionProperty scrollWheelAction { get; set; } // 0x0000000181DBE4A0-0x0000000181DBE4C0 0x0000000181DBEB50-0x0000000181DBEB80
	
		// Nested types
		public enum CursorMode // TypeDefIndex: 6316
		{
			SoftwareCursor = 0,
			HardwareCursorIfAvailable = 1
		}
	
		// Constructors
		public VirtualMouseInput(); // 0x0000000181DBE3E0-0x0000000181DBE400
	
		// Methods
		protected void OnEnable(); // 0x0000000181DBD410-0x0000000181DBD9B0
		protected void OnDisable(); // 0x0000000181DBD070-0x0000000181DBD410
		private void TryFindCanvas(); // 0x0000000181DBDD50-0x0000000181DBDDF0
		private void TryEnableHardwareCursor(); // 0x0000000181DBDB30-0x0000000181DBDD50
		private void UpdateMotion(); // 0x0000000181DBDDF0-0x0000000181DBE3E0
		private void OnButtonActionTriggered(InputAction.CallbackContext context); // 0x0000000181DBCEA0-0x0000000181DBD070
		private static void SetActionCallback(InputActionProperty field, Action<InputAction.CallbackContext> callback, bool install = true /* Metadata: 0x00698E00 */); // 0x0000000181DBD9B0-0x0000000181DBDA30
		private static void SetAction(ref InputActionProperty field, InputActionProperty value); // 0x0000000181DBDA30-0x0000000181DBDB30
		private void OnAfterInputUpdate(); // 0x0000000181DBCE90-0x0000000181DBCEA0
	}
}
