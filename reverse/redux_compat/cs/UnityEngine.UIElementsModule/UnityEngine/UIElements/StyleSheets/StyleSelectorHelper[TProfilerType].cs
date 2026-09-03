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
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal class StyleSelectorHelper<TProfilerType> // TypeDefIndex: 5250
		where TProfilerType : struct, IStyleProfiler
	{
		// Nested types
		private struct SelectorWorkItem // TypeDefIndex: 5251
		{
			// Fields
			public SelectorAccelerationTableType type;
			public int uniqueStringId;
	
			// Constructors
			public SelectorWorkItem(SelectorAccelerationTableType type, int uniqueStringId);
		}
	
		// Methods
		private static StyleComplexSelector GetComplexSelector([IsReadOnly] in SelectorRangeDescriptor descriptor, [IsReadOnly] in SelectorAccelerationCacheEntry cacheEntry);
		private static bool IsDescriptorCandidate([IsReadOnly] in SelectorRangeDescriptor descriptor, AncestorFilter ancestorFilter);
		private static bool MatchRightToLeftFlat(ref VisualElementSelectorData selectorData, [IsReadOnly] in SelectorAccelerationCacheEntry cacheEntry, ReadOnlySpan<FlattenedSelector> descriptorSelectors, bool applyPseudoMasks);
		private static void TestSelectorListFlat(ReadOnlySpan<SelectorRangeDescriptor> descriptors, [IsReadOnly] in SelectorAccelerationCacheEntry cacheEntry, List<StyleSelectorMatch> matchedSelectors, StyleMatchingContext context, int currentStyleSheetIndexInStack);
		private static void FastLookupFlat(Dictionary<int, DescriptorRange> table, [IsReadOnly] in SelectorAccelerationCacheEntry cacheEntry, List<StyleSelectorMatch> matchedSelectors, StyleMatchingContext context, int uniqueStringId, int currentStyleSheetIndexInStack);
		private static Dictionary<int, DescriptorRange> GetFlatTableByType([IsReadOnly] in SelectorAccelerationCacheEntry cacheEntry, SelectorAccelerationTableType type);
		public static void FindMatches(StyleMatchingContext context, List<StyleSelectorMatch> matchedSelectors, int parentSheetIndex);
	}
}
