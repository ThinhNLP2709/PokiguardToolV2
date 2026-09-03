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
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal class StyleProperty // TypeDefIndex: 4797
	{
		// Fields
		[SerializeField]
		private StylePropertyId m_Id; // 0x10
		[SerializeField]
		private string m_CustomName; // 0x18
		[SerializeField]
		private int m_Line; // 0x20
		[SerializeField]
		private StyleValueHandle[] m_Values; // 0x28
		[NonSerialized]
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal bool requireVariableResolve; // 0x30
		[NonSerialized]
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal int customNameId; // 0x34
	
		// Properties
		public StylePropertyId id { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public string name { get; internal set; } // 0x0000000182568720-0x00000001825687F0 0x0000000182567B00-0x0000000182567CB0
		public StyleValueHandle[] values { get; [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] internal set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		internal int handleCount { [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] get; } // 0x0000000182568700-0x0000000182568710 
		internal bool isCustomProperty { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x0000000182568710-0x0000000182568720 
	
		// Constructors
		internal StyleProperty(); // 0x0000000182568670-0x0000000182568700
	
		// Methods
		internal void CacheId(string value); // 0x0000000182567B00-0x0000000182567CB0
		public bool TryGetMaterialDefinition(StyleSheet styleSheet, ref UnmanagedMaterialDefinition value); // 0x0000000182567DE0-0x0000000182568670
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal static FilterFunctionType ToFilterFunctionType(StyleValueFunction function); // 0x0000000182567D50-0x0000000182567DE0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal static float ConvertDimensionToFilterFloat(Dimension dim); // 0x0000000182567CB0-0x0000000182567D50
	}
}
