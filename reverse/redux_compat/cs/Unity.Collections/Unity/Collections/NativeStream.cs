/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	[NativeContainer]
	public struct NativeStream : INativeDisposable // TypeDefIndex: 11622
	{
		// Fields
		private UnsafeStream m_Stream; // 0x00
	
		// Properties
		public bool IsCreated { [IsReadOnly] get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
		public int ForEachCount { [IsReadOnly] get; } // 0x0000000181CA36B0-0x0000000181CA36E0 
	
		// Nested types
		[BurstCompile]
		internal struct ConstructJobList : IJob // TypeDefIndex: 11623
		{
			// Fields
			public NativeStream Container; // 0x00
			[NativeDisableUnsafePtrRestriction]
			[ReadOnly]
			public unsafe UntypedUnsafeList* List; // 0x20
	
			// Methods
			public void Execute(); // 0x0000000181CA11E0-0x0000000181CA1210
		}
	
		[BurstCompile]
		internal struct ConstructJobArray : IJob // TypeDefIndex: 11624
		{
			// Fields
			public NativeStream Container; // 0x00
			[ReadOnly]
			public NativeArray<int> ForEachCountArray; // 0x20
	
			// Methods
			public void Execute(); // 0x0000000181CA11C0-0x0000000181CA11E0
		}
	
		[BurstCompile]
		internal struct ConstructJob : IJob // TypeDefIndex: 11625
		{
			// Fields
			public NativeStream Container; // 0x00
			public NativeReference<int> ForEachCount; // 0x20
	
			// Methods
			public void Execute(); // 0x0000000181CA1240-0x0000000181CA1280
		}
	
		[GenerateTestsForBurstCompatibility]
		[NativeContainer]
		[NativeContainerSupportsMinMaxWriteRestriction]
		public struct Writer // TypeDefIndex: 11626
		{
			// Fields
			private UnsafeStream.Writer m_Writer; // 0x00
	
			// Properties
			public int ForEachCount { get; } // 0x0000000181CA36B0-0x0000000181CA36E0 
	
			// Constructors
			internal Writer(ref NativeStream stream); // 0x0000000181CAD510-0x0000000181CAD590
	
			// Methods
			public void PatchMinMaxRange(int foreEachIndex); // 0x00000001802E76C0-0x00000001802E76D0
			public void BeginForEachIndex(int foreachIndex); // 0x0000000181CAD3F0-0x0000000181CAD410
			public void EndForEachIndex(); // 0x0000000181CAD410-0x0000000181CAD4E0
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public void Write<T>(T value)
				where T : struct;
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public ref ref T Allocate<T>()
				where T : struct;
			public unsafe byte* Allocate(int size); // 0x0000000181CAD2D0-0x0000000181CAD3F0
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private void CheckBeginForEachIndex(int foreachIndex); // 0x00000001802E76C0-0x00000001802E76D0
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private void CheckEndForEachIndex(); // 0x00000001802E76C0-0x00000001802E76D0
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private void CheckAllocateSize(int size); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		[GenerateTestsForBurstCompatibility]
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct Reader // TypeDefIndex: 11627
		{
			// Fields
			private UnsafeStream.Reader m_Reader; // 0x00
	
			// Properties
			public int ForEachCount { get; } // 0x0000000181CA36B0-0x0000000181CA36E0 
			public int RemainingItemCount { get; } // 0x000000018047EDE0-0x000000018047EDF0 
	
			// Constructors
			internal Reader(ref NativeStream stream); // 0x0000000181CA5770-0x0000000181CA57B0
	
			// Methods
			public int BeginForEachIndex(int foreachIndex); // 0x0000000181CA5400-0x0000000181CA5490
			public void EndForEachIndex(); // 0x00000001802E76C0-0x00000001802E76D0
			public UnsafeStream.Reader GetUnsafeReader(); // 0x00000001813282A0-0x00000001813282D0
			public unsafe byte* ReadUnsafePtr(int size); // 0x0000000181CA56B0-0x0000000181CA5710
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public ref ref T Read<T>()
				where T : struct;
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public ref ref T Peek<T>()
				where T : struct;
			public int Count(); // 0x0000000181CA5600-0x0000000181CA5670
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private void CheckNotReadingOutOfBounds(int size); // 0x00000001802E76C0-0x00000001802E76D0
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckRead(); // 0x00000001802E76C0-0x00000001802E76D0
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private void CheckReadSize(int size); // 0x00000001802E76C0-0x00000001802E76D0
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private void CheckBeginForEachIndex(int forEachIndex); // 0x00000001802E76C0-0x00000001802E76D0
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private void CheckEndForEachIndex(); // 0x0000000181CA5550-0x0000000181CA5600
		}
	
		// Constructors
		public NativeStream(int bufferCount, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA3670-0x0000000181CA36B0
	
		// Methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static JobHandle ScheduleConstruct<T>(out NativeStream stream, NativeList<T> bufferCount, JobHandle dependency, AllocatorManager.AllocatorHandle allocator)
			where T : struct;
		public static JobHandle ScheduleConstruct(out NativeStream stream, NativeArray<int> bufferCount, JobHandle dependency, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA35B0-0x0000000181CA3670
		public static JobHandle ScheduleConstruct(out NativeStream stream, NativeReference<int> bufferCount, JobHandle dependency, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA34D0-0x0000000181CA35B0
		[IsReadOnly]
		public bool IsEmpty(); // 0x0000000181CA3450-0x0000000181CA34D0
		public Reader AsReader(); // 0x0000000181CA31F0-0x0000000181CA3240
		public Writer AsWriter(); // 0x0000000181CA3240-0x0000000181CA32C0
		public int Count(); // 0x0000000181CA3340-0x0000000181CA33B0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public NativeArray<T> ToNativeArray<T>(AllocatorManager.AllocatorHandle allocator)
			where T : struct;
		public void Dispose(); // 0x0000000181CA3190-0x0000000181CA31A0
		public JobHandle Dispose(JobHandle inputDeps); // 0x0000000181CA33B0-0x0000000181CA3450
		internal UnsafeStream GetUnsafeStream(); // 0x0000000181325CE0-0x0000000181325D00
		private static void AllocateBlock(out NativeStream stream, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA31D0-0x0000000181CA31E0
		private void AllocateForEach(int forEachCount); // 0x0000000181CA31E0-0x0000000181CA31F0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckForEachCountGreaterThanZero(int forEachCount); // 0x0000000181CA32C0-0x0000000181CA3340
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
