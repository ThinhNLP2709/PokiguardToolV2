/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct OccluderContext : IDisposable // TypeDefIndex: 12870
	{
		// Fields
		public const int k_FirstDepthMipIndex = 3; // Metadata: 0x006A7601
		public const int k_MaxOccluderMips = 8; // Metadata: 0x006A7602
		public const int k_MaxSilhouettePlanes = 6; // Metadata: 0x006A7603
		public const int k_MaxSubviewsPerView = 6; // Metadata: 0x006A7604
		public int version; // 0x00
		public Vector2Int depthBufferSize; // 0x04
		public NativeArray<OccluderDerivedData> subviewData; // 0x10
		public int subviewValidMask; // 0x20
		public NativeArray<OccluderMipBounds> occluderMipBounds; // 0x28
		public Vector2Int occluderMipLayoutSize; // 0x38
		public Vector2Int occluderDepthPyramidSize; // 0x40
		public RTHandle occluderDepthPyramid; // 0x48
		public int occlusionDebugOverlaySize; // 0x50
		public GraphicsBuffer occlusionDebugOverlay; // 0x58
		public bool debugNeedsClear; // 0x60
		public ComputeBuffer constantBuffer; // 0x68
		public NativeArray<OccluderDepthPyramidConstants> constantBufferData; // 0x70
	
		// Properties
		public int subviewCount { get; } // 0x0000000180B23260-0x0000000180B23270 
		public Vector2 depthBufferSizeInOccluderPixels { get; } // 0x0000000181F41D60-0x0000000181F41D90 
	
		// Nested types
		private static class ShaderIDs // TypeDefIndex: 12871
		{
			// Fields
			public static readonly int _SrcDepth; // 0x00
			public static readonly int _DstDepth; // 0x04
			public static readonly int OccluderDepthPyramidConstants; // 0x08
	
			// Constructors
			static ShaderIDs(); // 0x0000000181F486F0-0x0000000181F487A0
		}
	
		// Methods
		public bool IsSubviewValid(int subviewIndex); // 0x0000000181F41340-0x0000000181F41360
		public void Dispose(); // 0x0000000181F40F50-0x0000000181F41050
		private void UpdateMipBounds(); // 0x0000000181F41BB0-0x0000000181F41D60
		private void AllocateTexturesIfNecessary(bool debugOverlayEnabled); // 0x0000000181F40690-0x0000000181F40950
		internal static void SetKeyword(ComputeCommandBuffer cmd, ComputeShader cs, [IsReadOnly] in LocalKeyword keyword, bool value); // 0x0000000181F41650-0x0000000181F41680
		private OccluderDepthPyramidConstants SetupFarDepthPyramidConstants(ReadOnlySpan<OccluderSubviewUpdate> occluderSubviewUpdates, NativeArray<Plane> silhouettePlanes); // 0x0000000181F41680-0x0000000181F41BB0
		public void CreateFarDepthPyramid(ComputeCommandBuffer cmd, [IsReadOnly] in OccluderParameters occluderParams, ReadOnlySpan<OccluderSubviewUpdate> occluderSubviewUpdates, [IsReadOnly] in OccluderHandles occluderHandles, NativeArray<Plane> silhouettePlanes, ComputeShader occluderDepthPyramidCS, int occluderDepthDownscaleKernel); // 0x0000000181F40950-0x0000000181F40F50
		public OccluderHandles Import(RenderGraph renderGraph); // 0x0000000181F411D0-0x0000000181F41340
		public void PrepareOccluders([IsReadOnly] in OccluderParameters occluderParams); // 0x0000000181F41360-0x0000000181F41650
		internal OcclusionCullingDebugOutput GetDebugOutput(); // 0x0000000181F41050-0x0000000181F411D0
	}
}
