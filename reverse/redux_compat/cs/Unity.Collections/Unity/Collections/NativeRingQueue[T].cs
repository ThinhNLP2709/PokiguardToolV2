/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(NativeRingQueueDebugView<T>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
	[NativeContainer]
	public struct NativeRingQueue<T> : INativeDisposable // TypeDefIndex: 11609
		where T : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeRingQueue<T>* m_RingQueue;
		public const int MaxCapacity = 2147483647; // Metadata: 0x006A1C44
	
		// Properties
		public bool IsCreated { [IsReadOnly] get; }
		public bool IsEmpty { [IsReadOnly] get; }
		public int Length { [IsReadOnly] get; }
		public int Capacity { [IsReadOnly] get; }
	
		// Constructors
		public unsafe NativeRingQueue(int capacity, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1C43 */);
	
		// Methods
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		public bool TryEnqueue(T value);
		public void Enqueue(T value);
		public bool TryDequeue(out ref T item);
		public T Dequeue();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckWrite();
	}
}
