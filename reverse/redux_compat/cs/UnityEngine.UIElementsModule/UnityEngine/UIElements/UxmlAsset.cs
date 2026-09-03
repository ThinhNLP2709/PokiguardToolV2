/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
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
	internal abstract class UxmlAsset // TypeDefIndex: 4904
	{
		// Fields
		[SerializeField]
		private string m_FullTypeName; // 0x10
		[SerializeField]
		private UxmlNamespaceDefinition m_XmlNamespace; // 0x18
		[SerializeField]
		private int m_Id; // 0x28
		[SerializeField]
		private Flags m_Flags; // 0x2C
		[HideInInspector]
		[SerializeReference]
		private UxmlAsset m_Parent; // 0x30
		[SerializeReference]
		private List<UxmlAsset> m_Children; // 0x38
		[SerializeField]
		private VisualTreeAsset m_VisualTreeAsset; // 0x40
		[SerializeField]
		private List<UxmlNamespaceDefinition> m_NamespaceDefinitions; // 0x48
		[SerializeField]
		protected List<UxmlProperty> m_Properties; // 0x50
	
		// Properties
		public string fullTypeName { get; } // 0x0000000180377550-0x0000000180377560 
		public int id { get; internal set; } // 0x0000000180377930-0x0000000180377940 0x00000001823E20A0-0x00000001823E2150
		public bool hasAuthoringId { get; set; } // 0x00000001821D0860-0x00000001821D0870 0x00000001823E2070-0x00000001823E20A0
		public bool isRoot { get; } // 0x00000001823E1F30-0x00000001823E1FF0 
		public UxmlAsset parentAsset { get; } // 0x000000018031E110-0x000000018031E120 
		internal VisualTreeAsset visualTreeAsset { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x0000000180377940-0x0000000180377950 
		public int childCount { get; } // 0x00000001823E1F20-0x00000001823E1F30 
		public UxmlAsset this[int index] { get => default; } // 0x00000001823E1F00-0x00000001823E1F20 
		public List<UxmlNamespaceDefinition> namespaceDefinitions { get; } // 0x00000001823E1FF0-0x00000001823E2070 
	
		// Nested types
		[Flags]
		private enum Flags // TypeDefIndex: 4905
		{
			None = 0,
			HasAuthoringId = 1
		}
	
		// Constructors
		public UxmlAsset(string fullTypeName, UxmlNamespaceDefinition xmlNamespace = default); // 0x0000000180E33FE0-0x0000000180E34030
	
		// Methods
		public UxmlObjectAsset GetField(string fieldName); // 0x00000001823E1030-0x00000001823E1110
		internal void SetVisualTreeAssetWithOutNotify(VisualTreeAsset vta); // 0x0000000180378120-0x0000000180378130
		internal void SetVisualTreeAsset(VisualTreeAsset vta); // 0x00000001823E1BE0-0x00000001823E1D50
		public void Add(UxmlAsset asset); // 0x00000001823E0FA0-0x00000001823E1030
		public void Insert(int index, UxmlAsset asset); // 0x00000001823E1230-0x00000001823E1610
		private void InsertInChildren(int index, UxmlAsset asset); // 0x00000001823E1170-0x00000001823E1230
		private void RemoveFromChildren(UxmlAsset child); // 0x00000001823E1880-0x00000001823E18F0
		private void RemoveFromChildren(int index); // 0x00000001823E18F0-0x00000001823E1910
		private void SetParent(UxmlAsset parent); // 0x00000001823E1B30-0x00000001823E1BE0
		private protected virtual void OnVisualTreeAssetChanged(VisualTreeAsset previousVta, VisualTreeAsset newVta); // 0x00000001823E17D0-0x00000001823E1880
		public int IndexOf(UxmlAsset asset); // 0x00000001823E1110-0x00000001823E1170
		public int SiblingIndex(); // 0x00000001823E1D50-0x00000001823E1DC0
		public bool IsAncestorOf(UxmlAsset other); // 0x00000001823E1610-0x00000001823E17D0
		public bool TryGetAttributeValue(string propertyName, out string value); // 0x00000001823E1E30-0x00000001823E1F00
		public void SetAttribute(string name, string value); // 0x00000001823E1910-0x00000001823E1920
		private void SetOrAddProperty(string propertyName, string propertyValue); // 0x00000001823E1920-0x00000001823E1B30
		internal abstract bool Accepts(UxmlAsset asset, out string errorMessage);
		public override string ToString(); // 0x00000001823E1DC0-0x00000001823E1E30
	}
}
