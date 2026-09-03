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
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public class VisualElementFocusRing : IFocusRing // TypeDefIndex: 4956
	{
		// Fields
		private readonly VisualElement root; // 0x10
		[CompilerGenerated]
		private DefaultFocusOrder _defaultFocusOrder_k__BackingField; // 0x18
		private List<FocusRingRecord> m_FocusRing; // 0x20
	
		// Properties
		private FocusController focusController { get; } // 0x00000001818C17E0-0x00000001818C1810 
		public DefaultFocusOrder defaultFocusOrder { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
	
		// Nested types
		public enum DefaultFocusOrder // TypeDefIndex: 4957
		{
			ChildOrder = 0,
			PositionXY = 1,
			PositionYX = 2
		}
	
		private class FocusRingRecord // TypeDefIndex: 4958
		{
			// Fields
			public int m_AutoIndex; // 0x10
			public Focusable m_Focusable; // 0x18
			public bool m_IsSlot; // 0x20
			public List<FocusRingRecord> m_ScopeNavigationOrder; // 0x28
	
			// Constructors
			public FocusRingRecord(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public VisualElementFocusRing(VisualElement root, DefaultFocusOrder dfo = DefaultFocusOrder.ChildOrder /* Metadata: 0x00660977 */); // 0x00000001823E5710-0x00000001823E57B0
	
		// Methods
		private int FocusRingAutoIndexSort(FocusRingRecord a, FocusRingRecord b); // 0x00000001823E4430-0x00000001823E4740
		private int FocusRingSort(FocusRingRecord a, FocusRingRecord b); // 0x00000001823E4740-0x00000001823E4870
		private void DoUpdate(); // 0x00000001823E4360-0x00000001823E4430
		private void BuildRingForScopeRecursive(VisualElement ve, ref int scopeIndex, List<FocusRingRecord> scopeList); // 0x00000001823E40B0-0x00000001823E4360
		private void SortAndFlattenScopeLists(List<FocusRingRecord> rootScopeList); // 0x00000001823E5500-0x00000001823E5710
		private int GetFocusableInternalIndex(Focusable f); // 0x00000001823E4C10-0x00000001823E4CA0
		public FocusChangeDirection GetFocusChangeDirection(Focusable currentFocusable, EventBase e); // 0x00000001823E4870-0x00000001823E4C10
		public Focusable GetNextFocusable(Focusable currentFocusable, FocusChangeDirection direction); // 0x00000001823E5250-0x00000001823E53B0
		internal Focusable GetNextFocusableInSequence(Focusable currentFocusable, FocusChangeDirection direction); // 0x00000001823E4D00-0x00000001823E5160
		internal VisualElement GetNextFocusableInTree(VisualElement currentFocusable); // 0x00000001823E5160-0x00000001823E5250
		internal VisualElement GetPreviousFocusableInTree(VisualElement currentFocusable); // 0x00000001823E5460-0x00000001823E5500
		private VisualElement GetNextElementDepthFirst(VisualElement ve); // 0x00000001823E4CA0-0x00000001823E4D00
		private VisualElement GetPreviousElementDepthFirst(VisualElement ve); // 0x00000001823E53B0-0x00000001823E5460
	}
}
