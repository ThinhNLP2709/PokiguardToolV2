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
	internal class VisualElementAsset : UxmlAsset // TypeDefIndex: 4909
	{
		// Fields
		[SerializeField]
		private int m_RuleIndex; // 0x58
		[SerializeField]
		private string[] m_Classes; // 0x60
		[NonSerialized]
		private UniqueStyleString[] m_ClassesUnique; // 0x68
		[SerializeField]
		private List<string> m_StylesheetPaths; // 0x70
		[SerializeField]
		private List<StyleSheet> m_Stylesheets; // 0x78
		[SerializeReference]
		private UxmlSerializedData m_SerializedData; // 0x80
		[SerializeField]
		private bool m_SkipClone; // 0x88
	
		// Properties
		public int ruleIndex { get; set; } // 0x000000018033D260-0x000000018033D270 0x000000018033E870-0x000000018033E880
		public UniqueStyleString[] classesUnique { get; } // 0x00000001823E3820-0x00000001823E3980 
		public List<string> stylesheetPaths { get; } // 0x00000001823E39A0-0x00000001823E3A20 
		public bool hasStylesheetPaths { get; } // 0x00000001823E3980-0x00000001823E3990 
		public List<StyleSheet> stylesheets { get; } // 0x00000001823E3A20-0x00000001823E3AA0 
		public bool hasStylesheets { get; } // 0x00000001823E3990-0x00000001823E39A0 
		public UxmlSerializedData serializedData { get; } // 0x000000018033D4A0-0x000000018033D4B0 
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal bool skipClone { get; } // 0x00000001803B5710-0x00000001803B5720 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4910
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Converter<string, UniqueStyleString> __9__11_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001823D39F0-0x00000001823D3A60
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal UniqueStyleString _get_classesUnique_b__11_0(string s); // 0x00000001823D38B0-0x00000001823D38E0
		}
	
		// Constructors
		public VisualElementAsset(string fullTypeName, UxmlNamespaceDefinition xmlNamespace = default); // 0x00000001823E3750-0x00000001823E3820
	
		// Methods
		private static bool IdsPathMatchesAttributeOverrideIdsPath(List<int> idsPath, List<int> attributeOverrideIdsPath, int templateId); // 0x00000001823E2D50-0x00000001823E2E30
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal virtual VisualElement Instantiate(CreationContext cc, VisualElementAssetReferenceTable.DocumentNode parentAuthoringNode = null); // 0x00000001823E2E30-0x00000001823E3430
		internal override bool Accepts(UxmlAsset asset, out string errorMessage); // 0x00000001823E2B50-0x00000001823E2BC0
		public override string ToString(); // 0x00000001823E35C0-0x00000001823E3750
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void AssignClassListToElement(VisualElement ve); // 0x00000001823E2BC0-0x00000001823E2D50
		private protected override void OnVisualTreeAssetChanged(VisualTreeAsset previousVta, VisualTreeAsset newVta); // 0x00000001823E3430-0x00000001823E35C0
	}
}
