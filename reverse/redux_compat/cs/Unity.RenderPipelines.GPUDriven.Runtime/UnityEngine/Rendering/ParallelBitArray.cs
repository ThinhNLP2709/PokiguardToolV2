/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct ParallelBitArray : IDisposable // TypeDefIndex: 12998
	{
		// Fields
		private Allocator m_Allocator; // 0x00
		private NativeArray<long> m_Bits; // 0x08
		private int m_Length; // 0x18
	
		// Properties
		public int Length { get; } // 0x0000000180B23260-0x0000000180B23270 
		public bool IsCreated { get; } // 0x0000000181F4FA00-0x0000000181F4FA10 
	
		// Constructors
		public ParallelBitArray(int length, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x006A7699 */); // 0x0000000181F4F9B0-0x0000000181F4FA00
	
		// Methods
		public void Dispose(); // 0x0000000181F4F520-0x0000000181F4F570
		public void Dispose(JobHandle inputDeps); // 0x0000000181F4F570-0x0000000181F4F5D0
		public void Resize(int newLength); // 0x0000000181F4F7B0-0x0000000181F4F930
		public void Set(int index, bool value); // 0x0000000181F4F940-0x0000000181F4F9B0
		public bool Get(int index); // 0x0000000181F4F710-0x0000000181F4F740
		public ulong GetChunk(int chunk_index); // 0x0000000181F4F6A0-0x0000000181F4F6B0
		public void SetChunk(int chunk_index, ulong chunk_bits); // 0x0000000181F4F930-0x0000000181F4F940
		public ulong InterlockedReadChunk(int chunk_index); // 0x0000000181F4F790-0x0000000181F4F7B0
		public void InterlockedOrChunk(int chunk_index, ulong chunk_bits); // 0x0000000181F4F740-0x0000000181F4F790
		public int ChunkCount(); // 0x00000001802E64B0-0x00000001802E64C0
		public ParallelBitArray GetSubArray(int length); // 0x0000000181F4F6B0-0x0000000181F4F710
		public NativeArray<long> GetBitsArray(); // 0x0000000180C57230-0x0000000180C57240
		public void FillZeroes(int length); // 0x0000000181F4F5D0-0x0000000181F4F6A0
	}
}
