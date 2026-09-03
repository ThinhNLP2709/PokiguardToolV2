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
	[DebuggerDisplay("Length = {m_ListData == null ? default : m_ListData->Length}, Capacity = {m_ListData == null ? default : m_ListData->Capacity}")]
	[DebuggerTypeProxy(typeof(NativeListDebugView<T>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
	[NativeContainer]
	public struct NativeList<T> : INativeDisposable, INativeList<T>, IEnumerable<T> // TypeDefIndex: 11572
		where T : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeList<T>* m_ListData;
		public const int MaxCapacity = 2147483647; // Metadata: 0x006A1C32
	
		// Properties
		public T this[int index] { get => default; set {} }
		public int Length { [IsReadOnly] get; set; }
		public int Count { get; set; }
		public int Capacity { [IsReadOnly] get; set; }
		public bool IsEmpty { [IsReadOnly] get; }
		public bool IsCreated { [IsReadOnly] get; }
	
		// Nested types
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		public struct ParallelWriter // TypeDefIndex: 11573
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			public unsafe UnsafeList<T>* ListData;
	
			// Properties
			public unsafe void* Ptr { [IsReadOnly] get; }
	
			// Constructors
			internal unsafe ParallelWriter(UnsafeList<T>* listData);
	
			// Methods
			public void AddNoResize(T value);
			public unsafe void AddRangeNoResize(void* ptr, int count);
			public void AddRangeNoResize(ReadOnlySpan<T> roSpan);
			public void AddRangeNoResize(UnsafeList<T> list);
			public void AddRangeNoResize(NativeList<T> list);
		}
	
		// Constructors
		public unsafe NativeList(AllocatorManager.AllocatorHandle allocator);
		public unsafe NativeList(int initialCapacity, AllocatorManager.AllocatorHandle allocator);
	
		// Methods
		[WriteAccessRequired]
		public unsafe T* GetUnsafePtr();
		[IsReadOnly]
		public unsafe T* GetUnsafeReadOnlyPtr();
		[WriteAccessRequired]
		public static implicit operator Span<T>([IsReadOnly] in NativeList<T> container);
		public static implicit operator ReadOnlySpan<T>([IsReadOnly] in NativeList<T> container);
		[WriteAccessRequired]
		public Span<T> AsSpan();
		[IsReadOnly]
		public ReadOnlySpan<T> AsReadOnlySpan();
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(AllocatorManager.AllocatorHandle) })]
		internal void Initialize<U>(int initialCapacity, ref ref U allocator)
			where U : struct, AllocatorManager.IAllocator;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(AllocatorManager.AllocatorHandle) })]
		internal static NativeList<T> New<U>(int initialCapacity, ref ref U allocator)
			where U : struct, AllocatorManager.IAllocator;
		public ref ref T ElementAt(int index);
		public unsafe UnsafeList<T>* GetUnsafeList();
		public void AddNoResize(T value);
		public unsafe void AddRangeNoResize(void* ptr, int count);
		public void AddRangeNoResize(ReadOnlySpan<T> roSpan);
		public void AddRangeNoResize(NativeList<T> list);
		public void Add([IsReadOnly] in ref T value);
		public void AddRange(NativeArray<T> array);
		public void AddRange(NativeList<T> list);
		public unsafe void AddRange(void* ptr, int count);
		public void AddRange(ReadOnlySpan<T> roSpan);
		public void AddReplicate([IsReadOnly] in ref T value, int count);
		public void InsertRangeWithBeginEnd(int begin, int end);
		public void InsertRange(int index, int count);
		public void RemoveAtSwapBack(int index);
		public void RemoveRangeSwapBack(int index, int count);
		public void RemoveAt(int index);
		public void RemoveRange(int index, int count);
		public void Dispose();
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(AllocatorManager.AllocatorHandle) })]
		internal void Dispose<U>(ref ref U allocator)
			where U : struct, AllocatorManager.IAllocator;
		public JobHandle Dispose(JobHandle inputDeps);
		public void Clear();
		[Obsolete("Implicit cast from `NativeList<T>` to `NativeArray<T>` has been deprecated; Use \'.AsArray()\' method to do explicit cast instead.", false)]
		public static implicit operator NativeArray<T>(NativeList<T> nativeList);
		public NativeArray<T> AsArray();
		public NativeArray<T> AsDeferredJobArray();
		public NativeArray<T> ToArray(AllocatorManager.AllocatorHandle allocator);
		public void CopyFrom([IsReadOnly] in ReadOnlySpan<T> other);
		public NativeArray<T> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		public void Resize(int length, NativeArrayOptions options);
		public void ResizeUninitialized(int length);
		public void SetCapacity(int capacity);
		public void TrimExcess();
		public NativeArray<T> AsReadOnly();
		public NativeArray<T> AsParallelReader();
		public ParallelWriter AsParallelWriter();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckInitialCapacity(int initialCapacity);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckSufficientCapacity(int capacity, int length);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckIndexInRange(int value, int length);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckArgPositive(int value);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckHandleMatches(AllocatorManager.AllocatorHandle handle);
	}
}
