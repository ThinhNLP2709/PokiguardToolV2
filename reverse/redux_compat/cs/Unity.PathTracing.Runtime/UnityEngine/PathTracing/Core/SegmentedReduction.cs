/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class SegmentedReduction // TypeDefIndex: 13603
	{
		// Fields
		private readonly ComputeShader _segmentedReductionShader; // 0x10
		private readonly int _reductionKernel; // 0x18
		private readonly uint _threadGroupSize; // 0x1C
	
		// Nested types
		private static class ShaderProperties // TypeDefIndex: 13604
		{
			// Fields
			public static readonly int SegmentWidth; // 0x00
			public static readonly int SegmentStride; // 0x04
			public static readonly int SegmentCount; // 0x08
			public static readonly int InputOffset; // 0x0C
			public static readonly int OutputOffset; // 0x10
			public static readonly int OverwriteOutput; // 0x14
			public static readonly int TruncateInterval; // 0x18
			public static readonly int TruncatedSegmentWidth; // 0x1C
			public static readonly int InputFloatBuffer; // 0x20
			public static readonly int OutputFloatBuffer; // 0x24
	
			// Constructors
			static ShaderProperties(); // 0x0000000181E12DB0-0x0000000181E12F90
		}
	
		// Constructors
		public SegmentedReduction(ComputeShader segmentedReductionShader); // 0x0000000181E12840-0x0000000181E128F0
	
		// Methods
		private static void CalculateParametersForTwoPassReduction(uint segmentWidth, uint segmentCount, out uint firstPassSegmentCount, out uint firstPassSegmentWidth, out uint truncateInterval, out uint truncatedSegmentWidth, out uint secondPassSegmentCount, out uint secondPassSegmentWidth); // 0x0000000181E12300-0x0000000181E123A0
		public static uint GetScratchBufferSizeInDwords(uint segmentWidth, uint segmentStride, uint segmentCount); // 0x0000000181E12630-0x0000000181E12690
		public void TwoPassSegmentedReduction(CommandBuffer cmd, uint segmentWidth, uint segmentStride, uint segmentCount, uint inputOffset, uint outputOffset, GraphicsBuffer inputBuffer, GraphicsBuffer scratchBuffer, GraphicsBuffer outputBuffer, bool overwriteOutput); // 0x0000000181E12700-0x0000000181E12840
		public void SinglePassSegmentedReduction(CommandBuffer cmd, uint segmentWidth, uint segmentStride, uint segmentCount, uint inputOffset, uint outputOffset, GraphicsBuffer inputBuffer, GraphicsBuffer outputBuffer, bool overwriteOutput); // 0x0000000181E12690-0x0000000181E12700
		private void DispatchReductionKernel(CommandBuffer cmd, uint segmentWidth, uint segmentStride, uint segmentCount, uint inputOffset, uint outputOffset, GraphicsBuffer inputBuffer, GraphicsBuffer outputBuffer, bool overwriteOutput, uint truncateInterval, uint truncatedSegmentWidth); // 0x0000000181E123A0-0x0000000181E12630
	}
}
