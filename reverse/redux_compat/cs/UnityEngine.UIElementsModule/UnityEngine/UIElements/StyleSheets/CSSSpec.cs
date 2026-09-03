/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.StyleSheets
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
	internal static class CSSSpec // TypeDefIndex: 5227
	{
		// Fields
		private static readonly Regex rgx; // 0x00
	
		// Constructors
		static CSSSpec(); // 0x000000018244E830-0x000000018244E8C0
	
		// Methods
		public static int GetSelectorSpecificity(string selector); // 0x000000018244DF90-0x000000018244E130
		public static Specificity GetSelectorSpecificity(StyleSelectorPart[] parts); // 0x000000018244E130-0x000000018244E270
		public static bool ParseSelector(string selector, out StyleSelectorPart[] parts); // 0x000000018244E270-0x000000018244E830
	}
}
