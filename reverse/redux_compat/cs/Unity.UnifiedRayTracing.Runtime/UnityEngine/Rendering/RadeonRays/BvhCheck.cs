/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.RadeonRays
{
	internal class BvhCheck // TypeDefIndex: 14230
	{
		// Fields
		private const uint kInvalidID = 4294967295; // Metadata: 0x006A95E7
	
		// Nested types
		public class VertexBuffers // TypeDefIndex: 14231
		{
			// Fields
			public GraphicsBuffer vertices; // 0x10
			public GraphicsBuffer indices; // 0x18
			public uint vertexBufferOffset; // 0x20
			public uint vertexCount; // 0x24
			public uint vertexStride; // 0x28
			public uint indexBufferOffset; // 0x2C
			public IndexFormat indexFormat; // 0x30
			public uint indexCount; // 0x34
	
			// Constructors
			public VertexBuffers(); // 0x0000000182124E10-0x0000000182124E20
		}
	
		private sealed class VertexBuffersCPU // TypeDefIndex: 14232
		{
			// Fields
			public float[] vertices; // 0x10
			public uint[] indices; // 0x18
			public uint vertexStride; // 0x20
	
			// Constructors
			public VertexBuffersCPU(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private struct Triangle // TypeDefIndex: 14233
		{
			// Fields
			public float3 v0; // 0x00
			public float3 v1; // 0x0C
			public float3 v2; // 0x18
		}
	
		// Constructors
		public BvhCheck(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static VertexBuffers Convert(MeshBuildInfo info); // 0x0000000182114050-0x0000000182114110
		public static double SurfaceArea(AABB aabb); // 0x00000001821148C0-0x0000000182114920
		public static double NodeSahCost(uint nodeAddr, AABB nodeAabb, AABB parentAabb); // 0x00000001821147A0-0x00000001821148C0
		public static double CheckConsistency(VertexBuffers bvhVertexBuffers, BottomLevelAccelStruct bvh, uint primitiveCount); // 0x0000000182113860-0x00000001821139D0
		public static double CheckConsistency(GraphicsBuffer primitiveAabbsBuffer, BottomLevelAccelStruct bvh, uint primitiveCount); // 0x00000001821139D0-0x0000000182113B70
		public static double CheckConsistency(GraphicsBuffer bvhBuffer, uint bvhBufferOffset, uint primitiveCount); // 0x0000000182113760-0x0000000182113860
		public static int ExtractBits(uint value, int startBit, int count); // 0x00000001821142F0-0x0000000182114320
		public static bool IsLeafNode(uint nodeAddr); // 0x0000000182114790-0x00000001821147A0
		public static uint GetLeafNodeFirstPrim(uint nodeAddr); // 0x00000001821145F0-0x0000000182114600
		public static uint GetLeafNodePrimCount(uint nodeAddr); // 0x0000000182114600-0x0000000182114610
		private static double CheckConsistencyInternal(AABB[] primitiveAabbs, GraphicsBuffer bvhBuffer, uint bvhBufferOffset, GraphicsBuffer bvhLeavesBuffer, uint bvhLeavesBufferOffset, BvhHeader header, uint primitiveCount); // 0x0000000182113200-0x0000000182113760
		private static uint3 GetFaceIndices(uint[] indices, uint triangleIdx); // 0x0000000182114580-0x00000001821145F0
		private static float3 GetVertex(float[] vertices, uint stride, uint idx); // 0x0000000182114730-0x0000000182114790
		private static Triangle GetTriangle(float[] vertices, uint stride, uint3 idx); // 0x0000000182114610-0x0000000182114730
		private static VertexBuffersCPU DownloadVertexData(VertexBuffers vertexBuffers); // 0x0000000182114110-0x00000001821142F0
		private static AABB GetAabb(AABB[] primitiveAabbs, BvhNode[] bvhNodes, uint4[] bvhLeafNodes, uint nodeAddr, bool isTopLevel); // 0x0000000182114320-0x0000000182114580
		private static AABB[] ComputePrimitiveAabbList(VertexBuffersCPU bvhVertexBuffers, uint primitiveCount); // 0x0000000182113B70-0x0000000182114050
	}
}
