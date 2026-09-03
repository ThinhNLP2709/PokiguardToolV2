/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI.Collections
{
	internal class IndexedSet<T> : IList<T> // TypeDefIndex: 13144
	{
		// Fields
		private readonly List<T> m_List;
		private Dictionary<T, int> m_Dictionary;
		private int m_EnabledObjectCount;
	
		// Properties
		public int Count { get; }
		public int Capacity { get; }
		public bool IsReadOnly { get; }
		public T this[int index] { get => default; set {} }
	
		// Constructors
		public IndexedSet();
	
		// Methods
		public void Add(T item);
		public void Add(T item, bool isActive);
		public bool AddUnique(T item, bool isActive = true /* Metadata: 0x006A77AE */);
		public bool EnableItem(T item);
		public bool DisableItem(T item);
		public bool Remove(T item);
		public IEnumerator<T> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public void Clear();
		public bool Contains(T item);
		public void CopyTo(T[] array, int arrayIndex);
		public int IndexOf(T item);
		public void Insert(int index, T item);
		public void RemoveAt(int index);
		private void Swap(int index1, int index2);
		public void RemoveAll(Predicate<T> match);
		public void Sort(Comparison<T> sortLayoutFunction);
	}
}
