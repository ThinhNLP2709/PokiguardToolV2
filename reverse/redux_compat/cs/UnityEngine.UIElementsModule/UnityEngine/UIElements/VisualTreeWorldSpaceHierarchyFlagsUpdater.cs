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
	internal class VisualTreeWorldSpaceHierarchyFlagsUpdater : VisualTreeHierarchyFlagsUpdater // TypeDefIndex: 4968
	{
		// Constructors
		public VisualTreeWorldSpaceHierarchyFlagsUpdater(); // 0x0000000182406FE0-0x0000000182407030
	
		// Methods
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType); // 0x0000000182406E00-0x0000000182406FE0
		private static VisualElementTransformFlags GetParentMustDirtyFlags(VisualElement ve); // 0x0000000182406DD0-0x0000000182406E00
		private static new void DirtyBoundingBoxHierarchy(VisualElement ve); // 0x0000000182406BF0-0x0000000182406D20
		private static new void DirtyParentHierarchy(VisualElement ve, VisualElementTransformFlags flags); // 0x0000000182406D20-0x0000000182406DD0
		public override void Update(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
