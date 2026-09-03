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
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public static class UQuery // TypeDefIndex: 4876
	{
		// Nested types
		internal interface IVisualPredicateWrapper // TypeDefIndex: 4877
		{
			// Methods
			bool Predicate(object e);
		}
	
		internal class IsOfType<T> : IVisualPredicateWrapper // TypeDefIndex: 4878
			where T : VisualElement
		{
			// Fields
			public static IsOfType<T> s_Instance;
	
			// Constructors
			public IsOfType();
			static IsOfType();
	
			// Methods
			public bool Predicate(object e);
		}
	
		internal abstract class UQueryMatcher : HierarchyTraversal // TypeDefIndex: 4879
		{
			// Fields
			internal List<RuleMatcher> m_Matchers; // 0x10
	
			// Constructors
			protected UQueryMatcher(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override void Traverse(VisualElement element); // 0x00000001823E0090-0x00000001823E00A0
			protected virtual bool OnRuleMatchedElement(RuleMatcher matcher, VisualElement element); // 0x00000001802E7840-0x00000001802E7850
			public override void TraverseRecursive(VisualElement element, int depth); // 0x00000001823DFF90-0x00000001823E0090
			public virtual void Run(VisualElement root, List<RuleMatcher> matchers); // 0x00000001823DFF40-0x00000001823DFF90
		}
	
		internal abstract class SingleQueryMatcher : UQueryMatcher // TypeDefIndex: 4880
		{
			// Fields
			[CompilerGenerated]
			private VisualElement _match_k__BackingField; // 0x18
	
			// Properties
			public VisualElement match { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
			// Constructors
			protected SingleQueryMatcher(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override void Run(VisualElement root, List<RuleMatcher> matchers); // 0x00000001823CF9B0-0x00000001823CFA30
			public bool IsInUse(); // 0x00000001814B9A50-0x00000001814B9A60
			public abstract SingleQueryMatcher CreateNew();
		}
	
		internal class FirstQueryMatcher : SingleQueryMatcher // TypeDefIndex: 4881
		{
			// Fields
			public static readonly FirstQueryMatcher Instance; // 0x00
	
			// Constructors
			public FirstQueryMatcher(); // 0x00000001802F4070-0x00000001802F4080
			static FirstQueryMatcher(); // 0x00000001823CE360-0x00000001823CE3D0
	
			// Methods
			protected override bool OnRuleMatchedElement(RuleMatcher matcher, VisualElement element); // 0x00000001823CE330-0x00000001823CE360
			public override SingleQueryMatcher CreateNew(); // 0x00000001823CE2E0-0x00000001823CE330
		}
	}
}
