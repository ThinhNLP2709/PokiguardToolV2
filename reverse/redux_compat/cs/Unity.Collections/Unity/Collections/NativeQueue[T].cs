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
	[NativeContainer]
	public struct NativeQueue<T> : INativeDisposable // TypeDefIndex: 11599
		where T : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		private unsafe UnsafeQueue<T>* m_Queue;
	
		// Properties
		public int Count { [IsReadOnly] get; }
		public bool IsCreated { [IsReadOnly] get; }
	
		// Nested types
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 11600
		{
			// Fields
			internal UnsafeQueue<T> m_Enumerator;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct ReadOnly : IEnumerable<T> // TypeDefIndex: 11601
		{
			// Fields
			private UnsafeQueue<T> m_ReadOnly;
	
			// Properties
			public bool IsCreated { [IsReadOnly] get; }
			public int Count { [IsReadOnly] get; }
			public T this[int index] { [IsReadOnly] get => default; }
	
			// Constructors
			internal ReadOnly(ref NativeQueue<T> data);
	
			// Methods
			[IsReadOnly]
			public bool IsEmpty();
			[IsReadOnly]
			public Enumerator<T> GetEnumerator();
			IEnumerator<T> IEnumerable<T>.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[IsReadOnly]
			private void CheckRead();
		}
	
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		public struct ParallelWriter // TypeDefIndex: 11602
		{
			// Fields
			internal UnsafeQueue<T> unsafeWriter;
	
			// Methods
			public void Enqueue(T value);
			public void Enqueue(T value, int threadIndexOverride);
		}
	
		// Constructors
		public unsafe NativeQueue(AllocatorManager.AllocatorHandle allocator);
	
		// Methods
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
		[IsReadOnly]
		private void CheckRead();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWrite();
	}
}
