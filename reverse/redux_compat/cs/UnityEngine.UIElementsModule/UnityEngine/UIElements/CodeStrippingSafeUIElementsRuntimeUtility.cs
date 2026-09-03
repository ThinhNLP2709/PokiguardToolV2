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
	internal interface CodeStrippingSafeUIElementsRuntimeUtility // TypeDefIndex: 4196
	{
		// Properties
		UnityEngine.Object activeEventSystem { get; }
		int s_ResolvedSortingIndexMax { get; }
		int s_DoubleClickTime { get; }
	
		// Methods
		bool HasActiveDocuments();
		List<IRuntimePanel> GetSortedPlayerPanelsInternal();
		void AddOnCreatePanelAction(Action<IRuntimePanel> action);
		void RemoveOnCreatePanelAction(Action<IRuntimePanel> action);
		void RegisterEventSystem(UnityEngine.Object eventSystem);
		void UnregisterEventSystem(UnityEngine.Object eventSystem);
		void GetCapturingElement(int pointerId, out IRuntimePanel panel, out IEventHandler element);
		bool TryPick(IRuntimePanel panel, int pointerId, Vector2 screenPosition, Vector2 delta, int? targetDisplay, out bool captured);
		bool TryPickWithCapture(int pointerId, Ray worldRay, float maxDistance, int layerMask, out Collider collider, out IPanelComponent panelComponent, out IEventHandler elementUnderPointer, out float distance, out bool captured);
		Vector3 PanelToScreenBottomLeftPosition(Vector2 mousePosition, int targetDisplay);
	}
}
