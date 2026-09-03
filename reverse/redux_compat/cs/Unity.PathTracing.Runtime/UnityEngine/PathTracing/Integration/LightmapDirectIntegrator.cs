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
	internal class LightmapDirectIntegrator : IDisposable // TypeDefIndex: 13545
	{
		// Fields
		private IRayTracingShader _stochasticLightShader; // 0x10
		private IRayTracingShader _directionalAndEnvironmentShader; // 0x18
		private ComputeShader _normalizationShader; // 0x20
		private int _normalizationKernel; // 0x28
		private int _directionalNormalizationKernel; // 0x2C
		private SamplingResources _samplingResources; // 0x30
		private RTHandle _emptyTexture; // 0x38
		private GraphicsBuffer _accumulationDispatchBuffer; // 0x40
		private ComputeShader _expansionHelpers; // 0x48
		private int _populateAccumulationDispatchKernel; // 0x50
	
		// Constructors
		public LightmapDirectIntegrator(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Dispose(); // 0x0000000181DF0D60-0x0000000181DF0D80
		public void SetupLightSamplingKeywords(CommandBuffer cmd, LightSamplingMode lightSamplingMode, EmissiveSamplingMode emissiveSamplingMode); // 0x0000000181DF1460-0x0000000181DF14E0
		public void SetTerrainKeyword(CommandBuffer cmd, bool hasTerrains); // 0x0000000181DF1410-0x0000000181DF1460
		public void Prepare(IRayTracingShader stochasticLightShader, IRayTracingShader directionalAndEnvironmentShader, ComputeShader normalizationShader, ComputeShader expansionHelpers, SamplingResources samplingResources, RTHandle emptyExposureTexture); // 0x0000000181DF12C0-0x0000000181DF1410
		public void Accumulate(CommandBuffer cmd, uint sampleCountToTakePerTexel, uint currentSampleCountPerTexel, Matrix4x4 shaderLocalToWorld, Matrix4x4 shaderLocalToWorldNormals, int instanceGeometryIndex, int terrainIndex, Vector2Int instanceTexelSize, uint2 chunkOffset, World world, GraphicsBuffer traceScratchBuffer, GraphicsBuffer gBuffer, uint expandedSampleWidth, GraphicsBuffer expandedOutput, GraphicsBuffer expandedDirectional, GraphicsBuffer compactedTexelIndices, GraphicsBuffer compactedGbufferLength, bool receiveShadows, float pushOff, uint risCandidateCount, LightSamplingMode lightSamplingMode, uint maxLightsInAnyCell, bool newChunkStarted); // 0x0000000181DEFF40-0x0000000181DF0D60
		public void Normalize(CommandBuffer cmd, RenderTexture lightmapInOut); // 0x0000000181DF1090-0x0000000181DF12C0
		public void NormalizeDirectional(CommandBuffer cmd, RenderTexture directionalInOut, RenderTexture sampleCountInW, RenderTexture normals); // 0x0000000181DF0D80-0x0000000181DF1090
	}
}
