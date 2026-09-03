/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine.PathTracing.Core;
using UnityEngine.PathTracing.Integration;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal static class BakeLightmapDriver // TypeDefIndex: 13631
	{
		// Fields
		private static readonly ProfilerMarker k_AccumulateLightmapInstance; // 0x00
	
		// Nested types
		public class LightmapBakeState // TypeDefIndex: 13632
		{
			// Fields
			public uint SampleIndex; // 0x10
			public ulong TexelIndex; // 0x18
	
			// Constructors
			public LightmapBakeState(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Init(); // 0x0000000181E0A900-0x0000000181E0A910
			public void Tick(uint passSampleCount, uint totalSampleCount, ulong chunkTexelCount, ulong totalTexelCount, out bool instanceIsDone, out bool chunkIsDone); // 0x0000000181E0A910-0x0000000181E0A950
		}
	
		public struct IntegrationSettings // TypeDefIndex: 13633
		{
			// Fields
			public RayTracingBackend Backend; // 0x00
			public uint MaxDispatchesPerFlush; // 0x04
			public bool DebugDispatches; // 0x08
			public static readonly IntegrationSettings Default; // 0x00
	
			// Constructors
			static IntegrationSettings(); // 0x0000000181E09770-0x0000000181E097D0
		}
	
		public class LightmapBakeSettings // TypeDefIndex: 13634
		{
			// Fields
			public uint AOSampleCount; // 0x10
			public uint DirectSampleCount; // 0x14
			public uint DirectBRDFSampleCount; // 0x18
			public uint IndirectSampleCount; // 0x1C
			public uint ValiditySampleCount; // 0x20
			public AntiAliasingType AOAntiAliasingType; // 0x24
			public AntiAliasingType DirectAntiAliasingType; // 0x28
			public AntiAliasingType IndirectAntiAliasingType; // 0x2C
			public AntiAliasingType ValidityAntiAliasingType; // 0x30
			public uint BounceCount; // 0x34
			public float AOMaxDistance; // 0x38
			public float PushOff; // 0x3C
			public ulong ExpandedBufferSize; // 0x40
			public LightSamplingMode DirectLightSamplingMode; // 0x48
			public uint DirectRISCandidateCount; // 0x4C
			public LightSamplingMode IndirectLightSamplingMode; // 0x50
			public uint IndirectRISCandidateCount; // 0x54
			public EmissiveSamplingMode DirectEmissiveSamplingMode; // 0x58
			public EmissiveSamplingMode IndirectEmissiveSamplingMode; // 0x5C
	
			// Constructors
			public LightmapBakeSettings(); // 0x0000000181E0A8B0-0x0000000181E0A900
	
			// Methods
			public uint GetSampleCount(IntegratedOutputType integratedOutputType); // 0x0000000181E0A850-0x0000000181E0A8B0
			public AntiAliasingType GetAntiAliasingType(IntegratedOutputType integratedOutputType); // 0x0000000181E0A7F0-0x0000000181E0A850
		}
	
		// Constructors
		static BakeLightmapDriver(); // 0x0000000181E05B40-0x0000000181E05BB0
	
		// Methods
		private static bool IsNewChunkStarted(uint maxChunkSize, uint instanceWidth, uint instanceHeight, uint currentChunkTexelOffset, uint currentSampleIndex, uint maxSamplesPerTexel, out uint chunkSize, out uint expandedSampleWidth, out uint passSampleCount, out uint2 chunkOffset); // 0x0000000181E05A80-0x0000000181E05B40
		internal static uint AccumulateLightmapInstance(LightmapBakeState bakeState, BakeInstance instance, LightmapBakeSettings lightmapBakeSettings, IntegratedOutputType integratedOutputType, LightmappingContext lightmappingContext, UVAccelerationStructure uvAS, UVFallbackBuffer uvFallbackBuffer, bool doDirectionality, out uint chunkSize, out bool instanceIsDone); // 0x0000000181E036B0-0x0000000181E05A80
	}
}
