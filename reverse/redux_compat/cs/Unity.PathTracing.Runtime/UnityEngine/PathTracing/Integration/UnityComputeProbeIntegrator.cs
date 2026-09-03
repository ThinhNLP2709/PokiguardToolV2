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

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Integration
{
	internal class UnityComputeProbeIntegrator : IProbeIntegrator // TypeDefIndex: 13562
	{
		// Fields
		private readonly ProbeIntegrator _probeIntegrator; // 0x10
		private UnityComputeWorld _world; // 0x18
		private uint _bounceCount; // 0x20
		private LightSamplingMode _directLightSamplingMode; // 0x24
		private uint _directRISCandidateCount; // 0x28
		private LightSamplingMode _indirectLightSamplingMode; // 0x2C
		private EmissiveSamplingMode _indirectEmissiveSamplingMode; // 0x30
		private uint _indirectRISCandidateCount; // 0x34
		private uint _basePositionsOffset; // 0x38
		private bool _hasTerrains; // 0x3C
		private ComputeShader _probeOcclusionLightIndexMappingShader; // 0x40
		private int _probeOcclusionLightIndexMappingKernel; // 0x48
		private SamplingResources _samplingResources; // 0x50
		private ProbeIntegratorResources _integrationResources; // 0x58
	
		// Nested types
		private static class ShaderProperties // TypeDefIndex: 13563
		{
			// Fields
			public static readonly int MappingTable; // 0x00
			public static readonly int PerProbeLightIndicesInput; // 0x04
			public static readonly int PerProbeLightIndicesOutput; // 0x08
			public static readonly int PerProbeLightIndicesInputOffset; // 0x0C
			public static readonly int MaxLightsPerProbe; // 0x10
			public static readonly int ProbeCount; // 0x14
	
			// Constructors
			static ShaderProperties(); // 0x0000000181DFCC80-0x0000000181DFCDB0
		}
	
		// Constructors
		public UnityComputeProbeIntegrator(SamplingResources samplingResources, ProbeIntegratorResources integrationResources, ComputeShader probeOcclusionLightIndexMappingShader); // 0x0000000181E02380-0x0000000181E02490
	
		// Methods
		public void Dispose(); // 0x0000000181E00A10-0x0000000181E00A70
		public IProbeIntegrator.Result IntegrateDirectRadiance(IDeviceContext context, int positionOffset, int positionCount, int sampleCount, bool ignoreEnvironment, BufferSlice<SphericalHarmonicsL2> radianceEstimateOut); // 0x0000000181E00A70-0x0000000181E00EF0
		public IProbeIntegrator.Result IntegrateIndirectRadiance(IDeviceContext context, int positionOffset, int positionCount, int sampleCount, bool ignoreEnvironment, BufferSlice<SphericalHarmonicsL2> radianceEstimateOut); // 0x0000000181E00EF0-0x0000000181E012E0
		public IProbeIntegrator.Result IntegrateValidity(IDeviceContext context, int positionOffset, int positionCount, int sampleCount, BufferSlice<float> validityEstimateOut); // 0x0000000181E01C70-0x0000000181E02020
		public IProbeIntegrator.Result IntegrateOcclusion(IDeviceContext context, int positionOffset, int positionCount, int sampleCount, int maxLightsPerProbe, BufferSlice<int> perProbeLightIndices, BufferSlice<float> probeOcclusionEstimateOut); // 0x0000000181E012E0-0x0000000181E01C70
		public void SetLightSamplingSettings(LightSamplingMode directLightSamplingMode, uint directRISCandidateCount, LightSamplingMode indirectLightSamplingMode, uint indirectRISCandidateCount, EmissiveSamplingMode indirectEmissiveSamplingMode); // 0x0000000181E02330-0x0000000181E02350
		public void Prepare(IDeviceContext context, IWorld world, BufferSlice<Vector3> positions, float pushoff, int bounceCount); // 0x0000000181E02020-0x0000000181E02330
		public void SetProgressReporter(BakeProgressState progressState); // 0x0000000181E02350-0x0000000181E02380
	}
}
