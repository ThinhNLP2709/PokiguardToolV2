/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[MovedFrom("UnityEditor")]
	[VisibleToOtherModules(new string[3] {"UnityEngine.UIElementsModule", "UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal class NumericFieldDraggerUtility // TypeDefIndex: 7678
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static bool s_UseYSign; // 0x00
	
		// Methods
		public static float Acceleration(bool shiftPressed, bool altPressed); // 0x00000001821EF340-0x00000001821EF380
		public static float NiceDelta(Vector2 deviceDelta, float acceleration); // 0x00000001821EF440-0x00000001821EF550
		public static double CalculateFloatDragSensitivity(double value, double minValue, double maxValue); // 0x00000001821EF380-0x00000001821EF440
	}
}
