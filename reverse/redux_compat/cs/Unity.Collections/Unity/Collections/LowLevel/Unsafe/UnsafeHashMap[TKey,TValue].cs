/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[DebuggerTypeProxy(typeof(UnsafeHashMapDebuggerTypeProxy<TKey, TValue>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
	public struct UnsafeHashMap<TKey, TValue> : INativeDisposable, IEnumerable<KVPair<TKey, TValue>> // TypeDefIndex: 11689
		where TKey : struct, IEquatable<TKey>
		where TValue : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal HashMapHelper<TKey> m_Data;
		public const int MaxCapacity = 536870912; // Metadata: 0x006A1D24
	
		// Properties
		public bool IsCreated { [IsReadOnly] get; }
		public bool IsEmpty { [IsReadOnly] get; }
		public int Count { [IsReadOnly] get; }
		public int Capacity { [IsReadOnly] get; set; }
		public TValue this[TKey key] { get => default; set {} }
	
		// Nested types
		public struct Enumerator : IEnumerator<KVPair<TKey, TValue>> // TypeDefIndex: 11690
		{
			// Fields
			internal HashMapHelper<TKey> m_Enumerator;
	
			// Properties
			public KVPair<TKey, TValue> Current { get; }
			object IEnumerator.Current { get; }
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public struct ReadOnly : IEnumerable<KVPair<TKey, TValue>> // TypeDefIndex: 11691
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal HashMapHelper<TKey> m_Data;
	
			// Properties
			public bool IsCreated { [IsReadOnly] get; }
			public bool IsEmpty { [IsReadOnly] get; }
			public int Count { [IsReadOnly] get; }
			public int Capacity { [IsReadOnly] get; }
			public TValue this[TKey key] { [IsReadOnly] get => default; }
	
			// Constructors
			internal ReadOnly(ref HashMapHelper<TKey> data);
	
			// Methods
			[IsReadOnly]
			public bool TryGetValue(TKey key, out ref TValue item);
			[IsReadOnly]
			public bool ContainsKey(TKey key);
			[IsReadOnly]
			public NativeArray<TKey> GetKeyArray(AllocatorManager.AllocatorHandle allocator);
			[IsReadOnly]
			public NativeArray<TValue> GetValueArray(AllocatorManager.AllocatorHandle allocator);
			[IsReadOnly]
			public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorManager.AllocatorHandle allocator);
			[IsReadOnly]
			public Enumerator<TKey, TValue> GetEnumerator();
			IEnumerator<KVPair<TKey, TValue>> IEnumerable<KVPair<TKey, TValue>>.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		// Constructors
		public UnsafeHashMap(int initialCapacity, AllocatorManager.AllocatorHandle allocator);
	
		// Methods
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		public void Clear();
		public bool TryAdd(TKey key, TValue item);
		public void Add(TKey key, TValue item);
		public bool Remove(TKey key);
		public bool TryGetValue(TKey key, out ref TValue item);
		public bool ContainsKey(TKey key);
		public void TrimExcess();
		public NativeArray<TKey> GetKeyArray(AllocatorManager.AllocatorHandle allocator);
		public NativeArray<TValue> GetValueArray(AllocatorManager.AllocatorHandle allocator);
		public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorManager.AllocatorHandle allocator);
		public Enumerator GetEnumerator();
		IEnumerator<KVPair<TKey, TValue>> IEnumerable<KVPair<TKey, TValue>>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public ReadOnly AsReadOnly();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void ThrowKeyNotPresent(TKey key);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void ThrowKeyAlreadyAdded(TKey key);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void ThrowAtMaxCapacity();
	}
}
