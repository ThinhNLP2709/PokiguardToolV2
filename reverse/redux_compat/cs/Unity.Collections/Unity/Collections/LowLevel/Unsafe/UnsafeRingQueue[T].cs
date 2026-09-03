/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(UnsafeRingQueueDebugView<T>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
	public struct UnsafeRingQueue<T> : INativeDisposable // TypeDefIndex: 11738
		where T : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		public unsafe T* Ptr;
		public AllocatorManager.AllocatorHandle Allocator;
		internal readonly int m_Capacity;
		internal int m_Filled;
		internal int m_Write;
		internal int m_Read;
		public const int MaxCapacity = 2147483647; // Metadata: 0x006A1D4F
	
		// Properties
		public bool IsEmpty { [IsReadOnly] get; }
		public int Length { [IsReadOnly] get; }
		public int Capacity { [IsReadOnly] get; }
		public bool IsCreated { [IsReadOnly] get; }
	
		// Constructors
		public unsafe UnsafeRingQueue(T* ptr, int capacity);
		public unsafe UnsafeRingQueue(int capacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1D4E */);
	
		// Methods
		internal static unsafe UnsafeRingQueue<T>* Alloc(AllocatorManager.AllocatorHandle allocator);
		internal static unsafe void Free(UnsafeRingQueue<T>* data);
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		private bool TryEnqueueInternal(T value);
		public bool TryEnqueue(T value);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void ThrowQueueFull();
		public void Enqueue(T value);
		private bool TryDequeueInternal(out ref T item);
		public bool TryDequeue(out ref T item);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void ThrowQueueEmpty();
		public T Dequeue();
	}
}
