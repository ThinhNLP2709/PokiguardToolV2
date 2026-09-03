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
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Concurrent
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(IDictionaryDebugView<K, V>))]
	public class ConcurrentDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue> // TypeDefIndex: 3543
	{
		// Fields
		[NonSerialized]
		private Tables _tables;
		private IEqualityComparer<TKey> _comparer;
		[NonSerialized]
		private readonly bool _growLockArray;
		[NonSerialized]
		private int _budget;
		private KeyValuePair<TKey, TValue>[] _serializationArray;
		private int _serializationConcurrencyLevel;
		private int _serializationCapacity;
		private static readonly bool s_isValueWriteAtomic;
	
		// Properties
		public TValue this[TKey key] { get => default; set {} }
		public int Count { get; }
		public ICollection<TKey> Keys { get; }
		IEnumerable<TKey> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Keys { get; }
		public ICollection<TValue> Values { get; }
		IEnumerable<TValue> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Values { get; }
		bool ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.IsReadOnly { get; }
		bool IDictionary.IsFixedSize { get; }
		bool IDictionary.IsReadOnly { get; }
		ICollection IDictionary.Keys { get; }
		ICollection IDictionary.Values { get; }
		object IDictionary.this[object key] { get => default; set {} }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
		private static int DefaultConcurrencyLevel { get; }
	
		// Nested types
		private sealed class Tables // TypeDefIndex: 3544
		{
			// Fields
			internal readonly Node<TKey, TValue>[] _buckets;
			internal readonly object[] _locks;
			internal int[] _countPerLock;
	
			// Constructors
			internal Tables(Node<TKey, TValue>[] buckets, object[] locks, int[] countPerLock);
		}
	
		[Serializable]
		private sealed class Node // TypeDefIndex: 3545
		{
			// Fields
			internal readonly TKey _key;
			internal TValue _value;
			internal Node<TKey, TValue> _next;
			internal readonly int _hashcode;
	
			// Constructors
			internal Node(TKey key, TValue value, int hashcode, Node<TKey, TValue> next);
		}
	
		[Serializable]
		private sealed class DictionaryEnumerator : IDictionaryEnumerator // TypeDefIndex: 3546
		{
			// Fields
			private IEnumerator<KeyValuePair<TKey, TValue>> _enumerator;
	
			// Properties
			public DictionaryEntry Entry { get; }
			public object Key { get; }
			public object Value { get; }
			public object Current { get; }
	
			// Constructors
			internal DictionaryEnumerator(ConcurrentDictionary<TKey, TValue> dictionary);
	
			// Methods
			public bool MoveNext();
			public void Reset();
		}
	
		[CompilerGenerated]
		private sealed class _GetEnumerator_d__35 : IEnumerator<KeyValuePair<TKey, TValue>> // TypeDefIndex: 3547
		{
			// Fields
			private int __1__state;
			private KeyValuePair<TKey, TValue> __2__current;
			public ConcurrentDictionary<TKey, TValue> __4__this;
			private Node<TKey, TValue>[] _buckets_5__2;
			private int _i_5__3;
			private Node<TKey, TValue> _current_5__4;
	
			// Properties
			KeyValuePair<TKey, TValue> IEnumerator<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _GetEnumerator_d__35(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			[DebuggerHidden]
			void IEnumerator.Reset();
		}
	
		// Constructors
		public ConcurrentDictionary();
		public ConcurrentDictionary(IEqualityComparer<TKey> comparer);
		internal ConcurrentDictionary(int concurrencyLevel, int capacity, bool growLockArray, IEqualityComparer<TKey> comparer);
		static ConcurrentDictionary();
	
		// Methods
		private static bool IsValueWriteAtomic();
		private void InitializeFromCollection(IEnumerable<KeyValuePair<TKey, TValue>> collection);
		public bool TryAdd(TKey key, TValue value);
		public bool ContainsKey(TKey key);
		public bool TryRemove(TKey key, out ref TValue value);
		private bool TryRemoveInternal(TKey key, out ref TValue value, bool matchValue, TValue oldValue);
		public bool TryGetValue(TKey key, out ref TValue value);
		private bool TryGetValueInternal(TKey key, int hashcode, out ref TValue value);
		public void Clear();
		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index);
		public KeyValuePair<TKey, TValue>[] ToArray();
		private void CopyToPairs(KeyValuePair<TKey, TValue>[] array, int index);
		private void CopyToEntries(DictionaryEntry[] array, int index);
		private void CopyToObjects(object[] array, int index);
		[IteratorStateMachine(typeof(_GetEnumerator_d__35))]
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
		private bool TryAddInternal(TKey key, int hashcode, TValue value, bool updateIfExists, bool acquireLock, out ref TValue resultingValue);
		private static void ThrowKeyNotFoundException(object key);
		private static void ThrowKeyNullException();
		private int GetCountInternal();
		public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory);
		public TValue GetOrAdd(TKey key, TValue value);
		void IDictionary<TKey, TValue>.Add(TKey key, TValue value);
		bool IDictionary<TKey, TValue>.Remove(TKey key);
		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair);
		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair);
		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair);
		IEnumerator IEnumerable.GetEnumerator();
		void IDictionary.Add(object key, object value);
		bool IDictionary.Contains(object key);
		IDictionaryEnumerator IDictionary.GetEnumerator();
		void IDictionary.Remove(object key);
		void ICollection.CopyTo(Array array, int index);
		private void GrowTable(Tables tables);
		private static int GetBucket(int hashcode, int bucketCount);
		private static void GetBucketAndLockNo(int hashcode, out int bucketNo, out int lockNo, int bucketCount, int lockCount);
		private void AcquireAllLocks(ref int locksAcquired);
		private void AcquireLocks(int fromInclusive, int toExclusive, ref int locksAcquired);
		private void ReleaseLocks(int fromInclusive, int toExclusive);
		private ReadOnlyCollection<TKey> GetKeys();
		private ReadOnlyCollection<TValue> GetValues();
		[OnSerializing]
		private void OnSerializing(StreamingContext context);
		[OnSerialized]
		private void OnSerialized(StreamingContext context);
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context);
	}
}
