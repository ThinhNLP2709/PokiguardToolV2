/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.EventSystems
{
	public abstract class PointerInputModule : BaseInputModule // TypeDefIndex: 13198
	{
		// Fields
		public const int kMouseLeftId = -1; // Metadata: 0x006A77D7
		public const int kMouseRightId = -2; // Metadata: 0x006A77D8
		public const int kMouseMiddleId = -3; // Metadata: 0x006A77D9
		public const int kFakeTouchesId = -4; // Metadata: 0x006A77DA
		protected Dictionary<int, PointerEventData> m_PointerData; // 0x58
		private readonly MouseState m_MouseState; // 0x60
	
		// Nested types
		protected class ButtonState // TypeDefIndex: 13199
		{
			// Fields
			private PointerEventData.InputButton m_Button; // 0x10
			private MouseButtonEventData m_EventData; // 0x18
	
			// Properties
			public MouseButtonEventData eventData { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
			public PointerEventData.InputButton button { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
	
			// Constructors
			public ButtonState(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		protected class MouseState // TypeDefIndex: 13200
		{
			// Fields
			private List<ButtonState> m_TrackedButtons; // 0x10
	
			// Constructors
			public MouseState(); // 0x00000001825B2F90-0x00000001825B3010
	
			// Methods
			public bool AnyPressesThisFrame(); // 0x00000001825B2C90-0x00000001825B2D20
			public bool AnyReleasesThisFrame(); // 0x00000001825B2D20-0x00000001825B2DB0
			public ButtonState GetButtonState(PointerEventData.InputButton button); // 0x00000001825B2DB0-0x00000001825B2F30
			public void SetButtonState(PointerEventData.InputButton button, PointerEventData.FramePressState stateForMouseButton, PointerEventData data); // 0x00000001825B2F30-0x00000001825B2F90
		}
	
		public class MouseButtonEventData // TypeDefIndex: 13201
		{
			// Fields
			public PointerEventData.FramePressState buttonState; // 0x10
			public PointerEventData buttonData; // 0x18
	
			// Constructors
			public MouseButtonEventData(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public bool PressedThisFrame(); // 0x00000001825B2C50-0x00000001825B2C70
			public bool ReleasedThisFrame(); // 0x00000001825B2C70-0x00000001825B2C90
		}
	
		// Constructors
		protected PointerInputModule(); // 0x00000001825BAC90-0x00000001825BAE00
	
		// Methods
		protected bool GetPointerData(int id, out PointerEventData data, bool create); // 0x00000001825B9F10-0x00000001825BA190
		protected void RemovePointerData(PointerEventData data); // 0x00000001825BA8E0-0x00000001825BA940
		protected PointerEventData GetTouchPointerEventData(Touch input, out bool pressed, out bool released); // 0x00000001825BA190-0x00000001825BA510
		protected void CopyFromTo(PointerEventData from, PointerEventData to); // 0x00000001825B94F0-0x00000001825B9680
		protected PointerEventData.FramePressState StateForMouseButton(int buttonId); // 0x00000001825BA990-0x00000001825BAA50
		protected virtual MouseState GetMousePointerEventData(); // 0x00000001825B9790-0x00000001825B97B0
		protected virtual MouseState GetMousePointerEventData(int id); // 0x00000001825B97B0-0x00000001825B9F10
		protected PointerEventData GetLastPointerEventData(int id); // 0x00000001825B9760-0x00000001825B9790
		private static bool ShouldStartDrag(Vector2 pressPos, Vector2 currentPos, float threshold, bool useDragThreshold); // 0x00000001825BA940-0x00000001825BA990
		protected virtual void ProcessMove(PointerEventData pointerEvent); // 0x00000001825BA880-0x00000001825BA8E0
		protected virtual void ProcessDrag(PointerEventData pointerEvent); // 0x00000001825BA5A0-0x00000001825BA880
		public override bool IsPointerOverGameObject(int pointerId); // 0x00000001825BA510-0x00000001825BA5A0
		protected void ClearSelection(); // 0x00000001825B9380-0x00000001825B94F0
		public override string ToString(); // 0x00000001825BAA50-0x00000001825BAC90
		protected void DeselectIfSelectionChanged(GameObject currentOverGo, BaseEventData pointerEvent); // 0x00000001825B9680-0x00000001825B9760
	}
}
