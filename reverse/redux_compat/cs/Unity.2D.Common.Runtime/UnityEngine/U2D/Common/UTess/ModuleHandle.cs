/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;

// Image 36: Unity.2D.Common.Runtime.dll - Assembly: Unity.2D.Common.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14954-14996

namespace UnityEngine.U2D.Common.UTess
{
	internal struct ModuleHandle // TypeDefIndex: 14990
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
	
		// Nested types
		private struct Int3Compare : IComparer<int3> // TypeDefIndex: 14991
		{
			// Methods
			public int Compare(int3 a, int3 b); // 0x0000000181C32600-0x0000000181C32620
		}
	
		// Constructors
		static ModuleHandle(); // 0x0000000181C36450-0x0000000181C36530
	
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
		internal static bool IsInsideCircle(UCircle c, float2 v); // 0x0000000181C34870-0x0000000181C348C0
		internal static float TriangleArea(float2 va, float2 vb, float2 vc); // 0x0000000181C362E0-0x0000000181C36340
		internal static float Sign(float2 p1, float2 p2, float2 p3); // 0x0000000181C32500-0x0000000181C32560
		internal static bool IsInsideTriangle(float2 pt, float2 v1, float2 v2, float2 v3); // 0x0000000181C34A70-0x0000000181C34BC0
		internal static bool IsInsideTriangleApproximate(float2 pt, float2 v1, float2 v2, float2 v3); // 0x0000000181C348C0-0x0000000181C34A70
		internal static bool IsInsideCircle(float2 a, float2 b, float2 c, float2 p); // 0x0000000181C34640-0x0000000181C34870
		internal static void GetIntermediate(ushort a, ushort b, ref int3 res); // 0x0000000181C34300-0x0000000181C34330
		internal static unsafe void RawSort(int3* data, int length); // 0x0000000181C34CA0-0x0000000181C34D60
		internal static int GenerateOutlineFromTriangleIndices([IsReadOnly] in NativeArray<ushort> indices, ref NativeArray<int2> outline); // 0x0000000181C33E30-0x0000000181C34300
		internal static void BuildTriangles(NativeArray<float2> vertices, int vertexCount, NativeArray<int> indices, int indexCount, ref NativeArray<UTriangle> triangles, ref int triangleCount, ref float maxArea, ref float avgArea, ref float minArea); // 0x0000000181C331C0-0x0000000181C33500
		internal static void BuildTriangles(NativeArray<float2> vertices, int vertexCount, NativeArray<int> indices, int indexCount, ref Array<UTriangle> triangles, ref int triangleCount, ref float maxArea, ref float avgArea, ref float minArea); // 0x0000000181C33500-0x0000000181C33850
		internal static void BuildTriangles(NativeArray<float2> vertices, int vertexCount, NativeArray<int> indices, int indexCount, ref NativeArray<UTriangle> triangles, ref int triangleCount, ref float maxArea, ref float avgArea, ref float minArea, ref float maxEdge, ref float avgEdge, ref float minEdge); // 0x0000000181C32D10-0x0000000181C331C0
		internal static void BuildTrianglesAndEdges(NativeArray<float2> vertices, int vertexCount, NativeArray<int> indices, int indexCount, ref NativeArray<UTriangle> triangles, ref int triangleCount, ref NativeArray<int4> delaEdges, ref int delaEdgeCount, ref float maxArea, ref float avgArea, ref float minArea); // 0x0000000181C32910-0x0000000181C32D10
		private static void CopyGraph(NativeArray<float2> srcPoints, int srcPointCount, ref NativeArray<float2> dstPoints, ref int dstPointCount, NativeArray<int2> srcEdges, int srcEdgeCount, ref NativeArray<int2> dstEdges, ref int dstEdgeCount); // 0x0000000181C33D40-0x0000000181C33E30
		private static void CopyGeometry(NativeArray<int> srcIndices, int srcIndexCount, ref NativeArray<int> dstIndices, ref int dstIndexCount, NativeArray<float2> srcVertices, int srcVertexCount, ref NativeArray<float2> dstVertices, ref int dstVertexCount); // 0x0000000181C33C60-0x0000000181C33D40
		private static void TransferOutput(NativeArray<int2> srcEdges, int srcEdgeCount, ref NativeArray<int2> dstEdges, ref int dstEdgeCount, NativeArray<int> srcIndices, int srcIndexCount, ref NativeArray<int> dstIndices, ref int dstIndexCount, NativeArray<float2> srcVertices, int srcVertexCount, ref NativeArray<float2> dstVertices, ref int dstVertexCount); // 0x0000000181C361B0-0x0000000181C362E0
		private static void TransferOutputEdgesToVertexCount(NativeArray<int2> srcEdges, int srcEdgeCount, int vertexCount, ref NativeArray<int2> dstEdges, ref int dstEdgeCount); // 0x0000000181C36140-0x0000000181C361B0
		private static void GraphConditioner(NativeArray<float2> points, ref NativeArray<float2> pgPoints, ref int pgPointCount, ref NativeArray<int2> pgEdges, ref int pgEdgeCount, bool resetTopology); // 0x0000000181C34330-0x0000000181C34640
		private static void Reorder(int startVertexCount, int index, ref NativeArray<int> indices, ref int indexCount, ref NativeArray<float2> vertices, ref int vertexCount); // 0x0000000181C34D60-0x0000000181C34E00
		internal static void VertexCleanupConditioner(int startVertexCount, ref NativeArray<int> indices, ref int indexCount, ref NativeArray<float2> vertices, ref int vertexCount); // 0x0000000181C36340-0x0000000181C36450
		public static bool TessellateMainThread(Allocator allocator, ref NativeArray<float2> points, ref NativeArray<int2> edges, out NativeArray<float2> outVertices, out NativeArray<int> outIndices); // 0x0000000181C35C80-0x0000000181C35C90
		public static float4 ConvexQuad(Allocator allocator, NativeArray<float2> points, NativeArray<int2> edges, ref NativeArray<float2> outVertices, ref int outVertexCount, ref NativeArray<int> outIndices, ref int outIndexCount, ref NativeArray<int2> outEdges, ref int outEdgeCount); // 0x0000000181C33A30-0x0000000181C33C60
		public static float4 Tessellate(Allocator allocator, [IsReadOnly] in NativeArray<float2> points, [IsReadOnly] in NativeArray<int2> edges, ref NativeArray<float2> outVertices, out int outVertexCount, ref NativeArray<int> outIndices, out int outIndexCount, ref NativeArray<int2> outEdges, out int outEdgeCount, bool runPlanarGraph); // 0x0000000181C35C90-0x0000000181C36140
		public static float4 Subdivide(Allocator allocator, NativeArray<float2> points, NativeArray<int2> edges, ref NativeArray<float2> outVertices, ref int outVertexCount, ref NativeArray<int> outIndices, ref int outIndexCount, ref NativeArray<int2> outEdges, ref int outEdgeCount, float areaFactor, float targetArea, int refineIterations, int smoothenIterations); // 0x0000000181C34E00-0x0000000181C35C80
	}
}
