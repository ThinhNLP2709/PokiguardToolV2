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
	[Serializable]
	public struct MaterialDefinition : IEquatable<MaterialDefinition> // TypeDefIndex: 4640
	{
		// Fields
		[SerializeField]
		private Material m_Material; // 0x00
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal List<MaterialPropertyValue> propertyValues; // 0x08
	
		// Properties
		public Material material { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<MaterialDefinition> // TypeDefIndex: 4641
		{
			// Nested types
			private class MaterialProperty : Property<MaterialDefinition, Material> // TypeDefIndex: 4642
			{
				// Fields
				[CompilerGenerated]
				private readonly string _Name_k__BackingField; // 0x18
				[CompilerGenerated]
				private readonly bool _IsReadOnly_k__BackingField; // 0x20
	
				// Properties
				public override string Name { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
				public override bool IsReadOnly { [CompilerGenerated] get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
	
				// Constructors
				public MaterialProperty(); // 0x000000018255DE00-0x000000018255DE50
	
				// Methods
				public override Material GetValue(ref MaterialDefinition container); // 0x0000000180691EA0-0x0000000180691EB0
				public override void SetValue(ref MaterialDefinition container, Material value); // 0x000000018255DDF0-0x000000018255DE00
			}
	
			// Constructors
			public PropertyBag(); // 0x000000018255E250-0x000000018255E340
		}
	
		// Constructors
		public MaterialDefinition(Material m); // 0x0000000182545280-0x00000001825452C0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal MaterialDefinition(Material m, List<MaterialPropertyValue> propertyValues); // 0x0000000182545170-0x00000001825451D0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal MaterialDefinition(MaterialDefinition other); // 0x00000001825451D0-0x0000000182545280
	
		// Methods
		public static MaterialDefinition FromMaterial(Material m); // 0x0000000182526B10-0x0000000182526B40
		public static bool operator ==(MaterialDefinition lhs, MaterialDefinition rhs); // 0x00000001825452C0-0x0000000182545480
		public static bool operator !=(MaterialDefinition lhs, MaterialDefinition rhs); // 0x00000001825454C0-0x00000001825454F0
		public static implicit operator MaterialDefinition(Material m); // 0x0000000182545480-0x00000001825454C0
		public bool Equals(MaterialDefinition other); // 0x00000001825449B0-0x00000001825449E0
		public override bool Equals(object obj); // 0x00000001825449E0-0x0000000182544A80
		public override int GetHashCode(); // 0x0000000182544E50-0x0000000182544FD0
		public override string ToString(); // 0x0000000182544FD0-0x0000000182545170
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static MaterialDefinition From(UnmanagedMaterialDefinition unmanagedMaterialDefinition); // 0x0000000182544A80-0x0000000182544E50
	}
}
