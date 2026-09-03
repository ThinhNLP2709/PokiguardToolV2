/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal struct BuddyAllocator : IDisposable // TypeDefIndex: 9504
	{
		// Fields
		private unsafe void* m_Data; // 0x00
		private ValueTuple<int, int> m_ActiveFreeMaskCounts; // 0x08
		private ValueTuple<int, int> m_FreeMasksStorage; // 0x10
		private ValueTuple<int, int> m_FreeMaskIndicesStorage; // 0x18
		private Allocator m_Allocator; // 0x20
	
		// Properties
		private ref Header header { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		private NativeArray<int> freeMaskCounts { get; } // 0x0000000181F89A90-0x0000000181F89AD0 
		private NativeArray<ulong> freeMasksStorage { get; } // 0x0000000181F89B10-0x0000000181F89B50 
		private NativeArray<int> freeMaskIndicesStorage { get; } // 0x0000000181F89AD0-0x0000000181F89B10 
		public int levelCount { get; } // 0x0000000181F4F500-0x0000000181F4F510 
	
		// Nested types
		private struct Header // TypeDefIndex: 9505
		{
			// Fields
			public int branchingOrder; // 0x00
			public int levelCount; // 0x04
			public int allocationCount; // 0x08
			public int freeAllocationIdsCount; // 0x0C
		}
	
		// Constructors
		public unsafe BuddyAllocator(int levelCount, int branchingOrder, Allocator allocator = Allocator.Persistent /* Metadata: 0x0069EBF2 */); // 0x0000000181F898F0-0x0000000181F89A90
	
		// Methods
		private NativeArray<ulong> FreeMasks(int level); // 0x0000000181F891B0-0x0000000181F892C0
		private NativeArray<int> FreeMaskIndices(int level); // 0x0000000181F890A0-0x0000000181F891B0
		public bool TryAllocate(int requestedLevel, out BuddyAllocation allocation); // 0x0000000181F895D0-0x0000000181F898F0
		public void Free(BuddyAllocation allocation); // 0x0000000181F892C0-0x0000000181F894C0
		public void Dispose(); // 0x0000000181F89070-0x0000000181F890A0
		private NativeArray<T> GetNativeArray<T>(int offset, int length)
			where T : struct;
		private static int LevelOffset(int level, int branchingOrder); // 0x0000000181F89560-0x0000000181F89590
		private static int LevelLength(int level, int branchingOrder); // 0x0000000181F894F0-0x0000000181F89500
		private static int LevelOffset64(int level, int branchingOrder); // 0x0000000181F89500-0x0000000181F89560
		private static int LevelLength64(int level, int branchingOrder); // 0x0000000181F894C0-0x0000000181F894F0
		private static ValueTuple<int, int> AllocateRange<T>(int length, ref int dataSize)
			where T : struct;
		private static int AlignForward(int offset, int alignment); // 0x0000000181F89050-0x0000000181F89070
		private static unsafe void* PtrAdd(void* ptr, int bytes); // 0x0000000181F895A0-0x0000000181F895D0
		private static int Pow2(int n); // 0x0000000181EC1700-0x0000000181EC1710
		private static int Pow2N(int x, int n); // 0x0000000181F89590-0x0000000181F895A0
	}
}
