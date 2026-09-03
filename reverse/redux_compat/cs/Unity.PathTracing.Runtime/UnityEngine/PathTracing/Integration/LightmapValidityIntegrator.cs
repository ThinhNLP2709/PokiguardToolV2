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
	internal class LightmapValidityIntegrator : IDisposable // TypeDefIndex: 13549
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
		public LightmapValidityIntegrator(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Dispose(); // 0x0000000181DEF1A0-0x0000000181DEF1C0
		public void SetTerrainKeyword(CommandBuffer cmd, bool hasTerrains); // 0x0000000181DEE1F0-0x0000000181DEE210
		public void Prepare(IRayTracingShader accumulationShader, ComputeShader normalizationShader, ComputeShader expansionHelpers, SamplingResources samplingResources, RTHandle emptyExposureTexture); // 0x0000000181DF43C0-0x0000000181DF44D0
		public void Accumulate(CommandBuffer cmd, uint sampleCountToTakePerTexel, uint currentSampleCountPerTexel, Matrix4x4 shaderLocalToWorld, Matrix4x4 shaderLocalToWorldNormals, int instanceGeometryIndex, int terrainIndex, Vector2Int instanceTexelSize, uint2 chunkOffset, World world, GraphicsBuffer traceScratchBuffer, GraphicsBuffer gBuffer, uint expandedSampleWidth, GraphicsBuffer expandedOutput, GraphicsBuffer compactedTexelIndices, GraphicsBuffer compactedGbufferLength, float pushOff, bool newChunkStarted); // 0x0000000181DF3B70-0x0000000181DF4190
		public void Normalize(CommandBuffer cmd, RenderTexture lightmapInOut); // 0x0000000181DF4190-0x0000000181DF43C0
	}
}
