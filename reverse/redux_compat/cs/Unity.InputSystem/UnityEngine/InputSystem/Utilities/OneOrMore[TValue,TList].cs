/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal struct OneOrMore<TValue, TList> : IReadOnlyList<TValue> // TypeDefIndex: 6628
		where TList : IReadOnlyList<TValue>
	{
		// Fields
		private readonly bool m_IsSingle;
		private readonly TValue m_Single;
		private readonly TList m_Multiple;
	
		// Properties
		public int Count { get; }
		public TValue this[int index] { get => default; }
	
		// Nested types
		private class Enumerator : IEnumerator<TValue> // TypeDefIndex: 6629
		{
			// Fields
			internal int m_Index;
			internal OneOrMore<TValue, TList> m_List;
	
			// Properties
			public TValue Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			public Enumerator();
	
			// Methods
			public bool MoveNext();
			public void Reset();
			public void Dispose();
		}
	
		// Constructors
		public OneOrMore(TValue single);
		public OneOrMore(TList multiple);
	
		// Methods
		public static implicit operator OneOrMore<TValue, TList>(TValue single);
		public static implicit operator OneOrMore<TValue, TList>(TList multiple);
		public IEnumerator<TValue> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
	}
}
