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
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
	internal class VisualTreeStyleUpdaterTraversal<TStyleProfiler> : HierarchyTraversal // TypeDefIndex: 4978
		where TStyleProfiler : struct, IStyleProfiler
	{
		// Fields
		private StyleVariableContext m_ProcessVarContext;
		private List<StyleSelectorMatch> m_TempMatchResults;
		private List<VisualElement> m_CustomStyleResolvedElements;
		[CompilerGenerated]
		private float _currentPixelsPerPoint_k__BackingField;
		private bool m_IsApplyingStyles;
		private List<VisualElement> m_ApplyStyleUpdateList;
		private StyleMatchingContext m_StyleMatchingContext;
		private StylePropertyReader m_StylePropertyReader;
		[CompilerGenerated]
		private BaseVisualElementPanel _currentPanel_k__BackingField;
		private readonly List<StylePropertyId> m_AnimatedProperties;
	
		// Properties
		private float currentPixelsPerPoint { [CompilerGenerated] get; [CompilerGenerated] set; }
		private BaseVisualElementPanel currentPanel { [CompilerGenerated] get; [CompilerGenerated] set; }
	
		// Constructors
		public VisualTreeStyleUpdaterTraversal();
	
		// Methods
		public void PrepareTraversal(BaseVisualElementPanel panel, float pixelsPerPoint);
		public override void Traverse(VisualElement element);
		public void AddChangedElement(VisualElement ve);
		public void ProcessQueuedElements();
		public void Clear();
		private void PropagateToParents(VisualElement ve);
		public override void TraverseRecursive(VisualElement element, int depth);
		private void ProcessTransitions(ComputedTransitionProperty[] computedTransitions, VisualElement element, ref ComputedStyle oldStyle, ref ComputedStyle newStyle);
		private void ForceUpdateTransitions(VisualElement element);
		internal void CancelAnimationsWithNoTransitionProperty(ComputedTransitionProperty[] computedTransitions, VisualElement element, ref ComputedStyle newStyle);
		private ComputedStyle ProcessMatchedRules(VisualElement element, List<StyleSelectorMatch> matchingSelectors);
		private void ProcessMatchedVariables(StyleSheet sheet, StyleRule rule);
	}
}
