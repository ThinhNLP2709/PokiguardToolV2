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
	public static class VisualElementExtensions // TypeDefIndex: 4011
	{
		// Fields
		private static readonly string[] k_ThreeStrings; // 0x00
	
		// Constructors
		static VisualElementExtensions(); // 0x0000000182479BE0-0x0000000182479C50
	
		// Extension methods
		public static void AddManipulator(this VisualElement ele, IManipulator manipulator); // 0x0000000182477FD0-0x0000000182478020
		public static void RemoveManipulator(this VisualElement ele, IManipulator manipulator); // 0x0000000182479330-0x0000000182479380
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal static TElement WithClassList<TElement>(this TElement ele, string className)
			where TElement : VisualElement;
		public static Vector2 WorldToLocal(this VisualElement ele, Vector2 p); // 0x0000000182479AB0-0x0000000182479BE0
		internal static Vector3 WorldToLocal3D(this VisualElement ele, Vector3 p); // 0x0000000182479590-0x0000000182479700
		public static Rect WorldToLocal(this VisualElement ele, Rect r); // 0x0000000182479700-0x0000000182479820
		internal static Ray LocalToWorld([NotNull] this VisualElement ele, Ray r); // 0x00000001824790F0-0x0000000182479330
		internal static Ray WorldToLocal([NotNull] this VisualElement ele, Ray r); // 0x0000000182479820-0x0000000182479AB0
		internal static Vector2 ChangeCoordinatesTo_2D([NotNull] this VisualElement src, [NotNull] VisualElement dest, Vector2 point); // 0x0000000182478020-0x0000000182478170
		internal static Vector2 ChangeCoordinatesTo_3D([NotNull] this VisualElement src, [NotNull] VisualElement dest, Vector2 point); // 0x0000000182478170-0x0000000182478300
		public static Rect ChangeCoordinatesTo(this VisualElement src, VisualElement dest, Rect rect); // 0x00000001824783D0-0x0000000182478870
		internal static Ray ChangeCoordinatesTo([NotNull] this VisualElement src, [NotNull] VisualElement dest, Ray ray); // 0x0000000182478300-0x00000001824783D0
		internal static bool IntersectWorldRay([NotNull] this VisualElement ve, Ray worldRay, out float distance, out Vector3 localPoint); // 0x0000000182478BB0-0x00000001824790F0
		internal static bool IntersectLocalRay([NotNull] this VisualElement ve, Ray localRay, out Vector3 localPoint); // 0x0000000182478A10-0x0000000182478BB0
		internal static Ray TransformRay(this Matrix4x4 m, Ray ray); // 0x0000000182479380-0x0000000182479590
		public static IPanelComponent FindRootPanelComponent(this VisualElement element); // 0x0000000182478870-0x0000000182478A10
	}
}
