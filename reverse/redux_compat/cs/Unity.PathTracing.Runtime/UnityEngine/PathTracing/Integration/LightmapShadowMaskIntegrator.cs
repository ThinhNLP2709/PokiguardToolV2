/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PathTracing.Core;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Sampling;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Integration
{
	internal class LightmapShadowMaskIntegrator : IDisposable // TypeDefIndex: 13550
	{
		// Fields
		private IRayTracingShader _accumulationShader; // 0x10
		private ComputeShader _normalizationShader; // 0x18
		private int _normalizationKernel; // 0x20
		private SamplingResources _samplingResources; // 0x28
		private RTHandle _emptyTexture; // 0x30
		private GraphicsBuffer _accumulationDispatchBuffer; // 0x38
		private ComputeShader _expansionHelpers; // 0x40
		private int _populateAccumulationDispatchKernel; // 0x48
	
		// Constructors
		public LightmapShadowMaskIntegrator(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Dispose(); // 0x0000000181DEF1A0-0x0000000181DEF1C0
		public void SetTerrainKeyword(CommandBuffer cmd, bool hasTerrains); // 0x0000000181DEE1F0-0x0000000181DEE210
		public void Prepare(IRayTracingShader accumulationShader, ComputeShader normalizationShader, ComputeShader expansionHelpers, SamplingResources samplingResources, RTHandle emptyExposureTexture); // 0x0000000181DF3A60-0x0000000181DF3B70
		public void Accumulate(CommandBuffer cmd, uint sampleCountToTakePerTexel, uint currentSampleCountPerTexel, Matrix4x4 shaderLocalToWorld, Matrix4x4 shaderLocalToWorldNormals, int instanceGeometryIndex, int terrainIndex, Vector2Int instanceTexelSize, uint2 chunkOffset, World world, GraphicsBuffer traceScratchBuffer, GraphicsBuffer gBuffer, uint expandedSampleWidth, GraphicsBuffer expandedOutput, GraphicsBuffer expandedSampleCountInW, GraphicsBuffer compactedTexelIndices, GraphicsBuffer compactedGbufferLength, bool receiveShadows, float pushOff, bool newChunkStarted); // 0x0000000181DF3120-0x0000000181DF37C0
		public void Normalize(CommandBuffer cmd, RenderTexture lightmap, RenderTexture sampleCountInW); // 0x0000000181DF37C0-0x0000000181DF3A60
	}
}
