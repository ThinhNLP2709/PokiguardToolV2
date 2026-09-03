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
	internal class UxmlObjectAsset : UxmlAsset // TypeDefIndex: 4906
	{
		// Fields
		[SerializeField]
		private bool m_IsField; // 0x58
	
		// Properties
		public bool isField { get; } // 0x0000000181424750-0x0000000181424760 
	
		// Constructors
		public UxmlObjectAsset(string fullTypeNameOrFieldName, bool isField, UxmlNamespaceDefinition xmlNamespace = default); // 0x00000001823E2880-0x00000001823E28F0
	
		// Methods
		internal override bool Accepts(UxmlAsset asset, out string errorMessage); // 0x00000001823E2580-0x00000001823E2740
		public override string ToString(); // 0x00000001823E2740-0x00000001823E2880
	}
}
