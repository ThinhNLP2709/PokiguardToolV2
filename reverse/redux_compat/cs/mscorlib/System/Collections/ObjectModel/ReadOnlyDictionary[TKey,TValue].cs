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
	[DebuggerTypeProxy(typeof(DictionaryDebugView<K, V>))]
	public class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue> // TypeDefIndex: 3554
	{
		// Fields
		private readonly IDictionary<TKey, TValue> m_dictionary;
		[NonSerialized]
		private object _syncRoot;
		[NonSerialized]
		private KeyCollection _keys;
		[NonSerialized]
		private ValueCollection _values;
	
		// Properties
		public KeyCollection Keys { get; }
		public ValueCollection Values { get; }
		ICollection<TKey> IDictionary<TKey,TValue>.Keys { get; }
		ICollection<TValue> IDictionary<TKey,TValue>.Values { get; }
		public TValue this[TKey key] { get => default; }
		TValue IDictionary<TKey,TValue>.this[TKey key] { get => default; set {} }
		public int Count { get; }
		bool ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.IsReadOnly { get; }
		bool IDictionary.IsFixedSize { get; }
		bool IDictionary.IsReadOnly { get; }
		ICollection IDictionary.Keys { get; }
		ICollection IDictionary.Values { get; }
		object IDictionary.this[object key] { get => default; set {} }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
		IEnumerable<TKey> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Keys { get; }
		IEnumerable<TValue> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Values { get; }
	
		// Nested types
		[Serializable]
		private struct DictionaryEnumerator : IDictionaryEnumerator // TypeDefIndex: 3555
		{
			// Fields
			private readonly IDictionary<TKey, TValue> _dictionary;
			private IEnumerator<KeyValuePair<TKey, TValue>> _enumerator;
	
			// Properties
			public DictionaryEntry Entry { get; }
			public object Key { get; }
			public object Value { get; }
			public object Current { get; }
	
			// Constructors
			public DictionaryEnumerator(IDictionary<TKey, TValue> dictionary);
	
			// Methods
			public bool MoveNext();
			public void Reset();
		}
	
		[Serializable]
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(CollectionDebugView<T>))]
		public sealed class KeyCollection : ICollection<TKey>, ICollection, IReadOnlyCollection<TKey> // TypeDefIndex: 3556
		{
			// Fields
			private readonly ICollection<TKey> _collection;
			[NonSerialized]
			private object _syncRoot;
	
			// Properties
			public int Count { get; }
			bool ICollection<TKey>.IsReadOnly { get; }
			bool ICollection.IsSynchronized { get; }
			object ICollection.SyncRoot { get; }
	
			// Constructors
			internal KeyCollection(ICollection<TKey> collection);
			internal KeyCollection();
	
			// Methods
			void ICollection<TKey>.Add(TKey item);
			void ICollection<TKey>.Clear();
			bool ICollection<TKey>.Contains(TKey item);
			public void CopyTo(TKey[] array, int arrayIndex);
			bool ICollection<TKey>.Remove(TKey item);
			public IEnumerator<TKey> GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
			void ICollection.CopyTo(Array array, int index);
		}
	
		[Serializable]
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(CollectionDebugView<T>))]
		public sealed class ValueCollection : ICollection<TValue>, ICollection, IReadOnlyCollection<TValue> // TypeDefIndex: 3557
		{
			// Fields
			private readonly ICollection<TValue> _collection;
			[NonSerialized]
			private object _syncRoot;
	
			// Properties
			public int Count { get; }
			bool ICollection<TValue>.IsReadOnly { get; }
			bool ICollection.IsSynchronized { get; }
			object ICollection.SyncRoot { get; }
	
			// Constructors
			internal ValueCollection(ICollection<TValue> collection);
			internal ValueCollection();
	
			// Methods
			void ICollection<TValue>.Add(TValue item);
			void ICollection<TValue>.Clear();
			bool ICollection<TValue>.Contains(TValue item);
			public void CopyTo(TValue[] array, int arrayIndex);
			bool ICollection<TValue>.Remove(TValue item);
			public IEnumerator<TValue> GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
			void ICollection.CopyTo(Array array, int index);
		}
	
		// Methods
		public bool ContainsKey(TKey key);
		public bool TryGetValue(TKey key, out ref TValue value);
		void IDictionary<TKey, TValue>.Add(TKey key, TValue value);
		bool IDictionary<TKey, TValue>.Remove(TKey key);
		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item);
		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex);
		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item);
		void ICollection<KeyValuePair<TKey, TValue>>.Clear();
		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item);
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		private static bool IsCompatibleKey(object key);
		void IDictionary.Add(object key, object value);
		void IDictionary.Clear();
		bool IDictionary.Contains(object key);
		IDictionaryEnumerator IDictionary.GetEnumerator();
		void IDictionary.Remove(object key);
		void ICollection.CopyTo(Array array, int index);
	}
}
