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
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal static class SelectorAccelerationCacheBuilder // TypeDefIndex: 4787
	{
		// Fields
		private static readonly RefComparison<SelectorRangeDescriptor> s_DescriptorRefComparison; // 0x00
	
		// Constructors
		static SelectorAccelerationCacheBuilder(); // 0x0000000182560AB0-0x0000000182560B40
	
		// Methods
		public static void BuildFlattenedCache(ref SelectorAccelerationCacheEntry entry, StyleSheet styleSheet); // 0x000000018255F5B0-0x000000018255FE90
		private static bool CountSelectorsInStyleSheet(StyleSheet styleSheet, ref int totalParts, ref int totalSelectors, ref int totalComplexSelectors); // 0x00000001825602A0-0x00000001825604F0
		private static void FlattenStyleSheet(Span<FlattenedSelectorPart> allParts, Span<FlattenedSelector> allSelectors, Span<SelectorRangeDescriptor> allDescriptors, StyleSheet styleSheet, int importedStyleSheetIndex, ref int partIdx, ref int selectorIdx, ref int descriptorIdx); // 0x0000000182560550-0x0000000182560AB0
		private static FlattenedSelectorPart FlattenPart(StyleSelectorPart part); // 0x00000001825604F0-0x0000000182560550
		private static void BuildRangeTables(ref SelectorAccelerationCacheEntry entry, Span<SelectorRangeDescriptor> allDescriptors); // 0x000000018255FE90-0x0000000182560280
		private static int CompareDescriptors(ref SelectorRangeDescriptor a, ref SelectorRangeDescriptor b); // 0x0000000182560280-0x00000001825602A0
	}
}
