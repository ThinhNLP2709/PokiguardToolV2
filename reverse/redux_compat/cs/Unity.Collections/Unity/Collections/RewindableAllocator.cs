/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[BurstCompile]
	public struct RewindableAllocator : AllocatorManager.IAllocator // TypeDefIndex: 11636
	{
		// Fields
		private const int kLog2MaxMemoryBlockSize = 26; // Metadata: 0x006A1C4E
		private const long kMaxMemoryBlockSize = 67108864; // Metadata: 0x006A1C4F
		private const long kMinMemoryBlockSize = 131072; // Metadata: 0x006A1C57
		private const int kMaxNumBlocks = 64; // Metadata: 0x006A1C5F
		private const int kBlockBusyRewindMask = 2147483647; // Metadata: 0x006A1C61
		private const int kBlockBusyAllocateMask = 2147483647; // Metadata: 0x006A1C62
		private Spinner m_spinner; // 0x00
		private AllocatorManager.AllocatorHandle m_handle; // 0x04
		private UnmanagedArray<MemoryBlock> m_block; // 0x08
		private MemoryLabel m_memoryLabel; // 0x18
		private int m_last; // 0x28
		private int m_used; // 0x2C
		private byte m_enableBlockFree; // 0x30
		private byte m_reachMaxBlockSize; // 0x31
	
		// Properties
		public bool EnableBlockFree { get; set; } // 0x0000000181CA65D0-0x0000000181CA65E0 0x00000001802E8960-0x00000001802E8970
		public int BlocksAllocated { get; } // 0x0000000181CA6560-0x0000000181CA6570 
		public int InitialSizeInBytes { get; } // 0x0000000181CA6640-0x0000000181CA6660 
		internal long MaxMemoryBlockSize { get; } // 0x0000000181CA6670-0x0000000181CA6680 
		internal long BytesAllocated { get; } // 0x0000000181CA6570-0x0000000181CA65D0 
		[ExcludeFromBurstCompatTesting("Uses managed delegate")]
		public AllocatorManager.TryFunction Function { get; } // 0x0000000181CA65E0-0x0000000181CA6640 
		public AllocatorManager.AllocatorHandle Handle { get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public Allocator ToAllocator { get; } // 0x0000000181CA6680-0x0000000181CA6690 
		public bool IsCustomAllocator { get; } // 0x0000000181CA6660-0x0000000181CA6670 
		public bool IsAutoDispose { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Nested types
		internal struct Union // TypeDefIndex: 11637
		{
			// Fields
			internal long m_long; // 0x00
			private const int currentBits = 40; // Metadata: 0x006A1C63
			private const int currentOffset = 0; // Metadata: 0x006A1C64
			private const long currentMask = 1099511627775; // Metadata: 0x006A1C65
			private const int allocCountBits = 24; // Metadata: 0x006A1C6D
			private const int allocCountOffset = 40; // Metadata: 0x006A1C6E
			private const long allocCountMask = 16777215; // Metadata: 0x006A1C6F
	
			// Properties
			internal long m_current { get; set; } // 0x0000000181CAA200-0x0000000181CAA220 0x0000000181CAA240-0x0000000181CAA260
			internal long m_allocCount { get; set; } // 0x0000000181CAA1F0-0x0000000181CAA200 0x0000000181CAA220-0x0000000181CAA240
		}
	
		[GenerateTestsForBurstCompatibility]
		internal struct MemoryBlock : IDisposable // TypeDefIndex: 11638
		{
			// Fields
			public const int kMaximumAlignment = 16384; // Metadata: 0x006A1C77
			public unsafe byte* m_pointer; // 0x00
			public long m_bytes; // 0x08
			public Union m_union; // 0x10
			private MemoryLabel m_memoryLabel; // 0x18
	
			// Constructors
			public unsafe MemoryBlock(long bytes, MemoryLabel memoryLabel); // 0x0000000181CA2650-0x0000000181CA26C0
	
			// Methods
			public void Rewind(); // 0x0000000180D92C60-0x0000000180D92C70
			public void Dispose(); // 0x0000000181CA2610-0x0000000181CA2650
			public bool Contains(IntPtr ptr); // 0x0000000181CA25C0-0x0000000181CA2610
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int Try_00000A4F_PostfixBurstDelegate(IntPtr state, ref AllocatorManager.Block block); // TypeDefIndex: 11639; 0x0000000180A70FB0-0x0000000180A70FC0
	
		internal static class Try_00000A4F_BurstDirectCall // TypeDefIndex: 11640
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181CA89E0-0x0000000181CA8A20
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_00016519); // 0x0000000181CA8A20-0x0000000181CA8B80
			private static IntPtr GetFunctionPointer(); // 0x0000000181CA8B80-0x0000000181CA8CD0
			public static int Invoke(IntPtr state, ref AllocatorManager.Block block); // 0x0000000181CA6390-0x0000000181CA6560
		}
	
		// Methods
		public void Initialize(int initialSizeInBytes, bool enableBlockFree = false /* Metadata: 0x006A1C4D */); // 0x0000000181CA5AB0-0x0000000181CA5CA0
		public void Rewind(); // 0x0000000181CA5CA0-0x0000000181CA5E00
		public void Dispose(); // 0x0000000181CA5880-0x0000000181CA5AB0
		private int TryAllocate(ref AllocatorManager.Block block, int startIndex, int lastIndex, long alignedSize, long alignmentMask); // 0x0000000181CA5E00-0x0000000181CA6000
		public int Try(ref AllocatorManager.Block block); // 0x0000000181CA6030-0x0000000181CA6390
		[BurstCompile]
		[MonoPInvokeCallback(typeof(AllocatorManager.TryFunction))]
		internal static int Try(IntPtr state, ref AllocatorManager.Block block); // 0x0000000181CA6390-0x0000000181CA6560
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public NativeArray<T> AllocateNativeArray<T>(int length)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public NativeList<T> AllocateNativeList<T>(int capacity)
			where T : struct;
		[BurstCompile]
		[MonoPInvokeCallback(typeof(AllocatorManager.TryFunction))]
		internal static int Try_BurstManaged(IntPtr state, ref AllocatorManager.Block block); // 0x0000000181CA6000-0x0000000181CA6030
	}
}
