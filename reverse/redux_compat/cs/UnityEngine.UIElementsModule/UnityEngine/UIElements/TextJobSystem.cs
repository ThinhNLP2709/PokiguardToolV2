/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class TextJobSystem // TypeDefIndex: 4837
	{
		// Fields
		internal UITKTextJobSystem m_UITKTextJobSystem; // 0x10
		private ATGTextJobSystem m_ATGTextJobSystem; // 0x18
	
		// Constructors
		public TextJobSystem(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void GenerateText(MeshGenerationContext mgc, TextElement textElement); // 0x00000001823C6E70-0x00000001823C70E0
		internal void PrepareShapingBeforeLayout(BaseVisualElementPanel panel); // 0x00000001823C70E0-0x00000001823C7170
		internal void SyncAndClearNativeMeasurePointers(); // 0x00000001823C7170-0x00000001823C7190
	}
}
