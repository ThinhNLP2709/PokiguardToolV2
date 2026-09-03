/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class CodeStrippingSafeUIElementsRuntimeUtilityImpl : CodeStrippingSafeUIElementsRuntimeUtility, IPointerDeviceState // TypeDefIndex: 4198
	{
		// Properties
		public UnityEngine.Object activeEventSystem { get; } // 0x00000001824AE320-0x00000001824AE3B0 
		public int s_ResolvedSortingIndexMax { get; } // 0x00000001824AE3B0-0x00000001824AE400 
		int CodeStrippingSafeUIElementsRuntimeUtility.s_DoubleClickTime { get; } // 0x00000001824AE240-0x00000001824AE2D0 
	
		// Constructors
		public CodeStrippingSafeUIElementsRuntimeUtilityImpl(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void AddOnCreatePanelAction(Action<IRuntimePanel> action); // 0x00000001824ADB50-0x00000001824ADBA0
		public void RemoveOnCreatePanelAction(Action<IRuntimePanel> action); // 0x00000001824AE090-0x00000001824AE0E0
		public void GetCapturingElement(int pointerId, out IRuntimePanel panel, out IEventHandler element); // 0x00000001824ADBF0-0x00000001824ADD50
		public void RegisterEventSystem(UnityEngine.Object eventSystem); // 0x00000001824ADFE0-0x00000001824AE030
		public void UnregisterEventSystem(UnityEngine.Object eventSystem); // 0x00000001824AE2D0-0x00000001824AE320
		public List<IRuntimePanel> GetSortedPlayerPanelsInternal(); // 0x00000001824ADE90-0x00000001824ADED0
		public IRuntimePanel GetPlayerPanelWithSoftPointerCapture(int pointerId); // 0x00000001824ADD50-0x00000001824ADDA0
		public void PressButton(int pointerId, int buttonId); // 0x00000001824ADF80-0x00000001824ADFE0
		public void ReleaseButton(int pointerId, int buttonId); // 0x00000001824AE030-0x00000001824AE090
		public int GetPressedButtons(int pointerId); // 0x00000001824ADE40-0x00000001824ADE90
		public Vector3 GetPointerDeltaPosition(int pointerId, ContextType contextType, Vector3 newPosition); // 0x00000001824ADDA0-0x00000001824ADE40
		public Camera GetCameraWithSoftPointerCapture(int pointerId); // 0x00000001824ADBA0-0x00000001824ADBF0
		public IPanelComponent GetWorldSpacePanelComponentWithSoftPointerCapture(int pointerId); // 0x00000001824ADED0-0x00000001824ADF20
		public bool HasActiveDocuments(); // 0x00000001824ADF20-0x00000001824ADF80
		bool CodeStrippingSafeUIElementsRuntimeUtility.TryPickWithCapture(int pointerId, Ray worldRay, float maxDistance, int layerMask, out Collider collider, out IPanelComponent panelComponent, out IEventHandler elementUnderPointer, out float distance, out bool captured); // 0x00000001824AE170-0x00000001824AE1F0
		bool CodeStrippingSafeUIElementsRuntimeUtility.TryPick(IRuntimePanel panel, int pointerId, Vector2 screenPosition, Vector2 delta, int? targetDisplay, out bool captured); // 0x00000001824AE1F0-0x00000001824AE240
		Vector3 CodeStrippingSafeUIElementsRuntimeUtility.PanelToScreenBottomLeftPosition(Vector2 mousePosition, int targetDisplay); // 0x00000001824AE0E0-0x00000001824AE170
	}
}
