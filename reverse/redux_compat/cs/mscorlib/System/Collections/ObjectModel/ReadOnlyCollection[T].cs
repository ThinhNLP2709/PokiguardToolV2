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
	public class ReadOnlyCollection<T> : IList<T>, IList, IReadOnlyList<T> // TypeDefIndex: 3552
	{
		// Fields
		private IList<T> list;
		[NonSerialized]
		private object _syncRoot;
	
		// Properties
		public int Count { get; }
		public T this[int index] { get => default; }
		bool ICollection<T>.IsReadOnly { get; }
		T IList<T>.this[int index] { get => default; set {} }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
		bool IList.IsFixedSize { get; }
		bool IList.IsReadOnly { get; }
		object IList.this[int index] { get => default; set {} }
	
		// Constructors
		public ReadOnlyCollection(IList<T> list);
	
		// Methods
		public bool Contains(T value);
		public void CopyTo(T[] array, int index);
		public IEnumerator<T> GetEnumerator();
		public int IndexOf(T value);
		void ICollection<T>.Add(T value);
		void ICollection<T>.Clear();
		void IList<T>.Insert(int index, T value);
		bool ICollection<T>.Remove(T value);
		void IList<T>.RemoveAt(int index);
		IEnumerator IEnumerable.GetEnumerator();
		void ICollection.CopyTo(Array array, int index);
		int IList.Add(object value);
		void IList.Clear();
		private static bool IsCompatibleObject(object value);
		bool IList.Contains(object value);
		int IList.IndexOf(object value);
		void IList.Insert(int index, object value);
		void IList.Remove(object value);
		void IList.RemoveAt(int index);
	}
}
