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
	internal class Scan // TypeDefIndex: 14263
	{
		// Fields
		private readonly ComputeShader shaderScan; // 0x10
		private readonly int kernelScan; // 0x18
		private readonly ComputeShader shaderReduce; // 0x20
		private readonly int kernelReduce; // 0x28
		private const uint kKeysPerThread = 4; // Metadata: 0x006A960E
		private const uint kGroupSize = 256; // Metadata: 0x006A960F
		private const uint kKeysPerGroup = 1024; // Metadata: 0x006A9611
	
		// Constructors
		public Scan(RadeonRaysShaders shaders); // 0x0000000182123310-0x00000001821233C0
	
		// Methods
		public void Execute(CommandBuffer cmd, GraphicsBuffer buffer, uint inputKeysOffset, uint outputKeysOffset, uint scratchDataOffset, uint size); // 0x0000000182122DA0-0x0000000182123190
		private void SetState(CommandBuffer cmd, ComputeShader shader, int kernelIndex, uint size, GraphicsBuffer buffer, uint inputKeysOffset, uint scratchDataOffset, uint outputKeysOffset); // 0x00000001821231C0-0x0000000182123310
		public static ulong GetScratchDataSizeInDwords(uint size); // 0x0000000182123190-0x00000001821231C0
	}
}
