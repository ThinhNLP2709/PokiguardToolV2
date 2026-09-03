/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[GenerateTestsForBurstCompatibility]
	public struct UnsafeStream : INativeDisposable // TypeDefIndex: 11745
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal AllocatorManager.Block m_BlockData; // 0x00
	
		// Properties
		public bool IsCreated { [IsReadOnly] get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
		public int ForEachCount { [IsReadOnly] get; } // 0x0000000181CA36B0-0x0000000181CA36E0 
	
		// Nested types
		[BurstCompile]
		internal struct DisposeJob : IJob // TypeDefIndex: 11746
		{
			// Fields
			public UnsafeStream Container; // 0x00
	
			// Methods
			public void Execute(); // 0x0000000181CA1490-0x0000000181CA14A0
		}
	
		[BurstCompile]
		internal struct ConstructJobList : IJob // TypeDefIndex: 11747
		{
			// Fields
			public UnsafeStream Container; // 0x00
			[NativeDisableUnsafePtrRestriction]
			[ReadOnly]
			public unsafe UntypedUnsafeList* List; // 0x20
	
			// Methods
			public void Execute(); // 0x0000000181CA1210-0x0000000181CA1240
		}
	
		[BurstCompile]
		internal struct ConstructJob : IJob // TypeDefIndex: 11748
		{
			// Fields
			public UnsafeStream Container; // 0x00
			[ReadOnly]
			public NativeArray<int> Length; // 0x20
	
			// Methods
			public void Execute(); // 0x0000000181CA1280-0x0000000181CA12A0
		}
	
		[GenerateTestsForBurstCompatibility]
		public struct Writer // TypeDefIndex: 11749
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal AllocatorManager.Block m_BlockData; // 0x00
			[NativeDisableUnsafePtrRestriction]
			private unsafe UnsafeStreamBlock* m_CurrentBlock; // 0x20
			[NativeDisableUnsafePtrRestriction]
			private unsafe byte* m_CurrentPtr; // 0x28
			[NativeDisableUnsafePtrRestriction]
			private unsafe byte* m_CurrentBlockEnd; // 0x30
			internal int m_ForeachIndex; // 0x38
			private int m_ElementCount; // 0x3C
			[NativeDisableUnsafePtrRestriction]
			private unsafe UnsafeStreamBlock* m_FirstBlock; // 0x40
			private int m_FirstOffset; // 0x48
			private int m_NumberOfBlocks; // 0x4C
			[NativeSetThreadIndex]
			private int m_ThreadIndex; // 0x50
	
			// Properties
			public int ForEachCount { get; } // 0x0000000181CA36B0-0x0000000181CA36E0 
	
			// Constructors
			internal unsafe Writer(ref UnsafeStream stream); // 0x0000000181CAD4E0-0x0000000181CAD510
	
			// Methods
			public void BeginForEachIndex(int foreachIndex); // 0x0000000181CAD3F0-0x0000000181CAD410
			public void EndForEachIndex(); // 0x0000000181CAD410-0x0000000181CAD4E0
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public void Write<T>(T value)
				where T : struct;
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public ref ref T Allocate<T>()
				where T : struct;
			public unsafe byte* Allocate(int size); // 0x0000000181CAD2D0-0x0000000181CAD3F0
		}
	
		public struct ReaderState // TypeDefIndex: 11750
		{
			// Fields
			internal unsafe UnsafeStreamBlock* m_CurrentBlock; // 0x00
			internal unsafe byte* m_CurrentPtr; // 0x08
			internal unsafe byte* m_CurrentBlockEnd; // 0x10
			internal int m_RemainingItemCount; // 0x18
			internal int m_LastBlockSize; // 0x1C
		}
	
		[GenerateTestsForBurstCompatibility]
		public struct Reader // TypeDefIndex: 11751
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal AllocatorManager.Block m_BlockData; // 0x00
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeStreamBlock* m_CurrentBlock; // 0x20
			[NativeDisableUnsafePtrRestriction]
			internal unsafe byte* m_CurrentPtr; // 0x28
			[NativeDisableUnsafePtrRestriction]
			internal unsafe byte* m_CurrentBlockEnd; // 0x30
			internal int m_RemainingItemCount; // 0x38
			internal int m_LastBlockSize; // 0x3C
	
			// Properties
			public ReaderState State { get; set; } // 0x0000000181CA5820-0x0000000181CA5850 0x0000000181CA5850-0x0000000181CA5880
			public int ForEachCount { get; } // 0x0000000181CA36B0-0x0000000181CA36E0 
			public int RemainingItemCount { get; } // 0x000000018047EDE0-0x000000018047EDF0 
	
			// Constructors
			internal unsafe Reader(ref UnsafeStream stream); // 0x0000000181CA57B0-0x0000000181CA57E0
	
			// Methods
			public int BeginForEachIndex(int foreachIndex); // 0x0000000181CA5400-0x0000000181CA5490
			public void EndForEachIndex(); // 0x00000001802E76C0-0x00000001802E76D0
			public unsafe byte* ReadUnsafePtr(int size); // 0x0000000181CA5710-0x0000000181CA5770
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public ref ref T Read<T>()
				where T : struct;
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public ref ref T Peek<T>()
				where T : struct;
			public int Count(); // 0x0000000181CA5600-0x0000000181CA5670
		}
	
		// Constructors
		public UnsafeStream(int bufferCount, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA3670-0x0000000181CA36B0
	
		// Methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static JobHandle ScheduleConstruct<T>(out UnsafeStream stream, NativeList<T> bufferCount, JobHandle dependency, AllocatorManager.AllocatorHandle allocator)
			where T : struct;
		public static JobHandle ScheduleConstruct(out UnsafeStream stream, NativeArray<int> bufferCount, JobHandle dependency, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CACA80-0x0000000181CACB40
		internal static void AllocateBlock(out UnsafeStream stream, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CAC630-0x0000000181CAC7A0
		internal void AllocateForEach(int forEachCount); // 0x0000000181CAC7A0-0x0000000181CAC870
		[IsReadOnly]
		public bool IsEmpty(); // 0x0000000181CA3450-0x0000000181CA34D0
		public Reader AsReader(); // 0x0000000181CAC870-0x0000000181CAC8A0
		public Writer AsWriter(); // 0x0000000181CAC8A0-0x0000000181CAC8E0
		public int Count(); // 0x0000000181CA3340-0x0000000181CA33B0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public NativeArray<T> ToNativeArray<T>(AllocatorManager.AllocatorHandle allocator)
			where T : struct;
		[IsReadOnly]
		internal unsafe void* GetForEachCountPtr(); // 0x0000000181CACA50-0x0000000181CACA80
		private void Deallocate(); // 0x0000000181CAC8E0-0x0000000181CAC9B0
		public void Dispose(); // 0x0000000181CA3190-0x0000000181CA31A0
		public JobHandle Dispose(JobHandle inputDeps); // 0x0000000181CAC9B0-0x0000000181CACA50
	}
}
