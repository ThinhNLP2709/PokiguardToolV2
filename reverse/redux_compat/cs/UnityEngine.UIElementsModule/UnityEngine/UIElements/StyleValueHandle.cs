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
	internal struct StyleValueHandle : IEquatable<StyleValueHandle> // TypeDefIndex: 4809
	{
		// Fields
		[SerializeField]
		private StyleValueType m_ValueType; // 0x00
		[SerializeField]
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal int valueIndex; // 0x04
	
		// Properties
		public StyleValueType valueType { get; [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] internal set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
	
		// Constructors
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal StyleValueHandle(int valueIndex, StyleValueType valueType); // 0x00000001823BA4A0-0x00000001823BA4B0
	
		// Methods
		public bool IsVarFunction(); // 0x00000001823BA490-0x00000001823BA4A0
		public bool Equals(StyleValueHandle other); // 0x000000018219A7A0-0x000000018219A7C0
		public override bool Equals(object obj); // 0x00000001823BA3A0-0x00000001823BA430
		public override int GetHashCode(); // 0x00000001823BA430-0x00000001823BA490
	}
}
