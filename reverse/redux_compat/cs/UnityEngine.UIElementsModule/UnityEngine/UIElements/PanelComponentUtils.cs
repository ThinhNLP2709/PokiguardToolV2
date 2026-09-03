/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
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
	internal static class PanelComponentUtils // TypeDefIndex: 4178
	{
		// Methods
		public static bool IsTransformControlledByGameObject(IPanelComponent panelComponent); // 0x00000001824A0D40-0x00000001824A0EB0
		public static void ComputeParentTransform(Vector2 pivotOffset, float pixelsPerUnit, out Matrix4x4 matrix); // 0x00000001824A0900-0x00000001824A0A00
		public static void ComputeNestedTransform(Transform transform, Transform parentTransform, Vector2 pivotOffset, Vector2 parentPivotOffset, float pixelsPerUnit, out Matrix4x4 matrix); // 0x00000001824A0610-0x00000001824A0900
		public static Matrix4x4 TransformToGameObjectMatrix(Vector2 pivotOffset, float pixelsPerUnit); // 0x00000001824A1490-0x00000001824A1550
		public static Matrix4x4 ScaleAndFlipMatrix(float pixelsPerUnit); // 0x00000001824A1310-0x00000001824A1490
		public static Bounds LocalBoundsFromPivotSource(VisualElement root, PivotReferenceSize pivotReferenceSize); // 0x00000001824A0F00-0x00000001824A11F0
		public static Bounds SanitizeRendererBounds(Bounds b); // 0x00000001824A11F0-0x00000001824A1310
		public static Vector2 GetPivotAsPercent(Pivot origin); // 0x00000001824A0C40-0x00000001824A0D40
		public static bool IsValidBounds([IsReadOnly] in Bounds b); // 0x00000001824A0EB0-0x00000001824A0F00
		internal static Vector3 GetPanelPosition(GameObject gameObject, IEventHandler pickedElement, Ray worldRay); // 0x00000001824A0A00-0x00000001824A0C40
	}
}
