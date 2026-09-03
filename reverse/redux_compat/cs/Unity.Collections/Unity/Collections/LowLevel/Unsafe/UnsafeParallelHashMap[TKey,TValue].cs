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
	[DebuggerDisplay("Count = {Count()}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(UnsafeParallelHashMapDebuggerTypeProxy<TKey, TValue>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
	public struct UnsafeParallelHashMap<TKey, TValue> : INativeDisposable, IEnumerable<KeyValue<TKey, TValue>> // TypeDefIndex: 11719
		where TKey : struct, IEquatable<TKey>
		where TValue : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeParallelHashMapData* m_Buffer;
		internal AllocatorManager.AllocatorHandle m_AllocatorLabel;
		public const int MaxCapacity = 1073741823; // Metadata: 0x006A1D3F
	
		// Properties
		public bool IsCreated { [IsReadOnly] get; }
		public bool IsEmpty { [IsReadOnly] get; }
		public int Capacity { [IsReadOnly] get; set; }
		public TValue this[TKey key] { get => default; set {} }
	
		// Nested types
		[DebuggerDisplay("Count = {m_HashMapData.Count()}, Capacity = {m_HashMapData.Capacity}, IsCreated = {m_HashMapData.IsCreated}, IsEmpty = {IsEmpty}")]
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public struct ReadOnly : IEnumerable<KeyValue<TKey, TValue>> // TypeDefIndex: 11720
		{
			// Fields
			internal UnsafeParallelHashMap<TKey, TValue> m_HashMapData;
	
			// Properties
			public bool IsCreated { [IsReadOnly] get; }
			public bool IsEmpty { [IsReadOnly] get; }
			public int Capacity { [IsReadOnly] get; }
			public TValue this[TKey key] { [IsReadOnly] get => default; }
	
			// Constructors
			internal ReadOnly(UnsafeParallelHashMap<TKey, TValue> hashMapData);
	
			// Methods
			[IsReadOnly]
			public int Count();
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
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			[IsReadOnly]
			private void ThrowKeyNotPresent(TKey key);
			[IsReadOnly]
			public Enumerator<TKey, TValue> GetEnumerator();
			IEnumerator<KeyValue<TKey, TValue>> IEnumerable<KeyValue<TKey, TValue>>.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public struct ParallelWriter // TypeDefIndex: 11721
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeParallelHashMapData* m_Buffer;
			[NativeSetThreadIndex]
			internal int m_ThreadIndex;
	
			// Properties
			public int ThreadIndex { get; }
			public int Capacity { [IsReadOnly] get; }
	
			// Methods
			public bool TryAdd(TKey key, TValue item);
			public bool TryAdd(TKey key, TValue item, int threadIndexOverride);
			public void Add(TKey key, TValue item);
			public void Add(TKey key, TValue item, int threadIndexOverride);
		}
	
		public struct Enumerator : IEnumerator<KeyValue<TKey, TValue>> // TypeDefIndex: 11722
		{
			// Fields
			internal UnsafeParallelHashMapDataEnumerator m_Enumerator;
	
			// Properties
			public KeyValue<TKey, TValue> Current { get; }
			object IEnumerator.Current { get; }
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		// Constructors
		public unsafe UnsafeParallelHashMap(int capacity, AllocatorManager.AllocatorHandle allocator);
	
		// Methods
		[IsReadOnly]
		public int Count();
		public void Clear();
		public bool TryAdd(TKey key, TValue item);
		public void Add(TKey key, TValue item);
		public bool Remove(TKey key);
		public bool TryGetValue(TKey key, out ref TValue item);
		public bool ContainsKey(TKey key);
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		public NativeArray<TKey> GetKeyArray(AllocatorManager.AllocatorHandle allocator);
		public NativeArray<TValue> GetValueArray(AllocatorManager.AllocatorHandle allocator);
		public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorManager.AllocatorHandle allocator);
		public ParallelWriter AsParallelWriter();
		public ReadOnly AsReadOnly();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void ThrowKeyAlreadyAdded([IsReadOnly] in ref TKey key);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void ThrowAtMaxCapacity();
		public Enumerator GetEnumerator();
		IEnumerator<KeyValue<TKey, TValue>> IEnumerable<KeyValue<TKey, TValue>>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
	}
}
