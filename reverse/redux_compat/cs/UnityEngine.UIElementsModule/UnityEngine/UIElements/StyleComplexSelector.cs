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
	[Serializable]
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal class StyleComplexSelector // TypeDefIndex: 4793
	{
		// Fields
		[NonSerialized]
		public Hashes ancestorHashes; // 0x10
		[SerializeField]
		private Specificity m_Specificity; // 0x20
		[NonSerialized]
		[CompilerGenerated]
		private StyleRule _rule_k__BackingField; // 0x28
		[SerializeField]
		private StyleSelector[] m_Selectors; // 0x30
		[SerializeField]
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal int ruleIndex; // 0x38
		[NonSerialized]
		internal int orderInStyleSheet; // 0x3C
		private static Dictionary<string, PseudoStateData> s_PseudoStates; // 0x00
		private static readonly List<StyleSelectorPart> s_HashList; // 0x08
	
		// Properties
		public Specificity specificity { get; internal set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public StyleRule rule { [VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })] [CompilerGenerated] get; [CompilerGenerated] [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] internal set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public bool isSimple { get; } // 0x00000001825642F0-0x0000000182564310 
		public StyleSelector[] selectors { get; [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] internal set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
	
		// Nested types
		private struct PseudoStateData // TypeDefIndex: 4794
		{
			// Fields
			public readonly PseudoStates state; // 0x00
			public readonly bool negate; // 0x04
	
			// Constructors
			public PseudoStateData(PseudoStates state, bool negate); // 0x0000000180F377D0-0x0000000180F377E0
		}
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 4795
		{
			// Fields
			public static Comparison<StyleSelectorPart> _0___StyleSelectorPartCompare; // 0x00
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4796
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Predicate<StyleSelectorPart> __9__25_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018256F5D0-0x000000018256F640
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _CalculateHashes_b__25_0(StyleSelectorPart p); // 0x000000018256F5B0-0x000000018256F5D0
		}
	
		// Constructors
		internal StyleComplexSelector(); // 0x0000000182564260-0x00000001825642F0
		static StyleComplexSelector(); // 0x00000001825641D0-0x0000000182564260
	
		// Methods
		internal void CachePseudoStateMasks(StyleSheet styleSheet); // 0x00000001825631A0-0x0000000182563960
		public override string ToString(); // 0x0000000182564160-0x00000001825641D0
		private static int StyleSelectorPartCompare(StyleSelectorPart x, StyleSelectorPart y); // 0x0000000182564110-0x0000000182564160
		internal void CalculateHashes(); // 0x0000000182563960-0x0000000182564110
	}
}
