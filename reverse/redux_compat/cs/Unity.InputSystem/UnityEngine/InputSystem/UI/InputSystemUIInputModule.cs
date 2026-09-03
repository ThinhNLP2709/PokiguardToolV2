/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Serialization;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.UI
{
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/UISupport.html#setting-up-ui-input")]
	public class InputSystemUIInputModule : BaseInputModule // TypeDefIndex: 6304
	{
		// Fields
		private const float kClickSpeed = 0.3f; // Metadata: 0x00698DF6
		[FormerlySerializedAs("m_RepeatDelay")]
		[SerializeField]
		[Tooltip("The Initial delay (in seconds) between an initial move action and a repeated move action.")]
		private float m_MoveRepeatDelay; // 0x58
		[FormerlySerializedAs("m_RepeatRate")]
		[SerializeField]
		[Tooltip("The speed (in seconds) that the move action repeats itself once repeating (max 1 per frame).")]
		private float m_MoveRepeatRate; // 0x5C
		[Tooltip("Scales the Eventsystem.DragThreshold, for tracked devices, to make selection easier.")]
		private float m_TrackedDeviceDragThresholdMultiplier; // 0x60
		[SerializeField]
		[Tooltip("Transform representing the real world origin for tracking devices. When using the XR Interaction Toolkit, this should be pointing to the XR Rig\'s Transform.")]
		private Transform m_XRTrackingOrigin; // 0x68
		private static DefaultInputActions defaultActions; // 0x00
		private const float kSmallestScrollDeltaPerTick = 1E-05f; // Metadata: 0x00698DFA
		[HideInInspector]
		[SerializeField]
		private InputActionAsset m_ActionsAsset; // 0x70
		[HideInInspector]
		[SerializeField]
		private InputActionReference m_PointAction; // 0x78
		[HideInInspector]
		[SerializeField]
		private InputActionReference m_MoveAction; // 0x80
		[HideInInspector]
		[SerializeField]
		private InputActionReference m_SubmitAction; // 0x88
		[HideInInspector]
		[SerializeField]
		private InputActionReference m_CancelAction; // 0x90
		[HideInInspector]
		[SerializeField]
		private InputActionReference m_LeftClickAction; // 0x98
		[HideInInspector]
		[SerializeField]
		private InputActionReference m_MiddleClickAction; // 0xA0
		[HideInInspector]
		[SerializeField]
		private InputActionReference m_RightClickAction; // 0xA8
		[HideInInspector]
		[SerializeField]
		private InputActionReference m_ScrollWheelAction; // 0xB0
		[HideInInspector]
		[SerializeField]
		private InputActionReference m_TrackedDevicePositionAction; // 0xB8
		[HideInInspector]
		[SerializeField]
		private InputActionReference m_TrackedDeviceOrientationAction; // 0xC0
		[SerializeField]
		private bool m_DeselectOnBackgroundClick; // 0xC8
		[SerializeField]
		private UIPointerBehavior m_PointerBehavior; // 0xCC
		[HideInInspector]
		[SerializeField]
		internal CursorLockBehavior m_CursorLockBehavior; // 0xD0
		[SerializeField]
		private float m_ScrollDeltaPerTick; // 0xD4
		private static Dictionary<InputAction, InputActionReferenceState> s_InputActionReferenceCounts; // 0x08
		[NonSerialized]
		private bool m_ActionsHooked; // 0xD8
		[NonSerialized]
		private bool m_NeedToPurgeStalePointers; // 0xD9
		private Action<InputAction.CallbackContext> m_OnPointDelegate; // 0xE0
		private Action<InputAction.CallbackContext> m_OnMoveDelegate; // 0xE8
		private Action<InputAction.CallbackContext> m_OnSubmitCancelDelegate; // 0xF0
		private Action<InputAction.CallbackContext> m_OnLeftClickDelegate; // 0xF8
		private Action<InputAction.CallbackContext> m_OnRightClickDelegate; // 0x100
		private Action<InputAction.CallbackContext> m_OnMiddleClickDelegate; // 0x108
		private Action<InputAction.CallbackContext> m_OnScrollWheelDelegate; // 0x110
		private Action<InputAction.CallbackContext> m_OnTrackedDevicePositionDelegate; // 0x118
		private Action<InputAction.CallbackContext> m_OnTrackedDeviceOrientationDelegate; // 0x120
		private Action<object> m_OnControlsChangedDelegate; // 0x128
		[NonSerialized]
		private int m_CurrentPointerId; // 0x130
		[NonSerialized]
		private int m_CurrentPointerIndex; // 0x134
		[NonSerialized]
		internal UIPointerType m_CurrentPointerType; // 0x138
		internal InlinedArray<int> m_PointerIds; // 0x140
		internal InlinedArray<PointerModel> m_PointerStates; // 0x150
		private NavigationModel m_NavigationState; // 0x3E0
		private SubmitCancelModel m_SubmitCancelState; // 0x408
		[NonSerialized]
		private GameObject m_LocalMultiPlayerRoot; // 0x418
	
		// Properties
		public bool deselectOnBackgroundClick { get; set; } // 0x00000001815989B0-0x00000001815989C0 0x0000000181DB5430-0x0000000181DB5440
		public UIPointerBehavior pointerBehavior { get; set; } // 0x00000001816A28D0-0x00000001816A28E0 0x0000000181DB5580-0x0000000181DB5590
		public CursorLockBehavior cursorLockBehavior { get; set; } // 0x0000000181DB4BA0-0x0000000181DB4BB0 0x0000000181DB5420-0x0000000181DB5430
		internal GameObject localMultiPlayerRoot { get; set; } // 0x0000000181DB4C10-0x0000000181DB4C20 0x0000000181DB5480-0x0000000181DB54A0
		public float scrollDeltaPerTick { get; set; } // 0x0000000181DB4C20-0x0000000181DB4C30 0x0000000181DB55D0-0x0000000181DB55E0
		public float moveRepeatDelay { get; set; } // 0x000000018042C5E0-0x000000018042C5F0 0x0000000181DB54E0-0x0000000181DB54F0
		public float moveRepeatRate { get; set; } // 0x0000000181D8CCB0-0x0000000181D8CCC0 0x0000000181DB54F0-0x0000000181DB5500
		private bool explictlyIgnoreFocus { get; } // 0x0000000181DB4BB0-0x0000000181DB4C10 
		private bool shouldIgnoreFocus { get; } // 0x0000000181DB4C30-0x0000000181DB4CE0 
		[Obsolete("\'repeatRate\' has been obsoleted; use \'moveRepeatRate\' instead. (UnityUpgradable) -> moveRepeatRate", false)]
		public float repeatRate { get; set; } // 0x0000000181D8CCB0-0x0000000181D8CCC0 0x0000000181DB54F0-0x0000000181DB5500
		[Obsolete("\'repeatDelay\' has been obsoleted; use \'moveRepeatDelay\' instead. (UnityUpgradable) -> moveRepeatDelay", false)]
		public float repeatDelay { get; set; } // 0x000000018042C5E0-0x000000018042C5F0 0x0000000181DB54E0-0x0000000181DB54F0
		public Transform xrTrackingOrigin { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		public float trackedDeviceDragThresholdMultiplier { get; set; } // 0x0000000181D8CCA0-0x0000000181D8CCB0 0x0000000181DB5660-0x0000000181DB5670
		public InputActionReference point { get; set; } // 0x000000018033D4E0-0x000000018033D4F0 0x0000000181DB5540-0x0000000181DB5580
		public InputActionReference scrollWheel { get; set; } // 0x00000001806BAE60-0x00000001806BAE70 0x0000000181DB55E0-0x0000000181DB5620
		public InputActionReference leftClick { get; set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x0000000181DB5440-0x0000000181DB5480
		public InputActionReference middleClick { get; set; } // 0x00000001805B5990-0x00000001805B59A0 0x0000000181DB54A0-0x0000000181DB54E0
		public InputActionReference rightClick { get; set; } // 0x000000018033D510-0x000000018033D520 0x0000000181DB5590-0x0000000181DB55D0
		public InputActionReference move { get; set; } // 0x000000018033D4A0-0x000000018033D4B0 0x0000000181DB5500-0x0000000181DB5540
		public InputActionReference submit { get; set; } // 0x000000018038B8A0-0x000000018038B8B0 0x0000000181DB5620-0x0000000181DB5660
		public InputActionReference cancel { get; set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000181DB53E0-0x0000000181DB5420
		public InputActionReference trackedDeviceOrientation { get; set; } // 0x00000001806CCB70-0x00000001806CCB80 0x0000000181DB5670-0x0000000181DB56B0
		public InputActionReference trackedDevicePosition { get; set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x0000000181DB56B0-0x0000000181DB56F0
		[Obsolete("\'trackedDeviceSelect\' has been obsoleted; use \'leftClick\' instead.", true)]
		public InputActionReference trackedDeviceSelect { get; set; } // 0x0000000181DB4CE0-0x0000000181DB4D20 0x0000000181DB56F0-0x0000000181DB5730
		public InputActionAsset actionsAsset { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000181DB4D20-0x0000000181DB53E0
		internal new bool sendPointerHoverToParent { get; set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
	
		// Nested types
		private struct InputActionReferenceState // TypeDefIndex: 6305
		{
			// Fields
			public int refCount; // 0x00
			public bool enabledByInputModule; // 0x04
		}
	
		public enum CursorLockBehavior // TypeDefIndex: 6306
		{
			OutsideScreen = 0,
			ScreenCenter = 1
		}
	
		// Constructors
		public InputSystemUIInputModule(); // 0x0000000181DB4B60-0x0000000181DB4BA0
		static InputSystemUIInputModule(); // 0x0000000181DB4AD0-0x0000000181DB4B60
	
		// Methods
		public override void ActivateModule(); // 0x0000000181DACE60-0x0000000181DACF20
		public override bool IsPointerOverGameObject(int pointerOrTouchId); // 0x0000000181DAF6B0-0x0000000181DAF870
		public RaycastResult GetLastRaycastResult(int pointerOrTouchId); // 0x0000000181DAE060-0x0000000181DAE1C0
		private RaycastResult PerformRaycast(ExtendedPointerEventData eventData); // 0x0000000181DB08B0-0x0000000181DB0C20
		private void ProcessPointer(ref PointerModel state); // 0x0000000181DB2870-0x0000000181DB3030
		private bool PointerShouldIgnoreTransform(Transform t); // 0x0000000181DB0C20-0x0000000181DB0D10
		private void ProcessPointerMovement(ref PointerModel pointer, ExtendedPointerEventData eventData); // 0x0000000181DB1FA0-0x0000000181DB2000
		private void ProcessPointerMovement(ExtendedPointerEventData eventData, GameObject currentPointerTarget); // 0x0000000181DB2000-0x0000000181DB2710
		private void ProcessPointerButton(ref PointerModel.ButtonState button, PointerEventData eventData); // 0x0000000181DB17C0-0x0000000181DB1FA0
		private void ProcessPointerButtonDrag(ref PointerModel.ButtonState button, ExtendedPointerEventData eventData); // 0x0000000181DB14B0-0x0000000181DB17C0
		private static void ProcessPointerScroll(ref PointerModel pointer, PointerEventData eventData); // 0x0000000181DB2710-0x0000000181DB2870
		internal void ProcessNavigation(ref NavigationModel navigationState); // 0x0000000181DB0D10-0x0000000181DB14B0
		private bool IsMoveAllowed(AxisEventData eventData); // 0x0000000181DAF4E0-0x0000000181DAF6B0
		private void SwapAction(ref InputActionReference property, InputActionReference newValue, bool actionsHooked, Action<InputAction.CallbackContext> actionCallback); // 0x0000000181DB43B0-0x0000000181DB4640
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ResetDefaultActions(); // 0x0000000181DB3870-0x0000000181DB3900
		public void AssignDefaultActions(); // 0x0000000181DAD220-0x0000000181DAD710
		public void UnassignActions(); // 0x0000000181DB47C0-0x0000000181DB4A10
		protected override void Awake(); // 0x0000000181DAD710-0x0000000181DAD750
		protected override void OnDestroy(); // 0x0000000181DAF880-0x0000000181DAF8C0
		protected override void OnEnable(); // 0x0000000181DAFAC0-0x0000000181DAFC80
		protected override void OnDisable(); // 0x0000000181DAF8C0-0x0000000181DAFAC0
		private void ResetPointers(); // 0x0000000181DB3900-0x0000000181DB3A80
		private bool HasNoActions(); // 0x0000000181DAEE70-0x0000000181DAEFE0
		private void EnableAllActions(); // 0x0000000181DAD9E0-0x0000000181DADAA0
		private void DisableAllActions(); // 0x0000000181DAD900-0x0000000181DAD9E0
		private void EnableInputAction(InputActionReference inputActionReference); // 0x0000000181DADAA0-0x0000000181DADC10
		private void TryDisableInputAction(InputActionReference inputActionReference, bool isComponentDisabling = false /* Metadata: 0x00698DF4 */); // 0x0000000181DB4640-0x0000000181DB47C0
		private int GetPointerStateIndexFor(int pointerOrTouchId); // 0x0000000181DAE3C0-0x0000000181DAE590
		private ref PointerModel GetPointerStateForIndex(int index); // 0x0000000181DAE2D0-0x0000000181DAE320
		private int GetDisplayIndexFor(InputControl control); // 0x0000000181DADFD0-0x0000000181DAE060
		private int GetPointerStateIndexFor(ref InputAction.CallbackContext context); // 0x0000000181DAE320-0x0000000181DAE3C0
		private int GetPointerStateIndexFor(InputControl control, bool createIfNotExists = true /* Metadata: 0x00698DF5 */); // 0x0000000181DAE590-0x0000000181DAEE70
		private int AllocatePointer(int pointerId, int displayIndex, int touchId, UIPointerType pointerType, InputControl control, InputDevice device, InputControl touchControl = null); // 0x0000000181DACF20-0x0000000181DAD220
		private bool SendPointerExitEventsAndRemovePointer(int index); // 0x0000000181DB3A80-0x0000000181DB3BD0
		private bool RemovePointerAtIndex(int index); // 0x0000000181DB3570-0x0000000181DB3870
		private void PurgeStalePointers(); // 0x0000000181DB33D0-0x0000000181DB3570
		private static bool HaveControlForDevice(InputDevice device, InputActionReference actionReference); // 0x0000000181DAEFE0-0x0000000181DAF0B0
		private void OnPointCallback(InputAction.CallbackContext context); // 0x0000000181DB0060-0x0000000181DB0180
		private bool IgnoreNextClick(ref InputAction.CallbackContext context, bool wasPressed); // 0x0000000181DAF3D0-0x0000000181DAF4E0
		private void OnLeftClickCallback(InputAction.CallbackContext context); // 0x0000000181DAFC80-0x0000000181DAFE10
		private void OnRightClickCallback(InputAction.CallbackContext context); // 0x0000000181DB0180-0x0000000181DB0330
		private void OnMiddleClickCallback(InputAction.CallbackContext context); // 0x0000000181DAFE10-0x0000000181DAFFC0
		private bool CheckForRemovedDevice(ref InputAction.CallbackContext context); // 0x0000000181DAD750-0x0000000181DAD7C0
		private void OnScrollCallback(InputAction.CallbackContext context); // 0x0000000181DB0330-0x0000000181DB0510
		private void OnMoveCallback(InputAction.CallbackContext context); // 0x0000000181DAFFC0-0x0000000181DB0060
		private void OnSubmitCancelCallback(InputAction.CallbackContext context); // 0x0000000181DB0510-0x0000000181DB0550
		private void OnTrackedDeviceOrientationCallback(InputAction.CallbackContext context); // 0x0000000181DB0550-0x0000000181DB0700
		private void OnTrackedDevicePositionCallback(InputAction.CallbackContext context); // 0x0000000181DB0700-0x0000000181DB08B0
		private void OnControlsChanged(object obj); // 0x0000000181DAF870-0x0000000181DAF880
		private void FilterPointerStatesByType(); // 0x0000000181DADC10-0x0000000181DADFD0
		public override void Process(); // 0x0000000181DB3030-0x0000000181DB33D0
		public override int ConvertUIToolkitPointerId(PointerEventData sourcePointerData); // 0x0000000181DAD830-0x0000000181DAD900
		public override Vector2 ConvertPointerEventScrollDeltaToTicks(Vector2 scrollDelta); // 0x0000000181DAD7C0-0x0000000181DAD830
		public override NavigationDeviceType GetNavigationEventDeviceType(BaseEventData eventData); // 0x0000000181DAE1C0-0x0000000181DAE2D0
		private void HookActions(); // 0x0000000181DAF0B0-0x0000000181DAF3D0
		private void UnhookActions(); // 0x0000000181DB4A10-0x0000000181DB4A30
		private void SetActionCallbacks(bool install); // 0x0000000181DB3CB0-0x0000000181DB43B0
		private static void SetActionCallback(InputActionReference actionReference, Action<InputAction.CallbackContext> callback, bool install); // 0x0000000181DB3BD0-0x0000000181DB3CB0
		private InputActionReference UpdateReferenceForNewAsset(InputActionReference actionReference); // 0x0000000181DB4A30-0x0000000181DB4AD0
	}
}
