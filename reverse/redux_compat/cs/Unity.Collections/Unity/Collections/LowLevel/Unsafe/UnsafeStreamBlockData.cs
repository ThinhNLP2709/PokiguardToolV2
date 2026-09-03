/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[GenerateTestsForBurstCompatibility]
	internal struct UnsafeStreamBlockData // TypeDefIndex: 11744
	{
		// Fields
		internal const int AllocationSize = 4096; // Metadata: 0x006A1D51
		internal AllocatorManager.AllocatorHandle Allocator; // 0x00
		internal unsafe UnsafeStreamBlock** Blocks; // 0x08
		internal int BlockCount; // 0x10
		internal AllocatorManager.Block Ranges; // 0x18
		internal int RangeCount; // 0x38
	
		// Methods
		internal unsafe UnsafeStreamBlock* Allocate(UnsafeStreamBlock* oldBlock, int threadIndex); // 0x0000000181CAC530-0x0000000181CAC5E0
		internal unsafe void Free(UnsafeStreamBlock* oldBlock); // 0x0000000181CAC5E0-0x0000000181CAC630
	}
}
