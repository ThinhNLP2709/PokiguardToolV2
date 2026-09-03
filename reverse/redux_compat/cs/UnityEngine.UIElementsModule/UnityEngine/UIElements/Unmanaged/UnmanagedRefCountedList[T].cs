/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Unmanaged
{
	[IsReadOnly]
	internal struct UnmanagedRefCountedList<T> // TypeDefIndex: 4995
		where T : struct
	{
		// Fields
		private static readonly MemoryLabel k_MemoryLabel;
		private static readonly int k_SizeOfData;
		private static readonly int k_SizeOfT;
		private readonly unsafe Data* m_Data;
	
		// Properties
		public static UnmanagedRefCountedList<T> Empty { get; }
		public ref T this[int index] { get => default; }
		public int Count { get; }
		public bool IsEmpty { get; }
		internal ref int UnsafeRefCount { get; }
		internal int UnsafeCount { get; }
	
		// Nested types
		private struct Data // TypeDefIndex: 4996
		{
			// Fields
			public int Size;
			public int RefCount;
			public T Items;
		}
	
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 4997
		{
			// Fields
			private readonly unsafe Data_T_<T>* m_Data;
			private int m_Index;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			public unsafe Enumerator(UnmanagedRefCountedList<T> list);
	
			// Methods
			public bool MoveNext();
			public void Reset();
			public void Dispose();
		}
	
		// Constructors
		internal unsafe UnmanagedRefCountedList(int size);
		static UnmanagedRefCountedList();
	
		// Methods
		public ReadOnlySpan<T> ToReadOnlySpan();
		public List<TOther> ToList<TOther>(Func<T, TOther> convert);
		public void CopyTo<TOther>(ref List<TOther> other, Func<T, TOther> convert);
		internal void UnsafeRelease();
		public Enumerator GetEnumerator();
		public static bool operator ==(UnmanagedRefCountedList<T> a, UnmanagedRefCountedList<T> b);
		public static bool operator !=(UnmanagedRefCountedList<T> a, UnmanagedRefCountedList<T> b);
		public bool Equals(UnmanagedRefCountedList<T> other);
		public override bool Equals(object obj);
		public override int GetHashCode();
		public static implicit operator ReadOnlySpan<T>(UnmanagedRefCountedList<T> v);
	}
}
