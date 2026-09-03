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
	[DebuggerTypeProxy(typeof(NativeParallelHashSetDebuggerTypeProxy<T>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
	public struct NativeParallelHashSet<T> : INativeDisposable, IEnumerable<T> // TypeDefIndex: 11585
		where T : struct, IEquatable<T>
	{
		// Fields
		internal NativeParallelHashMap<T, bool> m_Data;
		public const int MaxCapacity = 1073741823; // Metadata: 0x006A1C38
	
		// Properties
		public bool IsEmpty { [IsReadOnly] get; }
		public int Capacity { [IsReadOnly] get; set; }
		public bool IsCreated { [IsReadOnly] get; }
	
		// Nested types
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		[NativeContainerIsAtomicWriteOnly]
		public struct ParallelWriter // TypeDefIndex: 11586
		{
			// Fields
			internal NativeParallelHashMap<T, bool> m_Data;
	
			// Properties
			public int Capacity { [IsReadOnly] get; }
	
			// Methods
			public bool Add(T item);
			public bool Add(T item, int threadIndexOverride);
			public bool TryAdd(T item);
			public bool TryAdd(T item, int threadIndexOverride);
		}
	
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 11587
		{
			// Fields
			internal UnsafeParallelHashMapDataEnumerator m_Enumerator;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct ReadOnly : IEnumerable<T> // TypeDefIndex: 11588
		{
			// Fields
			internal UnsafeParallelHashMap<T, bool> m_Data;
	
			// Properties
			public bool IsCreated { [IsReadOnly] get; }
			public bool IsEmpty { [IsReadOnly] get; }
			public int Capacity { [IsReadOnly] get; }
	
			// Constructors
			internal ReadOnly(ref NativeParallelHashSet<T> data);
	
			// Methods
			[IsReadOnly]
			public int Count();
			[IsReadOnly]
			public bool Contains(T item);
			[IsReadOnly]
			public NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator);
			[IsReadOnly]
			public Enumerator<T> GetEnumerator();
			IEnumerator<T> IEnumerable<T>.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[IsReadOnly]
			private void CheckRead();
		}
	
		// Constructors
		public NativeParallelHashSet(int capacity, AllocatorManager.AllocatorHandle allocator);
	
		// Methods
		public int Count();
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		public void Clear();
		public bool Add(T item);
		public bool TryAdd(T item);
		public bool Remove(T item);
		public bool Contains(T item);
		public NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator);
		public ParallelWriter AsParallelWriter();
		public Enumerator GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public ReadOnly AsReadOnly();
	}
}
