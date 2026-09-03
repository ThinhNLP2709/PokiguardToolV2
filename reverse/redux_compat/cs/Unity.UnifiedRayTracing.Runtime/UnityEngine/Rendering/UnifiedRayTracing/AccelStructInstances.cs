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

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal sealed class AccelStructInstances : IDisposable // TypeDefIndex: 14269
	{
		// Fields
		private readonly GeometryPool m_GeometryPool; // 0x10
		private readonly PersistentGpuArray<RTInstance> m_InstanceBuffer; // 0x18
		private readonly PersistentGpuArray<RTTerrain> m_TerrainBuffer; // 0x20
		private readonly Dictionary<int, InstanceEntry> m_Instances; // 0x28
		private uint m_FrameTimestamp; // 0x30
		private uint m_TransformTouchedLastTimestamp; // 0x34
	
		// Properties
		public PersistentGpuArray<RTInstance> instanceBuffer { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public IReadOnlyCollection<InstanceEntry> instances { get; } // 0x0000000182111820-0x0000000182111870 
		public GeometryPool geometryPool { get; } // 0x0000000180377550-0x0000000180377560 
		public GraphicsBuffer indexBuffer { get; } // 0x0000000180FB1BE0-0x0000000180FB1C00 
		public GraphicsBuffer vertexBuffer { get; } // 0x00000001814C98E0-0x00000001814C9900 
		public bool instanceListValid { get; } // 0x0000000180DAB6D0-0x0000000180DAB6E0 
	
		// Nested types
		public struct RTInstance // TypeDefIndex: 14270
		{
			// Fields
			public float4x3 localToWorld; // 0x00
			public float localToWorldDeterminant; // 0x30
			public float localToWorldDetSign; // 0x34
			public int userTerrainIndex; // 0x38
			public uint padding1; // 0x3C
			public float4x3 previousLocalToWorld; // 0x40
			public float4x3 localToWorldNormals; // 0x70
			public uint renderingLayerMask; // 0xA0
			public uint instanceMask; // 0xA4
			public uint userMaterialID; // 0xA8
			public uint geometryIndex; // 0xAC
		}
	
		public struct RTTerrain // TypeDefIndex: 14271
		{
			// Fields
			public float3 terrainScale; // 0x00
			public float heightmapWidthInTexels; // 0x0C
			public float3 invTerrainScale; // 0x10
			public float invHeightmapWidthInTexels; // 0x1C
			public int pow2DivideTileCountX; // 0x20
			public int pow2ModuloTileCountX; // 0x24
			public int tileWidthInCells; // 0x28
			public float invTerrainWidthInCells; // 0x2C
		}
	
		public class InstanceEntry // TypeDefIndex: 14272
		{
			// Fields
			public GeometryPoolHandle geometryPoolHandle; // 0x10
			public BlockAllocator.Allocation indexInTerrainBuffer; // 0x14
			public BlockAllocator.Allocation indexInInstanceBuffer; // 0x20
			public uint instanceMask; // 0x2C
			public uint vertexOffset; // 0x30
			public uint indexOffset; // 0x34
	
			// Constructors
			public InstanceEntry(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14273
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<RTInstance, RTInstance> __9__23_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182124C80-0x0000000182124CF0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal RTInstance _NextFrame_b__23_0(RTInstance instance); // 0x0000000182124B80-0x0000000182124C10
		}
	
		// Constructors
		internal AccelStructInstances(GeometryPool geometryPool); // 0x00000001821116F0-0x0000000182111820
	
		// Methods
		public void Dispose(); // 0x00000001821103D0-0x0000000182110620
		public int AddInstance(MeshInstanceDesc meshInstance, uint materialID, uint renderingLayerMask); // 0x000000018210EE90-0x000000018210EF50
		public int AddInstances(Span<MeshInstanceDesc> meshInstances, Span<uint> materialIDs, Span<uint> renderingLayerMask); // 0x000000018210FD90-0x000000018210FEE0
		public int AddInstance([IsReadOnly] in ProceduralInstanceDesc procInstance, uint materialID, uint renderingLayerMask, RTTerrain terrainData); // 0x000000018210EF50-0x000000018210F600
		private void AddInstance(BlockAllocator.Allocation slotAllocation, [IsReadOnly] in MeshInstanceDesc meshInstance, uint materialID, uint renderingLayerMask); // 0x000000018210F600-0x000000018210FD90
		public GeometryPool.MeshChunk GetEntryGeomAllocation(GeometryPoolHandle handle, int submeshIndex); // 0x0000000182110620-0x00000001821106B0
		public void RemoveInstance(int instanceHandle); // 0x00000001821109C0-0x0000000182110B60
		public void ClearInstances(); // 0x00000001821101A0-0x00000001821103D0
		public void UpdateInstanceTransform(int instanceHandle, Matrix4x4 localToWorldMatrix); // 0x0000000182111020-0x00000001821114F0
		public void UpdateInstanceMaterialID(int instanceHandle, uint materialID); // 0x0000000182110E20-0x0000000182111020
		public void UpdateRenderingLayerMask(int instanceHandle, uint renderingLayerMask); // 0x00000001821114F0-0x00000001821116F0
		public void UpdateInstanceMask(int instanceHandle, uint mask); // 0x0000000182110C10-0x0000000182110E20
		public void NextFrame(); // 0x00000001821106D0-0x00000001821107E0
		public void Bind(CommandBuffer cmd, IRayTracingShader shader); // 0x000000018210FEE0-0x00000001821101A0
		public int GetInstanceCount(); // 0x00000001821106B0-0x00000001821106D0
		private static float4x3 NormalMatrix(float4x4 m); // 0x00000001821107E0-0x00000001821109C0
		private static float4x3 ToFloat4x3([IsReadOnly] in float4x4 m); // 0x0000000182110B60-0x0000000182110C10
	}
}
