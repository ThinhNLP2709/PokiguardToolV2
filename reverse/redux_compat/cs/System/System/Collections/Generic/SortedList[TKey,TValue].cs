/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Collections.Generic
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(IDictionaryDebugView<K, V>))]
	public class SortedList<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue> // TypeDefIndex: 8976
	{
		// Fields
		private TKey[] keys;
		private TValue[] values;
		private int _size;
		private int version;
		private IComparer<TKey> comparer;
		private KeyList keyList;
		private ValueList valueList;
		[NonSerialized]
		private object _syncRoot;
	
		// Properties
		public int Capacity { set; }
		public int Count { get; }
		public IList<TKey> Keys { get; }
		ICollection<TKey> IDictionary<TKey,TValue>.Keys { get; }
		ICollection IDictionary.Keys { get; }
		IEnumerable<TKey> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Keys { get; }
		public IList<TValue> Values { get; }
		ICollection<TValue> IDictionary<TKey,TValue>.Values { get; }
		ICollection IDictionary.Values { get; }
		IEnumerable<TValue> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Values { get; }
		bool ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.IsReadOnly { get; }
		bool IDictionary.IsReadOnly { get; }
		bool IDictionary.IsFixedSize { get; }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
		public TValue this[TKey key] { get => default; set {} }
		object IDictionary.this[object key] { get => default; set {} }
	
		// Nested types
		[Serializable]
		private struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDictionaryEnumerator // TypeDefIndex: 8977
		{
			// Fields
			private SortedList<TKey, TValue> _sortedList;
			private TKey _key;
			private TValue _value;
			private int _index;
			private int _version;
			private int _getEnumeratorRetType;
	
			// Properties
			object IDictionaryEnumerator.Key { get; }
			DictionaryEntry IDictionaryEnumerator.Entry { get; }
			public KeyValuePair<TKey, TValue> Current { get; }
			object IEnumerator.Current { get; }
			object IDictionaryEnumerator.Value { get; }
	
			// Constructors
			internal Enumerator(SortedList<TKey, TValue> sortedList, int getEnumeratorRetType);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			void IEnumerator.Reset();
		}
	
		[Serializable]
		private sealed class SortedListKeyEnumerator : IEnumerator<TKey> // TypeDefIndex: 8978
		{
			// Fields
			private SortedList<TKey, TValue> _sortedList;
			private int _index;
			private int _version;
			private TKey _currentKey;
	
			// Properties
			public TKey Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal SortedListKeyEnumerator(SortedList<TKey, TValue> sortedList);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			void IEnumerator.Reset();
		}
	
		[Serializable]
		private sealed class SortedListValueEnumerator : IEnumerator<TValue> // TypeDefIndex: 8979
		{
			// Fields
			private SortedList<TKey, TValue> _sortedList;
			private int _index;
			private int _version;
			private TValue _currentValue;
	
			// Properties
			public TValue Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal SortedListValueEnumerator(SortedList<TKey, TValue> sortedList);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			void IEnumerator.Reset();
		}
	
		[Serializable]
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(DictionaryKeyCollectionDebugView<TKey, TValue>))]
		private sealed class KeyList : IList<TKey>, ICollection // TypeDefIndex: 8980
		{
			// Fields
			private SortedList<TKey, TValue> _dict;
	
			// Properties
			public int Count { get; }
			public bool IsReadOnly { get; }
			bool ICollection.IsSynchronized { get; }
			object ICollection.SyncRoot { get; }
			public TKey this[int index] { get => default; set {} }
	
			// Constructors
			internal KeyList(SortedList<TKey, TValue> dictionary);
	
			// Methods
			public void Add(TKey key);
			public void Clear();
			public bool Contains(TKey key);
			public void CopyTo(TKey[] array, int arrayIndex);
			void ICollection.CopyTo(Array array, int arrayIndex);
			public void Insert(int index, TKey value);
			public IEnumerator<TKey> GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
			public int IndexOf(TKey key);
			public bool Remove(TKey key);
			public void RemoveAt(int index);
		}
	
		[Serializable]
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(DictionaryValueCollectionDebugView<TKey, TValue>))]
		private sealed class ValueList : IList<TValue>, ICollection // TypeDefIndex: 8981
		{
			// Fields
			private SortedList<TKey, TValue> _dict;
	
			// Properties
			public int Count { get; }
			public bool IsReadOnly { get; }
			bool ICollection.IsSynchronized { get; }
			object ICollection.SyncRoot { get; }
			public TValue this[int index] { get => default; set {} }
	
			// Constructors
			internal ValueList(SortedList<TKey, TValue> dictionary);
	
			// Methods
			public void Add(TValue key);
			public void Clear();
			public bool Contains(TValue value);
			public void CopyTo(TValue[] array, int arrayIndex);
			void ICollection.CopyTo(Array array, int index);
			public void Insert(int index, TValue value);
			public IEnumerator<TValue> GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
			public int IndexOf(TValue value);
			public bool Remove(TValue value);
			public void RemoveAt(int index);
		}
	
		// Constructors
		public SortedList();
		public SortedList(int capacity);
	
		// Methods
		public void Add(TKey key, TValue value);
		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair);
		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair);
		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair);
		void IDictionary.Add(object key, object value);
		private KeyList GetKeyListHelper();
		private ValueList GetValueListHelper();
		public void Clear();
		bool IDictionary.Contains(object key);
		public bool ContainsKey(TKey key);
		public bool ContainsValue(TValue value);
		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex);
		void ICollection.CopyTo(Array array, int index);
		private void EnsureCapacity(int min);
		private TValue GetByIndex(int index);
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator();
		IDictionaryEnumerator IDictionary.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		private TKey GetKey(int index);
		public int IndexOfKey(TKey key);
		public int IndexOfValue(TValue value);
		private void Insert(int index, TKey key, TValue value);
		public bool TryGetValue(TKey key, out ref TValue value);
		public void RemoveAt(int index);
		public bool Remove(TKey key);
		void IDictionary.Remove(object key);
		private static bool IsCompatibleKey(object key);
	}
}
