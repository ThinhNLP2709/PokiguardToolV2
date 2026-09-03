/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	internal class LowLevelDictionary<TKey, TValue> // TypeDefIndex: 3590
	{
		// Fields
		private Entry[] _buckets;
		private int _numEntries;
		private int _version;
		private IEqualityComparer<TKey> _comparer;
	
		// Properties
		public TValue this[TKey key] { set {} }
	
		// Nested types
		private sealed class Entry // TypeDefIndex: 3591
		{
			// Fields
			public TKey _key;
			public TValue _value;
			public Entry<TKey, TValue> _next;
	
			// Constructors
			public Entry();
		}
	
		private sealed class DefaultComparer<T> : IEqualityComparer<T> // TypeDefIndex: 3592
		{
			// Constructors
			public DefaultComparer();
	
			// Methods
			public bool Equals(T x, T y);
			public int GetHashCode(T obj);
		}
	
		// Constructors
		public LowLevelDictionary();
		public LowLevelDictionary(int capacity, IEqualityComparer<TKey> comparer);
	
		// Methods
		public void Clear(int capacity = 17 /* Metadata: 0x0064F08F */);
		public bool Remove(TKey key);
		private Entry Find(TKey key);
		private Entry UncheckedAdd(TKey key, TValue value);
		private void ExpandBuckets();
		private int GetBucket(TKey key, int numBuckets = 0 /* Metadata: 0x0064F090 */);
	}
}
