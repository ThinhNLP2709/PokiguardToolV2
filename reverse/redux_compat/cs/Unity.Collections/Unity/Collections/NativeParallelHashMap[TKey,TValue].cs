/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[DebuggerDisplay("Count = {m_HashMapData.Count()}, Capacity = {m_HashMapData.Capacity}, IsCreated = {m_HashMapData.IsCreated}, IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(NativeParallelHashMapDebuggerTypeProxy<TKey, TValue>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
	[NativeContainer]
	public struct NativeParallelHashMap<TKey, TValue> : INativeDisposable, IEnumerable<KeyValue<TKey, TValue>> // TypeDefIndex: 11579
		where TKey : struct, IEquatable<TKey>
		where TValue : struct
	{
		// Fields
		internal UnsafeParallelHashMap<TKey, TValue> m_HashMapData;
		public const int MaxCapacity = 1073741823; // Metadata: 0x006A1C33
	
		// Properties
		public bool IsEmpty { [IsReadOnly] get; }
		public int Capacity { [IsReadOnly] get; set; }
		public TValue this[TKey key] { get => default; set {} }
		public bool IsCreated { [IsReadOnly] get; }
	
		// Nested types
		[DebuggerDisplay("Count = {m_HashMapData.Count()}, Capacity = {m_HashMapData.Capacity}, IsCreated = {m_HashMapData.IsCreated}, IsEmpty = {IsEmpty}")]
		[DebuggerTypeProxy(typeof(NativeParallelHashMapDebuggerTypeProxy<TKey, TValue>))]
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct ReadOnly : IEnumerable<KeyValue<TKey, TValue>> // TypeDefIndex: 11580
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
			[IsReadOnly]
			private void CheckRead();
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			[IsReadOnly]
			private void ThrowKeyNotPresent(TKey key);
			[IsReadOnly]
			public Enumerator<TKey, TValue> GetEnumerator();
			IEnumerator<KeyValue<TKey, TValue>> IEnumerable<KeyValue<TKey, TValue>>.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[DebuggerDisplay("Capacity = {m_Writer.Capacity}")]
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		public struct ParallelWriter // TypeDefIndex: 11581
		{
			// Fields
			internal UnsafeParallelHashMap<TKey, TValue> m_Writer;
	
			// Properties
			public int ThreadIndex { get; }
			[Obsolete("\'m_ThreadIndex\' has been deprecated; use \'ThreadIndex\' instead. (UnityUpgradable) -> ThreadIndex")]
			public int m_ThreadIndex { get; }
			public int Capacity { [IsReadOnly] get; }
	
			// Methods
			public bool TryAdd(TKey key, TValue item);
			public bool TryAdd(TKey key, TValue item, int threadIndexOverride);
			public void Add(TKey key, TValue item);
			public void Add(TKey key, TValue item, int threadIndexOverride);
		}
	
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct Enumerator : IEnumerator<KeyValue<TKey, TValue>> // TypeDefIndex: 11582
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
		public NativeParallelHashMap(int capacity, AllocatorManager.AllocatorHandle allocator);
	
		// Methods
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
		public Enumerator GetEnumerator();
		IEnumerator<KeyValue<TKey, TValue>> IEnumerable<KeyValue<TKey, TValue>>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWrite();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void ThrowKeyNotPresent(TKey key);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void ThrowKeyAlreadyAdded(TKey key);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void ThrowAtMaxCapacity();
	}
}
