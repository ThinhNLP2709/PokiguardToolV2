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
	[DebuggerTypeProxy(typeof(UnsafePtrListDebugView<T>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
	public struct UnsafePtrList<T> : INativeDisposable, IEnumerable<IntPtr> // TypeDefIndex: 11706
		where T : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		public readonly unsafe T** Ptr;
		public readonly int m_length;
		public readonly int m_capacity;
		public readonly AllocatorManager.AllocatorHandle Allocator;
		private readonly int padding;
	
		// Properties
		public int Length { [IsReadOnly] get; set; }
		public int Capacity { [IsReadOnly] get; set; }
		public unsafe T* this[int index] { get => default; set {} }
		public bool IsEmpty { [IsReadOnly] get; }
		public bool IsCreated { [IsReadOnly] get; }
	
		// Nested types
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public struct ReadOnly // TypeDefIndex: 11707
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			public readonly unsafe T** Ptr;
			public readonly int Length;
	
			// Properties
			public bool IsCreated { [IsReadOnly] get; }
			public bool IsEmpty { [IsReadOnly] get; }
	
			// Constructors
			internal unsafe ReadOnly(T** ptr, int length);
	
			// Methods
			public unsafe int IndexOf(void* ptr);
			public unsafe bool Contains(void* ptr);
		}
	
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public struct ParallelReader // TypeDefIndex: 11708
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			public readonly unsafe T** Ptr;
			public readonly int Length;
	
			// Constructors
			internal unsafe ParallelReader(T** ptr, int length);
	
			// Methods
			public unsafe int IndexOf(void* ptr);
			public unsafe bool Contains(void* ptr);
		}
	
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public struct ParallelWriter // TypeDefIndex: 11709
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			public readonly unsafe T** Ptr;
			[NativeDisableUnsafePtrRestriction]
			public unsafe UnsafeList<IntPtr>* ListData;
	
			// Constructors
			internal unsafe ParallelWriter(T** ptr, UnsafeList<IntPtr>* listData);
	
			// Methods
			public unsafe void AddNoResize(T* value);
			public unsafe void AddRangeNoResize(T** ptr, int count);
			public void AddRangeNoResize(UnsafePtrList<T> list);
		}
	
		// Constructors
		public unsafe UnsafePtrList(T** ptr, int length);
		public unsafe UnsafePtrList(int initialCapacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory /* Metadata: 0x006A1D32 */);
	
		// Methods
		public unsafe ref ref T* ElementAt(int index);
		public static unsafe UnsafePtrList<T>* Create(T** ptr, int length);
		public static unsafe UnsafePtrList<T>* Create(int initialCapacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory /* Metadata: 0x006A1D33 */);
		public static unsafe void Destroy(UnsafePtrList<T>* listData);
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		public void Clear();
		public void Resize(int length, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory /* Metadata: 0x006A1D34 */);
		public void SetCapacity(int capacity);
		public void TrimExcess();
		public unsafe int IndexOf(void* ptr);
		public unsafe bool Contains(void* ptr);
		public unsafe void AddNoResize(void* value);
		public unsafe void AddRangeNoResize(void** ptr, int count);
		public void AddRangeNoResize(UnsafePtrList<T> list);
		public void Add([IsReadOnly] in IntPtr value);
		public unsafe void Add(void* value);
		public unsafe void AddRange(void* ptr, int length);
		public void AddRange(UnsafePtrList<T> list);
		public void InsertRangeWithBeginEnd(int begin, int end);
		public void RemoveAtSwapBack(int index);
		public void RemoveRangeSwapBack(int index, int count);
		public void RemoveAt(int index);
		public void RemoveRange(int index, int count);
		IEnumerator IEnumerable.GetEnumerator();
		IEnumerator<IntPtr> IEnumerable<IntPtr>.GetEnumerator();
		public ReadOnly AsReadOnly();
		public ParallelReader AsParallelReader();
		public ParallelWriter AsParallelWriter();
	}
}
