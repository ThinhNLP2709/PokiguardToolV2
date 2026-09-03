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
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal static class WorldSpaceInput // TypeDefIndex: 4213
	{
		// Nested types
		public struct PickResult // TypeDefIndex: 4214
		{
			// Fields
			public static readonly PickResult Empty; // 0x00
			public Collider collider; // 0x00
			public IPanelComponent panelComponent; // 0x08
			public VisualElement pickedElement; // 0x10
			public float distance; // 0x18
			public Vector3 normal; // 0x1C
			public Vector3 point; // 0x28
			public Vector3 localPoint; // 0x34
	
			// Constructors
			static PickResult(); // 0x00000001824BA610-0x00000001824BA680
	
			// Methods
			internal void ComputeCollisionData(Ray ray); // 0x00000001824BA360-0x00000001824BA610
		}
	
		// Methods
		public static VisualElement Pick3D(IPanelComponent panelComponent, Ray worldRay, out float distance); // 0x00000001824CA740-0x00000001824CAB70
		public static VisualElement Pick3D(IPanel panel, Ray panelRay, List<VisualElement> outResults = null); // 0x00000001824CA5F0-0x00000001824CA740
		public static VisualElement Pick3D(VisualElement rootVisualElement, Ray localRay, List<VisualElement> outResults = null); // 0x00000001824CAB70-0x00000001824CAC10
		public static PickResult PickDocument3D(Ray worldRay, float maxDistance = 1F / 0F /* Metadata: 0x00660639 */, int layerMask = -5 /* Metadata: 0x0066063D */); // 0x00000001824CAC10-0x00000001824CB4D0
		internal static VisualElement Pick_Internal(IPanelComponent panelComponent, Ray documentRay, List<VisualElement> outResults = null); // 0x00000001824CB4D0-0x00000001824CC090
		[VisibleToOtherModules(new string[1] {"Assembly-CSharp-testable" })]
		internal static VisualElement PerformPick(VisualElement root, Ray ray, List<VisualElement> outResults); // 0x00000001824CA570-0x00000001824CA5F0
		private static VisualElement PerformPick2D(VisualElement root, Ray ray, List<VisualElement> outResults); // 0x00000001824C9E80-0x00000001824CA270
		private static VisualElement PerformPick3D(VisualElement root, Ray ray, List<VisualElement> outResults); // 0x00000001824CA270-0x00000001824CA570
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static Bounds GetPicking3DWorldBounds(VisualElement ve); // 0x00000001824C9DD0-0x00000001824C9E80
		internal static Bounds GetPicking3DLocalBounds(VisualElement ve); // 0x00000001824C9CC0-0x00000001824C9DD0
	}
}
