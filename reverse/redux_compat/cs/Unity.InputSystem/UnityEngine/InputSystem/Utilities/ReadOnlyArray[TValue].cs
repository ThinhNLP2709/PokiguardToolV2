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
	public struct ReadOnlyArray<TValue> : IReadOnlyList<TValue> // TypeDefIndex: 6632
	{
		// Fields
		internal TValue[] m_Array;
		internal int m_StartIndex;
		internal int m_Length;
	
		// Properties
		public int Count { get; }
		public TValue this[int index] { get => default; }
	
		// Nested types
		public struct Enumerator : IEnumerator<TValue> // TypeDefIndex: 6633
		{
			// Fields
			private readonly TValue[] m_Array;
			private readonly int m_IndexStart;
			private readonly int m_IndexEnd;
			private int m_Index;
	
			// Properties
			public TValue Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal Enumerator(TValue[] array, int index, int length);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		// Constructors
		public ReadOnlyArray(TValue[] array);
		public ReadOnlyArray(TValue[] array, int index, int length);
	
		// Methods
		public TValue[] ToArray();
		public int IndexOf(Predicate<TValue> predicate);
		public Enumerator GetEnumerator();
		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public static implicit operator ReadOnlyArray<TValue>(TValue[] array);
	}
}
