/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[DebuggerTypeProxy(typeof(NativeParallelMultiHashMapDebuggerTypeProxy<TKey, TValue>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
	[NativeContainer]
	public struct NativeParallelMultiHashMap<TKey, TValue> : INativeDisposable, IEnumerable<KeyValue<TKey, TValue>> // TypeDefIndex: 11592
		where TKey : struct, IEquatable<TKey>
		where TValue : struct
	{
		// Fields
		internal UnsafeParallelMultiHashMap<TKey, TValue> m_MultiHashMapData;
		public const int MaxCapacity = 1073741823; // Metadata: 0x006A1C3D
	
		// Properties
		public bool IsEmpty { [IsReadOnly] get; }
		public int Capacity { [IsReadOnly] get; set; }
		public bool IsCreated { [IsReadOnly] get; }
	
		// Nested types
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		public struct ParallelWriter // TypeDefIndex: 11593
		{
			// Fields
			internal UnsafeParallelMultiHashMap<TKey, TValue> m_Writer;
	
			// Properties
			public int m_ThreadIndex { get; }
			public int Capacity { [IsReadOnly] get; }
	
			// Methods
			public void Add(TKey key, TValue item);
			public void Add(TKey key, TValue item, int threadIndexOverride);
		}
	
		public struct Enumerator : IEnumerator<TValue> // TypeDefIndex: 11594
		{
			// Fields
			internal NativeParallelMultiHashMap<TKey, TValue> hashmap;
			internal TKey key;
			internal byte isFirst;
			private TValue value;
			private NativeParallelMultiHashMapIterator<TKey> iterator;
	
			// Properties
			public TValue Current { get; }
			object IEnumerator.Current { get; }
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
			public Enumerator<TKey, TValue> GetEnumerator();
		}
	
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct KeyValueEnumerator : IEnumerator<KeyValue<TKey, TValue>> // TypeDefIndex: 11595
		{
			// Fields
			internal UnsafeParallelHashMapDataEnumerator m_Enumerator;
	
			// Properties
			public KeyValue<TKey, TValue> Current { [IsReadOnly] get; }
			object IEnumerator.Current { get; }
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		[DebuggerDisplay("Count = {m_HashMapData.Count()}, Capacity = {m_HashMapData.Capacity}, IsCreated = {m_HashMapData.IsCreated}, IsEmpty = {IsEmpty}")]
		[DebuggerTypeProxy(typeof(NativeParallelHashMapDebuggerTypeProxy<TKey, TValue>))]
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct ReadOnly : IEnumerable<KeyValue<TKey, TValue>> // TypeDefIndex: 11596
		{
			// Fields
			internal UnsafeParallelMultiHashMap<TKey, TValue> m_MultiHashMapData;
	
			// Properties
			public bool IsCreated { [IsReadOnly] get; }
			public bool IsEmpty { [IsReadOnly] get; }
			public int Capacity { [IsReadOnly] get; }
	
			// Constructors
			internal ReadOnly(UnsafeParallelMultiHashMap<TKey, TValue> container);
	
			// Methods
			[IsReadOnly]
			public int Count();
			[IsReadOnly]
			public bool TryGetFirstValue(TKey key, out ref TValue item, out NativeParallelMultiHashMapIterator<TKey> it);
			[IsReadOnly]
			public bool TryGetNextValue(out ref TValue item, ref NativeParallelMultiHashMapIterator<TKey> it);
			[IsReadOnly]
			public bool ContainsKey(TKey key);
			[IsReadOnly]
			public NativeArray<TKey> GetKeyArray(AllocatorManager.AllocatorHandle allocator);
			[IsReadOnly]
			public NativeArray<TValue> GetValueArray(AllocatorManager.AllocatorHandle allocator);
			[IsReadOnly]
			public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorManager.AllocatorHandle allocator);
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[IsReadOnly]
			private void CheckRead();
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			[IsReadOnly]
			private void ThrowKeyNotPresent(TKey key);
			public KeyValueEnumerator<TKey, TValue> GetEnumerator();
			IEnumerator<KeyValue<TKey, TValue>> IEnumerable<KeyValue<TKey, TValue>>.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		// Constructors
		public NativeParallelMultiHashMap(int capacity, AllocatorManager.AllocatorHandle allocator);
	
		// Methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(AllocatorManager.AllocatorHandle) })]
		internal void Initialize<U>(int capacity, ref ref U allocator)
			where U : struct, AllocatorManager.IAllocator;
		[IsReadOnly]
		public int Count();
		public void Clear();
		public void Add(TKey key, TValue item);
		public int Remove(TKey key);
		public void Remove(NativeParallelMultiHashMapIterator<TKey> it);
		public bool TryGetFirstValue(TKey key, out ref TValue item, out NativeParallelMultiHashMapIterator<TKey> it);
		public bool TryGetNextValue(out ref TValue item, ref NativeParallelMultiHashMapIterator<TKey> it);
		public bool ContainsKey(TKey key);
		public int CountValuesForKey(TKey key);
		public bool SetValue(TValue item, NativeParallelMultiHashMapIterator<TKey> it);
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		public NativeArray<TKey> GetKeyArray(AllocatorManager.AllocatorHandle allocator);
		public NativeArray<TValue> GetValueArray(AllocatorManager.AllocatorHandle allocator);
		public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorManager.AllocatorHandle allocator);
		public ParallelWriter AsParallelWriter();
		public Enumerator GetValuesForKey(TKey key);
		public KeyValueEnumerator GetEnumerator();
		IEnumerator<KeyValue<TKey, TValue>> IEnumerable<KeyValue<TKey, TValue>>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public ReadOnly AsReadOnly();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWrite();
	}
}
