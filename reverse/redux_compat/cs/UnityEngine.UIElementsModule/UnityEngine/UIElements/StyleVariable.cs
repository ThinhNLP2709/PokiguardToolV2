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
	[IsReadOnly]
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal struct StyleVariable // TypeDefIndex: 4813
	{
		// Fields
		public readonly int nameId; // 0x00
		public readonly int hash; // 0x04
		public readonly StyleSheet sheet; // 0x08
		public readonly StyleValueHandle[] handles; // 0x10
	
		// Constructors
		public StyleVariable(int nameId, StyleSheet sheet, StyleValueHandle[] handles); // 0x00000001823BBF20-0x00000001823BBFD0
	
		// Methods
		public override int GetHashCode(); // 0x00000001802E7C60-0x00000001802E7DA0
	}
}
