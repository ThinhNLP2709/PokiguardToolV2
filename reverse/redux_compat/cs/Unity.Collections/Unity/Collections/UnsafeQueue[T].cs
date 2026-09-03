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
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
	public struct UnsafeQueue<T> : INativeDisposable // TypeDefIndex: 11658
		where T : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeQueueData* m_Buffer;
		[NativeDisableUnsafePtrRestriction]
		internal AllocatorManager.AllocatorHandle m_AllocatorLabel;
	
		// Properties
		public int Count { [IsReadOnly] get; }
		public bool IsCreated { [IsReadOnly] get; }
	
		// Nested types
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 11659
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeQueueBlockHeader* m_FirstBlock;
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeQueueBlockHeader* m_Block;
			internal int m_ResetIndex;
			internal int m_Index;
			private T value;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		public struct ReadOnly : IEnumerable<T> // TypeDefIndex: 11660
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			private unsafe UnsafeQueueData* m_Buffer;
	
			// Properties
			public bool IsCreated { [IsReadOnly] get; }
			public int Count { [IsReadOnly] get; }
			public T this[int index] { [IsReadOnly] get => default; }
	
			// Constructors
			internal unsafe ReadOnly(ref UnsafeQueue<T> data);
	
			// Methods
			[IsReadOnly]
			public bool IsEmpty();
			[IsReadOnly]
			private bool TryGetValue(int index, out ref T item);
			[IsReadOnly]
			public Enumerator<T> GetEnumerator();
			IEnumerator<T> IEnumerable<T>.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			[IsReadOnly]
			private void ThrowIndexOutOfRangeException(int index);
		}
	
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public struct ParallelWriter // TypeDefIndex: 11661
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeQueueData* m_Buffer;
			internal AllocatorManager.AllocatorHandle m_AllocatorLabel;
			[NativeSetThreadIndex]
			internal int m_ThreadIndex;
	
			// Methods
			public void Enqueue(T value);
			public void Enqueue(T value, int threadIndexOverride);
		}
	
		// Constructors
		public unsafe UnsafeQueue(AllocatorManager.AllocatorHandle allocator);
	
		// Methods
		internal static unsafe UnsafeQueue<T>* Alloc(AllocatorManager.AllocatorHandle allocator);
		internal static unsafe void Free(UnsafeQueue<T>* data);
		[IsReadOnly]
		public bool IsEmpty();
		public T Peek();
		public void Enqueue(T value);
		public T Dequeue();
		public bool TryDequeue(out ref T item);
		public NativeArray<T> ToArray(AllocatorManager.AllocatorHandle allocator);
		public void Clear();
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		public ReadOnly AsReadOnly();
		public ParallelWriter AsParallelWriter();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckNotEmpty();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void ThrowEmpty();
	}
}
