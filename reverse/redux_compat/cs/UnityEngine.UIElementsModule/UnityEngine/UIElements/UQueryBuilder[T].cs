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
	public struct UQueryBuilder<T> : IEquatable<UnityEngine.UIElements.UQueryBuilder<T>> // TypeDefIndex: 4886
		where T : VisualElement
	{
		// Fields
		private List<StyleSelector> m_StyleSelectors;
		private List<StyleSelectorPart> m_Parts;
		private VisualElement m_Element;
		private List<RuleMatcher> m_Matchers;
		private StyleSelectorRelationship m_Relationship;
		private int pseudoStatesMask;
		private int negatedPseudoStatesMask;
	
		// Properties
		private List<StyleSelector> styleSelectors { get; }
		private List<StyleSelectorPart> parts { get; }
	
		// Constructors
		public UQueryBuilder(VisualElement visualElement);
	
		// Methods
		public UQueryBuilder<T> Class(string classname);
		public UQueryBuilder<T> Name(string id);
		public UIElements.UQueryBuilder<T2> OfType<T2>(string name = null, params string[] classes)
			where T2 : VisualElement;
		internal UQueryBuilder<T> SingleBaseType();
		private void AddClass(string c);
		private void AddClasses(params string[] classes);
		private void AddName(string id);
		private void AddType<T2>()
			where T2 : VisualElement;
		private UIElements.UQueryBuilder<T2> AddRelationship<T2>(StyleSelectorRelationship relationship)
			where T2 : VisualElement;
		private void AddPseudoStatesRuleIfNecessasy();
		private void FinishSelector();
		private bool CurrentSelectorEmpty();
		private void FinishCurrentSelector();
		public UQueryState<T> Build();
		public bool Equals(UQueryBuilder<T> other);
		public override bool Equals(object obj);
		public override int GetHashCode();
	}
}
