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
	[Serializable]
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal class StyleRule // TypeDefIndex: 4798
	{
		// Fields
		[SerializeField]
		private StyleComplexSelector[] m_ComplexSelectors; // 0x10
		[SerializeField]
		private StyleProperty[] m_Properties; // 0x18
		[SerializeField]
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal int line; // 0x20
		[NonSerialized]
		[CompilerGenerated]
		private StyleSheet _styleSheet_k__BackingField; // 0x28
		[NonSerialized]
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal int customPropertiesCount; // 0x30
	
		// Properties
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal StyleSheet styleSheet { [VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public StyleComplexSelector[] complexSelectors { get; } // 0x0000000180377550-0x0000000180377560 
		public StyleProperty[] properties { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		internal StyleRule(StyleSheet styleSheet); // 0x0000000182569530-0x0000000182569630
	
		// Methods
		public bool TryAddSelector(string selectorStr, out StyleComplexSelector selector, out string error); // 0x00000001825693A0-0x0000000182569530
		public StyleComplexSelector AddSelector(string selectorStr); // 0x00000001825691C0-0x00000001825693A0
		public StyleProperty AddProperty(string propertyName); // 0x0000000182568F40-0x00000001825691C0
		private void AddPropertyToArray(StyleProperty property); // 0x0000000182568EC0-0x0000000182568F40
	}
}
