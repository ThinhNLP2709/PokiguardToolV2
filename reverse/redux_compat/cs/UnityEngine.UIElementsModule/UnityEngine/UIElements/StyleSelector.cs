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
	internal class StyleSelector // TypeDefIndex: 4799
	{
		// Fields
		[SerializeField]
		private StyleSelectorPart[] m_Parts; // 0x10
		[SerializeField]
		private StyleSelectorRelationship m_PreviousRelationship; // 0x18
		internal int pseudoStateMask; // 0x1C
		internal int negatedPseudoStateMask; // 0x20
	
		// Properties
		public StyleSelectorPart[] parts { get; [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] internal set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public StyleSelectorRelationship previousRelationship { get; [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] internal set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
	
		// Constructors
		public StyleSelector(); // 0x0000000182569C10-0x0000000182569C20
	
		// Methods
		public override string ToString(); // 0x0000000182569BC0-0x0000000182569C10
	}
}
