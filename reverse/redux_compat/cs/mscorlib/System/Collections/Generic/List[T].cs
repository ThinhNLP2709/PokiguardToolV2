/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ICollectionDebugView<T>))]
	public class List<T> : IList<T>, IList, IReadOnlyList<T> // TypeDefIndex: 3584
	{
		// Fields
		private T[] _items;
		private int _size;
		private int _version;
		[NonSerialized]
		private object _syncRoot;
		private static readonly T[] s_emptyArray;
	
		// Properties
		public int Capacity { get; set; }
		public int Count { get; }
		bool IList.IsFixedSize { get; }
		bool ICollection<T>.IsReadOnly { get; }
		bool IList.IsReadOnly { get; }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
		public T this[int index] { get => default; set {} }
		object IList.this[int index] { get => default; set {} }
	
		// Nested types
		[Serializable]
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 3585
		{
			// Fields
			private List<T> _list;
			private int _index;
			private int _version;
			private T _current;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal Enumerator(List<T> list);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			private bool MoveNextRare();
			void IEnumerator.Reset();
		}
	
		// Constructors
		public List();
		public List(int capacity);
		public List(IEnumerable<T> collection);
		static List();
	
		// Methods
		private static bool IsCompatibleObject(object value);
		public void Add(T item);
		private void AddWithResize(T item);
		int IList.Add(object item);
		public void AddRange(IEnumerable<T> collection);
		public ReadOnlyCollection<T> AsReadOnly();
		public int BinarySearch(int index, int count, T item, IComparer<T> comparer);
		public int BinarySearch(T item);
		public int BinarySearch(T item, IComparer<T> comparer);
		public void Clear();
		public bool Contains(T item);
		bool IList.Contains(object item);
		public void CopyTo(T[] array);
		void ICollection.CopyTo(Array array, int arrayIndex);
		public void CopyTo(T[] array, int arrayIndex);
		private void EnsureCapacity(int min);
		public bool Exists(Predicate<T> match);
		public T Find(Predicate<T> match);
		public List<T> FindAll(Predicate<T> match);
		public int FindIndex(Predicate<T> match);
		public int FindIndex(int startIndex, Predicate<T> match);
		public int FindIndex(int startIndex, int count, Predicate<T> match);
		public Enumerator GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public List<T> GetRange(int index, int count);
		public int IndexOf(T item);
		int IList.IndexOf(object item);
		public void Insert(int index, T item);
		void IList.Insert(int index, object item);
		public void InsertRange(int index, IEnumerable<T> collection);
		public int LastIndexOf(T item);
		public int LastIndexOf(T item, int index, int count);
		public bool Remove(T item);
		void IList.Remove(object item);
		public int RemoveAll(Predicate<T> match);
		public void RemoveAt(int index);
		public void RemoveRange(int index, int count);
		public void Reverse();
		public void Reverse(int index, int count);
		public void Sort();
		public void Sort(IComparer<T> comparer);
		public void Sort(int index, int count, IComparer<T> comparer);
		public void Sort(Comparison<T> comparison);
		public T[] ToArray();
		public void TrimExcess();
		private void AddEnumerable(IEnumerable<T> enumerable);
	}
}
