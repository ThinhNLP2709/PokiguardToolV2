/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	[DebuggerDisplay("Count = {Count}")]
	internal class LowLevelList<T> // TypeDefIndex: 3602
	{
		// Fields
		protected T[] _items;
		protected int _size;
		protected int _version;
		private static readonly T[] s_emptyArray;
	
		// Properties
		public int Capacity { get; set; }
		public int Count { get; }
		public T this[int index] { get => default; set {} }
	
		// Constructors
		public LowLevelList();
		public LowLevelList(int capacity);
		static LowLevelList();
	
		// Methods
		public void Add(T item);
		private void EnsureCapacity(int min);
		public void AddRange(IEnumerable<T> collection);
		public void Clear();
		public bool Contains(T item);
		public void CopyTo(T[] array, int arrayIndex);
		public int IndexOf(T item);
		public void Insert(int index, T item);
		public void InsertRange(int index, IEnumerable<T> collection);
		public bool Remove(T item);
		public int RemoveAll(Predicate<T> match);
		public void RemoveAt(int index);
	}
}
