/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Runtime.CompilerServices
{
	[Serializable]
	public sealed class ReadOnlyCollectionBuilder<T> : IList<T>, IList // TypeDefIndex: 12543
	{
		// Fields
		private T[] _items;
		private int _size;
		private int _version;
	
		// Properties
		public int Capacity { set; }
		public int Count { get; }
		public T this[int index] { get => default; set {} }
		bool ICollection<T>.IsReadOnly { get; }
		bool IList.IsReadOnly { get; }
		bool IList.IsFixedSize { get; }
		object IList.this[int index] { get => default; set {} }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
	
		// Nested types
		[Serializable]
		private class Enumerator : IEnumerator<T> // TypeDefIndex: 12544
		{
			// Fields
			private readonly ReadOnlyCollectionBuilder<T> _builder;
			private readonly int _version;
			private int _index;
			private T _current;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal Enumerator(ReadOnlyCollectionBuilder<T> builder);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			void IEnumerator.Reset();
		}
	
		// Constructors
		public ReadOnlyCollectionBuilder();
		public ReadOnlyCollectionBuilder(int capacity);
	
		// Methods
		public int IndexOf(T item);
		public void Insert(int index, T item);
		public void RemoveAt(int index);
		public void Add(T item);
		public void Clear();
		public bool Contains(T item);
		public void CopyTo(T[] array, int arrayIndex);
		public bool Remove(T item);
		public IEnumerator<T> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		int IList.Add(object value);
		bool IList.Contains(object value);
		int IList.IndexOf(object value);
		void IList.Insert(int index, object value);
		void IList.Remove(object value);
		void ICollection.CopyTo(Array array, int index);
		public T[] ToArray();
		public ReadOnlyCollection<T> ToReadOnlyCollection();
		private void EnsureCapacity(int min);
		private static bool IsCompatibleObject(object value);
		private static void ValidateNullValue(object value, string argument);
	}
}
