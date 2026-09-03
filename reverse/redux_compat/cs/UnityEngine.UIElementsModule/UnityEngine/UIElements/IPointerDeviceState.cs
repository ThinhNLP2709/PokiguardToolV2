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
	internal interface IPointerDeviceState // TypeDefIndex: 4197
	{
		// Methods
		IRuntimePanel GetPlayerPanelWithSoftPointerCapture(int pointerId);
		void PressButton(int pointerId, int buttonId);
		void ReleaseButton(int pointerId, int buttonId);
		int GetPressedButtons(int pointerId);
		Vector3 GetPointerDeltaPosition(int pointerId, ContextType contextType, Vector3 newPosition);
		Camera GetCameraWithSoftPointerCapture(int pointerId);
		IPanelComponent GetWorldSpacePanelComponentWithSoftPointerCapture(int pointerId);
	}
}
