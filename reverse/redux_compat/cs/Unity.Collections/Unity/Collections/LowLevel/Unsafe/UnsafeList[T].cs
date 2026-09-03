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
	[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(UnsafeListTDebugView<T>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
	public struct UnsafeList<T> : INativeDisposable, INativeList<T>, IEnumerable<T> // TypeDefIndex: 11699
		where T : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		public unsafe T* Ptr;
		public int m_length;
		public int m_capacity;
		public AllocatorManager.AllocatorHandle Allocator;
		private readonly int padding;
		public const int MaxCapacity = 2147483647; // Metadata: 0x006A1D31
	
		// Properties
		public int Length { [IsReadOnly] get; set; }
		public int Capacity { [IsReadOnly] get; set; }
		public T this[int index] { get => default; set {} }
		public bool IsEmpty { [IsReadOnly] get; }
		public bool IsCreated { [IsReadOnly] get; }
	
		// Nested types
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public struct ReadOnly : IEnumerable<T> // TypeDefIndex: 11700
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			public readonly unsafe T* Ptr;
			public readonly int Length;
	
			// Properties
			public bool IsCreated { [IsReadOnly] get; }
			public bool IsEmpty { [IsReadOnly] get; }
	
			// Constructors
			internal unsafe ReadOnly(T* ptr, int length);
	
			// Methods
			[IsReadOnly]
			public unsafe T* GetUnsafeReadOnlyPtr();
			public static implicit operator ReadOnlySpan<T>([IsReadOnly] in ReadOnly<T> container);
			[IsReadOnly]
			public ReadOnlySpan<T> AsReadOnlySpan();
			public Enumerator<T> GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
			IEnumerator<T> IEnumerable<T>.GetEnumerator();
		}
	
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public struct ParallelReader // TypeDefIndex: 11701
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			public readonly unsafe T* Ptr;
			public readonly int Length;
	
			// Constructors
			internal unsafe ParallelReader(T* ptr, int length);
	
			// Methods
			[IsReadOnly]
			public unsafe T* GetUnsafeReadOnlyPtr();
			public static implicit operator ReadOnlySpan<T>([IsReadOnly] in ParallelReader<T> container);
			[IsReadOnly]
			public ReadOnlySpan<T> AsReadOnlySpan();
		}
	
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public struct ParallelWriter // TypeDefIndex: 11702
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			public unsafe UnsafeList<T>* ListData;
	
			// Properties
			public unsafe void* Ptr { [IsReadOnly] get; }
	
			// Constructors
			internal unsafe ParallelWriter(UnsafeList<T>* listData);
	
			// Methods
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public void AddNoResize(T value);
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public unsafe void AddRangeNoResize(void* ptr, int count);
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public void AddRangeNoResize(ReadOnlySpan<T> roSpan);
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public void AddRangeNoResize(UnsafeList<T> list);
		}
	
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 11703
		{
			// Fields
			internal unsafe T* m_Ptr;
			internal int m_Length;
			internal int m_Index;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		// Constructors
		public unsafe UnsafeList(T* ptr, int length);
		public unsafe UnsafeList(int initialCapacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory /* Metadata: 0x006A1D2E */);
	
		// Methods
		public ref ref T ElementAt(int index);
		[WriteAccessRequired]
		public unsafe T* GetUnsafePtr();
		[IsReadOnly]
		public unsafe T* GetUnsafeReadOnlyPtr();
		[WriteAccessRequired]
		public static implicit operator Span<T>([IsReadOnly] in UnsafeList<T> container);
		public static implicit operator ReadOnlySpan<T>([IsReadOnly] in UnsafeList<T> container);
		[WriteAccessRequired]
		public Span<T> AsSpan();
		[IsReadOnly]
		public ReadOnlySpan<T> AsReadOnlySpan();
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(AllocatorManager.AllocatorHandle) })]
		internal static unsafe UnsafeList<T>* Create<U>(int initialCapacity, ref ref U allocator, NativeArrayOptions options)
			where U : struct, AllocatorManager.IAllocator;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(AllocatorManager.AllocatorHandle) })]
		internal static unsafe void Destroy<U>(UnsafeList<T>* listData, ref ref U allocator)
			where U : struct, AllocatorManager.IAllocator;
		public static unsafe UnsafeList<T>* Create(int initialCapacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory /* Metadata: 0x006A1D2F */);
		public static unsafe void Destroy(UnsafeList<T>* listData);
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(AllocatorManager.AllocatorHandle) })]
		internal void Dispose<U>(ref ref U allocator)
			where U : struct, AllocatorManager.IAllocator;
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		public void Clear();
		public void Resize(int length, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory /* Metadata: 0x006A1D30 */);
		private void ResizeExact<U>(ref ref U allocator, int newCapacity)
			where U : struct, AllocatorManager.IAllocator;
		private void ResizeExact(int capacity);
		private void SetCapacity<U>(ref ref U allocator, int capacity)
			where U : struct, AllocatorManager.IAllocator;
		public void SetCapacity(int capacity);
		public void TrimExcess();
		public void AddNoResize(T value);
		public unsafe void AddRangeNoResize(void* ptr, int count);
		public void AddRangeNoResize(ReadOnlySpan<T> roSpan);
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public void AddRangeNoResize(UnsafeList<T> list);
		public void Add([IsReadOnly] in ref T value);
		public unsafe void AddRange(void* ptr, int count);
		public void AddRange(ReadOnlySpan<T> roSpan);
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public void AddRange(UnsafeList<T> container);
		public void AddReplicate([IsReadOnly] in ref T value, int count);
		public void InsertRangeWithBeginEnd(int begin, int end);
		public void InsertRange(int index, int count);
		public void RemoveAtSwapBack(int index);
		public void RemoveRangeSwapBack(int index, int count);
		public void RemoveAt(int index);
		public void RemoveRange(int index, int count);
		public ReadOnly AsReadOnly();
		public ParallelReader AsParallelReader();
		public ParallelWriter AsParallelWriter();
		public void CopyFrom([IsReadOnly] in ReadOnlySpan<T> other);
		public Enumerator GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static unsafe void CheckNull(void* listData);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckIndexCount(int index, int count);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckBeginEndNoLength(int begin, int end);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckBeginEnd(int begin, int end);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckNoResizeHasEnoughCapacity(int length);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckNoResizeHasEnoughCapacity(int length, int index);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckResize(int currentLength, int numElements, int maxCapacity);
	}
}
