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
	public struct UnsafeScratchAllocator // TypeDefIndex: 11740
	{
		// Fields
		private unsafe void* m_Pointer; // 0x00
		private int m_LengthInBytes; // 0x08
		private readonly int m_CapacityInBytes; // 0x0C
	
		// Constructors
		public unsafe UnsafeScratchAllocator(void* ptr, int capacityInBytes); // 0x0000000181CAC520-0x0000000181CAC530
	
		// Methods
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckAllocationDoesNotExceedCapacity(ulong requestedSize); // 0x0000000181CAC440-0x0000000181CAC520
		public unsafe void* Allocate(int sizeInBytes, int alignmentInBytes); // 0x0000000181CAC3A0-0x0000000181CAC440
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public unsafe void* Allocate<T>(int count = 1 /* Metadata: 0x006A1D50 */)
			where T : struct;
	}
}
