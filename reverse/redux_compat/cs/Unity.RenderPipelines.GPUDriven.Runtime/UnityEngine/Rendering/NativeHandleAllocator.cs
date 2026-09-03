/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct NativeHandleAllocator // TypeDefIndex: 12995
	{
		// Fields
		private const int InvalidChunkIndex = -1; // Metadata: 0x006A7697
		private const int BitChunkSize = 32; // Metadata: 0x006A7698
		private UnsafeList<int> m_StructData; // 0x00
		private UnsafeList<FreeBitsChunk> m_FreeBitChunksDense; // 0x18
		private UnsafeList<int> m_FreeChunkIndicesSparse; // 0x30
	
		// Properties
		public int length { get; private set; } // 0x0000000180C51FD0-0x0000000180C51FE0 0x0000000180C52420-0x0000000180C52430
		public int freeCount { get; private set; } // 0x0000000181F4F500-0x0000000181F4F510 0x0000000181F4F510-0x0000000181F4F520
		public int allocatedCount { get; } // 0x0000000181F4F4E0-0x0000000181F4F500 
		public bool isValid { get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
	
		// Nested types
		private struct FreeBitsChunk // TypeDefIndex: 12996
		{
			// Fields
			public readonly int chunk; // 0x00
			public uint freeBits; // 0x04
	
			// Constructors
			public FreeBitsChunk(int chunk, uint freeBits); // 0x0000000180C55C70-0x0000000180C55C80
		}
	
		// Methods
		public void Initialize(int initialCapacity = 128 /* Metadata: 0x006A7695 */); // 0x0000000181F4F0F0-0x0000000181F4F2B0
		public void Dispose(); // 0x0000000181F4EFA0-0x0000000181F4EFE0
		public int Allocate(); // 0x0000000181F4EEA0-0x0000000181F4EFA0
		public void Free(int handle); // 0x0000000181F4EFE0-0x0000000181F4F0F0
		internal void TrimLengthImpl(); // 0x0000000181F4F2B0-0x0000000181F4F4E0
		public void TrimLength(); // 0x0000000181F4EE90-0x0000000181F4EEA0
	}
}
