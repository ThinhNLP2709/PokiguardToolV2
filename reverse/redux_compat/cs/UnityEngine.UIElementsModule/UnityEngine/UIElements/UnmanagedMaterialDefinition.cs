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
using UnityEngine.UIElements.Unmanaged;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal struct UnmanagedMaterialDefinition : IEquatable<UnmanagedMaterialDefinition> // TypeDefIndex: 4644
	{
		// Fields
		public static readonly UnmanagedMaterialDefinition Empty; // 0x00
		public UnmanagedRefCountedList<UnmanagedMaterialPropertyValue> propertyValues; // 0x00
		public EntityId material; // 0x08
	
		// Methods
		public void CopyFrom(UnmanagedMaterialDefinition other); // 0x0000000182570B60-0x0000000182570BB0
		public void CopyFrom(MaterialDefinition other); // 0x0000000182570BB0-0x0000000182570C40
		public void Dispose(); // 0x0000000182570C40-0x0000000182570C80
		public bool Equals(UnmanagedMaterialDefinition other); // 0x0000000182570C80-0x0000000182570D00
		public override bool Equals(object obj); // 0x0000000182570D00-0x0000000182570DE0
		public override int GetHashCode(); // 0x0000000182570DE0-0x0000000182570E50
		public static bool operator ==(UnmanagedMaterialDefinition left, UnmanagedMaterialDefinition right); // 0x0000000182570E50-0x0000000182570EE0
		public static bool operator !=(UnmanagedMaterialDefinition left, UnmanagedMaterialDefinition right); // 0x0000000182570EE0-0x0000000182570F70
		internal MaterialPropertyBlock BuildPropertyBlock(); // 0x0000000182570840-0x0000000182570B60
	}
}
