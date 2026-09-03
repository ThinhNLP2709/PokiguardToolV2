/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class VisualTreeHierarchyFlagsUpdater : BaseVisualTreeUpdater // TypeDefIndex: 4967
	{
		// Fields
		private uint m_Version; // 0x28
		private uint m_LastVersion; // 0x2C
		private static readonly string s_Description; // 0x00
		private static readonly ProfilerMarker s_ProfilerMarker; // 0x08
	
		// Properties
		public override ProfilerMarker profilerMarker { get; } // 0x0000000182404390-0x00000001824043E0 
	
		// Constructors
		public VisualTreeHierarchyFlagsUpdater(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static VisualTreeHierarchyFlagsUpdater(); // 0x00000001824042F0-0x0000000182404390
	
		// Methods
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType); // 0x0000000182404020-0x00000001824041F0
		protected static ValueTuple<VisualElementFlags, VisualElementTransformFlags> GetChildrenMustDirtyFlags(VisualElement ve, VersionChangeType versionChangeType); // 0x0000000182403FC0-0x0000000182404020
		protected static void DirtyChildrenHierarchy(VisualElement ve, [TupleElementNames(new string[2] {"flags", "transformFlags" })] ValueTuple<VisualElementFlags, VisualElementTransformFlags> mustDirty); // 0x0000000182403DF0-0x0000000182403F50
		private static void DirtyBoundingBoxHierarchy(VisualElement ve); // 0x0000000182403D10-0x0000000182403DF0
		private static void DirtyParentHierarchy(VisualElement ve, VisualElementTransformFlags flags); // 0x0000000182403F50-0x0000000182403FC0
		public override void Update(); // 0x00000001824041F0-0x00000001824042F0
	}
}
