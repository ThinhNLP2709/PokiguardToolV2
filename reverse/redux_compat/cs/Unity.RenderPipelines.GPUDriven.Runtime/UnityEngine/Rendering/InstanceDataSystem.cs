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
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal class InstanceDataSystem : IDisposable // TypeDefIndex: 12787
	{
		// Fields
		internal const int k_STMaxWindParamsCount = 16; // Metadata: 0x006A75AC
		private NativeReference<GPUArchetypeManager> m_ArchetypeManager; // 0x10
		private DefaultGPUComponents m_DefaultGPUComponents; // 0x20
		private GPUInstanceDataBuffer m_InstanceDataBuffer; // 0x88
		private InstanceAllocators m_InstanceAllocators; // 0x90
		private RenderWorld m_RenderWorld; // 0xE8
		private NativeParallelHashMap<EntityId, InstanceHandle> m_RendererToInstanceMap; // 0x2C8
		private GPUCapacityResizingPolicy m_GPUResizingPolicy; // 0x2D8
		private CommandBuffer m_CmdBuffer; // 0x2E0
		private ComputeShader m_TransformUpdateCS; // 0x2E8
		private ComputeShader m_WindDataUpdateCS; // 0x2F0
		private int m_TransformInitKernel; // 0x2F8
		private int m_TransformUpdateKernel; // 0x2FC
		private int m_MotionUpdateKernel; // 0x300
		private int m_ProbeUpdateKernel; // 0x304
		private int m_LODUpdateKernel; // 0x308
		private int m_WindDataCopyHistoryKernel; // 0x30C
		private ComputeBuffer m_UpdateIndexQueueBuffer; // 0x310
		private ComputeBuffer m_ProbeUpdateDataQueueBuffer; // 0x318
		private ComputeBuffer m_ProbeOcclusionUpdateDataQueueBuffer; // 0x320
		private ComputeBuffer m_TransformUpdateDataQueueBuffer; // 0x328
		private ComputeBuffer m_BoundingSpheresUpdateDataQueueBuffer; // 0x330
		private bool m_EnableBoundingSpheres; // 0x338
		private readonly int[] m_ScratchWindParamAddressArray; // 0x340
		private static readonly ProfilerMarker k_InterpolateProbesAndUpdateTetrahedronCache; // 0x00
		internal static readonly ProfilerMarker k_DispatchProbeUpdateCommand; // 0x08
		internal static readonly ProfilerMarker k_DispatchMotionUpdateCommand; // 0x10
		internal static readonly ProfilerMarker k_DispatchTransformUpdateCommand; // 0x18
		private static readonly ProfilerMarker k_DispatchWindDataCopyHistory; // 0x20
		private static readonly ProfilerMarker k_ComputeBufferSetData; // 0x28
		private static readonly ProfilerMarker k_AllocateBuffers; // 0x30
		private static readonly ProfilerMarker k_UpdateTransformsAndProbes; // 0x38
		private static readonly ProfilerMarker k_UpdateInstanceData; // 0x40
		private static readonly ProfilerMarker k_QueryRendererInstances; // 0x48
		private static readonly ProfilerMarker k_DeepValidateTotalTreeCount; // 0x50
		[CompilerGenerated]
		private Action onGPUBufferLayoutChanged; // 0x348
	
		// Properties
		public NativeReference<GPUArchetypeManager> archetypeManager { get; } // 0x00000001802E65B0-0x00000001802E65C0 
		public ref DefaultGPUComponents defaultGPUComponents { get; } // 0x0000000181F17A20-0x0000000181F17A30 
		public bool hasBoundingSpheres { get; } // 0x0000000181F17A90-0x0000000181F17AA0 
		public int totalTreeCount { get; } // 0x0000000181F17B20-0x0000000181F17B70 
		public GPUInstanceDataBuffer gpuBuffer { get; } // 0x000000018038B8A0-0x000000018038B8B0 
		public GraphicsBufferHandle gpuBufferHandle { get; } // 0x0000000181F17A30-0x0000000181F17A70 
		public int gpuBufferLayoutVersion { get; } // 0x0000000181F17A70-0x0000000181F17A90 
		public ref RenderWorld renderWorld { get; } // 0x0000000181F17B10-0x0000000181F17B20 
		public NativeArray<InstanceHandle> indexToHandle { get; } // 0x0000000181F17AA0-0x0000000181F17B10 
		public NativeArray<MetadataValue> componentsMetadata { get; } // 0x0000000181F179C0-0x0000000181F17A20 
	
		// Events
		public event Action onGPUBufferLayoutChanged {
			add; // 0x0000000181F17910-0x0000000181F179C0
			remove; // 0x0000000181F17B70-0x0000000181F17C20
		}
	
		// Nested types
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct QueryRendererInstancesJob : IJobParallelFor // TypeDefIndex: 12788
		{
			// Fields
			[ReadOnly]
			public NativeArray<JaggedJobRange> jobRanges; // 0x00
			[ReadOnly]
			public NativeParallelHashMap<EntityId, InstanceHandle> rendererToInstanceMap; // 0x10
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			[ReadOnly]
			public JaggedSpan<EntityId> jaggedRenderers; // 0x20
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			[WriteOnly]
			public NativeArray<InstanceHandle> instances; // 0x40
			[NativeDisableUnsafePtrRestriction]
			public UnsafeAtomicCounter32 atomicNonFoundInstancesCount; // 0x50
	
			// Methods
			public void Execute(int jobIndex); // 0x0000000181F194A0-0x0000000181F19600
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct QuerySortedMeshInstancesJob : IJobParallelForBatch // TypeDefIndex: 12789
		{
			// Fields
			public const int MaxBatchSize = 64; // Metadata: 0x006A75AD
			[ReadOnly]
			public RenderWorld renderWorld; // 0x00
			[ReadOnly]
			public NativeArray<EntityId> sortedMeshes; // 0x1E0
			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeList<InstanceHandle> instances; // 0x1F0
	
			// Methods
			public void Execute(int startIndex, int count); // 0x0000000181F19600-0x0000000181F198C0
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct CalculateInterpolatedLightAndOcclusionProbesBatchJob : IJobParallelFor // TypeDefIndex: 12790
		{
			// Fields
			public const int k_CalculatedProbesPerBatch = 8; // Metadata: 0x006A75AF
			[ReadOnly]
			public int probesCount; // 0x00
			[ReadOnly]
			public LightProbesQuery lightProbesQuery; // 0x08
			[NativeDisableParallelForRestriction]
			[ReadOnly]
			public NativeArray<Vector3> queryPostitions; // 0x18
			[NativeDisableParallelForRestriction]
			public NativeArray<int> compactTetrahedronCache; // 0x28
			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<SphericalHarmonicsL2> probesSphericalHarmonics; // 0x38
			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<Vector4> probesOcclusion; // 0x48
	
			// Methods
			public void Execute(int index); // 0x0000000181F04C40-0x0000000181F04D60
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct ScatterTetrahedronCacheIndicesJob : IJobParallelFor // TypeDefIndex: 12791
		{
			// Fields
			[ReadOnly]
			public NativeArray<InstanceHandle> probeInstances; // 0x00
			[ReadOnly]
			public NativeArray<int> compactTetrahedronCache; // 0x10
			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			[NoAlias]
			public RenderWorld renderWorld; // 0x20
	
			// Methods
			public void Execute(int index); // 0x0000000181F1A6B0-0x0000000181F1A750
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct TransformUpdateJob : IJobParallelFor // TypeDefIndex: 12792
		{
			// Fields
			public const int MaxBatchSize = 64; // Metadata: 0x006A75B0
			[ReadOnly]
			public NativeArray<JaggedJobRange> jobRanges; // 0x00
			[ReadOnly]
			public NativeArray<InstanceHandle> instances; // 0x10
			[ReadOnly]
			public JaggedSpan<float4x4> jaggedLocalToWorldMatrices; // 0x20
			[ReadOnly]
			public JaggedSpan<float4x4> jaggedPrevLocalToWorldMatrices; // 0x40
			[ReadOnly]
			public bool initialize; // 0x60
			[ReadOnly]
			public bool enableBoundingSpheres; // 0x61
			[NativeDisableUnsafePtrRestriction]
			public UnsafeAtomicCounter32 atomicTransformQueueCount; // 0x68
			[NativeDisableParallelForRestriction]
			public RenderWorld renderWorld; // 0x70
			[NativeDisableParallelForRestriction]
			public NativeArray<InstanceHandle> transformUpdateInstanceQueue; // 0x250
			[NativeDisableParallelForRestriction]
			public NativeArray<TransformUpdatePacket> transformUpdateDataQueue; // 0x260
			[NativeDisableParallelForRestriction]
			public NativeArray<float4> boundingSpheresDataQueue; // 0x270
	
			// Methods
			public void Execute(int jobIndex); // 0x0000000181F1A750-0x0000000181F1B0D0
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct ProbesUpdateJob : IJobParallelForBatch // TypeDefIndex: 12793
		{
			// Fields
			public const int MaxBatchSize = 64; // Metadata: 0x006A75B2
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			[ReadOnly]
			public NativeArray<InstanceHandle> instances; // 0x00
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			[ReadOnly]
			public RenderWorld renderWorld; // 0x10
			[NativeDisableUnsafePtrRestriction]
			public UnsafeAtomicCounter32 atomicProbesQueueCount; // 0x1F0
			[NativeDisableParallelForRestriction]
			public NativeArray<InstanceHandle> probeInstanceQueue; // 0x1F8
			[NativeDisableParallelForRestriction]
			public NativeArray<int> compactTetrahedronCache; // 0x208
			[NativeDisableParallelForRestriction]
			public NativeArray<Vector3> probeQueryPosition; // 0x218
	
			// Methods
			public void Execute(int startIndex, int count); // 0x0000000181F29E80-0x0000000181F2A390
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct MotionUpdateJob : IJobParallelFor // TypeDefIndex: 12794
		{
			// Fields
			[ReadOnly]
			public int queueWriteBase; // 0x00
			[NativeDisableParallelForRestriction]
			public RenderWorld renderWorld; // 0x08
			[NativeDisableUnsafePtrRestriction]
			public UnsafeAtomicCounter32 atomicUpdateQueueCount; // 0x1E8
			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<InstanceHandle> transformUpdateInstanceQueue; // 0x1F0
	
			// Methods
			public void Execute(int chunk_index); // 0x0000000181F28E50-0x0000000181F29270
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct UpdateRendererInstancesJob : IJobParallelFor // TypeDefIndex: 12795
		{
			// Fields
			[ReadOnly]
			public NativeArray<JaggedJobRange> jobRanges; // 0x00
			[ReadOnly]
			public MeshRendererUpdateBatch updateBatch; // 0x10
			[ReadOnly]
			public NativeArray<InstanceHandle> instances; // 0x260
			[ReadOnly]
			public NativeParallelHashMap<EntityId, GPUInstanceIndex> lodGroupDataMap; // 0x270
			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public RenderWorld renderWorld; // 0x280
	
			// Methods
			public void Execute(int jobIndex); // 0x0000000181F2ED80-0x0000000181F30840
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct GetVisibleNonProcessedTreeInstancesJob : IJobParallelForBatch // TypeDefIndex: 12796
		{
			// Fields
			public const int MaxBatchSize = 64; // Metadata: 0x006A75B4
			[ReadOnly]
			public RenderWorld renderWorld; // 0x00
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			[ReadOnly]
			public ParallelBitArray compactedVisibilityMasks; // 0x1E0
			[ReadOnly]
			public bool becomeVisible; // 0x200
			[NativeDisableParallelForRestriction]
			public ParallelBitArray processedBits; // 0x208
			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<EntityId> renderers; // 0x228
			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<InstanceHandle> instances; // 0x238
			[NativeDisableUnsafePtrRestriction]
			public UnsafeAtomicCounter32 atomicTreeInstancesCount; // 0x248
	
			// Methods
			public void Execute(int startIndex, int count); // 0x0000000181F21DC0-0x0000000181F222B0
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct UpdateCompactedInstanceVisibilityJob : IJobParallelForBatch // TypeDefIndex: 12797
		{
			// Fields
			public const int MaxBatchSize = 64; // Metadata: 0x006A75B6
			[ReadOnly]
			public ParallelBitArray compactedVisibilityMasks; // 0x00
			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			[NoAlias]
			public RenderWorld renderWorld; // 0x20
	
			// Methods
			public void Execute(int startIndex, int count); // 0x0000000181F2E1F0-0x0000000181F2E3B0
		}
	
		private static class InstanceTransformUpdateIDs // TypeDefIndex: 12798
		{
			// Fields
			public static readonly int _TransformUpdateQueueCount; // 0x00
			public static readonly int _TransformUpdateOutputL2WVec4Offset; // 0x04
			public static readonly int _TransformUpdateOutputW2LVec4Offset; // 0x08
			public static readonly int _TransformUpdateOutputPrevL2WVec4Offset; // 0x0C
			public static readonly int _TransformUpdateOutputPrevW2LVec4Offset; // 0x10
			public static readonly int _BoundingSphereOutputVec4Offset; // 0x14
			public static readonly int _TransformUpdateDataQueue; // 0x18
			public static readonly int _TransformUpdateIndexQueue; // 0x1C
			public static readonly int _BoundingSphereDataQueue; // 0x20
			public static readonly int _OutputTransformBuffer; // 0x24
			public static readonly int _ProbeUpdateQueueCount; // 0x28
			public static readonly int _SHUpdateVec4Offset; // 0x2C
			public static readonly int _ProbeUpdateDataQueue; // 0x30
			public static readonly int _ProbeOcclusionUpdateDataQueue; // 0x34
			public static readonly int _ProbeUpdateIndexQueue; // 0x38
			public static readonly int _OutputProbeBuffer; // 0x3C
	
			// Constructors
			static InstanceTransformUpdateIDs(); // 0x0000000181F27FB0-0x0000000181F28290
		}
	
		private static class InstanceWindDataUpdateIDs // TypeDefIndex: 12799
		{
			// Fields
			public static readonly int _WindDataQueueCount; // 0x00
			public static readonly int _WindDataUpdateIndexQueue; // 0x04
			public static readonly int _WindDataBuffer; // 0x08
			public static readonly int _WindParamAddressArray; // 0x0C
			public static readonly int _WindHistoryParamAddressArray; // 0x10
	
			// Constructors
			static InstanceWindDataUpdateIDs(); // 0x0000000181F28290-0x0000000181F28390
		}
	
		public enum GPUCapacityResizingPolicy // TypeDefIndex: 12800
		{
			DoubleOnGrow = 0,
			DoubleOnGrow_HalveOnQuarterShrink = 1
		}
	
		// Constructors
		public InstanceDataSystem(int instancesCPUCapacity, bool enableBoundingSpheres, GPUResidentDrawerResources resources, GPUCapacityResizingPolicy gpuResizingPolicy = GPUCapacityResizingPolicy.DoubleOnGrow_HalveOnQuarterShrink /* Metadata: 0x006A75AB */); // 0x0000000181F17180-0x0000000181F17910
		static InstanceDataSystem(); // 0x0000000181F16E70-0x0000000181F17180
	
		// Methods
		private static float3 AABBRotateExtents(float3 extents, float3 m0, float3 m1, float3 m2); // 0x0000000181F10A60-0x0000000181F10BC0
		public static AABB AABBTransform(float4x4 transform, AABB localBounds); // 0x0000000181F10BC0-0x0000000181F10E60
		private static int AtomicAddLengthNoResize<T>([IsReadOnly] in NativeList<T> list, int count)
			where T : struct;
		public void Dispose(); // 0x0000000181F12FB0-0x0000000181F131F0
		private void EnsureIndexQueueBufferCapacity(int capacity); // 0x0000000181F13760-0x0000000181F13820
		private void EnsureProbeBuffersCapacity(int capacity); // 0x0000000181F13820-0x0000000181F13940
		private void EnsureTransformBuffersCapacity(int capacity); // 0x0000000181F13940-0x0000000181F13A70
		private JobHandle ScheduleInterpolateProbesAndUpdateTetrahedronCache(int queueCount, NativeArray<InstanceHandle> probeUpdateInstanceQueue, NativeArray<int> compactTetrahedronCache, NativeArray<Vector3> probeQueryPosition, NativeArray<SphericalHarmonicsL2> probeUpdateDataQueue, NativeArray<Vector4> probeOcclusionUpdateDataQueue); // 0x0000000181F14D10-0x0000000181F15030
		private void InterpolateProbesAndUpdateTetrahedronCache(int queueCount, NativeArray<InstanceHandle> probeUpdateInstanceQueue, NativeArray<int> compactTetrahedronCache, NativeArray<Vector3> probeQueryPosition, NativeArray<SphericalHarmonicsL2> probeUpdateDataQueue, NativeArray<Vector4> probeOcclusionUpdateDataQueue); // 0x0000000181F142B0-0x0000000181F14730
		private void DispatchProbeUpdateCommand(int queueCount, NativeArray<InstanceHandle> probeInstanceQueue, NativeArray<SphericalHarmonicsL2> probeUpdateDataQueue, NativeArray<Vector4> probeOcclusionUpdateDataQueue); // 0x0000000181F11C40-0x0000000181F122C0
		private void DispatchMotionUpdateCommand(int motionQueueCount, NativeArray<InstanceHandle> transformInstanceQueue); // 0x0000000181F11630-0x0000000181F11C40
		private void DispatchTransformUpdateCommand(bool initialize, int transformQueueCount, NativeArray<InstanceHandle> transformInstanceQueue, NativeArray<TransformUpdatePacket> updateDataQueue, NativeArray<float4> boundingSphereUpdateDataQueue); // 0x0000000181F122C0-0x0000000181F12AC0
		private void DispatchWindDataCopyHistoryCommand(NativeArray<GPUInstanceIndex> gpuIndices); // 0x0000000181F12AC0-0x0000000181F12FB0
		private void UpdateInstanceMotionsDataInternal(); // 0x0000000181F15A10-0x0000000181F15C70
		private void UpdateInstanceTransformsData(bool initialize, NativeArray<InstanceHandle> instances, JaggedSpan<float4x4> jaggedLocalToWorldMatrices, JaggedSpan<float4x4> jaggedPrevLocalToWorldMatrices, bool anyInstanceUseBlendProbes); // 0x0000000181F16300-0x0000000181F16AB0
		private void UpdateInstanceProbesData(NativeArray<InstanceHandle> instances); // 0x0000000181F15F30-0x0000000181F16300
		public int TrimGPUAllocatorLength(GPUArchetypeHandle archetype); // 0x0000000181F155A0-0x0000000181F15610
		public int GetGPUArchetypeAliveInstancesCount(GPUArchetypeHandle archetype); // 0x0000000181F13AC0-0x0000000181F13B30
		public void EnsureGPUInstanceDataBufferLayout(); // 0x0000000181F131F0-0x0000000181F13760
		public void UpdateInstanceWindDataHistory(NativeArray<GPUInstanceIndex> gpuIndices); // 0x0000000181F16B10-0x0000000181F16B40
		public void AddCameras(NativeArray<EntityId> cameraIDs); // 0x0000000181F10E60-0x0000000181F10ED0
		public void RemoveCameras(NativeArray<EntityId> cameraIDs); // 0x0000000181F14CA0-0x0000000181F14D10
		public void AllocateNewInstances(JaggedSpan<EntityId> jaggedInstanceIDs, NativeArray<InstanceHandle> instances, NativeArray<GPUArchetypeHandle> archetypes, int newInstancesCount); // 0x0000000181F110A0-0x0000000181F11270
		public void ReallocateExistingGPUInstances(NativeArray<InstanceHandle> instances, NativeArray<GPUArchetypeHandle> archetypes); // 0x0000000181F14AB0-0x0000000181F14CA0
		public void AllocOrGPUReallocInstances(JaggedSpan<EntityId> jaggedInstanceIDs, NativeArray<InstanceHandle> instances, NativeArray<GPUArchetypeHandle> archetypes, int newInstancesCount); // 0x0000000181F10ED0-0x0000000181F110A0
		private void HandleInstancesAllocations(InstanceAllocatorVariant allocVariant, JaggedSpan<EntityId> jaggedInstanceIDs, NativeArray<InstanceHandle> instances, NativeArray<GPUArchetypeHandle> archetypes, int newInstancesCount); // 0x0000000181F14180-0x0000000181F14240
		public void FreeInstances(NativeArray<InstanceHandle> instances); // 0x0000000181F13A70-0x0000000181F13AC0
		public void UpdateInstanceData(NativeArray<InstanceHandle> instances, [IsReadOnly] in MeshRendererUpdateBatch updateBatch, NativeParallelHashMap<EntityId, GPUInstanceIndex> lodGroupDataMap); // 0x0000000181F15690-0x0000000181F15A10
		public GPUInstanceUploadData CreateInstanceUploadData(GPUComponentHandle component, int capacity, Allocator allocator); // 0x0000000181F113D0-0x0000000181F114D0
		public GPUInstanceUploadData CreateInstanceUploadData(NativeArray<GPUComponentHandle> components, int capacity, Allocator allocator); // 0x0000000181F11340-0x0000000181F113D0
		public GPUInstanceUploadData CreateInstanceUploadData(GPUComponentSet componentSet, int capacity, Allocator allocator); // 0x0000000181F114D0-0x0000000181F11630
		public void UploadDataToGPU(NativeArray<InstanceHandle> instances, GraphicsBuffer uploadBuffer, [IsReadOnly] in GPUInstanceUploadData uploadData); // 0x0000000181F16D10-0x0000000181F16E20
		public void UploadDataToGPU(NativeArray<GPUInstanceIndex> gpuIndices, GraphicsBuffer uploadBuffer, [IsReadOnly] in GPUInstanceUploadData uploadData); // 0x0000000181F16E20-0x0000000181F16E70
		public GPUInstanceDataBufferReadback<T> ReadbackInstanceDataBuffer<T>()
			where T : struct;
		public ref GPUComponentDesc GetGPUComponentDesc(GPUComponentHandle component); // 0x0000000181F13B30-0x0000000181F13BB0
		public void UpdateAllInstanceProbes(); // 0x0000000181F15610-0x0000000181F15690
		public void InitializeInstanceTransforms(NativeArray<InstanceHandle> instances, JaggedSpan<float4x4> jaggedLocalToWorldMatrices, JaggedSpan<float4x4> jaggedPrevLocalToWorldMatrices, bool anyInstanceUseBlendProbes); // 0x0000000181F14240-0x0000000181F142B0
		public void UpdateInstanceTransforms(NativeArray<InstanceHandle> instances, JaggedSpan<float4x4> jaggedLocalToWorldMatrices, bool anyInstanceUseBlendProbes); // 0x0000000181F16AB0-0x0000000181F16B10
		public void UpdateInstanceMotions(); // 0x0000000181F15C70-0x0000000181F15F30
		public void QueryInstanceGPUIndices(NativeArray<InstanceHandle> instances, NativeArray<GPUInstanceIndex> gpuIndices); // 0x0000000181F14730-0x0000000181F14780
		public JobHandle ScheduleQueryRendererInstancesJob(JaggedSpan<EntityId> jaggedRenderers, NativeArray<InstanceHandle> instances, UnsafeAtomicCounter32 notFoundInstancesCount = default); // 0x0000000181F151F0-0x0000000181F15330
		public void QueryRendererInstances(NativeArray<EntityId> renderers, NativeArray<InstanceHandle> instances, UnsafeAtomicCounter32 notFoundInstancesCount = default); // 0x0000000181F14A00-0x0000000181F14AB0
		public void QueryRendererInstances(JaggedSpan<EntityId> jaggedRenderers, NativeArray<InstanceHandle> instances, UnsafeAtomicCounter32 notFoundInstancesCount = default); // 0x0000000181F14780-0x0000000181F14A00
		public JobHandle ScheduleQueryRendererInstancesJob(NativeArray<EntityId> renderers, NativeArray<InstanceHandle> instances); // 0x0000000181F15030-0x0000000181F151F0
		public JobHandle ScheduleQuerySortedMeshInstancesJob(NativeArray<EntityId> sortedMeshes, NativeList<InstanceHandle> instances); // 0x0000000181F15330-0x0000000181F155A0
		public bool AreAllAllocatedInstancesValid(); // 0x0000000181F11270-0x0000000181F11340
		public void GetVisibleTreeInstances([IsReadOnly] in ParallelBitArray compactedVisibilityMasks, [IsReadOnly] in ParallelBitArray processedBits, NativeList<EntityId> visibeTreeRenderers, NativeList<InstanceHandle> visibeTreeInstances, bool becomeVisibleOnly, out int becomeVisibeTreeInstancesCount); // 0x0000000181F13BB0-0x0000000181F14180
		public void UpdatePerFrameInstanceVisibility([IsReadOnly] in ParallelBitArray compactedVisibilityMasks); // 0x0000000181F16B40-0x0000000181F16D10
		public void ValidateTotalTreeCount(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
