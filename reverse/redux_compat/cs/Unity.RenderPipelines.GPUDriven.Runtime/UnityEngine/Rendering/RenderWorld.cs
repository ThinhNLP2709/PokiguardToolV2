/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct RenderWorld : IDisposable // TypeDefIndex: 12827
	{
		// Fields
		public static readonly EntityId DefaultMesh; // 0x00
		public static readonly ushort DefaultSubMeshStartIndex; // 0x08
		public static readonly ushort DefaultStaticBatchSubMeshCount; // 0x0A
		public static readonly AABB DefaultLocalBounds; // 0x0C
		public static readonly InternalMeshRendererSettings DefaultRendererSettings; // 0x24
		public static readonly InternalMeshLodRendererSettings DefaultMeshLodRendererSettings; // 0x2C
		public static readonly int DefaultParentLODGroupID; // 0x34
		public static readonly byte DefaultLODMask; // 0x38
		public static readonly short DefaultLightmapIndex; // 0x3A
		public static readonly int DefaultRendererPriority; // 0x3C
		private const int InvalidIndex = -1; // Metadata: 0x006A75C0
		private NativeReference<int> m_InstancesCount; // 0x00
		private NativeReference<int> m_TotalTreeCount; // 0x10
		private NativeList<int> m_HandleToIndex; // 0x20
		private NativeArray<InstanceHandle> m_IndexToHandle; // 0x28
		private NativeArray<EntityId> m_InstanceIDs; // 0x38
		private NativeArray<EmbeddedArray32<EntityId>> m_MaterialIDArrays; // 0x48
		private NativeArray<EntityId> m_MeshIDs; // 0x58
		private NativeArray<InternalMeshLodRendererSettings> m_MeshLodRendererSettings; // 0x68
		private NativeArray<ushort> m_SubMeshStartIndices; // 0x78
		private NativeArray<ushort> m_StaticBatchSubMeshCounts; // 0x88
		private NativeArray<AABB> m_LocalAABBs; // 0x98
		private NativeArray<InternalMeshRendererSettings> m_RendererSettings; // 0xA8
		private NativeArray<short> m_LightmapIndices; // 0xB8
		private NativeArray<GPUInstanceIndex> m_LODGroupIndices; // 0xC8
		private NativeArray<byte> m_LODMasks; // 0xD8
		private NativeArray<int> m_RendererPriorities; // 0xE8
		private NativeArray<InstanceGPUHandle> m_GPUHandles; // 0xF8
		private ParallelBitArray m_LocalToWorldIsFlippedBits; // 0x108
		private NativeArray<AABB> m_WorldAABBs; // 0x128
		private NativeArray<int> m_TetrahedronCacheIndices; // 0x138
		private ParallelBitArray m_MovedInCurrentFrameBits; // 0x148
		private ParallelBitArray m_MovedInPreviousFrameBits; // 0x168
		private ParallelBitArray m_VisibleInPreviousFrameBits; // 0x188
		private ParallelBitArray m_RenderingEnabled; // 0x1A8
		private EditorOnly m_EditorOnly; // 0x1C8
		private NativeParallelHashMap<EntityId, UnsafePerCameraInstanceData> m_PerCameraInstanceDataMap; // 0x1D0
	
		// Properties
		public NativeArray<InstanceHandle> indexToHandle { get; } // 0x0000000181F2CE10-0x0000000181F2CE90 
		public NativeArray<EntityId> instanceIDs { get; } // 0x0000000181F2CEA0-0x0000000181F2CF20 
		public NativeArray<EmbeddedArray32<EntityId>> materialIDArrays { get; } // 0x0000000181F2D1A0-0x0000000181F2D220 
		public NativeArray<EntityId> meshIDs { get; } // 0x0000000181F2D220-0x0000000181F2D2A0 
		public NativeArray<InternalMeshLodRendererSettings> meshLodRendererSettings { get; } // 0x0000000181F2D2A0-0x0000000181F2D320 
		public NativeArray<ushort> subMeshStartIndices { get; } // 0x0000000181F2D620-0x0000000181F2D6A0 
		public NativeArray<ushort> staticBatchSubMeshCounts { get; } // 0x0000000181F2D5A0-0x0000000181F2D620 
		public NativeArray<AABB> localAABBs { get; } // 0x0000000181F2CFA0-0x0000000181F2D020 
		public NativeArray<InternalMeshRendererSettings> rendererSettings { get; } // 0x0000000181F2D4A0-0x0000000181F2D520 
		public NativeArray<short> lightmapIndices { get; } // 0x0000000181F2CF20-0x0000000181F2CFA0 
		public NativeArray<GPUInstanceIndex> lodGroupIndices { get; } // 0x0000000181F2D0A0-0x0000000181F2D120 
		public NativeArray<byte> lodMasks { get; } // 0x0000000181F2D120-0x0000000181F2D1A0 
		public NativeArray<int> rendererPriorities { get; } // 0x0000000181F2D420-0x0000000181F2D4A0 
		public NativeArray<InstanceGPUHandle> gpuHandles { get; } // 0x0000000181F2CD80-0x0000000181F2CE00 
		public ParallelBitArray localToWorldIsFlippedBits { get; } // 0x0000000181F2D020-0x0000000181F2D0A0 
		public NativeArray<AABB> worldAABBs { get; } // 0x0000000181F2D7B0-0x0000000181F2D830 
		public NativeArray<int> tetrahedronCacheIndices { get; } // 0x0000000181F2D6A0-0x0000000181F2D720 
		public ParallelBitArray movedInCurrentFrameBits { get; } // 0x0000000181F2D320-0x0000000181F2D3A0 
		public ParallelBitArray movedInPreviousFrameBits { get; } // 0x0000000181F2D3A0-0x0000000181F2D420 
		public ParallelBitArray visibleInPreviousFrameBits { get; } // 0x0000000181F2D730-0x0000000181F2D7B0 
		public ParallelBitArray renderingEnabled { get; } // 0x0000000181F2D520-0x0000000181F2D5A0 
		public int instanceCount { get; private set; } // 0x0000000181F2CE90-0x0000000181F2CEA0 0x0000000181F2D830-0x0000000181F2D840
		public int handleCount { get; } // 0x0000000181F2CE00-0x0000000181F2CE10 
		public int totalTreeCount { get; } // 0x0000000181F2D720-0x0000000181F2D730 
		public int cameraCount { get; } // 0x0000000181F2CD70-0x0000000181F2CD80 
		public UnsafeAtomicCounter32 atomicTotalTreeCount { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Nested types
		public struct PerCameraInstanceData // TypeDefIndex: 12828
		{
			// Fields
			public const int InvalidByteData = 255; // Metadata: 0x006A75C1
			public NativeArray<byte> meshLods; // 0x00
			public NativeArray<byte> crossFades; // 0x10
	
			// Properties
			public bool IsCreated { get; } // 0x0000000181F299A0-0x0000000181F299C0 
	
			// Constructors
			public PerCameraInstanceData(int length, Allocator allocator); // 0x0000000181F29920-0x0000000181F299A0
	
			// Methods
			public void Dispose(JobHandle jobHandle); // 0x0000000181F298A0-0x0000000181F29920
		}
	
		private struct UnsafePerCameraInstanceData : IDisposable // TypeDefIndex: 12829
		{
			// Fields
			public UnsafeList<byte> meshLods; // 0x00
			public UnsafeList<byte> crossFades; // 0x18
	
			// Constructors
			public UnsafePerCameraInstanceData(int initCapacity, Allocator allocator); // 0x0000000181F2E100-0x0000000181F2E1F0
	
			// Methods
			public void Dispose(); // 0x0000000181F2DF90-0x0000000181F2DFB0
			public void Remove(int index, int lastIndex); // 0x0000000181F2DFB0-0x0000000181F2DFE0
			public void Resize(int newCapacity); // 0x0000000181F2DFE0-0x0000000181F2E020
			public PerCameraInstanceData ToPerCameraInstanceData(int instanceCount); // 0x0000000181F2E020-0x0000000181F2E100
		}
	
		private struct EditorOnly // TypeDefIndex: 12830
		{
			// Methods
			public void Initialize(int initCapacity); // 0x00000001802E76C0-0x00000001802E76D0
			public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			public void Grow(int newCapacity); // 0x00000001802E76C0-0x00000001802E76D0
			public void Remove(int index, int lastIndex); // 0x00000001802E76C0-0x00000001802E76D0
			public void SetDefault(int index); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		static RenderWorld(); // 0x0000000181F2CC10-0x0000000181F2CD70
	
		// Methods
		public void Initialize(int initCapacity); // 0x0000000181F2B700-0x0000000181F2BD50
		public void Dispose(); // 0x0000000181F2A940-0x0000000181F2AD90
		private void Grow(int newCapacity); // 0x0000000181F2B030-0x0000000181F2B5A0
		private int AddUninitialized(InstanceHandle instance); // 0x0000000181F2A830-0x0000000181F2A940
		public int HandleToIndex(InstanceHandle instance); // 0x0000000181F2B5A0-0x0000000181F2B600
		public InstanceHandle IndexToHanle(int index); // 0x0000000181F2B600-0x0000000181F2B610
		public bool IsValidInstance(InstanceHandle instance); // 0x0000000181F2BE80-0x0000000181F2BF70
		public bool IsValidIndex(int index); // 0x0000000181F2BDD0-0x0000000181F2BE80
		public bool IsFreeInstanceHandle(InstanceHandle instance); // 0x0000000181F2BD50-0x0000000181F2BDD0
		public int GetInstanceCapacity(); // 0x000000018033D100-0x000000018033D110
		public int GetFreeCapacity(); // 0x0000000181F2AE60-0x0000000181F2AEC0
		public void EnsureFreeCapacity(int instancesCount); // 0x0000000181F2AD90-0x0000000181F2AE60
		public int AddInstanceNoGrow(InstanceHandle instance); // 0x0000000181F2A620-0x0000000181F2A830
		public void RemoveInstance(InstanceHandle instance); // 0x0000000181F2C0D0-0x0000000181F2C6C0
		public void ResetInstance(int instanceIndex); // 0x0000000181F2C6C0-0x0000000181F2CAA0
		private void InitializeInstance(int instanceIndex); // 0x0000000181F2B610-0x0000000181F2B700
		public void AddCameras(NativeArray<EntityId> cameraIDs); // 0x0000000181F2A460-0x0000000181F2A620
		public void RemoveCameras(NativeArray<EntityId> cameraIDs); // 0x0000000181F2BF70-0x0000000181F2C0D0
		public bool TryGetPerCameraInstanceData(EntityId cameraID, out PerCameraInstanceData perCameraInstanceData); // 0x0000000181F2CAA0-0x0000000181F2CC10
		public PerCameraInstanceData GetPerCameraInstanceData(EntityId cameraID); // 0x0000000181F2AEC0-0x0000000181F2B030
	}
}
