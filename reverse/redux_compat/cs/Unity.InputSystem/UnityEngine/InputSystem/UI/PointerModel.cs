/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.UI
{
	internal struct PointerModel // TypeDefIndex: 6310
	{
		// Fields
		public bool changedThisFrame; // 0x00
		public ButtonState leftButton; // 0x08
		public ButtonState rightButton; // 0xC0
		public ButtonState middleButton; // 0x178
		public ExtendedPointerEventData eventData; // 0x230
		private Vector2 m_ScreenPosition; // 0x238
		private Vector2 m_ScrollDelta; // 0x240
		private Vector3 m_WorldPosition; // 0x248
		private Quaternion m_WorldOrientation; // 0x254
		private float m_Pressure; // 0x264
		private float m_AzimuthAngle; // 0x268
		private float m_AltitudeAngle; // 0x26C
		private float m_Twist; // 0x270
		private Vector2 m_Radius; // 0x274
	
		// Properties
		public UIPointerType pointerType { get; } // 0x0000000180E1AF20-0x0000000180E1AF50 
		public Vector2 screenPosition { get; set; } // 0x0000000181DB9350-0x0000000181DB9370 0x0000000181DB9470-0x0000000181DB94C0
		public Vector3 worldPosition { get; set; } // 0x0000000181DB93A0-0x0000000181DB93C0 0x0000000181DB95A0-0x0000000181DB9620
		public Quaternion worldOrientation { get; set; } // 0x0000000181DB9390-0x0000000181DB93A0 0x0000000181DB9530-0x0000000181DB95A0
		public Vector2 scrollDelta { get; set; } // 0x0000000181DB9370-0x0000000181DB9390 0x0000000181DB94C0-0x0000000181DB9510
		public float pressure { get; set; } // 0x0000000181DB9320-0x0000000181DB9330 0x0000000181DB9400-0x0000000181DB9420
		public float azimuthAngle { get; set; } // 0x0000000180BBD7C0-0x0000000180BBD7D0 0x0000000181DB93E0-0x0000000181DB9400
		public float altitudeAngle { get; set; } // 0x0000000180BBD6F0-0x0000000180BBD700 0x0000000181DB93C0-0x0000000181DB93E0
		public float twist { get; set; } // 0x0000000180BBD7D0-0x0000000180BBD7E0 0x0000000181DB9510-0x0000000181DB9530
		public Vector2 radius { get; set; } // 0x0000000181DB9330-0x0000000181DB9350 0x0000000181DB9420-0x0000000181DB9470
	
		// Nested types
		public struct ButtonState // TypeDefIndex: 6311
		{
			// Fields
			private bool m_IsPressed; // 0x00
			private PointerEventData.FramePressState m_FramePressState; // 0x04
			private float m_PressTime; // 0x08
			private RaycastResult m_PressRaycast; // 0x10
			private GameObject m_PressObject; // 0x80
			private GameObject m_RawPressObject; // 0x88
			private GameObject m_LastPressObject; // 0x90
			private GameObject m_DragObject; // 0x98
			private Vector2 m_PressPosition; // 0xA0
			private float m_ClickTime; // 0xA8
			private int m_ClickCount; // 0xAC
			private bool m_Dragging; // 0xB0
			private bool m_ClickedOnSameGameObject; // 0xB1
			private bool m_IgnoreNextClick; // 0xB2
	
			// Properties
			public bool isPressed { get; set; } // 0x0000000180333490-0x00000001803334A0 0x0000000181DA9A00-0x0000000181DA9A50
			public bool ignoreNextClick { get; set; } // 0x0000000181DA99A0-0x0000000181DA99B0 0x0000000181DA99F0-0x0000000181DA9A00
			public float pressTime { get; set; } // 0x00000001802DB050-0x00000001802DB060 0x0000000181DA9A50-0x0000000181DA9A60
			public bool clickedOnSameGameObject { get; set; } // 0x000000018172A3C0-0x000000018172A3D0 0x000000018172A4C0-0x000000018172A4D0
			public bool wasPressedThisFrame { get; } // 0x0000000181DA99B0-0x0000000181DA99D0 
			public bool wasReleasedThisFrame { get; } // 0x0000000181DA99D0-0x0000000181DA99F0 
	
			// Methods
			public void CopyPressStateTo(PointerEventData eventData); // 0x0000000181DA9860-0x0000000181DA9990
			public void CopyPressStateFrom(PointerEventData eventData); // 0x0000000181DA9730-0x0000000181DA9860
			public void OnEndFrame(); // 0x0000000181DA9990-0x0000000181DA99A0
		}
	
		// Constructors
		public PointerModel(ExtendedPointerEventData eventData); // 0x0000000181DB9260-0x0000000181DB9320
	
		// Methods
		public void OnFrameFinished(); // 0x0000000181DB91E0-0x0000000181DB9260
		public void CopyTouchOrPenStateFrom(PointerEventData eventData); // 0x0000000181DB90E0-0x0000000181DB91E0
	}
}
