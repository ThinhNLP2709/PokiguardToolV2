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

namespace System.Collections.ObjectModel
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ICollectionDebugView<T>))]
	public class Collection<T> : IList<T>, IList, IReadOnlyList<T> // TypeDefIndex: 3551
	{
		// Fields
		private IList<T> items;
	
		// Properties
		public int Count { get; }
		protected IList<T> Items { get; }
		public T this[int index] { get => default; set {} }
		bool ICollection<T>.IsReadOnly { get; }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
		object IList.this[int index] { get => default; set {} }
		bool IList.IsReadOnly { get; }
		bool IList.IsFixedSize { get; }
	
		// Constructors
		public Collection();
		public Collection(IList<T> list);
	
		// Methods
		public void Add(T item);
		public void Clear();
		public void CopyTo(T[] array, int index);
		public bool Contains(T item);
		public IEnumerator<T> GetEnumerator();
		public int IndexOf(T item);
		public void Insert(int index, T item);
		public bool Remove(T item);
		public void RemoveAt(int index);
		protected virtual void ClearItems();
		protected virtual void InsertItem(int index, T item);
		protected virtual void RemoveItem(int index);
		protected virtual void SetItem(int index, T item);
		IEnumerator IEnumerable.GetEnumerator();
		void ICollection.CopyTo(Array array, int index);
		int IList.Add(object value);
		bool IList.Contains(object value);
		int IList.IndexOf(object value);
		void IList.Insert(int index, object value);
		void IList.Remove(object value);
		private static bool IsCompatibleObject(object value);
	}
}
