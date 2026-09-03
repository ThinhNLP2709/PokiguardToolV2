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

namespace System.Runtime.CompilerServices
{
	public sealed class ConditionalWeakTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> // TypeDefIndex: 3246
		where TKey : class
		where TValue : class
	{
		// Fields
		private Ephemeron[] data;
		private object _lock;
		private int size;
	
		// Nested types
		public delegate TValue CreateValueCallback(TKey key); // TypeDefIndex: 3247; 0x00000000-0x00000000
	
		private sealed class Enumerator : IEnumerator<KeyValuePair<TKey, TValue>> // TypeDefIndex: 3248
		{
			// Fields
			private ConditionalWeakTable<TKey, TValue> _table;
			private int _currentIndex;
			private KeyValuePair<TKey, TValue> _current;
	
			// Properties
			public KeyValuePair<TKey, TValue> Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			public Enumerator(ConditionalWeakTable<TKey, TValue> table);
	
			// Methods
			~Enumerator();
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		// Constructors
		public ConditionalWeakTable();
	
		// Methods
		~ConditionalWeakTable();
		private void RehashWithoutResize();
		private void RecomputeSize();
		private void Rehash();
		public void Add(TKey key, TValue value);
		public bool Remove(TKey key);
		public bool TryGetValue(TKey key, out ref TValue value);
		public TValue GetValue(TKey key, CreateValueCallback createValueCallback);
		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
	}
}
