/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Integration
{
	internal static class LightmapIntegratorShaderIDs // TypeDefIndex: 13543
	{
		// Fields
		public static readonly ProfilerMarker k_AccumulationExpanded; // 0x00
		public static readonly ProfilerMarker k_GBufferDebug; // 0x08
		public static readonly int LightmapInOut; // 0x10
		public static readonly int DirectionalInOut; // 0x14
		public static readonly int AdaptiveInOut; // 0x18
		public static readonly int AdaptiveSampling; // 0x1C
		public static readonly int AdaptiveStopSamples; // 0x20
		public static readonly int AdaptiveCheckIfFullyConverged; // 0x24
		public static readonly int AdaptiveThreshold; // 0x28
		public static readonly int AccumulateDirectional; // 0x2C
		public static readonly int SampleCountInOut; // 0x30
		public static readonly int SampleCountIn; // 0x34
		public static readonly int ShaderLocalToWorld; // 0x38
		public static readonly int ShaderLocalToWorldNormals; // 0x3C
		public static readonly int InstanceGeometryIndex; // 0x40
		public static readonly int TerrainIndex; // 0x44
		public static readonly int GISampleCount; // 0x48
		public static readonly int AOMaxDistance; // 0x4C
		public static readonly int InputSampleCountInW; // 0x50
		public static readonly int Normals; // 0x54
		public static readonly int TextureWidth; // 0x58
		public static readonly int TextureHeight; // 0x5C
		public static readonly int ReceiveShadows; // 0x60
		public static readonly int PushOff; // 0x64
		public static readonly int IndirectDispatchDimensions; // 0x68
		public static readonly int IndirectDispatchoriginalDimensions; // 0x6C
		public static readonly int InputBufferSelector; // 0x70
		public static readonly int InputBufferLength; // 0x74
		public static readonly int InputBuffer0; // 0x78
		public static readonly int InputBuffer1; // 0x7C
		public static readonly int SelectionOutput; // 0x80
		public static readonly int GBuffer; // 0x84
		public static readonly int SampleOffset; // 0x88
		public static readonly int StochasticAntialiasing; // 0x8C
		public static readonly int SuperSampleWidth; // 0x90
		public static readonly int Float3Buffer; // 0x94
		public static readonly int DestinationTexture; // 0x98
		public static readonly int SourceTexture; // 0x9C
		public static readonly int SourceX; // 0xA0
		public static readonly int SourceY; // 0xA4
		public static readonly int SourceWidth; // 0xA8
		public static readonly int SourceHeight; // 0xAC
		public static readonly int DestinationX; // 0xB0
		public static readonly int DestinationY; // 0xB4
		public static readonly int TextureInOut; // 0xB8
		public static readonly int ExpandedOutput; // 0xBC
		public static readonly int ExpandedOutputDirectional; // 0xC0
		public static readonly int ExpandedSampleCountInW; // 0xC4
		public static readonly int ExpandedTexelSampleWidth; // 0xC8
		public static readonly int MaxLocalSampleCount; // 0xCC
		public static readonly int LightIndexInCell; // 0xD0
		public static readonly int SourceBuffer; // 0xD4
		public static readonly int SourceLength; // 0xD8
		public static readonly int SourceStride; // 0xDC
		public static readonly int GBufferLength; // 0xE0
		public static readonly int CompactedGBuffer; // 0xE4
		public static readonly int InstanceWidth; // 0xE8
		public static readonly int ChunkOffsetX; // 0xEC
		public static readonly int ChunkOffsetY; // 0xF0
		public static readonly int LightmapSamplesExpanded; // 0xF4
	
		// Constructors
		static LightmapIntegratorShaderIDs(); // 0x0000000181DF2260-0x0000000181DF2D30
	}
}
