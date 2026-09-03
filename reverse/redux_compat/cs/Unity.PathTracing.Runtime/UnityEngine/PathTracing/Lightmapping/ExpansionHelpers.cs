/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.PathTracing.Integration;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Sampling;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal static class ExpansionHelpers // TypeDefIndex: 13636
	{
		// Fields
		private static readonly ProfilerMarker k_ClearExpanded; // 0x00
		private static readonly ProfilerMarker k_UVSampling; // 0x08
		private static readonly ProfilerMarker k_CompactGBuffer; // 0x10
		private static readonly ProfilerMarker k_BinarySum; // 0x18
		private static readonly ProfilerMarker k_CopyToLightmap; // 0x20
	
		// Constructors
		static ExpansionHelpers(); // 0x0000000181E08C70-0x0000000181E08DF0
	
		// Methods
		internal static int PopulateAccumulationIndirectDispatch(CommandBuffer cmd, ComputeShader populateShader, int populateKernel, uint expandedSampleWidth, GraphicsBuffer compactedGbufferLength, GraphicsBuffer accumulationDispatchBuffer); // 0x0000000181E085B0-0x0000000181E086F0
		internal static int PopulateClearExpandedOutputIndirectDispatch(CommandBuffer cmd, ComputeShader populateClearDispatch, int populateClearDispatchKernel, uint clearThreadGroupSizeX, uint expandedSampleWidth, GraphicsBuffer compactedGBufferLength, GraphicsBuffer clearDispatchBuffer); // 0x0000000181E086F0-0x0000000181E08860
		internal static int ClearExpandedOutput(CommandBuffer cmd, ComputeShader clearExpandedOutput, int clearExpandedOutputKernel, GraphicsBuffer expandedOutput, GraphicsBuffer clearDispatchBuffer); // 0x0000000181E073D0-0x0000000181E074E0
		internal static void GenerateGBuffer(CommandBuffer cmd, IRayTracingShader gBufferShader, GraphicsBuffer gBuffer, GraphicsBuffer traceScratchBuffer, SamplingResources samplingResources, UVAccelerationStructure uvAS, UVFallbackBuffer uvFallbackBuffer, GraphicsBuffer compactedGBufferLength, GraphicsBuffer compactedTexelIndices, Vector2Int instanceTexelOffset, uint2 chunkOffset, uint chunkSize, uint expandedSampleWidth, uint passSampleCount, uint sampleOffset, AntiAliasingType aaType, uint superSampleWidth); // 0x0000000181E08170-0x0000000181E085B0
		internal static float2[] DebugGBuffer(CommandBuffer cmd, BakeInstance instance, LightmappingContext lightmappingContext, uint expandedSampleWidth, uint passSampleCount); // 0x0000000181E07A90-0x0000000181E08170
		internal static int CompactGBuffer(CommandBuffer cmd, ComputeShader compactGBuffer, int compactGBufferKernel, uint instanceWidth, uint chunkSize, uint2 chunkOffset, UVFallbackBuffer uvFallbackBuffer, GraphicsBuffer compactedGBufferLength, GraphicsBuffer compactedTexelIndices); // 0x0000000181E074E0-0x0000000181E077C0
		internal static int PopulateReduceExpandedOutputIndirectDispatch(CommandBuffer cmd, ComputeShader populateReduceExpandedOutput, int populateReduceExpandedOutputKernel, uint reduceThreadGroupSizeX, uint expandedSampleWidth, GraphicsBuffer compactedGBufferLength, GraphicsBuffer reduceDispatchBuffer); // 0x0000000181E089A0-0x0000000181E08B10
		internal static int ReduceExpandedOutput(CommandBuffer cmd, ComputeShader binaryGroupSumLeftShader, int binaryGroupSumLeftKernel, GraphicsBuffer expandedOutput, int expandedDispatchSize, uint expandedSampleWidth, GraphicsBuffer reduceDispatch); // 0x0000000181E08B10-0x0000000181E08C70
		internal static int PopulateCopyToLightmapIndirectDispatch(CommandBuffer cmd, ComputeShader populateCopyToLightmap, int populateCopyToLightmapKernel, uint copyThreadGroupSizeX, GraphicsBuffer compactedGBufferLength, GraphicsBuffer copyDispatch); // 0x0000000181E08860-0x0000000181E089A0
		internal static int CopyToLightmap(CommandBuffer cmd, ComputeShader copyToLightmap, int copyToLightmapKernel, uint expandedSampleWidth, int instanceWidth, Vector2Int instanceTexelOffset, uint2 chunkOffset, GraphicsBuffer compactedGBufferLength, GraphicsBuffer compactedTexelIndices, GraphicsBuffer expandedOutput, GraphicsBuffer copyDispatch, RenderTexture output); // 0x0000000181E077C0-0x0000000181E07A90
	}
}
