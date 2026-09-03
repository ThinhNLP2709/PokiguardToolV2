/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
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
	public struct UQueryState<T> : IEnumerable<T>, IEquatable<UnityEngine.UIElements.UQueryState<T>> // TypeDefIndex: 4882
		where T : VisualElement
	{
		// Fields
		private static ActionQueryMatcher s_Action;
		private readonly VisualElement m_Element;
		internal readonly List<RuleMatcher> m_Matchers;
		private static readonly ListQueryMatcher s_List;
		private static readonly ListQueryMatcher<VisualElement> s_EnumerationList;
	
		// Nested types
		private class ListQueryMatcher<TElement> : UQuery.UQueryMatcher // TypeDefIndex: 4883
			where TElement : VisualElement
		{
			// Fields
			[CompilerGenerated]
			private List<TElement> _matches_k__BackingField;
	
			// Properties
			public List<TElement> matches { [CompilerGenerated] get; [CompilerGenerated] set; }
	
			// Constructors
			public ListQueryMatcher();
	
			// Methods
			protected override bool OnRuleMatchedElement(RuleMatcher matcher, VisualElement element);
			public void Reset();
		}
	
		private class ActionQueryMatcher : UQuery.UQueryMatcher // TypeDefIndex: 4884
		{
			// Fields
			[CompilerGenerated]
			private Action<T> _callBack_k__BackingField;
	
			// Properties
			internal Action<T> callBack { [CompilerGenerated] get; }
	
			// Constructors
			public ActionQueryMatcher();
	
			// Methods
			protected override bool OnRuleMatchedElement(RuleMatcher matcher, VisualElement element);
		}
	
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 4885
		{
			// Fields
			private List<VisualElement> iterationList;
			private int currentIndex;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal Enumerator(UQueryState<T> queryState);
	
			// Methods
			public bool MoveNext();
			public void Reset();
			public void Dispose();
		}
	
		// Constructors
		internal UQueryState(VisualElement element, List<RuleMatcher> matchers);
		static UQueryState();
	
		// Methods
		private T Single(UQuery.SingleQueryMatcher matcher);
		public T First();
		public Enumerator GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public bool Equals(UQueryState<T> other);
		public override bool Equals(object obj);
		public override int GetHashCode();
	}
}
