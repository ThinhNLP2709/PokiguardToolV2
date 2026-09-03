/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PathTracing.Integration;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Sampling;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal class LightmapIntegratorContext : IDisposable // TypeDefIndex: 13629
	{
		// Fields
		internal UVFallbackBufferBuilder UVFallbackBufferBuilder; // 0x10
		internal LightmapDirectIntegrator LightmapDirectIntegrator; // 0x18
		internal LightmapDirectBRDFIntegrator LightmapDirectBRDFIntegrator; // 0x20
		internal LightmapIndirectIntegrator LightmapIndirectIntegrator; // 0x28
		internal LightmapAOIntegrator LightmapAOIntegrator; // 0x30
		internal LightmapValidityIntegrator LightmapValidityIntegrator; // 0x38
		internal LightmapOccupancyIntegrator LightmapOccupancyIntegrator; // 0x40
		internal LightmapShadowMaskIntegrator LightmapShadowMaskIntegrator; // 0x48
		internal GBufferDebug GBufferDebugShader; // 0x50
		internal IRayTracingShader GBufferShader; // 0x58
		internal ComputeShader ExpansionShaders; // 0x60
		internal SamplingResources SamplingResources; // 0x68
		private RTHandle _emptyExposureTexture; // 0x70
		internal GraphicsBuffer ClearDispatchBuffer; // 0x78
		internal GraphicsBuffer CopyDispatchBuffer; // 0x80
		internal GraphicsBuffer ReduceDispatchBuffer; // 0x88
		internal GraphicsBuffer CompactedGBufferLength; // 0x90
		internal int CompactGBufferKernel; // 0x98
		internal int PopulateAccumulationDispatchKernel; // 0x9C
		internal int PopulateClearDispatchKernel; // 0xA0
		internal int PopulateCopyDispatchKernel; // 0xA4
		internal int PopulateReduceDispatchKernel; // 0xA8
		internal int ClearBufferKernel; // 0xAC
		internal int ReductionKernel; // 0xB0
		internal int CopyToLightmapKernel; // 0xB4
	
		// Constructors
		public LightmapIntegratorContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Dispose(); // 0x0000000181E0F740-0x0000000181E0F8D0
		internal void Initialize(SamplingResources samplingResources, LightmapResourceLibrary lightmapResourceLib); // 0x0000000181E0F8D0-0x0000000181E10040
	}
}
