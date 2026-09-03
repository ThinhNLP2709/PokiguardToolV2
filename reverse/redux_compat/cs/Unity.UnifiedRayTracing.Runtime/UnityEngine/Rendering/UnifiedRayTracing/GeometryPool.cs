/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal sealed class GeometryPool : IDisposable // TypeDefIndex: 14279
	{
		// Fields
		private const int kMaxThreadGroupsPerDispatch = 65535; // Metadata: 0x006A9614
		private const int kThreadGroupSize = 256; // Metadata: 0x006A9618
		private const int InvalidHandle = -1; // Metadata: 0x006A961A
		private const GraphicsBuffer.Target VertexBufferTarget = GraphicsBuffer.Target.Structured; // Metadata: 0x006A961B
		private const GraphicsBuffer.Target IndexBufferTarget = GraphicsBuffer.Target.Structured; // Metadata: 0x006A961C
		private GraphicsBuffer m_GlobalIndexBuffer; // 0x10
		private GraphicsBuffer m_GlobalVertexBuffer; // 0x18
		private GraphicsBuffer m_GlobalMeshChunkTableEntryBuffer; // 0x20
		private readonly GraphicsBuffer m_DummyBuffer; // 0x28
		private int m_MaxVertCounts; // 0x30
		private int m_MaxIndexCounts; // 0x34
		private int m_MaxMeshChunkTableEntriesCount; // 0x38
		private BlockAllocator m_VertexAllocator; // 0x40
		private BlockAllocator m_IndexAllocator; // 0x60
		private BlockAllocator m_MeshChunkTableAllocator; // 0x80
		private NativeParallelHashMap<uint, int> m_MeshHashToGeoSlot; // 0xA0
		private List<GeometrySlot> m_GeoSlots; // 0xB0
		private NativeList<int> m_FreeGeoSlots; // 0xB8
		private NativeParallelHashMap<uint, GeometryPoolHandle> m_GeoPoolEntryHashToSlot; // 0xC0
		private NativeList<GeoPoolEntrySlot> m_GeoPoolEntrySlots; // 0xD0
		private NativeList<GeometryPoolHandle> m_FreeGeoPoolEntrySlots; // 0xD8
		private readonly List<GraphicsBuffer> m_InputBufferReferences; // 0xE0
		private readonly ComputeShader m_CopyShader; // 0xE8
		private ComputeShader m_GeometryPoolKernelsCS; // 0xF0
		private int m_KernelMainUpdateIndexBuffer16; // 0xF8
		private int m_KernelMainUpdateIndexBuffer32; // 0xFC
		private int m_KernelMainUpdateVertexBuffer; // 0x100
		private readonly CommandBuffer m_CmdBuffer; // 0x108
		private bool m_MustClearCmdBuffer; // 0x110
		private int m_PendingCmds; // 0x114
	
		// Properties
		public GraphicsBuffer globalIndexBuffer { get; } // 0x0000000180377550-0x0000000180377560 
		public GraphicsBuffer globalVertexBuffer { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public int globalVertexBufferStrideBytes { get; } // 0x0000000180A2FAE0-0x0000000180A2FAF0 
		public GraphicsBuffer globalMeshChunkTableEntryBuffer { get; } // 0x00000001802F8630-0x00000001802F8640 
		public int indicesCount { get; } // 0x000000018033D0F0-0x000000018033D100 
		public int verticesCount { get; } // 0x000000018033D100-0x000000018033D110 
		public int meshChunkTablesEntryCount { get; } // 0x000000018047EDE0-0x000000018047EDF0 
	
		// Nested types
		private static class GeoPoolShaderIDs // TypeDefIndex: 14280
		{
			// Fields
			public static readonly int _InputIBBaseOffset; // 0x00
			public static readonly int _DispatchIndexOffset; // 0x04
			public static readonly int _InputIBCount; // 0x08
			public static readonly int _OutputIBOffset; // 0x0C
			public static readonly int _InputFirstVertex; // 0x10
			public static readonly int _InputIndexBuffer; // 0x14
			public static readonly int _OutputIndexBuffer; // 0x18
			public static readonly int _InputVBCount; // 0x1C
			public static readonly int _InputBaseVertexOffset; // 0x20
			public static readonly int _DispatchVertexOffset; // 0x24
			public static readonly int _OutputVBSize; // 0x28
			public static readonly int _OutputVBOffset; // 0x2C
			public static readonly int _InputPosBufferStride; // 0x30
			public static readonly int _InputPosBufferOffset; // 0x34
			public static readonly int _InputUv0BufferStride; // 0x38
			public static readonly int _InputUv0BufferOffset; // 0x3C
			public static readonly int _InputUv1BufferStride; // 0x40
			public static readonly int _InputUv1BufferOffset; // 0x44
			public static readonly int _InputNormalBufferStride; // 0x48
			public static readonly int _InputNormalBufferOffset; // 0x4C
			public static readonly int _PosBuffer; // 0x50
			public static readonly int _Uv0Buffer; // 0x54
			public static readonly int _Uv1Buffer; // 0x58
			public static readonly int _NormalBuffer; // 0x5C
			public static readonly int _OutputVB; // 0x60
			public static readonly int _AttributesMask; // 0x64
	
			// Constructors
			static GeoPoolShaderIDs(); // 0x0000000182119D80-0x000000018211A210
		}
	
		public struct MeshChunk // TypeDefIndex: 14281
		{
			// Fields
			public BlockAllocator.Allocation vertexAlloc; // 0x00
			public BlockAllocator.Allocation indexAlloc; // 0x0C
	
			// Properties
			public static MeshChunk Invalid { get; } // 0x000000018211FA60-0x000000018211FAE0 
	
			// Methods
			public GeoPoolMeshChunk EncodeGPUEntry(); // 0x000000018211FA40-0x000000018211FA60
		}
	
		public struct GeometrySlot // TypeDefIndex: 14282
		{
			// Fields
			public uint refCount; // 0x00
			public uint hash; // 0x04
			public BlockAllocator.Allocation meshChunkTableAlloc; // 0x08
			public NativeArray<MeshChunk> meshChunks; // 0x18
			public bool hasGPUData; // 0x28
			public static readonly GeometrySlot Invalid; // 0x00
	
			// Properties
			public bool valid { get; } // 0x000000018211DA00-0x000000018211DA50 
	
			// Constructors
			static GeometrySlot(); // 0x000000018211D950-0x000000018211DA00
		}
	
		private struct GeoPoolEntrySlot // TypeDefIndex: 14283
		{
			// Fields
			public uint refCount; // 0x00
			public uint hash; // 0x04
			public int geoSlotHandle; // 0x08
			public static readonly GeoPoolEntrySlot Invalid; // 0x00
	
			// Properties
			public bool valid { get; } // 0x0000000182119D70-0x0000000182119D80 
	
			// Constructors
			static GeoPoolEntrySlot(); // 0x0000000182119D20-0x0000000182119D70
		}
	
		private struct VertexBufferAttribInfo // TypeDefIndex: 14284
		{
			// Fields
			public GraphicsBuffer buffer; // 0x00
			public int stride; // 0x08
			public int offset; // 0x0C
			public int byteCount; // 0x10
	
			// Properties
			public bool valid { get; } // 0x0000000180A3EC30-0x0000000180A3EC40 
		}
	
		// Constructors
		public GeometryPool([IsReadOnly] in GeometryPoolDesc desc, ComputeShader geometryPoolShader, ComputeShader copyShader); // 0x000000018211D430-0x000000018211D950
	
		// Methods
		public static int GetVertexByteSize(); // 0x0000000180A2FAE0-0x0000000180A2FAF0
		public static int GetIndexByteSize(); // 0x00000001804CB980-0x00000001804CB990
		public static int GetMeshChunkTableEntryByteSize(); // 0x000000018211C4F0-0x000000018211C540
		private int GetFormatByteCount(VertexAttributeFormat format); // 0x000000018211C2A0-0x000000018211C300
		private static int DivUp(int x, int y); // 0x0000000181E58550-0x0000000181E58560
		private void DisposeInputBuffers(); // 0x000000018211BB40-0x000000018211BC70
		public void Dispose(); // 0x000000018211BC70-0x000000018211BFE0
		private void LoadKernels(ComputeShader geometryPoolShader); // 0x000000018211C640-0x000000018211C710
		private int CalcVertexCount(int bufferByteSize); // 0x000000018211B4F0-0x000000018211B500
		private int CalcIndexCount(int bufferByteSize); // 0x0000000181A955B0-0x0000000181A955C0
		private int CalcMeshChunkTablesCount(int bufferByteSize); // 0x000000018211B490-0x000000018211B4F0
		private void DeallocateGeometrySlot(ref GeometrySlot slot); // 0x000000018211B9E0-0x000000018211BB40
		private void DeallocateGeometrySlot(int geoSlotHandle); // 0x000000018211B8E0-0x000000018211B9E0
		private bool AllocateGeo(Mesh mesh, out int allocationHandle); // 0x000000018211AB60-0x000000018211B490
		private void DeallocateGeoPoolEntrySlot(GeometryPoolHandle handle); // 0x000000018211B6C0-0x000000018211B770
		private void DeallocateGeoPoolEntrySlot(ref GeoPoolEntrySlot geoPoolEntrySlot); // 0x000000018211B770-0x000000018211B8E0
		public GeometryPoolEntryInfo GetEntryInfo(GeometryPoolHandle handle); // 0x000000018211C0E0-0x000000018211C2A0
		public GeometrySlot GetEntryGeomAllocation(GeometryPoolHandle handle); // 0x000000018211C080-0x000000018211C0E0
		public int GetInstanceGeometryIndex(Mesh mesh); // 0x000000018211C3D0-0x000000018211C4F0
		private void UpdateGeoGpuState(Mesh mesh, GeometryPoolHandle handle); // 0x000000018211CF60-0x000000018211D430
		private uint FNVHash(uint prevHash, uint dword); // 0x000000018211BFE0-0x000000018211C030
		private uint CalculateClusterHash(Mesh mesh, GeometryPoolSubmeshData[] submeshData); // 0x000000018211B500-0x000000018211B6C0
		public GeometryPoolHandle GetHandle(Mesh mesh); // 0x000000018211C300-0x000000018211C3D0
		private static int FindSubmeshEntryInDesc(int submeshIndex, [IsReadOnly] in GeometryPoolSubmeshData[] submeshData); // 0x000000018211C030-0x000000018211C080
		public bool Register(Mesh mesh, out GeometryPoolHandle outHandle); // 0x000000018211CDD0-0x000000018211CE30
		public bool Register([IsReadOnly] in GeometryPoolEntryDesc entryDesc, out GeometryPoolHandle outHandle); // 0x000000018211C8D0-0x000000018211CDD0
		public void Unregister(GeometryPoolHandle handle); // 0x000000018211CEB0-0x000000018211CF60
		public void SendGpuCommands(); // 0x000000018211CE30-0x000000018211CEB0
		private GraphicsBuffer LoadIndexBuffer(Mesh mesh); // 0x000000018211C540-0x000000018211C640
		private void LoadVertexAttribInfo(Mesh mesh, VertexAttribute attribute, out VertexBufferAttribInfo output); // 0x000000018211C710-0x000000018211C8D0
		private CommandBuffer AllocateCommandBuffer(); // 0x000000018211AB10-0x000000018211AB60
		private void AddIndexUpdateCommand(CommandBuffer cmdBuffer, IndexFormat inputFormat, [IsReadOnly] in GraphicsBuffer inputBuffer, [IsReadOnly] in BlockAllocator.Allocation location, int firstVertex, int inputOffset, int indexCount, int outputOffset, GraphicsBuffer outputIdxBuffer); // 0x000000018211A270-0x000000018211A540
		private void AddVertexUpdateCommand(CommandBuffer cmdBuffer, int baseVertexOffset, [IsReadOnly] in VertexBufferAttribInfo pos, [IsReadOnly] in VertexBufferAttribInfo uv0, [IsReadOnly] in VertexBufferAttribInfo uv1, [IsReadOnly] in VertexBufferAttribInfo n, [IsReadOnly] in BlockAllocator.Allocation location, GraphicsBuffer outputVertexBuffer); // 0x000000018211A540-0x000000018211AB10
	}
}
