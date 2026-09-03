/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal struct BlockAllocator : IDisposable // TypeDefIndex: 14293
	{
		// Fields
		private int m_FreeElementCount; // 0x00
		private int m_MaxElementCount; // 0x04
		private NativeList<Block> m_freeBlocks; // 0x08
		private NativeList<Block> m_usedBlocks; // 0x10
		private NativeList<int> m_freeSlots; // 0x18
	
		// Properties
		public int freeElementsCount { get; } // 0x0000000180732D10-0x0000000180732D20 
		public int freeBlocks { get; } // 0x00000001821131A0-0x00000001821131B0 
		public int capacity { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
		public int allocatedSize { get; } // 0x0000000181F7E240-0x0000000181F7E250 
	
		// Nested types
		public struct Block // TypeDefIndex: 14294
		{
			// Fields
			public int offset; // 0x00
			public int count; // 0x04
			public static readonly Block Invalid; // 0x00
	
			// Constructors
			static Block(); // 0x00000001821131B0-0x0000000182113200
		}
	
		public struct Allocation // TypeDefIndex: 14295
		{
			// Fields
			public int handle; // 0x00
			public Block block; // 0x04
			public static readonly Allocation Invalid; // 0x00
	
			// Properties
			public bool valid { [IsReadOnly] get; } // 0x0000000181E112B0-0x0000000181E112C0 
	
			// Constructors
			static Allocation(); // 0x0000000182111870-0x00000001821118D0
		}
	
		// Methods
		public void Initialize(int maxElementCounts); // 0x0000000182112DF0-0x0000000182112F00
		private int CalculateGeometricGrowthCapacity(int desiredNewCapacity, int maxAllowedNewCapacity); // 0x0000000182112890-0x00000001821128D0
		public int Grow(int newDesiredCapacity, int maxAllowedCapacity = 2147483647 /* Metadata: 0x006A962C */); // 0x0000000182112D40-0x0000000182112DF0
		public bool GetExpectedGrowthToFitAllocation(int elementCounts, int maxAllowedCapacity, out int newCapacity); // 0x0000000182112AB0-0x0000000182112B60
		public Allocation GrowAndAllocate(int elementCounts, out int oldCapacity, out int newCapacity); // 0x0000000182112B60-0x0000000182112BB0
		public Allocation GrowAndAllocate(int elementCounts, int maxAllowedCapacity, out int oldCapacity, out int newCapacity); // 0x0000000182112BB0-0x0000000182112D40
		public void Dispose(); // 0x00000001821128D0-0x0000000182112920
		public Allocation Allocate(int elementCounts); // 0x00000001821126B0-0x0000000182112890
		private int MergeBlockFrontBack(int freeBlockId); // 0x0000000182112F00-0x0000000182112FD0
		public void FreeAllocation([IsReadOnly] in Allocation allocation); // 0x0000000182112920-0x0000000182112AB0
		public Allocation[] SplitAllocation([IsReadOnly] in Allocation allocation, int count); // 0x0000000182112FD0-0x00000001821131A0
	}
}
