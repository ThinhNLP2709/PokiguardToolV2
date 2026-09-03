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
	[GenerateTestsForBurstCompatibility]
	public struct UnsafeAppendBuffer : INativeDisposable // TypeDefIndex: 11680
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		public unsafe byte* Ptr; // 0x00
		public int Length; // 0x08
		public int Capacity; // 0x0C
		public AllocatorManager.AllocatorHandle Allocator; // 0x10
		public readonly int Alignment; // 0x14
	
		// Properties
		public bool IsEmpty { [IsReadOnly] get; } // 0x0000000180D853E0-0x0000000180D853F0 
		public bool IsCreated { [IsReadOnly] get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
	
		// Nested types
		[GenerateTestsForBurstCompatibility]
		public struct Reader // TypeDefIndex: 11681
		{
			// Fields
			public readonly unsafe byte* Ptr; // 0x00
			public readonly int Size; // 0x08
			public int Offset; // 0x0C
	
			// Properties
			public bool EndOfBuffer { get; } // 0x0000000181CA5810-0x0000000181CA5820 
	
			// Constructors
			public unsafe Reader(ref UnsafeAppendBuffer buffer); // 0x0000000181CA57F0-0x0000000181CA5810
			public unsafe Reader(void* ptr, int length); // 0x0000000181CA57E0-0x0000000181CA57F0
	
			// Methods
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public void ReadNext<T>(out ref T value)
				where T : struct;
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public T ReadNext<T>()
				where T : struct;
			public unsafe void* ReadNext(int structSize); // 0x0000000181CA5670-0x0000000181CA56B0
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public void ReadNext<T>(out NativeArray<T> value, AllocatorManager.AllocatorHandle allocator)
				where T : struct;
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public unsafe void* ReadNextArray<T>(out int length)
				where T : struct;
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private void CheckBounds(int structSize); // 0x0000000181CA5490-0x0000000181CA5550
		}
	
		// Constructors
		public unsafe UnsafeAppendBuffer(int initialCapacity, int alignment, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CAA7F0-0x0000000181CAA820
		public unsafe UnsafeAppendBuffer(void* ptr, int length); // 0x0000000181CAA760-0x0000000181CAA7F0
	
		// Methods
		public void Dispose(); // 0x0000000181CAA480-0x0000000181CAA510
		public JobHandle Dispose(JobHandle inputDeps); // 0x0000000181CAA510-0x0000000181CAA620
		public void Reset(); // 0x0000000180EB47E0-0x0000000180EB47F0
		public void SetCapacity(int capacity); // 0x0000000181CAA690-0x0000000181CAA760
		public void ResizeUninitialized(int length); // 0x0000000181CAA660-0x0000000181CAA690
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public void Add<T>(T value)
			where T : struct;
		public unsafe void Add(void* ptr, int structSize); // 0x0000000181CAA380-0x0000000181CAA3D0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public unsafe void AddArray<T>(void* ptr, int length)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public void Add<T>(NativeArray<T> value)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public T Pop<T>()
			where T : struct;
		public unsafe void Pop(void* ptr, int structSize); // 0x0000000181CAA620-0x0000000181CAA660
		public Reader AsReader(); // 0x0000000180ED38B0-0x0000000180ED38D0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckAlignment(int alignment); // 0x0000000181CAA3D0-0x0000000181CAA480
	}
}
