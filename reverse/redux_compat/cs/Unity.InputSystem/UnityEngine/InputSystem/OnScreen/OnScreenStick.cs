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
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.Serialization;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.OnScreen
{
	[AddComponentMenu("Input/On-Screen Stick")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/OnScreen.html#on-screen-sticks")]
	public class OnScreenStick : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IDragHandler // TypeDefIndex: 6334
	{
		// Fields
		private const string kDynamicOriginClickable = "DynamicOriginClickable"; // Metadata: 0x00698E2C
		[FormerlySerializedAs("movementRange")]
		[Min(0f)]
		[SerializeField]
		private float m_MovementRange; // 0x38
		[Min(0f)]
		[SerializeField]
		[Tooltip("Defines the circular region where the onscreen control may have it\'s origin placed.")]
		private float m_DynamicOriginRange; // 0x3C
		[InputControl(layout = "Vector2")]
		[SerializeField]
		private string m_ControlPath; // 0x40
		[SerializeField]
		[Tooltip("Choose how the onscreen stick will move relative to it\'s origin and the press position.\n\nRelativePositionWithStaticOrigin: The control\'s center of origin is fixed. The control will begin un-actuated at it\'s centered position and then move relative to the pointer or finger motion.\n\nExactPositionWithStaticOrigin: The control\'s center of origin is fixed. The stick will immediately jump to the exact position of the click or touch and begin tracking motion from there.\n\nExactPositionWithDynamicOrigin: The control\'s center of origin is determined by the initial press position. The stick will begin un-actuated at this center position and then track the current pointer or finger position.")]
		private Behaviour m_Behaviour; // 0x48
		[SerializeField]
		[Tooltip("Set this to true to prevent cancellation of pointer events due to device switching. Cancellation will appear as the stick jumping back and forth between the pointer position and the stick center.")]
		private bool m_UseIsolatedInputActions; // 0x4C
		[SerializeField]
		[Tooltip("The action that will be used to detect pointer down events on the stick control. Note that if no bindings are set, default ones will be provided.")]
		private InputAction m_PointerDownAction; // 0x50
		[SerializeField]
		[Tooltip("The action that will be used to detect pointer movement on the stick control. Note that if no bindings are set, default ones will be provided.")]
		private InputAction m_PointerMoveAction; // 0x58
		private Vector3 m_StartPos; // 0x60
		private Vector2 m_PointerDownPos; // 0x6C
		[NonSerialized]
		private List<RaycastResult> m_RaycastResults; // 0x78
		[NonSerialized]
		private PointerEventData m_PointerEventData; // 0x80
		[NonSerialized]
		private TouchControl m_TouchControl; // 0x88
		[NonSerialized]
		private bool m_IsIsolationActive; // 0x90
	
		// Properties
		public float movementRange { get; set; } // 0x0000000181C62E80-0x0000000181C62E90 0x0000000181C62E90-0x0000000181C62EA0
		public float dynamicOriginRange { get; set; } // 0x0000000181C58AB0-0x0000000181C58AC0 0x0000000181DB8FC0-0x0000000181DB90D0
		public bool useIsolatedInputActions { get; set; } // 0x00000001803B6550-0x00000001803B6560 0x0000000181DB90D0-0x0000000181DB90E0
		protected override string controlPathInternal { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		public Behaviour behaviour { get; set; } // 0x000000018033D1C0-0x000000018033D1D0 0x000000018033E7A0-0x000000018033E7B0
	
		// Nested types
		public enum Behaviour // TypeDefIndex: 6335
		{
			RelativePositionWithStaticOrigin = 0,
			ExactPositionWithStaticOrigin = 1,
			ExactPositionWithDynamicOrigin = 2
		}
	
		// Constructors
		public OnScreenStick(); // 0x0000000181DB8FA0-0x0000000181DB8FC0
	
		// Methods
		public void OnPointerDown(PointerEventData eventData); // 0x0000000181DB84C0-0x0000000181DB8570
		public void OnDrag(PointerEventData eventData); // 0x0000000181DB7B40-0x0000000181DB7BF0
		public void OnPointerUp(PointerEventData eventData); // 0x0000000181DB8790-0x0000000181DB87A0
		private void Start(); // 0x0000000181DB87A0-0x0000000181DB8EA0
		private void OnDestroy(); // 0x0000000181DB7AA0-0x0000000181DB7B40
		private void BeginInteraction(Vector2 pointerPosition, Camera uiCamera); // 0x0000000181DB7140-0x0000000181DB73B0
		private void MoveStick(Vector2 pointerPosition, Camera uiCamera); // 0x0000000181DB7730-0x0000000181DB7AA0
		private void EndInteraction(); // 0x0000000181DB7540-0x0000000181DB7610
		private void OnPointerDown(InputAction.CallbackContext ctx); // 0x0000000181DB8020-0x0000000181DB84C0
		private void OnPointerChanged(InputAction.CallbackContext ctx); // 0x0000000181DB7ED0-0x0000000181DB8020
		private void OnPointerMove(InputAction.CallbackContext ctx); // 0x0000000181DB8570-0x0000000181DB8680
		private void OnPointerUp(InputAction.CallbackContext ctx); // 0x0000000181DB8680-0x0000000181DB8790
		private Camera GetCameraFromCanvas(); // 0x0000000181DB7610-0x0000000181DB7730
		private void OnDrawGizmosSelected(); // 0x0000000181DB7BF0-0x0000000181DB7ED0
		private void DrawGizmoCircle(Vector2 center, float radius); // 0x0000000181DB73B0-0x0000000181DB7540
		private void UpdateDynamicOriginClickableArea(); // 0x0000000181DB8EA0-0x0000000181DB8FA0
	}
}
