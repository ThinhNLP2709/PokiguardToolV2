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
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(IDictionaryDebugView<K, V>))]
	public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue>, ISerializable, IDeserializationCallback // TypeDefIndex: 3560
	{
		// Fields
		private int[] _buckets;
		private Entry[] _entries;
		private int _count;
		private int _freeList;
		private int _freeCount;
		private int _version;
		private IEqualityComparer<TKey> _comparer;
		private KeyCollection _keys;
		private ValueCollection _values;
		private object _syncRoot;
	
		// Properties
		public int Count { get; }
		public KeyCollection Keys { get; }
		ICollection<TKey> IDictionary<TKey,TValue>.Keys { get; }
		IEnumerable<TKey> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Keys { get; }
		public ValueCollection Values { get; }
		ICollection<TValue> IDictionary<TKey,TValue>.Values { get; }
		IEnumerable<TValue> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Values { get; }
		public TValue this[TKey key] { get => default; set {} }
		bool ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.IsReadOnly { get; }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
		bool IDictionary.IsFixedSize { get; }
		bool IDictionary.IsReadOnly { get; }
		ICollection IDictionary.Keys { get; }
		ICollection IDictionary.Values { get; }
		object IDictionary.this[object key] { get => default; set {} }
	
		// Nested types
		private struct Entry // TypeDefIndex: 3561
		{
			// Fields
			public int hashCode;
			public int next;
			public TKey key;
			public TValue value;
		}
	
		[Serializable]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDictionaryEnumerator // TypeDefIndex: 3562
		{
			// Fields
			private Dictionary<TKey, TValue> _dictionary;
			private int _version;
			private int _index;
			private KeyValuePair<TKey, TValue> _current;
			private int _getEnumeratorRetType;
	
			// Properties
			public KeyValuePair<TKey, TValue> Current { get; }
			object IEnumerator.Current { get; }
			DictionaryEntry IDictionaryEnumerator.Entry { get; }
			object IDictionaryEnumerator.Key { get; }
			object IDictionaryEnumerator.Value { get; }
	
			// Constructors
			internal Enumerator(Dictionary<TKey, TValue> dictionary, int getEnumeratorRetType);
	
			// Methods
			public bool MoveNext();
			public void Dispose();
			void IEnumerator.Reset();
		}
	
		[Serializable]
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(DictionaryKeyCollectionDebugView<TKey, TValue>))]
		public sealed class KeyCollection : ICollection<TKey>, ICollection, IReadOnlyCollection<TKey> // TypeDefIndex: 3563
		{
			// Fields
			private Dictionary<TKey, TValue> _dictionary;
	
			// Properties
			public int Count { get; }
			bool ICollection<TKey>.IsReadOnly { get; }
			bool ICollection.IsSynchronized { get; }
			object ICollection.SyncRoot { get; }
	
			// Nested types
			[Serializable]
			public struct Enumerator : IEnumerator<TKey> // TypeDefIndex: 3564
			{
				// Fields
				private Dictionary<TKey, TValue> _dictionary;
				private int _index;
				private int _version;
				private TKey _currentKey;
	
				// Properties
				public TKey Current { get; }
				object IEnumerator.Current { get; }
	
				// Constructors
				internal Enumerator(Dictionary<TKey, TValue> dictionary);
	
				// Methods
				public void Dispose();
				public bool MoveNext();
				void IEnumerator.Reset();
			}
	
			// Constructors
			public KeyCollection(Dictionary<TKey, TValue> dictionary);
	
			// Methods
			public Enumerator GetEnumerator();
			public void CopyTo(TKey[] array, int index);
			void ICollection<TKey>.Add(TKey item);
			void ICollection<TKey>.Clear();
			bool ICollection<TKey>.Contains(TKey item);
			bool ICollection<TKey>.Remove(TKey item);
			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
			void ICollection.CopyTo(Array array, int index);
		}
	
		[Serializable]
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(DictionaryValueCollectionDebugView<TKey, TValue>))]
		public sealed class ValueCollection : ICollection<TValue>, ICollection, IReadOnlyCollection<TValue> // TypeDefIndex: 3565
		{
			// Fields
			private Dictionary<TKey, TValue> _dictionary;
	
			// Properties
			public int Count { get; }
			bool ICollection<TValue>.IsReadOnly { get; }
			bool ICollection.IsSynchronized { get; }
			object ICollection.SyncRoot { get; }
	
			// Nested types
			[Serializable]
			public struct Enumerator : IEnumerator<TValue> // TypeDefIndex: 3566
			{
				// Fields
				private Dictionary<TKey, TValue> _dictionary;
				private int _index;
				private int _version;
				private TValue _currentValue;
	
				// Properties
				public TValue Current { get; }
				object IEnumerator.Current { get; }
	
				// Constructors
				internal Enumerator(Dictionary<TKey, TValue> dictionary);
	
				// Methods
				public void Dispose();
				public bool MoveNext();
				void IEnumerator.Reset();
			}
	
			// Constructors
			public ValueCollection(Dictionary<TKey, TValue> dictionary);
	
			// Methods
			public Enumerator GetEnumerator();
			public void CopyTo(TValue[] array, int index);
			void ICollection<TValue>.Add(TValue item);
			bool ICollection<TValue>.Remove(TValue item);
			void ICollection<TValue>.Clear();
			bool ICollection<TValue>.Contains(TValue item);
			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
			void ICollection.CopyTo(Array array, int index);
		}
	
		// Constructors
		public Dictionary();
		public Dictionary(int capacity);
		public Dictionary(IEqualityComparer<TKey> comparer);
		public Dictionary(int capacity, IEqualityComparer<TKey> comparer);
		public Dictionary(IDictionary<TKey, TValue> dictionary);
		public Dictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer);
		protected Dictionary(SerializationInfo info, StreamingContext context);
	
		// Methods
		public void Add(TKey key, TValue value);
		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair);
		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair);
		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair);
		public void Clear();
		public bool ContainsKey(TKey key);
		public bool ContainsValue(TValue value);
		private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index);
		public Enumerator GetEnumerator();
		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator();
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		private int FindEntry(TKey key);
		private int Initialize(int capacity);
		private bool TryInsert(TKey key, TValue value, InsertionBehavior behavior);
		public virtual void OnDeserialization(object sender);
		private void Resize();
		private void Resize(int newSize, bool forceNewHashCodes);
		public bool Remove(TKey key);
		public bool Remove(TKey key, out ref TValue value);
		public bool TryGetValue(TKey key, out ref TValue value);
		public bool TryAdd(TKey key, TValue value);
		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index);
		void ICollection.CopyTo(Array array, int index);
		IEnumerator IEnumerable.GetEnumerator();
		public int EnsureCapacity(int capacity);
		private static bool IsCompatibleKey(object key);
		void IDictionary.Add(object key, object value);
		bool IDictionary.Contains(object key);
		IDictionaryEnumerator IDictionary.GetEnumerator();
		void IDictionary.Remove(object key);
	}
}
