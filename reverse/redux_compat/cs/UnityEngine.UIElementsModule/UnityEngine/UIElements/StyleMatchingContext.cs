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

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
	internal class StyleMatchingContext // TypeDefIndex: 4976
	{
		// Fields
		private List<StyleSheet> m_StyleSheetStack; // 0x10
		private List<SelectorAccelerationCacheEntry> m_CacheEntryStack; // 0x18
		public StyleVariableContext variableContext; // 0x20
		public VisualElement currentElement; // 0x28
		public readonly bool applyPseudoMasks; // 0x30
		public AncestorFilter ancestorFilter; // 0x38
	
		// Properties
		public int styleSheetCount { get; } // 0x0000000180B5F570-0x0000000180B5F590 
	
		// Constructors
		public StyleMatchingContext(bool applyPseudoMasks); // 0x00000001823F9F30-0x00000001823FA090
	
		// Methods
		public void AddStyleSheet(StyleSheet sheet); // 0x00000001823F9C20-0x00000001823F9E60
		public void RemoveStyleSheetRange(int index, int count); // 0x00000001823F9ED0-0x00000001823F9F30
		public StyleSheet GetStyleSheetAt(int index); // 0x0000000180CAFA00-0x0000000180CAFA20
		public SelectorAccelerationCacheEntry GetCacheEntryAt(int index); // 0x00000001823F9E60-0x00000001823F9ED0
	}
}
