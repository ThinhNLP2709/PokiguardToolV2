/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[BurstCompile]
	internal struct CullingJob : IJobParallelFor // TypeDefIndex: 12840
	{
		// Fields
		public const uint k_MeshLodCrossfadeActive = 64; // Metadata: 0x006A75D8
		public const uint k_MeshLodCrossfadeSignBit = 128; // Metadata: 0x006A75D9
		public const uint k_MeshLodCrossfadeBits = 192; // Metadata: 0x006A75DB
		public const uint k_LODFadeOff = 255; // Metadata: 0x006A75DD
		public const uint k_LODFadeZeroPacked = 127; // Metadata: 0x006A75DF
		public const uint k_LODFadeIsSpeedTree = 256; // Metadata: 0x006A75E0
		private const uint k_InvalidCrossFadeAndLevel = 4294967295; // Metadata: 0x006A75E2
		private const uint k_VisibilityMaskNotVisible = 0; // Metadata: 0x006A75E3
		private const float k_SmallMeshTransitionWidth = 0.1f; // Metadata: 0x006A75E4
		[ReadOnly]
		public RenderWorld renderWorld; // 0x00
		[ReadOnly]
		public NativeParallelHashMap<EntityId, MeshInfo> meshMap; // 0x1E0
		[ReadOnly]
		public BinningConfig binningConfig; // 0x1F0
		[ReadOnly]
		public BatchCullingViewType viewType; // 0x1F8
		[ReadOnly]
		public float3 cameraPosition; // 0x1FC
		[ReadOnly]
		public float sqrMeshLodSelectionConstant; // 0x208
		[ReadOnly]
		public float sqrScreenRelativeMetric; // 0x20C
		[ReadOnly]
		public float minScreenRelativeHeight; // 0x210
		[ReadOnly]
		public float4 shadowMinScreenRelativeHeights; // 0x214
		[ReadOnly]
		public bool isOrtho; // 0x224
		[ReadOnly]
		public bool cullLightmappedShadowCasters; // 0x225
		[ReadOnly]
		public int maxLOD; // 0x228
		[ReadOnly]
		public uint cullingLayerMask; // 0x22C
		[ReadOnly]
		public ulong sceneCullingMask; // 0x230
		[ReadOnly]
		public float3x3 worldToLightSpaceRotation; // 0x238
		[ReadOnly]
		public bool animateCrossFades; // 0x25C
		[ReadOnly]
		public NativeArray<FrustumPlaneCuller.PlanePacket4> frustumPlanePackets; // 0x260
		[ReadOnly]
		public NativeArray<FrustumPlaneCuller.SplitInfo> frustumSplitInfos; // 0x270
		[ReadOnly]
		public NativeArray<Plane> lightFacingFrustumPlanes; // 0x280
		[ReadOnly]
		public NativeArray<ReceiverSphereCuller.SplitInfo> receiverSplitInfos; // 0x290
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeList<LODGroupCullingData> lodGroupCullingData; // 0x2A0
		[NativeDisableUnsafePtrRestriction]
		[ReadOnly]
		public IntPtr occlusionBuffer; // 0x2A8
		[NativeDisableParallelForRestriction]
		[WriteOnly]
		public NativeArray<byte> rendererVisibilityMasks; // 0x2B0
		[NativeDisableParallelForRestriction]
		[WriteOnly]
		public NativeArray<byte> rendererMeshLodSettings; // 0x2C0
		[NativeDisableParallelForRestriction]
		[WriteOnly]
		public NativeArray<byte> rendererCrossFadeValues; // 0x2D0
		public RenderWorld.PerCameraInstanceData perCameraInstanceData; // 0x2E0
		[NativeDisableContainerSafetyRestriction]
		[NativeDisableParallelForRestriction]
		public NativeArray<int> cullingDebugCounters; // 0x300
	
		// Nested types
		private enum CrossFadeType // TypeDefIndex: 12841
		{
			kDisabled = 0,
			kCrossFadeOut = 1,
			kCrossFadeIn = 2,
			kVisible = 3
		}
	
		// Methods
		private void IncrementCullingCounter(CullingDebugCounter counter); // 0x0000000181F1F7C0-0x0000000181F1F7F0
		private void IncrementLODLevelCounter(int lodLevel); // 0x0000000181F1F7F0-0x0000000181F1F830
		private static uint PackFloatToUint8(float percent); // 0x0000000181F1F830-0x0000000181F1F880
		private uint CalculateLODVisibility(GPUInstanceIndex lodGroupIndex, uint lodMask, bool smallMeshCulling, float cameraSqrDist, float worldSpaceSize); // 0x0000000181F1E2D0-0x0000000181F1E7B0
		private uint CalculateVisibilityMask(int instanceIndex, ShadowCastingMode shadowCastingMode, bool affectsLightmaps); // 0x0000000181F1E7B0-0x0000000181F1EB00
		private uint ComputeMeshLODLevel(int instanceIndex, [IsReadOnly] in MeshInfo mesh); // 0x0000000181F1EBD0-0x0000000181F1EFA0
		private uint ComputeMeshLODCrossfade(int instanceIndex, ref uint meshLodLevel); // 0x0000000181F1EB00-0x0000000181F1EBD0
		private void EnforcePreviousFrameMeshLOD(int instanceIndex, ref uint meshLodLevel); // 0x0000000181F1EFA0-0x0000000181F1EFE0
		public void Execute(int instanceIndex); // 0x0000000181F1EFE0-0x0000000181F1F7C0
	}
}
