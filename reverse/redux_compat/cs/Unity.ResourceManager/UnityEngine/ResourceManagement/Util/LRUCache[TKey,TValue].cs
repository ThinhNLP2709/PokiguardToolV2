/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	internal struct LRUCache<TKey, TValue> // TypeDefIndex: 13700
		where TKey : IEquatable<TKey>
	{
		// Fields
		public int requestHits;
		public int requestCount;
		private int entryLimit;
		private Dictionary<Key, Entry> cache;
		private LinkedList<Key> lru;
	
		// Nested types
		public struct Key : IEquatable<Key> // TypeDefIndex: 13701
		{
			// Fields
			private static readonly Type s_TypeType;
			public TKey key;
			public Type type;
	
			// Constructors
			public Key(TKey k, Type t);
			static Key();
	
			// Methods
			bool System.IEquatable<UnityEngine.ResourceManagement.Util.LRUCache<TKey,TValue>.Key>.Equals(Key<TKey, TValue> other);
			public override int GetHashCode();
		}
	
		public struct Entry : IEquatable<Entry> // TypeDefIndex: 13702
		{
			// Fields
			public LinkedListNode<Key<TKey, TValue>> lruNode;
			public TValue Value;
	
			// Methods
			public bool Equals(Entry<TKey, TValue> other);
			public override int GetHashCode();
		}
	
		// Constructors
		public LRUCache(int limit);
	
		// Methods
		public bool TryAdd(TKey id, TValue obj);
		public bool TryGet(Type type, TKey id, out ref TValue val);
	}
}
