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

namespace UnityEngine.UIElements.StyleSheets
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal static class StyleSheetColor // TypeDefIndex: 5252
	{
		// Fields
		private static Dictionary<string, Color32> s_NameToColor; // 0x00
	
		// Constructors
		static StyleSheetColor(); // 0x0000000182467A50-0x0000000182469710
	
		// Methods
		public static bool TryGetColor(string name, out Color color); // 0x0000000182467940-0x0000000182467A50
		private static Color32 HexToColor32(uint color); // 0x0000000182467920-0x0000000182467940
	}
}
