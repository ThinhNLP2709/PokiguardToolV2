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
	internal static class PhysicsDocumentPicker // TypeDefIndex: 4172
	{
		// Methods
		private static void Pick(Ray worldRay, float maxDistance, int layerMask, out Collider collider, out IPanelComponent panelComponent, out IEventHandler pickedElement, out float distance); // 0x00000001824A3C40-0x00000001824A3D00
		public static bool TryPickWithCapture(int pointerId, Ray worldRay, float maxDistance, int layerMask, out Collider collider, out IPanelComponent panelComponent, out IEventHandler elementUnderPointer, out float distance, out bool captured); // 0x00000001824A3D00-0x00000001824A3F30
		private static bool GetCapturingDocument(int pointerId, out IPanelComponent capturingComponent); // 0x00000001824A39B0-0x00000001824A3C40
	}
}
