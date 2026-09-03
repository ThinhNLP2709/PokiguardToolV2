/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RadeonRays;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal class ComputeRayTracingAccelStruct : IRayTracingAccelStruct // TypeDefIndex: 14301
	{
		// Fields
		private readonly uint m_HandleObfuscation; // 0x10
		private readonly RadeonRaysAPI m_RadeonRaysAPI; // 0x18
		private readonly BuildFlags m_BuildFlags; // 0x20
		private readonly ReferenceCounter m_Counter; // 0x28
		[TupleElementNames(new string[2] {"mesh", "subMeshIndex" })]
		private readonly Dictionary<ValueTuple<int, int>, MeshBlas> m_MeshBlases; // 0x30
		private readonly Dictionary<int, ProceduralBlas> m_ProceduralBlases; // 0x38
		internal BlockAllocator m_BlasInternalNodesAllocator; // 0x40
		private GraphicsBuffer m_BlasInternalNodesBuffer; // 0x60
		internal BlockAllocator m_BlasLeafNodesAllocator; // 0x68
		private GraphicsBuffer m_BlasLeafNodesBuffer; // 0x88
		private readonly BLASPositionsPool m_BlasPositions; // 0x90
		private TopLevelAccelStruct? m_TopLevelAccelStruct; // 0x98
		private readonly ComputeShader m_CopyShader; // 0xC0
		private readonly Dictionary<int, RadeonRaysInstance> m_RadeonInstances; // 0xC8
		private readonly Queue<uint> m_FreeHandles; // 0xD0
	
		// Properties
		internal GraphicsBuffer topLevelBvhBuffer { get; } // 0x00000001821195F0-0x0000000182119610 
		internal GraphicsBuffer bottomLevelBvhBuffer { get; } // 0x00000001821195B0-0x00000001821195D0 
		internal GraphicsBuffer instanceInfoBuffer { get; } // 0x00000001821195D0-0x00000001821195F0 
	
		// Nested types
		private struct Triangle // TypeDefIndex: 14302
		{
			// Fields
			public float3 v0; // 0x00
			public float3 v1; // 0x0C
			public float3 v2; // 0x18
		}
	
		private sealed class RadeonRaysInstance // TypeDefIndex: 14303
		{
			// Fields
			public Blas blas; // 0x10
			public uint instanceMask; // 0x18
			public bool triangleCullingEnabled; // 0x1C
			public bool invertTriangleCulling; // 0x1D
			public uint userInstanceID; // 0x20
			public bool opaqueGeometry; // 0x24
			public UnityEngine.Rendering.RadeonRays.Transform localToWorldTransform; // 0x28
	
			// Constructors
			public RadeonRaysInstance(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class Blas // TypeDefIndex: 14304
		{
			// Fields
			public BlockAllocator.Allocation bvhInternalNodesAlloc; // 0x10
			public BlockAllocator.Allocation bvhLeafNodesAlloc; // 0x1C
	
			// Constructors
			public Blas(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private sealed class ProceduralBlas : Blas // TypeDefIndex: 14305
		{
			// Fields
			public ProceduralBuildInfo buildInfo; // 0x28
	
			// Constructors
			public ProceduralBlas(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private sealed class MeshBlas : Blas // TypeDefIndex: 14306
		{
			// Fields
			[TupleElementNames(new string[2] {"meshHash", "subMeshIndex" })]
			public ValueTuple<int, int> geomKey; // 0x28
			public MeshBuildInfo buildInfo; // 0x30
			public BlockAllocator.Allocation blasVertices; // 0x60
			public bool bvhBuilt; // 0x6C
			private uint refCount; // 0x70
	
			// Constructors
			public MeshBlas(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void IncRef(); // 0x0000000182126BD0-0x0000000182126BE0
			public void DecRef(); // 0x0000000182126BC0-0x0000000182126BD0
			public bool IsUnreferenced(); // 0x0000000182126BE0-0x0000000182126BF0
		}
	
		// Constructors
		internal ComputeRayTracingAccelStruct(AccelerationStructureOptions options, RayTracingResources resources, ReferenceCounter counter, int blasBufferInitialSizeBytes = 67108864 /* Metadata: 0x006A9632 */); // 0x0000000182119060-0x00000001821195B0
	
		// Methods
		public void Dispose(); // 0x0000000182117E80-0x0000000182118160
		public int AddInstance(MeshInstanceDesc meshInstance); // 0x0000000182114A00-0x0000000182114E00
		public int AddInstance(ProceduralInstanceDesc proceduralInstance); // 0x0000000182114E00-0x00000001821150E0
		public void RemoveInstance(int instanceHandle); // 0x0000000182118A20-0x0000000182118D50
		public void ClearInstances(); // 0x00000001821175C0-0x0000000182117960
		public void UpdateInstanceTransform(int instanceHandle, Matrix4x4 localToWorldMatrix); // 0x0000000182118EF0-0x0000000182119060
		public void UpdateInstanceID(int instanceHandle, uint instanceID); // 0x0000000182118D50-0x0000000182118E20
		public void UpdateInstanceMask(int instanceHandle, uint mask); // 0x0000000182118E20-0x0000000182118EF0
		public void Build(CommandBuffer cmd, GraphicsBuffer scratchBuffer); // 0x0000000182116F20-0x0000000182116F80
		public ulong GetBuildScratchBufferRequiredSizeInBytes(); // 0x00000001821181D0-0x00000001821181F0
		private void FreeTopLevelAccelStruct(); // 0x0000000182118160-0x00000001821181D0
		private MeshBlas GetOrAllocateMeshBlas(Mesh mesh, int subMeshIndex); // 0x0000000182118640-0x00000001821187B0
		private ProceduralBlas AllocateProceduralBlas(GraphicsBuffer aabbBuffer, uint aabbCount); // 0x0000000182115E60-0x0000000182116190
		private void AllocateMeshBlas(Mesh mesh, int submeshIndex, MeshBlas blas); // 0x00000001821157C0-0x0000000182115E60
		private GraphicsBuffer LoadIndexBuffer(Mesh mesh); // 0x0000000182118890-0x00000001821188B0
		private GraphicsBuffer LoadPositionBuffer(Mesh mesh, out int stride, out int offset); // 0x00000001821188B0-0x0000000182118940
		private void DeleteMeshBlas([TupleElementNames(new string[2] {"mesh", "subMeshIndex" })] ValueTuple<int, int> geomKey, MeshBlas blas); // 0x0000000182117C70-0x0000000182117D90
		private void DeleteProceduralBlas(int instanceHandle, ProceduralBlas blas); // 0x0000000182117D90-0x0000000182117E80
		private ulong GetBvhBuildScratchBufferSizeInDwords(); // 0x00000001821181F0-0x00000001821185A0
		private void CreateBvh(CommandBuffer cmd, GraphicsBuffer scratchBuffer); // 0x0000000182117C30-0x0000000182117C70
		private void BuildMissingBottomLevelAccelStructs(CommandBuffer cmd, GraphicsBuffer scratchBuffer); // 0x00000001821165E0-0x0000000182116A90
		private void CheckMeshBlasConsistency(CommandBuffer cmd, MeshBlas meshBlas); // 0x0000000182117060-0x0000000182117380
		private void CheckProceduralBlasConsistency(CommandBuffer cmd, ProceduralBlas proceduralBlas); // 0x0000000182117380-0x00000001821175C0
		private void BuildTopLevelAccelStruct(CommandBuffer cmd, GraphicsBuffer scratchBuffer); // 0x0000000182116A90-0x0000000182116F20
		private BuildFlags ConvertFlagsToGpuBuild(BuildFlags flags); // 0x0000000182117960-0x0000000182117970
		public void Bind(CommandBuffer cmd, string name, IRayTracingShader shader); // 0x00000001821163B0-0x00000001821165E0
		public void Bind(CommandBuffer cmd, ComputeShader shader, int kernelIndex, string name); // 0x0000000182116190-0x00000001821163B0
		private static UnityEngine.Rendering.RadeonRays.Transform ConvertTranform(Matrix4x4 input); // 0x0000000182117B80-0x0000000182117C30
		private static Matrix4x4 ConvertTranform(UnityEngine.Rendering.RadeonRays.Transform input); // 0x0000000182117970-0x0000000182117B80
		private static int3 GetFaceIndices(List<int> indices, int triangleIdx); // 0x00000001821185A0-0x0000000182118640
		private static Triangle GetTriangle(List<Vector3> vertices, int3 idx); // 0x00000001821187B0-0x0000000182118890
		private BlockAllocator.Allocation AllocateBlasInternalNodes(int allocationNodeCount); // 0x00000001821150E0-0x0000000182115450
		private BlockAllocator.Allocation AllocateBlasLeafNodes(int allocationNodeCount); // 0x0000000182115450-0x00000001821157C0
		private int NewHandle(); // 0x0000000182118940-0x00000001821189C0
		private void ReleaseHandle(int handle); // 0x00000001821189C0-0x0000000182118A20
		[Conditional("UNITY_ASSERTIONS")]
		private void CheckInstanceHandleIsValid(int instanceHandle); // 0x0000000182116F80-0x0000000182117060
	}
}
