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
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal class TemplateAsset : VisualElementAsset // TypeDefIndex: 4893
	{
		// Fields
		public static readonly string UxmlInstanceTypeName; // 0x00
		[SerializeField]
		private string m_TemplateAlias; // 0x90
		[SerializeField]
		private List<VisualTreeAsset.SlotUsageEntry> m_SlotUsages; // 0x98
	
		// Properties
		public string templateAlias { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal List<VisualTreeAsset.SlotUsageEntry> slotUsages { [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
	
		// Nested types
		[Serializable]
		public struct AttributeOverride // TypeDefIndex: 4894
		{
			// Fields
			public string m_ElementName; // 0x00
			public string[] m_NamesPath; // 0x08
			public string m_AttributeName; // 0x10
			public string m_Value; // 0x18
		}
	
		[Serializable]
		public struct UxmlSerializedDataOverride // TypeDefIndex: 4895
		{
			// Fields
			public int m_ElementId; // 0x00
			public List<int> m_ElementIdsPath; // 0x08
			[SerializeReference]
			public UxmlSerializedData m_SerializedData; // 0x10
		}
	
		// Constructors
		static TemplateAsset(); // 0x00000001823CFA30-0x00000001823CFAA0
	}
}
