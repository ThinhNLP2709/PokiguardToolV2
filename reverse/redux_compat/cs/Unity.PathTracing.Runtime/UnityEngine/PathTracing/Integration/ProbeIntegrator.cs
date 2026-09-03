/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.PathTracing.Core;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Sampling;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Integration
{
	internal class ProbeIntegrator : IDisposable // TypeDefIndex: 13553
	{
		// Fields
		private GraphicsBuffer _positionsBuffer; // 0x10
		private SamplingResources _samplingResources; // 0x18
		private ProbeIntegratorResources _resourceLibrary; // 0x20
		private GraphicsBuffer _traceScratchBuffer; // 0x28
		private RTHandle _emptyExposureTexture; // 0x30
		private BakeProgressState _progressState; // 0x38
		private const uint maxTotalSamplesPerDispatch = 1048576; // Metadata: 0x006A7D2C
	
		// Nested types
		private static class ShaderProperties // TypeDefIndex: 13554
		{
			// Fields
			public static readonly int Positions; // 0x00
			public static readonly int ExpansionOffset; // 0x04
			public static readonly int PositionsOffset; // 0x08
			public static readonly int RadianceShl2; // 0x0C
			public static readonly int RadianceShl2Offset; // 0x10
			public static readonly int Validity; // 0x14
			public static readonly int ValidityOffset; // 0x18
			public static readonly int SampleOffset; // 0x1C
			public static readonly int SampleCount; // 0x20
			public static readonly int Occlusion; // 0x24
			public static readonly int OcclusionOffset; // 0x28
			public static readonly int PerProbeLightIndices; // 0x2C
			public static readonly int PerProbeLightIndicesOffset; // 0x30
			public static readonly int MaxLightsPerProbe; // 0x34
			public static readonly int LightIndexInCell; // 0x38
	
			// Constructors
			static ShaderProperties(); // 0x0000000181DFC9D0-0x0000000181DFCC80
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass14_0 // TypeDefIndex: 13555
		{
			// Fields
			public ulong workStepsForThisRequest; // 0x10
			public ProbeIntegrator __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass14_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _DispatchProbeKernel_b__0(AsyncGPUReadbackRequest _); // 0x0000000181DFEE70-0x0000000181DFEEA0
		}
	
		// Constructors
		public ProbeIntegrator(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void Prepare(GraphicsBuffer positionsBuffer, ProbeIntegratorResources integrationResources, SamplingResources samplingResources); // 0x0000000181DFA920-0x0000000181DFAAC0
		public static void GetScratchBufferSizesInDwords(uint outputStride, uint positionCount, uint sampleCount, out uint expansionBufferSize, out uint reductionBufferSize); // 0x0000000181DFA830-0x0000000181DFA8F0
		public static void GetRadianceScratchBufferSizesInDwords(uint positionCount, uint sampleCount, out uint expansionBufferSize, out uint reductionBufferSize); // 0x0000000181DFA800-0x0000000181DFA830
		public static void GetValidityScratchBufferSizesInDwords(uint positionCount, uint sampleCount, out uint expansionBufferSize, out uint reductionBufferSize); // 0x0000000181DFA8F0-0x0000000181DFA920
		public static void GetOcclusionScratchBufferSizesInDwords(uint maxLightsPerProbe, uint positionCount, uint sampleCount, out uint expansionBufferSize, out uint reductionBufferSize); // 0x0000000181DFA7F0-0x0000000181DFA800
		private void DispatchRadianceEstimationKernel(CommandBuffer cmd, IRayTracingShader shader, World world, uint positionOffset, uint positionCount, uint bounceCount, uint sampleOffset, uint sampleCount, LightSamplingMode lightSamplingMode, uint risCandidateCount, uint maxLightsInAnyCell, float environmentIntensityMultiplier, GraphicsBuffer radianceShl2, uint radianceOffset, GraphicsBuffer expansionBuffer, GraphicsBuffer reductionBuffer); // 0x0000000181DF9DD0-0x0000000181DF9F80
		private void DispatchProbeKernel(CommandBuffer cmd, IRayTracingShader shader, uint positionOffset, uint positionCount, uint sampleOffset, uint sampleCount, uint outputStride, int outputBufferPropertyID, GraphicsBuffer outputBuffer, uint outputOffset, GraphicsBuffer expansionBuffer, GraphicsBuffer reductionBuffer, uint bounceCount, bool roundRobin, uint maxLightsInAnyCell); // 0x0000000181DF98C0-0x0000000181DF9DD0
		internal static ulong CalculateWorkSteps(ulong probesCount, ulong sampleCount, ulong bounceCount, ulong multiplier = 1 /* Metadata: 0x006A7D24 */); // 0x0000000181DF98A0-0x0000000181DF98C0
		internal static ulong CalculateWorkStepsIndirectRadiance(ulong probesCount, ulong sampleCount, ulong bounceCount); // 0x0000000181DF9870-0x0000000181DF9890
		internal static ulong CalculateWorkStepsDirectRadiance(ulong probesCount, ulong sampleCount); // 0x0000000181DF9860-0x0000000181DF9870
		internal static ulong CalculateWorkStepsOcclusion(ulong probesCount, ulong sampleCount); // 0x0000000181DF9890-0x0000000181DF98A0
		internal static ulong CalculateWorkStepsValidity(ulong probesCount, ulong sampleCount); // 0x0000000181DF9890-0x0000000181DF98A0
		internal void EstimateIndirectRadianceShl2(CommandBuffer cmd, World world, uint positionOffset, uint positionCount, uint bounceCount, uint sampleOffset, uint sampleCount, LightSamplingMode lightSamplingMode, uint risCandidateCount, uint maxLightsInAnyCell, EmissiveSamplingMode emissiveSamplingMode, bool ignoreEnvironment, GraphicsBuffer radianceShl2, uint radianceOffset, GraphicsBuffer expansionBuffer, GraphicsBuffer reductionBuffer, bool hasTerrains); // 0x0000000181DFA240-0x0000000181DFA400
		internal void EstimateDirectRadianceShl2(CommandBuffer cmd, World world, uint positionOffset, uint positionCount, uint sampleOffset, uint sampleCount, LightSamplingMode lightSamplingMode, uint risCandidateCount, uint maxLightsInAnyCell, bool ignoreEnvironment, GraphicsBuffer radianceShl2, uint radianceOffset, GraphicsBuffer expansionBuffer, GraphicsBuffer reductionBuffer, bool hasTerrains); // 0x0000000181DF9FE0-0x0000000181DFA240
		internal void EstimateValidity(CommandBuffer cmd, World world, uint positionOffset, uint positionCount, uint sampleOffset, uint sampleCount, GraphicsBuffer validity, uint validityOffset, GraphicsBuffer expansionBuffer, GraphicsBuffer reductionBuffer, bool hasTerrains); // 0x0000000181DFA640-0x0000000181DFA7F0
		internal void EstimateLightOcclusion(CommandBuffer cmd, World world, uint positionOffset, uint positionCount, uint sampleOffset, uint sampleCount, uint maxLightsPerProbe, GraphicsBuffer perProbeLightIndices, uint perProbeLightIndicesOffset, GraphicsBuffer occlusion, uint occlusionOffset, GraphicsBuffer expansionBuffer, GraphicsBuffer reductionBuffer, bool hasTerrains); // 0x0000000181DFA400-0x0000000181DFA640
		private void ReleaseExistingAllocations(); // 0x0000000181DF9F80-0x0000000181DF9FE0
		public void Dispose(); // 0x0000000181DF9F80-0x0000000181DF9FE0
		public void SetProgressReporter(BakeProgressState progressState); // 0x000000018033E850-0x000000018033E860
	}
}
