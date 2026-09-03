/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class ElementUnderPointer // TypeDefIndex: 3967
	{
		// Fields
		private VisualElement[] m_PendingTopElementUnderPointer; // 0x10
		private VisualElement[] m_TopElementUnderPointer; // 0x18
		private IPointerOrMouseEvent[] m_TriggerEvent; // 0x20
		private Vector2[] m_PickingPointerPositions; // 0x28
		private readonly bool[] m_IsPrimaryPointer; // 0x30
		private bool[] m_IsPickingPointerTemporaries; // 0x38
	
		// Constructors
		public ElementUnderPointer(); // 0x000000018239CE50-0x000000018239D070
	
		// Methods
		internal VisualElement GetTopElementUnderPointer(int pointerId, out Vector2 pickPosition, out bool isTemporary); // 0x000000018239C850-0x000000018239C8C0
		internal VisualElement GetTopElementUnderPointer(int pointerId); // 0x0000000181ACD1B0-0x0000000181ACD1E0
		internal void RemoveElementUnderPointer(VisualElement elementToRemove); // 0x000000018239C8C0-0x000000018239C970
		internal void SetElementUnderPointer(VisualElement newElementUnderPointer, int pointerId, Vector2 pointerPos); // 0x000000018239CCB0-0x000000018239CE30
		private Vector2 GetEventPointerPosition(EventBase triggerEvent); // 0x000000018239C750-0x000000018239C850
		internal void SetTemporaryElementUnderPointer(VisualElement newElementUnderPointer, int pointerId, EventBase triggerEvent); // 0x000000018239CE30-0x000000018239CE50
		internal void SetElementUnderPointer(VisualElement newElementUnderPointer, int pointerId, EventBase triggerEvent); // 0x000000018239CC90-0x000000018239CCB0
		private void SetElementUnderPointer(VisualElement newElementUnderPointer, int pointerId, EventBase triggerEvent, bool temporary); // 0x000000018239C970-0x000000018239CC90
		internal bool CommitElementUnderPointers(EventDispatcher dispatcher, ContextType contextType); // 0x000000018239C1F0-0x000000018239C750
	}
}
