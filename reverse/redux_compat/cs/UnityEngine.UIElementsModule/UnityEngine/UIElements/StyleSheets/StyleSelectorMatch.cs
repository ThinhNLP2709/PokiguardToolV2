/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IL2CPP.CompilerServices;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.StyleSheets
{
	[IsReadOnly]
	internal struct StyleSelectorMatch // TypeDefIndex: 5248
	{
		// Fields
		public readonly StyleSheet sheet; // 0x00
		public readonly int styleSheetIndexInStack; // 0x08
		public readonly int importedStyleSheetIndex; // 0x0C
		public readonly StyleComplexSelector complexSelector; // 0x10
		public static readonly Comparison<StyleSelectorMatch> Comparison; // 0x00
		public static readonly RefComparison<StyleSelectorMatch> RefComparison; // 0x08
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5249
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x000000018246DC90-0x000000018246DD00
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _.cctor_b__9_0(StyleSelectorMatch a, StyleSelectorMatch b); // 0x000000018246DA50-0x000000018246DB00
			internal int _.cctor_b__9_1(ref StyleSelectorMatch a, ref StyleSelectorMatch b); // 0x000000018246DB00-0x000000018246DBB0
		}
	
		// Constructors
		public StyleSelectorMatch(StyleSheet sheet, int styleSheetIndexInStack, int importedStyleSheetIndex, StyleComplexSelector complexSelector); // 0x00000001824678D0-0x0000000182467920
		static StyleSelectorMatch(); // 0x0000000182467780-0x00000001824678D0
	
		// Methods
		[Il2CppSetOption(Option.NullChecks, false)]
		private static int Compare([IsReadOnly] in StyleSelectorMatch a, [IsReadOnly] in StyleSelectorMatch b); // 0x0000000182467720-0x0000000182467780
	}
}
