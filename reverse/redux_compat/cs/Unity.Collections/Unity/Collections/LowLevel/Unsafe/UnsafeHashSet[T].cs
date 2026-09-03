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
	[DebuggerTypeProxy(typeof(UnsafeHashSetDebuggerTypeProxy<T>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
	public struct UnsafeHashSet<T> : INativeDisposable, IEnumerable<T> // TypeDefIndex: 11693
		where T : struct, IEquatable<T>
	{
		// Fields
		internal HashMapHelper<T> m_Data;
		public const int MaxCapacity = 536870912; // Metadata: 0x006A1D29
	
		// Properties
		public bool IsEmpty { [IsReadOnly] get; }
		public int Count { [IsReadOnly] get; }
		public int Capacity { [IsReadOnly] get; set; }
		public bool IsCreated { [IsReadOnly] get; }
	
		// Nested types
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 11694
		{
			// Fields
			internal HashMapHelper<T> m_Enumerator;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public struct ReadOnly : IEnumerable<T> // TypeDefIndex: 11695
		{
			// Fields
			internal HashMapHelper<T> m_Data;
	
			// Properties
			public bool IsCreated { [IsReadOnly] get; }
			public bool IsEmpty { [IsReadOnly] get; }
			public int Count { [IsReadOnly] get; }
			public int Capacity { [IsReadOnly] get; }
	
			// Constructors
			internal ReadOnly(ref HashMapHelper<T> data);
	
			// Methods
			[IsReadOnly]
			public bool Contains(T item);
			[IsReadOnly]
			public NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator);
			[IsReadOnly]
			public Enumerator<T> GetEnumerator();
			IEnumerator<T> IEnumerable<T>.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		// Constructors
		public UnsafeHashSet(int initialCapacity, AllocatorManager.AllocatorHandle allocator);
	
		// Methods
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		public void Clear();
		public bool Add(T item);
		public bool TryAdd(T item);
		public bool Remove(T item);
		public bool Contains(T item);
		public void TrimExcess();
		public NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator);
		public Enumerator GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public ReadOnly AsReadOnly();
	}
}
