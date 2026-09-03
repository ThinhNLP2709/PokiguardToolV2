/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

// Image 38: UnityEngine.U2DRuntimeModule.dll - Assembly: UnityEngine.U2DRuntimeModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15050-15086

namespace UnityEngine.U2D.UTess
{
	internal struct ModuleHandle // TypeDefIndex: 15084
	{
		// Fields
		internal static readonly int kMaxArea; // 0x00
		internal static readonly int kMaxEdgeCount; // 0x04
		internal static readonly int kMaxIndexCount; // 0x08
		internal static readonly int kMaxVertexCount; // 0x0C
		internal static readonly int kMaxTriangleCount; // 0x10
		internal static readonly int kMaxRefineIterations; // 0x14
		internal static readonly int kMaxSmoothenIterations; // 0x18
		internal static readonly float kIncrementAreaFactor; // 0x1C
	
		// Constructors
		static ModuleHandle(); // 0x0000000182358580-0x0000000182358660
	
		// Methods
		internal static void Copy<T>(NativeArray<T> src, int srcIndex, NativeArray<T> dst, int dstIndex, int length)
			where T : struct;
		internal static void Copy<T>(NativeArray<T> src, NativeArray<T> dst, int length)
			where T : struct;
		internal static unsafe void InsertionSort<T, U>(void* array, int lo, int hi, U comp)
			where T : struct
			where U : IComparer<T>;
		internal static int GetLower<T, U, X>(NativeArray<T> values, int count, U check, X condition)
			where T : struct
			where U : struct
			where X : ICondition2<T, U>;
		internal static int GetUpper<T, U, X>(NativeArray<T> values, int count, U check, X condition)
			where T : struct
			where U : struct
			where X : ICondition2<T, U>;
		internal static int GetEqual<T, U, X>(Array<T> values, int count, U check, X condition)
			where T : struct
			where U : struct
			where X : ICondition2<T, U>;
		internal static int GetEqual<T, U, X>(NativeArray<T> values, int count, U check, X condition)
			where T : struct
			where U : struct
			where X : ICondition2<T, U>;
		internal static float OrientFast(float2 a, float2 b, float2 c); // 0x0000000181C34C20-0x0000000181C34CA0
		internal static double OrientFastDouble(double2 a, double2 b, double2 c); // 0x0000000181C34BC0-0x0000000181C34C20
		internal static UCircle CircumCircle(UTriangle tri); // 0x0000000181C33850-0x0000000181C33A30
		internal static float TriangleArea(float2 va, float2 vb, float2 vc); // 0x0000000181C362E0-0x0000000181C36340
		internal static bool IsInsideCircle(float2 a, float2 b, float2 c, float2 p); // 0x0000000181C34640-0x0000000181C34870
		internal static void BuildTriangles(NativeArray<float2> vertices, int vertexCount, NativeArray<int> indices, int indexCount, ref Array<UTriangle> triangles, ref int triangleCount, ref float maxArea, ref float avgArea, ref float minArea); // 0x0000000182356AD0-0x0000000182356E20
		internal static void BuildTriangles(NativeArray<float2> vertices, int vertexCount, NativeArray<int> indices, int indexCount, ref NativeArray<UTriangle> triangles, ref int triangleCount, ref float maxArea, ref float avgArea, ref float minArea, ref float maxEdge, ref float avgEdge, ref float minEdge); // 0x0000000182356620-0x0000000182356AD0
		internal static void BuildTrianglesAndEdges(NativeArray<float2> vertices, int vertexCount, NativeArray<int> indices, int indexCount, ref NativeArray<UTriangle> triangles, ref int triangleCount, ref NativeArray<int4> delaEdges, ref int delaEdgeCount, ref float maxArea, ref float avgArea, ref float minArea); // 0x0000000182356220-0x0000000182356620
		private static void CopyGraph(NativeArray<float2> srcPoints, int srcPointCount, ref NativeArray<float2> dstPoints, ref int dstPointCount, NativeArray<int2> srcEdges, int srcEdgeCount, ref NativeArray<int2> dstEdges, ref int dstEdgeCount); // 0x0000000182356F00-0x0000000182356FF0
		private static void CopyGeometry(NativeArray<int> srcIndices, int srcIndexCount, ref NativeArray<int> dstIndices, ref int dstIndexCount, NativeArray<float2> srcVertices, int srcVertexCount, ref NativeArray<float2> dstVertices, ref int dstVertexCount); // 0x0000000182356E20-0x0000000182356F00
		private static void TransferOutput(NativeArray<int2> srcEdges, int srcEdgeCount, ref NativeArray<int2> dstEdges, ref int dstEdgeCount, NativeArray<int> srcIndices, int srcIndexCount, ref NativeArray<int> dstIndices, ref int dstIndexCount, NativeArray<float2> srcVertices, int srcVertexCount, ref NativeArray<float2> dstVertices, ref int dstVertexCount); // 0x0000000182358340-0x0000000182358470
		private static void Reorder(int startVertexCount, int index, ref NativeArray<int> indices, ref int indexCount, ref NativeArray<float2> vertices, ref int vertexCount); // 0x0000000181C34D60-0x0000000181C34E00
		internal static void VertexCleanupConditioner(int startVertexCount, ref NativeArray<int> indices, ref int indexCount, ref NativeArray<float2> vertices, ref int vertexCount); // 0x0000000182358470-0x0000000182358580
		public static float4 Tessellate(Allocator allocator, [IsReadOnly] in NativeArray<float2> points, [IsReadOnly] in NativeArray<int2> edges, ref NativeArray<float2> outVertices, out int outVertexCount, ref NativeArray<int> outIndices, out int outIndexCount, ref NativeArray<int2> outEdges, out int outEdgeCount, bool runPlanarGraph); // 0x0000000182357E60-0x0000000182358340
		public static float4 Subdivide(Allocator allocator, NativeArray<float2> points, NativeArray<int2> edges, ref NativeArray<float2> outVertices, ref int outVertexCount, ref NativeArray<int> outIndices, ref int outIndexCount, ref NativeArray<int2> outEdges, ref int outEdgeCount, float areaFactor, float targetArea, int refineIterations, int smoothenIterations); // 0x0000000182356FF0-0x0000000182357E60
	}
}
