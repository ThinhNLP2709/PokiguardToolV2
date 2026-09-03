/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[IsReadOnly]
	public struct ArraySegment<T> : IList<T>, IReadOnlyList<T> // TypeDefIndex: 2211
	{
		// Fields
		[CompilerGenerated]
		private static readonly ArraySegment<T> _Empty_k__BackingField;
		private readonly T[] _array;
		private readonly int _offset;
		private readonly int _count;
	
		// Properties
		public static ArraySegment<T> Empty { [CompilerGenerated] get; }
		public T[] Array { get; }
		public int Offset { get; }
		public int Count { get; }
		T IList<T>.this[int index] { get => default; set {} }
		T IReadOnlyList<T>.this[int index] { get => default; }
		bool ICollection<T>.IsReadOnly { get; }
	
		// Nested types
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 2212
		{
			// Fields
			private readonly T[] _array;
			private readonly int _start;
			private readonly int _end;
			private int _current;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal Enumerator(ArraySegment<T> arraySegment);
	
			// Methods
			public bool MoveNext();
			void IEnumerator.Reset();
			public void Dispose();
		}
	
		// Constructors
		public ArraySegment(T[] array);
		public ArraySegment(T[] array, int offset, int count);
		static ArraySegment();
	
		// Methods
		public Enumerator GetEnumerator();
		public override int GetHashCode();
		public void CopyTo(T[] destination, int destinationIndex);
		public override bool Equals(object obj);
		public bool Equals(ArraySegment<T> obj);
		int IList<T>.IndexOf(T item);
		void IList<T>.Insert(int index, T item);
		void IList<T>.RemoveAt(int index);
		void ICollection<T>.Add(T item);
		void ICollection<T>.Clear();
		bool ICollection<T>.Contains(T item);
		bool ICollection<T>.Remove(T item);
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		private void ThrowInvalidOperationIfDefault();
	}
}
