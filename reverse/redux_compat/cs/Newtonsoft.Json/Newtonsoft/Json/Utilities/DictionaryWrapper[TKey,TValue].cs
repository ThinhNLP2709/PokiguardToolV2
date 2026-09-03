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
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class DictionaryWrapper<TKey, TValue> : IDictionary<TKey, TValue>, IWrappedDictionary // TypeDefIndex: 10112
	{
		// Fields
		[Nullable(2)]
		private readonly IDictionary _dictionary;
		[Nullable(new byte[3] {2, 1, 1 })]
		private readonly IDictionary<TKey, TValue> _genericDictionary;
		[Nullable(new byte[3] {2, 1, 1 })]
		private readonly IReadOnlyDictionary<TKey, TValue> _readOnlyDictionary;
		[Nullable(2)]
		private object _syncRoot;
	
		// Properties
		internal IDictionary<TKey, TValue> GenericDictionary { get; }
		public ICollection<TKey> Keys { get; }
		public ICollection<TValue> Values { get; }
		public TValue this[TKey key] { get => default; set {} }
		public int Count { get; }
		public bool IsReadOnly { get; }
		[Nullable(2)]
		object IDictionary.this[object key] { get => default; set {} }
		bool IDictionary.IsFixedSize { get; }
		ICollection IDictionary.Keys { get; }
		ICollection IDictionary.Values { get; }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
		public object UnderlyingDictionary { get; }
	
		// Nested types
		[IsReadOnly]
		[Nullable(0)]
		private struct DictionaryEnumerator<TEnumeratorKey, TEnumeratorValue> : IDictionaryEnumerator // TypeDefIndex: 10113
		{
			// Fields
			[Nullable(new byte[4] {1, 0, 1, 1 })]
			private readonly IEnumerator<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> _e;
	
			// Properties
			public DictionaryEntry Entry { get; }
			public object Key { get; }
			[Nullable(2)]
			public object Value { [NullableContext(2)] get; }
			public object Current { get; }
	
			// Constructors
			public DictionaryEnumerator([Nullable(new byte[4] {1, 0, 1, 1 })] IEnumerator<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> e);
	
			// Methods
			public bool MoveNext();
			public void Reset();
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10114
		{
			// Fields
			[Nullable(0)]
			public static readonly __c<TKey, TValue> __9;
			[Nullable(0)]
			public static Func<DictionaryEntry, KeyValuePair<TKey, TValue>> __9__29_0;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			[NullableContext(0)]
			internal KeyValuePair<TKey, TValue> _GetEnumerator_b__29_0(DictionaryEntry de);
		}
	
		// Constructors
		public DictionaryWrapper(IDictionary dictionary);
		public DictionaryWrapper(IDictionary<TKey, TValue> dictionary);
		public DictionaryWrapper(IReadOnlyDictionary<TKey, TValue> dictionary);
	
		// Methods
		public void Add(TKey key, TValue value);
		public bool ContainsKey(TKey key);
		public bool Remove(TKey key);
		public bool TryGetValue(TKey key, [Nullable(2)] out ref TValue value);
		public void Add([Nullable(new byte[3] {0, 1, 1 })] KeyValuePair<TKey, TValue> item);
		public void Clear();
		public bool Contains([Nullable(new byte[3] {0, 1, 1 })] KeyValuePair<TKey, TValue> item);
		public void CopyTo([Nullable(new byte[4] {1, 0, 1, 1 })] KeyValuePair<TKey, TValue>[] array, int arrayIndex);
		public bool Remove([Nullable(new byte[3] {0, 1, 1 })] KeyValuePair<TKey, TValue> item);
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		void IDictionary.Add(object key, [Nullable(2)] object value);
		IDictionaryEnumerator IDictionary.GetEnumerator();
		bool IDictionary.Contains(object key);
		public void Remove(object key);
		void ICollection.CopyTo(Array array, int index);
	}
}
