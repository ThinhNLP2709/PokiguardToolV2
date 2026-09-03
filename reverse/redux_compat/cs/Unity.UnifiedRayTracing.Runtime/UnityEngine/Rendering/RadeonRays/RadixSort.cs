/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.RadeonRays
{
	internal class RadixSort // TypeDefIndex: 14260
	{
		// Fields
		private readonly ComputeShader shaderBitHistogram; // 0x10
		private readonly int kernelBitHistogram; // 0x18
		private readonly ComputeShader shaderScatter; // 0x20
		private readonly int kernelScatter; // 0x28
		private readonly Scan scan; // 0x30
		private const uint kKeysPerThread = 4; // Metadata: 0x006A95FD
		private const uint kGroupSize = 256; // Metadata: 0x006A95FE
		private const uint kKeysPerGroup = 1024; // Metadata: 0x006A9600
		private const int kNumBitsPerPass = 4; // Metadata: 0x006A9602
	
		// Constructors
		public RadixSort(RadeonRaysShaders shaders); // 0x0000000182121690-0x0000000182121810
	
		// Methods
		public void Execute(CommandBuffer cmd, GraphicsBuffer buffer, uint inputKeysOffset, uint outputKeysOffset, uint inputValuesOffset, uint outputValuesOffset, uint scratchDataOffset, uint size); // 0x0000000182121140-0x0000000182121620
		public static ulong GetScratchDataSizeInDwords(uint size); // 0x0000000182121620-0x0000000182121690
	}
}
