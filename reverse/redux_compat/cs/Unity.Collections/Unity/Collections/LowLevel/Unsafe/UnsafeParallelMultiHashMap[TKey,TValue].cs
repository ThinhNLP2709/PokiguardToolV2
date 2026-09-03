/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[DebuggerTypeProxy(typeof(UnsafeParallelMultiHashMapDebuggerTypeProxy<TKey, TValue>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
	public struct UnsafeParallelMultiHashMap<TKey, TValue> : INativeDisposable, IEnumerable<KeyValue<TKey, TValue>> // TypeDefIndex: 11732
		where TKey : struct, IEquatable<TKey>
		where TValue : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeParallelHashMapData* m_Buffer;
		internal AllocatorManager.AllocatorHandle m_AllocatorLabel;
		public const int MaxCapacity = 1073741823; // Metadata: 0x006A1D49
	
		// Properties
		public bool IsEmpty { [IsReadOnly] get; }
		public int Capacity { [IsReadOnly] get; set; }
		public bool IsCreated { [IsReadOnly] get; }
	
		// Nested types
		public struct Enumerator : IEnumerator<TValue> // TypeDefIndex: 11733
		{
			// Fields
			internal UnsafeParallelMultiHashMap<TKey, TValue> hashmap;
			internal TKey key;
			internal bool isFirst;
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
	
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public struct ParallelWriter // TypeDefIndex: 11734
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeParallelHashMapData* m_Buffer;
			[NativeSetThreadIndex]
			internal int m_ThreadIndex;
	
			// Properties
			public int Capacity { [IsReadOnly] get; }
	
			// Methods
			public void Add(TKey key, TValue item);
			public void Add(TKey key, TValue item, int threadIndexOverride);
		}
	
		public struct KeyValueEnumerator : IEnumerator<KeyValue<TKey, TValue>> // TypeDefIndex: 11735
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
	
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public struct ReadOnly : IEnumerable<KeyValue<TKey, TValue>> // TypeDefIndex: 11736
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
			public KeyValueEnumerator<TKey, TValue> GetEnumerator();
			IEnumerator<KeyValue<TKey, TValue>> IEnumerable<KeyValue<TKey, TValue>>.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		// Constructors
		public unsafe UnsafeParallelMultiHashMap(int capacity, AllocatorManager.AllocatorHandle allocator);
	
		// Methods
		[IsReadOnly]
		public int Count();
		public void Clear();
		public void Add(TKey key, TValue item);
		public int Remove(TKey key);
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public void Remove<TValueEQ>(TKey key, TValueEQ value)
			where TValueEQ : struct, IEquatable<TValueEQ>;
		public void Remove(NativeParallelMultiHashMapIterator<TKey> it);
		[IsReadOnly]
		public bool TryGetFirstValue(TKey key, out ref TValue item, out NativeParallelMultiHashMapIterator<TKey> it);
		[IsReadOnly]
		public bool TryGetNextValue(out ref TValue item, ref NativeParallelMultiHashMapIterator<TKey> it);
		[IsReadOnly]
		public bool ContainsKey(TKey key);
		[IsReadOnly]
		public int CountValuesForKey(TKey key);
		public bool SetValue(TValue item, NativeParallelMultiHashMapIterator<TKey> it);
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		[IsReadOnly]
		public NativeArray<TKey> GetKeyArray(AllocatorManager.AllocatorHandle allocator);
		[IsReadOnly]
		public NativeArray<TValue> GetValueArray(AllocatorManager.AllocatorHandle allocator);
		[IsReadOnly]
		public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorManager.AllocatorHandle allocator);
		public Enumerator GetValuesForKey(TKey key);
		public ParallelWriter AsParallelWriter();
		public KeyValueEnumerator GetEnumerator();
		IEnumerator<KeyValue<TKey, TValue>> IEnumerable<KeyValue<TKey, TValue>>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public ReadOnly AsReadOnly();
	}
}
